using AlaThuqk.DATA;
using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.Repository;
using AutoMapper;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.Entities;
using AlaThuqk.Helpers.OneSignal;
using Color = AlaThuqk.Entities.Color;

namespace AlaThuqk.Services
{
    
    public interface IColorServices
    {
        
        Task<(Entities.Color? color, string? error)> add(ColorForm colorForm);
        Task<(List<Entities.Color> colors,int? totalCount,string? error)> GetAll(BaseFilter  baseFilter);
        Task<(Entities.Color? color,string?error)> update(ColorUpdate colorUpdate, Guid id);
        Task<(Entities.Color? color, string?)> Delete(Guid id);
        Task<(Entities.Color? color, string? error)> GetById(Guid id);
        
    }
    public class ColorService : IColorServices
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ColorService(IMapper mapper, IRepositoryWrapper repositoryWrapper,IConfiguration configuration,DataContext dataContext)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(Entities.Color? color, string? error)> add(ColorForm colorForm)
        {
            var color = _mapper.Map<Entities.Color>(colorForm);
            var result = await _repositoryWrapper.Color.Add(color);
            return result == null ? (null, "color could not Add") : (color, null);
            
           
        }
        public async Task<(List<Entities.Color> colors, int? totalCount, string? error)> GetAll(BaseFilter baseFilter)
        {
            var (colors, totalCount) = await _repositoryWrapper.Color.
                GetAll(baseFilter.PageNumber , baseFilter.PageSize);
            return (colors, totalCount, null);
        }
        public async Task<(Entities.Color? color, string? error)> update(ColorUpdate colorUpdate, Guid id)
        {
            var color = await _repositoryWrapper.Color.GetById(id);
            if (color == null)
            {
                return (null, "color not found");
            }
            color = _mapper.Map(colorUpdate, color);
            var response = await _repositoryWrapper.Color.Update(color);
            return response == null ? (null, "color could not be updated") : (color, null);
        }
        public async Task<(Entities.Color? color, string?)> Delete(Guid id)
        {
            var color = await _repositoryWrapper.Color.GetById(id);
            if (color == null) return (null, "color not found");
            var result = await _repositoryWrapper.Color.Delete(id);
            return result == null ? (null, "color could not be deleted") : (result, null);
        }
        public async Task<(Entities.Color? color, string? error)> GetById(Guid id)
        {
            var color = await _repositoryWrapper.Color.GetById(id);
            return color == null ? (null, "color not found") : (color, null);
        }
        
    }
}