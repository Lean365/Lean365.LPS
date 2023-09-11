<!--
 * @Descripttion: (工厂物料数据/mm_marc)
 * @version: (4.0.0)
 * @Author: (Lean365)
 * @Date: (2023-09-11)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh"type="info" plain @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['mm:marc:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['mm:marc:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['mm:marc:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:marc:import']">
          <el-button color="#79bbff" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="material/MmMarc/importTemplate"
                  importUrl="/material/MmMarc/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['mm:marc:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>
    <!-- 数据区域 -->
    <el-table
      :data="dataList"
      v-loading="loading"
      ref="table"
      border
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
      height="602" style="width: 100%" :summary-method="getSummaries" show-summary>
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="marcGuid" label="ID主键" align="center" v-if="columns.showColumn('marcGuid')"/>
      <el-table-column prop="marcABCIN" label="CC 库存盘点" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcABCIN')"/>
      <el-table-column prop="marcABFAC" label="空气浮力因子" align="center" v-if="columns.showColumn('marcABFAC')"/>
      <el-table-column prop="marcAHDIS" label="MRP 相关需求 " align="center" v-if="columns.showColumn('marcAHDIS')">
        <template #default="scope">
          <dict-tag :options=" options.marcAHDISOptions" :value="scope.row.marcAHDIS"  />
        </template>
      </el-table-column>
      <el-table-column prop="marcALTSL" label="选择方法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcALTSL')"/>
      <el-table-column prop="marcAPLAL" label="组计数器" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcAPLAL')"/>
      <el-table-column prop="marcAPOKZ" label="相关于 APO" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcAPOKZ')"/>
      <el-table-column prop="marcATPKZ" label="替换部件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcATPKZ')"/>
      <el-table-column prop="marcAUFTL" label="分割标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcAUFTL')"/>
      <el-table-column prop="marcAUSDT" label="中断日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('marcAUSDT')"/>
      <el-table-column prop="marcAUSME" label="发货单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcAUSME')"/>
      <el-table-column prop="marcAUSSS" label="装配报废" align="center" v-if="columns.showColumn('marcAUSSS')"/>
      <el-table-column prop="marcAUTRU" label="自动重置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcAUTRU')"/>
      <el-table-column prop="marcAWSLS" label="差异码 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcAWSLS')"/>
      <el-table-column prop="marcBASMG" label="基准数量" align="center" v-if="columns.showColumn('marcBASMG')"/>
      <el-table-column prop="marcBEARZ" label="处理时间" align="center" v-if="columns.showColumn('marcBEARZ')"/>
      <el-table-column prop="marcBESKZ" label="采购" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcBESKZ')"/>
      <el-table-column prop="marcBSTFE" label="固定批量大小" align="center" v-if="columns.showColumn('marcBSTFE')"/>
      <el-table-column prop="marcBSTMA" label="最大批量 " align="center" v-if="columns.showColumn('marcBSTMA')"/>
      <el-table-column prop="marcBSTMI" label="最小批量大小 " align="center" v-if="columns.showColumn('marcBSTMI')"/>
      <el-table-column prop="marcBSTRF" label="舍入值 " align="center" v-if="columns.showColumn('marcBSTRF')"/>
      <el-table-column prop="marcBWESB" label="评估收货锁定库存" align="center" v-if="columns.showColumn('marcBWESB')"/>
      <el-table-column prop="marcBWSCL" label="货源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcBWSCL')"/>
      <el-table-column prop="marcBWTTY" label="评估类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcBWTTY')"/>
      <el-table-column prop="marcCASNR" label="CAS 号（药品） " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcCASNR')"/>
      <el-table-column prop="marcCCFIX" label="周期标识被固定" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcCCFIX')"/>
      <el-table-column prop="marcCOMPL" label="该字段不再使用" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcCOMPL')"/>
      <el-table-column prop="marcconsProcg" label="寄售控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcconsProcg')"/>
      <el-table-column prop="marcCONVT" label="转换类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcCONVT')"/>
      <el-table-column prop="marcCOPAM" label="字段名 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcCOPAM')"/>
      <el-table-column prop="marcCUOBJ" label="内部对象号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcCUOBJ')"/>
      <el-table-column prop="marcCUOBV" label="内部对象号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcCUOBV')"/>
      <el-table-column prop="marcDIBER" label="MRP  范围存在" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcDIBER')"/>
      <el-table-column prop="marcDISGR" label="MRP组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcDISGR')"/>
      <el-table-column prop="marcDISLS" label="批量大小" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcDISLS')"/>
      <el-table-column prop="marcDISMM" label="MRP 类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcDISMM')"/>
      <el-table-column prop="marcDISPO" label="MRP 控制者 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcDISPO')"/>
      <el-table-column prop="marcDISPR" label="MRP 参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcDISPR')"/>
      <el-table-column prop="marcDPLFS" label="公平分享规则" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcDPLFS')"/>
      <el-table-column prop="marcDPLHO" label="发布界限" align="center" v-if="columns.showColumn('marcDPLHO')"/>
      <el-table-column prop="marcDPLPU" label="推式分配" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcDPLPU')"/>
      <el-table-column prop="marcDZEIT" label="厂内生产时间" align="center" v-if="columns.showColumn('marcDZEIT')"/>
      <el-table-column prop="marcEISBE" label="安全库存" align="center" v-if="columns.showColumn('marcEISBE')"/>
      <el-table-column prop="marcEISLO" label="最小安全库存 " align="center" v-if="columns.showColumn('marcEISLO')"/>
      <el-table-column prop="marcEKGRP" label="采购组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcEKGRP')"/>
      <el-table-column prop="marcEPRIO" label="库存确定组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcEPRIO')"/>
      <el-table-column prop="marcEXPME" label="商品代码单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcEXPME')"/>
      <el-table-column prop="marcFABKZ" label="JIT 标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcFABKZ')"/>
      <el-table-column prop="marcFEVOR" label="生产管理员 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcFEVOR')"/>
      <el-table-column prop="marcFFREI" label="自动批准" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcFFREI')"/>
      <el-table-column prop="marcFHORI" label="计划边际码 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcFHORI')"/>
      <el-table-column prop="marcFIXLS" label="固定批量大小" align="center" v-if="columns.showColumn('marcFIXLS')"/>
      <el-table-column prop="marcFPRFM" label="分配 prof." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcFPRFM')"/>
      <el-table-column prop="marcFRTME" label="生产单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcFRTME')"/>
      <el-table-column prop="marcfshMgArunReq" label="订单分配运行" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcfshMgArunReq')"/>
      <el-table-column prop="marcfshSeaim" label="库存管理中激活季节" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcfshSeaim')"/>
      <el-table-column prop="marcFVIDK" label="生产版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcFVIDK')"/>
      <el-table-column prop="marcFXHOR" label="计划的时界 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcFXHOR')"/>
      <el-table-column prop="marcFXPRU" label="固定价格联产品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcFXPRU')"/>
      <el-table-column prop="marcgiPrTime" label="发货处理时间" align="center" v-if="columns.showColumn('marcgiPrTime')"/>
      <el-table-column prop="marcGLGMG" label="有约束的虚拟" align="center" v-if="columns.showColumn('marcGLGMG')"/>
      <el-table-column prop="marcGPMKZ" label="粗略计划" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcGPMKZ')"/>
      <el-table-column prop="marcGPNUM" label="PRODCOM号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcGPNUM')"/>
      <el-table-column prop="marcHERBL" label="生产状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcHERBL')"/>
      <el-table-column prop="marcHERKL" label="原产地国" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcHERKL')"/>
      <el-table-column prop="marcHERKR" label="货源地 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcHERKR')"/>
      <el-table-column prop="marcINDUS" label="物料类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcINDUS')"/>
      <el-table-column prop="marcINSMK" label="过帐到检验库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcINSMK')"/>
      <el-table-column prop="marcITARK" label="军用物资" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcITARK')"/>
      <el-table-column prop="marciuidRelevant" label="IUID 相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marciuidRelevant')"/>
      <el-table-column prop="marciuidType" label="IUID 类型" align="center" v-if="columns.showColumn('marciuidType')">
        <template #default="scope">
          <dict-tag :options=" options.marciuidTypeOptions" :value="scope.row.marciuidType"  />
        </template>
      </el-table-column>
      <el-table-column prop="marcKAUSF" label="组件报废" align="center" v-if="columns.showColumn('marcKAUSF')"/>
      <el-table-column prop="marcKAUTB" label="自动采购单 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKAUTB')"/>
      <el-table-column prop="marcKORDB" label="源清单 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKORDB')"/>
      <el-table-column prop="marcKZAGL" label="平滑促销消耗 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZAGL')"/>
      <el-table-column prop="marcKZAUS" label="非连续标识 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZAUS')"/>
      <el-table-column prop="marcKZBED" label="需求分组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZBED')"/>
      <el-table-column prop="marcKZDIE" label="MRP控制者=买者 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZDIE')"/>
      <el-table-column prop="marcKZDKZ" label="凭证需求 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZDKZ')"/>
      <el-table-column prop="marcKZECH" label="输入批量" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZECH')"/>
      <el-table-column prop="marcKZKFK" label="修正因子" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZKFK')"/>
      <el-table-column prop="marcKZKRI" label="关键组件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZKRI')"/>
      <el-table-column prop="marcKZKUP" label="联产品 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZKUP')"/>
      <el-table-column prop="marcKZPPV" label="检查计划标识 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZPPV')"/>
      <el-table-column prop="marcKZPRO" label="从产品货位提取" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZPRO')"/>
      <el-table-column prop="marcKZPSP" label="跨项目 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcKZPSP')"/>
      <el-table-column prop="marcLADGR" label="装载组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLADGR')"/>
      <el-table-column prop="marcLAGPR" label="库存成本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLAGPR')"/>
      <el-table-column prop="marcLFGJA" label="年  当前期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLFGJA')"/>
      <el-table-column prop="marcLFMON" label="本期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLFMON')"/>
      <el-table-column prop="marcLFRHY" label="计划周期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLFRHY')"/>
      <el-table-column prop="marcLGFSB" label="外部采购仓储地" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLGFSB')"/>
      <el-table-column prop="marcLGPRO" label="生产仓储地点" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLGPRO')"/>
      <el-table-column prop="marcLGRAD" label="服务水平" align="center" v-if="columns.showColumn('marcLGRAD')"/>
      <el-table-column prop="marcLIZYK" label="取消激活的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLIZYK')"/>
      <el-table-column prop="marcLOGGR" label="后勤组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLOGGR')"/>
      <el-table-column prop="marcLOSFX" label="订购成本" align="center" v-if="columns.showColumn('marcLOSFX')"/>
      <el-table-column prop="marcLOSGR" label="成本核算批量" align="center" v-if="columns.showColumn('marcLOSGR')"/>
      <el-table-column prop="marcLTINC" label="批尺寸增加 " align="center" v-if="columns.showColumn('marcLTINC')"/>
      <el-table-column prop="marcLVORM" label="工厂级 DF" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLVORM')"/>
      <el-table-column prop="marcLZEIH" label="时间单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcLZEIH')"/>
      <el-table-column prop="marcMAABC" label="ABC 标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMAABC')"/>
      <el-table-column prop="marcMABST" label="最大库存水平 " align="center" v-if="columns.showColumn('marcMABST')"/>
      <el-table-column prop="marcMANDT" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMANDT')"/>
      <el-table-column prop="marcMATGR" label="物料分组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMATGR')"/>
      <el-table-column prop="marcMATNR" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMATNR')"/>
      <el-table-column prop="marcmaxTroc" label="最大目标范围 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcmaxTroc')"/>
      <el-table-column prop="marcMAXLS" label="最大批量大小 " align="center" v-if="columns.showColumn('marcMAXLS')"/>
      <el-table-column prop="marcMAXLZ" label="最大存储期间 " align="center" v-if="columns.showColumn('marcMAXLZ')"/>
      <el-table-column prop="marcMCRUE" label="最后的MARD 期间之前，MARDH 记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMCRUE')"/>
      <el-table-column prop="marcMDACH" label="活动控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMDACH')"/>
      <el-table-column prop="marcMEGRU" label="计量单位组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMEGRU')"/>
      <el-table-column prop="marcMFRGR" label="物料运输组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMFRGR')"/>
      <el-table-column prop="marcminTroc" label="最小目标范围 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcminTroc')"/>
      <el-table-column prop="marcMINBE" label="再订货点" align="center" v-if="columns.showColumn('marcMINBE')"/>
      <el-table-column prop="marcMINLS" label="最小批量大小 " align="center" v-if="columns.showColumn('marcMINLS')"/>
      <el-table-column prop="marcMISKZ" label="综合MRP" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMISKZ')"/>
      <el-table-column prop="marcMMSTA" label="P-S 物料状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMMSTA')"/>
      <el-table-column prop="marcMMSTD" label="有效起始期 " :show-overflow-tooltip="true"  v-if="columns.showColumn('marcMMSTD')"/>
      <el-table-column prop="marcMOGRU" label="CAP 产品组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMOGRU')"/>
      <el-table-column prop="marcMOWNR" label="EU 产品清单编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMOWNR')"/>
      <el-table-column prop="marcMPDAU" label="平均检查持续期" align="center" v-if="columns.showColumn('marcMPDAU')"/>
      <el-table-column prop="marcMRPPP" label="计划日历" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMRPPP')"/>
      <el-table-column prop="marcMTVER" label="出口/进口组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMTVER')"/>
      <el-table-column prop="marcMTVFP" label="可用性检查 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcMTVFP')"/>
      <el-table-column prop="marcmultipleEkgrp" label="交叉的采购组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcmultipleEkgrp')"/>
      <el-table-column prop="marcNCOST" label="无成本核算 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcNCOST')"/>
      <el-table-column prop="marcNFMAT" label="后继物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcNFMAT')"/>
      <el-table-column prop="marcNKMPR" label="下一次检查 " :show-overflow-tooltip="true"  v-if="columns.showColumn('marcNKMPR')"/>
      <el-table-column prop="marcOBJID" label="对象标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcOBJID')"/>
      <el-table-column prop="marcOCMPF" label="总体参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcOCMPF')"/>
      <el-table-column prop="marcOTYPE" label="对象类型" align="center" v-if="columns.showColumn('marcOTYPE')">
        <template #default="scope">
          <dict-tag :options=" options.marcOTYPEOptions" :value="scope.row.marcOTYPE"  />
        </template>
      </el-table-column>
      <el-table-column prop="marcPERIV" label="会计年度变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPERIV')"/>
      <el-table-column prop="marcPERKZ" label="期间标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPERKZ')"/>
      <el-table-column prop="marcPFREI" label="自动更改工厂订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPFREI')"/>
      <el-table-column prop="marcPLIFZ" label="计划交货时间" align="center" v-if="columns.showColumn('marcPLIFZ')"/>
      <el-table-column prop="marcPLNNR" label="组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPLNNR')"/>
      <el-table-column prop="marcPLNTY" label="任务清单类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPLNTY')"/>
      <el-table-column prop="marcPLVAR" label="计划版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPLVAR')"/>
      <el-table-column prop="marcPRCTR" label="利润中心" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPRCTR')"/>
      <el-table-column prop="marcPREFE" label="优先权 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPREFE')"/>
      <el-table-column prop="marcPRENC" label="免税证书" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPRENC')"/>
      <el-table-column prop="marcPREND" label="发放证书日 " :show-overflow-tooltip="true"  v-if="columns.showColumn('marcPREND')"/>
      <el-table-column prop="marcPRENE" label="供应商申报 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPRENE')"/>
      <el-table-column prop="marcPRENG" label="供应商申报日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('marcPRENG')"/>
      <el-table-column prop="marcPRENO" label="免税证书编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPRENO')"/>
      <el-table-column prop="marcPRFRQ" label="检查间隔 " align="center" v-if="columns.showColumn('marcPRFRQ')"/>
      <el-table-column prop="marcPSTAT" label="维护状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcPSTAT')"/>
      <el-table-column prop="marcQMATA" label="QM 物料授权" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcQMATA')"/>
      <el-table-column prop="marcQMATV" label="检验设置 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcQMATV')"/>
      <el-table-column prop="marcQSSYS" label="目标 QM 系统" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcQSSYS')"/>
      <el-table-column prop="marcQUAZT" label="隔离" align="center" v-if="columns.showColumn('marcQUAZT')"/>
      <el-table-column prop="marcQZGTP" label="证书类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcQZGTP')"/>
      <el-table-column prop="marcRDPRF" label="舍入参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcRDPRF')"/>
      <el-table-column prop="marcrefSchema" label="确定方案" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcrefSchema')"/>
      <el-table-column prop="marcRESVP" label="调整期间" align="center" v-if="columns.showColumn('marcRESVP')"/>
      <el-table-column prop="marcRGEKZ" label="反冲" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcRGEKZ')"/>
      <el-table-column prop="marcrotationDate" label="库存入库/出库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcrotationDate')"/>
      <el-table-column prop="marcRUEZT" label="准备时间" align="center" v-if="columns.showColumn('marcRUEZT')"/>
      <el-table-column prop="marcRWPRO" label="供货天数参文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcRWPRO')"/>
      <el-table-column prop="marcSAUFT" label="重复生产" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSAUFT')"/>
      <el-table-column prop="marcSBDKZ" label="独立/集中" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSBDKZ')"/>
      <el-table-column prop="marcSCHGT" label="散装物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSCHGT')"/>
      <el-table-column prop="marcSERNP" label="序列号参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSERNP')"/>
      <el-table-column prop="marcSERVG" label="服务水平" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSERVG')"/>
      <el-table-column prop="marcSFCPF" label="生产参数文 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSFCPF')"/>
      <el-table-column prop="marcSFEPR" label="REM 参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSFEPR')"/>
      <el-table-column prop="marcsgtChint" label="离散批次编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcsgtChint')"/>
      <el-table-column prop="marcsgtCovs" label="分段策略" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcsgtCovs')"/>
      <el-table-column prop="marcsgtMrpsi" label="库存排序方法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcsgtMrpsi')"/>
      <el-table-column prop="marcsgtPrcm" label="消耗优先级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcsgtPrcm')"/>
      <el-table-column prop="marcsgtScope" label="分段范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcsgtScope')"/>
      <el-table-column prop="marcsgtStatc" label="分段状态 MRP" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcsgtStatc')"/>
      <el-table-column prop="marcsgtStkPrt" label="库存保护" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcsgtStkPrt')"/>
      <el-table-column prop="marcSHFLG" label="安全时间标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSHFLG')"/>
      <el-table-column prop="marcSHPRO" label="ST 期间参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSHPRO')"/>
      <el-table-column prop="marcSHZET" label="安全时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSHZET')"/>
      <el-table-column prop="marcSOBSK" label="特殊工艺类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSOBSK')"/>
      <el-table-column prop="marcSOBSL" label="特殊采购" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSOBSL')"/>
      <el-table-column prop="marcSPROZ" label="样本%" align="center" v-if="columns.showColumn('marcSPROZ')"/>
      <el-table-column prop="marcSSQSS" label="QM 控制码 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSSQSS')"/>
      <el-table-column prop="marcSTAWN" label="Comm./imp. code" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSTAWN')"/>
      <el-table-column prop="marcSTDPD" label="可配置的物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSTDPD')"/>
      <el-table-column prop="marcSTEUC" label="控制代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSTEUC')"/>
      <el-table-column prop="marcSTLAL" label="备选 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSTLAL')"/>
      <el-table-column prop="marcSTLAN" label="用途 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSTLAN')"/>
      <el-table-column prop="marcSTRGR" label="策略组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcSTRGR')"/>
      <el-table-column prop="marcTAKZT" label="间隔时间" align="center" v-if="columns.showColumn('marcTAKZT')"/>
      <el-table-column prop="marctargetStock" label="目标库存" align="center" v-if="columns.showColumn('marctargetStock')"/>
      <el-table-column prop="marcTRAME" label="在途库存 " align="center" v-if="columns.showColumn('marcTRAME')"/>
      <el-table-column prop="marcTRANZ" label="工序间 " align="center" v-if="columns.showColumn('marcTRANZ')"/>
      <el-table-column prop="marcUCHKZ" label="OB管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcUCHKZ')"/>
      <el-table-column prop="marcUCMAT" label="OB参考物料 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcUCMAT')"/>
      <el-table-column prop="marcUEETK" label="无限的 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcUEETK')"/>
      <el-table-column prop="marcUEETO" label="过度交货允差" align="center" v-if="columns.showColumn('marcUEETO')"/>
      <el-table-column prop="marcuidIea" label="外部分配" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcuidIea')"/>
      <el-table-column prop="marcUMLMC" label="中转库存" align="center" v-if="columns.showColumn('marcUMLMC')"/>
      <el-table-column prop="marcUMRSL" label="转换组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcUMRSL')"/>
      <el-table-column prop="marcUNETO" label="不足交货允差" align="center" v-if="columns.showColumn('marcUNETO')"/>
      <el-table-column prop="marcUOMGR" label="计量单位组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcUOMGR')"/>
      <el-table-column prop="marcUSEQU" label="配额使用安排" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcUSEQU')"/>
      <el-table-column prop="marcVBAMG" label="基准数量" align="center" v-if="columns.showColumn('marcVBAMG')"/>
      <el-table-column prop="marcVBEAZ" label="处理时间" align="center" v-if="columns.showColumn('marcVBEAZ')"/>
      <el-table-column prop="marcVERKZ" label="版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcVERKZ')"/>
      <el-table-column prop="marcVINT1" label="逆向消耗期间 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcVINT1')"/>
      <el-table-column prop="marcVINT2" label="向前消耗期间 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcVINT2')"/>
      <el-table-column prop="marcVKGLG" label="SlsVal.TiedEmpt" align="center" v-if="columns.showColumn('marcVKGLG')"/>
      <el-table-column prop="marcVKTRW" label="运输库存/SP" align="center" v-if="columns.showColumn('marcVKTRW')"/>
      <el-table-column prop="marcVKUMC" label="库存转移 SV" align="center" v-if="columns.showColumn('marcVKUMC')"/>
      <el-table-column prop="marcVRBDT" label="日期到 " :show-overflow-tooltip="true"  v-if="columns.showColumn('marcVRBDT')"/>
      <el-table-column prop="marcVRBFK" label="乘数" align="center" v-if="columns.showColumn('marcVRBFK')"/>
      <el-table-column prop="marcVRBMT" label="参考物料:消耗 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcVRBMT')"/>
      <el-table-column prop="marcVRBWK" label="参考工厂：寄存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcVRBWK')"/>
      <el-table-column prop="marcVRMOD" label="消耗模式 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcVRMOD')"/>
      <el-table-column prop="marcVRVEZ" label="准备时间" align="center" v-if="columns.showColumn('marcVRVEZ')"/>
      <el-table-column prop="marcVSPVB" label="提议供应区域" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcVSPVB')"/>
      <el-table-column prop="marcVZUSL" label="附加费 %" align="center" v-if="columns.showColumn('marcVZUSL')"/>
      <el-table-column prop="marcWEBAZ" label="收货处理时间" align="center" v-if="columns.showColumn('marcWEBAZ')"/>
      <el-table-column prop="marcWERKS" label="工厂" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcWERKS')"/>
      <el-table-column prop="marcWSTGH" label="活动性物质 " align="center" v-if="columns.showColumn('marcWSTGH')"/>
      <el-table-column prop="marcWZEIT" label="总补货提前时间" align="center" v-if="columns.showColumn('marcWZEIT')"/>
      <el-table-column prop="marcXCHAR" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcXCHAR')"/>
      <el-table-column prop="marcXCHPF" label="批次管理需求 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcXCHPF')"/>
      <el-table-column prop="marcXMCNG" label="负的库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('marcXMCNG')"/>
      <el-table-column prop="reMarks" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('reMarks')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column :label="$t('btn.operation')" width="180">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:marc:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" icon="delete" plain :title="$t('btn.delete')" v-hasPermi="['mm:marc:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改工厂物料数据对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="ID主键" prop="marcGuid">
              <el-input v-model="form.marcGuid" :placeholder="$t('btn.enter')+'ID主键'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CC 库存盘点" prop="marcABCIN">
              <el-input clearable v-model="form.marcABCIN" :placeholder="$t('btn.enter')+'CC 库存盘点'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="空气浮力因子" prop="marcABFAC">
              <el-input clearable v-model="form.marcABFAC" :placeholder="$t('btn.enter')+'空气浮力因子'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 相关需求 " prop="marcAHDIS">
              <el-radio-group v-model="form.marcAHDIS">
                <el-radio v-for="item in options.marcAHDISOptions" :key="item.dictValue" :label="item.dictValue">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选择方法" prop="marcALTSL">
              <el-input clearable v-model="form.marcALTSL" :placeholder="$t('btn.enter')+'选择方法'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组计数器" prop="marcAPLAL">
              <el-input clearable v-model="form.marcAPLAL" :placeholder="$t('btn.enter')+'组计数器'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="相关于 APO" prop="marcAPOKZ">
              <el-input clearable v-model="form.marcAPOKZ" :placeholder="$t('btn.enter')+'相关于 APO'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="替换部件" prop="marcATPKZ">
              <el-input clearable v-model="form.marcATPKZ" :placeholder="$t('btn.enter')+'替换部件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分割标识" prop="marcAUFTL">
              <el-input clearable v-model="form.marcAUFTL" :placeholder="$t('btn.enter')+'分割标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="中断日期" prop="marcAUSDT">
              <el-date-picker v-model="form.marcAUSDT" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发货单位" prop="marcAUSME">
              <el-input clearable v-model="form.marcAUSME" :placeholder="$t('btn.enter')+'发货单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="装配报废" prop="marcAUSSS">
              <el-input clearable v-model="form.marcAUSSS" :placeholder="$t('btn.enter')+'装配报废'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自动重置" prop="marcAUTRU">
              <el-input clearable v-model="form.marcAUTRU" :placeholder="$t('btn.enter')+'自动重置'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异码 " prop="marcAWSLS">
              <el-input clearable v-model="form.marcAWSLS" :placeholder="$t('btn.enter')+'差异码 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基准数量" prop="marcBASMG">
              <el-input clearable v-model="form.marcBASMG" :placeholder="$t('btn.enter')+'基准数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理时间" prop="marcBEARZ">
              <el-input clearable v-model="form.marcBEARZ" :placeholder="$t('btn.enter')+'处理时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购" prop="marcBESKZ">
              <el-input clearable v-model="form.marcBESKZ" :placeholder="$t('btn.enter')+'采购'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固定批量大小" prop="marcBSTFE">
              <el-input clearable v-model="form.marcBSTFE" :placeholder="$t('btn.enter')+'固定批量大小'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大批量 " prop="marcBSTMA">
              <el-input clearable v-model="form.marcBSTMA" :placeholder="$t('btn.enter')+'最大批量 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最小批量大小 " prop="marcBSTMI">
              <el-input clearable v-model="form.marcBSTMI" :placeholder="$t('btn.enter')+'最小批量大小 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="舍入值 " prop="marcBSTRF">
              <el-input clearable v-model="form.marcBSTRF" :placeholder="$t('btn.enter')+'舍入值 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估收货锁定库存" prop="marcBWESB">
              <el-input clearable v-model="form.marcBWESB" :placeholder="$t('btn.enter')+'评估收货锁定库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="货源" prop="marcBWSCL">
              <el-input clearable v-model="form.marcBWSCL" :placeholder="$t('btn.enter')+'货源'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类别" prop="marcBWTTY">
              <el-input clearable v-model="form.marcBWTTY" :placeholder="$t('btn.enter')+'评估类别'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CAS 号（药品） " prop="marcCASNR">
              <el-input clearable v-model="form.marcCASNR" :placeholder="$t('btn.enter')+'CAS 号（药品） '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="周期标识被固定" prop="marcCCFIX">
              <el-input clearable v-model="form.marcCCFIX" :placeholder="$t('btn.enter')+'周期标识被固定'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="该字段不再使用" prop="marcCOMPL">
              <el-input clearable v-model="form.marcCOMPL" :placeholder="$t('btn.enter')+'该字段不再使用'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="寄售控制" prop="marcconsProcg">
              <el-input clearable v-model="form.marcconsProcg" :placeholder="$t('btn.enter')+'寄售控制'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转换类型" prop="marcCONVT">
              <el-input clearable v-model="form.marcCONVT" :placeholder="$t('btn.enter')+'转换类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="字段名 " prop="marcCOPAM">
              <el-input clearable v-model="form.marcCOPAM" :placeholder="$t('btn.enter')+'字段名 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内部对象号 " prop="marcCUOBJ">
              <el-input clearable v-model="form.marcCUOBJ" :placeholder="$t('btn.enter')+'内部对象号 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内部对象号 " prop="marcCUOBV">
              <el-input clearable v-model="form.marcCUOBV" :placeholder="$t('btn.enter')+'内部对象号 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP  范围存在" prop="marcDIBER">
              <el-input clearable v-model="form.marcDIBER" :placeholder="$t('btn.enter')+'MRP  范围存在'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP组 " prop="marcDISGR">
              <el-input clearable v-model="form.marcDISGR" :placeholder="$t('btn.enter')+'MRP组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批量大小" prop="marcDISLS">
              <el-input clearable v-model="form.marcDISLS" :placeholder="$t('btn.enter')+'批量大小'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 类型" prop="marcDISMM">
              <el-input clearable v-model="form.marcDISMM" :placeholder="$t('btn.enter')+'MRP 类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 控制者 " prop="marcDISPO">
              <el-input clearable v-model="form.marcDISPO" :placeholder="$t('btn.enter')+'MRP 控制者 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 参数文件" prop="marcDISPR">
              <el-input clearable v-model="form.marcDISPR" :placeholder="$t('btn.enter')+'MRP 参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公平分享规则" prop="marcDPLFS">
              <el-input clearable v-model="form.marcDPLFS" :placeholder="$t('btn.enter')+'公平分享规则'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发布界限" prop="marcDPLHO">
              <el-input clearable v-model="form.marcDPLHO" :placeholder="$t('btn.enter')+'发布界限'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="推式分配" prop="marcDPLPU">
              <el-input clearable v-model="form.marcDPLPU" :placeholder="$t('btn.enter')+'推式分配'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="厂内生产时间" prop="marcDZEIT">
              <el-input clearable v-model="form.marcDZEIT" :placeholder="$t('btn.enter')+'厂内生产时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="安全库存" prop="marcEISBE">
              <el-input clearable v-model="form.marcEISBE" :placeholder="$t('btn.enter')+'安全库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最小安全库存 " prop="marcEISLO">
              <el-input clearable v-model="form.marcEISLO" :placeholder="$t('btn.enter')+'最小安全库存 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购组 " prop="marcEKGRP">
              <el-input clearable v-model="form.marcEKGRP" :placeholder="$t('btn.enter')+'采购组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存确定组 " prop="marcEPRIO">
              <el-input clearable v-model="form.marcEPRIO" :placeholder="$t('btn.enter')+'库存确定组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商品代码单位" prop="marcEXPME">
              <el-input clearable v-model="form.marcEXPME" :placeholder="$t('btn.enter')+'商品代码单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="JIT 标识" prop="marcFABKZ">
              <el-input clearable v-model="form.marcFABKZ" :placeholder="$t('btn.enter')+'JIT 标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产管理员 " prop="marcFEVOR">
              <el-input clearable v-model="form.marcFEVOR" :placeholder="$t('btn.enter')+'生产管理员 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自动批准" prop="marcFFREI">
              <el-input clearable v-model="form.marcFFREI" :placeholder="$t('btn.enter')+'自动批准'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划边际码 " prop="marcFHORI">
              <el-input clearable v-model="form.marcFHORI" :placeholder="$t('btn.enter')+'计划边际码 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固定批量大小" prop="marcFIXLS">
              <el-input clearable v-model="form.marcFIXLS" :placeholder="$t('btn.enter')+'固定批量大小'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分配 prof." prop="marcFPRFM">
              <el-input clearable v-model="form.marcFPRFM" :placeholder="$t('btn.enter')+'分配 prof.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产单位" prop="marcFRTME">
              <el-input clearable v-model="form.marcFRTME" :placeholder="$t('btn.enter')+'生产单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单分配运行" prop="marcfshMgArunReq">
              <el-input clearable v-model="form.marcfshMgArunReq" :placeholder="$t('btn.enter')+'订单分配运行'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存管理中激活季节" prop="marcfshSeaim">
              <el-input clearable v-model="form.marcfshSeaim" :placeholder="$t('btn.enter')+'库存管理中激活季节'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产版本" prop="marcFVIDK">
              <el-input clearable v-model="form.marcFVIDK" :placeholder="$t('btn.enter')+'生产版本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划的时界 " prop="marcFXHOR">
              <el-input clearable v-model="form.marcFXHOR" :placeholder="$t('btn.enter')+'计划的时界 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固定价格联产品" prop="marcFXPRU">
              <el-input clearable v-model="form.marcFXPRU" :placeholder="$t('btn.enter')+'固定价格联产品'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发货处理时间" prop="marcgiPrTime">
              <el-input clearable v-model="form.marcgiPrTime" :placeholder="$t('btn.enter')+'发货处理时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有约束的虚拟" prop="marcGLGMG">
              <el-input clearable v-model="form.marcGLGMG" :placeholder="$t('btn.enter')+'有约束的虚拟'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="粗略计划" prop="marcGPMKZ">
              <el-input clearable v-model="form.marcGPMKZ" :placeholder="$t('btn.enter')+'粗略计划'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="PRODCOM号 " prop="marcGPNUM">
              <el-input clearable v-model="form.marcGPNUM" :placeholder="$t('btn.enter')+'PRODCOM号 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产状态 " prop="marcHERBL">
              <el-input clearable v-model="form.marcHERBL" :placeholder="$t('btn.enter')+'生产状态 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原产地国" prop="marcHERKL">
              <el-input clearable v-model="form.marcHERKL" :placeholder="$t('btn.enter')+'原产地国'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="货源地 " prop="marcHERKR">
              <el-input clearable v-model="form.marcHERKR" :placeholder="$t('btn.enter')+'货源地 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料类别" prop="marcINDUS">
              <el-input clearable v-model="form.marcINDUS" :placeholder="$t('btn.enter')+'物料类别'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过帐到检验库存" prop="marcINSMK">
              <el-input clearable v-model="form.marcINSMK" :placeholder="$t('btn.enter')+'过帐到检验库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="军用物资" prop="marcITARK">
              <el-input clearable v-model="form.marcITARK" :placeholder="$t('btn.enter')+'军用物资'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IUID 相关" prop="marciuidRelevant">
              <el-input clearable v-model="form.marciuidRelevant" :placeholder="$t('btn.enter')+'IUID 相关'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IUID 类型" prop="marciuidType">
              <el-select filterable clearable v-model="form.marciuidType"  :placeholder="$t('btn.select')+'IUID 类型'">
                <el-option
                  v-for="item in options.marciuidTypeOptions" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件报废" prop="marcKAUSF">
              <el-input clearable v-model="form.marcKAUSF" :placeholder="$t('btn.enter')+'组件报废'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自动采购单 " prop="marcKAUTB">
              <el-input clearable v-model="form.marcKAUTB" :placeholder="$t('btn.enter')+'自动采购单 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="源清单 " prop="marcKORDB">
              <el-input clearable v-model="form.marcKORDB" :placeholder="$t('btn.enter')+'源清单 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="平滑促销消耗 " prop="marcKZAGL">
              <el-input clearable v-model="form.marcKZAGL" :placeholder="$t('btn.enter')+'平滑促销消耗 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="非连续标识 " prop="marcKZAUS">
              <el-input clearable v-model="form.marcKZAUS" :placeholder="$t('btn.enter')+'非连续标识 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="需求分组 " prop="marcKZBED">
              <el-input clearable v-model="form.marcKZBED" :placeholder="$t('btn.enter')+'需求分组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP控制者=买者 " prop="marcKZDIE">
              <el-input clearable v-model="form.marcKZDIE" :placeholder="$t('btn.enter')+'MRP控制者=买者 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证需求 " prop="marcKZDKZ">
              <el-input clearable v-model="form.marcKZDKZ" :placeholder="$t('btn.enter')+'凭证需求 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入批量" prop="marcKZECH">
              <el-input clearable v-model="form.marcKZECH" :placeholder="$t('btn.enter')+'输入批量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="修正因子" prop="marcKZKFK">
              <el-input clearable v-model="form.marcKZKFK" :placeholder="$t('btn.enter')+'修正因子'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="关键组件" prop="marcKZKRI">
              <el-input clearable v-model="form.marcKZKRI" :placeholder="$t('btn.enter')+'关键组件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联产品 " prop="marcKZKUP">
              <el-input clearable v-model="form.marcKZKUP" :placeholder="$t('btn.enter')+'联产品 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查计划标识 " prop="marcKZPPV">
              <el-input clearable v-model="form.marcKZPPV" :placeholder="$t('btn.enter')+'检查计划标识 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="从产品货位提取" prop="marcKZPRO">
              <el-input clearable v-model="form.marcKZPRO" :placeholder="$t('btn.enter')+'从产品货位提取'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨项目 " prop="marcKZPSP">
              <el-input clearable v-model="form.marcKZPSP" :placeholder="$t('btn.enter')+'跨项目 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="装载组 " prop="marcLADGR">
              <el-input clearable v-model="form.marcLADGR" :placeholder="$t('btn.enter')+'装载组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存成本" prop="marcLAGPR">
              <el-input clearable v-model="form.marcLAGPR" :placeholder="$t('btn.enter')+'库存成本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年  当前期间" prop="marcLFGJA">
              <el-input clearable v-model="form.marcLFGJA" :placeholder="$t('btn.enter')+'年  当前期间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本期" prop="marcLFMON">
              <el-input clearable v-model="form.marcLFMON" :placeholder="$t('btn.enter')+'本期'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划周期" prop="marcLFRHY">
              <el-input clearable v-model="form.marcLFRHY" :placeholder="$t('btn.enter')+'计划周期'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部采购仓储地" prop="marcLGFSB">
              <el-input clearable v-model="form.marcLGFSB" :placeholder="$t('btn.enter')+'外部采购仓储地'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产仓储地点" prop="marcLGPRO">
              <el-input clearable v-model="form.marcLGPRO" :placeholder="$t('btn.enter')+'生产仓储地点'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="服务水平" prop="marcLGRAD">
              <el-input clearable v-model="form.marcLGRAD" :placeholder="$t('btn.enter')+'服务水平'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="取消激活的" prop="marcLIZYK">
              <el-input clearable v-model="form.marcLIZYK" :placeholder="$t('btn.enter')+'取消激活的'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后勤组 " prop="marcLOGGR">
              <el-input clearable v-model="form.marcLOGGR" :placeholder="$t('btn.enter')+'后勤组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订购成本" prop="marcLOSFX">
              <el-input clearable v-model="form.marcLOSFX" :placeholder="$t('btn.enter')+'订购成本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本核算批量" prop="marcLOSGR">
              <el-input clearable v-model="form.marcLOSGR" :placeholder="$t('btn.enter')+'成本核算批量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批尺寸增加 " prop="marcLTINC">
              <el-input clearable v-model="form.marcLTINC" :placeholder="$t('btn.enter')+'批尺寸增加 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂级 DF" prop="marcLVORM">
              <el-input clearable v-model="form.marcLVORM" :placeholder="$t('btn.enter')+'工厂级 DF'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="时间单位" prop="marcLZEIH">
              <el-input clearable v-model="form.marcLZEIH" :placeholder="$t('btn.enter')+'时间单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ABC 标识" prop="marcMAABC">
              <el-input clearable v-model="form.marcMAABC" :placeholder="$t('btn.enter')+'ABC 标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大库存水平 " prop="marcMABST">
              <el-input clearable v-model="form.marcMABST" :placeholder="$t('btn.enter')+'最大库存水平 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="集团" prop="marcMANDT">
              <el-input clearable v-model="form.marcMANDT" :placeholder="$t('btn.enter')+'集团'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料分组" prop="marcMATGR">
              <el-input clearable v-model="form.marcMATGR" :placeholder="$t('btn.enter')+'物料分组'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="marcMATNR">
              <el-input clearable v-model="form.marcMATNR" :placeholder="$t('btn.enter')+'物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大目标范围 " prop="marcmaxTroc">
              <el-input clearable v-model="form.marcmaxTroc" :placeholder="$t('btn.enter')+'最大目标范围 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大批量大小 " prop="marcMAXLS">
              <el-input clearable v-model="form.marcMAXLS" :placeholder="$t('btn.enter')+'最大批量大小 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大存储期间 " prop="marcMAXLZ">
              <el-input clearable v-model="form.marcMAXLZ" :placeholder="$t('btn.enter')+'最大存储期间 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最后的MARD 期间之前，MARDH 记" prop="marcMCRUE">
              <el-input clearable v-model="form.marcMCRUE" :placeholder="$t('btn.enter')+'最后的MARD 期间之前，MARDH 记'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="活动控制" prop="marcMDACH">
              <el-input clearable v-model="form.marcMDACH" :placeholder="$t('btn.enter')+'活动控制'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计量单位组 " prop="marcMEGRU">
              <el-input clearable v-model="form.marcMEGRU" :placeholder="$t('btn.enter')+'计量单位组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料运输组 " prop="marcMFRGR">
              <el-input clearable v-model="form.marcMFRGR" :placeholder="$t('btn.enter')+'物料运输组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最小目标范围 " prop="marcminTroc">
              <el-input clearable v-model="form.marcminTroc" :placeholder="$t('btn.enter')+'最小目标范围 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="再订货点" prop="marcMINBE">
              <el-input clearable v-model="form.marcMINBE" :placeholder="$t('btn.enter')+'再订货点'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最小批量大小 " prop="marcMINLS">
              <el-input clearable v-model="form.marcMINLS" :placeholder="$t('btn.enter')+'最小批量大小 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="综合MRP" prop="marcMISKZ">
              <el-input clearable v-model="form.marcMISKZ" :placeholder="$t('btn.enter')+'综合MRP'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="P-S 物料状态 " prop="marcMMSTA">
              <el-input clearable v-model="form.marcMMSTA" :placeholder="$t('btn.enter')+'P-S 物料状态 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效起始期 " prop="marcMMSTD">
              <el-date-picker v-model="form.marcMMSTD" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CAP 产品组 " prop="marcMOGRU">
              <el-input clearable v-model="form.marcMOGRU" :placeholder="$t('btn.enter')+'CAP 产品组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EU 产品清单编号" prop="marcMOWNR">
              <el-input clearable v-model="form.marcMOWNR" :placeholder="$t('btn.enter')+'EU 产品清单编号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="平均检查持续期" prop="marcMPDAU">
              <el-input clearable v-model="form.marcMPDAU" :placeholder="$t('btn.enter')+'平均检查持续期'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划日历" prop="marcMRPPP">
              <el-input clearable v-model="form.marcMRPPP" :placeholder="$t('btn.enter')+'计划日历'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出口/进口组 " prop="marcMTVER">
              <el-input clearable v-model="form.marcMTVER" :placeholder="$t('btn.enter')+'出口/进口组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可用性检查 " prop="marcMTVFP">
              <el-input clearable v-model="form.marcMTVFP" :placeholder="$t('btn.enter')+'可用性检查 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交叉的采购组" prop="marcmultipleEkgrp">
              <el-input clearable v-model="form.marcmultipleEkgrp" :placeholder="$t('btn.enter')+'交叉的采购组'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="无成本核算 " prop="marcNCOST">
              <el-input clearable v-model="form.marcNCOST" :placeholder="$t('btn.enter')+'无成本核算 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后继物料" prop="marcNFMAT">
              <el-input clearable v-model="form.marcNFMAT" :placeholder="$t('btn.enter')+'后继物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="下一次检查 " prop="marcNKMPR">
              <el-date-picker v-model="form.marcNKMPR" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="对象标识" prop="marcOBJID">
              <el-input clearable v-model="form.marcOBJID" :placeholder="$t('btn.enter')+'对象标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总体参数文件" prop="marcOCMPF">
              <el-input clearable v-model="form.marcOCMPF" :placeholder="$t('btn.enter')+'总体参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="对象类型" prop="marcOTYPE">
              <el-select filterable clearable v-model="form.marcOTYPE"  :placeholder="$t('btn.select')+'对象类型'">
                <el-option
                  v-for="item in options.marcOTYPEOptions" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="会计年度变式" prop="marcPERIV">
              <el-input clearable v-model="form.marcPERIV" :placeholder="$t('btn.enter')+'会计年度变式'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间标识" prop="marcPERKZ">
              <el-input clearable v-model="form.marcPERKZ" :placeholder="$t('btn.enter')+'期间标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自动更改工厂订单" prop="marcPFREI">
              <el-input clearable v-model="form.marcPFREI" :placeholder="$t('btn.enter')+'自动更改工厂订单'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划交货时间" prop="marcPLIFZ">
              <el-input clearable v-model="form.marcPLIFZ" :placeholder="$t('btn.enter')+'计划交货时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组 " prop="marcPLNNR">
              <el-input clearable v-model="form.marcPLNNR" :placeholder="$t('btn.enter')+'组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="任务清单类型" prop="marcPLNTY">
              <el-input clearable v-model="form.marcPLNTY" :placeholder="$t('btn.enter')+'任务清单类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划版本" prop="marcPLVAR">
              <el-input clearable v-model="form.marcPLVAR" :placeholder="$t('btn.enter')+'计划版本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="marcPRCTR">
              <el-input clearable v-model="form.marcPRCTR" :placeholder="$t('btn.enter')+'利润中心'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="优先权 " prop="marcPREFE">
              <el-input clearable v-model="form.marcPREFE" :placeholder="$t('btn.enter')+'优先权 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="免税证书" prop="marcPRENC">
              <el-input clearable v-model="form.marcPRENC" :placeholder="$t('btn.enter')+'免税证书'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发放证书日 " prop="marcPREND">
              <el-date-picker v-model="form.marcPREND" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商申报 " prop="marcPRENE">
              <el-input clearable v-model="form.marcPRENE" :placeholder="$t('btn.enter')+'供应商申报 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商申报日期" prop="marcPRENG">
              <el-date-picker v-model="form.marcPRENG" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="免税证书编号" prop="marcPRENO">
              <el-input clearable v-model="form.marcPRENO" :placeholder="$t('btn.enter')+'免税证书编号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查间隔 " prop="marcPRFRQ">
              <el-input clearable v-model="form.marcPRFRQ" :placeholder="$t('btn.enter')+'检查间隔 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="维护状态 " prop="marcPSTAT">
              <el-input clearable v-model="form.marcPSTAT" :placeholder="$t('btn.enter')+'维护状态 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QM 物料授权" prop="marcQMATA">
              <el-input clearable v-model="form.marcQMATA" :placeholder="$t('btn.enter')+'QM 物料授权'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验设置 " prop="marcQMATV">
              <el-input clearable v-model="form.marcQMATV" :placeholder="$t('btn.enter')+'检验设置 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="目标 QM 系统" prop="marcQSSYS">
              <el-input clearable v-model="form.marcQSSYS" :placeholder="$t('btn.enter')+'目标 QM 系统'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="隔离" prop="marcQUAZT">
              <el-input clearable v-model="form.marcQUAZT" :placeholder="$t('btn.enter')+'隔离'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="证书类型" prop="marcQZGTP">
              <el-input clearable v-model="form.marcQZGTP" :placeholder="$t('btn.enter')+'证书类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="舍入参数文件" prop="marcRDPRF">
              <el-input clearable v-model="form.marcRDPRF" :placeholder="$t('btn.enter')+'舍入参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="确定方案" prop="marcrefSchema">
              <el-input clearable v-model="form.marcrefSchema" :placeholder="$t('btn.enter')+'确定方案'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="调整期间" prop="marcRESVP">
              <el-input clearable v-model="form.marcRESVP" :placeholder="$t('btn.enter')+'调整期间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="反冲" prop="marcRGEKZ">
              <el-input clearable v-model="form.marcRGEKZ" :placeholder="$t('btn.enter')+'反冲'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存入库/出库" prop="marcrotationDate">
              <el-input clearable v-model="form.marcrotationDate" :placeholder="$t('btn.enter')+'库存入库/出库'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="准备时间" prop="marcRUEZT">
              <el-input clearable v-model="form.marcRUEZT" :placeholder="$t('btn.enter')+'准备时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供货天数参文件" prop="marcRWPRO">
              <el-input clearable v-model="form.marcRWPRO" :placeholder="$t('btn.enter')+'供货天数参文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="重复生产" prop="marcSAUFT">
              <el-input clearable v-model="form.marcSAUFT" :placeholder="$t('btn.enter')+'重复生产'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="独立/集中" prop="marcSBDKZ">
              <el-input clearable v-model="form.marcSBDKZ" :placeholder="$t('btn.enter')+'独立/集中'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="散装物料" prop="marcSCHGT">
              <el-input clearable v-model="form.marcSCHGT" :placeholder="$t('btn.enter')+'散装物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号参数文件" prop="marcSERNP">
              <el-input clearable v-model="form.marcSERNP" :placeholder="$t('btn.enter')+'序列号参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="服务水平" prop="marcSERVG">
              <el-input clearable v-model="form.marcSERVG" :placeholder="$t('btn.enter')+'服务水平'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产参数文 " prop="marcSFCPF">
              <el-input clearable v-model="form.marcSFCPF" :placeholder="$t('btn.enter')+'生产参数文 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="REM 参数文件" prop="marcSFEPR">
              <el-input clearable v-model="form.marcSFEPR" :placeholder="$t('btn.enter')+'REM 参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="离散批次编号" prop="marcsgtChint">
              <el-input clearable v-model="form.marcsgtChint" :placeholder="$t('btn.enter')+'离散批次编号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段策略" prop="marcsgtCovs">
              <el-input clearable v-model="form.marcsgtCovs" :placeholder="$t('btn.enter')+'分段策略'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存排序方法" prop="marcsgtMrpsi">
              <el-input clearable v-model="form.marcsgtMrpsi" :placeholder="$t('btn.enter')+'库存排序方法'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="消耗优先级" prop="marcsgtPrcm">
              <el-input clearable v-model="form.marcsgtPrcm" :placeholder="$t('btn.enter')+'消耗优先级'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段范围" prop="marcsgtScope">
              <el-input clearable v-model="form.marcsgtScope" :placeholder="$t('btn.enter')+'分段范围'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段状态 MRP" prop="marcsgtStatc">
              <el-input clearable v-model="form.marcsgtStatc" :placeholder="$t('btn.enter')+'分段状态 MRP'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存保护" prop="marcsgtStkPrt">
              <el-input clearable v-model="form.marcsgtStkPrt" :placeholder="$t('btn.enter')+'库存保护'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="安全时间标识" prop="marcSHFLG">
              <el-input clearable v-model="form.marcSHFLG" :placeholder="$t('btn.enter')+'安全时间标识'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ST 期间参数文件" prop="marcSHPRO">
              <el-input clearable v-model="form.marcSHPRO" :placeholder="$t('btn.enter')+'ST 期间参数文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="安全时间" prop="marcSHZET">
              <el-input clearable v-model="form.marcSHZET" :placeholder="$t('btn.enter')+'安全时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特殊工艺类型" prop="marcSOBSK">
              <el-input clearable v-model="form.marcSOBSK" :placeholder="$t('btn.enter')+'特殊工艺类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特殊采购" prop="marcSOBSL">
              <el-input clearable v-model="form.marcSOBSL" :placeholder="$t('btn.enter')+'特殊采购'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="样本%" prop="marcSPROZ">
              <el-input clearable v-model="form.marcSPROZ" :placeholder="$t('btn.enter')+'样本%'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QM 控制码 " prop="marcSSQSS">
              <el-input clearable v-model="form.marcSSQSS" :placeholder="$t('btn.enter')+'QM 控制码 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Comm./imp. code" prop="marcSTAWN">
              <el-input clearable v-model="form.marcSTAWN" :placeholder="$t('btn.enter')+'Comm./imp. code'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可配置的物料" prop="marcSTDPD">
              <el-input clearable v-model="form.marcSTDPD" :placeholder="$t('btn.enter')+'可配置的物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="控制代码" prop="marcSTEUC">
              <el-input clearable v-model="form.marcSTEUC" :placeholder="$t('btn.enter')+'控制代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备选 " prop="marcSTLAL">
              <el-input clearable v-model="form.marcSTLAL" :placeholder="$t('btn.enter')+'备选 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用途 " prop="marcSTLAN">
              <el-input clearable v-model="form.marcSTLAN" :placeholder="$t('btn.enter')+'用途 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="策略组 " prop="marcSTRGR">
              <el-input clearable v-model="form.marcSTRGR" :placeholder="$t('btn.enter')+'策略组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间隔时间" prop="marcTAKZT">
              <el-input clearable v-model="form.marcTAKZT" :placeholder="$t('btn.enter')+'间隔时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="目标库存" prop="marctargetStock">
              <el-input clearable v-model="form.marctargetStock" :placeholder="$t('btn.enter')+'目标库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="在途库存 " prop="marcTRAME">
              <el-input clearable v-model="form.marcTRAME" :placeholder="$t('btn.enter')+'在途库存 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工序间 " prop="marcTRANZ">
              <el-input clearable v-model="form.marcTRANZ" :placeholder="$t('btn.enter')+'工序间 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="OB管理" prop="marcUCHKZ">
              <el-input clearable v-model="form.marcUCHKZ" :placeholder="$t('btn.enter')+'OB管理'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="OB参考物料 " prop="marcUCMAT">
              <el-input clearable v-model="form.marcUCMAT" :placeholder="$t('btn.enter')+'OB参考物料 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="无限的 " prop="marcUEETK">
              <el-input clearable v-model="form.marcUEETK" :placeholder="$t('btn.enter')+'无限的 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过度交货允差" prop="marcUEETO">
              <el-input clearable v-model="form.marcUEETO" :placeholder="$t('btn.enter')+'过度交货允差'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部分配" prop="marcuidIea">
              <el-input clearable v-model="form.marcuidIea" :placeholder="$t('btn.enter')+'外部分配'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="中转库存" prop="marcUMLMC">
              <el-input clearable v-model="form.marcUMLMC" :placeholder="$t('btn.enter')+'中转库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转换组 " prop="marcUMRSL">
              <el-input clearable v-model="form.marcUMRSL" :placeholder="$t('btn.enter')+'转换组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不足交货允差" prop="marcUNETO">
              <el-input clearable v-model="form.marcUNETO" :placeholder="$t('btn.enter')+'不足交货允差'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计量单位组 " prop="marcUOMGR">
              <el-input clearable v-model="form.marcUOMGR" :placeholder="$t('btn.enter')+'计量单位组 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="配额使用安排" prop="marcUSEQU">
              <el-input clearable v-model="form.marcUSEQU" :placeholder="$t('btn.enter')+'配额使用安排'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基准数量" prop="marcVBAMG">
              <el-input clearable v-model="form.marcVBAMG" :placeholder="$t('btn.enter')+'基准数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理时间" prop="marcVBEAZ">
              <el-input clearable v-model="form.marcVBEAZ" :placeholder="$t('btn.enter')+'处理时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="版本" prop="marcVERKZ">
              <el-input clearable v-model="form.marcVERKZ" :placeholder="$t('btn.enter')+'版本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="逆向消耗期间 " prop="marcVINT1">
              <el-input clearable v-model="form.marcVINT1" :placeholder="$t('btn.enter')+'逆向消耗期间 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="向前消耗期间 " prop="marcVINT2">
              <el-input clearable v-model="form.marcVINT2" :placeholder="$t('btn.enter')+'向前消耗期间 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="SlsVal.TiedEmpt" prop="marcVKGLG">
              <el-input clearable v-model="form.marcVKGLG" :placeholder="$t('btn.enter')+'SlsVal.TiedEmpt'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="运输库存/SP" prop="marcVKTRW">
              <el-input clearable v-model="form.marcVKTRW" :placeholder="$t('btn.enter')+'运输库存/SP'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存转移 SV" prop="marcVKUMC">
              <el-input clearable v-model="form.marcVKUMC" :placeholder="$t('btn.enter')+'库存转移 SV'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期到 " prop="marcVRBDT">
              <el-date-picker v-model="form.marcVRBDT" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="乘数" prop="marcVRBFK">
              <el-input clearable v-model="form.marcVRBFK" :placeholder="$t('btn.enter')+'乘数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考物料:消耗 " prop="marcVRBMT">
              <el-input clearable v-model="form.marcVRBMT" :placeholder="$t('btn.enter')+'参考物料:消耗 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考工厂：寄存" prop="marcVRBWK">
              <el-input clearable v-model="form.marcVRBWK" :placeholder="$t('btn.enter')+'参考工厂：寄存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="消耗模式 " prop="marcVRMOD">
              <el-input clearable v-model="form.marcVRMOD" :placeholder="$t('btn.enter')+'消耗模式 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="准备时间" prop="marcVRVEZ">
              <el-input clearable v-model="form.marcVRVEZ" :placeholder="$t('btn.enter')+'准备时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="提议供应区域" prop="marcVSPVB">
              <el-input clearable v-model="form.marcVSPVB" :placeholder="$t('btn.enter')+'提议供应区域'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="附加费 %" prop="marcVZUSL">
              <el-input clearable v-model="form.marcVZUSL" :placeholder="$t('btn.enter')+'附加费 %'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="收货处理时间" prop="marcWEBAZ">
              <el-input clearable v-model="form.marcWEBAZ" :placeholder="$t('btn.enter')+'收货处理时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="marcWERKS">
              <el-input clearable v-model="form.marcWERKS" :placeholder="$t('btn.enter')+'工厂'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="活动性物质 " prop="marcWSTGH">
              <el-input clearable v-model="form.marcWSTGH" :placeholder="$t('btn.enter')+'活动性物质 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总补货提前时间" prop="marcWZEIT">
              <el-input clearable v-model="form.marcWZEIT" :placeholder="$t('btn.enter')+'总补货提前时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="marcXCHAR">
              <el-input clearable v-model="form.marcXCHAR" :placeholder="$t('btn.enter')+'批次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次管理需求 " prop="marcXCHPF">
              <el-input clearable v-model="form.marcXCHPF" :placeholder="$t('btn.enter')+'批次管理需求 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="负的库存" prop="marcXMCNG">
              <el-input clearable v-model="form.marcXMCNG" :placeholder="$t('btn.enter')+'负的库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="reMarks">
              <el-input type="textarea" v-model="form.reMarks" placeholder="请输入备注"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
          </el-tab-pane>


          <el-tab-pane :label="$t('ptabs.Onboarding')" name="second">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.qualifications')" name="third">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.annex')" name="fourth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.content')" name="fifth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.trade')" name="sixth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.bank')" name="seventh">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.contact')" name="eighth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.customization')" name="ninth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.subInfo')" name="tenth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
        </el-tabs>

      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="mmmarc">
