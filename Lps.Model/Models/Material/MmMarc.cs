using MiniExcelLibs.Attributes;

namespace Lps.Model.Material
{
    /// <summary>
    /// 工厂物料数据
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-09-11
    /// </summary>
    [SugarTable("mm_marc")]
    public class MmMarc
    {
        /// <summary>
        /// 描述 :ID主键 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        [ExcelColumn(Name = "ID主键")]

        public Guid MarcGuid { get; set; }

        /// <summary>
        /// 描述 :CC 库存盘点 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "CC 库存盘点")]
        [ExcelColumn(Name = "CC 库存盘点")]

        public string MarcABCIN { get; set; }

        /// <summary>
        /// 描述 :空气浮力因子 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "空气浮力因子", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "空气浮力因子")]

        public decimal MarcABFAC { get; set; }

        /// <summary>
        /// 描述 :MRP 相关需求  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP 相关需求 ")]
        [ExcelColumn(Name = "MRP 相关需求 ")]

        public string MarcAHDIS { get; set; }

        /// <summary>
        /// 描述 :选择方法 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "选择方法")]
        [ExcelColumn(Name = "选择方法")]

        public string MarcALTSL { get; set; }

        /// <summary>
        /// 描述 :组计数器 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "组计数器")]
        [ExcelColumn(Name = "组计数器")]

        public string MarcAPLAL { get; set; }

        /// <summary>
        /// 描述 :相关于 APO 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "相关于 APO")]
        [ExcelColumn(Name = "相关于 APO")]

        public string MarcAPOKZ { get; set; }

        /// <summary>
        /// 描述 :替换部件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "替换部件")]
        [ExcelColumn(Name = "替换部件")]

        public string MarcATPKZ { get; set; }

        /// <summary>
        /// 描述 :分割标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "分割标识")]
        [ExcelColumn(Name = "分割标识")]

        public string MarcAUFTL { get; set; }

        /// <summary>
        /// 描述 :中断日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "中断日期")]
        [ExcelColumn(Name = "中断日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? MarcAUSDT { get; set; }

        /// <summary>
        /// 描述 :发货单位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "发货单位")]
        [ExcelColumn(Name = "发货单位")]

        public string MarcAUSME { get; set; }

        /// <summary>
        /// 描述 :装配报废 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "装配报废", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "装配报废")]

        public decimal MarcAUSSS { get; set; }

        /// <summary>
        /// 描述 :自动重置 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自动重置")]
        [ExcelColumn(Name = "自动重置")]

        public string MarcAUTRU { get; set; }

        /// <summary>
        /// 描述 :差异码  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "差异码 ")]
        [ExcelColumn(Name = "差异码 ")]

        public string MarcAWSLS { get; set; }

        /// <summary>
        /// 描述 :基准数量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "基准数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "基准数量")]

        public decimal MarcBASMG { get; set; }

        /// <summary>
        /// 描述 :处理时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "处理时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "处理时间")]

        public decimal MarcBEARZ { get; set; }

        /// <summary>
        /// 描述 :采购 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "采购")]

        public string MarcBESKZ { get; set; }

        /// <summary>
        /// 描述 :固定批量大小 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "固定批量大小", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "固定批量大小")]

        public decimal MarcBSTFE { get; set; }

        /// <summary>
        /// 描述 :最大批量  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "最大批量 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最大批量 ")]

        public decimal MarcBSTMA { get; set; }

        /// <summary>
        /// 描述 :最小批量大小  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "最小批量大小 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最小批量大小 ")]

        public decimal MarcBSTMI { get; set; }

        /// <summary>
        /// 描述 :舍入值  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "舍入值 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "舍入值 ")]

        public decimal MarcBSTRF { get; set; }

        /// <summary>
        /// 描述 :评估收货锁定库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "评估收货锁定库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "评估收货锁定库存")]

        public decimal MarcBWESB { get; set; }

        /// <summary>
        /// 描述 :货源 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "货源")]
        [ExcelColumn(Name = "货源")]

        public string MarcBWSCL { get; set; }

        /// <summary>
        /// 描述 :评估类别 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "评估类别")]
        [ExcelColumn(Name = "评估类别")]

        public string MarcBWTTY { get; set; }

        /// <summary>
        /// 描述 :CAS 号（药品）  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "CAS 号（药品） ")]
        [ExcelColumn(Name = "CAS 号（药品） ")]

        public string MarcCASNR { get; set; }

        /// <summary>
        /// 描述 :周期标识被固定 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "周期标识被固定")]
        [ExcelColumn(Name = "周期标识被固定")]

        public string MarcCCFIX { get; set; }

        /// <summary>
        /// 描述 :该字段不再使用 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "该字段不再使用")]
        [ExcelColumn(Name = "该字段不再使用")]

        public string MarcCOMPL { get; set; }

        /// <summary>
        /// 描述 :寄售控制 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcCONS_PROCG")]
        [ExcelColumn(Name = "寄售控制")]

        public string MarcconsProcg { get; set; }

        /// <summary>
        /// 描述 :转换类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "转换类型")]
        [ExcelColumn(Name = "转换类型")]

        public string MarcCONVT { get; set; }

        /// <summary>
        /// 描述 :字段名  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "字段名 ")]
        [ExcelColumn(Name = "字段名 ")]

        public string MarcCOPAM { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "内部对象号 ")]
        [ExcelColumn(Name = "内部对象号 ")]

        public string MarcCUOBJ { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "内部对象号 ")]
        [ExcelColumn(Name = "内部对象号 ")]

        public string MarcCUOBV { get; set; }

        /// <summary>
        /// 描述 :MRP  范围存在 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP  范围存在")]
        [ExcelColumn(Name = "MRP  范围存在")]

        public string MarcDIBER { get; set; }

        /// <summary>
        /// 描述 :MRP组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP组 ")]
        [ExcelColumn(Name = "MRP组 ")]

        public string MarcDISGR { get; set; }

        /// <summary>
        /// 描述 :批量大小 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "批量大小", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "批量大小")]

        public string MarcDISLS { get; set; }

        /// <summary>
        /// 描述 :MRP 类型 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP 类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "MRP 类型")]

        public string MarcDISMM { get; set; }

        /// <summary>
        /// 描述 :MRP 控制者  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP 控制者 ")]
        [ExcelColumn(Name = "MRP 控制者 ")]

        public string MarcDISPO { get; set; }

        /// <summary>
        /// 描述 :MRP 参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP 参数文件")]
        [ExcelColumn(Name = "MRP 参数文件")]

        public string MarcDISPR { get; set; }

        /// <summary>
        /// 描述 :公平分享规则 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "公平分享规则")]
        [ExcelColumn(Name = "公平分享规则")]

        public string MarcDPLFS { get; set; }

        /// <summary>
        /// 描述 :发布界限 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "发布界限", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "发布界限")]

        public decimal MarcDPLHO { get; set; }

        /// <summary>
        /// 描述 :推式分配 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "推式分配")]
        [ExcelColumn(Name = "推式分配")]

        public string MarcDPLPU { get; set; }

        /// <summary>
        /// 描述 :厂内生产时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "厂内生产时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "厂内生产时间")]

        public decimal MarcDZEIT { get; set; }

        /// <summary>
        /// 描述 :安全库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "安全库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "安全库存")]

        public decimal MarcEISBE { get; set; }

        /// <summary>
        /// 描述 :最小安全库存  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "最小安全库存 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最小安全库存 ")]

        public decimal MarcEISLO { get; set; }

        /// <summary>
        /// 描述 :采购组  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "采购组 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "采购组 ")]

        public string MarcEKGRP { get; set; }

        /// <summary>
        /// 描述 :库存确定组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "库存确定组 ")]
        [ExcelColumn(Name = "库存确定组 ")]

        public string MarcEPRIO { get; set; }

        /// <summary>
        /// 描述 :商品代码单位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "商品代码单位")]
        [ExcelColumn(Name = "商品代码单位")]

        public string MarcEXPME { get; set; }

        /// <summary>
        /// 描述 :JIT 标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "JIT 标识")]
        [ExcelColumn(Name = "JIT 标识")]

        public string MarcFABKZ { get; set; }

        /// <summary>
        /// 描述 :生产管理员  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产管理员 ")]
        [ExcelColumn(Name = "生产管理员 ")]

        public string MarcFEVOR { get; set; }

        /// <summary>
        /// 描述 :自动批准 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自动批准")]
        [ExcelColumn(Name = "自动批准")]

        public string MarcFFREI { get; set; }

        /// <summary>
        /// 描述 :计划边际码  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划边际码 ")]
        [ExcelColumn(Name = "计划边际码 ")]

        public string MarcFHORI { get; set; }

        /// <summary>
        /// 描述 :固定批量大小 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "固定批量大小", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "固定批量大小")]

        public decimal MarcFIXLS { get; set; }

        /// <summary>
        /// 描述 :分配 prof. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "分配 prof.")]
        [ExcelColumn(Name = "分配 prof.")]

        public string MarcFPRFM { get; set; }

        /// <summary>
        /// 描述 :生产单位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产单位")]
        [ExcelColumn(Name = "生产单位")]

        public string MarcFRTME { get; set; }

        /// <summary>
        /// 描述 :订单分配运行 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcFSH_MG_ARUN_REQ")]
        [ExcelColumn(Name = "订单分配运行")]

        public string MarcfshMgArunReq { get; set; }

        /// <summary>
        /// 描述 :库存管理中激活季节 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcFSH_SEAIM")]
        [ExcelColumn(Name = "库存管理中激活季节")]

        public string MarcfshSeaim { get; set; }

        /// <summary>
        /// 描述 :生产版本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产版本")]
        [ExcelColumn(Name = "生产版本")]

        public string MarcFVIDK { get; set; }

