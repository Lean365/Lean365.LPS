using System;
using SqlSugar;
using Lps.Infrastructure.Attribute;
using Lps.Infrastructure.Extensions;
using Lps.Model;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore;
using Lps.Model.Dto;
using Lps.Model.Sales;
using Lps.Repository;
using Lps.Service.Sales.ISalesService;
using System.Linq;

namespace Lps.Service.Sales
{
    /// <summary>
    /// 销售凭证
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    [AppService(ServiceType = typeof(ISdSalesInvoiceService), ServiceLifetime = LifeTime.Transient)]
    public class SdSalesInvoiceService : BaseService<SdSalesInvoice>, ISdSalesInvoiceService
    {
        /// <summary>
        /// 查询销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdSalesInvoiceDto> GetList(SdSalesInvoiceQueryDto parm)
        {
            var predicate = Expressionable.Create<SdSalesInvoice>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpPlnt), it => it.SpPlnt == parm.SpPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpFy), it => it.SpFy == parm.SpFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpYm), it => it.SpYm == parm.SpYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpCustomerCode), it => it.SpCustomerCode == parm.SpCustomerCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpPrctr), it => it.SpPrctr == parm.SpPrctr);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SpSalesItem), it => it.SpSalesItem.Contains(parm.SpSalesItem));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SdSalesInvoice, SdSalesInvoiceDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString)
        {
            int count = Count(it => it.SpGuid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SpGuid"></param>
        /// <returns></returns>
        public SdSalesInvoice GetInfo(Guid SpGuid)
        {
            var response = Queryable()
                .Where(x => x.SpGuid == SpGuid)
                .First();

            return response;
        }

        /// <summary>
        /// 添加销售凭证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SdSalesInvoice AddSdSalesInvoice(SdSalesInvoice model)
        {
            return Context.Insertable(model).EnableDiffLogEvent("新增销售凭证").ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改销售凭证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSdSalesInvoice(SdSalesInvoice model)
        {
            //var response = Update(w => w.SpGuid == model.SpGuid, it => new SdSalesInvoice()
            //{
            //    SpPlnt = model.SpPlnt,
            //    SpFy = model.SpFy,
            //    SpYm = model.SpYm,
            //    SpAccDocNo = model.SpAccDocNo,
            //    SpAccDocLineNo = model.SpAccDocLineNo,
            //    SpCustomerCode = model.SpCustomerCode,
            //    SpPrctr = model.SpPrctr,
            //    SpSalesItem = model.SpSalesItem,
            //    SpAccountCode = model.SpAccountCode,
            //    SpSalesQty = model.SpSalesQty,
            //    SpSalesUnit = model.SpSalesUnit,
            //    SpOriginalAmount = model.SpOriginalAmount,
            //    SpOriginalCcy = model.SpOriginalCcy,
            //    SpLocalAmount = model.SpLocalAmount,
            //    SpLocalCcy = model.SpLocalCcy,
            //    SpRefDocNo = model.SpRefDocNo,
            //    SpRefDocLineNo = model.SpRefDocLineNo,
            //    SpPostingDate = model.SpPostingDate,
            //    SpPostingUser = model.SpPostingUser,
            //    SpEntryDate = model.SpEntryDate,
            //    SpEntryTime = model.SpEntryTime,
            //    SpOrigin = model.SpOrigin,
            //    SpPgroup = model.SpPgroup,
            //    SpAccDocType = model.SpAccDocType,
            //    SpAccDocText = model.SpAccDocText,
            //    ReMarks = model.ReMarks,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true);
        }

        /// <summary>
        /// 导入销售凭证
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSdSalesInvoice(List<SdSalesInvoice> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SpGuid.IsEmpty(), "Guid不能为空")
                .SplitError(x => x.Item.SpPlnt.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.SpFy.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.SpYm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.SpAccDocNo.IsEmpty(), "销售凭证不能为空")
                .SplitError(x => x.Item.SpAccDocLineNo.IsEmpty(), "凭证明细不能为空")
                .SplitError(x => x.Item.SpCustomerCode.IsEmpty(), "客户不能为空")
                .SplitError(x => x.Item.SpPrctr.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.SpSalesItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.SpAccountCode.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.SpSalesQty.IsEmpty(), "销售数量不能为空")
                .SplitError(x => x.Item.SpSalesUnit.IsEmpty(), "销售单位不能为空")
                .SplitError(x => x.Item.SpOriginalAmount.IsEmpty(), "原币销售额不能为空")
                .SplitError(x => x.Item.SpOriginalCcy.IsEmpty(), "原币币种不能为空")
                .SplitError(x => x.Item.SpLocalAmount.IsEmpty(), "本币销售额不能为空")
                .SplitError(x => x.Item.SpLocalCcy.IsEmpty(), "本币币种不能为空")
                .SplitError(x => x.Item.SpRefDocNo.IsEmpty(), "参考凭证不能为空")
                .SplitError(x => x.Item.SpRefDocLineNo.IsEmpty(), "参考明细不能为空")
                .SplitError(x => x.Item.SpPostingDate.IsEmpty(), "过账日期不能为空")
                .SplitError(x => x.Item.SpPostingUser.IsEmpty(), "用户不能为空")
                .SplitError(x => x.Item.SpEntryDate.IsEmpty(), "输入日期不能为空")
                .SplitError(x => x.Item.SpEntryTime.IsEmpty(), "输入时间不能为空")
                .SplitError(x => x.Item.SpOrigin.IsEmpty(), "来源不能为空")
                .SplitError(x => x.Item.SpPgroup.IsEmpty(), "产品组不能为空")
                .SplitError(x => x.Item.SpAccDocType.IsEmpty(), "凭证类型不能为空")
                .SplitError(x => x.Item.SpAccDocText.IsEmpty(), "凭证名称不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.EnableDiffLogEvent("批量导入销售凭证").ExecuteCommand();//插入可插入部分;

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";                    
            Console.WriteLine(msg);

            //输出错误信息               
            foreach (var item in x.ErrorList)
            {
                Console.WriteLine("错误" + item.StorageMessage);
            }
            foreach (var item in x.IgnoreList)
            {
                Console.WriteLine("忽略" + item.StorageMessage);
            }

            return (msg, x.ErrorList, x.IgnoreList);
        }
    }
}