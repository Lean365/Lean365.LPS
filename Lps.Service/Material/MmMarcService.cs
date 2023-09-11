using System;
using SqlSugar;
using Lps.Infrastructure.Attribute;
using Lps.Infrastructure.Extensions;
using Lps.Model;
using Lps.ServiceCore.Model.System;
using Lps.ServiceCore;
using Lps.Model.Dto;
using Lps.Model.Material;
using Lps.Repository;
using Lps.Service.Material.IMaterialService;
using System.Linq;

namespace Lps.Service.Material
{
    /// <summary>
    /// 工厂物料数据
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-09-11
    /// </summary>
    [AppService(ServiceType = typeof(IMmMarcService), ServiceLifetime = LifeTime.Transient)]
    public class MmMarcService : BaseService<MmMarc>, IMmMarcService
    {
        /// <summary>
        /// 查询工厂物料数据列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMarcDto> GetList(MmMarcQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMarc>();

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MmMarc, MmMarcDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString)
        {
            int count = Count(it => it.MarcGuid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MarcGuid"></param>
        /// <returns></returns>
        public MmMarc GetInfo(Guid MarcGuid)
        {
            var response = Queryable()
                .Where(x => x.MarcGuid == MarcGuid)
                .First();

            return response;
        }

        /// <summary>
        /// 添加工厂物料数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmMarc AddMmMarc(MmMarc model)
        {
            return Context.Insertable(model).EnableDiffLogEvent("新增工厂物料数据").ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改工厂物料数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmMarc(MmMarc model)
        {
            //var response = Update(w => w.MarcGuid == model.MarcGuid, it => new MmMarc()
            //{
            //    MarcABCIN = model.MarcABCIN,
            //    MarcABFAC = model.MarcABFAC,
            //    MarcAHDIS = model.MarcAHDIS,
            //    MarcALTSL = model.MarcALTSL,
            //    MarcAPLAL = model.MarcAPLAL,
            //    MarcAPOKZ = model.MarcAPOKZ,
            //    MarcATPKZ = model.MarcATPKZ,
            //    MarcAUFTL = model.MarcAUFTL,
            //    MarcAUSDT = model.MarcAUSDT,
            //    MarcAUSME = model.MarcAUSME,
            //    MarcAUSSS = model.MarcAUSSS,
            //    MarcAUTRU = model.MarcAUTRU,
            //    MarcAWSLS = model.MarcAWSLS,
            //    MarcBASMG = model.MarcBASMG,
            //    MarcBEARZ = model.MarcBEARZ,
            //    MarcBESKZ = model.MarcBESKZ,
            //    MarcBSTFE = model.MarcBSTFE,
            //    MarcBSTMA = model.MarcBSTMA,
            //    MarcBSTMI = model.MarcBSTMI,
            //    MarcBSTRF = model.MarcBSTRF,
            //    MarcBWESB = model.MarcBWESB,
            //    MarcBWSCL = model.MarcBWSCL,
            //    MarcBWTTY = model.MarcBWTTY,
            //    MarcCASNR = model.MarcCASNR,
            //    MarcCCFIX = model.MarcCCFIX,
            //    MarcCOMPL = model.MarcCOMPL,
            //    MarcconsProcg = model.MarcconsProcg,
            //    MarcCONVT = model.MarcCONVT,
            //    MarcCOPAM = model.MarcCOPAM,
            //    MarcCUOBJ = model.MarcCUOBJ,
            //    MarcCUOBV = model.MarcCUOBV,
            //    MarcDIBER = model.MarcDIBER,
            //    MarcDISGR = model.MarcDISGR,
            //    MarcDISLS = model.MarcDISLS,
            //    MarcDISMM = model.MarcDISMM,
            //    MarcDISPO = model.MarcDISPO,
            //    MarcDISPR = model.MarcDISPR,
            //    MarcDPLFS = model.MarcDPLFS,
            //    MarcDPLHO = model.MarcDPLHO,
            //    MarcDPLPU = model.MarcDPLPU,
            //    MarcDZEIT = model.MarcDZEIT,
            //    MarcEISBE = model.MarcEISBE,
            //    MarcEISLO = model.MarcEISLO,
            //    MarcEKGRP = model.MarcEKGRP,
            //    MarcEPRIO = model.MarcEPRIO,
            //    MarcEXPME = model.MarcEXPME,
            //    MarcFABKZ = model.MarcFABKZ,
            //    MarcFEVOR = model.MarcFEVOR,
            //    MarcFFREI = model.MarcFFREI,
            //    MarcFHORI = model.MarcFHORI,
            //    MarcFIXLS = model.MarcFIXLS,
            //    MarcFPRFM = model.MarcFPRFM,
            //    MarcFRTME = model.MarcFRTME,
            //    MarcfshMgArunReq = model.MarcfshMgArunReq,
            //    MarcfshSeaim = model.MarcfshSeaim,
            //    MarcFVIDK = model.MarcFVIDK,
            //    MarcFXHOR = model.MarcFXHOR,
            //    MarcFXPRU = model.MarcFXPRU,
            //    MarcgiPrTime = model.MarcgiPrTime,
            //    MarcGLGMG = model.MarcGLGMG,
            //    MarcGPMKZ = model.MarcGPMKZ,
            //    MarcGPNUM = model.MarcGPNUM,
            //    MarcHERBL = model.MarcHERBL,
            //    MarcHERKL = model.MarcHERKL,
            //    MarcHERKR = model.MarcHERKR,
            //    MarcINDUS = model.MarcINDUS,
            //    MarcINSMK = model.MarcINSMK,
            //    MarcITARK = model.MarcITARK,
            //    MarciuidRelevant = model.MarciuidRelevant,
            //    MarciuidType = model.MarciuidType,
            //    MarcKAUSF = model.MarcKAUSF,
            //    MarcKAUTB = model.MarcKAUTB,
            //    MarcKORDB = model.MarcKORDB,
            //    MarcKZAGL = model.MarcKZAGL,
            //    MarcKZAUS = model.MarcKZAUS,
            //    MarcKZBED = model.MarcKZBED,
            //    MarcKZDIE = model.MarcKZDIE,
            //    MarcKZDKZ = model.MarcKZDKZ,
            //    MarcKZECH = model.MarcKZECH,
            //    MarcKZKFK = model.MarcKZKFK,
            //    MarcKZKRI = model.MarcKZKRI,
            //    MarcKZKUP = model.MarcKZKUP,
            //    MarcKZPPV = model.MarcKZPPV,
            //    MarcKZPRO = model.MarcKZPRO,
            //    MarcKZPSP = model.MarcKZPSP,
            //    MarcLADGR = model.MarcLADGR,
            //    MarcLAGPR = model.MarcLAGPR,
            //    MarcLFGJA = model.MarcLFGJA,
            //    MarcLFMON = model.MarcLFMON,
            //    MarcLFRHY = model.MarcLFRHY,
            //    MarcLGFSB = model.MarcLGFSB,
            //    MarcLGPRO = model.MarcLGPRO,
            //    MarcLGRAD = model.MarcLGRAD,
            //    MarcLIZYK = model.MarcLIZYK,
            //    MarcLOGGR = model.MarcLOGGR,
            //    MarcLOSFX = model.MarcLOSFX,
            //    MarcLOSGR = model.MarcLOSGR,
            //    MarcLTINC = model.MarcLTINC,
            //    MarcLVORM = model.MarcLVORM,
            //    MarcLZEIH = model.MarcLZEIH,
            //    MarcMAABC = model.MarcMAABC,
            //    MarcMABST = model.MarcMABST,
            //    MarcMANDT = model.MarcMANDT,
            //    MarcMATGR = model.MarcMATGR,
            //    MarcMATNR = model.MarcMATNR,
            //    MarcmaxTroc = model.MarcmaxTroc,
            //    MarcMAXLS = model.MarcMAXLS,
            //    MarcMAXLZ = model.MarcMAXLZ,
            //    MarcMCRUE = model.MarcMCRUE,
            //    MarcMDACH = model.MarcMDACH,
            //    MarcMEGRU = model.MarcMEGRU,
            //    MarcMFRGR = model.MarcMFRGR,
            //    MarcminTroc = model.MarcminTroc,
            //    MarcMINBE = model.MarcMINBE,
            //    MarcMINLS = model.MarcMINLS,
            //    MarcMISKZ = model.MarcMISKZ,
            //    MarcMMSTA = model.MarcMMSTA,
            //    MarcMMSTD = model.MarcMMSTD,
            //    MarcMOGRU = model.MarcMOGRU,
            //    MarcMOWNR = model.MarcMOWNR,
            //    MarcMPDAU = model.MarcMPDAU,
            //    MarcMRPPP = model.MarcMRPPP,
            //    MarcMTVER = model.MarcMTVER,
            //    MarcMTVFP = model.MarcMTVFP,
            //    MarcmultipleEkgrp = model.MarcmultipleEkgrp,
            //    MarcNCOST = model.MarcNCOST,
            //    MarcNFMAT = model.MarcNFMAT,
            //    MarcNKMPR = model.MarcNKMPR,
            //    MarcOBJID = model.MarcOBJID,
            //    MarcOCMPF = model.MarcOCMPF,
            //    MarcOTYPE = model.MarcOTYPE,
            //    MarcPERIV = model.MarcPERIV,
            //    MarcPERKZ = model.MarcPERKZ,
            //    MarcPFREI = model.MarcPFREI,
            //    MarcPLIFZ = model.MarcPLIFZ,
            //    MarcPLNNR = model.MarcPLNNR,
            //    MarcPLNTY = model.MarcPLNTY,
            //    MarcPLVAR = model.MarcPLVAR,
            //    MarcPRCTR = model.MarcPRCTR,
            //    MarcPREFE = model.MarcPREFE,
            //    MarcPRENC = model.MarcPRENC,
            //    MarcPREND = model.MarcPREND,
            //    MarcPRENE = model.MarcPRENE,
            //    MarcPRENG = model.MarcPRENG,
            //    MarcPRENO = model.MarcPRENO,
            //    MarcPRFRQ = model.MarcPRFRQ,
            //    MarcPSTAT = model.MarcPSTAT,
            //    MarcQMATA = model.MarcQMATA,
            //    MarcQMATV = model.MarcQMATV,
            //    MarcQSSYS = model.MarcQSSYS,
            //    MarcQUAZT = model.MarcQUAZT,
            //    MarcQZGTP = model.MarcQZGTP,
            //    MarcRDPRF = model.MarcRDPRF,
            //    MarcrefSchema = model.MarcrefSchema,
            //    MarcRESVP = model.MarcRESVP,
            //    MarcRGEKZ = model.MarcRGEKZ,
            //    MarcrotationDate = model.MarcrotationDate,
            //    MarcRUEZT = model.MarcRUEZT,
            //    MarcRWPRO = model.MarcRWPRO,
            //    MarcSAUFT = model.MarcSAUFT,
            //    MarcSBDKZ = model.MarcSBDKZ,
            //    MarcSCHGT = model.MarcSCHGT,
            //    MarcSERNP = model.MarcSERNP,
            //    MarcSERVG = model.MarcSERVG,
            //    MarcSFCPF = model.MarcSFCPF,
            //    MarcSFEPR = model.MarcSFEPR,
            //    MarcsgtChint = model.MarcsgtChint,
            //    MarcsgtCovs = model.MarcsgtCovs,
            //    MarcsgtMrpsi = model.MarcsgtMrpsi,
            //    MarcsgtPrcm = model.MarcsgtPrcm,
            //    MarcsgtScope = model.MarcsgtScope,
            //    MarcsgtStatc = model.MarcsgtStatc,
            //    MarcsgtStkPrt = model.MarcsgtStkPrt,
            //    MarcSHFLG = model.MarcSHFLG,
            //    MarcSHPRO = model.MarcSHPRO,
            //    MarcSHZET = model.MarcSHZET,
            //    MarcSOBSK = model.MarcSOBSK,
            //    MarcSOBSL = model.MarcSOBSL,
            //    MarcSPROZ = model.MarcSPROZ,
            //    MarcSSQSS = model.MarcSSQSS,
            //    MarcSTAWN = model.MarcSTAWN,
            //    MarcSTDPD = model.MarcSTDPD,
            //    MarcSTEUC = model.MarcSTEUC,
            //    MarcSTLAL = model.MarcSTLAL,
            //    MarcSTLAN = model.MarcSTLAN,
            //    MarcSTRGR = model.MarcSTRGR,
            //    MarcTAKZT = model.MarcTAKZT,
            //    MarctargetStock = model.MarctargetStock,
            //    MarcTRAME = model.MarcTRAME,
            //    MarcTRANZ = model.MarcTRANZ,
            //    MarcUCHKZ = model.MarcUCHKZ,
            //    MarcUCMAT = model.MarcUCMAT,
            //    MarcUEETK = model.MarcUEETK,
            //    MarcUEETO = model.MarcUEETO,
            //    MarcuidIea = model.MarcuidIea,
            //    MarcUMLMC = model.MarcUMLMC,
            //    MarcUMRSL = model.MarcUMRSL,
            //    MarcUNETO = model.MarcUNETO,
            //    MarcUOMGR = model.MarcUOMGR,
            //    MarcUSEQU = model.MarcUSEQU,
            //    MarcVBAMG = model.MarcVBAMG,
            //    MarcVBEAZ = model.MarcVBEAZ,
            //    MarcVERKZ = model.MarcVERKZ,
            //    MarcVINT1 = model.MarcVINT1,
            //    MarcVINT2 = model.MarcVINT2,
            //    MarcVKGLG = model.MarcVKGLG,
            //    MarcVKTRW = model.MarcVKTRW,
            //    MarcVKUMC = model.MarcVKUMC,
            //    MarcVRBDT = model.MarcVRBDT,
            //    MarcVRBFK = model.MarcVRBFK,
            //    MarcVRBMT = model.MarcVRBMT,
            //    MarcVRBWK = model.MarcVRBWK,
            //    MarcVRMOD = model.MarcVRMOD,
            //    MarcVRVEZ = model.MarcVRVEZ,
            //    MarcVSPVB = model.MarcVSPVB,
            //    MarcVZUSL = model.MarcVZUSL,
            //    MarcWEBAZ = model.MarcWEBAZ,
            //    MarcWERKS = model.MarcWERKS,
            //    MarcWSTGH = model.MarcWSTGH,
            //    MarcWZEIT = model.MarcWZEIT,
            //    MarcXCHAR = model.MarcXCHAR,
            //    MarcXCHPF = model.MarcXCHPF,
            //    MarcXMCNG = model.MarcXMCNG,
            //    ReMarks = model.ReMarks,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true);
        }

        /// <summary>
        /// 导入工厂物料数据
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmMarc(List<MmMarc> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MarcGuid.IsEmpty(), "ID主键不能为空")
                .SplitError(x => x.Item.MarcABFAC.IsEmpty(), "空气浮力因子不能为空")
                .SplitError(x => x.Item.MarcAUSSS.IsEmpty(), "装配报废不能为空")
                .SplitError(x => x.Item.MarcBASMG.IsEmpty(), "基准数量不能为空")
                .SplitError(x => x.Item.MarcBEARZ.IsEmpty(), "处理时间不能为空")
                .SplitError(x => x.Item.MarcBESKZ.IsEmpty(), "采购不能为空")
                .SplitError(x => x.Item.MarcBSTFE.IsEmpty(), "固定批量大小不能为空")
                .SplitError(x => x.Item.MarcBSTMA.IsEmpty(), "最大批量 不能为空")
                .SplitError(x => x.Item.MarcBSTMI.IsEmpty(), "最小批量大小 不能为空")
                .SplitError(x => x.Item.MarcBSTRF.IsEmpty(), "舍入值 不能为空")
                .SplitError(x => x.Item.MarcBWESB.IsEmpty(), "评估收货锁定库存不能为空")
                .SplitError(x => x.Item.MarcDISLS.IsEmpty(), "批量大小不能为空")
                .SplitError(x => x.Item.MarcDISMM.IsEmpty(), "MRP 类型不能为空")
                .SplitError(x => x.Item.MarcDPLHO.IsEmpty(), "发布界限不能为空")
                .SplitError(x => x.Item.MarcDZEIT.IsEmpty(), "厂内生产时间不能为空")
                .SplitError(x => x.Item.MarcEISBE.IsEmpty(), "安全库存不能为空")
                .SplitError(x => x.Item.MarcEISLO.IsEmpty(), "最小安全库存 不能为空")
                .SplitError(x => x.Item.MarcEKGRP.IsEmpty(), "采购组 不能为空")
                .SplitError(x => x.Item.MarcFIXLS.IsEmpty(), "固定批量大小不能为空")
                .SplitError(x => x.Item.MarcgiPrTime.IsEmpty(), "发货处理时间不能为空")
                .SplitError(x => x.Item.MarcGLGMG.IsEmpty(), "有约束的虚拟不能为空")
                .SplitError(x => x.Item.MarcINSMK.IsEmpty(), "过帐到检验库存不能为空")
                .SplitError(x => x.Item.MarcKAUSF.IsEmpty(), "组件报废不能为空")
                .SplitError(x => x.Item.MarcLGFSB.IsEmpty(), "外部采购仓储地不能为空")
                .SplitError(x => x.Item.MarcLGPRO.IsEmpty(), "生产仓储地点不能为空")
                .SplitError(x => x.Item.MarcLGRAD.IsEmpty(), "服务水平不能为空")
                .SplitError(x => x.Item.MarcLOSFX.IsEmpty(), "订购成本不能为空")
                .SplitError(x => x.Item.MarcLOSGR.IsEmpty(), "成本核算批量不能为空")
                .SplitError(x => x.Item.MarcLTINC.IsEmpty(), "批尺寸增加 不能为空")
                .SplitError(x => x.Item.MarcMABST.IsEmpty(), "最大库存水平 不能为空")
                .SplitError(x => x.Item.MarcMANDT.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.MarcMATNR.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.MarcMAXLS.IsEmpty(), "最大批量大小 不能为空")
                .SplitError(x => x.Item.MarcMAXLZ.IsEmpty(), "最大存储期间 不能为空")
                .SplitError(x => x.Item.MarcMINBE.IsEmpty(), "再订货点不能为空")
                .SplitError(x => x.Item.MarcMINLS.IsEmpty(), "最小批量大小 不能为空")
                .SplitError(x => x.Item.MarcMPDAU.IsEmpty(), "平均检查持续期不能为空")
                .SplitError(x => x.Item.MarcMTVFP.IsEmpty(), "可用性检查 不能为空")
                .SplitError(x => x.Item.MarcPLIFZ.IsEmpty(), "计划交货时间不能为空")
                .SplitError(x => x.Item.MarcPRCTR.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.MarcPRFRQ.IsEmpty(), "检查间隔 不能为空")
                .SplitError(x => x.Item.MarcQUAZT.IsEmpty(), "隔离不能为空")
                .SplitError(x => x.Item.MarcRESVP.IsEmpty(), "调整期间不能为空")
                .SplitError(x => x.Item.MarcRUEZT.IsEmpty(), "准备时间不能为空")
                .SplitError(x => x.Item.MarcSOBSL.IsEmpty(), "特殊采购不能为空")
                .SplitError(x => x.Item.MarcSPROZ.IsEmpty(), "样本%不能为空")
                .SplitError(x => x.Item.MarcTAKZT.IsEmpty(), "间隔时间不能为空")
                .SplitError(x => x.Item.MarctargetStock.IsEmpty(), "目标库存不能为空")
                .SplitError(x => x.Item.MarcTRAME.IsEmpty(), "在途库存 不能为空")
                .SplitError(x => x.Item.MarcTRANZ.IsEmpty(), "工序间 不能为空")
                .SplitError(x => x.Item.MarcUEETO.IsEmpty(), "过度交货允差不能为空")
                .SplitError(x => x.Item.MarcUMLMC.IsEmpty(), "中转库存不能为空")
                .SplitError(x => x.Item.MarcUNETO.IsEmpty(), "不足交货允差不能为空")
                .SplitError(x => x.Item.MarcVBAMG.IsEmpty(), "基准数量不能为空")
                .SplitError(x => x.Item.MarcVBEAZ.IsEmpty(), "处理时间不能为空")
                .SplitError(x => x.Item.MarcVKGLG.IsEmpty(), "SlsVal.TiedEmpt不能为空")
                .SplitError(x => x.Item.MarcVKTRW.IsEmpty(), "运输库存/SP不能为空")
                .SplitError(x => x.Item.MarcVKUMC.IsEmpty(), "库存转移 SV不能为空")
                .SplitError(x => x.Item.MarcVRBFK.IsEmpty(), "乘数不能为空")
                .SplitError(x => x.Item.MarcVRVEZ.IsEmpty(), "准备时间不能为空")
                .SplitError(x => x.Item.MarcVZUSL.IsEmpty(), "附加费 %不能为空")
                .SplitError(x => x.Item.MarcWEBAZ.IsEmpty(), "收货处理时间不能为空")
                .SplitError(x => x.Item.MarcWERKS.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.MarcWSTGH.IsEmpty(), "活动性物质 不能为空")
                .SplitError(x => x.Item.MarcWZEIT.IsEmpty(), "总补货提前时间不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "软删除不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.EnableDiffLogEvent("批量导入工厂物料数据").ExecuteCommand();//插入可插入部分;

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";                    
            Console.WriteLine(msg);

            //输出错误信息               
            foreach (var item in x.ErrorList)
            {
                Console.WriteLine("错误" + item.StorageMessage);
            }
            foreach (var item in x.IgnoreList)
            {
                Console.WriteLine("忽略" + item.StorageMessage);
            }

            return (msg, x.ErrorList, x.IgnoreList);
        }
    }
}