        /// <summary>
        /// 描述 :计划的时界  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划的时界 ")]
        [ExcelColumn(Name = "计划的时界 ")]

        public string MarcFXHOR { get; set; }

        /// <summary>
        /// 描述 :固定价格联产品 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "固定价格联产品")]
        [ExcelColumn(Name = "固定价格联产品")]

        public string MarcFXPRU { get; set; }

        /// <summary>
        /// 描述 :发货处理时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "marcGI_PR_TIME")]
        [ExcelColumn(Name = "发货处理时间")]

        public decimal MarcgiPrTime { get; set; }

        /// <summary>
        /// 描述 :有约束的虚拟 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "有约束的虚拟", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "有约束的虚拟")]

        public decimal MarcGLGMG { get; set; }

        /// <summary>
        /// 描述 :粗略计划 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "粗略计划")]
        [ExcelColumn(Name = "粗略计划")]

        public string MarcGPMKZ { get; set; }

        /// <summary>
        /// 描述 :PRODCOM号  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "PRODCOM号 ")]
        [ExcelColumn(Name = "PRODCOM号 ")]

        public string MarcGPNUM { get; set; }

        /// <summary>
        /// 描述 :生产状态  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产状态 ")]
        [ExcelColumn(Name = "生产状态 ")]

        public string MarcHERBL { get; set; }

        /// <summary>
        /// 描述 :原产地国 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "原产地国")]
        [ExcelColumn(Name = "原产地国")]

        public string MarcHERKL { get; set; }

        /// <summary>
        /// 描述 :货源地  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "货源地 ")]
        [ExcelColumn(Name = "货源地 ")]

        public string MarcHERKR { get; set; }

        /// <summary>
        /// 描述 :物料类别 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料类别")]
        [ExcelColumn(Name = "物料类别")]

        public string MarcINDUS { get; set; }

        /// <summary>
        /// 描述 :过帐到检验库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "过帐到检验库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "过帐到检验库存")]

        public string MarcINSMK { get; set; }

        /// <summary>
        /// 描述 :军用物资 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "军用物资")]
        [ExcelColumn(Name = "军用物资")]

        public string MarcITARK { get; set; }

        /// <summary>
        /// 描述 :IUID 相关 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcIUID_RELEVANT")]
        [ExcelColumn(Name = "IUID 相关")]

        public string MarciuidRelevant { get; set; }

        /// <summary>
        /// 描述 :IUID 类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcIUID_TYPE")]
        [ExcelColumn(Name = "IUID 类型")]

        public string MarciuidType { get; set; }

        /// <summary>
        /// 描述 :组件报废 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "组件报废", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "组件报废")]

        public decimal MarcKAUSF { get; set; }

        /// <summary>
        /// 描述 :自动采购单  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自动采购单 ")]
        [ExcelColumn(Name = "自动采购单 ")]

        public string MarcKAUTB { get; set; }

        /// <summary>
        /// 描述 :源清单  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "源清单 ")]
        [ExcelColumn(Name = "源清单 ")]

        public string MarcKORDB { get; set; }

        /// <summary>
        /// 描述 :平滑促销消耗  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "平滑促销消耗 ")]
        [ExcelColumn(Name = "平滑促销消耗 ")]

        public string MarcKZAGL { get; set; }

        /// <summary>
        /// 描述 :非连续标识  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "非连续标识 ")]
        [ExcelColumn(Name = "非连续标识 ")]

        public string MarcKZAUS { get; set; }

        /// <summary>
        /// 描述 :需求分组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "需求分组 ")]
        [ExcelColumn(Name = "需求分组 ")]

        public string MarcKZBED { get; set; }

        /// <summary>
        /// 描述 :MRP控制者=买者  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP控制者=买者 ")]
        [ExcelColumn(Name = "MRP控制者=买者 ")]

        public string MarcKZDIE { get; set; }

        /// <summary>
        /// 描述 :凭证需求  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "凭证需求 ")]
        [ExcelColumn(Name = "凭证需求 ")]

        public string MarcKZDKZ { get; set; }

        /// <summary>
        /// 描述 :输入批量 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "输入批量")]
        [ExcelColumn(Name = "输入批量")]

        public string MarcKZECH { get; set; }

        /// <summary>
        /// 描述 :修正因子 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "修正因子")]
        [ExcelColumn(Name = "修正因子")]

        public string MarcKZKFK { get; set; }

        /// <summary>
        /// 描述 :关键组件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "关键组件")]
        [ExcelColumn(Name = "关键组件")]

        public string MarcKZKRI { get; set; }

        /// <summary>
        /// 描述 :联产品  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "联产品 ")]
        [ExcelColumn(Name = "联产品 ")]

        public string MarcKZKUP { get; set; }

        /// <summary>
        /// 描述 :检查计划标识  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检查计划标识 ")]
        [ExcelColumn(Name = "检查计划标识 ")]

        public string MarcKZPPV { get; set; }

        /// <summary>
        /// 描述 :从产品货位提取 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "从产品货位提取")]
        [ExcelColumn(Name = "从产品货位提取")]

        public string MarcKZPRO { get; set; }

        /// <summary>
        /// 描述 :跨项目  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "跨项目 ")]
        [ExcelColumn(Name = "跨项目 ")]

        public string MarcKZPSP { get; set; }

        /// <summary>
        /// 描述 :装载组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "装载组 ")]
        [ExcelColumn(Name = "装载组 ")]

        public string MarcLADGR { get; set; }

        /// <summary>
        /// 描述 :库存成本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "库存成本")]
        [ExcelColumn(Name = "库存成本")]

        public string MarcLAGPR { get; set; }

        /// <summary>
        /// 描述 :年  当前期间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "年  当前期间")]
        [ExcelColumn(Name = "年  当前期间")]

        public string MarcLFGJA { get; set; }

        /// <summary>
        /// 描述 :本期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "本期")]
        [ExcelColumn(Name = "本期")]

        public string MarcLFMON { get; set; }

        /// <summary>
        /// 描述 :计划周期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划周期")]
        [ExcelColumn(Name = "计划周期")]

        public string MarcLFRHY { get; set; }

        /// <summary>
        /// 描述 :外部采购仓储地 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "外部采购仓储地", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "外部采购仓储地")]

        public string MarcLGFSB { get; set; }

        /// <summary>
        /// 描述 :生产仓储地点 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产仓储地点", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产仓储地点")]

        public string MarcLGPRO { get; set; }

        /// <summary>
        /// 描述 :服务水平 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "服务水平", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "服务水平")]

        public decimal MarcLGRAD { get; set; }

        /// <summary>
        /// 描述 :取消激活的 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "取消激活的")]
        [ExcelColumn(Name = "取消激活的")]

        public string MarcLIZYK { get; set; }

        /// <summary>
        /// 描述 :后勤组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "后勤组 ")]
        [ExcelColumn(Name = "后勤组 ")]

        public string MarcLOGGR { get; set; }

        /// <summary>
        /// 描述 :订购成本 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "订购成本", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "订购成本")]

        public decimal MarcLOSFX { get; set; }

        /// <summary>
        /// 描述 :成本核算批量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "成本核算批量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "成本核算批量")]

        public decimal MarcLOSGR { get; set; }

        /// <summary>
        /// 描述 :批尺寸增加  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "批尺寸增加 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "批尺寸增加 ")]

        public decimal MarcLTINC { get; set; }

        /// <summary>
        /// 描述 :工厂级 DF 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "工厂级 DF")]
        [ExcelColumn(Name = "工厂级 DF")]

        public string MarcLVORM { get; set; }

        /// <summary>
        /// 描述 :时间单位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "时间单位")]
        [ExcelColumn(Name = "时间单位")]

        public string MarcLZEIH { get; set; }

        /// <summary>
        /// 描述 :ABC 标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "ABC 标识")]
        [ExcelColumn(Name = "ABC 标识")]

        public string MarcMAABC { get; set; }

        /// <summary>
        /// 描述 :最大库存水平  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "最大库存水平 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最大库存水平 ")]

        public decimal MarcMABST { get; set; }

        /// <summary>
        /// 描述 :集团 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "集团", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "集团")]

        public string MarcMANDT { get; set; }

        /// <summary>
        /// 描述 :物料分组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料分组")]
        [ExcelColumn(Name = "物料分组")]

        public string MarcMATGR { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]

        public string MarcMATNR { get; set; }

        /// <summary>
        /// 描述 :最大目标范围  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcMAX_TROC")]
        [ExcelColumn(Name = "最大目标范围 ")]

        public string MarcmaxTroc { get; set; }

        /// <summary>
        /// 描述 :最大批量大小  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "最大批量大小 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最大批量大小 ")]

        public decimal MarcMAXLS { get; set; }

        /// <summary>
        /// 描述 :最大存储期间  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "最大存储期间 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最大存储期间 ")]

        public decimal MarcMAXLZ { get; set; }

        /// <summary>
        /// 描述 :最后的MARD 期间之前，MARDH 记 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "最后的MARD 期间之前，MARDH 记")]
        [ExcelColumn(Name = "最后的MARD 期间之前，MARDH 记")]

        public string MarcMCRUE { get; set; }

        /// <summary>
        /// 描述 :活动控制 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "活动控制")]
        [ExcelColumn(Name = "活动控制")]

        public string MarcMDACH { get; set; }

        /// <summary>
        /// 描述 :计量单位组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计量单位组 ")]
        [ExcelColumn(Name = "计量单位组 ")]

        public string MarcMEGRU { get; set; }

        /// <summary>
        /// 描述 :物料运输组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料运输组 ")]
        [ExcelColumn(Name = "物料运输组 ")]

        public string MarcMFRGR { get; set; }