import { listMmMarc,
 addMmMarc, delMmMarc, 
 updateMmMarc,getMmMarc, 
 } 
from '@/api/material/mmmarc.js'
import importData from '@/components/ImportData'
  //防抖处理函数 import { debounce } from 'lodash';
import { debounce } from 'lodash';
  //获取当前组件实例
const { proxy } = getCurrentInstance()
 //选中refId数组数组
const ids = ref([])
// 是否加载动画
const loading = ref(false)
// 显示搜索条件
const showSearch = ref(true)
//使用reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const queryParams = reactive({
  pageNum: 1,
  pageSize: 14,
  sort: '',
  sortType: 'asc',
})
//字段显示控制
const columns = ref([
  { visible: false, prop: 'marcGuid', label: 'ID主键' },

  { visible: true, prop: 'marcABCIN', label: 'CC 库存盘点' },
  { visible: true, prop: 'marcABFAC', label: '空气浮力因子' },
  { visible: true, prop: 'marcAHDIS', label: 'MRP 相关需求 ' },
  { visible: true, prop: 'marcALTSL', label: '选择方法' },
  { visible: true, prop: 'marcAPLAL', label: '组计数器' },
  { visible: true, prop: 'marcAPOKZ', label: '相关于 APO' },
  { visible: true, prop: 'marcATPKZ', label: '替换部件' },
  { visible: true, prop: 'marcAUFTL', label: '分割标识' },
  { visible: false, prop: 'marcAUSDT', label: '中断日期' },
  { visible: false, prop: 'marcAUSME', label: '发货单位' },
  { visible: false, prop: 'marcAUSSS', label: '装配报废' },
  { visible: false, prop: 'marcAUTRU', label: '自动重置' },
  { visible: false, prop: 'marcAWSLS', label: '差异码 ' },
  { visible: false, prop: 'marcBASMG', label: '基准数量' },
  { visible: false, prop: 'marcBEARZ', label: '处理时间' },
  { visible: false, prop: 'marcBESKZ', label: '采购' },
  { visible: false, prop: 'marcBSTFE', label: '固定批量大小' },
  { visible: false, prop: 'marcBSTMA', label: '最大批量 ' },
  { visible: false, prop: 'marcBSTMI', label: '最小批量大小 ' },
  { visible: false, prop: 'marcBSTRF', label: '舍入值 ' },
  { visible: false, prop: 'marcBWESB', label: '评估收货锁定库存' },
  { visible: false, prop: 'marcBWSCL', label: '货源' },
  { visible: false, prop: 'marcBWTTY', label: '评估类别' },
  { visible: false, prop: 'marcCASNR', label: 'CAS 号（药品） ' },
  { visible: false, prop: 'marcCCFIX', label: '周期标识被固定' },
  { visible: false, prop: 'marcCOMPL', label: '该字段不再使用' },
  { visible: false, prop: 'marcconsProcg', label: '寄售控制' },
  { visible: false, prop: 'marcCONVT', label: '转换类型' },
  { visible: false, prop: 'marcCOPAM', label: '字段名 ' },
  { visible: false, prop: 'marcCUOBJ', label: '内部对象号 ' },
  { visible: false, prop: 'marcCUOBV', label: '内部对象号 ' },
  { visible: false, prop: 'marcDIBER', label: 'MRP  范围存在' },
  { visible: false, prop: 'marcDISGR', label: 'MRP组 ' },
  { visible: false, prop: 'marcDISLS', label: '批量大小' },
  { visible: false, prop: 'marcDISMM', label: 'MRP 类型' },
  { visible: false, prop: 'marcDISPO', label: 'MRP 控制者 ' },
  { visible: false, prop: 'marcDISPR', label: 'MRP 参数文件' },
  { visible: false, prop: 'marcDPLFS', label: '公平分享规则' },
  { visible: false, prop: 'marcDPLHO', label: '发布界限' },
  { visible: false, prop: 'marcDPLPU', label: '推式分配' },
  { visible: false, prop: 'marcDZEIT', label: '厂内生产时间' },
  { visible: false, prop: 'marcEISBE', label: '安全库存' },
  { visible: false, prop: 'marcEISLO', label: '最小安全库存 ' },
  { visible: false, prop: 'marcEKGRP', label: '采购组 ' },
  { visible: false, prop: 'marcEPRIO', label: '库存确定组 ' },
  { visible: false, prop: 'marcEXPME', label: '商品代码单位' },
  { visible: false, prop: 'marcFABKZ', label: 'JIT 标识' },
  { visible: false, prop: 'marcFEVOR', label: '生产管理员 ' },
  { visible: false, prop: 'marcFFREI', label: '自动批准' },
  { visible: false, prop: 'marcFHORI', label: '计划边际码 ' },
  { visible: false, prop: 'marcFIXLS', label: '固定批量大小' },
  { visible: false, prop: 'marcFPRFM', label: '分配 prof.' },
  { visible: false, prop: 'marcFRTME', label: '生产单位' },
  { visible: false, prop: 'marcfshMgArunReq', label: '订单分配运行' },
  { visible: false, prop: 'marcfshSeaim', label: '库存管理中激活季节' },
  { visible: false, prop: 'marcFVIDK', label: '生产版本' },
  { visible: false, prop: 'marcFXHOR', label: '计划的时界 ' },
  { visible: false, prop: 'marcFXPRU', label: '固定价格联产品' },
  { visible: false, prop: 'marcgiPrTime', label: '发货处理时间' },
  { visible: false, prop: 'marcGLGMG', label: '有约束的虚拟' },
  { visible: false, prop: 'marcGPMKZ', label: '粗略计划' },
  { visible: false, prop: 'marcGPNUM', label: 'PRODCOM号 ' },
  { visible: false, prop: 'marcHERBL', label: '生产状态 ' },
  { visible: false, prop: 'marcHERKL', label: '原产地国' },
  { visible: false, prop: 'marcHERKR', label: '货源地 ' },
  { visible: false, prop: 'marcINDUS', label: '物料类别' },
  { visible: false, prop: 'marcINSMK', label: '过帐到检验库存' },
  { visible: false, prop: 'marcITARK', label: '军用物资' },
  { visible: false, prop: 'marciuidRelevant', label: 'IUID 相关' },
  { visible: false, prop: 'marciuidType', label: 'IUID 类型' },
  { visible: false, prop: 'marcKAUSF', label: '组件报废' },
  { visible: false, prop: 'marcKAUTB', label: '自动采购单 ' },
  { visible: false, prop: 'marcKORDB', label: '源清单 ' },
  { visible: false, prop: 'marcKZAGL', label: '平滑促销消耗 ' },
  { visible: false, prop: 'marcKZAUS', label: '非连续标识 ' },
  { visible: false, prop: 'marcKZBED', label: '需求分组 ' },
  { visible: false, prop: 'marcKZDIE', label: 'MRP控制者=买者 ' },
  { visible: false, prop: 'marcKZDKZ', label: '凭证需求 ' },
  { visible: false, prop: 'marcKZECH', label: '输入批量' },
  { visible: false, prop: 'marcKZKFK', label: '修正因子' },
  { visible: false, prop: 'marcKZKRI', label: '关键组件' },
  { visible: false, prop: 'marcKZKUP', label: '联产品 ' },
  { visible: false, prop: 'marcKZPPV', label: '检查计划标识 ' },
  { visible: false, prop: 'marcKZPRO', label: '从产品货位提取' },
  { visible: false, prop: 'marcKZPSP', label: '跨项目 ' },
  { visible: false, prop: 'marcLADGR', label: '装载组 ' },
  { visible: false, prop: 'marcLAGPR', label: '库存成本' },
  { visible: false, prop: 'marcLFGJA', label: '年  当前期间' },
  { visible: false, prop: 'marcLFMON', label: '本期' },
  { visible: false, prop: 'marcLFRHY', label: '计划周期' },
  { visible: false, prop: 'marcLGFSB', label: '外部采购仓储地' },
  { visible: false, prop: 'marcLGPRO', label: '生产仓储地点' },
  { visible: false, prop: 'marcLGRAD', label: '服务水平' },
  { visible: false, prop: 'marcLIZYK', label: '取消激活的' },
  { visible: false, prop: 'marcLOGGR', label: '后勤组 ' },
  { visible: false, prop: 'marcLOSFX', label: '订购成本' },
  { visible: false, prop: 'marcLOSGR', label: '成本核算批量' },
  { visible: false, prop: 'marcLTINC', label: '批尺寸增加 ' },
  { visible: false, prop: 'marcLVORM', label: '工厂级 DF' },
  { visible: false, prop: 'marcLZEIH', label: '时间单位' },
  { visible: false, prop: 'marcMAABC', label: 'ABC 标识' },
  { visible: false, prop: 'marcMABST', label: '最大库存水平 ' },
  { visible: false, prop: 'marcMANDT', label: '集团' },
  { visible: false, prop: 'marcMATGR', label: '物料分组' },
  { visible: false, prop: 'marcMATNR', label: '物料' },
  { visible: false, prop: 'marcmaxTroc', label: '最大目标范围 ' },
  { visible: false, prop: 'marcMAXLS', label: '最大批量大小 ' },
  { visible: false, prop: 'marcMAXLZ', label: '最大存储期间 ' },
  { visible: false, prop: 'marcMCRUE', label: '最后的MARD 期间之前，MARDH 记' },
  { visible: false, prop: 'marcMDACH', label: '活动控制' },
  { visible: false, prop: 'marcMEGRU', label: '计量单位组 ' },
  { visible: false, prop: 'marcMFRGR', label: '物料运输组 ' },
  { visible: false, prop: 'marcminTroc', label: '最小目标范围 ' },
  { visible: false, prop: 'marcMINBE', label: '再订货点' },
  { visible: false, prop: 'marcMINLS', label: '最小批量大小 ' },
  { visible: false, prop: 'marcMISKZ', label: '综合MRP' },
  { visible: false, prop: 'marcMMSTA', label: 'P-S 物料状态 ' },
  { visible: false, prop: 'marcMMSTD', label: '有效起始期 ' },
  { visible: false, prop: 'marcMOGRU', label: 'CAP 产品组 ' },
  { visible: false, prop: 'marcMOWNR', label: 'EU 产品清单编号' },
  { visible: false, prop: 'marcMPDAU', label: '平均检查持续期' },
  { visible: false, prop: 'marcMRPPP', label: '计划日历' },
  { visible: false, prop: 'marcMTVER', label: '出口/进口组 ' },
  { visible: false, prop: 'marcMTVFP', label: '可用性检查 ' },
  { visible: false, prop: 'marcmultipleEkgrp', label: '交叉的采购组' },
  { visible: false, prop: 'marcNCOST', label: '无成本核算 ' },
  { visible: false, prop: 'marcNFMAT', label: '后继物料' },
  { visible: false, prop: 'marcNKMPR', label: '下一次检查 ' },
  { visible: false, prop: 'marcOBJID', label: '对象标识' },
  { visible: false, prop: 'marcOCMPF', label: '总体参数文件' },
  { visible: false, prop: 'marcOTYPE', label: '对象类型' },
  { visible: false, prop: 'marcPERIV', label: '会计年度变式' },
  { visible: false, prop: 'marcPERKZ', label: '期间标识' },
  { visible: false, prop: 'marcPFREI', label: '自动更改工厂订单' },
  { visible: false, prop: 'marcPLIFZ', label: '计划交货时间' },
  { visible: false, prop: 'marcPLNNR', label: '组 ' },
  { visible: false, prop: 'marcPLNTY', label: '任务清单类型' },
  { visible: false, prop: 'marcPLVAR', label: '计划版本' },
  { visible: false, prop: 'marcPRCTR', label: '利润中心' },
  { visible: false, prop: 'marcPREFE', label: '优先权 ' },
  { visible: false, prop: 'marcPRENC', label: '免税证书' },
  { visible: false, prop: 'marcPREND', label: '发放证书日 ' },
  { visible: false, prop: 'marcPRENE', label: '供应商申报 ' },
  { visible: false, prop: 'marcPRENG', label: '供应商申报日期' },
  { visible: false, prop: 'marcPRENO', label: '免税证书编号' },
  { visible: false, prop: 'marcPRFRQ', label: '检查间隔 ' },
  { visible: false, prop: 'marcPSTAT', label: '维护状态 ' },
  { visible: false, prop: 'marcQMATA', label: 'QM 物料授权' },
  { visible: false, prop: 'marcQMATV', label: '检验设置 ' },
  { visible: false, prop: 'marcQSSYS', label: '目标 QM 系统' },
  { visible: false, prop: 'marcQUAZT', label: '隔离' },
  { visible: false, prop: 'marcQZGTP', label: '证书类型' },
  { visible: false, prop: 'marcRDPRF', label: '舍入参数文件' },
  { visible: false, prop: 'marcrefSchema', label: '确定方案' },
  { visible: false, prop: 'marcRESVP', label: '调整期间' },
  { visible: false, prop: 'marcRGEKZ', label: '反冲' },
  { visible: false, prop: 'marcrotationDate', label: '库存入库/出库' },
  { visible: false, prop: 'marcRUEZT', label: '准备时间' },
  { visible: false, prop: 'marcRWPRO', label: '供货天数参文件' },
  { visible: false, prop: 'marcSAUFT', label: '重复生产' },
  { visible: false, prop: 'marcSBDKZ', label: '独立/集中' },
  { visible: false, prop: 'marcSCHGT', label: '散装物料' },
  { visible: false, prop: 'marcSERNP', label: '序列号参数文件' },
  { visible: false, prop: 'marcSERVG', label: '服务水平' },
  { visible: false, prop: 'marcSFCPF', label: '生产参数文 ' },
  { visible: false, prop: 'marcSFEPR', label: 'REM 参数文件' },
  { visible: false, prop: 'marcsgtChint', label: '离散批次编号' },
  { visible: false, prop: 'marcsgtCovs', label: '分段策略' },
  { visible: false, prop: 'marcsgtMrpsi', label: '库存排序方法' },
  { visible: false, prop: 'marcsgtPrcm', label: '消耗优先级' },
  { visible: false, prop: 'marcsgtScope', label: '分段范围' },
  { visible: false, prop: 'marcsgtStatc', label: '分段状态 MRP' },
  { visible: false, prop: 'marcsgtStkPrt', label: '库存保护' },
  { visible: false, prop: 'marcSHFLG', label: '安全时间标识' },
  { visible: false, prop: 'marcSHPRO', label: 'ST 期间参数文件' },
  { visible: false, prop: 'marcSHZET', label: '安全时间' },
  { visible: false, prop: 'marcSOBSK', label: '特殊工艺类型' },
  { visible: false, prop: 'marcSOBSL', label: '特殊采购' },
  { visible: false, prop: 'marcSPROZ', label: '样本%' },
  { visible: false, prop: 'marcSSQSS', label: 'QM 控制码 ' },
  { visible: false, prop: 'marcSTAWN', label: 'Comm./imp. code' },
  { visible: false, prop: 'marcSTDPD', label: '可配置的物料' },
  { visible: false, prop: 'marcSTEUC', label: '控制代码' },
  { visible: false, prop: 'marcSTLAL', label: '备选 ' },
  { visible: false, prop: 'marcSTLAN', label: '用途 ' },
  { visible: false, prop: 'marcSTRGR', label: '策略组 ' },
  { visible: false, prop: 'marcTAKZT', label: '间隔时间' },
  { visible: false, prop: 'marctargetStock', label: '目标库存' },
  { visible: false, prop: 'marcTRAME', label: '在途库存 ' },
  { visible: false, prop: 'marcTRANZ', label: '工序间 ' },
  { visible: false, prop: 'marcUCHKZ', label: 'OB管理' },
  { visible: false, prop: 'marcUCMAT', label: 'OB参考物料 ' },
  { visible: false, prop: 'marcUEETK', label: '无限的 ' },
  { visible: false, prop: 'marcUEETO', label: '过度交货允差' },
  { visible: false, prop: 'marcuidIea', label: '外部分配' },
  { visible: false, prop: 'marcUMLMC', label: '中转库存' },
  { visible: false, prop: 'marcUMRSL', label: '转换组 ' },
  { visible: false, prop: 'marcUNETO', label: '不足交货允差' },
  { visible: false, prop: 'marcUOMGR', label: '计量单位组 ' },
  { visible: false, prop: 'marcUSEQU', label: '配额使用安排' },
  { visible: false, prop: 'marcVBAMG', label: '基准数量' },
  { visible: false, prop: 'marcVBEAZ', label: '处理时间' },
  { visible: false, prop: 'marcVERKZ', label: '版本' },
  { visible: false, prop: 'marcVINT1', label: '逆向消耗期间 ' },
  { visible: false, prop: 'marcVINT2', label: '向前消耗期间 ' },
  { visible: false, prop: 'marcVKGLG', label: 'SlsVal.TiedEmpt' },
  { visible: false, prop: 'marcVKTRW', label: '运输库存/SP' },
  { visible: false, prop: 'marcVKUMC', label: '库存转移 SV' },
  { visible: false, prop: 'marcVRBDT', label: '日期到 ' },
  { visible: false, prop: 'marcVRBFK', label: '乘数' },
  { visible: false, prop: 'marcVRBMT', label: '参考物料:消耗 ' },
  { visible: false, prop: 'marcVRBWK', label: '参考工厂：寄存' },
  { visible: false, prop: 'marcVRMOD', label: '消耗模式 ' },
  { visible: false, prop: 'marcVRVEZ', label: '准备时间' },
  { visible: false, prop: 'marcVSPVB', label: '提议供应区域' },
  { visible: false, prop: 'marcVZUSL', label: '附加费 %' },
  { visible: false, prop: 'marcWEBAZ', label: '收货处理时间' },
  { visible: false, prop: 'marcWERKS', label: '工厂' },
  { visible: false, prop: 'marcWSTGH', label: '活动性物质 ' },
  { visible: false, prop: 'marcWZEIT', label: '总补货提前时间' },
  { visible: false, prop: 'marcXCHAR', label: '批次' },
  { visible: false, prop: 'marcXCHPF', label: '批次管理需求 ' },
  { visible: false, prop: 'marcXMCNG', label: '负的库存' },
  { visible: false, prop: 'reMarks', label: '备注' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
])
// 记录数
const total = ref(0)
// 定义工厂物料数据表格数据变量
const dataList = ref([])
// 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

//字典参数
var dictParams = [
]
//字典加载
//API获取工厂物料数据/mm_marc表记录数据
function getList(){
  loading.value = true
  listMmMarc(queryParams).then(res => {
    const { code, data } = res
    if (code == 200) {
      dataList.value = data.result
      total.value = data.totalNum
      loading.value = false
    }
  })
}

// 查询
function handleQuery() {
  queryParams.pageNum = 1
  getList()
}

// 重置查询操作
function resetQuery(){
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.marcGuid);
  single.value = selection.length != 1
  multiple.value = !selection.length;
}
// 自定义排序
function sortChange(column) {
  var sort = undefined
  var sortType = undefined

  if (column.prop != null && column.order != null) {
    sort = column.prop
    sortType = column.order

  }
  queryParams.sort = sort
  queryParams.sortType = sortType
  handleQuery()
}

