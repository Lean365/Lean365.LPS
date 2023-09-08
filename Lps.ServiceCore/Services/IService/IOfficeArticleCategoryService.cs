using System.Collections.Generic;
using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    public interface IOfficeArticleCategoryService : IBaseService<OfficeArticleCategory>
    {
        PagedInfo<OfficeArticleCategory> GetList(ArticleCategoryQueryDto parm);
        List<OfficeArticleCategory> GetTreeList(ArticleCategoryQueryDto parm);
        int AddArticleCategory(OfficeArticleCategory parm);
    }
}
