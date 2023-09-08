using Lps.Infrastructure;
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
    /// 定时任务
    /// </summary>
    [AppService(ServiceType = typeof(ISysTasksQzService), ServiceLifetime = LifeTime.Transient)]
    public class SysTasksQzService : BaseService<SysTasks>, ISysTasksQzService
    {
        /// <summary>
        /// 查询任务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysTasks> SelectTaskList(TasksQueryDto parm)
        {
            var predicate = Expressionable.Create<SysTasks>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QueryText),
                m => m.Name.Contains(parm.QueryText) ||
                m.JobGroup.Contains(parm.QueryText) ||
                m.AssemblyName.Contains(parm.QueryText));
            predicate.AndIF(parm.TaskType != null, m => m.TaskType == parm.TaskType);
            predicate.AndIF(parm.IsStart != null, m => m.IsStart == parm.IsStart);

            return Queryable().Where(predicate.ToExpression())
                .ToPage(parm);
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddTasks(SysTasks parm)
        {
            parm.IsStart = 0;

            SetAssembleName(parm);

            return Add(parm);
        }

        private void SetAssembleName(SysTasks parm)
        {
            if (parm.ApiUrl.IfNotEmpty() && parm.TaskType == 2)
            {
                parm.AssemblyName = "Lps.Tasks";
                parm.ClassName = "TaskScheduler.Job_HttpRequest";
            }

            if (parm.SqlText.IfNotEmpty() && parm.TaskType == 3)
            {
                parm.AssemblyName = "Lps.Tasks";
                parm.ClassName = "TaskScheduler.Job_SqlExecute";
            }
        }

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateTasks(SysTasks parm)
        {
            SetAssembleName(parm);

            return Update(f => f.ID == parm.ID, f => new SysTasks
            {
                ID = parm.ID,
                Name = parm.Name,
                JobGroup = parm.JobGroup,
                Cron = parm.Cron,
                AssemblyName = parm.AssemblyName,
                ClassName = parm.ClassName,
                ReMarks = parm.ReMarks,
                TriggerType = parm.TriggerType,
                IntervalSecond = parm.IntervalSecond,
                JobParams = parm.JobParams,
                Update_time = DateTime.Now,
                BeginTime = parm.BeginTime,
                EndTime = parm.EndTime,
                TaskType = parm.TaskType,
                ApiUrl = parm.ApiUrl,
                SqlText = parm.SqlText,
                RequestMethod = parm.RequestMethod,
            });
        }
    }
}
