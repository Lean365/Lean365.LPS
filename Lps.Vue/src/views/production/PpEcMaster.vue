<!--
 * @Descripttion: (主设变/pp_ec_master)
 * @version: (4.0.0)
 * @Author: (Lean365)
 * @Date: (2023-09-15)
-->
<template>
  <div>
    <!-- 工具区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-form-item label="发行日">
        <el-date-picker
          v-model="dateRangeEmEcIssueDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions" size="small">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="设变No." prop="emEcNo">
        <el-input  clearable v-model="queryParams.emEcNo" :placeholder="$t('btn.enter')+'设变No.'" size="small"/>
      </el-form-item>
      <el-form-item label="状态" prop="emEcStatus">
        <el-radio-group v-model="queryParams.emEcStatus" size="small">
          <el-radio>{{$t('layout.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_ec_status " :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="担当" prop="emEcAssigned">
        <el-select filterable clearable  v-model="queryParams.emEcAssigned" :placeholder="$t('btn.select')+'担当'" size="small">
          <el-option v-for="item in  options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="管理区分" prop="emEcManageCategory">
        <el-select filterable clearable  v-model="queryParams.emEcManageCategory" :placeholder="$t('btn.select')+'管理区分'" size="small">
          <el-option v-for="item in  options.sys_ec_mgtype " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="输入日">
        <el-date-picker
          v-model="dateRangeEmEcEntryDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions" size="small">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="SOP" prop="esSopStae">
        <el-select filterable clearable  v-model="queryParams.esSopStae" :placeholder="$t('btn.select')+'SOP'" size="small">
          <el-option v-for="item in  options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" size="small" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" type="info" plain size="small" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:ecmaster:add']" plain icon="plus" size="small" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:ecmaster:edit']" plain icon="edit" size="small" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:ecmaster:delete']" plain icon="delete" size="small" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:ecmaster:import']" >
          <el-button color="#626aef" plain icon="Upload" size="small">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="production/PpEcMaster/importTemplate"
                  importUrl="/production/PpEcMaster/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport" v-hasPermi="['pp:ecmaster:export']">
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
      height="555" style="width: 100%" :summary-method="getSummaries" show-summary>
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button text @click="rowClick(scope.row)">{{ $t('btn.details') }}</el-button>
        </template>
      </el-table-column>
      <el-table-column prop="emGuid" label="Guid" align="center" v-if="columns.showColumn('emGuid')"/>
      <el-table-column prop="emEcIssueDate" label="发行日" :show-overflow-tooltip="true"  v-if="columns.showColumn('emEcIssueDate')"/>
      <el-table-column prop="emEcNo" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcNo')"/>
      <el-table-column prop="emEcDoc" label="关联文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcDoc')"/>
      <el-table-column prop="emEcStatus" label="状态" align="center" v-if="columns.showColumn('emEcStatus')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.emEcStatus"  />
        </template>
      </el-table-column>
      <el-table-column prop="emEcTitle" label="标题" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcTitle')"/>
      <el-table-column prop="emEcContent" label="内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcContent')"/>
      <el-table-column prop="emEcAssigned" label="担当" align="center" v-if="columns.showColumn('emEcAssigned')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.emEcAssigned"  />
        </template>
      </el-table-column>
      <el-table-column prop="emEcLossAmount" label="损失金额" align="center" v-if="columns.showColumn('emEcLossAmount')"/>
      <el-table-column prop="emEcManageCategory" label="管理区分" align="center" v-if="columns.showColumn('emEcManageCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_mgtype " :value="scope.row.emEcManageCategory"  />
        </template>
      </el-table-column>
      <el-table-column prop="emEcLiaisonNo" label="联络No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcLiaisonNo')"/>
      <el-table-column prop="emEcLiaisonDoc" label="联络文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcLiaisonDoc')"/>
      <el-table-column prop="emEcEppLiaisonNo" label="EppNo." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcEppLiaisonNo')"/>
      <el-table-column prop="emEcEppLiaisonDoc" label="Epp文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcEppLiaisonDoc')"/>
      <el-table-column prop="emEcFppLiaisonNo" label="FppNo." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcFppLiaisonNo')"/>
      <el-table-column prop="emEcFppLiaisonDoc" label="Fpp文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcFppLiaisonDoc')"/>
      <el-table-column prop="emEcExternalNo" label="外部No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcExternalNo')"/>
      <el-table-column prop="emEcExternalDoc" label="外部文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcExternalDoc')"/>
      <el-table-column prop="emEcImpDept" label="输入部门" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcImpDept')"/>
      <el-table-column prop="emEcEntryDate" label="输入日" :show-overflow-tooltip="true"  v-if="columns.showColumn('emEcEntryDate')"/>
      <el-table-column prop="esSopStae" label="SOP" align="center" v-if="columns.showColumn('esSopStae')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.esSopStae"  />
        </template>
      </el-table-column>
      <el-table-column prop="reMarks" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('reMarks')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column :label="$t('btn.operation')" width="180" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:ecmaster:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" icon="delete" plain :title="$t('btn.delete')" v-hasPermi="['pp:ecmaster:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <el-drawer v-model="drawer" :with-header="false" direction="btt">
      <el-table :data="ppEcSlaveList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="esGuid" label="Guid"/>
        <el-table-column prop="esEntryDate" label="输入日"/>
        <el-table-column prop="emEcNo" label="设变No."/>
        <el-table-column prop="esModel" label="机种"/>
        <el-table-column prop="esItem" label="物料"/>
        <el-table-column prop="esSubItem" label="子物料"/>
        <el-table-column prop="esOldItem" label="旧物料"/>
        <el-table-column prop="esOldItemText" label="旧文本"/>
        <el-table-column prop="esOldUsageQty" label="用量"/>
        <el-table-column prop="esOldSetLoc" label="位置"/>
        <el-table-column prop="esNewItem" label="新物料"/>
        <el-table-column prop="esNewItemText" label="新文本"/>
        <el-table-column prop="esNewUsageQty" label="用量"/>
        <el-table-column prop="esNewSetLoc" label="位置"/>
        <el-table-column prop="esBomNo" label="bom番号"/>
        <el-table-column prop="esChange" label="互换"/>
        <el-table-column prop="eslocal" label="区分"/>
        <el-table-column prop="esnote" label="指示"/>
        <el-table-column prop="esOldProcess" label="旧品处理"/>
        <el-table-column prop="esBomDate" label="bom日期"/>
        <el-table-column prop="emEcImpDept" label="实施部门"/>
        <el-table-column prop="esPurType" label="采购类型">
          <template #default="scope">
            <dict-tag :options=" options.sys_pur_type " :value="scope.row.esPurType"  />
          </template>
        </el-table-column>
        <el-table-column prop="esSloc" label="仓库">
          <template #default="scope">
            <dict-tag :options=" options.sys_sloc_list " :value="scope.row.esSloc"  />
          </template>
        </el-table-column>
        <el-table-column prop="esInsmk" label="检验否">
          <template #default="scope">
            <dict-tag :options=" options.sys_flag_list " :value="scope.row.esInsmk"  />
          </template>
        </el-table-column>
        <el-table-column prop="esMstae" label="工厂状态">
          <template #default="scope">
            <dict-tag :options=" options.sys_eol_type " :value="scope.row.esMstae"  />
          </template>
        </el-table-column>
        <el-table-column prop="esSopStae" label="SOP">
          <template #default="scope">
            <dict-tag :options=" options.sys_sop_yn " :value="scope.row.esSopStae"  />
          </template>
        </el-table-column>
        <el-table-column prop="esOldCurrStock" label="旧品库存"/>
        <el-table-column prop="esNewCurrStock" label="新品库存"/>
        <el-table-column prop="esPurEntryDate" label="采购登入日期"/>
        <el-table-column prop="esSupplier" label="供应商"/>
        <el-table-column prop="esPurOrder" label="采购PO"/>
        <el-table-column prop="esPurNote" label="说明"/>
        <el-table-column prop="esPurCreator" label="采购新增"/>
        <el-table-column prop="esPurCreateTime" label="采购新增日期"/>
        <el-table-column prop="esPurModifier" label="采购修改"/>
        <el-table-column prop="esPurModifyTime" label="采购修改日期"/>
        <el-table-column prop="esPmcEntryDate" label="生管登入日期"/>
        <el-table-column prop="esPmcLot" label="预投入批次"/>
        <el-table-column prop="esPmcMemo" label="说明"/>
        <el-table-column prop="esPmcNote" label="备注"/>
        <el-table-column prop="esPmcCreator" label="生管新增"/>
        <el-table-column prop="esPmcCreateTime" label="生管新增日期"/>
        <el-table-column prop="esPmcModifier" label="生管修改"/>
        <el-table-column prop="esPmcModifyTime" label="生管修改日期"/>
        <el-table-column prop="esIqcEntryDate" label="IQC登入日期"/>
        <el-table-column prop="esIqcOrder" label="检验订单"/>
        <el-table-column prop="esIqcNote" label="说明"/>
        <el-table-column prop="esIqcCreator" label="IQC新增"/>
        <el-table-column prop="esIqcCreateTime" label="IQC新增日期"/>
        <el-table-column prop="esIqcModifier" label="IQC修改"/>
        <el-table-column prop="esIqcModifyTime" label="IQC修改日期"/>
        <el-table-column prop="esMmEntryDate" label="部管登入日期"/>
        <el-table-column prop="esMmLot" label="领用批次"/>
        <el-table-column prop="esMmMocNo" label="工单"/>
        <el-table-column prop="esMmNote" label="说明"/>
        <el-table-column prop="esMmCreator" label="EsMmCreator"/>
        <el-table-column prop="esMmCreateTime" label="EsMmCreateTime"/>
        <el-table-column prop="esMmModifier" label="EsMmModifier"/>
        <el-table-column prop="esMmModifyTime" label="EsMmModifyTime"/>
        <el-table-column prop="esPpEntryDate" label="制一登入日期"/>
        <el-table-column prop="esPpLine" label="班组"/>
        <el-table-column prop="esPpLot" label="生产批次"/>
        <el-table-column prop="esPpNote" label="说明"/>
        <el-table-column prop="esPpCreator" label="EsPpCreator"/>
        <el-table-column prop="esPpCreateTime" label="EsPpCreateTime"/>
        <el-table-column prop="esPpModifier" label="EsPpModifier"/>
        <el-table-column prop="esPpModifyTime" label="EsPpModifyTime"/>
        <el-table-column prop="esPcbaEntryDate" label="制二登入日期"/>
        <el-table-column prop="esPcbaLine" label="Pcba班组"/>
        <el-table-column prop="esPcbaLot" label="Pcba批次"/>
        <el-table-column prop="esPcbaNote" label="说明"/>
        <el-table-column prop="esPcbaCreator" label="EsPcbaCreator"/>
        <el-table-column prop="esPcbaCreateTime" label="EsPcbaCreateTime"/>
        <el-table-column prop="esPcbaModifier" label="EsPcbaModifier"/>
        <el-table-column prop="esPcbaModifyTime" label="EsPcbaModifyTime"/>
        <el-table-column prop="esQaEntryDate" label="QA确认日期"/>
        <el-table-column prop="esQaLot" label="检验批次"/>
        <el-table-column prop="esQaNote" label="说明"/>
        <el-table-column prop="esQaCreator" label="EsQaCreator"/>
        <el-table-column prop="esQaCreateTime" label="EsQaCreateTime"/>
        <el-table-column prop="esQaModifier" label="EsQaModifier"/>
        <el-table-column prop="esQaModifyTime" label="EsQaModifyTime"/>
        <el-table-column prop="reMarks" label="备注"/>
        <el-table-column prop="createBy" label="创建者"/>
        <el-table-column prop="createTime" label="创建时间"/>
      </el-table>
    </el-drawer>

    <!-- 添加或修改主设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="Guid" prop="emGuid">
              <el-input v-model="form.emGuid" :placeholder="$t('btn.enter')+'Guid'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行日" prop="emEcIssueDate">
              <el-date-picker v-model="form.emEcIssueDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="emEcNo">
              <el-input clearable v-model="form.emEcNo" :placeholder="$t('btn.enter')+'设变No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="关联文件" prop="emEcDoc">
              <el-input clearable v-model="form.emEcDoc" :placeholder="$t('btn.enter')+'关联文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状态" prop="emEcStatus">
              <el-radio-group v-model="form.emEcStatus">
                <el-radio v-for="item in options.sys_ec_status" :key="item.dictValue" :label="item.dictValue">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标题" prop="emEcTitle">
              <el-input clearable v-model="form.emEcTitle" :placeholder="$t('btn.enter')+'标题'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="内容" prop="emEcContent">
              <el-input type="textarea" v-model="form.emEcContent" placeholder="请输入内容"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当" prop="emEcAssigned">
              <el-select filterable clearable v-model="form.emEcAssigned"  :placeholder="$t('btn.select')+'担当'">
                <el-option
                  v-for="item in options.sql_ec_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="损失金额" prop="emEcLossAmount">
              <el-input-number v-model.number="form.emEcLossAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'损失金额'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="管理区分" prop="emEcManageCategory">
              <el-select filterable clearable v-model="form.emEcManageCategory"  :placeholder="$t('btn.select')+'管理区分'">
                <el-option
                  v-for="item in options.sys_ec_mgtype" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联络No." prop="emEcLiaisonNo">
              <el-input clearable v-model="form.emEcLiaisonNo" :placeholder="$t('btn.enter')+'联络No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联络文件" prop="emEcLiaisonDoc">
              <el-input clearable v-model="form.emEcLiaisonDoc" :placeholder="$t('btn.enter')+'联络文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EppNo." prop="emEcEppLiaisonNo">
              <el-input clearable v-model="form.emEcEppLiaisonNo" :placeholder="$t('btn.enter')+'EppNo.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Epp文件" prop="emEcEppLiaisonDoc">
              <el-input clearable v-model="form.emEcEppLiaisonDoc" :placeholder="$t('btn.enter')+'Epp文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="FppNo." prop="emEcFppLiaisonNo">
              <el-input clearable v-model="form.emEcFppLiaisonNo" :placeholder="$t('btn.enter')+'FppNo.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fpp文件" prop="emEcFppLiaisonDoc">
              <el-input clearable v-model="form.emEcFppLiaisonDoc" :placeholder="$t('btn.enter')+'Fpp文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部No." prop="emEcExternalNo">
              <el-input clearable v-model="form.emEcExternalNo" :placeholder="$t('btn.enter')+'外部No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部文件" prop="emEcExternalDoc">
              <el-input clearable v-model="form.emEcExternalDoc" :placeholder="$t('btn.enter')+'外部文件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入部门" prop="emEcImpDept">
              <el-input clearable v-model="form.emEcImpDept" :placeholder="$t('btn.enter')+'输入部门'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日" prop="emEcEntryDate">
              <el-date-picker v-model="form.emEcEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="SOP" prop="esSopStae">
              <el-select filterable clearable v-model="form.esSopStae"  :placeholder="$t('btn.select')+'SOP'">
                <el-option
                  v-for="item in options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
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

        <el-divider content-position="center">从设变</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button type="primary" icon="Plus" @click="handleAddPpEcSlave">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button type="danger" icon="Delete" @click="handleDeletePpEcSlave">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button type="info" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.exitfullscreen') 
              : $t('layout.fullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppEcSlaveList" :row-class-name="rowPpEcSlaveIndex" @selection-change="handlePpEcSlaveSelectionChange" ref="PpEcSlaveRef">
          <el-table-column type="selection" width="50" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="输入日" align="center" prop="esEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esEntryDate" type="date" :placeholder="$t('btn.select')+'输入日'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="机种" align="center" prop="esModel">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esModel" :placeholder="$t('btn.enter')+'机种'"/>
            </template>
          </el-table-column>
          <el-table-column label="物料" align="center" prop="esItem">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esItem" :placeholder="$t('btn.enter')+'物料'"/>
            </template>
          </el-table-column>
          <el-table-column label="子物料" align="center" prop="esSubItem">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esSubItem" :placeholder="$t('btn.enter')+'子物料'"/>
            </template>
          </el-table-column>
          <el-table-column label="旧物料" align="center" prop="esOldItem">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esOldItem" :placeholder="$t('btn.enter')+'旧物料'"/>
            </template>
          </el-table-column>
          <el-table-column label="旧文本" align="center" prop="esOldItemText">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esOldItemText" :placeholder="$t('btn.enter')+'旧文本'"/>
            </template>
          </el-table-column>
          <el-table-column label="用量" align="center" prop="esOldUsageQty">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esOldUsageQty" :placeholder="$t('btn.enter')+'用量'"/>
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="esOldSetLoc">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esOldSetLoc" :placeholder="$t('btn.enter')+'位置'"/>
            </template>
          </el-table-column>
          <el-table-column label="新物料" align="center" prop="esNewItem">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esNewItem" :placeholder="$t('btn.enter')+'新物料'"/>
            </template>
          </el-table-column>
          <el-table-column label="新文本" align="center" prop="esNewItemText">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esNewItemText" :placeholder="$t('btn.enter')+'新文本'"/>
            </template>
          </el-table-column>
          <el-table-column label="用量" align="center" prop="esNewUsageQty">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esNewUsageQty" :placeholder="$t('btn.enter')+'用量'"/>
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="esNewSetLoc">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esNewSetLoc" :placeholder="$t('btn.enter')+'位置'"/>
            </template>
          </el-table-column>
          <el-table-column label="bom番号" align="center" prop="esBomNo">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esBomNo" :placeholder="$t('btn.enter')+'bom番号'"/>
            </template>
          </el-table-column>
          <el-table-column label="互换" align="center" prop="esChange">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esChange" :placeholder="$t('btn.enter')+'互换'"/>
            </template>
          </el-table-column>
          <el-table-column label="区分" align="center" prop="eslocal">
            <template #default="scope">
              <el-input clearable v-model="scope.row.eslocal" :placeholder="$t('btn.enter')+'区分'"/>
            </template>
          </el-table-column>
          <el-table-column label="指示" align="center" prop="esnote">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esnote" :placeholder="$t('btn.enter')+'指示'"/>
            </template>
          </el-table-column>
          <el-table-column label="旧品处理" align="center" prop="esOldProcess">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esOldProcess" :placeholder="$t('btn.enter')+'旧品处理'"/>
            </template>
          </el-table-column>
          <el-table-column label="bom日期" align="center" prop="esBomDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esBomDate" type="date" :placeholder="$t('btn.select')+'bom日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="实施部门" align="center" prop="emEcImpDept">
            <template #default="scope">
              <el-input clearable v-model="scope.row.emEcImpDept" :placeholder="$t('btn.enter')+'实施部门'"/>
            </template>
          </el-table-column>
          <el-table-column label="采购类型" prop="esPurType">
            <template #default="scope">
              <el-select clearable v-model="scope.row.esPurType" :placeholder="$t('btn.select')+'采购类型'">
                <el-option
                  v-for="item in options.sys_pur_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="仓库" prop="esSloc">
            <template #default="scope">
              <el-select clearable v-model="scope.row.esSloc" :placeholder="$t('btn.select')+'仓库'">
                <el-option
                  v-for="item in options.sys_sloc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="检验否" prop="esInsmk">
            <template #default="scope">
              <el-select clearable v-model="scope.row.esInsmk" :placeholder="$t('btn.select')+'检验否'">
                <el-option
                  v-for="item in options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="工厂状态" prop="esMstae">
            <template #default="scope">
              <el-select clearable v-model="scope.row.esMstae" :placeholder="$t('btn.select')+'工厂状态'">
                <el-option
                  v-for="item in options.sys_eol_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="SOP" prop="esSopStae">
            <template #default="scope">
              <el-select clearable v-model="scope.row.esSopStae" :placeholder="$t('btn.select')+'SOP'">
                <el-option
                  v-for="item in options.sys_sop_yn" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="旧品库存" align="center" prop="esOldCurrStock">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esOldCurrStock" :placeholder="$t('btn.enter')+'旧品库存'"/>
            </template>
          </el-table-column>
          <el-table-column label="新品库存" align="center" prop="esNewCurrStock">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esNewCurrStock" :placeholder="$t('btn.enter')+'新品库存'"/>
            </template>
          </el-table-column>
          <el-table-column label="采购登入日期" align="center" prop="esPurEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPurEntryDate" type="date" :placeholder="$t('btn.select')+'采购登入日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="供应商" align="center" prop="esSupplier">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esSupplier" :placeholder="$t('btn.enter')+'供应商'"/>
            </template>
          </el-table-column>
          <el-table-column label="采购PO" align="center" prop="esPurOrder">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPurOrder" :placeholder="$t('btn.enter')+'采购PO'"/>
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esPurNote">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPurNote" :placeholder="$t('btn.enter')+'说明'"/>
            </template>
          </el-table-column>
          <el-table-column label="采购新增" align="center" prop="esPurCreator">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPurCreator" :placeholder="$t('btn.enter')+'采购新增'"/>
            </template>
          </el-table-column>
          <el-table-column label="采购新增日期" align="center" prop="esPurCreateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPurCreateTime" type="date" :placeholder="$t('btn.select')+'采购新增日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="采购修改" align="center" prop="esPurModifier">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPurModifier" :placeholder="$t('btn.enter')+'采购修改'"/>
            </template>
          </el-table-column>
          <el-table-column label="采购修改日期" align="center" prop="esPurModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPurModifyTime" type="date" :placeholder="$t('btn.select')+'采购修改日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="生管登入日期" align="center" prop="esPmcEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPmcEntryDate" type="date" :placeholder="$t('btn.select')+'生管登入日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="预投入批次" align="center" prop="esPmcLot">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPmcLot" :placeholder="$t('btn.enter')+'预投入批次'"/>
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esPmcMemo">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPmcMemo" :placeholder="$t('btn.enter')+'说明'"/>
            </template>
          </el-table-column>
          <el-table-column label="备注" align="center" prop="esPmcNote">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPmcNote" :placeholder="$t('btn.enter')+'备注'"/>
            </template>
          </el-table-column>
          <el-table-column label="生管新增" align="center" prop="esPmcCreator">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPmcCreator" :placeholder="$t('btn.enter')+'生管新增'"/>
            </template>
          </el-table-column>
          <el-table-column label="生管新增日期" align="center" prop="esPmcCreateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPmcCreateTime" type="date" :placeholder="$t('btn.select')+'生管新增日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="生管修改" align="center" prop="esPmcModifier">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPmcModifier" :placeholder="$t('btn.enter')+'生管修改'"/>
            </template>
          </el-table-column>
          <el-table-column label="生管修改日期" align="center" prop="esPmcModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPmcModifyTime" type="date" :placeholder="$t('btn.select')+'生管修改日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="IQC登入日期" align="center" prop="esIqcEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esIqcEntryDate" type="date" :placeholder="$t('btn.select')+'IQC登入日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="检验订单" align="center" prop="esIqcOrder">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esIqcOrder" :placeholder="$t('btn.enter')+'检验订单'"/>
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esIqcNote">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esIqcNote" :placeholder="$t('btn.enter')+'说明'"/>
            </template>
          </el-table-column>
          <el-table-column label="IQC新增" align="center" prop="esIqcCreator">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esIqcCreator" :placeholder="$t('btn.enter')+'IQC新增'"/>
            </template>
          </el-table-column>
          <el-table-column label="IQC新增日期" align="center" prop="esIqcCreateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esIqcCreateTime" type="date" :placeholder="$t('btn.select')+'IQC新增日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="IQC修改" align="center" prop="esIqcModifier">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esIqcModifier" :placeholder="$t('btn.enter')+'IQC修改'"/>
            </template>
          </el-table-column>
          <el-table-column label="IQC修改日期" align="center" prop="esIqcModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esIqcModifyTime" type="date" :placeholder="$t('btn.select')+'IQC修改日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="部管登入日期" align="center" prop="esMmEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esMmEntryDate" type="date" :placeholder="$t('btn.select')+'部管登入日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="领用批次" align="center" prop="esMmLot">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esMmLot" :placeholder="$t('btn.enter')+'领用批次'"/>
            </template>
          </el-table-column>
          <el-table-column label="工单" align="center" prop="esMmMocNo">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esMmMocNo" :placeholder="$t('btn.enter')+'工单'"/>
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esMmNote">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esMmNote" :placeholder="$t('btn.enter')+'说明'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsMmCreator" align="center" prop="esMmCreator">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esMmCreator" :placeholder="$t('btn.enter')+'EsMmCreator'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsMmCreateTime" align="center" prop="esMmCreateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esMmCreateTime" type="date" :placeholder="$t('btn.select')+'EsMmCreateTime'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="EsMmModifier" align="center" prop="esMmModifier">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esMmModifier" :placeholder="$t('btn.enter')+'EsMmModifier'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsMmModifyTime" align="center" prop="esMmModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esMmModifyTime" type="date" :placeholder="$t('btn.select')+'EsMmModifyTime'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="制一登入日期" align="center" prop="esPpEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPpEntryDate" type="date" :placeholder="$t('btn.select')+'制一登入日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="班组" align="center" prop="esPpLine">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPpLine" :placeholder="$t('btn.enter')+'班组'"/>
            </template>
          </el-table-column>
          <el-table-column label="生产批次" align="center" prop="esPpLot">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPpLot" :placeholder="$t('btn.enter')+'生产批次'"/>
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esPpNote">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPpNote" :placeholder="$t('btn.enter')+'说明'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsPpCreator" align="center" prop="esPpCreator">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPpCreator" :placeholder="$t('btn.enter')+'EsPpCreator'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsPpCreateTime" align="center" prop="esPpCreateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPpCreateTime" type="date" :placeholder="$t('btn.select')+'EsPpCreateTime'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="EsPpModifier" align="center" prop="esPpModifier">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPpModifier" :placeholder="$t('btn.enter')+'EsPpModifier'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsPpModifyTime" align="center" prop="esPpModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPpModifyTime" type="date" :placeholder="$t('btn.select')+'EsPpModifyTime'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="制二登入日期" align="center" prop="esPcbaEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPcbaEntryDate" type="date" :placeholder="$t('btn.select')+'制二登入日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="Pcba班组" align="center" prop="esPcbaLine">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPcbaLine" :placeholder="$t('btn.enter')+'Pcba班组'"/>
            </template>
          </el-table-column>
          <el-table-column label="Pcba批次" align="center" prop="esPcbaLot">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPcbaLot" :placeholder="$t('btn.enter')+'Pcba批次'"/>
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esPcbaNote">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPcbaNote" :placeholder="$t('btn.enter')+'说明'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsPcbaCreator" align="center" prop="esPcbaCreator">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPcbaCreator" :placeholder="$t('btn.enter')+'EsPcbaCreator'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsPcbaCreateTime" align="center" prop="esPcbaCreateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPcbaCreateTime" type="date" :placeholder="$t('btn.select')+'EsPcbaCreateTime'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="EsPcbaModifier" align="center" prop="esPcbaModifier">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esPcbaModifier" :placeholder="$t('btn.enter')+'EsPcbaModifier'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsPcbaModifyTime" align="center" prop="esPcbaModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPcbaModifyTime" type="date" :placeholder="$t('btn.select')+'EsPcbaModifyTime'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="QA确认日期" align="center" prop="esQaEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esQaEntryDate" type="date" :placeholder="$t('btn.select')+'QA确认日期'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="检验批次" align="center" prop="esQaLot">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esQaLot" :placeholder="$t('btn.enter')+'检验批次'"/>
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esQaNote">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esQaNote" :placeholder="$t('btn.enter')+'说明'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsQaCreator" align="center" prop="esQaCreator">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esQaCreator" :placeholder="$t('btn.enter')+'EsQaCreator'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsQaCreateTime" align="center" prop="esQaCreateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esQaCreateTime" type="date" :placeholder="$t('btn.select')+'EsQaCreateTime'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="EsQaModifier" align="center" prop="esQaModifier">
            <template #default="scope">
              <el-input clearable v-model="scope.row.esQaModifier" :placeholder="$t('btn.enter')+'EsQaModifier'"/>
            </template>
          </el-table-column>
          <el-table-column label="EsQaModifyTime" align="center" prop="esQaModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esQaModifyTime" type="date" :placeholder="$t('btn.select')+'EsQaModifyTime'"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="备注" align="center" prop="reMarks">
            <template #default="scope">
              <el-input clearable v-model="scope.row.reMarks" :placeholder="$t('btn.enter')+'备注'"/>
            </template>
          </el-table-column>
          <el-table-column label="创建者" align="center" prop="createBy">
            <template #default="scope">
              <el-input clearable v-model="scope.row.createBy" :placeholder="$t('btn.enter')+'创建者'"/>
            </template>
          </el-table-column>
          <el-table-column label="创建时间" align="center" prop="createTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.createTime" type="date" :placeholder="$t('btn.select')+'创建时间'"></el-date-picker>
            </template>
          </el-table-column>
        </el-table>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ppecmaster">
import { listPpEcMaster,
 addPpEcMaster, delPpEcMaster, 
 updatePpEcMaster,getPpEcMaster, 
 } 
from '@/api/production/ppecmaster.js'
import importData from '@/components/ImportData'
  //防抖处理函数 import { debounce } from 'lodash';
import { debounce } from 'lodash';
  //获取当前组件实例
const { proxy } = getCurrentInstance()

//标签页
const activeName = ref('first')

const handleClick = (tab, event) => {
    console.log(tab, event)
  }
 //选中refId数组数组
const ids = ref([])
// 是否加载动画
const loading = ref(false)
// 显示搜索条件
const showSearch = ref(true)
//使用reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const queryParams = reactive({
  pageNum: 1,
  pageSize: 10,
  sort: '',
  sortType: 'asc',
  emEcIssueDate: undefined,
  emEcNo: undefined,
  emEcStatus: undefined,
  emEcAssigned: undefined,
  emEcManageCategory: undefined,
  emEcEntryDate: undefined,
  esSopStae: undefined,
})
//字段显示控制
const columns = ref([
  { visible: false, prop: 'emGuid', label: 'Guid' },

  { visible: true, prop: 'emEcIssueDate', label: '发行日' },
  { visible: true, prop: 'emEcNo', label: '设变No.' },
  { visible: true, prop: 'emEcDoc', label: '关联文件' },
  { visible: true, prop: 'emEcStatus', label: '状态' },
  { visible: true, prop: 'emEcTitle', label: '标题' },
  { visible: true, prop: 'emEcContent', label: '内容' },
  { visible: true, prop: 'emEcAssigned', label: '担当' },
  { visible: true, prop: 'emEcLossAmount', label: '损失金额' },
  { visible: false, prop: 'emEcManageCategory', label: '管理区分' },
  { visible: false, prop: 'emEcLiaisonNo', label: '联络No.' },
  { visible: false, prop: 'emEcLiaisonDoc', label: '联络文件' },
  { visible: false, prop: 'emEcEppLiaisonNo', label: 'EppNo.' },
  { visible: false, prop: 'emEcEppLiaisonDoc', label: 'Epp文件' },
  { visible: false, prop: 'emEcFppLiaisonNo', label: 'FppNo.' },
  { visible: false, prop: 'emEcFppLiaisonDoc', label: 'Fpp文件' },
  { visible: false, prop: 'emEcExternalNo', label: '外部No.' },
  { visible: false, prop: 'emEcExternalDoc', label: '外部文件' },
  { visible: false, prop: 'emEcImpDept', label: '输入部门' },
  { visible: false, prop: 'emEcEntryDate', label: '输入日' },
  { visible: false, prop: 'esSopStae', label: 'SOP' },
  { visible: false, prop: 'reMarks', label: '备注' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
])
// 记录数
const total = ref(0)
// 定义主设变表格数据变量
const dataList = ref([])
// 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

// 发行日时间范围
const dateRangeEmEcIssueDate = ref([])
// 输入日时间范围
const dateRangeEmEcEntryDate = ref([])
//字典参数
var dictParams = [
  { dictType: "sys_ec_status" },
  { dictType: "sql_ec_group" },
  { dictType: "sys_ec_mgtype" },
  { dictType: "sys_flag_list" },
  { dictType: "sys_is_deleted" },
  { dictType: "sys_pur_type" },
  { dictType: "sys_sloc_list" },
  { dictType: "sys_flag_list" },
  { dictType: "sys_eol_type" },
  { dictType: "sys_sop_yn" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取主设变/pp_ec_master表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEmEcIssueDate.value, 'EmEcIssueDate');
  proxy.addDateRange(queryParams, dateRangeEmEcEntryDate.value, 'EmEcEntryDate');
  loading.value = true
  listPpEcMaster(queryParams).then(res => {
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
  // 发行日时间范围
  dateRangeEmEcIssueDate.value = []
  // 输入日时间范围
  dateRangeEmEcEntryDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.emGuid);
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
    emGuid: [{ required: true, message: 'Guid'+ proxy.$t('btn.empty'), trigger: "blur" }],
    emEcIssueDate: [{ required: true, message: '发行日'+ proxy.$t('btn.empty'), trigger: "blur" }],
    emEcNo: [{ required: true, message: '设变No.'+ proxy.$t('btn.empty'), trigger: "blur" }],
    emEcStatus: [{ required: true, message: '状态'+ proxy.$t('btn.empty'), trigger: "blur" }],
    emEcTitle: [{ required: true, message: '标题'+ proxy.$t('btn.empty'), trigger: "blur" }],
    emEcContent: [{ required: true, message: '内容'+ proxy.$t('btn.empty'), trigger: "blur" }],
    emEcAssigned: [{ required: true, message: '担当'+ proxy.$t('btn.empty'), trigger: "change" }],
    emEcLossAmount: [{ required: true, message: '损失金额'+ proxy.$t('btn.empty'), trigger: "blur" }],
    emEcManageCategory: [{ required: true, message: '管理区分'+ proxy.$t('btn.empty'), trigger: "change", type: "number" }],
    emEcImpDept: [{ required: true, message: '输入部门'+ proxy.$t('btn.empty'), trigger: "blur" }],
    emEcEntryDate: [{ required: true, message: '输入日'+ proxy.$t('btn.empty'), trigger: "blur" }],
    esSopStae: [{ required: true, message: 'SOP'+ proxy.$t('btn.empty'), trigger: "change" }],
  },
  options: {
    // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ec_status: [],
    // 担当 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_ec_group: [],
    // 管理区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ec_mgtype: [],
    // SOP 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_flag_list: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_is_deleted: [],
    // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_pur_type: [],
    // 仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_sloc_list: [],
    // 检验否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_flag_list: [],
    // 工厂状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_eol_type: [],
    // SOP 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_sop_yn: [],
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
    emGuid: null,
    emEcIssueDate: null,
    emEcNo: null,
    emEcDoc: null,
    emEcStatus: null,
    emEcTitle: null,
    emEcContent: null,
    emEcAssigned: null,
    emEcLossAmount: null,
    emEcManageCategory: null,
    emEcLiaisonNo: null,
    emEcLiaisonDoc: null,
    emEcEppLiaisonNo: null,
    emEcEppLiaisonDoc: null,
    emEcFppLiaisonNo: null,
    emEcFppLiaisonDoc: null,
    emEcExternalNo: null,
    emEcExternalDoc: null,
    emEcImpDept: null,
    emEcEntryDate: null,
    esSopStae: null,
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
  ppEcSlaveList.value = []
  proxy.resetForm("formRef")
}
// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+'主设变'
  opertype.value = 1
  form.value.emGuid= crypto.randomUUID()
  form.value.emEcIssueDate= new Date()
  form.value.emEcStatus= 0
  form.value.emEcAssigned= []
  form.value.emEcLossAmount= 0
  form.value.emEcManageCategory= 0
  form.value.emEcEntryDate= new Date()
  form.value.esSopStae= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.emGuid || ids.value
  getPpEcMaster(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+'主设变'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ppEcSlaveList.value = res.data.ppEcSlaveNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ppEcSlaveNav = ppEcSlaveList.value
      if (form.value.emGuid != undefined && opertype.value === 2) {
        updatePpEcMaster(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addPpEcMaster(form.value).then((res) => {
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
  const Ids = row.emGuid || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delPpEcMaster(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"主设变", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/production/PpEcMaster/export', { ...queryParams })
    })
}

/*********************从设变子表信息*************************/
const ppEcSlaveList = ref([])
const checkedPpEcSlave = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 从设变序号 */
function rowPpEcSlaveIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 从设变添加按钮操作 */
function handleAddPpEcSlave() {
  let obj = {};
  //obj.esEntryDate = null;
  //obj.esModel = null;
  //obj.esItem = null;
  //obj.esSubItem = null;
  //obj.esOldItem = null;
  //obj.esOldItemText = null;
  //obj.esOldUsageQty = null;
  //obj.esOldSetLoc = null;
  //obj.esNewItem = null;
  //obj.esNewItemText = null;
  //obj.esNewUsageQty = null;
  //obj.esNewSetLoc = null;
  //obj.esBomNo = null;
  //obj.esChange = null;
  //obj.eslocal = null;
  //obj.esnote = null;
  //obj.esOldProcess = null;
  //obj.esBomDate = null;
  //obj.emEcImpDept = null;
  //obj.esPurType = null;
  //obj.esSloc = null;
  //obj.esInsmk = null;
  //obj.esMstae = null;
  //obj.esSopStae = null;
  //obj.esOldCurrStock = null;
  //obj.esNewCurrStock = null;
  //obj.esPurEntryDate = null;
  //obj.esSupplier = null;
  //obj.esPurOrder = null;
  //obj.esPurNote = null;
  //obj.esPurCreator = null;
  //obj.esPurCreateTime = null;
  //obj.esPurModifier = null;
  //obj.esPurModifyTime = null;
  //obj.esPmcEntryDate = null;
  //obj.esPmcLot = null;
  //obj.esPmcMemo = null;
  //obj.esPmcNote = null;
  //obj.esPmcCreator = null;
  //obj.esPmcCreateTime = null;
  //obj.esPmcModifier = null;
  //obj.esPmcModifyTime = null;
  //obj.esIqcEntryDate = null;
  //obj.esIqcOrder = null;
  //obj.esIqcNote = null;
  //obj.esIqcCreator = null;
  //obj.esIqcCreateTime = null;
  //obj.esIqcModifier = null;
  //obj.esIqcModifyTime = null;
  //obj.esMmEntryDate = null;
  //obj.esMmLot = null;
  //obj.esMmMocNo = null;
  //obj.esMmNote = null;
  //obj.esMmCreator = null;
  //obj.esMmCreateTime = null;
  //obj.esMmModifier = null;
  //obj.esMmModifyTime = null;
  //obj.esPpEntryDate = null;
  //obj.esPpLine = null;
  //obj.esPpLot = null;
  //obj.esPpNote = null;
  //obj.esPpCreator = null;
  //obj.esPpCreateTime = null;
  //obj.esPpModifier = null;
  //obj.esPpModifyTime = null;
  //obj.esPcbaEntryDate = null;
  //obj.esPcbaLine = null;
  //obj.esPcbaLot = null;
  //obj.esPcbaNote = null;
  //obj.esPcbaCreator = null;
  //obj.esPcbaCreateTime = null;
  //obj.esPcbaModifier = null;
  //obj.esPcbaModifyTime = null;
  //obj.esQaEntryDate = null;
  //obj.esQaLot = null;
  //obj.esQaNote = null;
  //obj.esQaCreator = null;
  //obj.esQaCreateTime = null;
  //obj.esQaModifier = null;
  //obj.esQaModifyTime = null;
  //obj.reMarks = null;
  //obj.createBy = null;
  //obj.createTime = null;
  ppEcSlaveList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpEcSlaveSelectionChange(selection) {
  checkedPpEcSlave.value = selection.map(item => item.index)
}

/** 从设变删除按钮操作 */
function handleDeletePpEcSlave() {
  if(checkedPpEcSlave.value.length == 0){
    proxy.$modal.msgError(proxy.$t('btn.firstDelete')+'从设变'+proxy.$t('btn.firstData'))
  } else {
    const PpEcSlaves = ppEcSlaveList.value;
    const checkedPpEcSlaves = checkedPpEcSlave.value;
    ppEcSlaveList.value = PpEcSlaves.filter(function(item) {
      return checkedPpEcSlaves.indexOf(item.index) == -1
    });
  }
}

/** 从设变详情 */
function rowClick(row) {
  const id = row.emGuid || ids.value
  getPpEcMaster(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ppEcSlaveList.value = data.ppEcSlaveNav
    }
  })
}


  //自定义统计函数
  const getSummaries = (param) => {
    const { columns, data } = param;
    const sums = [];
    columns.forEach((column, index) => {
      if (index === 1) {
        sums[index] = '合计'
        return
      }
      //合计的索引
      // if (index === 2 || index === 3 || index === 4 || index === 5 || index === 6) {
      if (index === 6 || index === 7) {
        const values = data.map(item => Number(item[column.property]));
        if (!values.every(value => isNaN(value))) {
          sums[index] = values.reduce((prev, curr) => {
            const value = Number(curr)
            if (!isNaN(value)) {
              return (prev + curr)
            } else {
              return prev
            }
          }, 0)
          // sums[index] = (sums[index]).toFixed(2); 
          sums[index] = ThousandWithNumber(sums[index])// !!重点 要对结果进行转换
        }
      }

    })
    //加减运算
    //sums[8] = '未完成台数：' + ThousandWithNumber(formatNumber(sums[6]) - formatNumber(sums[7])).toString()
    //合计库存金额，数量*价格
    //sums[8] = ThousandWithNumber((data.reduce((sum, row) => sum + (row.mmMovingAvg * row.mmInventory / 1000.00), 0)).toFixed(2))// !!重点 要对结果进行转换
    return sums
  }
  //千分位转number
  const formatNumber = (val) => {
    if (val == null || val == 0) {
      return val = '0.00'
    } else {
      return val.replace(/,/g, '');
    }
  }
  // 千分位函数
  function ThousandWithNumber(value) {
    if (!value) return 0
    // 获取整数部分
    const wholePart = Math.trunc(value)
    // 梳理数据 -> 千分位
    const wholePartFormat = wholePart.toString().replace(/(\d)(?=(?:\d{3})+$)/g, '$1,')
    // 处理小数部分
    let decimalPart = ''
    // 将数值截取为小数部分和整数部分
    const valueArray = value.toString().split('.')
    if (valueArray.length === 2) { // 有小数部分
      decimalPart = valueArray[1].toString() // 取得小数部分
      return wholePartFormat + '.' + decimalPart
    }
    return wholePartFormat + decimalPart
  }

handleQuery()
</script>