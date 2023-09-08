using Lps.Infrastructure.Attribute;
using SqlSugar;
using System.Collections.Generic;
using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.ServiceCore.Service.IService;
using Lps.ServiceCore.Model.System;
using Microsoft.IdentityModel.Tokens;

namespace Lps.ServiceCore.Service
{
    /// <summary>
    /// 通知公告表Service业务层处理
    ///
    /// @author Lean365
    /// @date 2021-12-15
    /// </summary>
    [AppService(ServiceType = typeof(IOfficeNoticeService), ServiceLifetime = LifeTime.Transient)]
    public class OfficeNoticeService : BaseService<OfficeNotice>, IOfficeNoticeService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询系统通知
        /// </summary>
        /// <returns></returns>
        public List<OfficeNotice> GetSysNotices()
        {
            var predicate = Expressionable.Create<OfficeNotice>();

            predicate = predicate.And(m => m.IsStatus == 0);
            return Queryable()
                .Where(predicate.ToExpression())
                .OrderByDescending(f => f.Create_time)
                .ToList();
        }

        public PagedInfo<OfficeNotice> GetPageList(SysNoticeQueryDto parm)
        {
            var predicate = Expressionable.Create<OfficeNotice>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.NoticeTitle), m => m.NoticeTitle.Contains(parm.NoticeTitle));
            predicate = predicate.AndIF(parm.NoticeType.ToString().IfNotEmpty(), m => m.NoticeType == parm.NoticeType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CreateBy), m => m.Create_by.Contains(parm.CreateBy) || m.Update_by.Contains(parm.CreateBy));
            predicate = predicate.AndIF(parm.IsStatus.ToString().IfNotEmpty(), m => m.IsStatus == parm.IsStatus);
            var response = GetPages(predicate.ToExpression(), parm);
            return response;
        }

        #endregion
    }
}