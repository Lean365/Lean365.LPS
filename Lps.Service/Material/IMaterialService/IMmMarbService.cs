using System;
using Lps.Model;
using Lps.ServiceCore;
using Lps.Model.Dto;
using Lps.Model.Material;
using System.Collections.Generic;

namespace Lps.Service.Material.IMaterialService
{
    /// <summary>
    /// 物料信息
    /// service接口
    /// @author Lean365
    /// @date 2023-09-12
    /// </summary>
    public interface IMmMarbService : IBaseService<MmMarb>
    {
        /// <summary>
        /// 物料信息
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMarbDto> GetList(MmMarbQueryDto parm);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString);

        /// <summary>
        /// 物料信息
        /// 详情
        /// </summary>
        /// <param name="MmGuid"></param>
        /// <returns></returns>
        MmMarb GetInfo(Guid MmGuid);

        /// <summary>
        /// 物料信息
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmMarb AddMmMarb(MmMarb parm);

        /// <summary>
        /// 物料信息
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmMarb(MmMarb parm);


        /// <summary>
        /// 导入
        /// 物料信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmMarb(List<MmMarb> list);
    }
}
