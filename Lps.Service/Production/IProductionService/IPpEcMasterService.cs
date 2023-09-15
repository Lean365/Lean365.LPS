using System;
using Lps.Model;
using Lps.ServiceCore;
using Lps.Model.Dto;
using Lps.Model.Production;
using System.Collections.Generic;

namespace Lps.Service.Production.IProductionService
{
    /// <summary>
    /// 主设变
    /// service接口
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    public interface IPpEcMasterService : IBaseService<PpEcMaster>
    {
        /// <summary>
        /// 主设变
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterDto> GetList(PpEcMasterQueryDto parm);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString);

        /// <summary>
        /// 主设变
        /// 详情
        /// </summary>
        /// <param name="EmGuid"></param>
        /// <returns></returns>
        PpEcMaster GetInfo(Guid EmGuid);

        /// <summary>
        /// 主设变
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMaster AddPpEcMaster(PpEcMaster parm);

        /// <summary>
        /// 主设变
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMaster(PpEcMaster parm);


        /// <summary>
        /// 导入
        /// 主设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMaster(List<PpEcMaster> list);
    }
}
