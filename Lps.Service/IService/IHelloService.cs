using Lps.ServiceCore;
using Lps.ServiceCore.Model.System;

namespace Lps.Service.IService
{
    /// <summary>
    /// Hello接口
    /// </summary>
    public interface IHelloService : IBaseService<OfficeArticleCategory>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string SayHello(string name);
    }
}
