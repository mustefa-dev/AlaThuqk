using AlaThuqk.DATA;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.DATA.DTOs.Template;
using AlaThuqk.DATA.Filter;
using AlaThuqk.Repository;
using AutoMapper;
using AlaThuqk.Entities;
using AlaThuqk.Helpers.OneSignal;
using BackEndStructuer.Entities;
using Microsoft.EntityFrameworkCore;
using Template = AlaThuqk.Entities.Template;

namespace AlaThuqk.Services{
    public interface ITemplateServices{
        Task<(TemplateDto? templatedto, string? error)> Add(TemplateForm templateForm);

        Task<(List<TemplateDto> templateDtos, int? totalCount, string? error)> GetAll(TemplateFilter baseFilter,
            Guid userId);

        Task<(TemplateDto? templateDto, string?error)> update(TemplateUpdate templateDto, Guid id);

        Task<(TemplateDto? templateDto, string error)> GetById(Guid id, Guid userId);
        Task<(TemplateDto? templateDto, string?)> Delete(Guid id);
        Task<(List<SizeDto> sizeDtos, string? error)> GetSizes(Guid id);
        Task<(List<ColorDto> sizeDtos, string? error)> GetColors(Guid id, Guid sizeId);

        Task<(List<TemplateDto> templateDtos, int? totalCount, string? error)> GetMostSoldTemplates(
            TemplateFilter baseFilter);

        Task<(List<TemplateDto>, int? totalCount, string? error)> GetMostLikedTemplate(TemplateFilter baseFilter);
        Task<(TemplateDto? templateDto, string? error)> LikeUnlikeTemplate(Guid userId, Guid templateId);

        Task<(List<TemplateDto> templateDtosDtos, int? totalCount, string? error)> GetMyLikedTemplate(
            TemplateFilter baseFilter,
            Guid userId);
    }

    public class TemplateService : ITemplateServices{
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private ITemplateServices _templateServicesImplementation;

