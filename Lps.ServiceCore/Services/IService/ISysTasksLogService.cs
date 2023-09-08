using System.Threading.Tasks;
using Lps.Repository;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    public interface ISysTasksLogService : IBaseService<SysTasksLog>
    {
        /// <summary>
        /// 记录任务执行日志
        /// </summary>
        /// <returns></returns>
        //public int AddTaskLog(string jobId);
        Task<SysTasksLog> AddTaskLog(string jobId, SysTasksLog tasksLog);
    }
}
