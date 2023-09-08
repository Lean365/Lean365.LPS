using Lps.Infrastructure.Attribute;
using SqlSugar;
using System;
using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.Repository;
using Lps.ServiceCore.Service.IService;
using Lps.ServiceCore.Model.System;
using Microsoft.IdentityModel.Tokens;

namespace Lps.ServiceCore.Service
{
    /// <summary>
    /// 
    /// </summary>
    [AppService(ServiceType = typeof(IOfficeArticleService), ServiceLifetime = LifeTime.Transient)]
    public class OfficeArticleService : BaseService<OfficeArticle>, IOfficeArticleService
    {
        /// <summary>
        /// 查询文章管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OfficeArticleDto> GetList(ArticleQueryDto parm)
        {
            var predicate = Expressionable.Create<OfficeArticle>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Title), m => m.Title.Contains(parm.Title));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsStatus.ToString()), m => m.IsStatus == parm.IsStatus);

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Includes(x => x.ArticleCategoryNav) //填充子对象
                .Where(predicate.ToExpression())
                .OrderBy(x => x.CreateTime, OrderByType.Desc)
                .ToPage<OfficeArticle, OfficeArticleDto>(parm);

            return response;
        }

        /// <summary>
        /// 查询我的文章列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OfficeArticleDto> GetMyList(ArticleQueryDto parm)
        {
            var predicate = Expressionable.Create<OfficeArticle>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Title), m => m.Title.Contains(parm.Title));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsStatus.ToString().ToString()), m => m.IsStatus.ToString() == parm.IsStatus.ToString());
            predicate = predicate.AndIF(parm.BeginTime != null, m => m.CreateTime >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, m => m.CreateTime <= parm.EndTime);
            predicate = predicate.And(m => m.UserId == parm.UserId);

            var response = Queryable()
                .Includes(x => x.ArticleCategoryNav)
                .Where(predicate.ToExpression())
                .ToPage<OfficeArticle, OfficeArticleDto>(parm);

            return response;
        }

        /// <summary>
        /// 修改文章管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateArticle(OfficeArticle model)
        {
            var response = Update(w => w.Cid == model.Cid, it => new OfficeArticle()
            {
                Title = model.Title,
                Content = model.Content,
                IsStatus = model.IsStatus,
                Tags = model.Tags,
                UpdateTime = DateTime.Now,
                CoverUrl = model.CoverUrl,
                CategoryId = model.CategoryId,
                FmtType = model.FmtType,
                IsPublic = model.IsPublic,
            });
            return response;
        }
    }
}
