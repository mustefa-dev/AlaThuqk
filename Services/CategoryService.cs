using AlaThuqk.DATA;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Category;
using AlaThuqk.Repository;
using AutoMapper;
using AlaThuqk.Entities;
using AlaThuqk.Helpers.OneSignal;
using Category = AlaThuqk.Entities.Category;

namespace AlaThuqk.Services
{
    
    public interface ICategoryServices
    {
        
        Task<(Entities.Category? category, string? error)> add(CategoryForm categoryForm);
        Task<(List<Entities.Category> categorys,int? totalCount,string? error)> GetAll(BaseFilter  baseFilter);
        Task<(Entities.Category? category,string?error)> update(CategoryUpdate categoryUpdate, Guid id);
        Task<(Entities.Category? category, string?)> Delete(Guid id);
        Task<(Entities.Category? category, string? error)> GetById(Guid id);
        
    }
    public class CategoryService : ICategoryServices
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IMapper mapper, IRepositoryWrapper repositoryWrapper,IConfiguration configuration,DataContext dataContext)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(Entities.Category? category, string? error)> add(CategoryForm categoryForm)
        {
            var category = _mapper.Map<Entities.Category>(categoryForm);
            var result = await _repositoryWrapper.Category.Add(category);
            return result == null ? (null, "category could not Add") : (category, null);
            
           
        }
        public async Task<(List<Category> categorys, int? totalCount, string? error)> GetAll(BaseFilter baseFilter)
        {
            var (categorys, totalCount) = await _repositoryWrapper.Category.
                GetAll(baseFilter.PageNumber , baseFilter.PageSize);
            return (categorys, totalCount, null);
        }
        
        public async Task<(Entities.Category? category, string? error)> update(CategoryUpdate categoryUpdate, Guid id)
        {
            var category = await _repositoryWrapper.Category.GetById(id);
            if (category == null)
            {
                return (null, "category not found");
            }
            category = _mapper.Map(categoryUpdate, category);
            var response = await _repositoryWrapper.Category.Update(category);
            return response == null ? (null, "category could not be updated") : (category, null);
        }
        public async Task<(Entities.Category? category, string?)> Delete(Guid id)
        {
            var category = await _repositoryWrapper.Category.GetById(id);
            if (category == null) return (null, "category not found");
            var result = await _repositoryWrapper.Category.Delete(id);
            return result == null ? (null, "category could not be deleted") : (result, null);
        }
        public async Task<(Entities.Category? category, string? error)> GetById(Guid id)
        {
            var category = await _repositoryWrapper.Category.GetById(id);
            return category == null ? (null, "category not found") : (category, null);
        }
    }
}