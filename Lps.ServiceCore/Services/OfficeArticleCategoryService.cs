using Lps.Infrastructure.Attribute;
using SqlSugar;
using System.Collections.Generic;
using Lps.Model;
using Lps.ServiceCore.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.Repository;
using Lps.ServiceCore.Service.IService;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore;
namespace Lps.ServiceCore.Service
{
    /// <summary>
    /// 文章目录Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IOfficeArticleCategoryService), ServiceLifetime = LifeTime.Transient)]
    public class OfficeArticleCategoryService : BaseService<OfficeArticleCategory>, IOfficeArticleCategoryService
    {
        /// <summary>
        /// 查询文章目录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OfficeArticleCategory> GetList(ArticleCategoryQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<OfficeArticleCategory>();

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询文章目录树列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<OfficeArticleCategory> GetTreeList(ArticleCategoryQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<OfficeArticleCategory>();

            //搜索条件查询语法参考Sqlsugar

            var response = Queryable().Where(predicate.ToExpression())
                .ToTree(it => it.Children, it => it.ParentId, 0);

            return response;
        }

        /// <summary>
        /// 添加文章目录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddArticleCategory(OfficeArticleCategory parm)
        {
            var response = Insert(parm, it => new
            {
                it.Name,
                it.CreateTime,
                it.ParentId,
            });
            return response;
        }
    }
}
