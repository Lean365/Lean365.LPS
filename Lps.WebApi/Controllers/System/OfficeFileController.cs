using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Lps.WebApi.Filters;
using Lps.ServiceCore.Service.IService;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore.Model.Dto;

namespace Lps.WebApi.Controllers
{
    /// <summary>
    /// 文件存储Controller
    /// </summary>
    [Verify]
    [Route("tool/file")]
    [ApiExplorerSettings(GroupName = "office")]
    public class OfficeFileController : BaseController
    {
        /// <summary>
        /// 文件存储接口
        /// </summary>
        private readonly IOfficeFileService _SysFileService;

        public OfficeFileController(IOfficeFileService SysFileService)
        {
            _SysFileService = SysFileService;
        }

        /// <summary>
        /// 查询文件存储列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "office:file:list")]
        public IActionResult QuerySysFile([FromQuery] OfficeFileQueryDto parm)
        {
            var predicate = Expressionable.Create<OfficeFile>();

            predicate = predicate.AndIF(parm.BeginCreate_time != null, it => it.Create_time >= parm.BeginCreate_time);
            predicate = predicate.AndIF(parm.EndCreate_time != null, it => it.Create_time <= parm.EndCreate_time);
            predicate = predicate.AndIF(parm.StoreType != null, m => m.StoreType == parm.StoreType);
            predicate = predicate.AndIF(parm.FileId != null, m => m.Id == parm.FileId);

            var response = _SysFileService.GetPages(predicate.ToExpression(), parm, x => x.Id, OrderByType.Desc);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询文件存储详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "office:file:query")]
        public IActionResult GetSysFile(long Id)
        {
            var response = _SysFileService.GetFirst(x => x.Id == Id);

            return SUCCESS(response);
        }

        /// <summary>
        /// 删除文件存储
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "office:file:delete")]
        [Log(Title = "文件存储", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysFile(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }


            //TODO 删除本地资源
            foreach (var id in idsArr)
            {
                FileUtil.deleteFile(_SysFileService.GetById(id).FileUrl.Substring(0, _SysFileService.GetById(id).FileUrl.LastIndexOf("/") + 1), _SysFileService.GetById(id).FileName);
            }
            var response = _SysFileService.Delete(idsArr);
            return ToResponse(response);
        }

        /// <summary>
        /// 文件存储导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "文件存储")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "office:file:export")]
        public IActionResult Export()
        {
            var list = _SysFileService.GetAll();

            string sFileName = ExportExcel(list, "SysFile", "文件存储");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }
    }
}