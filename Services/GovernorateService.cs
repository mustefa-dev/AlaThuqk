using AlaThuqk.DATA.DTOs.Governorates;
using AlaThuqk.Entities;
using AlaThuqk.Repository;
using AutoMapper;
using Gaz_BackEnd.DATA.DTOs.Governorates;

namespace AlaThuqk.Services{
    public interface IGovernorateService{
        Task<(List<GovernoratesDTO> governorate, int? totalCount, string? error)> All();

        Task<(List<GovernoratesDTO> governorate, int? totalCount, string? error)> GetAll(
            GovernorateFilter governorateFilter);

        Task<(GovernoratesDTO? governorate, string? error)> GetById(Guid id);
        Task<(GovernoratesDTO? governorate, string? error)> add(GovernorateForm governorateForm);
        Task<(GovernoratesDTO? governorate, string? error)> update(GovernorateForm governorateForm, Guid id);
        Task<(GovernoratesDTO? governorate, string?)> Delete(Guid id);
    }

    public class GovernoratesService : IGovernorateService{
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GovernoratesService(IMapper mapper, IRepositoryWrapper repositoryWrapper) {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(List<GovernoratesDTO> governorate, int? totalCount, string? error)> All() {
            var (governorates, totalCount) = await _repositoryWrapper.Governorates.GetAll(x => (x.Deleted != true));
            var result = _mapper.Map<List<GovernoratesDTO>>(governorates);
            return (result, totalCount, null);
        }

        public async Task<(List<GovernoratesDTO> governorate, int? totalCount, string? error)> GetAll(
            GovernorateFilter governorateFilter) {
            var (governorates, totalCount) = await _repositoryWrapper.Governorates.GetAll(
                governorateFilter.PageSize);

            var result = _mapper.Map<List<GovernoratesDTO>>(governorates);
            return (result, totalCount, null);
        }

        public async Task<(GovernoratesDTO? governorate, string? error)> GetById(Guid id) {
            var getGovernorate = await _repositoryWrapper.Governorates.Get(u => u.Id == id && u.Deleted != true);
            if (getGovernorate == null) return (null, "المحافظة غير متوفرة");
            var GovernorateDto = _mapper.Map<GovernoratesDTO>(getGovernorate);
            return (GovernorateDto, null);
        }

        public async Task<(GovernoratesDTO? governorate, string? error)> add(GovernorateForm governorateForm) {
           
            var governorate = _mapper.Map<Governorate>(governorateForm);
            var result = await _repositoryWrapper.Governorates.Add(governorate);
            var governorateDTO = _mapper.Map<GovernoratesDTO>(result);
            return result == null ? (null, "لا يمكن اضافة محافظة") : (governorateDTO, null);
        }

        public async Task<(GovernoratesDTO? governorate, string? error)> update(GovernorateForm governorateForm,
            Guid id) {
            var getGovernorate = await _repositoryWrapper.Governorates.GetById(id);
            if (getGovernorate == null) {
                return (null, "المحافظة غير متوفرة");
            }

            

            getGovernorate = _mapper.Map(governorateForm, getGovernorate);
            var response = await _repositoryWrapper.Governorates.Update(getGovernorate);
            var governorateDTO = _mapper.Map<GovernoratesDTO>(response);
            return response == null ? (null, "لا يمكن تحديث المحافظة") : (governorateDTO, null);
        }

        public async Task<(GovernoratesDTO? governorate, string?)> Delete(Guid id) {
            var getGovernorate = await _repositoryWrapper.Governorates.GetById(id);
            if (getGovernorate == null) return (null, "المحافظة غير متوفرة");
            getGovernorate.Deleted = true;
            var response = await _repositoryWrapper.Governorates.Update(getGovernorate);
            var governorateDTO = _mapper.Map<GovernoratesDTO>(response);
            return response == null ? (null, "لا يمكن حذف المحافظة") : (governorateDTO, null);
        }
    }
}