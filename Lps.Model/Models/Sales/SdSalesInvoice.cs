using MiniExcelLibs.Attributes;

namespace Lps.Model.Sales
{
    /// <summary>
    /// 销售凭证
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    [SugarTable("sd_sales_invoice")]
    public class SdSalesInvoice
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        [ExcelColumn(Name = "Guid")]

        public Guid SpGuid { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "工厂", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工厂")]

        public string SpPlnt { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "期间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "期间")]

        public string SpFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "年月", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "年月")]

        public string SpYm { get; set; }

        /// <summary>
        /// 描述 :销售凭证 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "销售凭证", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "销售凭证")]

        public string SpAccDocNo { get; set; }

        /// <summary>
        /// 描述 :凭证明细 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "凭证明细", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "凭证明细")]

        public string SpAccDocLineNo { get; set; }

        /// <summary>
        /// 描述 :客户 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "客户", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "客户")]

        public string SpCustomerCode { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "利润中心", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "利润中心")]

        public string SpPrctr { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]

        public string SpSalesItem { get; set; }

        /// <summary>
        /// 描述 :科目 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "科目", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "科目")]

        public string SpAccountCode { get; set; }

        /// <summary>
        /// 描述 :销售数量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "销售数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "销售数量")]

        public decimal SpSalesQty { get; set; }

        /// <summary>
        /// 描述 :销售单位 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "销售单位", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "销售单位")]

        public string SpSalesUnit { get; set; }

        /// <summary>
        /// 描述 :原币销售额 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "原币销售额", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "原币销售额")]

        public decimal SpOriginalAmount { get; set; }

        /// <summary>
        /// 描述 :原币币种 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "原币币种", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "原币币种")]

        public string SpOriginalCcy { get; set; }

        /// <summary>
        /// 描述 :本币销售额 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "本币销售额", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "本币销售额")]

        public decimal SpLocalAmount { get; set; }

        /// <summary>
        /// 描述 :本币币种 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "本币币种", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "本币币种")]

        public string SpLocalCcy { get; set; }

        /// <summary>
        /// 描述 :参考凭证 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "参考凭证", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "参考凭证")]

        public string SpRefDocNo { get; set; }

        /// <summary>
        /// 描述 :参考明细 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "参考明细", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "参考明细")]

        public string SpRefDocLineNo { get; set; }

        /// <summary>
        /// 描述 :过账日期 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "过账日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "过账日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? SpPostingDate { get; set; }

        /// <summary>
        /// 描述 :用户 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "用户", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "用户")]

        public string SpPostingUser { get; set; }

        /// <summary>
        /// 描述 :输入日期 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "输入日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? SpEntryDate { get; set; }

        /// <summary>
        /// 描述 :输入时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "输入时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入时间")]

        public string SpEntryTime { get; set; }

        /// <summary>
        /// 描述 :来源 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "来源", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "来源")]

        public string SpOrigin { get; set; }

        /// <summary>
        /// 描述 :产品组 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "产品组", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "产品组")]

        public string SpPgroup { get; set; }

        /// <summary>
        /// 描述 :凭证类型 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "凭证类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "凭证类型")]

        public string SpAccDocType { get; set; }

        /// <summary>
        /// 描述 :凭证名称 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "凭证名称", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "凭证名称")]

        public string SpAccDocText { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "软删除")]
        [ExcelColumn(Name = "软删除")]

        public int? IsDeleted { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]

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

    }

    /// <summary>
    /// 销售凭证
    /// 数据实体模板对象导出
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    [SugarTable("sd_sales_invoice")]
    public class SdSalesInvoiceImportTmpl
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false,ColumnDescription = "Guid", ExtendedAttribute = ProteryConstant.NOTNULL)]

        [ExcelColumn(Name = "Guid")]
        public Guid SpGuid { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "工厂", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工厂")]
        public string SpPlnt { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "期间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "期间")]
        public string SpFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "年月", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "年月")]
        public string SpYm { get; set; }

        /// <summary>
        /// 描述 :销售凭证 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "销售凭证", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "销售凭证")]
        public string SpAccDocNo { get; set; }

        /// <summary>
        /// 描述 :凭证明细 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "凭证明细", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "凭证明细")]
        public string SpAccDocLineNo { get; set; }

        /// <summary>
        /// 描述 :客户 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "客户", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "客户")]
        public string SpCustomerCode { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "利润中心", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "利润中心")]
        public string SpPrctr { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]
        public string SpSalesItem { get; set; }

        /// <summary>
        /// 描述 :科目 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "科目", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "科目")]
        public string SpAccountCode { get; set; }

        /// <summary>
        /// 描述 :销售数量 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "销售数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "销售数量")]
        public decimal SpSalesQty { get; set; }

        /// <summary>
        /// 描述 :销售单位 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "销售单位", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "销售单位")]
        public string SpSalesUnit { get; set; }

        /// <summary>
        /// 描述 :原币销售额 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "原币销售额", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "原币销售额")]
        public decimal SpOriginalAmount { get; set; }

        /// <summary>
        /// 描述 :原币币种 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "原币币种", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "原币币种")]
        public string SpOriginalCcy { get; set; }

        /// <summary>
        /// 描述 :本币销售额 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "本币销售额", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "本币销售额")]
        public decimal SpLocalAmount { get; set; }

        /// <summary>
        /// 描述 :本币币种 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "本币币种", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "本币币种")]
        public string SpLocalCcy { get; set; }

        /// <summary>
        /// 描述 :参考凭证 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "参考凭证", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "参考凭证")]
        public string SpRefDocNo { get; set; }

        /// <summary>
        /// 描述 :参考明细 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "参考明细", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "参考明细")]
        public string SpRefDocLineNo { get; set; }

        /// <summary>
        /// 描述 :过账日期 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "过账日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "过账日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpPostingDate { get; set; }

        /// <summary>
        /// 描述 :用户 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "用户", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "用户")]
        public string SpPostingUser { get; set; }

        /// <summary>
        /// 描述 :输入日期 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "输入日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpEntryDate { get; set; }

        /// <summary>
        /// 描述 :输入时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "输入时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入时间")]
        public string SpEntryTime { get; set; }

        /// <summary>
        /// 描述 :来源 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "来源", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "来源")]
        public string SpOrigin { get; set; }

        /// <summary>
        /// 描述 :产品组 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "产品组", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "产品组")]
        public string SpPgroup { get; set; }

        /// <summary>
        /// 描述 :凭证类型 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "凭证类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "凭证类型")]
        public string SpAccDocType { get; set; }

        /// <summary>
        /// 描述 :凭证名称 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "凭证名称", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "凭证名称")]
        public string SpAccDocText { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "软删除")]
        [ExcelColumn(Name = "软删除")]
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]
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

    }
}