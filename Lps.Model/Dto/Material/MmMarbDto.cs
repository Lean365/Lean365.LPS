using System.ComponentModel.DataAnnotations;
using MiniExcelLibs.Attributes;

namespace Lps.Model.Dto
{
    /// <summary>
    /// 物料信息
    /// 查询对象
    /// @author Lean365
    /// @date 2023-09-12
    /// </summary>
    public class MmMarbQueryDto : PagerInfo 
    {
        public string MmPlnt { get; set; }
        public string MmMatItem { get; set; }
        public string MmIndustry { get; set; }
        public string MmMatType { get; set; }
        public string MmMatDes { get; set; }
        public string MmMatGroup { get; set; }
        public string MmPurGroup { get; set; }
        public string MmPurType { get; set; }
        public string MmSpecType { get; set; }
        public int? MmLeadTime { get; set; }
        public string MmisChecked { get; set; }
        public string MmProfitCenter { get; set; }
        public string MmisLot { get; set; }
        public string MmValType { get; set; }
        public string MmCcy { get; set; }
        public string MmSLoc { get; set; }
        public string MmLocPosn { get; set; }
        public string MmLocEol { get; set; }
    }

    /// <summary>
    /// 物料信息输入输出对象
    /// </summary>
    public class MmMarbDto
    {
        [Required(ErrorMessage = "Guid不能为空")]
        [ExcelColumn(Name = "Guid")]
        public Guid MmGuid { get; set; }

        [Required(ErrorMessage = "更新日期不能为空")]
        [ExcelColumn(Name = "更新日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MmLastDate { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        public string MmPlnt { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        public string MmMatItem { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        [ExcelColumn(Name = "行业类别")]
        public string MmIndustry { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        [ExcelColumn(Name = "物料类型")]
        public string MmMatType { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        public string MmMatDes { get; set; }

        [Required(ErrorMessage = "标准单位不能为空")]
        [ExcelColumn(Name = "标准单位")]
        public string MmBaseUnit { get; set; }

        [ExcelColumn(Name = "层次")]
        public string MmProLevel { get; set; }

        [Required(ErrorMessage = "物料组不能为空")]
        [ExcelColumn(Name = "物料组")]
        public string MmMatGroup { get; set; }

        [ExcelColumn(Name = "采购组")]
        public string MmPurGroup { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        public string MmPurType { get; set; }

        [ExcelColumn(Name = "特殊采购类")]
        public string MmSpecType { get; set; }

        [ExcelColumn(Name = "散装物料")]
        public string MmBulkMat { get; set; }

        [Required(ErrorMessage = "最小批量不能为空")]
        [ExcelColumn(Name = "最小批量")]
        public int MmMoq { get; set; }

        [Required(ErrorMessage = "舍入值不能为空")]
        [ExcelColumn(Name = "舍入值")]
        public int MmRoundingVal { get; set; }

        [Required(ErrorMessage = "交货时间不能为空")]
        [ExcelColumn(Name = "交货时间")]
        public int MmLeadTime { get; set; }

        [Required(ErrorMessage = "生产天数不能为空")]
        [ExcelColumn(Name = "生产天数")]
        public decimal MmProDays { get; set; }

        [ExcelColumn(Name = "检验否")]
        public string MmisChecked { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        public string MmProfitCenter { get; set; }

        [ExcelColumn(Name = "差异码")]
        public string MmDiffCode { get; set; }

        [ExcelColumn(Name = "批次管理")]
        public string MmisLot { get; set; }

        [ExcelColumn(Name = "制造商物料")]
        public string MmMpn { get; set; }

        [ExcelColumn(Name = "制造商")]
        public string MmMfrs { get; set; }

        [Required(ErrorMessage = "评估类不能为空")]
        [ExcelColumn(Name = "评估类")]
        public string MmValType { get; set; }

        [Required(ErrorMessage = "移动平均价不能为空")]
        [ExcelColumn(Name = "移动平均价")]
        public decimal MmMovingAvg { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        public string MmCcy { get; set; }

        [Required(ErrorMessage = "价格控制不能为空")]
        [ExcelColumn(Name = "价格控制")]
        public string MmPriceControl { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        [ExcelColumn(Name = "价格单位")]
        public int MmPriceUnit { get; set; }

        [ExcelColumn(Name = "采购仓库")]
        public string MmSLoc { get; set; }

        [ExcelColumn(Name = "生产仓库")]
        public string MmESLoc { get; set; }

        [ExcelColumn(Name = "仓位")]
        public string MmLocPosn { get; set; }

        [Required(ErrorMessage = "库存不能为空")]
        [ExcelColumn(Name = "库存")]
        public decimal MmInventory { get; set; }

        [ExcelColumn(Name = "EOL")]
        public string MmLocEol { get; set; }

        [ExcelColumn(Name = "自定义A")]
        public string UDF01 { get; set; }

        [ExcelColumn(Name = "自定义B")]
        public string UDF02 { get; set; }

        [ExcelColumn(Name = "自定义C")]
        public string UDF03 { get; set; }

        [ExcelColumn(Name = "自定义D")]
        public string UDF04 { get; set; }

        [ExcelColumn(Name = "自定义E")]
        public string UDF05 { get; set; }

        [ExcelColumn(Name = "自定义F")]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelColumn(Name = "自定义1")]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelColumn(Name = "自定义2")]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelColumn(Name = "自定义3")]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelColumn(Name = "自定义4")]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelColumn(Name = "自定义5")]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelColumn(Name = "自定义6")]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        public string ReMarks { get; set; }

        [ExcelColumn(Name = "创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? CreateTime { get; set; }

        [ExcelColumn(Name = "更新者")]
        public string UpdateBy { get; set; }

        [ExcelColumn(Name = "更新时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? UpdateTime { get; set; }



    }
}