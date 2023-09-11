using System.ComponentModel.DataAnnotations;
using MiniExcelLibs.Attributes;

namespace Lps.Model.Dto
{
    /// <summary>
    /// 工厂物料数据
    /// 查询对象
    /// @author Lean365
    /// @date 2023-09-11
    /// </summary>
    public class MmMarcQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 工厂物料数据输入输出对象
    /// </summary>
    public class MmMarcDto
    {
        [Required(ErrorMessage = "ID主键不能为空")]
        [ExcelColumn(Name = "ID主键")]
        public Guid MarcGuid { get; set; }

        [ExcelColumn(Name = "CC 库存盘点")]
        public string MarcABCIN { get; set; }

        [Required(ErrorMessage = "空气浮力因子不能为空")]
        [ExcelColumn(Name = "空气浮力因子")]
        public decimal MarcABFAC { get; set; }

        [ExcelColumn(Name = "MRP 相关需求 ")]
        public string MarcAHDIS { get; set; }

        [ExcelColumn(Name = "选择方法")]
        public string MarcALTSL { get; set; }

        [ExcelColumn(Name = "组计数器")]
        public string MarcAPLAL { get; set; }

        [ExcelColumn(Name = "相关于 APO")]
        public string MarcAPOKZ { get; set; }

        [ExcelColumn(Name = "替换部件")]
        public string MarcATPKZ { get; set; }

        [ExcelColumn(Name = "分割标识")]
        public string MarcAUFTL { get; set; }

