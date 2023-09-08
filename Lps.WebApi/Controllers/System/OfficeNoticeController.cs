using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SqlSugar;
using Lps.WebApi.Filters;
using Lps.Model;
using Lps.ServiceCore.Service.IService;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore.Model.Dto;
using Lps.ServiceCore.Signalr;


namespace Lps.WebApi.Controllers.System
{
    /// <summary>
    /// 系统通知
    /// </summary>
    [Verify]
    [Route("system/notice")]
    [ApiExplorerSettings(GroupName = "office")]
    public class OfficeNoticeController : BaseController
    {
        /// <summary>
        /// 通知公告表接口
        /// </summary>
        private readonly IOfficeNoticeService _SysNoticeService;
        private readonly IHubContext<MessageHub> _hubContext;

        public OfficeNoticeController(IOfficeNoticeService SysNoticeService, IHubContext<MessageHub> hubContext)
        {
            _SysNoticeService = SysNoticeService;
            _hubContext = hubContext;
        }

        /// <summary>
        /// 查询通知公告表列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("queryNotice")]
        public IActionResult QueryNotice([FromQuery] SysNoticeQueryDto parm)
        {
            var predicate = Expressionable.Create<OfficeNotice>();

            predicate = predicate.And(m => m.IsStatus == 0);
            var response = _SysNoticeService.GetPages(predicate.ToExpression(), parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询通知公告表列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "office:notice:list")]
        public IActionResult QuerySysNotice([FromQuery] SysNoticeQueryDto parm)
        {
            PagedInfo<OfficeNotice> response = _SysNoticeService.GetPageList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询通知公告表详情
        /// </summary>
        /// <param name="NoticeId"></param>
        /// <returns></returns>
        [HttpGet("{NoticeId}")]
        public IActionResult GetSysNotice(int NoticeId)
        {
            var response = _SysNoticeService.GetFirst(x => x.NoticeId == NoticeId);

            return SUCCESS(response);
        }

        /// <summary>
        /// 添加通知公告表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "office:notice:add")]
        [Log(Title = "发布通告", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSysNotice([FromBody] OfficeNoticeDto parm)
        {
            var modal = parm.Adapt<OfficeNotice>().ToCreate(HttpContext);
            
            int result = _SysNoticeService.Insert(modal, it => new
            {
                it.NoticeTitle,
                it.NoticeType,
                it.NoticeContent,
                it.IsStatus,
                it.ReMarks,
                it.Create_by,
                it.Create_time
            });

            return SUCCESS(result);
        }

        /// <summary>
        /// 更新通知公告表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "office:notice:update")]
        [Log(Title = "修改公告", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSysNotice([FromBody] OfficeNoticeDto parm)
        {
            var model = parm.Adapt<OfficeNotice>().ToUpdate(HttpContext);
            model.Update_by = HttpContext.GetName();
            var response = _SysNoticeService.Update(w => w.NoticeId == model.NoticeId, it => new OfficeNotice()
            {
                NoticeTitle = model.NoticeTitle,
                NoticeType = model.NoticeType,
                NoticeContent = model.NoticeContent,
                IsStatus = model.IsStatus,
                ReMarks = model.ReMarks,
                Update_by = HttpContext.GetName(),
                Update_time = DateTime.Now
            });

            return SUCCESS(response);
        }
        /// <summary>
        /// 发送通知公告表
        /// </summary>
        /// <returns></returns>
        [HttpPut("send/{NoticeId}")]
        [ActionPermissionFilter(Permission = "office:notice:update")]
        [Log(Title = "发送通知公告", BusinessType = BusinessType.OTHER)]
        public IActionResult SendNotice(int NoticeId = 0)
        {
            if (NoticeId <= 0)
            {
                throw new CustomException("请求实体不能为空");
            }
            var response = _SysNoticeService.GetFirst(x => x.NoticeId == NoticeId);
            if (response != null && response.IsStatus == 0)
            {
                _hubContext.Clients.All.SendAsync(HubsConstant.ReceiveNotice, response.NoticeTitle, response.NoticeContent);
            }
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除通知公告表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "office:notice:delete")]
        [Log(Title = "通知公告", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysNotice(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SysNoticeService.Delete(idsArr);

            return SUCCESS(response);
        }
    }
}