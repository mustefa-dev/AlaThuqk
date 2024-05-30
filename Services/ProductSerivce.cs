using AlaThuqk.DATA;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.DATA.DTOs.Order;
using AlaThuqk.DATA.DTOs.Product;
using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.Repository;
using AutoMapper;
using BackEndStructuer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Product = AlaThuqk.Entities.Product;

namespace AlaThuqk.Services{
    public interface IProductServices{
        Task<(ProductDto? productDto, string? error)> Add(ProductForm productForm);


        Task<(List<ProductDto> productDto, int? totalCount, string? error)> GetAll(ProductFilter baseFilter,
            Guid userId);

        Task<(ProductDto? productDto, string error)> GetById(Guid id, Guid userId);
        Task<(ProductDto? productDto, string?error)> update(ProductUpdate productUpdate, Guid id);
        Task<(ProductDto? productDto, string?)> Delete(Guid id);
        Task<(List<SizeDto> sizeDtos, string? error)> GetSizes(Guid id);

        Task<(List<ColorDto> sizeDtos, string? error)> GetColors(Guid id, Guid sizeId);

        Task<(List<ProductDto> productDtos, int? totalCount, string? error)> GetMostSoldProducts(
            ProductFilter baseFilter);

        Task<(List<ProductDto>, int? totalCount, string? error)> GetMostLikedTemplate(ProductFilter baseFilter);

        Task<(ProductDto? productDto, string? error)> LikeUnlikeProduct(Guid userId, Guid productId);

        Task<(List<ProductDto> productDtos, int? totalCount, string? error)> GetMyLikedProducts(
            ProductFilter baseFilter,
            Guid userId);
    }

