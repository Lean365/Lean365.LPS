using Microsoft.AspNetCore.Mvc;
using Lps.Model.Dto;
using Lps.ServiceCore.Model.System;
using Lps.Model.Production;
using Lps.Service.Production.IProductionService;
using Lps.ServiceCore.Filters;
using MiniExcelLibs;


namespace Lps.WebApi.Controllers
{
    /// <summary>
    /// 主设变
    /// API控制器Controller
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    [Verify]
    [Route("production/PpEcMaster")]
    [Tags("主设变/PpEcMaster")]
    [ApiExplorerSettings(GroupName = "production")]
    public class PpEcMasterController : BaseController
    {
        /// <summary>
        /// 主设变接口
        /// </summary>
        private readonly IPpEcMasterService _PpEcMasterService;

        public PpEcMasterController(IPpEcMasterService PpEcMasterService)
        {
            _PpEcMasterService = PpEcMasterService;
        }

        /// <summary>
        /// 查询主设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:list")]
        public IActionResult QueryPpEcMaster([FromQuery] PpEcMasterQueryDto parm)
        {
            var response = _PpEcMasterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询主设变详情
        /// </summary>
        /// <param name="EmGuid"></param>
        /// <returns></returns>
        [HttpGet("{EmGuid}")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:query")]
        public IActionResult GetPpEcMaster(Guid EmGuid)
        {
            var response = _PpEcMasterService.GetInfo(EmGuid);
            
            var info = response.Adapt<PpEcMaster>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加主设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmaster:add")]
        [Log(Title = "主设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMaster([FromBody] PpEcMasterDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误(parameter error)");
            }

           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterService.CheckEntryUnique(parm.EmGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)主设变 '{parm.EmGuid}'失败(failed)，输入的(The entered)主设变已存在(already exists)"));
            }

            var modal = parm.Adapt<PpEcMaster>().ToCreate(HttpContext);

            var response = _PpEcMasterService.AddPpEcMaster(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新主设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmaster:edit")]
        [Log(Title = "主设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMaster([FromBody] PpEcMasterDto parm)
        {
            var modal = parm.Adapt<PpEcMaster>().ToUpdate(HttpContext);
            var response = _PpEcMasterService.UpdatePpEcMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除主设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:delete")]
        [Log(Title = "主设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMaster(string ids)
        {
            //针对自增ID
            //string[] idsArr = Tools.SpitIntArrary(ids);
            //针对全局唯一标识符Guid
            Guid[] idsArr = Tools.SpitGuidArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空（Delete failed, ID or Guid cannot be empty)")); }

            var response = _PpEcMasterService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出主设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "主设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:export")]
        public IActionResult Export([FromQuery] PpEcMasterQueryDto parm)
        {
            //parm.PageNum = 1;
            //parm.PageSize = 100000;
            var list = _PpEcMasterService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据(No data)");
            }
            var result = ExportExcelMini(list, "主设变", "主设变");
            return ExportExcel(result.Item2, result.Item1);
        }


        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "主设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false, IsSaveResponseData = true)]
        [ActionPermissionFilter(Permission = "pp:ecmaster:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMaster> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMaster>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterService.ImportPpEcMaster(list));
        }

        /// <summary>
        /// 主设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "主设变模板", BusinessType = BusinessType.EXPORT, IsSaveRequestData = true, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterImportTmpl>() { }, "PpEcMasterTmpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}