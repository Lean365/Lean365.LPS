using Lps.Infrastructure.Attribute;
using Lps.Infrastructure.Extensions;
using SqlSugar;
using System;
using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.Repository;
using Lps.ServiceCore.Service.IService;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service
{
    /// <summary>
    /// 数据差异日志Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISysSqldiffLogService), ServiceLifetime = LifeTime.Transient)]
    public class SysSqldiffLogService : BaseService<SysSqldiffLog>, ISysSqldiffLogService
    {
        /// <summary>
        /// 查询数据差异日志列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysSqldiffLogDto> GetList(SqlDiffLogQueryDto parm)
        {
            var predicate = Expressionable.Create<SysSqldiffLog>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TableName), it => it.TableName == parm.TableName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DiffType), it => it.DiffType == parm.DiffType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.UserName), it => it.UserName == parm.UserName);
            predicate = predicate.AndIF(parm.BeginAddTime == null, it => it.AddTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginAddTime != null, it => it.AddTime >= parm.BeginAddTime);
            predicate = predicate.AndIF(parm.EndAddTime != null, it => it.AddTime <= parm.EndAddTime);
            var response = Queryable()
                //.OrderBy("PId desc")
                .Where(predicate.ToExpression())
                .ToPage<SysSqldiffLog, SysSqldiffLogDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PId"></param>
        /// <returns></returns>
        public SysSqldiffLog GetInfo(long PId)
        {
            var response = Queryable()
                .Where(x => x.PId == PId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加数据差异日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SysSqldiffLog AddSqlDiffLog(SysSqldiffLog model)
        {
            return Context.Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改数据差异日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSqlDiffLog(SysSqldiffLog model)
        {
            //var response = Update(w => w.PId == model.PId, it => new SqlDiffLog()
            //{
            //    TableName = model.TableName,
            //    BusinessData = model.BusinessData,
            //    DiffType = model.DiffType,
            //    Sql = model.Sql,
            //    BeforeData = model.BeforeData,
            //    AfterData = model.AfterData,
            //    UserName = model.UserName,
            //    AddTime = model.AddTime,
            //    ConfigId = model.ConfigId,
            //});
            //return response;
            return Update(model, true);
        }

    }
}