/*************** form操作 ***************/
//定义响应式变量
const formRef = ref()
// 弹出层标题
const title = ref('')
// 操作类型 1、add 2、edit 3、view
//定义响应式变量
const opertype = ref(0)
//定义对话框打开或关闭
const open = ref(false)
//reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const state = reactive({
  single: true,
  multiple: true,
  form: {},
  rules: {
    marcGuid: [{ required: true, message: "ID主键+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcABFAC: [{ required: true, message: "空气浮力因子+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcAUSSS: [{ required: true, message: "装配报废+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcBASMG: [{ required: true, message: "基准数量+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcBEARZ: [{ required: true, message: "处理时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcBESKZ: [{ required: true, message: "采购+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcBSTFE: [{ required: true, message: "固定批量大小+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcBSTMA: [{ required: true, message: "最大批量 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcBSTMI: [{ required: true, message: "最小批量大小 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcBSTRF: [{ required: true, message: "舍入值 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcBWESB: [{ required: true, message: "评估收货锁定库存+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcDISLS: [{ required: true, message: "批量大小+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcDISMM: [{ required: true, message: "MRP 类型+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcDPLHO: [{ required: true, message: "发布界限+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcDZEIT: [{ required: true, message: "厂内生产时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcEISBE: [{ required: true, message: "安全库存+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcEISLO: [{ required: true, message: "最小安全库存 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcEKGRP: [{ required: true, message: "采购组 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcFIXLS: [{ required: true, message: "固定批量大小+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcgiPrTime: [{ required: true, message: "发货处理时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcGLGMG: [{ required: true, message: "有约束的虚拟+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcINSMK: [{ required: true, message: "过帐到检验库存+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcKAUSF: [{ required: true, message: "组件报废+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcLGFSB: [{ required: true, message: "外部采购仓储地+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcLGPRO: [{ required: true, message: "生产仓储地点+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcLGRAD: [{ required: true, message: "服务水平+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcLOSFX: [{ required: true, message: "订购成本+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcLOSGR: [{ required: true, message: "成本核算批量+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcLTINC: [{ required: true, message: "批尺寸增加 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcMABST: [{ required: true, message: "最大库存水平 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcMANDT: [{ required: true, message: "集团+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcMATNR: [{ required: true, message: "物料+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcMAXLS: [{ required: true, message: "最大批量大小 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcMAXLZ: [{ required: true, message: "最大存储期间 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcMINBE: [{ required: true, message: "再订货点+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcMINLS: [{ required: true, message: "最小批量大小 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcMPDAU: [{ required: true, message: "平均检查持续期+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcMTVFP: [{ required: true, message: "可用性检查 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcPLIFZ: [{ required: true, message: "计划交货时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcPRCTR: [{ required: true, message: "利润中心+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcPRFRQ: [{ required: true, message: "检查间隔 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcQUAZT: [{ required: true, message: "隔离+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcRESVP: [{ required: true, message: "调整期间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcRUEZT: [{ required: true, message: "准备时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcSOBSL: [{ required: true, message: "特殊采购+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcSPROZ: [{ required: true, message: "样本%+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcTAKZT: [{ required: true, message: "间隔时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marctargetStock: [{ required: true, message: "目标库存+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcTRAME: [{ required: true, message: "在途库存 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcTRANZ: [{ required: true, message: "工序间 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcUEETO: [{ required: true, message: "过度交货允差+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcUMLMC: [{ required: true, message: "中转库存+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcUNETO: [{ required: true, message: "不足交货允差+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcVBAMG: [{ required: true, message: "基准数量+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcVBEAZ: [{ required: true, message: "处理时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcVKGLG: [{ required: true, message: "SlsVal.TiedEmpt+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcVKTRW: [{ required: true, message: "运输库存/SP+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcVKUMC: [{ required: true, message: "库存转移 SV+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcVRBFK: [{ required: true, message: "乘数+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcVRVEZ: [{ required: true, message: "准备时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcVZUSL: [{ required: true, message: "附加费 %+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcWEBAZ: [{ required: true, message: "收货处理时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcWERKS: [{ required: true, message: "工厂+ proxy.$t('btn.empty')", trigger: "blur" }],
    marcWSTGH: [{ required: true, message: "活动性物质 + proxy.$t('btn.empty')", trigger: "blur" }],
    marcWZEIT: [{ required: true, message: "总补货提前时间+ proxy.$t('btn.empty')", trigger: "blur" }],
    uDF51: [{ required: true, message: "自定义1+ proxy.$t('btn.empty')", trigger: "blur" }],
    uDF52: [{ required: true, message: "自定义2+ proxy.$t('btn.empty')", trigger: "blur" }],
    uDF53: [{ required: true, message: "自定义3+ proxy.$t('btn.empty')", trigger: "blur" }],
    uDF54: [{ required: true, message: "自定义4+ proxy.$t('btn.empty')", trigger: "blur" }],
    uDF55: [{ required: true, message: "自定义5+ proxy.$t('btn.empty')", trigger: "blur" }],
    uDF56: [{ required: true, message: "自定义6+ proxy.$t('btn.empty')", trigger: "blur" }],
    isDeleted: [{ required: true, message: "软删除+ proxy.$t('btn.empty')", trigger: "blur", type: "number" }],
  },
  options: {
    // MRP 相关需求  选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    marcAHDISOptions: [],
    // IUID 类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    marciuidTypeOptions: [],
    // 对象类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    marcOTYPEOptions: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    isDeletedOptions: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options, single, multiple } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    marcGuid: null,
    marcABCIN: null,
    marcABFAC: null,
    marcAHDIS: null,
    marcALTSL: null,
    marcAPLAL: null,
    marcAPOKZ: null,
    marcATPKZ: null,
    marcAUFTL: null,
    marcAUSDT: null,
    marcAUSME: null,
    marcAUSSS: null,
    marcAUTRU: null,
    marcAWSLS: null,
    marcBASMG: null,
    marcBEARZ: null,
    marcBESKZ: null,
    marcBSTFE: null,
    marcBSTMA: null,
    marcBSTMI: null,
    marcBSTRF: null,
    marcBWESB: null,
    marcBWSCL: null,
    marcBWTTY: null,
    marcCASNR: null,
    marcCCFIX: null,
    marcCOMPL: null,
    marcconsProcg: null,
    marcCONVT: null,
    marcCOPAM: null,
    marcCUOBJ: null,
    marcCUOBV: null,
    marcDIBER: null,
    marcDISGR: null,
    marcDISLS: null,
    marcDISMM: null,
    marcDISPO: null,
    marcDISPR: null,
    marcDPLFS: null,
    marcDPLHO: null,
    marcDPLPU: null,
    marcDZEIT: null,
    marcEISBE: null,
    marcEISLO: null,
    marcEKGRP: null,
    marcEPRIO: null,
    marcEXPME: null,
    marcFABKZ: null,
    marcFEVOR: null,
    marcFFREI: null,
    marcFHORI: null,
    marcFIXLS: null,
    marcFPRFM: null,
    marcFRTME: null,
    marcfshMgArunReq: null,
    marcfshSeaim: null,
    marcFVIDK: null,
    marcFXHOR: null,
    marcFXPRU: null,
    marcgiPrTime: null,
    marcGLGMG: null,
    marcGPMKZ: null,
    marcGPNUM: null,
    marcHERBL: null,
    marcHERKL: null,
    marcHERKR: null,
    marcINDUS: null,
    marcINSMK: null,
    marcITARK: null,
    marciuidRelevant: null,
    marciuidType: null,
    marcKAUSF: null,
    marcKAUTB: null,
    marcKORDB: null,
    marcKZAGL: null,
    marcKZAUS: null,
    marcKZBED: null,
    marcKZDIE: null,
    marcKZDKZ: null,
    marcKZECH: null,
    marcKZKFK: null,
    marcKZKRI: null,
    marcKZKUP: null,
    marcKZPPV: null,
    marcKZPRO: null,
    marcKZPSP: null,
    marcLADGR: null,
    marcLAGPR: null,
    marcLFGJA: null,
    marcLFMON: null,
    marcLFRHY: null,
    marcLGFSB: null,
    marcLGPRO: null,
    marcLGRAD: null,
    marcLIZYK: null,
    marcLOGGR: null,
    marcLOSFX: null,
    marcLOSGR: null,
    marcLTINC: null,
    marcLVORM: null,
    marcLZEIH: null,
    marcMAABC: null,
    marcMABST: null,
    marcMANDT: null,
    marcMATGR: null,
    marcMATNR: null,
    marcmaxTroc: null,
    marcMAXLS: null,
    marcMAXLZ: null,
    marcMCRUE: null,
    marcMDACH: null,
    marcMEGRU: null,
    marcMFRGR: null,
    marcminTroc: null,
    marcMINBE: null,
    marcMINLS: null,
    marcMISKZ: null,
    marcMMSTA: null,
    marcMMSTD: null,
    marcMOGRU: null,
    marcMOWNR: null,
    marcMPDAU: null,
    marcMRPPP: null,
    marcMTVER: null,
    marcMTVFP: null,
    marcmultipleEkgrp: null,
    marcNCOST: null,
    marcNFMAT: null,
    marcNKMPR: null,
    marcOBJID: null,
    marcOCMPF: null,
    marcOTYPE: null,
    marcPERIV: null,
    marcPERKZ: null,
    marcPFREI: null,
    marcPLIFZ: null,
    marcPLNNR: null,
    marcPLNTY: null,
    marcPLVAR: null,
    marcPRCTR: null,
    marcPREFE: null,
    marcPRENC: null,
    marcPREND: null,
    marcPRENE: null,
    marcPRENG: null,
    marcPRENO: null,
    marcPRFRQ: null,
    marcPSTAT: null,
    marcQMATA: null,
    marcQMATV: null,
    marcQSSYS: null,
    marcQUAZT: null,
    marcQZGTP: null,
    marcRDPRF: null,
    marcrefSchema: null,
    marcRESVP: null,
    marcRGEKZ: null,
    marcrotationDate: null,
    marcRUEZT: null,
    marcRWPRO: null,
    marcSAUFT: null,
    marcSBDKZ: null,
    marcSCHGT: null,
    marcSERNP: null,
    marcSERVG: null,
    marcSFCPF: null,
    marcSFEPR: null,
    marcsgtChint: null,
    marcsgtCovs: null,
    marcsgtMrpsi: null,
    marcsgtPrcm: null,
    marcsgtScope: null,
    marcsgtStatc: null,
    marcsgtStkPrt: null,
    marcSHFLG: null,
    marcSHPRO: null,
    marcSHZET: null,
    marcSOBSK: null,
    marcSOBSL: null,
    marcSPROZ: null,
    marcSSQSS: null,
    marcSTAWN: null,
    marcSTDPD: null,
    marcSTEUC: null,
    marcSTLAL: null,
    marcSTLAN: null,
    marcSTRGR: null,
    marcTAKZT: null,
    marctargetStock: null,
    marcTRAME: null,
    marcTRANZ: null,
    marcUCHKZ: null,
    marcUCMAT: null,
    marcUEETK: null,
    marcUEETO: null,
    marcuidIea: null,
    marcUMLMC: null,
    marcUMRSL: null,
    marcUNETO: null,
    marcUOMGR: null,
    marcUSEQU: null,
    marcVBAMG: null,
    marcVBEAZ: null,
    marcVERKZ: null,
    marcVINT1: null,
    marcVINT2: null,
    marcVKGLG: null,
    marcVKTRW: null,
    marcVKUMC: null,
    marcVRBDT: null,
    marcVRBFK: null,
    marcVRBMT: null,
    marcVRBWK: null,
    marcVRMOD: null,
    marcVRVEZ: null,
    marcVSPVB: null,
    marcVZUSL: null,
    marcWEBAZ: null,
    marcWERKS: null,
    marcWSTGH: null,
    marcWZEIT: null,
    marcXCHAR: null,
    marcXCHPF: null,
    marcXMCNG: null,
    uDF01: null,
    uDF02: null,
    uDF03: null,
    uDF04: null,
    uDF05: null,
    uDF06: null,
    uDF51: null,
    uDF52: null,
    uDF53: null,
    uDF54: null,
    uDF55: null,
    uDF56: null,
    isDeleted: null,
    reMarks: null,
    createBy: null,
    createTime: null,
    updateBy: null,
    updateTime: null,
  };
  proxy.resetForm("formRef")
}
// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+'工厂物料数据'
  opertype.value = 1
  form.value.marcGuid= crypto.randomUUID()
  form.value.marcABFAC= 0
  form.value.marcAHDIS= 0
  form.value.marcAUSDT= new Date()
  form.value.marcAUSSS= 0
  form.value.marcBASMG= 0
  form.value.marcBEARZ= 0
  form.value.marcBSTFE= 0
  form.value.marcBSTMA= 0
  form.value.marcBSTMI= 0
  form.value.marcBSTRF= 0
  form.value.marcBWESB= 0
  form.value.marcDPLHO= 0
  form.value.marcDZEIT= 0
  form.value.marcEISBE= 0
  form.value.marcEISLO= 0
  form.value.marcFIXLS= 0
  form.value.marcgiPrTime= 0
  form.value.marcGLGMG= 0
  form.value.marciuidType= []
  form.value.marcKAUSF= 0
  form.value.marcLGRAD= 0
  form.value.marcLOSFX= 0
  form.value.marcLOSGR= 0
  form.value.marcLTINC= 0
  form.value.marcMABST= 0
  form.value.marcMAXLS= 0
  form.value.marcMAXLZ= 0
  form.value.marcMINBE= 0
  form.value.marcMINLS= 0
  form.value.marcMMSTD= new Date()
  form.value.marcMPDAU= 0
  form.value.marcNKMPR= new Date()
  form.value.marcOTYPE= []
  form.value.marcPLIFZ= 0
  form.value.marcPREND= new Date()
  form.value.marcPRENG= new Date()
  form.value.marcPRFRQ= 0
  form.value.marcQUAZT= 0
  form.value.marcRESVP= 0
  form.value.marcRUEZT= 0
  form.value.marcSPROZ= 0
  form.value.marcTAKZT= 0
  form.value.marctargetStock= 0
  form.value.marcTRAME= 0
  form.value.marcTRANZ= 0
  form.value.marcUEETO= 0
  form.value.marcUMLMC= 0
  form.value.marcUNETO= 0
  form.value.marcVBAMG= 0
  form.value.marcVBEAZ= 0
  form.value.marcVKGLG= 0
  form.value.marcVKTRW= 0
  form.value.marcVKUMC= 0
  form.value.marcVRBDT= new Date()
  form.value.marcVRBFK= 0
  form.value.marcVRVEZ= 0
  form.value.marcVZUSL= 0
  form.value.marcWEBAZ= 0
  form.value.marcWSTGH= 0
  form.value.marcWZEIT= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.marcGuid || ids.value
  getMmMarc(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+'工厂物料数据'
      opertype.value = 2

      form.value = {
        ...data,
      }
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      if (form.value.marcGuid != undefined && opertype.value === 2) {
        updateMmMarc(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addMmMarc(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.marcGuid || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delMmMarc(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
    })
}



// 导入数据成功处理
const handleFileSuccess = (response) => {
  const { item1, item2 } = response.data
  var error = ''
  item2.forEach((item) => {
    error += item.storageMessage + ','
  })
  proxy.$alert(item1 + '<p>' + error + '</p>', proxy.$t('btn.importResults'), {
    dangerouslyUseHTMLString: true
  })
  getList()
}

// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.confirmExport')+"工厂物料数据", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/material/MmMarc/export', { ...queryParams })
    })
}


handleQuery()
</script>