    public class ProductService : IProductServices{
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProductService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IConfiguration configuration,
            DataContext dataContext) {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(ProductDto? productDto, string? error)> Add(ProductForm productForm) {
            var category = await _repositoryWrapper.Category.GetById(productForm.CategoryId);
            if (category == null) return (null, "category not found");
            var product = _mapper.Map<Product>(productForm);
            var result = await _repositoryWrapper.Product.Add(product);
            var productDto = _mapper.Map<ProductDto>(result);
            return result == null ? (null, "product could not Add") : (productDto, null);
        }

        public async Task<(List<ProductDto> productDto, int? totalCount, string? error)> GetAll(
            ProductFilter baseFilter,
            Guid userId) {
            baseFilter.search ??= "";
            var (products, totalCount) = await _repositoryWrapper.Product.GetAll(
                product => product.Sizes.Any(size =>
                    size.Colors.Any(color => color.Quantity > 0) || (
                        product.Name.Contains(baseFilter.search))),
                product => product.Include(product => product.Sizes).ThenInclude(size => size.Colors)
                    .Include(product => product.Category)
                ,
                baseFilter.PageNumber, baseFilter.PageSize);


            var productDtos = products.Select(
                    product => _mapper.Map<ProductDto>(products.Find(product1 => product1.Id == product.Id)))
                .ToList();

            foreach (var productDto in productDtos)
            {
                var isLiked = await _repositoryWrapper.UserLike.Get(x => x.ProductId == productDto.Id && x.UserId == userId);
                productDto.IsLiked = isLiked != null;
            }

            return (productDtos, totalCount, null);
        }


        public async Task<(ProductDto? productDto, string? error)> GetById(Guid id, Guid userId)
        {
            var product = await _repositoryWrapper.Product.Get(
                product => product.Id == id,
                product => product.Include(product => product.Sizes).ThenInclude(size => size.Colors)
                    .Include(product => product.Category)
                    .Include(product => product.UserLikes) 
            );

            var productDto = _mapper.Map<ProductDto>(product);
            if (productDto == null) return (null, "product not found");

            int realLikesCount = product.UserLikes?.Count ?? 0; 

            productDto.Likes = realLikesCount; 

            var isLiked = await _repositoryWrapper.UserLike.Get(x => x.ProductId == id && x.UserId == userId);
            productDto.IsLiked = isLiked != null;

            return product == null ? (null, "category not found") : (productDto, null);
        }


        public async Task<(ProductDto? productDto, string? error)> update(ProductUpdate productUpdate, Guid id) {
            var product = await _repositoryWrapper.Product.GetById(id);
            if (product == null) {
                return (null, "product not found");
            }

            product = _mapper.Map(productUpdate, product);
            var response = await _repositoryWrapper.Product.Update(product);
            var productDto = _mapper.Map<ProductDto>(response);
            return response == null ? (null, "product could not be updated") : (productDto, null);
        }

        public async Task<(ProductDto? productDto, string?)> Delete(Guid id) {
            var product = await _repositoryWrapper.Product.GetById(id);
            if (product == null) return (null, "product not found");
            var result = await _repositoryWrapper.Product.Delete(id);
            var productDto = _mapper.Map<ProductDto>(result);
            return result == null ? (null, "product could not be deleted") : (productDto, null);
        }

        public async Task<(List<SizeDto> sizeDtos, string? error)> GetSizes(Guid id) {
            var product = await _repositoryWrapper.Product.GetById(id);
            if (product == null) return (null, "product not found");
            var (data, totalCount) = await _repositoryWrapper.Size.GetAll(size => size.ProductId == id);
            var sizeDtos = _mapper.Map<List<SizeDto>>(data);
            return (sizeDtos, null);
        }

        public async Task<(List<ColorDto> sizeDtos, string? error)> GetColors(Guid id, Guid sizeId) {
            var product = await _repositoryWrapper.Product.GetById(id);
            if (product == null) return (null, "product not found");
            var (data, totalCount) = await _repositoryWrapper.Color.GetAll(color => color.SizeId == sizeId);
            var sizeDtos = _mapper.Map<List<ColorDto>>(data);
            return (sizeDtos, null);
        }


        public async Task<(List<ProductDto> productDtos, int? totalCount, string? error)> GetMostSoldProducts(
            ProductFilter baseFilter) {
            baseFilter.search ??= "";
            var mostSoldProductInfo = (await _repositoryWrapper.Order.GetAll(
                    order => baseFilter.search.Trim().IsNullOrEmpty() || order.OrderItems.Any(item =>
                        item.Color.Size.Product.Name.Contains(baseFilter.search!)),
                    include: o => o.Include(order => order.OrderItems)
                        .ThenInclude(item => item.Color.Size.Product).ThenInclude(product => product.Sizes)
                        .ThenInclude(size => size.Colors)
                        .Include(order => order.OrderItems).ThenInclude(item => item.Color.Size.Product.Category),
                    baseFilter.PageNumber, baseFilter.PageSize
                )).data
                .SelectMany(order =>
                    order.OrderItems.Select(item => new
                        { Product = item.Color.Size.Product, QuantitySold = item.Quantity }))
                .GroupBy(item => item.Product)
                .Select(group => new { Product = group.Key, TotalQuantitySold = group.Sum(item => item.QuantitySold) })
                .OrderByDescending(p => p.TotalQuantitySold)
                .Select(p => _mapper.Map<ProductDto>(p.Product))
                .ToList() ?? new List<ProductDto>();

            return (mostSoldProductInfo, mostSoldProductInfo.Count, null);
        }


        public async Task<(List<ProductDto>, int? totalCount, string? error)> GetMostLikedTemplate(
            ProductFilter baseFilter) {
            baseFilter.search ??= "";

            var mostLikedProductInfo = (await _repositoryWrapper.Product.GetAll(
                    product => baseFilter.search.Trim().IsNullOrEmpty() || product.Name.Contains(baseFilter.search!),
                    include: product => product.Include(product => product.UserLikes)
                        .Include(product => product.Sizes)
                        .ThenInclude(size => size.Colors)
                        .Include(product => product.Category), 
                    baseFilter.PageNumber, baseFilter.PageSize
                )).data
                .Select(product => new { Product = product, Likes = product.UserLikes.Count })
                .OrderByDescending(p => p.Likes)
                .Select(p => _mapper.Map<ProductDto>(p.Product))
                .ToList() ?? new List<ProductDto>();
            
            return (mostLikedProductInfo, mostLikedProductInfo.Count, null);
        }


        public async Task<(ProductDto? productDto, string? error)> LikeUnlikeProduct(Guid userId, Guid productId) {
            var product = await _repositoryWrapper.Product.GetById(productId);
            if (product == null) return (null, "product not found");
            var user = await _repositoryWrapper.User.GetById(userId);
            if (user == null) return (null, "user not found");
            var userLike = await _repositoryWrapper.UserLike.Get(x => x.ProductId == productId && x.UserId == userId);
            if (userLike == null) {
                var newUserLike = new UserLike()
                {
                    ProductId = productId,
                    UserId = userId
                };
                var result = await _repositoryWrapper.UserLike.Add(newUserLike);
                product.Likes++; await _repositoryWrapper.Product.Update(product);
                

                var productDto = _mapper.Map<ProductDto>(product);
                return result == null ? (null, "product could not be liked") : (productDto, null);
            }
            else {
                var result = await _repositoryWrapper.UserLike.Delete(userLike.Id);
                product.Likes--; await _repositoryWrapper.Product.Update(product);
                var productDto = _mapper.Map<ProductDto>(product);
                return result == null ? (null, "product could not be unliked") : (productDto, null);
            }
        }

        public async Task<(List<ProductDto> productDtos, int? totalCount, string? error)> GetMyLikedProducts(
            ProductFilter baseFilter, Guid userId) {
            var (products, totalCount) = await _repositoryWrapper.Product.GetAll(
                product => product.UserLikes.Any(userLike => userLike.UserId == userId),
                product => product.Include(product => product.Sizes).ThenInclude(size => size.Colors)
                    .Include(product => product.Category)
                ,
                baseFilter.PageNumber, baseFilter.PageSize);

            var productDto = _mapper.Map<List<ProductDto>>(products);
            foreach (var product in productDto) {
                var isLiked =
                    await _repositoryWrapper.UserLike.Get(x => x.ProductId == product.Id && x.UserId == userId);
                product.IsLiked = isLiked != null;
            }
            return (productDto, totalCount, null);
        }
    }
}