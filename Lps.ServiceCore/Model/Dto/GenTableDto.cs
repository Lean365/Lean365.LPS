using System.Collections.Generic;
using Lps.Model.System.Generate;

namespace Lps.ServiceCore.Model.Dto
{
    public class GenTableDto
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string TableComment { get; set; }
        public string SubTableName { get; set; }
        public string SubTableFkName { get; set; }
        public string ClassName { get; set; }
        public string TplCategory { get; set; }
        public string BaseNameSpace { get; set; }
        public string ModuleName { get; set; }
        public string BusinessName { get; set; }
        public string FunctionName { get; set; }
        public string FunctionAuthor { get; set; }
        public string GenType { get; set; }
        public string GenPath { get; set; }
        //public string PermissionPrefix { get; set; }
        public string ReMarks { get; set; }
        /// <summary>
        /// 额外参数
        /// </summary>
        public Options Params { get; set; }
        public List<GenTableColumnDto> Columns { get; set; }
    }

    /// <summary>
    /// 额外参数
    /// ****注意里面参数统一首字母小写*****
    /// </summary>
    public class Params
    {
        /// <summary>
        /// 树代码
        /// </summary>
        public string TreeCode { get; set; }
        /// <summary>
        /// 树名称
        /// </summary>
        public string TreeName { get; set; }
        /// <summary>
        /// 树父代码
        /// </summary>
        public string TreeParentCode { get; set; }
        /// <summary>
        /// 父菜单代码
        /// </summary>
        public int? ParentMenuId { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; }
        /// <summary>
        /// 排序类型
        /// </summary>
        public string SortType { get; set; }
        /// <summary>
        /// 额外参数字符串
        /// </summary>
        public string CheckedBtn { get; set; }
        /// <summary>
        /// 权限前缀
        /// </summary>
        public string PermissionPrefix { get; set; }
        /// <summary>
        /// 多语言Key后缀
        /// </summary>
        public string MenuPrefix { get; set; }
    }
    public class GenTableColumnDto
    {
        /// <summary>
        /// 列ID
        /// </summary>
        public int ColumnId { get; set; }
        /// <summary>
        /// 表ID
        /// </summary>
        public int TableId { get; set; }
        /// <summary>
        /// 表描述
        /// </summary>
        public string ColumnComment { get; set; }
        /// <summary>
        /// C#类型
        /// </summary>
        public string CsharpType { get; set; }
        /// <summary>
        /// C#字段
        /// </summary>
        public string CsharpField { get; set; }
        /// <summary>
        /// 是否新增
        /// </summary>
        public bool IsInsert { get; set; }
        /// <summary>
        /// 是否编辑
        /// </summary>
        public bool IsEdit { get; set; }
        /// <summary>
        /// 是否列表
        /// </summary>
        public bool IsList { get; set; }
        /// <summary>
        /// 是否查询
        /// </summary>
        public bool IsQuery { get; set; }
        /// <summary>
        /// 是否排序
        /// </summary>
        public bool IsSort { get; set; }
        /// <summary>
        /// 是否必填
        /// </summary>
        public bool IsRequired { get; set; }
        /// <summary>
        /// 是否导出
        /// </summary>
        public bool IsExport { get; set; }
        /// <summary>
        /// 显示类型（文本框、文本域、下拉框、复选框、单选框、日期控件）
        /// </summary>
        public string HtmlType { get; set; }
        /// <summary>
        /// 查询类型（等于、不等于、大于、小于、范围）
        /// </summary>
        public string QueryType { get; set; } = "EQ";
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        public string DictType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string ReMarks { get; set; }
        /// <summary>
        /// 自动填充类型
        /// </summary>
        public int? AutoFillType { get; set; }
    }
}
