using System.Collections.Generic;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Model.Dto
{
    public class SysDictDataDto
    {
        public string ReMarks { get; set; }
        public string DictType { get; set; }
        public string ColumnName { get; set; }
        public List<SysDictData> List { get; set; }
    }
}