        [ExcelColumn(Name = "中断日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcAUSDT { get; set; }

        [ExcelColumn(Name = "发货单位")]
        public string MarcAUSME { get; set; }

        [Required(ErrorMessage = "装配报废不能为空")]
        [ExcelColumn(Name = "装配报废")]
        public decimal MarcAUSSS { get; set; }

        [ExcelColumn(Name = "自动重置")]
        public string MarcAUTRU { get; set; }

        [ExcelColumn(Name = "差异码 ")]
        public string MarcAWSLS { get; set; }

        [Required(ErrorMessage = "基准数量不能为空")]
        [ExcelColumn(Name = "基准数量")]
        public decimal MarcBASMG { get; set; }

        [Required(ErrorMessage = "处理时间不能为空")]
        [ExcelColumn(Name = "处理时间")]
        public decimal MarcBEARZ { get; set; }

        [Required(ErrorMessage = "采购不能为空")]
        [ExcelColumn(Name = "采购")]
        public string MarcBESKZ { get; set; }

        [Required(ErrorMessage = "固定批量大小不能为空")]
        [ExcelColumn(Name = "固定批量大小")]
        public decimal MarcBSTFE { get; set; }

        [Required(ErrorMessage = "最大批量 不能为空")]
        [ExcelColumn(Name = "最大批量 ")]
        public decimal MarcBSTMA { get; set; }

        [Required(ErrorMessage = "最小批量大小 不能为空")]
        [ExcelColumn(Name = "最小批量大小 ")]
        public decimal MarcBSTMI { get; set; }

        [Required(ErrorMessage = "舍入值 不能为空")]
        [ExcelColumn(Name = "舍入值 ")]
        public decimal MarcBSTRF { get; set; }

        [Required(ErrorMessage = "评估收货锁定库存不能为空")]
        [ExcelColumn(Name = "评估收货锁定库存")]
        public decimal MarcBWESB { get; set; }

        [ExcelColumn(Name = "货源")]
        public string MarcBWSCL { get; set; }

        [ExcelColumn(Name = "评估类别")]
        public string MarcBWTTY { get; set; }

        [ExcelColumn(Name = "CAS 号（药品） ")]
        public string MarcCASNR { get; set; }

        [ExcelColumn(Name = "周期标识被固定")]
        public string MarcCCFIX { get; set; }

        [ExcelColumn(Name = "该字段不再使用")]
        public string MarcCOMPL { get; set; }

        [ExcelColumn(Name = "寄售控制")]
        public string MarcconsProcg { get; set; }

        [ExcelColumn(Name = "转换类型")]
        public string MarcCONVT { get; set; }

        [ExcelColumn(Name = "字段名 ")]
        public string MarcCOPAM { get; set; }

        [ExcelColumn(Name = "内部对象号 ")]
        public string MarcCUOBJ { get; set; }

        [ExcelColumn(Name = "内部对象号 ")]
        public string MarcCUOBV { get; set; }

        [ExcelColumn(Name = "MRP  范围存在")]
        public string MarcDIBER { get; set; }

        [ExcelColumn(Name = "MRP组 ")]
        public string MarcDISGR { get; set; }

        [Required(ErrorMessage = "批量大小不能为空")]
        [ExcelColumn(Name = "批量大小")]
        public string MarcDISLS { get; set; }

        [Required(ErrorMessage = "MRP 类型不能为空")]
        [ExcelColumn(Name = "MRP 类型")]
        public string MarcDISMM { get; set; }

        [ExcelColumn(Name = "MRP 控制者 ")]
        public string MarcDISPO { get; set; }

        [ExcelColumn(Name = "MRP 参数文件")]
        public string MarcDISPR { get; set; }

        [ExcelColumn(Name = "公平分享规则")]
        public string MarcDPLFS { get; set; }

        [Required(ErrorMessage = "发布界限不能为空")]
        [ExcelColumn(Name = "发布界限")]
        public decimal MarcDPLHO { get; set; }

        [ExcelColumn(Name = "推式分配")]
        public string MarcDPLPU { get; set; }

        [Required(ErrorMessage = "厂内生产时间不能为空")]
        [ExcelColumn(Name = "厂内生产时间")]
        public decimal MarcDZEIT { get; set; }

        [Required(ErrorMessage = "安全库存不能为空")]
        [ExcelColumn(Name = "安全库存")]
        public decimal MarcEISBE { get; set; }

        [Required(ErrorMessage = "最小安全库存 不能为空")]
        [ExcelColumn(Name = "最小安全库存 ")]
        public decimal MarcEISLO { get; set; }

        [Required(ErrorMessage = "采购组 不能为空")]
        [ExcelColumn(Name = "采购组 ")]
        public string MarcEKGRP { get; set; }

        [ExcelColumn(Name = "库存确定组 ")]
        public string MarcEPRIO { get; set; }

        [ExcelColumn(Name = "商品代码单位")]
        public string MarcEXPME { get; set; }

        [ExcelColumn(Name = "JIT 标识")]
        public string MarcFABKZ { get; set; }

        [ExcelColumn(Name = "生产管理员 ")]
        public string MarcFEVOR { get; set; }

        [ExcelColumn(Name = "自动批准")]
        public string MarcFFREI { get; set; }

        [ExcelColumn(Name = "计划边际码 ")]
        public string MarcFHORI { get; set; }

        [Required(ErrorMessage = "固定批量大小不能为空")]
        [ExcelColumn(Name = "固定批量大小")]
        public decimal MarcFIXLS { get; set; }

        [ExcelColumn(Name = "分配 prof.")]
        public string MarcFPRFM { get; set; }

        [ExcelColumn(Name = "生产单位")]
        public string MarcFRTME { get; set; }

        [ExcelColumn(Name = "订单分配运行")]
        public string MarcfshMgArunReq { get; set; }

        [ExcelColumn(Name = "库存管理中激活季节")]
        public string MarcfshSeaim { get; set; }

        [ExcelColumn(Name = "生产版本")]
        public string MarcFVIDK { get; set; }

        [ExcelColumn(Name = "计划的时界 ")]
        public string MarcFXHOR { get; set; }

        [ExcelColumn(Name = "固定价格联产品")]
        public string MarcFXPRU { get; set; }

        [Required(ErrorMessage = "发货处理时间不能为空")]
        [ExcelColumn(Name = "发货处理时间")]
        public decimal MarcgiPrTime { get; set; }

        [Required(ErrorMessage = "有约束的虚拟不能为空")]
        [ExcelColumn(Name = "有约束的虚拟")]
        public decimal MarcGLGMG { get; set; }

        [ExcelColumn(Name = "粗略计划")]
        public string MarcGPMKZ { get; set; }

        [ExcelColumn(Name = "PRODCOM号 ")]
        public string MarcGPNUM { get; set; }

        [ExcelColumn(Name = "生产状态 ")]
        public string MarcHERBL { get; set; }

        [ExcelColumn(Name = "原产地国")]
        public string MarcHERKL { get; set; }

        [ExcelColumn(Name = "货源地 ")]
        public string MarcHERKR { get; set; }

        [ExcelColumn(Name = "物料类别")]
        public string MarcINDUS { get; set; }

        [Required(ErrorMessage = "过帐到检验库存不能为空")]
        [ExcelColumn(Name = "过帐到检验库存")]
        public string MarcINSMK { get; set; }

        [ExcelColumn(Name = "军用物资")]
        public string MarcITARK { get; set; }

        [ExcelColumn(Name = "IUID 相关")]
        public string MarciuidRelevant { get; set; }

        [ExcelColumn(Name = "IUID 类型")]
        public string MarciuidType { get; set; }

        [Required(ErrorMessage = "组件报废不能为空")]
        [ExcelColumn(Name = "组件报废")]
        public decimal MarcKAUSF { get; set; }

        [ExcelColumn(Name = "自动采购单 ")]
        public string MarcKAUTB { get; set; }

        [ExcelColumn(Name = "源清单 ")]
        public string MarcKORDB { get; set; }

        [ExcelColumn(Name = "平滑促销消耗 ")]
        public string MarcKZAGL { get; set; }

        [ExcelColumn(Name = "非连续标识 ")]
        public string MarcKZAUS { get; set; }

        [ExcelColumn(Name = "需求分组 ")]
        public string MarcKZBED { get; set; }

        [ExcelColumn(Name = "MRP控制者=买者 ")]
        public string MarcKZDIE { get; set; }

        [ExcelColumn(Name = "凭证需求 ")]
        public string MarcKZDKZ { get; set; }

        [ExcelColumn(Name = "输入批量")]
        public string MarcKZECH { get; set; }

        [ExcelColumn(Name = "修正因子")]
        public string MarcKZKFK { get; set; }

        [ExcelColumn(Name = "关键组件")]
        public string MarcKZKRI { get; set; }

        [ExcelColumn(Name = "联产品 ")]
        public string MarcKZKUP { get; set; }

        [ExcelColumn(Name = "检查计划标识 ")]
        public string MarcKZPPV { get; set; }

        [ExcelColumn(Name = "从产品货位提取")]
        public string MarcKZPRO { get; set; }

        [ExcelColumn(Name = "跨项目 ")]
        public string MarcKZPSP { get; set; }

        [ExcelColumn(Name = "装载组 ")]
        public string MarcLADGR { get; set; }

        [ExcelColumn(Name = "库存成本")]
        public string MarcLAGPR { get; set; }

        [ExcelColumn(Name = "年  当前期间")]
        public string MarcLFGJA { get; set; }

        [ExcelColumn(Name = "本期")]
        public string MarcLFMON { get; set; }

        [ExcelColumn(Name = "计划周期")]
        public string MarcLFRHY { get; set; }

        [Required(ErrorMessage = "外部采购仓储地不能为空")]
        [ExcelColumn(Name = "外部采购仓储地")]
        public string MarcLGFSB { get; set; }

        [Required(ErrorMessage = "生产仓储地点不能为空")]
        [ExcelColumn(Name = "生产仓储地点")]
        public string MarcLGPRO { get; set; }

        [Required(ErrorMessage = "服务水平不能为空")]
        [ExcelColumn(Name = "服务水平")]
        public decimal MarcLGRAD { get; set; }

        [ExcelColumn(Name = "取消激活的")]
        public string MarcLIZYK { get; set; }

        [ExcelColumn(Name = "后勤组 ")]
        public string MarcLOGGR { get; set; }

        [Required(ErrorMessage = "订购成本不能为空")]
        [ExcelColumn(Name = "订购成本")]
        public decimal MarcLOSFX { get; set; }

        [Required(ErrorMessage = "成本核算批量不能为空")]
        [ExcelColumn(Name = "成本核算批量")]
        public decimal MarcLOSGR { get; set; }

        [Required(ErrorMessage = "批尺寸增加 不能为空")]
        [ExcelColumn(Name = "批尺寸增加 ")]
        public decimal MarcLTINC { get; set; }

        [ExcelColumn(Name = "工厂级 DF")]
        public string MarcLVORM { get; set; }

        [ExcelColumn(Name = "时间单位")]
        public string MarcLZEIH { get; set; }

        [ExcelColumn(Name = "ABC 标识")]
        public string MarcMAABC { get; set; }

        [Required(ErrorMessage = "最大库存水平 不能为空")]
        [ExcelColumn(Name = "最大库存水平 ")]
        public decimal MarcMABST { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        public string MarcMANDT { get; set; }

        [ExcelColumn(Name = "物料分组")]
        public string MarcMATGR { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        public string MarcMATNR { get; set; }

        [ExcelColumn(Name = "最大目标范围 ")]
        public string MarcmaxTroc { get; set; }

        [Required(ErrorMessage = "最大批量大小 不能为空")]
        [ExcelColumn(Name = "最大批量大小 ")]
        public decimal MarcMAXLS { get; set; }

        [Required(ErrorMessage = "最大存储期间 不能为空")]
        [ExcelColumn(Name = "最大存储期间 ")]
        public decimal MarcMAXLZ { get; set; }

        [ExcelColumn(Name = "最后的MARD 期间之前，MARDH 记")]
        public string MarcMCRUE { get; set; }

        [ExcelColumn(Name = "活动控制")]
        public string MarcMDACH { get; set; }

        [ExcelColumn(Name = "计量单位组 ")]
        public string MarcMEGRU { get; set; }

        [ExcelColumn(Name = "物料运输组 ")]
        public string MarcMFRGR { get; set; }

        [ExcelColumn(Name = "最小目标范围 ")]
        public string MarcminTroc { get; set; }

        [Required(ErrorMessage = "再订货点不能为空")]
        [ExcelColumn(Name = "再订货点")]
        public decimal MarcMINBE { get; set; }

        [Required(ErrorMessage = "最小批量大小 不能为空")]
        [ExcelColumn(Name = "最小批量大小 ")]
        public decimal MarcMINLS { get; set; }

        [ExcelColumn(Name = "综合MRP")]
        public string MarcMISKZ { get; set; }

        [ExcelColumn(Name = "P-S 物料状态 ")]
        public string MarcMMSTA { get; set; }

        [ExcelColumn(Name = "有效起始期 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcMMSTD { get; set; }

        [ExcelColumn(Name = "CAP 产品组 ")]
        public string MarcMOGRU { get; set; }

        [ExcelColumn(Name = "EU 产品清单编号")]
        public string MarcMOWNR { get; set; }

        [Required(ErrorMessage = "平均检查持续期不能为空")]
        [ExcelColumn(Name = "平均检查持续期")]
        public decimal MarcMPDAU { get; set; }

        [ExcelColumn(Name = "计划日历")]
        public string MarcMRPPP { get; set; }

        [ExcelColumn(Name = "出口/进口组 ")]
        public string MarcMTVER { get; set; }

        [Required(ErrorMessage = "可用性检查 不能为空")]
        [ExcelColumn(Name = "可用性检查 ")]
        public string MarcMTVFP { get; set; }

        [ExcelColumn(Name = "交叉的采购组")]
        public string MarcmultipleEkgrp { get; set; }

        [ExcelColumn(Name = "无成本核算 ")]
        public string MarcNCOST { get; set; }

        [ExcelColumn(Name = "后继物料")]
        public string MarcNFMAT { get; set; }

        [ExcelColumn(Name = "下一次检查 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcNKMPR { get; set; }

        [ExcelColumn(Name = "对象标识")]
        public string MarcOBJID { get; set; }

        [ExcelColumn(Name = "总体参数文件")]
        public string MarcOCMPF { get; set; }

        [ExcelColumn(Name = "对象类型")]
        public string MarcOTYPE { get; set; }

        [ExcelColumn(Name = "会计年度变式")]
        public string MarcPERIV { get; set; }

        [ExcelColumn(Name = "期间标识")]
        public string MarcPERKZ { get; set; }

        [ExcelColumn(Name = "自动更改工厂订单")]
        public string MarcPFREI { get; set; }

        [Required(ErrorMessage = "计划交货时间不能为空")]
        [ExcelColumn(Name = "计划交货时间")]
        public decimal MarcPLIFZ { get; set; }

        [ExcelColumn(Name = "组 ")]
        public string MarcPLNNR { get; set; }

        [ExcelColumn(Name = "任务清单类型")]
        public string MarcPLNTY { get; set; }

        [ExcelColumn(Name = "计划版本")]
        public string MarcPLVAR { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        public string MarcPRCTR { get; set; }

        [ExcelColumn(Name = "优先权 ")]
        public string MarcPREFE { get; set; }

        [ExcelColumn(Name = "免税证书")]
        public string MarcPRENC { get; set; }

        [ExcelColumn(Name = "发放证书日 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcPREND { get; set; }

        [ExcelColumn(Name = "供应商申报 ")]
        public string MarcPRENE { get; set; }

        [ExcelColumn(Name = "供应商申报日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcPRENG { get; set; }

        [ExcelColumn(Name = "免税证书编号")]
        public string MarcPRENO { get; set; }

        [Required(ErrorMessage = "检查间隔 不能为空")]
        [ExcelColumn(Name = "检查间隔 ")]
        public decimal MarcPRFRQ { get; set; }

        [ExcelColumn(Name = "维护状态 ")]
        public string MarcPSTAT { get; set; }

        [ExcelColumn(Name = "QM 物料授权")]
        public string MarcQMATA { get; set; }

        [ExcelColumn(Name = "检验设置 ")]
        public string MarcQMATV { get; set; }

        [ExcelColumn(Name = "目标 QM 系统")]
        public string MarcQSSYS { get; set; }

        [Required(ErrorMessage = "隔离不能为空")]
        [ExcelColumn(Name = "隔离")]
        public decimal MarcQUAZT { get; set; }

        [ExcelColumn(Name = "证书类型")]
        public string MarcQZGTP { get; set; }

        [ExcelColumn(Name = "舍入参数文件")]
        public string MarcRDPRF { get; set; }

        [ExcelColumn(Name = "确定方案")]
        public string MarcrefSchema { get; set; }

        [Required(ErrorMessage = "调整期间不能为空")]
        [ExcelColumn(Name = "调整期间")]
        public decimal MarcRESVP { get; set; }

        [ExcelColumn(Name = "反冲")]
        public string MarcRGEKZ { get; set; }

        [ExcelColumn(Name = "库存入库/出库")]
        public string MarcrotationDate { get; set; }

        [Required(ErrorMessage = "准备时间不能为空")]
        [ExcelColumn(Name = "准备时间")]
        public decimal MarcRUEZT { get; set; }

        [ExcelColumn(Name = "供货天数参文件")]
        public string MarcRWPRO { get; set; }

        [ExcelColumn(Name = "重复生产")]
        public string MarcSAUFT { get; set; }

        [ExcelColumn(Name = "独立/集中")]
        public string MarcSBDKZ { get; set; }

        [ExcelColumn(Name = "散装物料")]
        public string MarcSCHGT { get; set; }

        [ExcelColumn(Name = "序列号参数文件")]
        public string MarcSERNP { get; set; }

        [ExcelColumn(Name = "服务水平")]
        public string MarcSERVG { get; set; }

        [ExcelColumn(Name = "生产参数文 ")]
        public string MarcSFCPF { get; set; }

        [ExcelColumn(Name = "REM 参数文件")]
        public string MarcSFEPR { get; set; }

        [ExcelColumn(Name = "离散批次编号")]
        public string MarcsgtChint { get; set; }

        [ExcelColumn(Name = "分段策略")]
        public string MarcsgtCovs { get; set; }

        [ExcelColumn(Name = "库存排序方法")]
        public string MarcsgtMrpsi { get; set; }

        [ExcelColumn(Name = "消耗优先级")]
        public string MarcsgtPrcm { get; set; }

        [ExcelColumn(Name = "分段范围")]
        public string MarcsgtScope { get; set; }

        [ExcelColumn(Name = "分段状态 MRP")]
        public string MarcsgtStatc { get; set; }

        [ExcelColumn(Name = "库存保护")]
        public string MarcsgtStkPrt { get; set; }

        [ExcelColumn(Name = "安全时间标识")]
        public string MarcSHFLG { get; set; }

        [ExcelColumn(Name = "ST 期间参数文件")]
        public string MarcSHPRO { get; set; }

        [ExcelColumn(Name = "安全时间")]
        public string MarcSHZET { get; set; }

        [ExcelColumn(Name = "特殊工艺类型")]
        public string MarcSOBSK { get; set; }

        [Required(ErrorMessage = "特殊采购不能为空")]
        [ExcelColumn(Name = "特殊采购")]
        public string MarcSOBSL { get; set; }

        [Required(ErrorMessage = "样本%不能为空")]
        [ExcelColumn(Name = "样本%")]
        public decimal MarcSPROZ { get; set; }

        [ExcelColumn(Name = "QM 控制码 ")]
        public string MarcSSQSS { get; set; }

        [ExcelColumn(Name = "Comm./imp. code")]
        public string MarcSTAWN { get; set; }

        [ExcelColumn(Name = "可配置的物料")]
        public string MarcSTDPD { get; set; }

        [ExcelColumn(Name = "控制代码")]
        public string MarcSTEUC { get; set; }

        [ExcelColumn(Name = "备选 ")]
        public string MarcSTLAL { get; set; }

        [ExcelColumn(Name = "用途 ")]
        public string MarcSTLAN { get; set; }

        [ExcelColumn(Name = "策略组 ")]
        public string MarcSTRGR { get; set; }

        [Required(ErrorMessage = "间隔时间不能为空")]
        [ExcelColumn(Name = "间隔时间")]
        public decimal MarcTAKZT { get; set; }

        [Required(ErrorMessage = "目标库存不能为空")]
        [ExcelColumn(Name = "目标库存")]
        public decimal MarctargetStock { get; set; }

        [Required(ErrorMessage = "在途库存 不能为空")]
        [ExcelColumn(Name = "在途库存 ")]
        public decimal MarcTRAME { get; set; }

        [Required(ErrorMessage = "工序间 不能为空")]
        [ExcelColumn(Name = "工序间 ")]
        public decimal MarcTRANZ { get; set; }

        [ExcelColumn(Name = "OB管理")]
        public string MarcUCHKZ { get; set; }

        [ExcelColumn(Name = "OB参考物料 ")]
        public string MarcUCMAT { get; set; }

        [ExcelColumn(Name = "无限的 ")]
        public string MarcUEETK { get; set; }

        [Required(ErrorMessage = "过度交货允差不能为空")]
        [ExcelColumn(Name = "过度交货允差")]
        public decimal MarcUEETO { get; set; }

        [ExcelColumn(Name = "外部分配")]
        public string MarcuidIea { get; set; }

        [Required(ErrorMessage = "中转库存不能为空")]
        [ExcelColumn(Name = "中转库存")]
        public decimal MarcUMLMC { get; set; }

        [ExcelColumn(Name = "转换组 ")]
        public string MarcUMRSL { get; set; }

        [Required(ErrorMessage = "不足交货允差不能为空")]
        [ExcelColumn(Name = "不足交货允差")]
        public decimal MarcUNETO { get; set; }

        [ExcelColumn(Name = "计量单位组 ")]
        public string MarcUOMGR { get; set; }

        [ExcelColumn(Name = "配额使用安排")]
        public string MarcUSEQU { get; set; }

        [Required(ErrorMessage = "基准数量不能为空")]
        [ExcelColumn(Name = "基准数量")]
        public decimal MarcVBAMG { get; set; }

        [Required(ErrorMessage = "处理时间不能为空")]
        [ExcelColumn(Name = "处理时间")]
        public decimal MarcVBEAZ { get; set; }

        [ExcelColumn(Name = "版本")]
        public string MarcVERKZ { get; set; }

        [ExcelColumn(Name = "逆向消耗期间 ")]
        public string MarcVINT1 { get; set; }

        [ExcelColumn(Name = "向前消耗期间 ")]
        public string MarcVINT2 { get; set; }

        [Required(ErrorMessage = "SlsVal.TiedEmpt不能为空")]
        [ExcelColumn(Name = "SlsVal.TiedEmpt")]
        public decimal MarcVKGLG { get; set; }

        [Required(ErrorMessage = "运输库存/SP不能为空")]
        [ExcelColumn(Name = "运输库存/SP")]
        public decimal MarcVKTRW { get; set; }

        [Required(ErrorMessage = "库存转移 SV不能为空")]
        [ExcelColumn(Name = "库存转移 SV")]
        public decimal MarcVKUMC { get; set; }

        [ExcelColumn(Name = "日期到 ", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MarcVRBDT { get; set; }

        [Required(ErrorMessage = "乘数不能为空")]
        [ExcelColumn(Name = "乘数")]
        public decimal MarcVRBFK { get; set; }

        [ExcelColumn(Name = "参考物料:消耗 ")]
        public string MarcVRBMT { get; set; }

        [ExcelColumn(Name = "参考工厂：寄存")]
        public string MarcVRBWK { get; set; }

        [ExcelColumn(Name = "消耗模式 ")]
        public string MarcVRMOD { get; set; }

        [Required(ErrorMessage = "准备时间不能为空")]
        [ExcelColumn(Name = "准备时间")]
        public decimal MarcVRVEZ { get; set; }

        [ExcelColumn(Name = "提议供应区域")]
        public string MarcVSPVB { get; set; }

        [Required(ErrorMessage = "附加费 %不能为空")]
        [ExcelColumn(Name = "附加费 %")]
        public decimal MarcVZUSL { get; set; }

        [Required(ErrorMessage = "收货处理时间不能为空")]
        [ExcelColumn(Name = "收货处理时间")]
        public decimal MarcWEBAZ { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        public string MarcWERKS { get; set; }

        [Required(ErrorMessage = "活动性物质 不能为空")]
        [ExcelColumn(Name = "活动性物质 ")]
        public decimal MarcWSTGH { get; set; }

        [Required(ErrorMessage = "总补货提前时间不能为空")]
        [ExcelColumn(Name = "总补货提前时间")]
        public decimal MarcWZEIT { get; set; }

        [ExcelColumn(Name = "批次")]
        public string MarcXCHAR { get; set; }

        [ExcelColumn(Name = "批次管理需求 ")]
        public string MarcXCHPF { get; set; }

        [ExcelColumn(Name = "负的库存")]
        public string MarcXMCNG { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        public int IsDeleted { get; set; }

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