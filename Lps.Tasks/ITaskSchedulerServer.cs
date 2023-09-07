using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lps.Model.System;

namespace Lps.Tasks
{
	public interface ITaskSchedulerServer
	{
		Task<ApiResult> StartTaskScheduleAsync();

		Task<ApiResult> StopTaskScheduleAsync();

		Task<ApiResult> AddTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> PauseTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> ResumeTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> DeleteTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> RunTaskScheduleAsync(SysTasks tasksQz);

		Task<ApiResult> UpdateTaskScheduleAsync(SysTasks tasksQz);
	}
}
