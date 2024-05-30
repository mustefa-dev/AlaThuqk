using AlaThuqk.DATA;
using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.Repository;
using AutoMapper;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.Entities;
using AlaThuqk.Helpers.OneSignal;
using Size = AlaThuqk.Entities.Size;

namespace AlaThuqk.Services{

    public interface ISizeServices{

        Task<(SizeDto? sizeDto, string? error)> add(SizeForm sizeForm);
        Task<(List<SizeDto> sizes, int? totalCount, string? error)> GetAll(BaseFilter baseFilter);
        Task<(SizeDto? size, string?error)> update(SizeUpdate sizeUpdate, Guid id);
        Task<(SizeDto? size, string?)> Delete(Guid id);
        Task<(SizeDto? size, string? error)> GetById(Guid id);

    }

    public class SizeService : ISizeServices{
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SizeService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IConfiguration configuration,
            DataContext dataContext) {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(SizeDto? sizeDto, string? error)> add(SizeForm sizeForm) {
            var size = _mapper.Map<Entities.Size>(sizeForm);
            var result = await _repositoryWrapper.Size.Add(size);
            var sizeDto = _mapper.Map<SizeDto>(result);
            return result == null ? (null, "size could not Add") : (sizeDto, null);


        }

        public async Task<(List<SizeDto> sizes, int? totalCount, string? error)> GetAll(BaseFilter baseFilter) {
            var (sizes, totalCount) = await _repositoryWrapper.Size.GetAll
                (baseFilter.PageSize, baseFilter.PageNumber); 
            var result = _mapper.Map<List<SizeDto>>(sizes);
            return (result, totalCount, null);
        }

        public async Task<(SizeDto? size, string? error)> update(SizeUpdate sizeUpdate, Guid id) {
            var size = await _repositoryWrapper.Size.GetById(id);
            if (size == null) {
                return (null, "size not found");
            }

            size = _mapper.Map(sizeUpdate, size);
            var response = await _repositoryWrapper.Size.Update(size);
            var sizeDto = _mapper.Map<SizeDto>(response);
            return response == null ? (null, "size could not Update") : (sizeDto, null);
        }

        public async Task<(SizeDto? size, string?)> Delete(Guid id) {
            var size = await _repositoryWrapper.Size.GetById(id);
            if (size == null) return (null, "size not found");
            var result = await _repositoryWrapper.Size.Delete(id);
            var sizeDto = _mapper.Map<SizeDto>(result);
            return result == null ? (null, "size could not delete") : (sizeDto, null);
        }

        public async Task<(SizeDto? size, string? error)> GetById(Guid id) {
            var size = await _repositoryWrapper.Size.GetById(id);
            var sizeDto = _mapper.Map<SizeDto>(size);
            if (size == null) return (null, "size not found");
            return (sizeDto, null);
        }
    }
}