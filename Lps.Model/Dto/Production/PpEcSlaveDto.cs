using System.ComponentModel.DataAnnotations;
using MiniExcelLibs.Attributes;

namespace Lps.Model.Dto
{
    /// <summary>
    /// 从设变
    /// 查询对象
    /// @author Lean365
    /// @date 2023-09-15
    /// </summary>
    public class PpEcSlaveQueryDto : PagerInfo 
    {
        public DateTime? BeginEsEntryDate { get; set; }
        public DateTime? EndEsEntryDate { get; set; }
        public string EmEcNo { get; set; }
        public string EsModel { get; set; }
        public string EsItem { get; set; }
        public string EsOldItem { get; set; }
        public string EsNewItem { get; set; }
        public string EsPurType { get; set; }
        public string EsSloc { get; set; }
        public string EsInsmk { get; set; }
        public string EsMstae { get; set; }
        public string EsSopStae { get; set; }
    }

    /// <summary>
    /// 从设变输入输出对象
    /// </summary>
    public class PpEcSlaveDto
    {
        [Required(ErrorMessage = "Guid不能为空")]
        [ExcelColumn(Name = "Guid")]
        public Guid EsGuid { get; set; }

        [Required(ErrorMessage = "输入日不能为空")]
        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsEntryDate { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        [ExcelColumn(Name = "设变No.")]
        public string EmEcNo { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        public string EsModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        public string EsItem { get; set; }

        [ExcelColumn(Name = "子物料")]
        public string EsSubItem { get; set; }

        [ExcelColumn(Name = "旧物料")]
        public string EsOldItem { get; set; }

        [ExcelColumn(Name = "旧文本")]
        public string EsOldItemText { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        [ExcelColumn(Name = "用量")]
        public decimal EsOldUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        public string EsOldSetLoc { get; set; }

        [ExcelColumn(Name = "新物料")]
        public string EsNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        public string EsNewItemText { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        [ExcelColumn(Name = "用量")]
        public decimal EsNewUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        public string EsNewSetLoc { get; set; }

        [ExcelColumn(Name = "bom番号")]
        public string EsBomNo { get; set; }

        [ExcelColumn(Name = "互换")]
        public string EsChange { get; set; }

        [ExcelColumn(Name = "区分")]
        public string Eslocal { get; set; }

        [ExcelColumn(Name = "指示")]
        public string Esnote { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        public string EsOldProcess { get; set; }

        [Required(ErrorMessage = "bom日期不能为空")]
        [ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsBomDate { get; set; }

        [Required(ErrorMessage = "实施部门不能为空")]
        [ExcelColumn(Name = "实施部门")]
        public string EmEcImpDept { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        public string EsPurType { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        [ExcelColumn(Name = "仓库")]
        public string EsSloc { get; set; }

        [ExcelColumn(Name = "检验否")]
        public string EsInsmk { get; set; }

        [ExcelColumn(Name = "工厂状态")]
        public string EsMstae { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        [ExcelColumn(Name = "SOP")]
        public string EsSopStae { get; set; }

        [Required(ErrorMessage = "旧品库存不能为空")]
        [ExcelColumn(Name = "旧品库存")]
        public decimal EsOldCurrStock { get; set; }

        [Required(ErrorMessage = "新品库存不能为空")]
        [ExcelColumn(Name = "新品库存")]
        public decimal EsNewCurrStock { get; set; }

        [ExcelColumn(Name = "采购登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPurEntryDate { get; set; }

        [ExcelColumn(Name = "供应商")]
        public string EsSupplier { get; set; }

        [ExcelColumn(Name = "采购PO")]
        public string EsPurOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        public string EsPurNote { get; set; }

        [ExcelColumn(Name = "采购新增")]
        public string EsPurCreator { get; set; }

        [ExcelColumn(Name = "采购新增日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPurCreateTime { get; set; }

        [ExcelColumn(Name = "采购修改")]
        public string EsPurModifier { get; set; }

        [ExcelColumn(Name = "采购修改日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPurModifyTime { get; set; }

        [ExcelColumn(Name = "生管登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPmcEntryDate { get; set; }

        [ExcelColumn(Name = "预投入批次")]
        public string EsPmcLot { get; set; }

        [ExcelColumn(Name = "说明")]
        public string EsPmcMemo { get; set; }

        [ExcelColumn(Name = "备注")]
        public string EsPmcNote { get; set; }

        [ExcelColumn(Name = "生管新增")]
        public string EsPmcCreator { get; set; }

        [ExcelColumn(Name = "生管新增日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPmcCreateTime { get; set; }

        [ExcelColumn(Name = "生管修改")]
        public string EsPmcModifier { get; set; }

        [ExcelColumn(Name = "生管修改日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPmcModifyTime { get; set; }

        [ExcelColumn(Name = "IQC登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIqcEntryDate { get; set; }

        [ExcelColumn(Name = "检验订单")]
        public string EsIqcOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        public string EsIqcNote { get; set; }

        [ExcelColumn(Name = "IQC新增")]
        public string EsIqcCreator { get; set; }

        [ExcelColumn(Name = "IQC新增日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIqcCreateTime { get; set; }

        [ExcelColumn(Name = "IQC修改")]
        public string EsIqcModifier { get; set; }

        [ExcelColumn(Name = "IQC修改日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIqcModifyTime { get; set; }

        [ExcelColumn(Name = "部管登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsMmEntryDate { get; set; }

        [ExcelColumn(Name = "领用批次")]
        public string EsMmLot { get; set; }

        [ExcelColumn(Name = "工单")]
        public string EsMmMocNo { get; set; }

        [ExcelColumn(Name = "说明")]
        public string EsMmNote { get; set; }

        [ExcelColumn(Name = "EsMmCreator")]
        public string EsMmCreator { get; set; }

        [ExcelColumn(Name = "EsMmCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsMmCreateTime { get; set; }

        [ExcelColumn(Name = "EsMmModifier")]
        public string EsMmModifier { get; set; }

        [ExcelColumn(Name = "EsMmModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsMmModifyTime { get; set; }

        [ExcelColumn(Name = "制一登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPpEntryDate { get; set; }

        [ExcelColumn(Name = "班组")]
        public string EsPpLine { get; set; }

        [ExcelColumn(Name = "生产批次")]
        public string EsPpLot { get; set; }

        [ExcelColumn(Name = "说明")]
        public string EsPpNote { get; set; }

        [ExcelColumn(Name = "EsPpCreator")]
        public string EsPpCreator { get; set; }

        [ExcelColumn(Name = "EsPpCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPpCreateTime { get; set; }

        [ExcelColumn(Name = "EsPpModifier")]
        public string EsPpModifier { get; set; }

        [ExcelColumn(Name = "EsPpModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPpModifyTime { get; set; }

        [ExcelColumn(Name = "制二登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPcbaEntryDate { get; set; }

        [ExcelColumn(Name = "Pcba班组")]
        public string EsPcbaLine { get; set; }

        [ExcelColumn(Name = "Pcba批次")]
        public string EsPcbaLot { get; set; }

        [ExcelColumn(Name = "说明")]
        public string EsPcbaNote { get; set; }

        [ExcelColumn(Name = "EsPcbaCreator")]
        public string EsPcbaCreator { get; set; }

        [ExcelColumn(Name = "EsPcbaCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPcbaCreateTime { get; set; }

        [ExcelColumn(Name = "EsPcbaModifier")]
        public string EsPcbaModifier { get; set; }

        [ExcelColumn(Name = "EsPcbaModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPcbaModifyTime { get; set; }

        [ExcelColumn(Name = "QA确认日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsQaEntryDate { get; set; }

        [ExcelColumn(Name = "检验批次")]
        public string EsQaLot { get; set; }

        [ExcelColumn(Name = "说明")]
        public string EsQaNote { get; set; }

        [ExcelColumn(Name = "EsQaCreator")]
        public string EsQaCreator { get; set; }

        [ExcelColumn(Name = "EsQaCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsQaCreateTime { get; set; }

        [ExcelColumn(Name = "EsQaModifier")]
        public string EsQaModifier { get; set; }

        [ExcelColumn(Name = "EsQaModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsQaModifyTime { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        public string ReMarks { get; set; }

        [ExcelColumn(Name = "创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}