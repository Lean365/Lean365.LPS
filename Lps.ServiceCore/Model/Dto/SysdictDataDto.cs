using System.Collections.Generic;

namespace Lps.Model.System.Dto
{
    public class SysdictDataDto
    {
        public string DictType { get; set; }
        public string ColumnName { get; set; }
        public List<SysDictData> List { get; set; }
    }
}
