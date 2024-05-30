// using AutoMapper;
// using AlaThuqk.DATA;
// using AlaThuqk.DATA.DTOs;
// using AlaThuqk.Entities;
// using AlaThuqk.Helpers.OneSignal;
// using AlaThuqk.Entities;
// using AlaThuqk.Repository;
// using Article = AlaThuqk.Entities.Article;
//
// namespace AlaThuqk.Services
// {
//     
//     public interface IArticleServices
//     {
//         
//         Task<(Article? article, string? error)> Add(ArticleForm articleForm);
//         Task<(List<Article> articles,int? totalCount,string? error)> GetAll(int _pageNumber = 0);
//         Task<(Article? article,string?error)> Update(ArticleUpdate articleUpdate, Guid id);
//         Task<(Article? article, string?)> Delete(Guid id);
//         
//     }
//     public class ArticleService : IArticleServices
//     {
//         private readonly IMapper _mapper;
//         private readonly IRepositoryWrapper _repositoryWrapper;
//
//         public ArticleService(IMapper mapper, IRepositoryWrapper repositoryWrapper,IConfiguration configuration,DataContext dataContext)
//         {
//             _mapper = mapper;
//             _repositoryWrapper = repositoryWrapper;
//         }
//
//         public async Task<(Article? article, string? error)> Add(ArticleForm articleForm)
//         {
//             var article = _mapper.Map<Article>(articleForm);
//             var result = await _repositoryWrapper.Article.Add(article);
//             return result == null ? (null, "article could not Add") : (article, null);
//             
//            
//         }
//         public async Task<(List<Article> articles, int? totalCount, string? error)> GetAll(int _pageNumber = 0)
//         {
//             var (articles, totalCount) = await _repositoryWrapper.Article.GetAll(_pageNumber);
//
//             return (articles, totalCount, null);
//         }
//         public async Task<(Article? article, string? error)> Update(ArticleUpdate articleUpdate, Guid id)
//         {
//             var article = await _repositoryWrapper.Article.GetById(id);
//             if (article == null)
//             {
//                 return (null, "article not found");
//             }
//             article = _mapper.Map(articleUpdate, article);
//             var response = await _repositoryWrapper.Article.Update(article);
//             return response == null ? (null, "article could not be updated") : (article, null);
//         }
//         public async Task<(Article? article, string?)> Delete(Guid id)
//         {
//             var article = await _repositoryWrapper.Article.GetById(id);
//             if (article == null) return (null, "article not found");
//             var result = await _repositoryWrapper.Article.Delete(id);
//             return result == null ? (null, "article could not be deleted") : (result, null);
//         }
//     }
// }