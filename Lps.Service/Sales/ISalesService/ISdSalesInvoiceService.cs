using System;
using Lps.Model;
using Lps.ServiceCore;
using Lps.Model.Dto;
using Lps.Model.Sales;
using System.Collections.Generic;

namespace Lps.Service.Sales.ISalesService
{
    /// <summary>
    /// 销售凭证
    /// service接口
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    public interface ISdSalesInvoiceService : IBaseService<SdSalesInvoice>
    {
        /// <summary>
        /// 销售凭证
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdSalesInvoiceDto> GetList(SdSalesInvoiceQueryDto parm);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString);

        /// <summary>
        /// 销售凭证
        /// 详情
        /// </summary>
        /// <param name="SpGuid"></param>
        /// <returns></returns>
        SdSalesInvoice GetInfo(Guid SpGuid);

        /// <summary>
        /// 销售凭证
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        SdSalesInvoice AddSdSalesInvoice(SdSalesInvoice parm);

        /// <summary>
        /// 销售凭证
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSdSalesInvoice(SdSalesInvoice parm);


        /// <summary>
        /// 导入
        /// 销售凭证
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSdSalesInvoice(List<SdSalesInvoice> list);
    }
}
