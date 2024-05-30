using AlaThuqk.DATA;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.PrintComponent;
using AlaThuqk.Repository;
using AutoMapper;
using AlaThuqk.Entities;
using AlaThuqk.Helpers.OneSignal;
using PrintComponent = AlaThuqk.Entities.PrintComponent;

namespace AlaThuqk.Services{
    public interface IPrintComponentServices{
        Task<(PrintComponentDto? printcomponentDto, string? error)> add(PrintComponentForm printComponentForm);
        Task<(List<PrintComponent> printcomponents, int? totalCount, string? error)> GetAll(BaseFilter baseFilter);
        Task<(PrintComponent? printcomponent, string?error)> update(PrintComponentUpdate printComponentUpdate, Guid id);
        Task<(PrintComponent? printcomponent, string?)> Delete(Guid id);
        Task<(PrintComponent? printcomponent, string? error)> GetById(Guid id);
    }

    public class PrintComponentServices : IPrintComponentServices{
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PrintComponentServices(IMapper mapper, IRepositoryWrapper repositoryWrapper,
            IConfiguration configuration, DataContext dataContext) {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(PrintComponentDto? printcomponentDto, string? error)> add(
            PrintComponentForm printComponentForm) {
            var printcomponent = _mapper.Map<Entities.PrintComponent>(printComponentForm);
            var result = await _repositoryWrapper.PrintComponent.Add(printcomponent);
            var printcomponentDto = _mapper.Map<PrintComponentDto>(result);
            return result == null ? (null, "printcomponent could not Add") : (printcomponentDto, null);
        }

        public async Task<(List<PrintComponent> printcomponents, int? totalCount, string? error)> GetAll(
            BaseFilter baseFilter) {
            var (printcomponents, totalCount) = await _repositoryWrapper.PrintComponent.GetAll(baseFilter.PageNumber ,
                baseFilter.PageSize);

            return (printcomponents, totalCount, null);
        }

        public async Task<(PrintComponent? printcomponent, string? error)> update(
            PrintComponentUpdate printComponentUpdate, Guid id) {
            var printcomponent = await _repositoryWrapper.PrintComponent.GetById(id);
            if (printcomponent == null) {
                return (null, "printcomponent not found");
            }

            printcomponent = _mapper.Map(printComponentUpdate, printcomponent);
            await _repositoryWrapper.PrintComponent.Update(printcomponent);
            return (printcomponent, null);
        }

        public async Task<(PrintComponent? printcomponent, string?)> Delete(Guid id) {
            var printComponent = await _repositoryWrapper.Size.GetById(id);
            var printComponentDto = _mapper.Map<PrintComponent>(printComponent);
            if (printComponent == null) return (null, "size not found");
            return (printComponentDto, null);
        }

        public async Task<(PrintComponent? printcomponent, string? error)> GetById(Guid id) {
            var printcomponent = await _repositoryWrapper.PrintComponent.GetById(id);
            var printcomponentDto = _mapper.Map<PrintComponent>(printcomponent);
            return (printcomponentDto, null);
        }
    }
}