        public TemplateService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IConfiguration configuration,
            DataContext dataContext) {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<(TemplateDto? templatedto, string? error)> Add(TemplateForm templateForm) {
            var category = await _repositoryWrapper.Category.GetById(templateForm.CategoryId.Value);
            if (category == null) return (null, "category not found");
            var template = _mapper.Map<Template>(templateForm);
            var result = await _repositoryWrapper.Template.Add(template);
            var templateDto = _mapper.Map<TemplateDto>(result);
            return result == null ? (null, "template could not Add") : (templateDto, null);
        }

        public async Task<(List<TemplateDto> templateDtos, int? totalCount, string? error)> GetAll(
            TemplateFilter baseFilter, Guid userId) {
            baseFilter.search ??= "";
            var (templates, totalCount) = await _repositoryWrapper.Template.GetAll(
                template => template.Sizes.Any(size =>
                    size.Colors.Any(color => color.Quantity > 0) || (
                        template.Name.Contains(baseFilter.search))),
                template => template.Include(template1 => template1.Sizes).ThenInclude(size => size.Colors)
                    .Include(template1 => template1.Category)
                    .Include(template1 => template1.Components)
                ,
                baseFilter.PageNumber, baseFilter.PageSize);


            var templateDtos = templates.Select(
                    template => _mapper.Map<TemplateDto>(templates.Find(template1 => template1.Id == template.Id)))
                .ToList();
            foreach (var templateDto in templateDtos) {
                var isLiked =
                    await _repositoryWrapper.UserLike.Get(x => x.TemplateId == templateDto.Id && x.UserId == userId);
                templateDto.IsLiked = isLiked != null;
            }

            return (templateDtos, totalCount, null);
        }


        public async Task<(TemplateDto? templateDto, string? error)> update(TemplateUpdate templateUpdate, Guid id) {
            var template = await _repositoryWrapper.Template.GetById(id);
            if (template == null) {
                return (null, "template not found");
            }

            template = _mapper.Map(templateUpdate, template);
            var response = await _repositoryWrapper.Template.Update(template);
            var templateDto = _mapper.Map<TemplateDto>(response);
            return response == null ? (null, "template could not be updated") : (templateDtoDto: templateDto, null);
        }

        public async Task<(TemplateDto? templateDto, string error)> GetById(Guid id, Guid userId) {
            var template = await _repositoryWrapper.Template.Get(
                template1 => template1.Id == id,
                templates => templates.Include(template1 => template1.Sizes).ThenInclude(size => size.Colors)
                    .Include(template1 => template1.Category)
            );
            var templateDto = _mapper.Map<TemplateDto>(template);
            if (templateDto == null) return (null, "Template not found");

            var isLiked = await _repositoryWrapper.UserLike.Get(x => x.TemplateId == id && x.UserId == userId);
            templateDto.IsLiked = isLiked != null;

            return template == null ? (null, "category not found") : (templatDto: templateDto, null);
        }

        public async Task<(TemplateDto? templateDto, string?)> Delete(Guid id) {
            var template = await _repositoryWrapper.Template.GetById(id);
            if (template == null) return (null, "template not found");
            var result = await _repositoryWrapper.Template.Delete(id);
            var templateDto = _mapper.Map<TemplateDto>(result);
            return result == null ? (null, "template could not be deleted") : (templateDto, null);
        }

        public async Task<(List<SizeDto> sizeDtos, string? error)> GetSizes(Guid id) {
            var template = await _repositoryWrapper.Template.Get(
                template1 => template1.Id == id,
                templates => templates.Include(template1 => template1.Sizes).ThenInclude(size => size.Colors)
                    .Include(template1 => template1.Category)
            );
            var templateDto = _mapper.Map<TemplateDto>(template);
            if (templateDto == null) return (null, "template not found");
            var sizeDtos = _mapper.Map<List<SizeDto>>(templateDto.Sizes);
            return (sizeDtos, null);
        }

        public async Task<(List<ColorDto> sizeDtos, string? error)> GetColors(Guid id, Guid sizeId) {
            var template = await _repositoryWrapper.Template.GetById(id);
            if (template == null) return (null, "template not found");
            var (data, totalCount) = await _repositoryWrapper.Color.GetAll(color => color.SizeId == sizeId);
            var sizeDtos = _mapper.Map<List<ColorDto>>(data);
            return (sizeDtos, null);
        }

        public async Task<(List<TemplateDto> templateDtos, int? totalCount, string? error)> GetMostSoldTemplates(
            TemplateFilter baseFilter) {
            baseFilter.search ??= "";
            var (template, totalCount) = await _repositoryWrapper.Template.GetAll(
                template => template.Sizes.Any(size =>
                    size.Colors.Any(color => color.Quantity > 0) || (
                        template.Name.Contains(baseFilter.search))),
                templates => templates.Include(template => template.Sizes).ThenInclude(size => size.Colors)
                    .Include(template1 => template1.Category)
                ,
                baseFilter.PageNumber, baseFilter.PageSize);

            var templateDtos = template.Select(
                    template1 => _mapper.Map<TemplateDto>(template.Find(template1 => template1.Id == template1.Id)))
                .ToList();
            return (templateDtos, totalCount, null);
        }

        public async Task<(List<TemplateDto>, int? totalCount, string? error)> GetMostLikedTemplate(
            TemplateFilter baseFilter) {
            baseFilter.search ??= "";
            var (templates, totalCount) = await _repositoryWrapper.Template.GetAll(
                template => template.Sizes.Any(size =>
                    size.Colors.Any(color => color.Quantity > 0) || (
                        template.Name.Contains(baseFilter.search))),
                t => t.Include(template => template.Sizes).ThenInclude(size => size.Colors)
                    .Include(template => template.Category)
                ,
                baseFilter.PageNumber, baseFilter.PageSize);

            var templateDtos = templates.Select(
                    template => _mapper.Map<TemplateDto>(templates.Find(template1 => template1.Id == template.Id)))
                .ToList();
            return (templateDtos, totalCount, null);
        }

        public async Task<(TemplateDto? templateDto, string? error)> LikeUnlikeTemplate(Guid userId, Guid templateId) {
            var template = await _repositoryWrapper.Template.GetById(templateId);
            if (template == null) return (null, "Template not found");

            var user = await _repositoryWrapper.User.GetById(userId);
            if (user == null) return (null, "User not found");

            var userLike = await _repositoryWrapper.UserLike.Get(x => x.TemplateId == templateId && x.UserId == userId);
            if (userLike == null) {
                    var newUserLike = new UserLike
                    {
                        TemplateId = templateId,
                        UserId = userId
                    };
                    await _repositoryWrapper.UserLike.Add(newUserLike);
                    template.Likes++; await _repositoryWrapper.Template.Update(template); 

                    var templateDto = _mapper.Map<TemplateDto>(template);
                    return (templateDto, null);
                }
                else {
                    await _repositoryWrapper.UserLike.Delete(userLike.Id);
                    template.Likes--; await _repositoryWrapper.Template.Update(template);
                    var templateDto = _mapper.Map<TemplateDto>(template);
                    return (templateDto, null);
                }
        }


        public async Task<(List<TemplateDto> templateDtosDtos, int? totalCount, string? error)> GetMyLikedTemplate(
            TemplateFilter baseFilter,
            Guid userId) {
            baseFilter.search ??= "";
            var (templates, totalCount) = await _repositoryWrapper.Template.GetAll(
                template => template.Sizes.Any(size =>
                    size.Colors.Any(color => color.Quantity > 0) || (
                        template.Name.Contains(baseFilter.search))),
                queryable => queryable.Include(template => template.Sizes).ThenInclude(size => size.Colors)
                    .Include(template => template.Category)
                ,
                baseFilter.PageNumber, baseFilter.PageSize);

            var templateDtos = templates.Select(
                    template => _mapper.Map<TemplateDto>(templates.Find(template => template.Id == template.Id)))
                .ToList();
            return (templateDtos, totalCount, null);
        }
    }
}