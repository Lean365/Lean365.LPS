using Lps.Infrastructure.Attribute;
using SqlSugar;
using System;
using System.Linq;
using Lps.Model;
using Lps.Repository;
using Lps.ServiceCore.Service.IService;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore.Model.Dto;
namespace Lps.ServiceCore.Service
{
    /// <summary>
    /// 多语言配置Service业务层处理
    ///
    /// @author Lean365
    /// @date 2022-05-06
    /// </summary>
    [AppService(ServiceType = typeof(IOfficeCommonLangService), ServiceLifetime = LifeTime.Transient)]
    public class SysCommonLangService : BaseService<SysCommonLang>, IOfficeCommonLangService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询多语言配置列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysCommonLang> GetList(CommonLangQueryDto parm)
        {
            var predicate = Expressionable.Create<SysCommonLang>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangCode), it => it.LangCode == parm.LangCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangKey), it => it.LangKey.Contains(parm.LangKey));
            predicate = predicate.AndIF(parm.BeginAddtime != null, it => it.Addtime >= parm.BeginAddtime && it.Addtime <= parm.EndAddtime);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);
            return response;
        }

        /// <summary>
        /// 行转列
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic GetListToPivot(CommonLangQueryDto parm)
        {
            var predicate = Expressionable.Create<SysCommonLang>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangCode), it => it.LangCode == parm.LangCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangKey), it => it.LangKey.Contains(parm.LangKey));
            predicate = predicate.AndIF(parm.BeginAddtime != null, it => it.Addtime >= parm.BeginAddtime && it.Addtime <= parm.EndAddtime);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPivotList(it => it.LangCode, it => it.LangKey, it => it.Max(f => f.LangName));
            return response;
        }

        public List<SysCommonLang> GetLangList(CommonLangQueryDto parm)
        {
            var predicate = Expressionable.Create<SysCommonLang>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangCode), it => it.LangCode == parm.LangCode);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangKey), it => it.LangKey.Contains(parm.LangKey));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToList();
            return response;
        }

        public void StorageCommonLang(SysCommonLangDto parm)
        {
            List<SysCommonLang> langs = new();
            foreach (var item in parm.LangList)
            {
                langs.Add(new SysCommonLang()
                {
                    Addtime = DateTime.Now,
                    LangKey = parm.LangKey,
                    LangCode = item.LangCode,
                    LangName = item.LangName,
                });
            }
            var storage = Context.Storageable(langs)
                .WhereColumns(it => new { it.LangKey, it.LangCode })
                .ToStorage();

            storage.AsInsertable.ExecuteReturnSnowflakeIdList();//执行插入
            storage.AsUpdateable.UpdateColumns(it => new { it.LangName }).ExecuteCommand();//执行修改
        }

        public Dictionary<string, object> SetLang(List<SysCommonLang> msgList)
        {
            Dictionary<string, object> dic = new();

            foreach (var item in msgList)
            {
                if (!dic.ContainsKey(item.LangKey))
                {
                    dic.Add(item.LangKey, item.LangName);
                }
            }
            return dic;
        }

        /// <summary>
        /// 导入多语言设置
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportCommonLang(List<SysCommonLang> list)
        {
            var x = Context.Storageable(list)
                .WhereColumns(it => new { it.LangKey, it.LangCode })
                .ToStorage();
            x.AsInsertable.ExecuteReturnSnowflakeIdList();//插入可插入部分;
            x.AsUpdateable.UpdateColumns(it => new { it.LangName }).ExecuteCommand();

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";

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
        #endregion
    }
}