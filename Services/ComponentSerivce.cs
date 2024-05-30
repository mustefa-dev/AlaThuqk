using AlaThuqk.DATA;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.Repository;
using AutoMapper;
using AlaThuqk.Entities;
using AlaThuqk.Helpers.OneSignal;
using Component = AlaThuqk.Entities.Component;

namespace AlaThuqk.Services{

    public interface IComponentServices{

        Task<(Entities.Component? component, string? error)> add(ComponentForm componentForm);
        Task<(List<Entities.Component> components, int? totalCount, string? error)> GetAll(BaseFilter baseFilter);
        Task<(Entities.Component? component, string?error)> update(ComponentUpdate componentUpdate, Guid id);
        Task<(Entities.Component? component, string?)> Delete(Guid id);
        Task<(Entities.Component? component, string? error)> GetById(Guid id);

    }

    public class ComponentService : IComponentServices{
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ComponentService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IConfiguration configuration,
            DataContext dataContext) {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(Entities.Component? component, string? error)> add(ComponentForm componentForm) {
            var component = _mapper.Map<Entities.Component>(componentForm);
            var result = await _repositoryWrapper.Component.Add(component);
            return result == null ? (null, "component could not Add") : (component, null);


        }

        public async Task<(List<Entities.Component> components, int? totalCount, string? error)> GetAll(
            BaseFilter baseFilter) {
            var (components, totalCount) = await _repositoryWrapper.Component.
                GetAll(baseFilter.PageNumber, baseFilter.PageSize);
            return (components, totalCount, null);
        }

        public async Task<(Entities.Component? component, string? error)> update(ComponentUpdate componentUpdate,
            Guid id) {
            var component = await _repositoryWrapper.Component.GetById(id);
            if (component == null) {
                return (null, "component not found");
            }

            component = _mapper.Map(componentUpdate, component);
            var response = await _repositoryWrapper.Component.Update(component);
            return response == null ? (null, "component could not be updated") : (component, null);
        }

        public async Task<(Entities.Component? component, string?)> Delete(Guid id) {
            var component = await _repositoryWrapper.Component.GetById(id);
            if (component == null) return (null, "component not found");
            var result = await _repositoryWrapper.Component.Delete(id);
            return result == null ? (null, "component could not be deleted") : (result, null);
        }

        public async Task<(Entities.Component? component, string? error)> GetById(Guid id) {
            var component = await _repositoryWrapper.Component.GetById(id);
            if (component == null) return (null, "component not found");
            return (component, null);
        }
    }
}