        /// <summary>
        /// 描述 :最小目标范围  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcMIN_TROC")]
        [ExcelColumn(Name = "最小目标范围 ")]

        public string MarcminTroc { get; set; }

        /// <summary>
        /// 描述 :再订货点 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "再订货点", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "再订货点")]

        public decimal MarcMINBE { get; set; }

        /// <summary>
        /// 描述 :最小批量大小  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "最小批量大小 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最小批量大小 ")]

        public decimal MarcMINLS { get; set; }

        /// <summary>
        /// 描述 :综合MRP 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "综合MRP")]
        [ExcelColumn(Name = "综合MRP")]

        public string MarcMISKZ { get; set; }

        /// <summary>
        /// 描述 :P-S 物料状态  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "P-S 物料状态 ")]
        [ExcelColumn(Name = "P-S 物料状态 ")]

        public string MarcMMSTA { get; set; }

        /// <summary>
        /// 描述 :有效起始期  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "有效起始期 ")]
        [ExcelColumn(Name = "有效起始期 ", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? MarcMMSTD { get; set; }

        /// <summary>
        /// 描述 :CAP 产品组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "CAP 产品组 ")]
        [ExcelColumn(Name = "CAP 产品组 ")]

        public string MarcMOGRU { get; set; }

        /// <summary>
        /// 描述 :EU 产品清单编号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EU 产品清单编号")]
        [ExcelColumn(Name = "EU 产品清单编号")]

        public string MarcMOWNR { get; set; }

        /// <summary>
        /// 描述 :平均检查持续期 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "平均检查持续期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "平均检查持续期")]

        public decimal MarcMPDAU { get; set; }

        /// <summary>
        /// 描述 :计划日历 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划日历")]
        [ExcelColumn(Name = "计划日历")]

        public string MarcMRPPP { get; set; }

        /// <summary>
        /// 描述 :出口/进口组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "出口/进口组 ")]
        [ExcelColumn(Name = "出口/进口组 ")]

        public string MarcMTVER { get; set; }

        /// <summary>
        /// 描述 :可用性检查  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "可用性检查 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "可用性检查 ")]

        public string MarcMTVFP { get; set; }

        /// <summary>
        /// 描述 :交叉的采购组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcMULTIPLE_EKGRP")]
        [ExcelColumn(Name = "交叉的采购组")]

        public string MarcmultipleEkgrp { get; set; }

        /// <summary>
        /// 描述 :无成本核算  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "无成本核算 ")]
        [ExcelColumn(Name = "无成本核算 ")]

        public string MarcNCOST { get; set; }

        /// <summary>
        /// 描述 :后继物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "后继物料")]
        [ExcelColumn(Name = "后继物料")]

        public string MarcNFMAT { get; set; }

        /// <summary>
        /// 描述 :下一次检查  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "下一次检查 ")]
        [ExcelColumn(Name = "下一次检查 ", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? MarcNKMPR { get; set; }

        /// <summary>
        /// 描述 :对象标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "对象标识")]
        [ExcelColumn(Name = "对象标识")]

        public string MarcOBJID { get; set; }

        /// <summary>
        /// 描述 :总体参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "总体参数文件")]
        [ExcelColumn(Name = "总体参数文件")]

        public string MarcOCMPF { get; set; }

        /// <summary>
        /// 描述 :对象类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "对象类型")]
        [ExcelColumn(Name = "对象类型")]

        public string MarcOTYPE { get; set; }

        /// <summary>
        /// 描述 :会计年度变式 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "会计年度变式")]
        [ExcelColumn(Name = "会计年度变式")]

        public string MarcPERIV { get; set; }

        /// <summary>
        /// 描述 :期间标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "期间标识")]
        [ExcelColumn(Name = "期间标识")]

        public string MarcPERKZ { get; set; }

        /// <summary>
        /// 描述 :自动更改工厂订单 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自动更改工厂订单")]
        [ExcelColumn(Name = "自动更改工厂订单")]

        public string MarcPFREI { get; set; }

        /// <summary>
        /// 描述 :计划交货时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划交货时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "计划交货时间")]

        public decimal MarcPLIFZ { get; set; }

        /// <summary>
        /// 描述 :组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "组 ")]
        [ExcelColumn(Name = "组 ")]

        public string MarcPLNNR { get; set; }

        /// <summary>
        /// 描述 :任务清单类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "任务清单类型")]
        [ExcelColumn(Name = "任务清单类型")]

        public string MarcPLNTY { get; set; }

        /// <summary>
        /// 描述 :计划版本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划版本")]
        [ExcelColumn(Name = "计划版本")]

        public string MarcPLVAR { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "利润中心", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "利润中心")]

        public string MarcPRCTR { get; set; }

        /// <summary>
        /// 描述 :优先权  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "优先权 ")]
        [ExcelColumn(Name = "优先权 ")]

        public string MarcPREFE { get; set; }

        /// <summary>
        /// 描述 :免税证书 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "免税证书")]
        [ExcelColumn(Name = "免税证书")]

        public string MarcPRENC { get; set; }

        /// <summary>
        /// 描述 :发放证书日  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "发放证书日 ")]
        [ExcelColumn(Name = "发放证书日 ", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? MarcPREND { get; set; }

        /// <summary>
        /// 描述 :供应商申报  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "供应商申报 ")]
        [ExcelColumn(Name = "供应商申报 ")]

        public string MarcPRENE { get; set; }

        /// <summary>
        /// 描述 :供应商申报日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "供应商申报日期")]
        [ExcelColumn(Name = "供应商申报日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? MarcPRENG { get; set; }

        /// <summary>
        /// 描述 :免税证书编号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "免税证书编号")]
        [ExcelColumn(Name = "免税证书编号")]

        public string MarcPRENO { get; set; }

        /// <summary>
        /// 描述 :检查间隔  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "检查间隔 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "检查间隔 ")]

        public decimal MarcPRFRQ { get; set; }

        /// <summary>
        /// 描述 :维护状态  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "维护状态 ")]
        [ExcelColumn(Name = "维护状态 ")]

        public string MarcPSTAT { get; set; }

        /// <summary>
        /// 描述 :QM 物料授权 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "QM 物料授权")]
        [ExcelColumn(Name = "QM 物料授权")]

        public string MarcQMATA { get; set; }

        /// <summary>
        /// 描述 :检验设置  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验设置 ")]
        [ExcelColumn(Name = "检验设置 ")]

        public string MarcQMATV { get; set; }

        /// <summary>
        /// 描述 :目标 QM 系统 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "目标 QM 系统")]
        [ExcelColumn(Name = "目标 QM 系统")]

        public string MarcQSSYS { get; set; }

        /// <summary>
        /// 描述 :隔离 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "隔离", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "隔离")]

        public decimal MarcQUAZT { get; set; }

        /// <summary>
        /// 描述 :证书类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "证书类型")]
        [ExcelColumn(Name = "证书类型")]

        public string MarcQZGTP { get; set; }

        /// <summary>
        /// 描述 :舍入参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "舍入参数文件")]
        [ExcelColumn(Name = "舍入参数文件")]

        public string MarcRDPRF { get; set; }

        /// <summary>
        /// 描述 :确定方案 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcREF_SCHEMA")]
        [ExcelColumn(Name = "确定方案")]

        public string MarcrefSchema { get; set; }

        /// <summary>
        /// 描述 :调整期间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "调整期间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "调整期间")]

        public decimal MarcRESVP { get; set; }

        /// <summary>
        /// 描述 :反冲 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "反冲")]
        [ExcelColumn(Name = "反冲")]

        public string MarcRGEKZ { get; set; }

        /// <summary>
        /// 描述 :库存入库/出库 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcROTATION_DATE")]
        [ExcelColumn(Name = "库存入库/出库")]

        public string MarcrotationDate { get; set; }

        /// <summary>
        /// 描述 :准备时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "准备时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "准备时间")]

        public decimal MarcRUEZT { get; set; }

        /// <summary>
        /// 描述 :供货天数参文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "供货天数参文件")]
        [ExcelColumn(Name = "供货天数参文件")]

        public string MarcRWPRO { get; set; }

        /// <summary>
        /// 描述 :重复生产 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "重复生产")]
        [ExcelColumn(Name = "重复生产")]

        public string MarcSAUFT { get; set; }

        /// <summary>
        /// 描述 :独立/集中 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "独立/集中")]
        [ExcelColumn(Name = "独立/集中")]

        public string MarcSBDKZ { get; set; }

        /// <summary>
        /// 描述 :散装物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "散装物料")]
        [ExcelColumn(Name = "散装物料")]

        public string MarcSCHGT { get; set; }

        /// <summary>
        /// 描述 :序列号参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "序列号参数文件")]
        [ExcelColumn(Name = "序列号参数文件")]

        public string MarcSERNP { get; set; }

        /// <summary>
        /// 描述 :服务水平 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "服务水平")]
        [ExcelColumn(Name = "服务水平")]

        public string MarcSERVG { get; set; }

        /// <summary>
        /// 描述 :生产参数文  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产参数文 ")]
        [ExcelColumn(Name = "生产参数文 ")]

        public string MarcSFCPF { get; set; }

        /// <summary>
        /// 描述 :REM 参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "REM 参数文件")]
        [ExcelColumn(Name = "REM 参数文件")]

        public string MarcSFEPR { get; set; }

        /// <summary>
        /// 描述 :离散批次编号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_CHINT")]
        [ExcelColumn(Name = "离散批次编号")]

        public string MarcsgtChint { get; set; }

        /// <summary>
        /// 描述 :分段策略 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_COVS")]
        [ExcelColumn(Name = "分段策略")]

        public string MarcsgtCovs { get; set; }

        /// <summary>
        /// 描述 :库存排序方法 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_MRPSI")]
        [ExcelColumn(Name = "库存排序方法")]

        public string MarcsgtMrpsi { get; set; }

        /// <summary>
        /// 描述 :消耗优先级 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_PRCM")]
        [ExcelColumn(Name = "消耗优先级")]

        public string MarcsgtPrcm { get; set; }

        /// <summary>
        /// 描述 :分段范围 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_SCOPE")]
        [ExcelColumn(Name = "分段范围")]

        public string MarcsgtScope { get; set; }

        /// <summary>
        /// 描述 :分段状态 MRP 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_STATC")]
        [ExcelColumn(Name = "分段状态 MRP")]

        public string MarcsgtStatc { get; set; }

        /// <summary>
        /// 描述 :库存保护 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_STK_PRT")]
        [ExcelColumn(Name = "库存保护")]

        public string MarcsgtStkPrt { get; set; }

        /// <summary>
        /// 描述 :安全时间标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "安全时间标识")]
        [ExcelColumn(Name = "安全时间标识")]

        public string MarcSHFLG { get; set; }

        /// <summary>
        /// 描述 :ST 期间参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "ST 期间参数文件")]
        [ExcelColumn(Name = "ST 期间参数文件")]

        public string MarcSHPRO { get; set; }

        /// <summary>
        /// 描述 :安全时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "安全时间")]
        [ExcelColumn(Name = "安全时间")]

        public string MarcSHZET { get; set; }

        /// <summary>
        /// 描述 :特殊工艺类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "特殊工艺类型")]
        [ExcelColumn(Name = "特殊工艺类型")]

        public string MarcSOBSK { get; set; }

        /// <summary>
        /// 描述 :特殊采购 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "特殊采购", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "特殊采购")]

        public string MarcSOBSL { get; set; }

        /// <summary>
        /// 描述 :样本% 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "样本%", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "样本%")]

        public decimal MarcSPROZ { get; set; }

        /// <summary>
        /// 描述 :QM 控制码  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "QM 控制码 ")]
        [ExcelColumn(Name = "QM 控制码 ")]

        public string MarcSSQSS { get; set; }

        /// <summary>
        /// 描述 :Comm./imp. code 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Comm./imp. code")]
        [ExcelColumn(Name = "Comm./imp. code")]

        public string MarcSTAWN { get; set; }

        /// <summary>
        /// 描述 :可配置的物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "可配置的物料")]
        [ExcelColumn(Name = "可配置的物料")]

        public string MarcSTDPD { get; set; }

        /// <summary>
        /// 描述 :控制代码 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "控制代码")]
        [ExcelColumn(Name = "控制代码")]

        public string MarcSTEUC { get; set; }

        /// <summary>
        /// 描述 :备选  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备选 ")]
        [ExcelColumn(Name = "备选 ")]

        public string MarcSTLAL { get; set; }

        /// <summary>
        /// 描述 :用途  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "用途 ")]
        [ExcelColumn(Name = "用途 ")]

        public string MarcSTLAN { get; set; }

        /// <summary>
        /// 描述 :策略组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "策略组 ")]
        [ExcelColumn(Name = "策略组 ")]

        public string MarcSTRGR { get; set; }

        /// <summary>
        /// 描述 :间隔时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "间隔时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "间隔时间")]

        public decimal MarcTAKZT { get; set; }

        /// <summary>
        /// 描述 :目标库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "marcTARGET_STOCK")]
        [ExcelColumn(Name = "目标库存")]

        public decimal MarctargetStock { get; set; }

        /// <summary>
        /// 描述 :在途库存  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "在途库存 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "在途库存 ")]

        public decimal MarcTRAME { get; set; }

        /// <summary>
        /// 描述 :工序间  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "工序间 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工序间 ")]

        public decimal MarcTRANZ { get; set; }

        /// <summary>
        /// 描述 :OB管理 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "OB管理")]
        [ExcelColumn(Name = "OB管理")]

        public string MarcUCHKZ { get; set; }

        /// <summary>
        /// 描述 :OB参考物料  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "OB参考物料 ")]
        [ExcelColumn(Name = "OB参考物料 ")]

        public string MarcUCMAT { get; set; }

        /// <summary>
        /// 描述 :无限的  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "无限的 ")]
        [ExcelColumn(Name = "无限的 ")]

        public string MarcUEETK { get; set; }

        /// <summary>
        /// 描述 :过度交货允差 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "过度交货允差", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "过度交货允差")]

        public decimal MarcUEETO { get; set; }

        /// <summary>
        /// 描述 :外部分配 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcUID_IEA")]
        [ExcelColumn(Name = "外部分配")]

        public string MarcuidIea { get; set; }

        /// <summary>
        /// 描述 :中转库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "中转库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "中转库存")]

        public decimal MarcUMLMC { get; set; }

        /// <summary>
        /// 描述 :转换组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "转换组 ")]
        [ExcelColumn(Name = "转换组 ")]

        public string MarcUMRSL { get; set; }

        /// <summary>
        /// 描述 :不足交货允差 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "不足交货允差", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "不足交货允差")]

        public decimal MarcUNETO { get; set; }

        /// <summary>
        /// 描述 :计量单位组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计量单位组 ")]
        [ExcelColumn(Name = "计量单位组 ")]

        public string MarcUOMGR { get; set; }

        /// <summary>
        /// 描述 :配额使用安排 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "配额使用安排")]
        [ExcelColumn(Name = "配额使用安排")]

        public string MarcUSEQU { get; set; }

        /// <summary>
        /// 描述 :基准数量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "基准数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "基准数量")]

        public decimal MarcVBAMG { get; set; }

        /// <summary>
        /// 描述 :处理时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "处理时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "处理时间")]

        public decimal MarcVBEAZ { get; set; }

        /// <summary>
        /// 描述 :版本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "版本")]
        [ExcelColumn(Name = "版本")]

        public string MarcVERKZ { get; set; }

        /// <summary>
        /// 描述 :逆向消耗期间  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "逆向消耗期间 ")]
        [ExcelColumn(Name = "逆向消耗期间 ")]

        public string MarcVINT1 { get; set; }

        /// <summary>
        /// 描述 :向前消耗期间  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "向前消耗期间 ")]
        [ExcelColumn(Name = "向前消耗期间 ")]

        public string MarcVINT2 { get; set; }

        /// <summary>
        /// 描述 :SlsVal.TiedEmpt 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "SlsVal.TiedEmpt", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "SlsVal.TiedEmpt")]

        public decimal MarcVKGLG { get; set; }

        /// <summary>
        /// 描述 :运输库存/SP 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "运输库存/SP", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "运输库存/SP")]

        public decimal MarcVKTRW { get; set; }

        /// <summary>
        /// 描述 :库存转移 SV 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "库存转移 SV", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "库存转移 SV")]

        public decimal MarcVKUMC { get; set; }

        /// <summary>
        /// 描述 :日期到  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "日期到 ")]
        [ExcelColumn(Name = "日期到 ", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? MarcVRBDT { get; set; }

        /// <summary>
        /// 描述 :乘数 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "乘数", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "乘数")]

        public decimal MarcVRBFK { get; set; }

        /// <summary>
        /// 描述 :参考物料:消耗  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "参考物料:消耗 ")]
        [ExcelColumn(Name = "参考物料:消耗 ")]

        public string MarcVRBMT { get; set; }

        /// <summary>
        /// 描述 :参考工厂：寄存 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "参考工厂：寄存")]
        [ExcelColumn(Name = "参考工厂：寄存")]

        public string MarcVRBWK { get; set; }

        /// <summary>
        /// 描述 :消耗模式  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "消耗模式 ")]
        [ExcelColumn(Name = "消耗模式 ")]

        public string MarcVRMOD { get; set; }

        /// <summary>
        /// 描述 :准备时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "准备时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "准备时间")]

        public decimal MarcVRVEZ { get; set; }

        /// <summary>
        /// 描述 :提议供应区域 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "提议供应区域")]
        [ExcelColumn(Name = "提议供应区域")]

        public string MarcVSPVB { get; set; }

        /// <summary>
        /// 描述 :附加费 % 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "附加费 %", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "附加费 %")]

        public decimal MarcVZUSL { get; set; }

        /// <summary>
        /// 描述 :收货处理时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "收货处理时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "收货处理时间")]

        public decimal MarcWEBAZ { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "工厂", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工厂")]

        public string MarcWERKS { get; set; }

        /// <summary>
        /// 描述 :活动性物质  
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "活动性物质 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "活动性物质 ")]

        public decimal MarcWSTGH { get; set; }

        /// <summary>
        /// 描述 :总补货提前时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "总补货提前时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "总补货提前时间")]

        public decimal MarcWZEIT { get; set; }

        /// <summary>
        /// 描述 :批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "批次")]
        [ExcelColumn(Name = "批次")]

        public string MarcXCHAR { get; set; }

        /// <summary>
        /// 描述 :批次管理需求  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "批次管理需求 ")]
        [ExcelColumn(Name = "批次管理需求 ")]

        public string MarcXCHPF { get; set; }

        /// <summary>
        /// 描述 :负的库存 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "负的库存")]
        [ExcelColumn(Name = "负的库存")]

        public string MarcXMCNG { get; set; }

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
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "软删除", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "软删除")]

        public int IsDeleted { get; set; }

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
    /// 工厂物料数据
    /// 数据实体模板对象导出
    /// @author Lean365
    /// @date 2023-09-11
    /// </summary>
    [SugarTable("mm_marc")]
    public class MmMarcImportTmpl
    {
        /// <summary>
        /// 描述 :ID主键 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false,ColumnDescription = "ID主键", ExtendedAttribute = ProteryConstant.NOTNULL)]

        [ExcelColumn(Name = "ID主键")]
        public Guid MarcGuid { get; set; }

        /// <summary>
        /// 描述 :CC 库存盘点 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "CC 库存盘点")]
        [ExcelColumn(Name = "CC 库存盘点")]
        public string MarcABCIN { get; set; }

        /// <summary>
        /// 描述 :空气浮力因子 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "空气浮力因子", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "空气浮力因子")]
        public decimal MarcABFAC { get; set; }

        /// <summary>
        /// 描述 :MRP 相关需求  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP 相关需求 ")]
        [ExcelColumn(Name = "MRP 相关需求 ")]
        public string MarcAHDIS { get; set; }

        /// <summary>
        /// 描述 :选择方法 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "选择方法")]
        [ExcelColumn(Name = "选择方法")]
        public string MarcALTSL { get; set; }

        /// <summary>
        /// 描述 :组计数器 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "组计数器")]
        [ExcelColumn(Name = "组计数器")]
        public string MarcAPLAL { get; set; }

        /// <summary>
        /// 描述 :相关于 APO 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "相关于 APO")]
        [ExcelColumn(Name = "相关于 APO")]
        public string MarcAPOKZ { get; set; }

        /// <summary>
        /// 描述 :替换部件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "替换部件")]
        [ExcelColumn(Name = "替换部件")]
        public string MarcATPKZ { get; set; }

        /// <summary>
        /// 描述 :分割标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "分割标识")]
        [ExcelColumn(Name = "分割标识")]
        public string MarcAUFTL { get; set; }

        /// <summary>
        /// 描述 :中断日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "中断日期")]
        [ExcelColumn(Name = "中断日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcAUSDT { get; set; }

        /// <summary>
        /// 描述 :发货单位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "发货单位")]
        [ExcelColumn(Name = "发货单位")]
        public string MarcAUSME { get; set; }

        /// <summary>
        /// 描述 :装配报废 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "装配报废", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "装配报废")]
        public decimal MarcAUSSS { get; set; }

        /// <summary>
        /// 描述 :自动重置 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自动重置")]
        [ExcelColumn(Name = "自动重置")]
        public string MarcAUTRU { get; set; }

        /// <summary>
        /// 描述 :差异码  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "差异码 ")]
        [ExcelColumn(Name = "差异码 ")]
        public string MarcAWSLS { get; set; }

        /// <summary>
        /// 描述 :基准数量 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "基准数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "基准数量")]
        public decimal MarcBASMG { get; set; }

        /// <summary>
        /// 描述 :处理时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "处理时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "处理时间")]
        public decimal MarcBEARZ { get; set; }

        /// <summary>
        /// 描述 :采购 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "采购", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "采购")]
        public string MarcBESKZ { get; set; }

        /// <summary>
        /// 描述 :固定批量大小 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "固定批量大小", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "固定批量大小")]
        public decimal MarcBSTFE { get; set; }

        /// <summary>
        /// 描述 :最大批量  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "最大批量 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最大批量 ")]
        public decimal MarcBSTMA { get; set; }

        /// <summary>
        /// 描述 :最小批量大小  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "最小批量大小 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最小批量大小 ")]
        public decimal MarcBSTMI { get; set; }

        /// <summary>
        /// 描述 :舍入值  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "舍入值 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "舍入值 ")]
        public decimal MarcBSTRF { get; set; }

        /// <summary>
        /// 描述 :评估收货锁定库存 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "评估收货锁定库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "评估收货锁定库存")]
        public decimal MarcBWESB { get; set; }

        /// <summary>
        /// 描述 :货源 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "货源")]
        [ExcelColumn(Name = "货源")]
        public string MarcBWSCL { get; set; }

        /// <summary>
        /// 描述 :评估类别 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "评估类别")]
        [ExcelColumn(Name = "评估类别")]
        public string MarcBWTTY { get; set; }

        /// <summary>
        /// 描述 :CAS 号（药品）  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "CAS 号（药品） ")]
        [ExcelColumn(Name = "CAS 号（药品） ")]
        public string MarcCASNR { get; set; }

        /// <summary>
        /// 描述 :周期标识被固定 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "周期标识被固定")]
        [ExcelColumn(Name = "周期标识被固定")]
        public string MarcCCFIX { get; set; }

        /// <summary>
        /// 描述 :该字段不再使用 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "该字段不再使用")]
        [ExcelColumn(Name = "该字段不再使用")]
        public string MarcCOMPL { get; set; }

        /// <summary>
        /// 描述 :寄售控制 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcCONS_PROCG",ColumnDescription = "寄售控制")]
        [ExcelColumn(Name = "寄售控制")]
        public string MarcconsProcg { get; set; }

        /// <summary>
        /// 描述 :转换类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "转换类型")]
        [ExcelColumn(Name = "转换类型")]
        public string MarcCONVT { get; set; }

        /// <summary>
        /// 描述 :字段名  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "字段名 ")]
        [ExcelColumn(Name = "字段名 ")]
        public string MarcCOPAM { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "内部对象号 ")]
        [ExcelColumn(Name = "内部对象号 ")]
        public string MarcCUOBJ { get; set; }

        /// <summary>
        /// 描述 :内部对象号  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "内部对象号 ")]
        [ExcelColumn(Name = "内部对象号 ")]
        public string MarcCUOBV { get; set; }

        /// <summary>
        /// 描述 :MRP  范围存在 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP  范围存在")]
        [ExcelColumn(Name = "MRP  范围存在")]
        public string MarcDIBER { get; set; }

        /// <summary>
        /// 描述 :MRP组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP组 ")]
        [ExcelColumn(Name = "MRP组 ")]
        public string MarcDISGR { get; set; }

        /// <summary>
        /// 描述 :批量大小 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "批量大小", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "批量大小")]
        public string MarcDISLS { get; set; }

        /// <summary>
        /// 描述 :MRP 类型 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "MRP 类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "MRP 类型")]
        public string MarcDISMM { get; set; }

        /// <summary>
        /// 描述 :MRP 控制者  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP 控制者 ")]
        [ExcelColumn(Name = "MRP 控制者 ")]
        public string MarcDISPO { get; set; }

        /// <summary>
        /// 描述 :MRP 参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP 参数文件")]
        [ExcelColumn(Name = "MRP 参数文件")]
        public string MarcDISPR { get; set; }

        /// <summary>
        /// 描述 :公平分享规则 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "公平分享规则")]
        [ExcelColumn(Name = "公平分享规则")]
        public string MarcDPLFS { get; set; }

        /// <summary>
        /// 描述 :发布界限 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "发布界限", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "发布界限")]
        public decimal MarcDPLHO { get; set; }

        /// <summary>
        /// 描述 :推式分配 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "推式分配")]
        [ExcelColumn(Name = "推式分配")]
        public string MarcDPLPU { get; set; }

        /// <summary>
        /// 描述 :厂内生产时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "厂内生产时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "厂内生产时间")]
        public decimal MarcDZEIT { get; set; }

        /// <summary>
        /// 描述 :安全库存 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "安全库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "安全库存")]
        public decimal MarcEISBE { get; set; }

        /// <summary>
        /// 描述 :最小安全库存  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "最小安全库存 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最小安全库存 ")]
        public decimal MarcEISLO { get; set; }

        /// <summary>
        /// 描述 :采购组  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "采购组 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "采购组 ")]
        public string MarcEKGRP { get; set; }

        /// <summary>
        /// 描述 :库存确定组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "库存确定组 ")]
        [ExcelColumn(Name = "库存确定组 ")]
        public string MarcEPRIO { get; set; }

        /// <summary>
        /// 描述 :商品代码单位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "商品代码单位")]
        [ExcelColumn(Name = "商品代码单位")]
        public string MarcEXPME { get; set; }

        /// <summary>
        /// 描述 :JIT 标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "JIT 标识")]
        [ExcelColumn(Name = "JIT 标识")]
        public string MarcFABKZ { get; set; }

        /// <summary>
        /// 描述 :生产管理员  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产管理员 ")]
        [ExcelColumn(Name = "生产管理员 ")]
        public string MarcFEVOR { get; set; }

        /// <summary>
        /// 描述 :自动批准 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自动批准")]
        [ExcelColumn(Name = "自动批准")]
        public string MarcFFREI { get; set; }

        /// <summary>
        /// 描述 :计划边际码  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划边际码 ")]
        [ExcelColumn(Name = "计划边际码 ")]
        public string MarcFHORI { get; set; }

        /// <summary>
        /// 描述 :固定批量大小 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "固定批量大小", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "固定批量大小")]
        public decimal MarcFIXLS { get; set; }

        /// <summary>
        /// 描述 :分配 prof. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "分配 prof.")]
        [ExcelColumn(Name = "分配 prof.")]
        public string MarcFPRFM { get; set; }

        /// <summary>
        /// 描述 :生产单位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产单位")]
        [ExcelColumn(Name = "生产单位")]
        public string MarcFRTME { get; set; }

        /// <summary>
        /// 描述 :订单分配运行 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcFSH_MG_ARUN_REQ",ColumnDescription = "订单分配运行")]
        [ExcelColumn(Name = "订单分配运行")]
        public string MarcfshMgArunReq { get; set; }

        /// <summary>
        /// 描述 :库存管理中激活季节 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcFSH_SEAIM",ColumnDescription = "库存管理中激活季节")]
        [ExcelColumn(Name = "库存管理中激活季节")]
        public string MarcfshSeaim { get; set; }

        /// <summary>
        /// 描述 :生产版本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产版本")]
        [ExcelColumn(Name = "生产版本")]
        public string MarcFVIDK { get; set; }

        /// <summary>
        /// 描述 :计划的时界  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划的时界 ")]
        [ExcelColumn(Name = "计划的时界 ")]
        public string MarcFXHOR { get; set; }

        /// <summary>
        /// 描述 :固定价格联产品 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "固定价格联产品")]
        [ExcelColumn(Name = "固定价格联产品")]
        public string MarcFXPRU { get; set; }

        /// <summary>
        /// 描述 :发货处理时间 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "marcGI_PR_TIME",ColumnDescription = "发货处理时间")]
        [ExcelColumn(Name = "发货处理时间")]
        public decimal MarcgiPrTime { get; set; }

        /// <summary>
        /// 描述 :有约束的虚拟 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "有约束的虚拟", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "有约束的虚拟")]
        public decimal MarcGLGMG { get; set; }

        /// <summary>
        /// 描述 :粗略计划 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "粗略计划")]
        [ExcelColumn(Name = "粗略计划")]
        public string MarcGPMKZ { get; set; }

        /// <summary>
        /// 描述 :PRODCOM号  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "PRODCOM号 ")]
        [ExcelColumn(Name = "PRODCOM号 ")]
        public string MarcGPNUM { get; set; }

        /// <summary>
        /// 描述 :生产状态  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产状态 ")]
        [ExcelColumn(Name = "生产状态 ")]
        public string MarcHERBL { get; set; }

        /// <summary>
        /// 描述 :原产地国 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "原产地国")]
        [ExcelColumn(Name = "原产地国")]
        public string MarcHERKL { get; set; }

        /// <summary>
        /// 描述 :货源地  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "货源地 ")]
        [ExcelColumn(Name = "货源地 ")]
        public string MarcHERKR { get; set; }

        /// <summary>
        /// 描述 :物料类别 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料类别")]
        [ExcelColumn(Name = "物料类别")]
        public string MarcINDUS { get; set; }

        /// <summary>
        /// 描述 :过帐到检验库存 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "过帐到检验库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "过帐到检验库存")]
        public string MarcINSMK { get; set; }

        /// <summary>
        /// 描述 :军用物资 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "军用物资")]
        [ExcelColumn(Name = "军用物资")]
        public string MarcITARK { get; set; }

        /// <summary>
        /// 描述 :IUID 相关 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcIUID_RELEVANT",ColumnDescription = "IUID 相关")]
        [ExcelColumn(Name = "IUID 相关")]
        public string MarciuidRelevant { get; set; }

        /// <summary>
        /// 描述 :IUID 类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcIUID_TYPE",ColumnDescription = "IUID 类型")]
        [ExcelColumn(Name = "IUID 类型")]
        public string MarciuidType { get; set; }

        /// <summary>
        /// 描述 :组件报废 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "组件报废", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "组件报废")]
        public decimal MarcKAUSF { get; set; }

        /// <summary>
        /// 描述 :自动采购单  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自动采购单 ")]
        [ExcelColumn(Name = "自动采购单 ")]
        public string MarcKAUTB { get; set; }

        /// <summary>
        /// 描述 :源清单  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "源清单 ")]
        [ExcelColumn(Name = "源清单 ")]
        public string MarcKORDB { get; set; }

        /// <summary>
        /// 描述 :平滑促销消耗  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "平滑促销消耗 ")]
        [ExcelColumn(Name = "平滑促销消耗 ")]
        public string MarcKZAGL { get; set; }

        /// <summary>
        /// 描述 :非连续标识  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "非连续标识 ")]
        [ExcelColumn(Name = "非连续标识 ")]
        public string MarcKZAUS { get; set; }

        /// <summary>
        /// 描述 :需求分组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "需求分组 ")]
        [ExcelColumn(Name = "需求分组 ")]
        public string MarcKZBED { get; set; }

        /// <summary>
        /// 描述 :MRP控制者=买者  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "MRP控制者=买者 ")]
        [ExcelColumn(Name = "MRP控制者=买者 ")]
        public string MarcKZDIE { get; set; }

        /// <summary>
        /// 描述 :凭证需求  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "凭证需求 ")]
        [ExcelColumn(Name = "凭证需求 ")]
        public string MarcKZDKZ { get; set; }

        /// <summary>
        /// 描述 :输入批量 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "输入批量")]
        [ExcelColumn(Name = "输入批量")]
        public string MarcKZECH { get; set; }

        /// <summary>
        /// 描述 :修正因子 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "修正因子")]
        [ExcelColumn(Name = "修正因子")]
        public string MarcKZKFK { get; set; }

        /// <summary>
        /// 描述 :关键组件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "关键组件")]
        [ExcelColumn(Name = "关键组件")]
        public string MarcKZKRI { get; set; }

        /// <summary>
        /// 描述 :联产品  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "联产品 ")]
        [ExcelColumn(Name = "联产品 ")]
        public string MarcKZKUP { get; set; }

        /// <summary>
        /// 描述 :检查计划标识  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检查计划标识 ")]
        [ExcelColumn(Name = "检查计划标识 ")]
        public string MarcKZPPV { get; set; }

        /// <summary>
        /// 描述 :从产品货位提取 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "从产品货位提取")]
        [ExcelColumn(Name = "从产品货位提取")]
        public string MarcKZPRO { get; set; }

        /// <summary>
        /// 描述 :跨项目  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "跨项目 ")]
        [ExcelColumn(Name = "跨项目 ")]
        public string MarcKZPSP { get; set; }

        /// <summary>
        /// 描述 :装载组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "装载组 ")]
        [ExcelColumn(Name = "装载组 ")]
        public string MarcLADGR { get; set; }

        /// <summary>
        /// 描述 :库存成本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "库存成本")]
        [ExcelColumn(Name = "库存成本")]
        public string MarcLAGPR { get; set; }

        /// <summary>
        /// 描述 :年  当前期间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "年  当前期间")]
        [ExcelColumn(Name = "年  当前期间")]
        public string MarcLFGJA { get; set; }

        /// <summary>
        /// 描述 :本期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "本期")]
        [ExcelColumn(Name = "本期")]
        public string MarcLFMON { get; set; }

        /// <summary>
        /// 描述 :计划周期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划周期")]
        [ExcelColumn(Name = "计划周期")]
        public string MarcLFRHY { get; set; }

        /// <summary>
        /// 描述 :外部采购仓储地 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "外部采购仓储地", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "外部采购仓储地")]
        public string MarcLGFSB { get; set; }

        /// <summary>
        /// 描述 :生产仓储地点 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "生产仓储地点", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产仓储地点")]
        public string MarcLGPRO { get; set; }

        /// <summary>
        /// 描述 :服务水平 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "服务水平", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "服务水平")]
        public decimal MarcLGRAD { get; set; }

        /// <summary>
        /// 描述 :取消激活的 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "取消激活的")]
        [ExcelColumn(Name = "取消激活的")]
        public string MarcLIZYK { get; set; }

        /// <summary>
        /// 描述 :后勤组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "后勤组 ")]
        [ExcelColumn(Name = "后勤组 ")]
        public string MarcLOGGR { get; set; }

        /// <summary>
        /// 描述 :订购成本 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "订购成本", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "订购成本")]
        public decimal MarcLOSFX { get; set; }

        /// <summary>
        /// 描述 :成本核算批量 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "成本核算批量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "成本核算批量")]
        public decimal MarcLOSGR { get; set; }

        /// <summary>
        /// 描述 :批尺寸增加  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "批尺寸增加 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "批尺寸增加 ")]
        public decimal MarcLTINC { get; set; }

        /// <summary>
        /// 描述 :工厂级 DF 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "工厂级 DF")]
        [ExcelColumn(Name = "工厂级 DF")]
        public string MarcLVORM { get; set; }

        /// <summary>
        /// 描述 :时间单位 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "时间单位")]
        [ExcelColumn(Name = "时间单位")]
        public string MarcLZEIH { get; set; }

        /// <summary>
        /// 描述 :ABC 标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "ABC 标识")]
        [ExcelColumn(Name = "ABC 标识")]
        public string MarcMAABC { get; set; }

        /// <summary>
        /// 描述 :最大库存水平  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "最大库存水平 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最大库存水平 ")]
        public decimal MarcMABST { get; set; }

        /// <summary>
        /// 描述 :集团 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "集团", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "集团")]
        public string MarcMANDT { get; set; }

        /// <summary>
        /// 描述 :物料分组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料分组")]
        [ExcelColumn(Name = "物料分组")]
        public string MarcMATGR { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]
        public string MarcMATNR { get; set; }

        /// <summary>
        /// 描述 :最大目标范围  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcMAX_TROC",ColumnDescription = "最大目标范围 ")]
        [ExcelColumn(Name = "最大目标范围 ")]
        public string MarcmaxTroc { get; set; }

        /// <summary>
        /// 描述 :最大批量大小  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "最大批量大小 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最大批量大小 ")]
        public decimal MarcMAXLS { get; set; }

        /// <summary>
        /// 描述 :最大存储期间  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "最大存储期间 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最大存储期间 ")]
        public decimal MarcMAXLZ { get; set; }

        /// <summary>
        /// 描述 :最后的MARD 期间之前，MARDH 记 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "最后的MARD 期间之前，MARDH 记")]
        [ExcelColumn(Name = "最后的MARD 期间之前，MARDH 记")]
        public string MarcMCRUE { get; set; }

        /// <summary>
        /// 描述 :活动控制 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "活动控制")]
        [ExcelColumn(Name = "活动控制")]
        public string MarcMDACH { get; set; }

        /// <summary>
        /// 描述 :计量单位组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计量单位组 ")]
        [ExcelColumn(Name = "计量单位组 ")]
        public string MarcMEGRU { get; set; }

        /// <summary>
        /// 描述 :物料运输组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料运输组 ")]
        [ExcelColumn(Name = "物料运输组 ")]
        public string MarcMFRGR { get; set; }

        /// <summary>
        /// 描述 :最小目标范围  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcMIN_TROC",ColumnDescription = "最小目标范围 ")]
        [ExcelColumn(Name = "最小目标范围 ")]
        public string MarcminTroc { get; set; }

        /// <summary>
        /// 描述 :再订货点 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "再订货点", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "再订货点")]
        public decimal MarcMINBE { get; set; }

        /// <summary>
        /// 描述 :最小批量大小  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "最小批量大小 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "最小批量大小 ")]
        public decimal MarcMINLS { get; set; }

        /// <summary>
        /// 描述 :综合MRP 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "综合MRP")]
        [ExcelColumn(Name = "综合MRP")]
        public string MarcMISKZ { get; set; }

        /// <summary>
        /// 描述 :P-S 物料状态  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "P-S 物料状态 ")]
        [ExcelColumn(Name = "P-S 物料状态 ")]
        public string MarcMMSTA { get; set; }

        /// <summary>
        /// 描述 :有效起始期  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "有效起始期 ")]
        [ExcelColumn(Name = "有效起始期 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcMMSTD { get; set; }

        /// <summary>
        /// 描述 :CAP 产品组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "CAP 产品组 ")]
        [ExcelColumn(Name = "CAP 产品组 ")]
        public string MarcMOGRU { get; set; }

        /// <summary>
        /// 描述 :EU 产品清单编号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "EU 产品清单编号")]
        [ExcelColumn(Name = "EU 产品清单编号")]
        public string MarcMOWNR { get; set; }

        /// <summary>
        /// 描述 :平均检查持续期 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "平均检查持续期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "平均检查持续期")]
        public decimal MarcMPDAU { get; set; }

        /// <summary>
        /// 描述 :计划日历 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划日历")]
        [ExcelColumn(Name = "计划日历")]
        public string MarcMRPPP { get; set; }

        /// <summary>
        /// 描述 :出口/进口组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "出口/进口组 ")]
        [ExcelColumn(Name = "出口/进口组 ")]
        public string MarcMTVER { get; set; }

        /// <summary>
        /// 描述 :可用性检查  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "可用性检查 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "可用性检查 ")]
        public string MarcMTVFP { get; set; }

        /// <summary>
        /// 描述 :交叉的采购组 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcMULTIPLE_EKGRP",ColumnDescription = "交叉的采购组")]
        [ExcelColumn(Name = "交叉的采购组")]
        public string MarcmultipleEkgrp { get; set; }

        /// <summary>
        /// 描述 :无成本核算  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "无成本核算 ")]
        [ExcelColumn(Name = "无成本核算 ")]
        public string MarcNCOST { get; set; }

        /// <summary>
        /// 描述 :后继物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "后继物料")]
        [ExcelColumn(Name = "后继物料")]
        public string MarcNFMAT { get; set; }

        /// <summary>
        /// 描述 :下一次检查  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "下一次检查 ")]
        [ExcelColumn(Name = "下一次检查 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcNKMPR { get; set; }

        /// <summary>
        /// 描述 :对象标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "对象标识")]
        [ExcelColumn(Name = "对象标识")]
        public string MarcOBJID { get; set; }

        /// <summary>
        /// 描述 :总体参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "总体参数文件")]
        [ExcelColumn(Name = "总体参数文件")]
        public string MarcOCMPF { get; set; }

        /// <summary>
        /// 描述 :对象类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "对象类型")]
        [ExcelColumn(Name = "对象类型")]
        public string MarcOTYPE { get; set; }

        /// <summary>
        /// 描述 :会计年度变式 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "会计年度变式")]
        [ExcelColumn(Name = "会计年度变式")]
        public string MarcPERIV { get; set; }

        /// <summary>
        /// 描述 :期间标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "期间标识")]
        [ExcelColumn(Name = "期间标识")]
        public string MarcPERKZ { get; set; }

        /// <summary>
        /// 描述 :自动更改工厂订单 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自动更改工厂订单")]
        [ExcelColumn(Name = "自动更改工厂订单")]
        public string MarcPFREI { get; set; }

        /// <summary>
        /// 描述 :计划交货时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "计划交货时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "计划交货时间")]
        public decimal MarcPLIFZ { get; set; }

        /// <summary>
        /// 描述 :组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "组 ")]
        [ExcelColumn(Name = "组 ")]
        public string MarcPLNNR { get; set; }

        /// <summary>
        /// 描述 :任务清单类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "任务清单类型")]
        [ExcelColumn(Name = "任务清单类型")]
        public string MarcPLNTY { get; set; }

        /// <summary>
        /// 描述 :计划版本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计划版本")]
        [ExcelColumn(Name = "计划版本")]
        public string MarcPLVAR { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "利润中心", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "利润中心")]
        public string MarcPRCTR { get; set; }

        /// <summary>
        /// 描述 :优先权  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "优先权 ")]
        [ExcelColumn(Name = "优先权 ")]
        public string MarcPREFE { get; set; }

        /// <summary>
        /// 描述 :免税证书 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "免税证书")]
        [ExcelColumn(Name = "免税证书")]
        public string MarcPRENC { get; set; }

        /// <summary>
        /// 描述 :发放证书日  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "发放证书日 ")]
        [ExcelColumn(Name = "发放证书日 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcPREND { get; set; }

        /// <summary>
        /// 描述 :供应商申报  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "供应商申报 ")]
        [ExcelColumn(Name = "供应商申报 ")]
        public string MarcPRENE { get; set; }

        /// <summary>
        /// 描述 :供应商申报日期 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "供应商申报日期")]
        [ExcelColumn(Name = "供应商申报日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcPRENG { get; set; }

        /// <summary>
        /// 描述 :免税证书编号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "免税证书编号")]
        [ExcelColumn(Name = "免税证书编号")]
        public string MarcPRENO { get; set; }

        /// <summary>
        /// 描述 :检查间隔  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "检查间隔 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "检查间隔 ")]
        public decimal MarcPRFRQ { get; set; }

        /// <summary>
        /// 描述 :维护状态  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "维护状态 ")]
        [ExcelColumn(Name = "维护状态 ")]
        public string MarcPSTAT { get; set; }

        /// <summary>
        /// 描述 :QM 物料授权 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "QM 物料授权")]
        [ExcelColumn(Name = "QM 物料授权")]
        public string MarcQMATA { get; set; }

        /// <summary>
        /// 描述 :检验设置  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "检验设置 ")]
        [ExcelColumn(Name = "检验设置 ")]
        public string MarcQMATV { get; set; }

        /// <summary>
        /// 描述 :目标 QM 系统 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "目标 QM 系统")]
        [ExcelColumn(Name = "目标 QM 系统")]
        public string MarcQSSYS { get; set; }

        /// <summary>
        /// 描述 :隔离 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "隔离", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "隔离")]
        public decimal MarcQUAZT { get; set; }

        /// <summary>
        /// 描述 :证书类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "证书类型")]
        [ExcelColumn(Name = "证书类型")]
        public string MarcQZGTP { get; set; }

        /// <summary>
        /// 描述 :舍入参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "舍入参数文件")]
        [ExcelColumn(Name = "舍入参数文件")]
        public string MarcRDPRF { get; set; }

        /// <summary>
        /// 描述 :确定方案 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcREF_SCHEMA",ColumnDescription = "确定方案")]
        [ExcelColumn(Name = "确定方案")]
        public string MarcrefSchema { get; set; }

        /// <summary>
        /// 描述 :调整期间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "调整期间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "调整期间")]
        public decimal MarcRESVP { get; set; }

        /// <summary>
        /// 描述 :反冲 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "反冲")]
        [ExcelColumn(Name = "反冲")]
        public string MarcRGEKZ { get; set; }

        /// <summary>
        /// 描述 :库存入库/出库 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcROTATION_DATE",ColumnDescription = "库存入库/出库")]
        [ExcelColumn(Name = "库存入库/出库")]
        public string MarcrotationDate { get; set; }

        /// <summary>
        /// 描述 :准备时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "准备时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "准备时间")]
        public decimal MarcRUEZT { get; set; }

        /// <summary>
        /// 描述 :供货天数参文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "供货天数参文件")]
        [ExcelColumn(Name = "供货天数参文件")]
        public string MarcRWPRO { get; set; }

        /// <summary>
        /// 描述 :重复生产 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "重复生产")]
        [ExcelColumn(Name = "重复生产")]
        public string MarcSAUFT { get; set; }

        /// <summary>
        /// 描述 :独立/集中 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "独立/集中")]
        [ExcelColumn(Name = "独立/集中")]
        public string MarcSBDKZ { get; set; }

        /// <summary>
        /// 描述 :散装物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "散装物料")]
        [ExcelColumn(Name = "散装物料")]
        public string MarcSCHGT { get; set; }

        /// <summary>
        /// 描述 :序列号参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "序列号参数文件")]
        [ExcelColumn(Name = "序列号参数文件")]
        public string MarcSERNP { get; set; }

        /// <summary>
        /// 描述 :服务水平 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "服务水平")]
        [ExcelColumn(Name = "服务水平")]
        public string MarcSERVG { get; set; }

        /// <summary>
        /// 描述 :生产参数文  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产参数文 ")]
        [ExcelColumn(Name = "生产参数文 ")]
        public string MarcSFCPF { get; set; }

        /// <summary>
        /// 描述 :REM 参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "REM 参数文件")]
        [ExcelColumn(Name = "REM 参数文件")]
        public string MarcSFEPR { get; set; }

        /// <summary>
        /// 描述 :离散批次编号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_CHINT",ColumnDescription = "离散批次编号")]
        [ExcelColumn(Name = "离散批次编号")]
        public string MarcsgtChint { get; set; }

        /// <summary>
        /// 描述 :分段策略 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_COVS",ColumnDescription = "分段策略")]
        [ExcelColumn(Name = "分段策略")]
        public string MarcsgtCovs { get; set; }

        /// <summary>
        /// 描述 :库存排序方法 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_MRPSI",ColumnDescription = "库存排序方法")]
        [ExcelColumn(Name = "库存排序方法")]
        public string MarcsgtMrpsi { get; set; }

        /// <summary>
        /// 描述 :消耗优先级 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_PRCM",ColumnDescription = "消耗优先级")]
        [ExcelColumn(Name = "消耗优先级")]
        public string MarcsgtPrcm { get; set; }

        /// <summary>
        /// 描述 :分段范围 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_SCOPE",ColumnDescription = "分段范围")]
        [ExcelColumn(Name = "分段范围")]
        public string MarcsgtScope { get; set; }

        /// <summary>
        /// 描述 :分段状态 MRP 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_STATC",ColumnDescription = "分段状态 MRP")]
        [ExcelColumn(Name = "分段状态 MRP")]
        public string MarcsgtStatc { get; set; }

        /// <summary>
        /// 描述 :库存保护 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcSGT_STK_PRT",ColumnDescription = "库存保护")]
        [ExcelColumn(Name = "库存保护")]
        public string MarcsgtStkPrt { get; set; }

        /// <summary>
        /// 描述 :安全时间标识 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "安全时间标识")]
        [ExcelColumn(Name = "安全时间标识")]
        public string MarcSHFLG { get; set; }

        /// <summary>
        /// 描述 :ST 期间参数文件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "ST 期间参数文件")]
        [ExcelColumn(Name = "ST 期间参数文件")]
        public string MarcSHPRO { get; set; }

        /// <summary>
        /// 描述 :安全时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "安全时间")]
        [ExcelColumn(Name = "安全时间")]
        public string MarcSHZET { get; set; }

        /// <summary>
        /// 描述 :特殊工艺类型 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "特殊工艺类型")]
        [ExcelColumn(Name = "特殊工艺类型")]
        public string MarcSOBSK { get; set; }

        /// <summary>
        /// 描述 :特殊采购 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "特殊采购", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "特殊采购")]
        public string MarcSOBSL { get; set; }

        /// <summary>
        /// 描述 :样本% 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "样本%", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "样本%")]
        public decimal MarcSPROZ { get; set; }

        /// <summary>
        /// 描述 :QM 控制码  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "QM 控制码 ")]
        [ExcelColumn(Name = "QM 控制码 ")]
        public string MarcSSQSS { get; set; }

        /// <summary>
        /// 描述 :Comm./imp. code 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "Comm./imp. code")]
        [ExcelColumn(Name = "Comm./imp. code")]
        public string MarcSTAWN { get; set; }

        /// <summary>
        /// 描述 :可配置的物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "可配置的物料")]
        [ExcelColumn(Name = "可配置的物料")]
        public string MarcSTDPD { get; set; }

        /// <summary>
        /// 描述 :控制代码 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "控制代码")]
        [ExcelColumn(Name = "控制代码")]
        public string MarcSTEUC { get; set; }

        /// <summary>
        /// 描述 :备选  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备选 ")]
        [ExcelColumn(Name = "备选 ")]
        public string MarcSTLAL { get; set; }

        /// <summary>
        /// 描述 :用途  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "用途 ")]
        [ExcelColumn(Name = "用途 ")]
        public string MarcSTLAN { get; set; }

        /// <summary>
        /// 描述 :策略组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "策略组 ")]
        [ExcelColumn(Name = "策略组 ")]
        public string MarcSTRGR { get; set; }

        /// <summary>
        /// 描述 :间隔时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "间隔时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "间隔时间")]
        public decimal MarcTAKZT { get; set; }

        /// <summary>
        /// 描述 :目标库存 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "marcTARGET_STOCK",ColumnDescription = "目标库存")]
        [ExcelColumn(Name = "目标库存")]
        public decimal MarctargetStock { get; set; }

        /// <summary>
        /// 描述 :在途库存  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "在途库存 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "在途库存 ")]
        public decimal MarcTRAME { get; set; }

        /// <summary>
        /// 描述 :工序间  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "工序间 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工序间 ")]
        public decimal MarcTRANZ { get; set; }

        /// <summary>
        /// 描述 :OB管理 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "OB管理")]
        [ExcelColumn(Name = "OB管理")]
        public string MarcUCHKZ { get; set; }

        /// <summary>
        /// 描述 :OB参考物料  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "OB参考物料 ")]
        [ExcelColumn(Name = "OB参考物料 ")]
        public string MarcUCMAT { get; set; }

        /// <summary>
        /// 描述 :无限的  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "无限的 ")]
        [ExcelColumn(Name = "无限的 ")]
        public string MarcUEETK { get; set; }

        /// <summary>
        /// 描述 :过度交货允差 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "过度交货允差", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "过度交货允差")]
        public decimal MarcUEETO { get; set; }

        /// <summary>
        /// 描述 :外部分配 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "marcUID_IEA",ColumnDescription = "外部分配")]
        [ExcelColumn(Name = "外部分配")]
        public string MarcuidIea { get; set; }

        /// <summary>
        /// 描述 :中转库存 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "中转库存", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "中转库存")]
        public decimal MarcUMLMC { get; set; }

        /// <summary>
        /// 描述 :转换组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "转换组 ")]
        [ExcelColumn(Name = "转换组 ")]
        public string MarcUMRSL { get; set; }

        /// <summary>
        /// 描述 :不足交货允差 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "不足交货允差", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "不足交货允差")]
        public decimal MarcUNETO { get; set; }

        /// <summary>
        /// 描述 :计量单位组  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "计量单位组 ")]
        [ExcelColumn(Name = "计量单位组 ")]
        public string MarcUOMGR { get; set; }

        /// <summary>
        /// 描述 :配额使用安排 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "配额使用安排")]
        [ExcelColumn(Name = "配额使用安排")]
        public string MarcUSEQU { get; set; }

        /// <summary>
        /// 描述 :基准数量 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "基准数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "基准数量")]
        public decimal MarcVBAMG { get; set; }

        /// <summary>
        /// 描述 :处理时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "处理时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "处理时间")]
        public decimal MarcVBEAZ { get; set; }

        /// <summary>
        /// 描述 :版本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "版本")]
        [ExcelColumn(Name = "版本")]
        public string MarcVERKZ { get; set; }

        /// <summary>
        /// 描述 :逆向消耗期间  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "逆向消耗期间 ")]
        [ExcelColumn(Name = "逆向消耗期间 ")]
        public string MarcVINT1 { get; set; }

        /// <summary>
        /// 描述 :向前消耗期间  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "向前消耗期间 ")]
        [ExcelColumn(Name = "向前消耗期间 ")]
        public string MarcVINT2 { get; set; }

        /// <summary>
        /// 描述 :SlsVal.TiedEmpt 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "SlsVal.TiedEmpt", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "SlsVal.TiedEmpt")]
        public decimal MarcVKGLG { get; set; }

        /// <summary>
        /// 描述 :运输库存/SP 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "运输库存/SP", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "运输库存/SP")]
        public decimal MarcVKTRW { get; set; }

        /// <summary>
        /// 描述 :库存转移 SV 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "库存转移 SV", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "库存转移 SV")]
        public decimal MarcVKUMC { get; set; }

        /// <summary>
        /// 描述 :日期到  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "日期到 ")]
        [ExcelColumn(Name = "日期到 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcVRBDT { get; set; }

        /// <summary>
        /// 描述 :乘数 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "乘数", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "乘数")]
        public decimal MarcVRBFK { get; set; }

        /// <summary>
        /// 描述 :参考物料:消耗  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "参考物料:消耗 ")]
        [ExcelColumn(Name = "参考物料:消耗 ")]
        public string MarcVRBMT { get; set; }

        /// <summary>
        /// 描述 :参考工厂：寄存 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "参考工厂：寄存")]
        [ExcelColumn(Name = "参考工厂：寄存")]
        public string MarcVRBWK { get; set; }

        /// <summary>
        /// 描述 :消耗模式  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "消耗模式 ")]
        [ExcelColumn(Name = "消耗模式 ")]
        public string MarcVRMOD { get; set; }

        /// <summary>
        /// 描述 :准备时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "准备时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "准备时间")]
        public decimal MarcVRVEZ { get; set; }

        /// <summary>
        /// 描述 :提议供应区域 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "提议供应区域")]
        [ExcelColumn(Name = "提议供应区域")]
        public string MarcVSPVB { get; set; }

        /// <summary>
        /// 描述 :附加费 % 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "附加费 %", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "附加费 %")]
        public decimal MarcVZUSL { get; set; }

        /// <summary>
        /// 描述 :收货处理时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "收货处理时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "收货处理时间")]
        public decimal MarcWEBAZ { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "工厂", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工厂")]
        public string MarcWERKS { get; set; }

        /// <summary>
        /// 描述 :活动性物质  
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "活动性物质 ", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "活动性物质 ")]
        public decimal MarcWSTGH { get; set; }

        /// <summary>
        /// 描述 :总补货提前时间 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "总补货提前时间", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "总补货提前时间")]
        public decimal MarcWZEIT { get; set; }

        /// <summary>
        /// 描述 :批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "批次")]
        [ExcelColumn(Name = "批次")]
        public string MarcXCHAR { get; set; }

        /// <summary>
        /// 描述 :批次管理需求  
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "批次管理需求 ")]
        [ExcelColumn(Name = "批次管理需求 ")]
        public string MarcXCHPF { get; set; }

        /// <summary>
        /// 描述 :负的库存 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "负的库存")]
        [ExcelColumn(Name = "负的库存")]
        public string MarcXMCNG { get; set; }

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
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "软删除", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "软删除")]
        public int IsDeleted { get; set; }

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