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
    /// 物料信息
    /// API控制器Controller
    /// @author Lean365
    /// @date 2023-09-12
    /// </summary>
    [Verify]
    [Route("material/MmMarb")]
    [Tags("物料信息/MmMarb")]
    [ApiExplorerSettings(GroupName = "material")]
    public class MmMarbController : BaseController
    {
        /// <summary>
        /// 物料信息接口
        /// </summary>
        private readonly IMmMarbService _MmMarbService;

        public MmMarbController(IMmMarbService MmMarbService)
        {
            _MmMarbService = MmMarbService;
        }

        /// <summary>
        /// 查询物料信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:marb:list")]
        public IActionResult QueryMmMarb([FromQuery] MmMarbQueryDto parm)
        {
            var response = _MmMarbService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询物料信息详情
        /// </summary>
        /// <param name="MmGuid"></param>
        /// <returns></returns>
        [HttpGet("{MmGuid}")]
        [ActionPermissionFilter(Permission = "mm:marb:query")]
        public IActionResult GetMmMarb(Guid MmGuid)
        {
            var response = _MmMarbService.GetInfo(MmGuid);
            
            var info = response.Adapt<MmMarb>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加物料信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:marb:add")]
        [Log(Title = "物料信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmMarb([FromBody] MmMarbDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误(parameter error)");
            }

           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmMarbService.CheckEntryUnique(parm.MmGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)物料信息 '{parm.MmGuid}'失败(failed)，输入的(The entered)物料信息已存在(already exists)"));
            }

            var modal = parm.Adapt<MmMarb>().ToCreate(HttpContext);

            var response = _MmMarbService.AddMmMarb(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新物料信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:marb:edit")]
        [Log(Title = "物料信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmMarb([FromBody] MmMarbDto parm)
        {
            var modal = parm.Adapt<MmMarb>().ToUpdate(HttpContext);
            var response = _MmMarbService.UpdateMmMarb(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除物料信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "mm:marb:delete")]
        [Log(Title = "物料信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMarb(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空（Delete failed, ID or Guid cannot be empty)")); }

            var response = _MmMarbService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出物料信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "物料信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:marb:export")]
        public IActionResult Export([FromQuery] MmMarbQueryDto parm)
        {
            //parm.PageNum = 1;
            //parm.PageSize = 100000;
            var list = _MmMarbService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据(No data)");
            }
            var result = ExportExcelMini(list, "物料信息", "物料信息");
            return ExportExcel(result.Item2, result.Item1);
        }


        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "物料信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false, IsSaveResponseData = true)]
        [ActionPermissionFilter(Permission = "mm:marb:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MmMarb> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmMarb>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmMarbService.ImportMmMarb(list));
        }

        /// <summary>
        /// 物料信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "物料信息模板", BusinessType = BusinessType.EXPORT, IsSaveRequestData = true, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmMarbImportTmpl>() { }, "MmMarbTmpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}