using MiniExcelLibs.Attributes;

namespace Lps.Model.Material
{
    /// <summary>
    /// 物料信息
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-09-12
    /// </summary>
    [SugarTable("mm_marb")]
    public class MmMarb
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        [ExcelColumn(Name = "Guid")]

        public Guid MmGuid { get; set; }

        /// <summary>
        /// 描述 :更新日期 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "更新日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "更新日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? MmLastDate { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "工厂", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工厂")]

        public string MmPlnt { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]

        public string MmMatItem { get; set; }

        /// <summary>
        /// 描述 :行业类别 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "行业类别", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "行业类别")]

        public string MmIndustry { get; set; }

        /// <summary>
        /// 描述 :物料类型 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料类型")]

        public string MmMatType { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料文本", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料文本")]

        public string MmMatDes { get; set; }

        /// <summary>
        /// 描述 :标准单位 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "标准单位", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "标准单位")]

        public string MmBaseUnit { get; set; }

        /// <summary>
        /// 描述 :层次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "层次")]
        [ExcelColumn(Name = "层次")]

        public string MmProLevel { get; set; }

        /// <summary>
        /// 描述 :物料组 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料组", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料组")]

        public string MmMatGroup { get; set; }

        /// <summary>
        /// 描述 :采购组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购组")]
        [ExcelColumn(Name = "采购组")]

        public string MmPurGroup { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "采购类型")]

        public string MmPurType { get; set; }

        /// <summary>
        /// 描述 :特殊采购类 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "特殊采购类")]
        [ExcelColumn(Name = "特殊采购类")]

        public string MmSpecType { get; set; }

        /// <summary>
        /// 描述 :散装物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "散装物料")]
        [ExcelColumn(Name = "散装物料")]

        public string MmBulkMat { get; set; }

        /// <summary>
        /// 描述 :最小批量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "最小批量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最小批量")]

        public int MmMoq { get; set; }

        /// <summary>
        /// 描述 :舍入值 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "舍入值", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "舍入值")]

        public int MmRoundingVal { get; set; }

        /// <summary>
        /// 描述 :交货时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "交货时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "交货时间")]

        public int MmLeadTime { get; set; }

        /// <summary>
        /// 描述 :生产天数 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产天数", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产天数")]

        public decimal MmProDays { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验否")]
        [ExcelColumn(Name = "检验否")]

        public string MmisChecked { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "利润中心", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "利润中心")]

        public string MmProfitCenter { get; set; }

        /// <summary>
        /// 描述 :差异码 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "差异码")]
        [ExcelColumn(Name = "差异码")]

        public string MmDiffCode { get; set; }

        /// <summary>
        /// 描述 :批次管理 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "批次管理")]
        [ExcelColumn(Name = "批次管理")]

        public string MmisLot { get; set; }

        /// <summary>
        /// 描述 :制造商物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "制造商物料")]
        [ExcelColumn(Name = "制造商物料")]

        public string MmMpn { get; set; }

        /// <summary>
        /// 描述 :制造商 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "制造商")]
        [ExcelColumn(Name = "制造商")]

        public string MmMfrs { get; set; }

        /// <summary>
        /// 描述 :评估类 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "评估类", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "评估类")]

        public string MmValType { get; set; }

        /// <summary>
        /// 描述 :移动平均价 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "移动平均价", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "移动平均价")]

        public decimal MmMovingAvg { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "币种", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "币种")]

        public string MmCcy { get; set; }

        /// <summary>
        /// 描述 :价格控制 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "价格控制", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "价格控制")]

        public string MmPriceControl { get; set; }

        /// <summary>
        /// 描述 :价格单位 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "价格单位", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "价格单位")]

        public int MmPriceUnit { get; set; }

        /// <summary>
        /// 描述 :采购仓库 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购仓库")]
        [ExcelColumn(Name = "采购仓库")]

        public string MmSLoc { get; set; }

        /// <summary>
        /// 描述 :生产仓库 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产仓库")]
        [ExcelColumn(Name = "生产仓库")]

        public string MmESLoc { get; set; }

        /// <summary>
        /// 描述 :仓位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "仓位")]
        [ExcelColumn(Name = "仓位")]

        public string MmLocPosn { get; set; }

        /// <summary>
        /// 描述 :库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "库存")]

        public decimal MmInventory { get; set; }

        /// <summary>
        /// 描述 :EOL 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EOL")]
        [ExcelColumn(Name = "EOL")]

        public string MmLocEol { get; set; }

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
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义1", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义1")]

        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :自定义2 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义2", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义2")]

        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :自定义3 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义3", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义3")]

        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :自定义4 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义4", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义4")]

        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :自定义5 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义5", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义5")]

        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :自定义6 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义6", ExtendedAttribute = ProteryConstant.NOTNULL)]
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

    }

    /// <summary>
    /// 物料信息
    /// 数据实体模板对象导出
    /// @author Lean365
    /// @date 2023-09-12
    /// </summary>
    [SugarTable("mm_marb")]
    public class MmMarbImportTmpl
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false,ColumnDescription = "Guid", ExtendedAttribute = ProteryConstant.NOTNULL)]

        [ExcelColumn(Name = "Guid")]
        public Guid MmGuid { get; set; }

        /// <summary>
        /// 描述 :更新日期 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "更新日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "更新日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MmLastDate { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "工厂", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工厂")]
        public string MmPlnt { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]
        public string MmMatItem { get; set; }

        /// <summary>
        /// 描述 :行业类别 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "行业类别", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "行业类别")]
        public string MmIndustry { get; set; }

        /// <summary>
        /// 描述 :物料类型 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "物料类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料类型")]
        public string MmMatType { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "物料文本", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料文本")]
        public string MmMatDes { get; set; }

        /// <summary>
        /// 描述 :标准单位 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "标准单位", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "标准单位")]
        public string MmBaseUnit { get; set; }

        /// <summary>
        /// 描述 :层次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "层次")]
        [ExcelColumn(Name = "层次")]
        public string MmProLevel { get; set; }

        /// <summary>
        /// 描述 :物料组 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "物料组", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料组")]
        public string MmMatGroup { get; set; }

        /// <summary>
        /// 描述 :采购组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购组")]
        [ExcelColumn(Name = "采购组")]
        public string MmPurGroup { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "采购类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "采购类型")]
        public string MmPurType { get; set; }

        /// <summary>
        /// 描述 :特殊采购类 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "特殊采购类")]
        [ExcelColumn(Name = "特殊采购类")]
        public string MmSpecType { get; set; }

        /// <summary>
        /// 描述 :散装物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "散装物料")]
        [ExcelColumn(Name = "散装物料")]
        public string MmBulkMat { get; set; }

        /// <summary>
        /// 描述 :最小批量 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "最小批量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最小批量")]
        public int MmMoq { get; set; }

        /// <summary>
        /// 描述 :舍入值 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "舍入值", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "舍入值")]
        public int MmRoundingVal { get; set; }

        /// <summary>
        /// 描述 :交货时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "交货时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "交货时间")]
        public int MmLeadTime { get; set; }

        /// <summary>
        /// 描述 :生产天数 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "生产天数", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产天数")]
        public decimal MmProDays { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验否")]
        [ExcelColumn(Name = "检验否")]
        public string MmisChecked { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "利润中心", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "利润中心")]
        public string MmProfitCenter { get; set; }

        /// <summary>
        /// 描述 :差异码 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "差异码")]
        [ExcelColumn(Name = "差异码")]
        public string MmDiffCode { get; set; }

        /// <summary>
        /// 描述 :批次管理 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "批次管理")]
        [ExcelColumn(Name = "批次管理")]
        public string MmisLot { get; set; }

        /// <summary>
        /// 描述 :制造商物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "制造商物料")]
        [ExcelColumn(Name = "制造商物料")]
        public string MmMpn { get; set; }

        /// <summary>
        /// 描述 :制造商 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "制造商")]
        [ExcelColumn(Name = "制造商")]
        public string MmMfrs { get; set; }

        /// <summary>
        /// 描述 :评估类 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "评估类", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "评估类")]
        public string MmValType { get; set; }

        /// <summary>
        /// 描述 :移动平均价 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "移动平均价", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "移动平均价")]
        public decimal MmMovingAvg { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "币种", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "币种")]
        public string MmCcy { get; set; }

        /// <summary>
        /// 描述 :价格控制 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "价格控制", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "价格控制")]
        public string MmPriceControl { get; set; }

        /// <summary>
        /// 描述 :价格单位 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "价格单位", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "价格单位")]
        public int MmPriceUnit { get; set; }

        /// <summary>
        /// 描述 :采购仓库 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购仓库")]
        [ExcelColumn(Name = "采购仓库")]
        public string MmSLoc { get; set; }

        /// <summary>
        /// 描述 :生产仓库 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产仓库")]
        [ExcelColumn(Name = "生产仓库")]
        public string MmESLoc { get; set; }

        /// <summary>
        /// 描述 :仓位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "仓位")]
        [ExcelColumn(Name = "仓位")]
        public string MmLocPosn { get; set; }

        /// <summary>
        /// 描述 :库存 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "库存")]
        public decimal MmInventory { get; set; }

        /// <summary>
        /// 描述 :EOL 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EOL")]
        [ExcelColumn(Name = "EOL")]
        public string MmLocEol { get; set; }

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
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义1", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义1")]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :自定义2 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义2", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义2")]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :自定义3 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义3", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义3")]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :自定义4 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义4", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义4")]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :自定义5 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义5", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义5")]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :自定义6 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义6", ExtendedAttribute = ProteryConstant.NOTNULL)]
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
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :更新时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time",ColumnDescription = "更新时间")]
        [ExcelColumn(Name = "更新时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? UpdateTime { get; set; }

    }
}