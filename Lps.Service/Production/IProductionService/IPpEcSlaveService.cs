using System;
using Lps.Model;
using Lps.ServiceCore;
using Lps.Model.Dto;
using Lps.Model.Production;
using System.Collections.Generic;

namespace Lps.Service.Production.IProductionService
{
    /// <summary>
    /// 从设变
    /// service接口
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    public interface IPpEcSlaveService : IBaseService<PpEcSlave>
    {
        /// <summary>
        /// 从设变
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveDto> GetList(PpEcSlaveQueryDto parm);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString);

        /// <summary>
        /// 从设变
        /// 详情
        /// </summary>
        /// <param name="EsGuid"></param>
        /// <returns></returns>
        PpEcSlave GetInfo(Guid EsGuid);

        /// <summary>
        /// 从设变
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlave AddPpEcSlave(PpEcSlave parm);

        /// <summary>
        /// 从设变
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlave(PpEcSlave parm);


        /// <summary>
        /// 导入
        /// 从设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlave(List<PpEcSlave> list);
    }
}
