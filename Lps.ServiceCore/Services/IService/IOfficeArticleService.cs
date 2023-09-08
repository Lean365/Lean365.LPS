using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    public interface IOfficeArticleService : IBaseService<OfficeArticle>
    {
        PagedInfo<OfficeArticleDto> GetList(ArticleQueryDto parm);
        PagedInfo<OfficeArticleDto> GetMyList(ArticleQueryDto parm);
        /// <summary>
        /// 修改文章管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateArticle(OfficeArticle model);
    }
}
