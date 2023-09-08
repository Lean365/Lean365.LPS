using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    public interface ISysTasksQzService : IBaseService<SysTasks>
    {
        PagedInfo<SysTasks> SelectTaskList(TasksQueryDto parm);
        //SysTasksQz GetId(object id);
        int AddTasks(SysTasks parm);
        int UpdateTasks(SysTasks parm);
    }
}
