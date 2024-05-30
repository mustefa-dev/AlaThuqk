using AlaThuqk.Repository;
using AutoMapper;
using BackEndStructuer.DATA.DTOs.SettingDto;
using BackEndStructuer.DATA.DTOs.SettingFilter;
using BackEndStructuer.DATA.DTOs.SettingForm;
using BackEndStructuer.DATA.DTOs.SettingUpdate;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;

namespace BackEndStructuer.Services;

public interface ISettingServices{
    Task<(SettingDto? setting, string? error)> Create(SettingForm settingForm);
    Task<(List<SettingDto> settings, int? totalCount, string? error)> GetAll(SettingFilter filter);

    Task<(SettingDto? setting, string? error)> GetById(Guid id);

    Task<(SettingDto? setting, string? error)> Update(Guid id, SettingUpdate settingUpdate);
    Task<(SettingDto? setting, string? error)> Delete(Guid id);
}

public class SettingServices : ISettingServices{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public SettingServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    ) {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<(SettingDto? setting, string? error)> Create(SettingForm settingForm) {
        var setting = _mapper.Map<Setting>(settingForm);
        var result = await _repositoryWrapper.Setting.Add(setting);
        var resultDto = _mapper.Map<SettingDto>(result);
        return result == null ? (null, "color could not Add") : (resultDto, null);
    }

    public async Task<(List<SettingDto> settings, int? totalCount, string? error)> GetAll(SettingFilter filter) {
        var (settings, totalCount) = await _repositoryWrapper.Setting.GetAll(filter.PageNumber, filter.PageSize);
        var settingDto = _mapper.Map<List<SettingDto>>(settings);
        return (settingDto, totalCount, null);
    }

    public Task<(SettingDto? setting, string? error)> GetById(Guid id) {
        throw new NotImplementedException();
    }

    public async Task<(SettingDto? setting, string? error)> Update(Guid id, SettingUpdate settingUpdate) {
        throw new NotImplementedException();
    }

    public async Task<(SettingDto? setting, string? error)> Delete(Guid id) {
        throw new NotImplementedException();
    }
}