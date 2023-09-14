using System;
using SqlSugar;
using Lps.Infrastructure.Attribute;
using Lps.Infrastructure.Extensions;
using Lps.Model;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore;
using Lps.Model.Dto;
using Lps.Model.Production;
using Lps.Repository;
using Lps.Service.Production.IProductionService;
using System.Linq;

namespace Lps.Service.Production
{
    /// <summary>
    /// 从设变
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-09-14
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveService : BaseService<PpEcSlave>, IPpEcSlaveService
    {
        /// <summary>
        /// 查询从设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveDto> GetList(PpEcSlaveQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlave>();

            //predicate = predicate.AndIF(parm.BeginEsEntryDate == null, it => it.EsEntryDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginEsEntryDate != null, it => it.EsEntryDate >= parm.BeginEsEntryDate);
            predicate = predicate.AndIF(parm.EndEsEntryDate != null, it => it.EsEntryDate <= parm.EndEsEntryDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsEcNo), it => it.EsEcNo.Contains(parm.EsEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsModel), it => it.EsModel.Contains(parm.EsModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsItem), it => it.EsItem.Contains(parm.EsItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsOldItem), it => it.EsOldItem.Contains(parm.EsOldItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsNewItem), it => it.EsNewItem.Contains(parm.EsNewItem));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlave, PpEcSlaveDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString)
        {
            int count = Count(it => it.EsGuid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EsGuid"></param>
        /// <returns></returns>
        public PpEcSlave GetInfo(Guid EsGuid)
        {
            var response = Queryable()
                .Where(x => x.EsGuid == EsGuid)
                .First();

            return response;
        }

        /// <summary>
        /// 添加从设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlave AddPpEcSlave(PpEcSlave model)
        {
            return Context.Insertable(model).EnableDiffLogEvent("新增从设变").ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改从设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlave(PpEcSlave model)
        {
            //var response = Update(w => w.EsGuid == model.EsGuid, it => new PpEcSlave()
            //{
            //    EsEntryDate = model.EsEntryDate,
            //    EsEcNo = model.EsEcNo,
            //    EsModel = model.EsModel,
            //    EsItem = model.EsItem,
            //    EsSubItem = model.EsSubItem,
            //    EsOldItem = model.EsOldItem,
            //    EsOldItemText = model.EsOldItemText,
            //    EsOldUsageQty = model.EsOldUsageQty,
            //    EsOldSetLoc = model.EsOldSetLoc,
            //    EsNewItem = model.EsNewItem,
            //    EsNewItemText = model.EsNewItemText,
            //    EsNewUsageQty = model.EsNewUsageQty,
            //    EsNewSetLoc = model.EsNewSetLoc,
            //    EsBomNo = model.EsBomNo,
            //    EsChange = model.EsChange,
            //    Eslocal = model.Eslocal,
            //    Esnote = model.Esnote,
            //    EsOldProcess = model.EsOldProcess,
            //    EsBomDate = model.EsBomDate,
            //    EmEcImpDept = model.EmEcImpDept,
            //    EsPurType = model.EsPurType,
            //    EsSloc = model.EsSloc,
            //    EsInsmk = model.EsInsmk,
            //    EsMstae = model.EsMstae,
            //    EsSopStae = model.EsSopStae,
            //    EsOldCurrStock = model.EsOldCurrStock,
            //    EsNewCurrStock = model.EsNewCurrStock,
            //    EsPurEntryDate = model.EsPurEntryDate,
            //    EsSupplier = model.EsSupplier,
            //    EsPurOrder = model.EsPurOrder,
            //    EsPurNote = model.EsPurNote,
            //    EsPurCreator = model.EsPurCreator,
            //    EsPurCreateTime = model.EsPurCreateTime,
            //    EsPurModifier = model.EsPurModifier,
            //    EsPurModifyTime = model.EsPurModifyTime,
            //    EsPmcEntryDate = model.EsPmcEntryDate,
            //    EsPmcLot = model.EsPmcLot,
            //    EsPmcMemo = model.EsPmcMemo,
            //    EsPmcNote = model.EsPmcNote,
            //    EsPmcCreator = model.EsPmcCreator,
            //    EsPmcCreateTime = model.EsPmcCreateTime,
            //    EsPmcModifier = model.EsPmcModifier,
            //    EsPmcModifyTime = model.EsPmcModifyTime,
            //    EsIqcEntryDate = model.EsIqcEntryDate,
            //    EsIqcOrder = model.EsIqcOrder,
            //    EsIqcNote = model.EsIqcNote,
            //    EsIqcCreator = model.EsIqcCreator,
            //    EsIqcCreateTime = model.EsIqcCreateTime,
            //    EsIqcModifier = model.EsIqcModifier,
            //    EsIqcModifyTime = model.EsIqcModifyTime,
            //    EsMmEntryDate = model.EsMmEntryDate,
            //    EsMmLot = model.EsMmLot,
            //    EsMmMocNo = model.EsMmMocNo,
            //    EsMmNote = model.EsMmNote,
            //    EsMmCreator = model.EsMmCreator,
            //    EsMmCreateTime = model.EsMmCreateTime,
            //    EsMmModifier = model.EsMmModifier,
            //    EsMmModifyTime = model.EsMmModifyTime,
            //    EsPpEntryDate = model.EsPpEntryDate,
            //    EsPpLine = model.EsPpLine,
            //    EsPpLot = model.EsPpLot,
            //    EsPpNote = model.EsPpNote,
            //    EsPpCreator = model.EsPpCreator,
            //    EsPpCreateTime = model.EsPpCreateTime,
            //    EsPpModifier = model.EsPpModifier,
            //    EsPpModifyTime = model.EsPpModifyTime,
            //    EsPcbaEntryDate = model.EsPcbaEntryDate,
            //    EsPcbaLine = model.EsPcbaLine,
            //    EsPcbaLot = model.EsPcbaLot,
            //    EsPcbaNote = model.EsPcbaNote,
            //    EsPcbaCreator = model.EsPcbaCreator,
            //    EsPcbaCreateTime = model.EsPcbaCreateTime,
            //    EsPcbaModifier = model.EsPcbaModifier,
            //    EsPcbaModifyTime = model.EsPcbaModifyTime,
            //    EsQaEntryDate = model.EsQaEntryDate,
            //    EsQaLot = model.EsQaLot,
            //    EsQaNote = model.EsQaNote,
            //    EsQaCreator = model.EsQaCreator,
            //    EsQaCreateTime = model.EsQaCreateTime,
            //    EsQaModifier = model.EsQaModifier,
            //    EsQaModifyTime = model.EsQaModifyTime,
            //    ReMarks = model.ReMarks,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true);
        }

        /// <summary>
        /// 导入从设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlave(List<PpEcSlave> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EsGuid.IsEmpty(), "Guid不能为空")
                .SplitError(x => x.Item.EsEntryDate.IsEmpty(), "输入日不能为空")
                .SplitError(x => x.Item.EsEcNo.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.EsModel.IsEmpty(), "机种不能为空")
                .SplitError(x => x.Item.EsItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.EsOldUsageQty.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.EsNewUsageQty.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.EsBomDate.IsEmpty(), "bom日期不能为空")
                .SplitError(x => x.Item.EmEcImpDept.IsEmpty(), "实施部门不能为空")
                .SplitError(x => x.Item.EsPurType.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.EsSloc.IsEmpty(), "仓库不能为空")
                .SplitError(x => x.Item.EsSopStae.IsEmpty(), "SOP不能为空")
                .SplitError(x => x.Item.EsOldCurrStock.IsEmpty(), "旧品库存不能为空")
                .SplitError(x => x.Item.EsNewCurrStock.IsEmpty(), "新品库存不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.EnableDiffLogEvent("批量导入从设变").ExecuteCommand();//插入可插入部分;

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