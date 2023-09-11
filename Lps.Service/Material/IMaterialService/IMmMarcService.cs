using System;
using Lps.Model;
using Lps.ServiceCore;
using Lps.Model.Dto;
using Lps.Model.Material;
using System.Collections.Generic;

namespace Lps.Service.Material.IMaterialService
{
    /// <summary>
    /// 工厂物料数据
    /// service接口
    /// @author Lean365
    /// @date 2023-09-11
    /// </summary>
    public interface IMmMarcService : IBaseService<MmMarc>
    {
        /// <summary>
        /// 工厂物料数据
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMarcDto> GetList(MmMarcQueryDto parm);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString);

        /// <summary>
        /// 工厂物料数据
        /// 详情
        /// </summary>
        /// <param name="MarcGuid"></param>
        /// <returns></returns>
        MmMarc GetInfo(Guid MarcGuid);

        /// <summary>
        /// 工厂物料数据
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmMarc AddMmMarc(MmMarc parm);

        /// <summary>
        /// 工厂物料数据
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmMarc(MmMarc parm);


        /// <summary>
        /// 导入
        /// 工厂物料数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmMarc(List<MmMarc> list);
    }
}
