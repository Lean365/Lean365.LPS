using MiniExcelLibs.Attributes;

namespace Lps.Model.Production
{
    /// <summary>
    /// 主设变
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-09-14
    /// </summary>
    [SugarTable("pp_ec_master")]
    public class PpEcMaster
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        [ExcelColumn(Name = "Guid")]

        public Guid EmGuid { get; set; }

        /// <summary>
        /// 描述 :发行日 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "发行日", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EmEcIssueDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "设变No.", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "设变No.")]

        public string EmEcNo { get; set; }

        /// <summary>
        /// 描述 :关联文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "关联文件")]
        [ExcelColumn(Name = "关联文件")]

        public string EmEcDoc { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "状态", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "状态")]

        public string EmEcStatus { get; set; }

        /// <summary>
        /// 描述 :标题 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "标题", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "标题")]

        public string EmEcTitle { get; set; }

        /// <summary>
        /// 描述 :内容 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "内容", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "内容")]

        public string EmEcContent { get; set; }

        /// <summary>
        /// 描述 :担当 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "担当", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "担当")]

        public string EmEcAssigned { get; set; }

        /// <summary>
        /// 描述 :损失金额 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "损失金额", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "损失金额")]

        public decimal EmEcLossAmount { get; set; }

        /// <summary>
        /// 描述 :管理区分 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "管理区分", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "管理区分")]

        public int EmEcManageCategory { get; set; }

        /// <summary>
        /// 描述 :联络No. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "联络No.")]
        [ExcelColumn(Name = "联络No.")]

        public string EmEcLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :联络文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "联络文件")]
        [ExcelColumn(Name = "联络文件")]

        public string EmEcLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :EppNo. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EppNo.")]
        [ExcelColumn(Name = "EppNo.")]

        public string EmEcEppLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :Epp文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Epp文件")]
        [ExcelColumn(Name = "Epp文件")]

        public string EmEcEppLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :FppNo. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "FppNo.")]
        [ExcelColumn(Name = "FppNo.")]

        public string EmEcFppLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :Fpp文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Fpp文件")]
        [ExcelColumn(Name = "Fpp文件")]

        public string EmEcFppLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :外部No. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "外部No.")]
        [ExcelColumn(Name = "外部No.")]

        public string EmEcExternalNo { get; set; }

        /// <summary>
        /// 描述 :外部文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "外部文件")]
        [ExcelColumn(Name = "外部文件")]

        public string EmEcExternalDoc { get; set; }

        /// <summary>
        /// 描述 :输入部门 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "输入部门", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入部门")]

        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :输入日 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "输入日", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EmEcEntryDate { get; set; }

        /// <summary>
        /// 描述 :SOP 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "SOP", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "SOP")]

        public string EsSopStae { get; set; }

        /// <summary>
        /// 描述 :自定义A 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义A")]
        [ExcelColumn(Name = "自定义A")]

        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :自定义B 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义B")]
        [ExcelColumn(Name = "自定义B")]

        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :自定义C 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义C")]
        [ExcelColumn(Name = "自定义C")]

        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :自定义D 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义D")]
        [ExcelColumn(Name = "自定义D")]

        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :自定义E 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义E")]
        [ExcelColumn(Name = "自定义E")]

        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :自定义F 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义F")]
        [ExcelColumn(Name = "自定义F")]

        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :自定义1 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义1")]
        [ExcelColumn(Name = "自定义1")]

        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :自定义2 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义2")]
        [ExcelColumn(Name = "自定义2")]

        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :自定义3 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义3")]
        [ExcelColumn(Name = "自定义3")]

        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :自定义4 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义4")]
        [ExcelColumn(Name = "自定义4")]

        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :自定义5 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义5")]
        [ExcelColumn(Name = "自定义5")]

        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :自定义6 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义6")]
        [ExcelColumn(Name = "自定义6")]

        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "软删除")]
        [ExcelColumn(Name = "软删除")]

        public int? IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备注")]
        [ExcelColumn(Name = "备注")]

        public string ReMarks { get; set; }

        /// <summary>
        /// 描述 :创建者 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        [ExcelColumn(Name = "创建者")]

        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :创建时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :更新者 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        [ExcelColumn(Name = "更新者")]

        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :更新时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        [ExcelColumn(Name = "更新时间", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? UpdateTime { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<PpEcMaster> Children { get; set; }
    }

    /// <summary>
    /// 主设变
    /// 数据实体模板对象导出
    /// @author Lean365
    /// @date 2023-09-14
    /// </summary>
    [SugarTable("pp_ec_master")]
    public class PpEcMasterImportTmpl
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false,ColumnDescription = "Guid", ExtendedAttribute = ProteryConstant.NOTNULL)]

        [ExcelColumn(Name = "Guid")]
        public Guid EmGuid { get; set; }

        /// <summary>
        /// 描述 :发行日 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "发行日", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EmEcIssueDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "设变No.", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "设变No.")]
        public string EmEcNo { get; set; }

        /// <summary>
        /// 描述 :关联文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "关联文件")]
        [ExcelColumn(Name = "关联文件")]
        public string EmEcDoc { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "状态", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "状态")]
        public string EmEcStatus { get; set; }

        /// <summary>
        /// 描述 :标题 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "标题", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "标题")]
        public string EmEcTitle { get; set; }

        /// <summary>
        /// 描述 :内容 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "内容", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "内容")]
        public string EmEcContent { get; set; }

        /// <summary>
        /// 描述 :担当 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "担当", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "担当")]
        public string EmEcAssigned { get; set; }

        /// <summary>
        /// 描述 :损失金额 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "损失金额", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "损失金额")]
        public decimal EmEcLossAmount { get; set; }

        /// <summary>
        /// 描述 :管理区分 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "管理区分", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "管理区分")]
        public int EmEcManageCategory { get; set; }

        /// <summary>
        /// 描述 :联络No. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "联络No.")]
        [ExcelColumn(Name = "联络No.")]
        public string EmEcLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :联络文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "联络文件")]
        [ExcelColumn(Name = "联络文件")]
        public string EmEcLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :EppNo. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EppNo.")]
        [ExcelColumn(Name = "EppNo.")]
        public string EmEcEppLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :Epp文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Epp文件")]
        [ExcelColumn(Name = "Epp文件")]
        public string EmEcEppLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :FppNo. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "FppNo.")]
        [ExcelColumn(Name = "FppNo.")]
        public string EmEcFppLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :Fpp文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Fpp文件")]
        [ExcelColumn(Name = "Fpp文件")]
        public string EmEcFppLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :外部No. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "外部No.")]
        [ExcelColumn(Name = "外部No.")]
        public string EmEcExternalNo { get; set; }

        /// <summary>
        /// 描述 :外部文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "外部文件")]
        [ExcelColumn(Name = "外部文件")]
        public string EmEcExternalDoc { get; set; }

        /// <summary>
        /// 描述 :输入部门 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "输入部门", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入部门")]
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :输入日 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "输入日", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EmEcEntryDate { get; set; }

        /// <summary>
        /// 描述 :SOP 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "SOP", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "SOP")]
        public string EsSopStae { get; set; }

        /// <summary>
        /// 描述 :自定义A 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义A")]
        [ExcelColumn(Name = "自定义A")]
        [ExcelIgnore]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :自定义B 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义B")]
        [ExcelColumn(Name = "自定义B")]
        [ExcelIgnore]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :自定义C 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义C")]
        [ExcelColumn(Name = "自定义C")]
        [ExcelIgnore]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :自定义D 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义D")]
        [ExcelColumn(Name = "自定义D")]
        [ExcelIgnore]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :自定义E 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义E")]
        [ExcelColumn(Name = "自定义E")]
        [ExcelIgnore]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :自定义F 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义F")]
        [ExcelColumn(Name = "自定义F")]
        [ExcelIgnore]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :自定义1 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义1")]
        [ExcelColumn(Name = "自定义1")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :自定义2 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义2")]
        [ExcelColumn(Name = "自定义2")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :自定义3 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义3")]
        [ExcelColumn(Name = "自定义3")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :自定义4 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义4")]
        [ExcelColumn(Name = "自定义4")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :自定义5 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义5")]
        [ExcelColumn(Name = "自定义5")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :自定义6 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义6")]
        [ExcelColumn(Name = "自定义6")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "软删除")]
        [ExcelColumn(Name = "软删除")]
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备注")]
        [ExcelColumn(Name = "备注")]
        public string ReMarks { get; set; }

        /// <summary>
        /// 描述 :创建者 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by",ColumnDescription = "创建者")]
        [ExcelColumn(Name = "创建者")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :创建时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time",ColumnDescription = "创建时间")]
        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :更新者 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by",ColumnDescription = "更新者")]
        [ExcelColumn(Name = "更新者")]
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :更新时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time",ColumnDescription = "更新时间")]
        [ExcelColumn(Name = "更新时间", Format = "yyyy-MM-dd HH:mm:ss")]
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<PpEcMaster> Children { get; set; }
    }
}