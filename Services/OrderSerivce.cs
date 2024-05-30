using System.Diagnostics;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Order;
using AlaThuqk.Entities;
using AlaThuqk.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order = AlaThuqk.Entities.Order;

namespace AlaThuqk.Services{
    public interface IOrderServices{
        Task<(OrderDto? order, string? error)> Add(OrderForm orderForm, Guid userId);
        Task<(List<OrderDto> orders, int? totalCount, string? error)> GetAll(BaseFilter baseFilter);
        Task<(OrderDto? order, string?error)> Update(OrderUpdate orderUpdate, Guid id);
        Task<(OrderDto? order, string?)> Delete(Guid id);

        Task<(OrderDto? orderDto, string? error)> GetById(Guid id);

        Task<(List<OrderDto> orders, int? totalCount, string? error)> GetMyOrders(BaseFilter baseFilter, Guid userId);
    }

    public class OrderService : IOrderServices{
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public OrderService(IMapper mapper, IRepositoryWrapper repositoryWrapper) {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(OrderDto? order, string? error)> Add(OrderForm orderForm, Guid userId) {
            var order = _mapper.Map<Order>(orderForm);
            order.UserId = userId;
            var user = await _repositoryWrapper.User.GetById(userId);
            if (user == null) return (null, "user not found");
            var orderItems = order.OrderItems;
            var price = 0;
            foreach (var orderItem in orderItems) {
                if (orderItem.PrintComponents == null && orderItem.TemplateId == null)
                    return (null, "OrderItem must have a template or printComponents");


                if (orderItem.Quantity == null || orderItem.Quantity <= 0)
                    return (null, "OrderItem must have a quantity");


                var color = await _repositoryWrapper.Color.Get(
                    color1 => color1.Id == orderItem.ColorId,
                    colors => colors
                        .Include(color1 => color1.Size)
                );
                if (color == null) return (null, "Item not found");

                if (orderItem.TemplateId != null) {
                    var template = await _repositoryWrapper.Template.Get(
                        template1 => template1.Id == orderItem.TemplateId &&
                                     template1.Sizes.Any(size => size.Id == color.SizeId)
                    );
                    if (template == null) return (null, "Template not found");
                    price += template.Price * orderItem.Quantity ?? 0;
                    orderItem.Type = OrderItemType.Template;
                }
                else if (orderItem.PrintComponents != null) {
                    orderItem.ProductId = color.Size.ProductId;
                    var product = await _repositoryWrapper.Product.GetById(orderItem.ProductId.Value);
                    if (product == null) return (null, "Product not found");
                    price += product.Price * orderItem.Quantity;
                    orderItem.Type = OrderItemType.Product;
                }

                if (color.Quantity < orderItem.Quantity) return (null, "The quantity of the product is not available");
                color.Quantity -= orderItem.Quantity;
                color = await _repositoryWrapper.Color.Update(color);
                if (color == null)
                    return (null, "Failed to Update the available quantity in the inventory");
            }

            if (orderForm.AddressId == null) return (null, "AddressId is required");

            var address = await _repositoryWrapper.Address.Get(
                address1 => address1.Id == orderForm.AddressId.Value,
                addresses =>
                    addresses.Include(address1 => address1.Governorate)
            );
            if (address == null) return (null, "Address not found");
            var deleveryPrice = address.Governorate.DeliveryPrice;
            order.Price = price;
            order.DeliveryPrice = deleveryPrice;
            order.TotalPrice = price + deleveryPrice;

            var result = await _repositoryWrapper.Order.Add(order);
            if (result == null) return (null, "order could not Add");
            var orderDto = _mapper.Map<OrderDto>(result);
            return (orderDto, null);
        }


        public async Task<(List<OrderDto> orders, int? totalCount, string? error)> GetAll(BaseFilter baseFilter) {
            var (orders, totalCount) = await _repositoryWrapper.Order.GetAll(
                orders =>
                    orders
                        .Include(order => order.OrderItems)
                        .ThenInclude(item => item.Product)
                        .ThenInclude(product => product.Category)
                        .Include(order => order.OrderItems)
                        .ThenInclude(item => item.Color)
                        .ThenInclude(color => color.Size)
                        .Include(order => order.UserAddress)
                        .Include(order => order.OrderItems)
                        .ThenInclude(oi => oi.PrintComponents)
                        .Include(order => order.OrderItems)
                        .ThenInclude(item => item.Template)
                        .ThenInclude(template => template.Components),
                baseFilter.PageNumber, baseFilter.PageSize);


            var orderDto = orders.Select(order => _mapper.Map<OrderDto>(order)).ToList();

            return (orderDto, totalCount, null);
        }

        public async Task<(OrderDto? order, string? error)> Update(OrderUpdate orderUpdate, Guid id) {
            var order = await _repositoryWrapper.Order.GetById(id);
            if (order == null) {
                return (null, "order not found");
            }

            order = _mapper.Map(orderUpdate, order);
            var response = await _repositoryWrapper.Order.Update(order);
            var orderDto = _mapper.Map<OrderDto>(response);
            return response == null ? (null, "order could not be updated") : (orderDto, null);
        }

        public async Task<(OrderDto? order, string?)> Delete(Guid id) {
            var order = await _repositoryWrapper.Order.GetById(id);
            if (order == null) return (null, "order not found");
            var result = await _repositoryWrapper.Order.Delete(id);
            var orderDto = _mapper.Map<OrderDto>(result);
            return result == null ? (null, "order could not be deleted") : (orderDto, null);
        }

        public async Task<(OrderDto? orderDto, string? error)> GetById(Guid id) {
            var order = await _repositoryWrapper.Order.Get(
                order1 => order1.Id == id,
                orders =>
                    orders.Include(order => order.OrderItems)
                        .ThenInclude(item => item.Product)
                        .Include(order => order.UserAddress)
                        .Include(order => order.OrderItems)
                        .ThenInclude(oi => oi.PrintComponents)
            );
            if (order == null) return (null, "order not found");
            var orderDto = _mapper.Map<OrderDto>(order);
            return (orderDto, null);
        }

        public async Task<(List<OrderDto> orders, int? totalCount, string? error)> GetMyOrders(
            BaseFilter baseFilter,
            Guid userId) {
            var (orders, totalCount) = await _repositoryWrapper.Order.GetAll(
                orders => orders.UserId == userId,
                orders =>
                    orders.Include(order => order.OrderItems)
                        .ThenInclude(oi => oi.Color)
                        .ThenInclude(color => color.Size)
                        .ThenInclude(size => size.Product),
                baseFilter.PageNumber, baseFilter.PageSize);

            var orderDto = _mapper.Map<List<OrderDto>>(orders);
            orderDto.ForEach(orderDto =>
            {
                orderDto.OrderItems.ForEach(orderItemDto =>
                {
                    var color = orders.Find(order => order.Id == orderDto.Id)?.OrderItems
                        .FirstOrDefault(orderItem => orderItem.Id == orderItemDto.Id)?.Color;
                    var size = color.Size;
                    var product = size.Product;
                    orderItemDto.ProductId = product.Id.ToString();
                    orderItemDto.Color = color.ColorText;
                    orderItemDto.ColorId = color.Id.ToString();
                    orderItemDto.Size = size.SizeText;
                    orderItemDto.SizeId = size.Id.ToString();
                });
            });
            return (orderDto, totalCount, null);
        }
    }
}