using System;
using SqlSugar;
using Lps.Infrastructure.Attribute;
using Lps.Infrastructure.Extensions;
using Lps.Model;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore;
using Lps.Model.Dto;
using Lps.Model.Material;
using Lps.Repository;
using Lps.Service.Material.IMaterialService;
using System.Linq;

namespace Lps.Service.Material
{
    /// <summary>
    /// 物料信息
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-09-12
    /// </summary>
    [AppService(ServiceType = typeof(IMmMarbService), ServiceLifetime = LifeTime.Transient)]
    public class MmMarbService : BaseService<MmMarb>, IMmMarbService
    {
        /// <summary>
        /// 查询物料信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMarbDto> GetList(MmMarbQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMarb>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmPlnt), it => it.MmPlnt == parm.MmPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem.Contains(parm.MmMatItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmIndustry), it => it.MmIndustry == parm.MmIndustry);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatType), it => it.MmMatType == parm.MmMatType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatDes), it => it.MmMatDes.Contains(parm.MmMatDes));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatGroup), it => it.MmMatGroup == parm.MmMatGroup);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmPurGroup), it => it.MmPurGroup == parm.MmPurGroup);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmPurType), it => it.MmPurType == parm.MmPurType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmSpecType), it => it.MmSpecType == parm.MmSpecType);
            predicate = predicate.AndIF(parm.MmLeadTime != null, it => it.MmLeadTime == parm.MmLeadTime);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmisChecked), it => it.MmisChecked == parm.MmisChecked);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmProfitCenter), it => it.MmProfitCenter == parm.MmProfitCenter);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmisLot), it => it.MmisLot == parm.MmisLot);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmValType), it => it.MmValType == parm.MmValType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmCcy), it => it.MmCcy == parm.MmCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmSLoc), it => it.MmSLoc == parm.MmSLoc);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmLocPosn), it => it.MmLocPosn == parm.MmLocPosn);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmLocEol), it => it.MmLocEol == parm.MmLocEol);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MmMarb, MmMarbDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString)
        {
            int count = Count(it => it.MmGuid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MmGuid"></param>
        /// <returns></returns>
        public MmMarb GetInfo(Guid MmGuid)
        {
            var response = Queryable()
                .Where(x => x.MmGuid == MmGuid)
                .First();

            return response;
        }

        /// <summary>
        /// 添加物料信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmMarb AddMmMarb(MmMarb model)
        {
            return Context.Insertable(model).EnableDiffLogEvent("新增物料信息").ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改物料信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmMarb(MmMarb model)
        {
            //var response = Update(w => w.MmGuid == model.MmGuid, it => new MmMarb()
            //{
            //    MmLastDate = model.MmLastDate,
            //    MmPlnt = model.MmPlnt,
            //    MmMatItem = model.MmMatItem,
            //    MmIndustry = model.MmIndustry,
            //    MmMatType = model.MmMatType,
            //    MmMatDes = model.MmMatDes,
            //    MmBaseUnit = model.MmBaseUnit,
            //    MmProLevel = model.MmProLevel,
            //    MmMatGroup = model.MmMatGroup,
            //    MmPurGroup = model.MmPurGroup,
            //    MmPurType = model.MmPurType,
            //    MmSpecType = model.MmSpecType,
            //    MmBulkMat = model.MmBulkMat,
            //    MmMoq = model.MmMoq,
            //    MmRoundingVal = model.MmRoundingVal,
            //    MmLeadTime = model.MmLeadTime,
            //    MmProDays = model.MmProDays,
            //    MmisChecked = model.MmisChecked,
            //    MmProfitCenter = model.MmProfitCenter,
            //    MmDiffCode = model.MmDiffCode,
            //    MmisLot = model.MmisLot,
            //    MmMpn = model.MmMpn,
            //    MmMfrs = model.MmMfrs,
            //    MmValType = model.MmValType,
            //    MmMovingAvg = model.MmMovingAvg,
            //    MmCcy = model.MmCcy,
            //    MmPriceControl = model.MmPriceControl,
            //    MmPriceUnit = model.MmPriceUnit,
            //    MmSLoc = model.MmSLoc,
            //    MmESLoc = model.MmESLoc,
            //    MmLocPosn = model.MmLocPosn,
            //    MmInventory = model.MmInventory,
            //    MmLocEol = model.MmLocEol,
            //    ReMarks = model.ReMarks,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true);
        }

        /// <summary>
        /// 导入物料信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmMarb(List<MmMarb> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MmGuid.IsEmpty(), "Guid不能为空")
                .SplitError(x => x.Item.MmLastDate.IsEmpty(), "更新日期不能为空")
                .SplitError(x => x.Item.MmPlnt.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.MmMatItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.MmIndustry.IsEmpty(), "行业类别不能为空")
                .SplitError(x => x.Item.MmMatType.IsEmpty(), "物料类型不能为空")
                .SplitError(x => x.Item.MmMatDes.IsEmpty(), "物料文本不能为空")
                .SplitError(x => x.Item.MmBaseUnit.IsEmpty(), "标准单位不能为空")
                .SplitError(x => x.Item.MmMatGroup.IsEmpty(), "物料组不能为空")
                .SplitError(x => x.Item.MmPurType.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.MmMoq.IsEmpty(), "最小批量不能为空")
                .SplitError(x => x.Item.MmRoundingVal.IsEmpty(), "舍入值不能为空")
                .SplitError(x => x.Item.MmLeadTime.IsEmpty(), "交货时间不能为空")
                .SplitError(x => x.Item.MmProDays.IsEmpty(), "生产天数不能为空")
                .SplitError(x => x.Item.MmProfitCenter.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.MmValType.IsEmpty(), "评估类不能为空")
                .SplitError(x => x.Item.MmMovingAvg.IsEmpty(), "移动平均价不能为空")
                .SplitError(x => x.Item.MmCcy.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.MmPriceControl.IsEmpty(), "价格控制不能为空")
                .SplitError(x => x.Item.MmPriceUnit.IsEmpty(), "价格单位不能为空")
                .SplitError(x => x.Item.MmInventory.IsEmpty(), "库存不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.EnableDiffLogEvent("批量导入物料信息").ExecuteCommand();//插入可插入部分;

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