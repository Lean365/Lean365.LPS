using Microsoft.AspNetCore.Mvc;
using Lps.Model.Dto;
using Lps.ServiceCore.Model.System;
using Lps.Model.Material;
using Lps.Service.Material.IMaterialService;
using Lps.WebApi.Filters;
using MiniExcelLibs;


namespace Lps.WebApi.Controllers
{
    /// <summary>
    /// 工厂物料数据
    /// API控制器Controller
    /// @author Lean365
    /// @date 2023-09-11
    /// </summary>
    [Verify]
    [Route("material/MmMarc")]
    [Tags("工厂物料数据/MmMarc")]
    [ApiExplorerSettings(GroupName = "material")]
    public class MmMarcController : BaseController
    {
        /// <summary>
        /// 工厂物料数据接口
        /// </summary>
        private readonly IMmMarcService _MmMarcService;

        public MmMarcController(IMmMarcService MmMarcService)
        {
            _MmMarcService = MmMarcService;
        }

        /// <summary>
        /// 查询工厂物料数据列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:marc:list")]
        public IActionResult QueryMmMarc([FromQuery] MmMarcQueryDto parm)
        {
            var response = _MmMarcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询工厂物料数据详情
        /// </summary>
        /// <param name="MarcGuid"></param>
        /// <returns></returns>
        [HttpGet("{MarcGuid}")]
        [ActionPermissionFilter(Permission = "mm:marc:query")]
        public IActionResult GetMmMarc(Guid MarcGuid)
        {
            var response = _MmMarcService.GetInfo(MarcGuid);
            
            var info = response.Adapt<MmMarc>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加工厂物料数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:marc:add")]
        [Log(Title = "工厂物料数据", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmMarc([FromBody] MmMarcDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误(parameter error)");
            }

           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmMarcService.CheckEntryUnique(parm.MarcGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)工厂物料数据 '{parm.MarcGuid}'失败(failed)，输入的(The entered)工厂物料数据已存在(already exists)"));
            }

            var modal = parm.Adapt<MmMarc>().ToCreate(HttpContext);

            var response = _MmMarcService.AddMmMarc(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新工厂物料数据
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:marc:edit")]
        [Log(Title = "工厂物料数据", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmMarc([FromBody] MmMarcDto parm)
        {
            var modal = parm.Adapt<MmMarc>().ToUpdate(HttpContext);
            var response = _MmMarcService.UpdateMmMarc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工厂物料数据
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "mm:marc:delete")]
        [Log(Title = "工厂物料数据", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMarc(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空（Delete failed, ID or Guid cannot be empty)")); }

            var response = _MmMarcService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出工厂物料数据
        /// </summary>
        /// <returns></returns>
        [Log(Title = "工厂物料数据", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:marc:export")]
        public IActionResult Export([FromQuery] MmMarcQueryDto parm)
        {
            //parm.PageNum = 1;
            //parm.PageSize = 100000;
            var list = _MmMarcService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据(No data)");
            }
            var result = ExportExcelMini(list, "工厂物料数据", "工厂物料数据");
            return ExportExcel(result.Item2, result.Item1);
        }


        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "工厂物料数据导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false, IsSaveResponseData = true)]
        [ActionPermissionFilter(Permission = "mm:marc:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MmMarc> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmMarc>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmMarcService.ImportMmMarc(list));
        }

        /// <summary>
        /// 工厂物料数据导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "工厂物料数据模板", BusinessType = BusinessType.EXPORT, IsSaveRequestData = true, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmMarcImportTmpl>() { }, "MmMarcTmpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}