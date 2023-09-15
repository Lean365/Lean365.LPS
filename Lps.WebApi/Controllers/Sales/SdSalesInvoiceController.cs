using Microsoft.AspNetCore.Mvc;
using Lps.Model.Dto;
using Lps.ServiceCore.Model.System;
using Lps.Model.Sales;
using Lps.Service.Sales.ISalesService;
using Lps.ServiceCore.Filters;
using MiniExcelLibs;


namespace Lps.WebApi.Controllers
{
    /// <summary>
    /// 销售凭证
    /// API控制器Controller
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    [Verify]
    [Route("sales/SdSalesInvoice")]
    [Tags("销售凭证/SdSalesInvoice")]
    [ApiExplorerSettings(GroupName = "sales")]
    public class SdSalesInvoiceController : BaseController
    {
        /// <summary>
        /// 销售凭证接口
        /// </summary>
        private readonly ISdSalesInvoiceService _SdSalesInvoiceService;

        public SdSalesInvoiceController(ISdSalesInvoiceService SdSalesInvoiceService)
        {
            _SdSalesInvoiceService = SdSalesInvoiceService;
        }

        /// <summary>
        /// 查询销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:list")]
        public IActionResult QuerySdSalesInvoice([FromQuery] SdSalesInvoiceQueryDto parm)
        {
            var response = _SdSalesInvoiceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询销售凭证详情
        /// </summary>
        /// <param name="SpGuid"></param>
        /// <returns></returns>
        [HttpGet("{SpGuid}")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:query")]
        public IActionResult GetSdSalesInvoice(Guid SpGuid)
        {
            var response = _SdSalesInvoiceService.GetInfo(SpGuid);
            
            var info = response.Adapt<SdSalesInvoice>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:add")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSdSalesInvoice([FromBody] SdSalesInvoiceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误(parameter error)");
            }

           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_SdSalesInvoiceService.CheckEntryUnique(parm.SpGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)销售凭证 '{parm.SpGuid}'失败(failed)，输入的(The entered)销售凭证已存在(already exists)"));
            }

            var modal = parm.Adapt<SdSalesInvoice>().ToCreate(HttpContext);

            var response = _SdSalesInvoiceService.AddSdSalesInvoice(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:edit")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSdSalesInvoice([FromBody] SdSalesInvoiceDto parm)
        {
            var modal = parm.Adapt<SdSalesInvoice>().ToUpdate(HttpContext);
            var response = _SdSalesInvoiceService.UpdateSdSalesInvoice(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:delete")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdSalesInvoice(string ids)
        {
            //针对自增ID
            //string[] idsArr = Tools.SpitIntArrary(ids);
            //针对全局唯一标识符Guid
            Guid[] idsArr = Tools.SpitGuidArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空（Delete failed, ID or Guid cannot be empty)")); }

            var response = _SdSalesInvoiceService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出销售凭证
        /// </summary>
        /// <returns></returns>
        [Log(Title = "销售凭证", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:export")]
        public IActionResult Export([FromQuery] SdSalesInvoiceQueryDto parm)
        {
            //parm.PageNum = 1;
            //parm.PageSize = 100000;
            var list = _SdSalesInvoiceService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据(No data)");
            }
            var result = ExportExcelMini(list, "销售凭证", "销售凭证");
            return ExportExcel(result.Item2, result.Item1);
        }


        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "销售凭证导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false, IsSaveResponseData = true)]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SdSalesInvoice> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SdSalesInvoice>(startCell: "A1").ToList();
            }

            return SUCCESS(_SdSalesInvoiceService.ImportSdSalesInvoice(list));
        }

        /// <summary>
        /// 销售凭证导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "销售凭证模板", BusinessType = BusinessType.EXPORT, IsSaveRequestData = true, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SdSalesInvoiceImportTmpl>() { }, "SdSalesInvoiceTmpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}