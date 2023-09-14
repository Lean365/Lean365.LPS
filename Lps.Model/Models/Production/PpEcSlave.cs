using MiniExcelLibs.Attributes;

namespace Lps.Model.Production
{
    /// <summary>
    /// 从设变
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-09-14
    /// </summary>
    [SugarTable("pp_ec_slave")]
    public class PpEcSlave
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        [ExcelColumn(Name = "Guid")]

        public Guid EsGuid { get; set; }

        /// <summary>
        /// 描述 :输入日 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "输入日", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsEntryDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "设变No.", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "设变No.")]

        public string EsEcNo { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "机种", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "机种")]

        public string EsModel { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]

        public string EsItem { get; set; }

        /// <summary>
        /// 描述 :子物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "子物料")]
        [ExcelColumn(Name = "子物料")]

        public string EsSubItem { get; set; }

        /// <summary>
        /// 描述 :旧物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "旧物料")]
        [ExcelColumn(Name = "旧物料")]

        public string EsOldItem { get; set; }

        /// <summary>
        /// 描述 :旧文本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "旧文本")]
        [ExcelColumn(Name = "旧文本")]

        public string EsOldItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "用量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "用量")]

        public decimal EsOldUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "位置")]
        [ExcelColumn(Name = "位置")]

        public string EsOldSetLoc { get; set; }

        /// <summary>
        /// 描述 :新物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "新物料")]
        [ExcelColumn(Name = "新物料")]

        public string EsNewItem { get; set; }

        /// <summary>
        /// 描述 :新文本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "新文本")]
        [ExcelColumn(Name = "新文本")]

        public string EsNewItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "用量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "用量")]

        public decimal EsNewUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "位置")]
        [ExcelColumn(Name = "位置")]

        public string EsNewSetLoc { get; set; }

        /// <summary>
        /// 描述 :bom番号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "bom番号")]
        [ExcelColumn(Name = "bom番号")]

        public string EsBomNo { get; set; }

        /// <summary>
        /// 描述 :互换 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "互换")]
        [ExcelColumn(Name = "互换")]

        public string EsChange { get; set; }

        /// <summary>
        /// 描述 :区分 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "区分")]
        [ExcelColumn(Name = "区分")]

        public string Eslocal { get; set; }

        /// <summary>
        /// 描述 :指示 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "指示")]
        [ExcelColumn(Name = "指示")]

        public string Esnote { get; set; }

        /// <summary>
        /// 描述 :旧品处理 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "旧品处理")]
        [ExcelColumn(Name = "旧品处理")]

        public string EsOldProcess { get; set; }

        /// <summary>
        /// 描述 :bom日期 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "bom日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsBomDate { get; set; }

        /// <summary>
        /// 描述 :实施部门 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "实施部门", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "实施部门")]

        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "采购类型")]

        public string EsPurType { get; set; }

        /// <summary>
        /// 描述 :仓库 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "仓库", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "仓库")]

        public string EsSloc { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验否")]
        [ExcelColumn(Name = "检验否")]

        public string EsInsmk { get; set; }

        /// <summary>
        /// 描述 :工厂状态 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "工厂状态")]
        [ExcelColumn(Name = "工厂状态")]

        public string EsMstae { get; set; }

        /// <summary>
        /// 描述 :SOP 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "SOP", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "SOP")]

        public string EsSopStae { get; set; }

        /// <summary>
        /// 描述 :旧品库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "旧品库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "旧品库存")]

        public decimal EsOldCurrStock { get; set; }

        /// <summary>
        /// 描述 :新品库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "新品库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "新品库存")]

        public decimal EsNewCurrStock { get; set; }

        /// <summary>
        /// 描述 :采购登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购登入日期")]
        [ExcelColumn(Name = "采购登入日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPurEntryDate { get; set; }

        /// <summary>
        /// 描述 :供应商 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "供应商")]
        [ExcelColumn(Name = "供应商")]

        public string EsSupplier { get; set; }

        /// <summary>
        /// 描述 :采购PO 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购PO")]
        [ExcelColumn(Name = "采购PO")]

        public string EsPurOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]

        public string EsPurNote { get; set; }

        /// <summary>
        /// 描述 :采购新增 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购新增")]
        [ExcelColumn(Name = "采购新增")]

        public string EsPurCreator { get; set; }

        /// <summary>
        /// 描述 :采购新增日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购新增日期")]
        [ExcelColumn(Name = "采购新增日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPurCreateTime { get; set; }

        /// <summary>
        /// 描述 :采购修改 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购修改")]
        [ExcelColumn(Name = "采购修改")]

        public string EsPurModifier { get; set; }

        /// <summary>
        /// 描述 :采购修改日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购修改日期")]
        [ExcelColumn(Name = "采购修改日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPurModifyTime { get; set; }

        /// <summary>
        /// 描述 :生管登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管登入日期")]
        [ExcelColumn(Name = "生管登入日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPmcEntryDate { get; set; }

        /// <summary>
        /// 描述 :预投入批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "预投入批次")]
        [ExcelColumn(Name = "预投入批次")]

        public string EsPmcLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]

        public string EsPmcMemo { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备注")]
        [ExcelColumn(Name = "备注")]

        public string EsPmcNote { get; set; }

        /// <summary>
        /// 描述 :生管新增 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管新增")]
        [ExcelColumn(Name = "生管新增")]

        public string EsPmcCreator { get; set; }

        /// <summary>
        /// 描述 :生管新增日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管新增日期")]
        [ExcelColumn(Name = "生管新增日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPmcCreateTime { get; set; }

        /// <summary>
        /// 描述 :生管修改 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管修改")]
        [ExcelColumn(Name = "生管修改")]

        public string EsPmcModifier { get; set; }

        /// <summary>
        /// 描述 :生管修改日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管修改日期")]
        [ExcelColumn(Name = "生管修改日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPmcModifyTime { get; set; }

        /// <summary>
        /// 描述 :IQC登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC登入日期")]
        [ExcelColumn(Name = "IQC登入日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsIqcEntryDate { get; set; }

        /// <summary>
        /// 描述 :检验订单 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验订单")]
        [ExcelColumn(Name = "检验订单")]

        public string EsIqcOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]

        public string EsIqcNote { get; set; }

        /// <summary>
        /// 描述 :IQC新增 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC新增")]
        [ExcelColumn(Name = "IQC新增")]

        public string EsIqcCreator { get; set; }

        /// <summary>
        /// 描述 :IQC新增日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC新增日期")]
        [ExcelColumn(Name = "IQC新增日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsIqcCreateTime { get; set; }

        /// <summary>
        /// 描述 :IQC修改 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC修改")]
        [ExcelColumn(Name = "IQC修改")]

        public string EsIqcModifier { get; set; }

        /// <summary>
        /// 描述 :IQC修改日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC修改日期")]
        [ExcelColumn(Name = "IQC修改日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsIqcModifyTime { get; set; }

        /// <summary>
        /// 描述 :部管登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "部管登入日期")]
        [ExcelColumn(Name = "部管登入日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsMmEntryDate { get; set; }

        /// <summary>
        /// 描述 :领用批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "领用批次")]
        [ExcelColumn(Name = "领用批次")]

        public string EsMmLot { get; set; }

        /// <summary>
        /// 描述 :工单 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "工单")]
        [ExcelColumn(Name = "工单")]

        public string EsMmMocNo { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]

        public string EsMmNote { get; set; }

        /// <summary>
        /// 描述 :EsMmCreator 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsMmCreator")]
        [ExcelColumn(Name = "EsMmCreator")]

        public string EsMmCreator { get; set; }

        /// <summary>
        /// 描述 :EsMmCreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsMmCreateTime")]
        [ExcelColumn(Name = "EsMmCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsMmCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsMmModifier 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsMmModifier")]
        [ExcelColumn(Name = "EsMmModifier")]

        public string EsMmModifier { get; set; }

        /// <summary>
        /// 描述 :EsMmModifyTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsMmModifyTime")]
        [ExcelColumn(Name = "EsMmModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsMmModifyTime { get; set; }

        /// <summary>
        /// 描述 :制一登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "制一登入日期")]
        [ExcelColumn(Name = "制一登入日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPpEntryDate { get; set; }

        /// <summary>
        /// 描述 :班组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "班组")]
        [ExcelColumn(Name = "班组")]

        public string EsPpLine { get; set; }

        /// <summary>
        /// 描述 :生产批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产批次")]
        [ExcelColumn(Name = "生产批次")]

        public string EsPpLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]

        public string EsPpNote { get; set; }

        /// <summary>
        /// 描述 :EsPpCreator 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPpCreator")]
        [ExcelColumn(Name = "EsPpCreator")]

        public string EsPpCreator { get; set; }

        /// <summary>
        /// 描述 :EsPpCreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPpCreateTime")]
        [ExcelColumn(Name = "EsPpCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPpCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPpModifier 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPpModifier")]
        [ExcelColumn(Name = "EsPpModifier")]

        public string EsPpModifier { get; set; }

        /// <summary>
        /// 描述 :EsPpModifyTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPpModifyTime")]
        [ExcelColumn(Name = "EsPpModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPpModifyTime { get; set; }

        /// <summary>
        /// 描述 :制二登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "制二登入日期")]
        [ExcelColumn(Name = "制二登入日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPcbaEntryDate { get; set; }

        /// <summary>
        /// 描述 :Pcba班组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Pcba班组")]
        [ExcelColumn(Name = "Pcba班组")]

        public string EsPcbaLine { get; set; }

        /// <summary>
        /// 描述 :Pcba批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Pcba批次")]
        [ExcelColumn(Name = "Pcba批次")]

        public string EsPcbaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]

        public string EsPcbaNote { get; set; }

        /// <summary>
        /// 描述 :EsPcbaCreator 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPcbaCreator")]
        [ExcelColumn(Name = "EsPcbaCreator")]

        public string EsPcbaCreator { get; set; }

        /// <summary>
        /// 描述 :EsPcbaCreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPcbaCreateTime")]
        [ExcelColumn(Name = "EsPcbaCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPcbaCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPcbaModifier 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPcbaModifier")]
        [ExcelColumn(Name = "EsPcbaModifier")]

        public string EsPcbaModifier { get; set; }

        /// <summary>
        /// 描述 :EsPcbaModifyTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPcbaModifyTime")]
        [ExcelColumn(Name = "EsPcbaModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsPcbaModifyTime { get; set; }

        /// <summary>
        /// 描述 :QA确认日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "QA确认日期")]
        [ExcelColumn(Name = "QA确认日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsQaEntryDate { get; set; }

        /// <summary>
        /// 描述 :检验批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验批次")]
        [ExcelColumn(Name = "检验批次")]

        public string EsQaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]

        public string EsQaNote { get; set; }

        /// <summary>
        /// 描述 :EsQaCreator 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsQaCreator")]
        [ExcelColumn(Name = "EsQaCreator")]

        public string EsQaCreator { get; set; }

        /// <summary>
        /// 描述 :EsQaCreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsQaCreateTime")]
        [ExcelColumn(Name = "EsQaCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsQaCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsQaModifier 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsQaModifier")]
        [ExcelColumn(Name = "EsQaModifier")]

        public string EsQaModifier { get; set; }

        /// <summary>
        /// 描述 :EsQaModifyTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsQaModifyTime")]
        [ExcelColumn(Name = "EsQaModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? EsQaModifyTime { get; set; }

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

    }

    /// <summary>
    /// 从设变
    /// 数据实体模板对象导出
    /// @author Lean365
    /// @date 2023-09-14
    /// </summary>
    [SugarTable("pp_ec_slave")]
    public class PpEcSlaveImportTmpl
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false,ColumnDescription = "Guid", ExtendedAttribute = ProteryConstant.NOTNULL)]

        [ExcelColumn(Name = "Guid")]
        public Guid EsGuid { get; set; }

        /// <summary>
        /// 描述 :输入日 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "输入日", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsEntryDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "设变No.", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "设变No.")]
        public string EsEcNo { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "机种", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "机种")]
        public string EsModel { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]
        public string EsItem { get; set; }

        /// <summary>
        /// 描述 :子物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "子物料")]
        [ExcelColumn(Name = "子物料")]
        public string EsSubItem { get; set; }

        /// <summary>
        /// 描述 :旧物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "旧物料")]
        [ExcelColumn(Name = "旧物料")]
        public string EsOldItem { get; set; }

        /// <summary>
        /// 描述 :旧文本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "旧文本")]
        [ExcelColumn(Name = "旧文本")]
        public string EsOldItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "用量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "用量")]
        public decimal EsOldUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "位置")]
        [ExcelColumn(Name = "位置")]
        public string EsOldSetLoc { get; set; }

        /// <summary>
        /// 描述 :新物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "新物料")]
        [ExcelColumn(Name = "新物料")]
        public string EsNewItem { get; set; }

        /// <summary>
        /// 描述 :新文本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "新文本")]
        [ExcelColumn(Name = "新文本")]
        public string EsNewItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "用量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "用量")]
        public decimal EsNewUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "位置")]
        [ExcelColumn(Name = "位置")]
        public string EsNewSetLoc { get; set; }

        /// <summary>
        /// 描述 :bom番号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "bom番号")]
        [ExcelColumn(Name = "bom番号")]
        public string EsBomNo { get; set; }

        /// <summary>
        /// 描述 :互换 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "互换")]
        [ExcelColumn(Name = "互换")]
        public string EsChange { get; set; }

        /// <summary>
        /// 描述 :区分 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "区分")]
        [ExcelColumn(Name = "区分")]
        public string Eslocal { get; set; }

        /// <summary>
        /// 描述 :指示 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "指示")]
        [ExcelColumn(Name = "指示")]
        public string Esnote { get; set; }

        /// <summary>
        /// 描述 :旧品处理 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "旧品处理")]
        [ExcelColumn(Name = "旧品处理")]
        public string EsOldProcess { get; set; }

        /// <summary>
        /// 描述 :bom日期 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "bom日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsBomDate { get; set; }

        /// <summary>
        /// 描述 :实施部门 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "实施部门", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "实施部门")]
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "采购类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "采购类型")]
        public string EsPurType { get; set; }

        /// <summary>
        /// 描述 :仓库 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "仓库", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "仓库")]
        public string EsSloc { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验否")]
        [ExcelColumn(Name = "检验否")]
        public string EsInsmk { get; set; }

        /// <summary>
        /// 描述 :工厂状态 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "工厂状态")]
        [ExcelColumn(Name = "工厂状态")]
        public string EsMstae { get; set; }

        /// <summary>
        /// 描述 :SOP 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "SOP", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "SOP")]
        public string EsSopStae { get; set; }

        /// <summary>
        /// 描述 :旧品库存 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "旧品库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "旧品库存")]
        public decimal EsOldCurrStock { get; set; }

        /// <summary>
        /// 描述 :新品库存 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "新品库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "新品库存")]
        public decimal EsNewCurrStock { get; set; }

        /// <summary>
        /// 描述 :采购登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购登入日期")]
        [ExcelColumn(Name = "采购登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPurEntryDate { get; set; }

        /// <summary>
        /// 描述 :供应商 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "供应商")]
        [ExcelColumn(Name = "供应商")]
        public string EsSupplier { get; set; }

        /// <summary>
        /// 描述 :采购PO 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购PO")]
        [ExcelColumn(Name = "采购PO")]
        public string EsPurOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]
        public string EsPurNote { get; set; }

        /// <summary>
        /// 描述 :采购新增 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购新增")]
        [ExcelColumn(Name = "采购新增")]
        public string EsPurCreator { get; set; }

        /// <summary>
        /// 描述 :采购新增日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购新增日期")]
        [ExcelColumn(Name = "采购新增日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPurCreateTime { get; set; }

        /// <summary>
        /// 描述 :采购修改 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购修改")]
        [ExcelColumn(Name = "采购修改")]
        public string EsPurModifier { get; set; }

        /// <summary>
        /// 描述 :采购修改日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购修改日期")]
        [ExcelColumn(Name = "采购修改日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPurModifyTime { get; set; }

        /// <summary>
        /// 描述 :生管登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管登入日期")]
        [ExcelColumn(Name = "生管登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPmcEntryDate { get; set; }

        /// <summary>
        /// 描述 :预投入批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "预投入批次")]
        [ExcelColumn(Name = "预投入批次")]
        public string EsPmcLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]
        public string EsPmcMemo { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备注")]
        [ExcelColumn(Name = "备注")]
        public string EsPmcNote { get; set; }

        /// <summary>
        /// 描述 :生管新增 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管新增")]
        [ExcelColumn(Name = "生管新增")]
        public string EsPmcCreator { get; set; }

        /// <summary>
        /// 描述 :生管新增日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管新增日期")]
        [ExcelColumn(Name = "生管新增日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPmcCreateTime { get; set; }

        /// <summary>
        /// 描述 :生管修改 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管修改")]
        [ExcelColumn(Name = "生管修改")]
        public string EsPmcModifier { get; set; }

        /// <summary>
        /// 描述 :生管修改日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生管修改日期")]
        [ExcelColumn(Name = "生管修改日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPmcModifyTime { get; set; }

        /// <summary>
        /// 描述 :IQC登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC登入日期")]
        [ExcelColumn(Name = "IQC登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIqcEntryDate { get; set; }

        /// <summary>
        /// 描述 :检验订单 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验订单")]
        [ExcelColumn(Name = "检验订单")]
        public string EsIqcOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]
        public string EsIqcNote { get; set; }

        /// <summary>
        /// 描述 :IQC新增 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC新增")]
        [ExcelColumn(Name = "IQC新增")]
        public string EsIqcCreator { get; set; }

        /// <summary>
        /// 描述 :IQC新增日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC新增日期")]
        [ExcelColumn(Name = "IQC新增日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIqcCreateTime { get; set; }

        /// <summary>
        /// 描述 :IQC修改 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC修改")]
        [ExcelColumn(Name = "IQC修改")]
        public string EsIqcModifier { get; set; }

        /// <summary>
        /// 描述 :IQC修改日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "IQC修改日期")]
        [ExcelColumn(Name = "IQC修改日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIqcModifyTime { get; set; }

        /// <summary>
        /// 描述 :部管登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "部管登入日期")]
        [ExcelColumn(Name = "部管登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsMmEntryDate { get; set; }

        /// <summary>
        /// 描述 :领用批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "领用批次")]
        [ExcelColumn(Name = "领用批次")]
        public string EsMmLot { get; set; }

        /// <summary>
        /// 描述 :工单 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "工单")]
        [ExcelColumn(Name = "工单")]
        public string EsMmMocNo { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]
        public string EsMmNote { get; set; }

        /// <summary>
        /// 描述 :EsMmCreator 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsMmCreator")]
        [ExcelColumn(Name = "EsMmCreator")]
        public string EsMmCreator { get; set; }

        /// <summary>
        /// 描述 :EsMmCreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsMmCreateTime")]
        [ExcelColumn(Name = "EsMmCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsMmCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsMmModifier 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsMmModifier")]
        [ExcelColumn(Name = "EsMmModifier")]
        public string EsMmModifier { get; set; }

        /// <summary>
        /// 描述 :EsMmModifyTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsMmModifyTime")]
        [ExcelColumn(Name = "EsMmModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsMmModifyTime { get; set; }

        /// <summary>
        /// 描述 :制一登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "制一登入日期")]
        [ExcelColumn(Name = "制一登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPpEntryDate { get; set; }

        /// <summary>
        /// 描述 :班组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "班组")]
        [ExcelColumn(Name = "班组")]
        public string EsPpLine { get; set; }

        /// <summary>
        /// 描述 :生产批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产批次")]
        [ExcelColumn(Name = "生产批次")]
        public string EsPpLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]
        public string EsPpNote { get; set; }

        /// <summary>
        /// 描述 :EsPpCreator 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPpCreator")]
        [ExcelColumn(Name = "EsPpCreator")]
        public string EsPpCreator { get; set; }

        /// <summary>
        /// 描述 :EsPpCreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPpCreateTime")]
        [ExcelColumn(Name = "EsPpCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPpCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPpModifier 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPpModifier")]
        [ExcelColumn(Name = "EsPpModifier")]
        public string EsPpModifier { get; set; }

        /// <summary>
        /// 描述 :EsPpModifyTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPpModifyTime")]
        [ExcelColumn(Name = "EsPpModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPpModifyTime { get; set; }

        /// <summary>
        /// 描述 :制二登入日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "制二登入日期")]
        [ExcelColumn(Name = "制二登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPcbaEntryDate { get; set; }

        /// <summary>
        /// 描述 :Pcba班组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Pcba班组")]
        [ExcelColumn(Name = "Pcba班组")]
        public string EsPcbaLine { get; set; }

        /// <summary>
        /// 描述 :Pcba批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Pcba批次")]
        [ExcelColumn(Name = "Pcba批次")]
        public string EsPcbaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]
        public string EsPcbaNote { get; set; }

        /// <summary>
        /// 描述 :EsPcbaCreator 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPcbaCreator")]
        [ExcelColumn(Name = "EsPcbaCreator")]
        public string EsPcbaCreator { get; set; }

        /// <summary>
        /// 描述 :EsPcbaCreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPcbaCreateTime")]
        [ExcelColumn(Name = "EsPcbaCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPcbaCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPcbaModifier 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPcbaModifier")]
        [ExcelColumn(Name = "EsPcbaModifier")]
        public string EsPcbaModifier { get; set; }

        /// <summary>
        /// 描述 :EsPcbaModifyTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsPcbaModifyTime")]
        [ExcelColumn(Name = "EsPcbaModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPcbaModifyTime { get; set; }

        /// <summary>
        /// 描述 :QA确认日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "QA确认日期")]
        [ExcelColumn(Name = "QA确认日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsQaEntryDate { get; set; }

        /// <summary>
        /// 描述 :检验批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验批次")]
        [ExcelColumn(Name = "检验批次")]
        public string EsQaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "说明")]
        [ExcelColumn(Name = "说明")]
        public string EsQaNote { get; set; }

        /// <summary>
        /// 描述 :EsQaCreator 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsQaCreator")]
        [ExcelColumn(Name = "EsQaCreator")]
        public string EsQaCreator { get; set; }

        /// <summary>
        /// 描述 :EsQaCreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsQaCreateTime")]
        [ExcelColumn(Name = "EsQaCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsQaCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsQaModifier 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsQaModifier")]
        [ExcelColumn(Name = "EsQaModifier")]
        public string EsQaModifier { get; set; }

        /// <summary>
        /// 描述 :EsQaModifyTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EsQaModifyTime")]
        [ExcelColumn(Name = "EsQaModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsQaModifyTime { get; set; }

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

    }
}