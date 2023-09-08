using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Lps.WebApi.Extensions;
using Lps.WebApi.Filters;
using Lps.ServiceCore.Service.IService;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore.Model.Dto;

namespace Lps.WebApi.Controllers
{
    /// <summary>
    /// 文章管理
    /// </summary>
    [Verify]
    [Route("article")]
    [ApiExplorerSettings(GroupName = "office")]
    public class OfficeArticleController : BaseController
    {
        /// <summary>
        /// 文章接口
        /// </summary>
        private readonly IOfficeArticleService _ArticleService;
        private readonly IOfficeArticleCategoryService _ArticleCategoryService;

        public OfficeArticleController(IOfficeArticleService ArticleService, IOfficeArticleCategoryService articleCategoryService)
        {
            _ArticleService = ArticleService;
            _ArticleCategoryService = articleCategoryService;
        }

        /// <summary>
        /// 查询文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(RolePermi = "admin")]
        public IActionResult Query([FromQuery] ArticleQueryDto parm)
        {
            var response = _ArticleService.GetList(parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 查询我的文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("mylist")]
        public IActionResult QueryMyList([FromQuery] ArticleQueryDto parm)
        {
            parm.UserId = HttpContext.GetUId();
            var response = _ArticleService.GetMyList(parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 查询最新文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("newList")]
        public IActionResult QueryNew()
        {
            var predicate = Expressionable.Create<OfficeArticle>();
            predicate = predicate.And(m => m.IsStatus == 0);
            predicate = predicate.And(m => m.IsPublic == 1);

            var response = _ArticleService.Queryable()
                .Where(predicate.ToExpression())
                .Includes(x => x.ArticleCategoryNav) //填充子对象
                .Take(10)
                .OrderBy(f => f.UpdateTime, OrderByType.Desc).ToList();

            return SUCCESS(response);
        }

        /// <summary>
        /// 查询文章详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            long userId = HttpContext.GetUId();
            var response = _ArticleService.GetId(id);
            var model = response.Adapt<OfficeArticleDto>();
            if (model.IsPublic == 0 && userId != model.UserId)
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, "访问失败");
            }
            if (model != null)
            {
                model.ArticleCategoryNav = _ArticleCategoryService.GetById(model.CategoryId);
                model.TagList = model.Tags?.Split(',', StringSplitOptions.RemoveEmptyEntries);
            }
            return SUCCESS(model);
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        [ActionPermissionFilter(Permission = "office:article:add")]
        [Log(Title = "发布文章", BusinessType = BusinessType.INSERT)]
        public IActionResult Create([FromBody] OfficeArticleDto parm)
        {
            var addModel = parm.Adapt<OfficeArticle>().ToCreate(context: HttpContext);
            addModel.AuthorName = HttpContext.GetName();

            return SUCCESS(_ArticleService.InsertReturnIdentity(addModel));
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <returns></returns>
        [HttpPut("edit")]
        [ActionPermissionFilter(Permission = "office:article:update")]
        [Log(Title = "文章修改", BusinessType = BusinessType.UPDATE)]
        public IActionResult Update([FromBody] OfficeArticleDto parm)
        {
            parm.AuthorName = HttpContext.GetName();
            var modal = parm.Adapt<OfficeArticle>().ToUpdate(HttpContext);
            var response = _ArticleService.UpdateArticle(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ActionPermissionFilter(Permission = "office:article:delete")]
        [Log(Title = "文章删除", BusinessType = BusinessType.DELETE)]
        public IActionResult Delete(int id = 0)
        {
            var response = _ArticleService.Delete(id);
            return SUCCESS(response);
        }
    }
}