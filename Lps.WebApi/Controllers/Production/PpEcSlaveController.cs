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
    /// 从设变
    /// API控制器Controller
    /// @author Lean365
    /// @date 2023-09-14
    /// </summary>
    [Verify]
    [Route("production/PpEcSlave")]
    [Tags("从设变/PpEcSlave")]
    [ApiExplorerSettings(GroupName = "production")]
    public class PpEcSlaveController : BaseController
    {
        /// <summary>
        /// 从设变接口
        /// </summary>
        private readonly IPpEcSlaveService _PpEcSlaveService;

        public PpEcSlaveController(IPpEcSlaveService PpEcSlaveService)
        {
            _PpEcSlaveService = PpEcSlaveService;
        }

        /// <summary>
        /// 查询从设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslave:list")]
        public IActionResult QueryPpEcSlave([FromQuery] PpEcSlaveQueryDto parm)
        {
            var response = _PpEcSlaveService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询从设变详情
        /// </summary>
        /// <param name="EsGuid"></param>
        /// <returns></returns>
        [HttpGet("{EsGuid}")]
        [ActionPermissionFilter(Permission = "pp:ecslave:query")]
        public IActionResult GetPpEcSlave(Guid EsGuid)
        {
            var response = _PpEcSlaveService.GetInfo(EsGuid);
            
            var info = response.Adapt<PpEcSlave>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加从设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslave:add")]
        [Log(Title = "从设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlave([FromBody] PpEcSlaveDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误(parameter error)");
            }

           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlaveService.CheckEntryUnique(parm.EsGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)从设变 '{parm.EsGuid}'失败(failed)，输入的(The entered)从设变已存在(already exists)"));
            }

            var modal = parm.Adapt<PpEcSlave>().ToCreate(HttpContext);

            var response = _PpEcSlaveService.AddPpEcSlave(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新从设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslave:edit")]
        [Log(Title = "从设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlave([FromBody] PpEcSlaveDto parm)
        {
            var modal = parm.Adapt<PpEcSlave>().ToUpdate(HttpContext);
            var response = _PpEcSlaveService.UpdatePpEcSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除从设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslave:delete")]
        [Log(Title = "从设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlave(string ids)
        {
            //针对自增ID
            //string[] idsArr = Tools.SpitIntArrary(ids);
            //针对全局唯一标识符Guid
            Guid[] idsArr = Tools.SpitGuidArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空（Delete failed, ID or Guid cannot be empty)")); }

            var response = _PpEcSlaveService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出从设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "从设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslave:export")]
        public IActionResult Export([FromQuery] PpEcSlaveQueryDto parm)
        {
            //parm.PageNum = 1;
            //parm.PageSize = 100000;
            var list = _PpEcSlaveService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据(No data)");
            }
            var result = ExportExcelMini(list, "从设变", "从设变");
            return ExportExcel(result.Item2, result.Item1);
        }


        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "从设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false, IsSaveResponseData = true)]
        [ActionPermissionFilter(Permission = "pp:ecslave:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlave> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlave>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlaveService.ImportPpEcSlave(list));
        }

        /// <summary>
        /// 从设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "从设变模板", BusinessType = BusinessType.EXPORT, IsSaveRequestData = true, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlaveImportTmpl>() { }, "PpEcSlaveTmpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}