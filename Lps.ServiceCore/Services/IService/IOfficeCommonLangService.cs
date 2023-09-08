using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    /// <summary>
    /// 多语言配置service接口
    ///
    /// @author Lean365
    /// @date 2022-05-06
    /// </summary>
    public interface IOfficeCommonLangService : IBaseService<SysCommonLang>
    {
        PagedInfo<SysCommonLang> GetList(CommonLangQueryDto parm);
        List<SysCommonLang> GetLangList(CommonLangQueryDto parm);
        dynamic GetListToPivot(CommonLangQueryDto parm);
        void StorageCommonLang(SysCommonLangDto parm);
        Dictionary<string, object> SetLang(List<SysCommonLang> msgList);

        (string, object, object) ImportCommonLang(List<SysCommonLang> list);
    }
}
