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
    /// 主设变
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcMasterService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcMasterService : BaseService<PpEcMaster>, IPpEcMasterService
    {
        /// <summary>
        /// 查询主设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterDto> GetList(PpEcMasterQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcMaster>();

            //predicate = predicate.AndIF(parm.BeginEmEcIssueDate == null, it => it.EmEcIssueDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginEmEcIssueDate != null, it => it.EmEcIssueDate >= parm.BeginEmEcIssueDate);
            predicate = predicate.AndIF(parm.EndEmEcIssueDate != null, it => it.EmEcIssueDate <= parm.EndEmEcIssueDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcNo), it => it.EmEcNo.Contains(parm.EmEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcStatus), it => it.EmEcStatus == parm.EmEcStatus);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcAssigned), it => it.EmEcAssigned == parm.EmEcAssigned);
            predicate = predicate.AndIF(parm.EmEcManageCategory != null, it => it.EmEcManageCategory == parm.EmEcManageCategory);
            //predicate = predicate.AndIF(parm.BeginEmEcEntryDate == null, it => it.EmEcEntryDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginEmEcEntryDate != null, it => it.EmEcEntryDate >= parm.BeginEmEcEntryDate);
            predicate = predicate.AndIF(parm.EndEmEcEntryDate != null, it => it.EmEcEntryDate <= parm.EndEmEcEntryDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsSopStae), it => it.EsSopStae == parm.EsSopStae);
            var response = Queryable()
                //.Includes(x => x.PpEcSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .ToPage<PpEcMaster, PpEcMasterDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString)
        {
            int count = Count(it => it.EmGuid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EmGuid"></param>
        /// <returns></returns>
        public PpEcMaster GetInfo(Guid EmGuid)
        {
            var response = Queryable()
                .Includes(x => x.PpEcSlaveNav) //填充子对象
                .Where(x => x.EmGuid == EmGuid)
                .First();

            return response;
        }

        /// <summary>
        /// 添加主设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcMaster AddPpEcMaster(PpEcMaster model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpEcSlaveNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改主设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcMaster(PpEcMaster model)
        {
            //var response = Update(w => w.EmGuid == model.EmGuid, it => new PpEcMaster()
            //{
            //    EmEcIssueDate = model.EmEcIssueDate,
            //    EmEcNo = model.EmEcNo,
            //    EmEcDoc = model.EmEcDoc,
            //    EmEcStatus = model.EmEcStatus,
            //    EmEcTitle = model.EmEcTitle,
            //    EmEcContent = model.EmEcContent,
            //    EmEcAssigned = model.EmEcAssigned,
            //    EmEcLossAmount = model.EmEcLossAmount,
            //    EmEcManageCategory = model.EmEcManageCategory,
            //    EmEcLiaisonNo = model.EmEcLiaisonNo,
            //    EmEcLiaisonDoc = model.EmEcLiaisonDoc,
            //    EmEcEppLiaisonNo = model.EmEcEppLiaisonNo,
            //    EmEcEppLiaisonDoc = model.EmEcEppLiaisonDoc,
            //    EmEcFppLiaisonNo = model.EmEcFppLiaisonNo,
            //    EmEcFppLiaisonDoc = model.EmEcFppLiaisonDoc,
            //    EmEcExternalNo = model.EmEcExternalNo,
            //    EmEcExternalDoc = model.EmEcExternalDoc,
            //    EmEcImpDept = model.EmEcImpDept,
            //    EmEcEntryDate = model.EmEcEntryDate,
            //    EsSopStae = model.EsSopStae,
            //    ReMarks = model.ReMarks,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Context.UpdateNav(model).Include(z1 => z1.PpEcSlaveNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入主设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcMaster(List<PpEcMaster> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EmGuid.IsEmpty(), "Guid不能为空")
                .SplitError(x => x.Item.EmEcIssueDate.IsEmpty(), "发行日不能为空")
                .SplitError(x => x.Item.EmEcNo.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.EmEcStatus.IsEmpty(), "状态不能为空")
                .SplitError(x => x.Item.EmEcTitle.IsEmpty(), "标题不能为空")
                .SplitError(x => x.Item.EmEcContent.IsEmpty(), "内容不能为空")
                .SplitError(x => x.Item.EmEcAssigned.IsEmpty(), "担当不能为空")
                .SplitError(x => x.Item.EmEcLossAmount.IsEmpty(), "损失金额不能为空")
                .SplitError(x => x.Item.EmEcManageCategory.IsEmpty(), "管理区分不能为空")
                .SplitError(x => x.Item.EmEcImpDept.IsEmpty(), "输入部门不能为空")
                .SplitError(x => x.Item.EmEcEntryDate.IsEmpty(), "输入日不能为空")
                .SplitError(x => x.Item.EsSopStae.IsEmpty(), "SOP不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.EnableDiffLogEvent("批量导入主设变").ExecuteCommand();//插入可插入部分;

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