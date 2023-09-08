using Lps.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using MiniExcelLibs;
using Lps.WebApi.Filters;
using Lps.Model;
using Lps.ServiceCore.Service.IService;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore.Model.Dto;


namespace Lps.WebApi.Controllers
{
    /// <summary>
    /// 多语言配置Controller
    /// </summary>
    [Verify]
    [Route("system/CommonLang")]
    [ApiExplorerSettings(GroupName = "tool")]
    public class SysCommonLangController : BaseController
    {
        /// <summary>
        /// 多语言配置接口
        /// </summary>
        private readonly IOfficeCommonLangService _CommonLangService;

        public SysCommonLangController(IOfficeCommonLangService CommonLangService)
        {
            _CommonLangService = CommonLangService;
        }

        /// <summary>
        /// 查询多语言配置列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "system:lang:list")]
        public IActionResult QueryCommonLang([FromQuery] CommonLangQueryDto parm)
        {
            if (parm.ShowMode == 2)
            {
                PagedInfo<dynamic> pagedInfo = new()
                {
                    Result = _CommonLangService.GetListToPivot(parm)
                };

                return SUCCESS(pagedInfo);
            }

            return SUCCESS(_CommonLangService.GetList(parm));
        }

        /// <summary>
        /// 查询多语言配置列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/{lang}")]
        [AllowAnonymous]
        public IActionResult QueryCommonLangs(string lang)
        {
            var msgList = _CommonLangService.GetLangList(new CommonLangQueryDto() { LangCode = lang });

            return SUCCESS(_CommonLangService.SetLang(msgList));
        }

        /// <summary>
        /// 查询多语言配置详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "system:lang:query")]
        public IActionResult GetCommonLang(long Id)
        {
            var response = _CommonLangService.GetFirst(x => x.Id == Id);

            var list = _CommonLangService.GetList(x => x.LangKey == response.LangKey);
            var vo = list.Adapt<List<SysCommonLangDto>>();
            var modal = new SysCommonLangDto() { LangKey = response.LangKey, LangList = vo };
            return SUCCESS(modal);
        }

        /// <summary>
        /// 查询多语言配置详情
        /// </summary>
        /// <param name="langKey"></param>
        /// <returns></returns>
        [HttpGet("key/{langKey}")]
        [ActionPermissionFilter(Permission = "system:lang:query")]
        public IActionResult GetCommonLangByKey(string langKey)
        {
            var list = _CommonLangService.GetList(x => x.LangKey == langKey);
            var vo = list.Adapt<List<SysCommonLangDto>>();
            var modal = new SysCommonLangDto() { LangKey = langKey, LangList = vo };

            return SUCCESS(modal);
        }

        /// <summary>
        /// 更新多语言配置
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "system:lang:edit")]
        [Log(Title = "多语言配置", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateCommonLang([FromBody] SysCommonLangDto parm)
        {
            if (parm == null || parm.LangKey.IsEmpty())
            {
                throw new CustomException("请求实体不能为空");
            }

            _CommonLangService.StorageCommonLang(parm);

            return ToResponse(1);
        }

        /// <summary>
        /// 删除多语言配置
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "system:lang:delete")]
        [Log(Title = "多语言配置", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteCommonLang(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _CommonLangService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除多语言配置
        /// </summary>
        /// <returns></returns>
        [HttpDelete("ByKey")]
        [ActionPermissionFilter(Permission = "system:lang:delete")]
        [Log(Title = "多语言配置", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteCommonLangByKey(string langkey)
        {
            if (langkey.IsEmpty()) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _CommonLangService
                .Deleteable()
                .EnableDiffLogEvent()
                .Where(f => f.LangKey == langkey)
                .ExecuteCommand();
            return ToResponse(response);
        }

        /// <summary>
        /// 导出多语言配置
        /// </summary>
        /// <returns></returns>
        [Log(Title = "多语言配置", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "system:lang:export")]
        public IActionResult Export([FromQuery] CommonLangQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _CommonLangService.GetListToPivot(parm);

            string sFileName = ExportExcel(list, "CommonLang", "多语言配置");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "多语言设置导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false, IsSaveResponseData = true)]
        [ActionPermissionFilter(Permission = "system:lang:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SysCommonLang> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                var rows = stream.Query(startCell: "A2").ToList();

                foreach (var item in rows)
                {
                    list.Add(new SysCommonLang() { LangCode = "zh-cn", LangKey = item.A, LangName = item.B, Addtime = DateTime.Now });
                    list.Add(new SysCommonLang() { LangCode = "en", LangKey = item.A, LangName = item.C, Addtime = DateTime.Now });
                    list.Add(new SysCommonLang() { LangCode = "zh-tw", LangKey = item.A, LangName = item.D, Addtime = DateTime.Now });
                }
            }

            return SUCCESS(_CommonLangService.ImportCommonLang(list));
        }

        /// <summary>
        /// 多语言设置导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "多语言设置模板", BusinessType = BusinessType.EXPORT, IsSaveRequestData = true, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SysCommonLang>() { }, "lang");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}