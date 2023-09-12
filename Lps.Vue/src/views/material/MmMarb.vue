<!--
 * @Descripttion: (物料信息/mm_marb)
 * @version: (4.0.0)
 * @Author: (Lean365)
 * @Date: (2023-09-12)
-->
<template>
  <div>
    <!-- 工具区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="mmPlnt">
        <el-select clearable  v-model="queryParams.mmPlnt" :placeholder="$t('btn.select')+'工厂'">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="mmMatItem">
        <el-input  clearable v-model="queryParams.mmMatItem" :placeholder="$t('btn.enter')+'物料'" />
      </el-form-item>
      <el-form-item label="行业类别" prop="mmIndustry">
        <el-select clearable  v-model="queryParams.mmIndustry" :placeholder="$t('btn.select')+'行业类别'">
          <el-option v-for="item in  options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料类型" prop="mmMatType">
        <el-select clearable  v-model="queryParams.mmMatType" :placeholder="$t('btn.select')+'物料类型'">
          <el-option v-for="item in  options.sys_mats_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料文本" prop="mmMatDes">
        <el-input  clearable v-model="queryParams.mmMatDes" :placeholder="$t('btn.enter')+'物料文本'" />
      </el-form-item>
      <el-form-item label="物料组" prop="mmMatGroup">
        <el-select clearable  v-model="queryParams.mmMatGroup" :placeholder="$t('btn.select')+'物料组'">
          <el-option v-for="item in  options.sys_item_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购组" prop="mmPurGroup">
        <el-select clearable  v-model="queryParams.mmPurGroup" :placeholder="$t('btn.select')+'采购组'">
          <el-option v-for="item in  options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购类型" prop="mmPurType">
        <el-select clearable  v-model="queryParams.mmPurType" :placeholder="$t('btn.select')+'采购类型'">
          <el-option v-for="item in  options.sys_pur_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="特殊采购类" prop="mmSpecType">
        <el-select clearable  v-model="queryParams.mmSpecType" :placeholder="$t('btn.select')+'特殊采购类'">
          <el-option v-for="item in  options.sys_pur_spec " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="交货时间" prop="mmLeadTime">
        <el-input  clearable v-model.number="queryParams.mmLeadTime" :placeholder="$t('btn.enter')+'交货时间'" />
      </el-form-item>
      <el-form-item label="检验否" prop="mmisChecked">
        <el-select clearable  v-model="queryParams.mmisChecked" :placeholder="$t('btn.select')+'检验否'">
          <el-option v-for="item in  options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="利润中心" prop="mmProfitCenter">
        <el-select clearable  v-model="queryParams.mmProfitCenter" :placeholder="$t('btn.select')+'利润中心'">
          <el-option v-for="item in  options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="批次管理" prop="mmisLot">
        <el-select clearable  v-model="queryParams.mmisLot" :placeholder="$t('btn.select')+'批次管理'">
          <el-option v-for="item in  options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="评估类" prop="mmValType">
        <el-select clearable  v-model="queryParams.mmValType" :placeholder="$t('btn.select')+'评估类'">
          <el-option v-for="item in  options.la_val_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="币种" prop="mmCcy">
        <el-select clearable  v-model="queryParams.mmCcy" :placeholder="$t('btn.select')+'币种'">
          <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购仓库" prop="mmSLoc">
        <el-select clearable  v-model="queryParams.mmSLoc" :placeholder="$t('btn.select')+'采购仓库'">
          <el-option v-for="item in  options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="仓位" prop="mmLocPosn">
        <el-select clearable  v-model="queryParams.mmLocPosn" :placeholder="$t('btn.select')+'仓位'">
          <el-option v-for="item in  options.sys_warehouse_location " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="EOL" prop="mmLocEol">
        <el-select clearable  v-model="queryParams.mmLocEol" :placeholder="$t('btn.select')+'EOL'">
          <el-option v-for="item in  options.sys_eol_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" type="info" plain @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['mm:marb:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['mm:marb:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['mm:marb:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:marb:import']">
          <el-button color="#79bbff" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="material/MmMarb/importTemplate"
                  importUrl="/material/MmMarb/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['mm:marb:export']">
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
      <el-table-column prop="mmGuid" label="Guid" align="center" v-if="columns.showColumn('mmGuid')"/>
      <el-table-column prop="mmLastDate" label="更新日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mmLastDate')"/>
      <el-table-column prop="mmPlnt" label="工厂" align="center" v-if="columns.showColumn('mmPlnt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.mmPlnt"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmMatItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmMatItem')"/>
      <el-table-column prop="mmIndustry" label="行业类别" align="center" v-if="columns.showColumn('mmIndustry')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.mmIndustry"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmMatType" label="物料类型" align="center" v-if="columns.showColumn('mmMatType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_mats_type " :value="scope.row.mmMatType"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmMatDes" label="物料文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmMatDes')"/>
      <el-table-column prop="mmBaseUnit" label="标准单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmBaseUnit')"/>
      <el-table-column prop="mmProLevel" label="层次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmProLevel')"/>
      <el-table-column prop="mmMatGroup" label="物料组" align="center" v-if="columns.showColumn('mmMatGroup')">
        <template #default="scope">
          <dict-tag :options=" options.sys_item_group " :value="scope.row.mmMatGroup"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmPurGroup" label="采购组" align="center" v-if="columns.showColumn('mmPurGroup')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.mmPurGroup"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmPurType" label="采购类型" align="center" v-if="columns.showColumn('mmPurType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_type " :value="scope.row.mmPurType"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmSpecType" label="特殊采购类" align="center" v-if="columns.showColumn('mmSpecType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_spec " :value="scope.row.mmSpecType"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmBulkMat" label="散装物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmBulkMat')"/>
      <el-table-column prop="mmMoq" label="最小批量" align="center" v-if="columns.showColumn('mmMoq')"/>
      <el-table-column prop="mmRoundingVal" label="舍入值" align="center" v-if="columns.showColumn('mmRoundingVal')"/>
      <el-table-column prop="mmLeadTime" label="交货时间" align="center" v-if="columns.showColumn('mmLeadTime')"/>
      <el-table-column prop="mmProDays" label="生产天数" align="center" v-if="columns.showColumn('mmProDays')"/>
      <el-table-column prop="mmisChecked" label="检验否" align="center" v-if="columns.showColumn('mmisChecked')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.mmisChecked"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmProfitCenter" label="利润中心" align="center" v-if="columns.showColumn('mmProfitCenter')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.mmProfitCenter"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmDiffCode" label="差异码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmDiffCode')"/>
      <el-table-column prop="mmisLot" label="批次管理" align="center" v-if="columns.showColumn('mmisLot')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.mmisLot"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmMpn" label="制造商物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmMpn')"/>
      <el-table-column prop="mmMfrs" label="制造商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmMfrs')"/>
      <el-table-column prop="mmValType" label="评估类" align="center" v-if="columns.showColumn('mmValType')">
        <template #default="scope">
          <dict-tag :options=" options.la_val_type " :value="scope.row.mmValType"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmMovingAvg" label="移动平均价" align="center" v-if="columns.showColumn('mmMovingAvg')"/>
      <el-table-column prop="mmCcy" label="币种" align="center" v-if="columns.showColumn('mmCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.mmCcy"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmPriceControl" label="价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmPriceControl')"/>
      <el-table-column prop="mmPriceUnit" label="价格单位" align="center" v-if="columns.showColumn('mmPriceUnit')"/>
      <el-table-column prop="mmSLoc" label="采购仓库" align="center" v-if="columns.showColumn('mmSLoc')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.mmSLoc"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmESLoc" label="生产仓库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmESLoc')"/>
      <el-table-column prop="mmLocPosn" label="仓位" align="center" v-if="columns.showColumn('mmLocPosn')">
        <template #default="scope">
          <dict-tag :options=" options.sys_warehouse_location " :value="scope.row.mmLocPosn"  />
        </template>
      </el-table-column>
      <el-table-column prop="mmInventory" label="库存" align="center" v-if="columns.showColumn('mmInventory')"/>
      <el-table-column prop="mmLocEol" label="EOL" align="center" v-if="columns.showColumn('mmLocEol')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eol_type " :value="scope.row.mmLocEol"  />
        </template>
      </el-table-column>
      <el-table-column prop="reMarks" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('reMarks')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column :label="$t('btn.operation')" width="180">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:marb:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" icon="delete" plain :title="$t('btn.delete')" v-hasPermi="['mm:marb:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改物料信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="Guid" prop="mmGuid">
              <el-input v-model="form.mmGuid" :placeholder="$t('btn.enter')+'Guid'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新日期" prop="mmLastDate">
              <el-date-picker v-model="form.mmLastDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="mmPlnt">
              <el-select filterable clearable v-model="form.mmPlnt"  :placeholder="$t('btn.select')+'工厂'">
                <el-option
                  v-for="item in options.sys_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="mmMatItem">
              <el-input clearable v-model="form.mmMatItem" :placeholder="$t('btn.enter')+'物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="行业类别" prop="mmIndustry">
              <el-select filterable clearable v-model="form.mmIndustry"  :placeholder="$t('btn.select')+'行业类别'">
                <el-option
                  v-for="item in options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料类型" prop="mmMatType">
              <el-select filterable clearable v-model="form.mmMatType"  :placeholder="$t('btn.select')+'物料类型'">
                <el-option
                  v-for="item in options.sys_mats_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料文本" prop="mmMatDes">
              <el-input clearable v-model="form.mmMatDes" :placeholder="$t('btn.enter')+'物料文本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准单位" prop="mmBaseUnit">
              <el-input clearable v-model="form.mmBaseUnit" :placeholder="$t('btn.enter')+'标准单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="层次" prop="mmProLevel">
              <el-input clearable v-model="form.mmProLevel" :placeholder="$t('btn.enter')+'层次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组" prop="mmMatGroup">
              <el-select filterable clearable v-model="form.mmMatGroup"  :placeholder="$t('btn.select')+'物料组'">
                <el-option
                  v-for="item in options.sys_item_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购组" prop="mmPurGroup">
              <el-select filterable clearable v-model="form.mmPurGroup"  :placeholder="$t('btn.select')+'采购组'">
                <el-option
                  v-for="item in options.sys_pur_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购类型" prop="mmPurType">
              <el-select filterable clearable v-model="form.mmPurType"  :placeholder="$t('btn.select')+'采购类型'">
                <el-option
                  v-for="item in options.sys_pur_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特殊采购类" prop="mmSpecType">
              <el-select filterable clearable v-model="form.mmSpecType"  :placeholder="$t('btn.select')+'特殊采购类'">
                <el-option
                  v-for="item in options.sys_pur_spec" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="散装物料" prop="mmBulkMat">
              <el-input clearable v-model="form.mmBulkMat" :placeholder="$t('btn.enter')+'散装物料'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="最小批量" prop="mmMoq">
              <el-input-number v-model.number="form.mmMoq" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'最小批量'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="舍入值" prop="mmRoundingVal">
              <el-input-number v-model.number="form.mmRoundingVal" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'舍入值'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="交货时间" prop="mmLeadTime">
              <el-input-number v-model.number="form.mmLeadTime" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'交货时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产天数" prop="mmProDays">
              <el-input-number v-model.number="form.mmProDays" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'生产天数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验否" prop="mmisChecked">
              <el-select filterable clearable v-model="form.mmisChecked"  :placeholder="$t('btn.select')+'检验否'">
                <el-option
                  v-for="item in options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="mmProfitCenter">
              <el-select filterable clearable v-model="form.mmProfitCenter"  :placeholder="$t('btn.select')+'利润中心'">
                <el-option
                  v-for="item in options.sql_prctr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异码" prop="mmDiffCode">
              <el-input clearable v-model="form.mmDiffCode" :placeholder="$t('btn.enter')+'差异码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次管理" prop="mmisLot">
              <el-select filterable clearable v-model="form.mmisLot"  :placeholder="$t('btn.select')+'批次管理'">
                <el-option
                  v-for="item in options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商物料" prop="mmMpn">
              <el-input clearable v-model="form.mmMpn" :placeholder="$t('btn.enter')+'制造商物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商" prop="mmMfrs">
              <el-input clearable v-model="form.mmMfrs" :placeholder="$t('btn.enter')+'制造商'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类" prop="mmValType">
              <el-select filterable clearable v-model="form.mmValType"  :placeholder="$t('btn.select')+'评估类'">
                <el-option
                  v-for="item in options.la_val_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动平均价" prop="mmMovingAvg">
              <el-input-number v-model.number="form.mmMovingAvg" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'移动平均价'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="mmCcy">
              <el-select filterable clearable v-model="form.mmCcy"  :placeholder="$t('btn.select')+'币种'">
                <el-option
                  v-for="item in options.sys_ccy_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格控制" prop="mmPriceControl">
              <el-input clearable v-model="form.mmPriceControl" :placeholder="$t('btn.enter')+'价格控制'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="价格单位" prop="mmPriceUnit">
              <el-input-number v-model.number="form.mmPriceUnit" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'价格单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购仓库" prop="mmSLoc">
              <el-select filterable clearable v-model="form.mmSLoc"  :placeholder="$t('btn.select')+'采购仓库'">
                <el-option
                  v-for="item in options.sys_sloc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产仓库" prop="mmESLoc">
              <el-input clearable v-model="form.mmESLoc" :placeholder="$t('btn.enter')+'生产仓库'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓位" prop="mmLocPosn">
              <el-select filterable clearable v-model="form.mmLocPosn"  :placeholder="$t('btn.select')+'仓位'">
                <el-option
                  v-for="item in options.sys_warehouse_location" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存" prop="mmInventory">
              <el-input-number v-model.number="form.mmInventory" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EOL" prop="mmLocEol">
              <el-select filterable clearable v-model="form.mmLocEol"  :placeholder="$t('btn.select')+'EOL'">
                <el-option
                  v-for="item in options.sys_eol_type" 
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

      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="mmmarb">
import { listMmMarb,
 addMmMarb, delMmMarb, 
 updateMmMarb,getMmMarb, 
 } 
from '@/api/material/mmmarb.js'
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
  pageSize: 14,
  sort: '',
  sortType: 'asc',
  mmPlnt: undefined,
  mmMatItem: undefined,
  mmIndustry: undefined,
  mmMatType: undefined,
  mmMatDes: undefined,
  mmMatGroup: undefined,
  mmPurGroup: undefined,
  mmPurType: undefined,
  mmSpecType: undefined,
  mmLeadTime: undefined,
  mmisChecked: undefined,
  mmProfitCenter: undefined,
  mmisLot: undefined,
  mmValType: undefined,
  mmCcy: undefined,
  mmSLoc: undefined,
  mmLocPosn: undefined,
  mmLocEol: undefined,
})
//字段显示控制
const columns = ref([
  { visible: false, prop: 'mmGuid', label: 'Guid' },

  { visible: true, prop: 'mmLastDate', label: '更新日期' },
  { visible: true, prop: 'mmPlnt', label: '工厂' },
  { visible: true, prop: 'mmMatItem', label: '物料' },
  { visible: true, prop: 'mmIndustry', label: '行业类别' },
  { visible: true, prop: 'mmMatType', label: '物料类型' },
  { visible: true, prop: 'mmMatDes', label: '物料文本' },
  { visible: true, prop: 'mmBaseUnit', label: '标准单位' },
  { visible: true, prop: 'mmProLevel', label: '层次' },
  { visible: false, prop: 'mmMatGroup', label: '物料组' },
  { visible: false, prop: 'mmPurGroup', label: '采购组' },
  { visible: false, prop: 'mmPurType', label: '采购类型' },
  { visible: false, prop: 'mmSpecType', label: '特殊采购类' },
  { visible: false, prop: 'mmBulkMat', label: '散装物料' },
  { visible: false, prop: 'mmMoq', label: '最小批量' },
  { visible: false, prop: 'mmRoundingVal', label: '舍入值' },
  { visible: false, prop: 'mmLeadTime', label: '交货时间' },
  { visible: false, prop: 'mmProDays', label: '生产天数' },
  { visible: false, prop: 'mmisChecked', label: '检验否' },
  { visible: false, prop: 'mmProfitCenter', label: '利润中心' },
  { visible: false, prop: 'mmDiffCode', label: '差异码' },
  { visible: false, prop: 'mmisLot', label: '批次管理' },
  { visible: false, prop: 'mmMpn', label: '制造商物料' },
  { visible: false, prop: 'mmMfrs', label: '制造商' },
  { visible: false, prop: 'mmValType', label: '评估类' },
  { visible: false, prop: 'mmMovingAvg', label: '移动平均价' },
  { visible: false, prop: 'mmCcy', label: '币种' },
  { visible: false, prop: 'mmPriceControl', label: '价格控制' },
  { visible: false, prop: 'mmPriceUnit', label: '价格单位' },
  { visible: false, prop: 'mmSLoc', label: '采购仓库' },
  { visible: false, prop: 'mmESLoc', label: '生产仓库' },
  { visible: false, prop: 'mmLocPosn', label: '仓位' },
  { visible: false, prop: 'mmInventory', label: '库存' },
  { visible: false, prop: 'mmLocEol', label: 'EOL' },
  { visible: false, prop: 'reMarks', label: '备注' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
])
// 记录数
const total = ref(0)
// 定义物料信息表格数据变量
const dataList = ref([])
// 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

//字典参数
var dictParams = [
  { dictType: "sys_plant_list" },
  { dictType: "sys_ind_type" },
  { dictType: "sys_mats_type" },
  { dictType: "sys_item_group" },
  { dictType: "sys_pur_group" },
  { dictType: "sys_pur_type" },
  { dictType: "sys_pur_spec" },
  { dictType: "sys_flag_list" },
  { dictType: "sql_prctr_list" },
  { dictType: "sys_flag_list" },
  { dictType: "la_val_type" },
  { dictType: "sys_ccy_type" },
  { dictType: "sys_sloc_list" },
  { dictType: "sys_warehouse_location" },
  { dictType: "sys_eol_type" },
  { dictType: "sys_is_deleted" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取物料信息/mm_marb表记录数据
function getList(){
  loading.value = true
  listMmMarb(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.mmGuid);
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
    mmGuid: [{ required: true, message: 'Guid'+ proxy.$t('btn.empty'), trigger: "blur" }],
    mmLastDate: [{ required: true, message: '更新日期'+ proxy.$t('btn.empty'), trigger: "blur" }],
    mmPlnt: [{ required: true, message: '工厂'+ proxy.$t('btn.empty'), trigger: "change" }],
    mmMatItem: [{ required: true, message: '物料'+ proxy.$t('btn.empty'), trigger: "blur" }],
    mmIndustry: [{ required: true, message: '行业类别'+ proxy.$t('btn.empty'), trigger: "change" }],
    mmMatType: [{ required: true, message: '物料类型'+ proxy.$t('btn.empty'), trigger: "change" }],
    mmMatDes: [{ required: true, message: '物料文本'+ proxy.$t('btn.empty'), trigger: "blur" }],
    mmBaseUnit: [{ required: true, message: '标准单位'+ proxy.$t('btn.empty'), trigger: "blur" }],
    mmMatGroup: [{ required: true, message: '物料组'+ proxy.$t('btn.empty'), trigger: "change" }],
    mmPurType: [{ required: true, message: '采购类型'+ proxy.$t('btn.empty'), trigger: "change" }],
    mmMoq: [{ required: true, message: '最小批量'+ proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    mmRoundingVal: [{ required: true, message: '舍入值'+ proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    mmLeadTime: [{ required: true, message: '交货时间'+ proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    mmProDays: [{ required: true, message: '生产天数'+ proxy.$t('btn.empty'), trigger: "blur" }],
    mmProfitCenter: [{ required: true, message: '利润中心'+ proxy.$t('btn.empty'), trigger: "change" }],
    mmValType: [{ required: true, message: '评估类'+ proxy.$t('btn.empty'), trigger: "change" }],
    mmMovingAvg: [{ required: true, message: '移动平均价'+ proxy.$t('btn.empty'), trigger: "blur" }],
    mmCcy: [{ required: true, message: '币种'+ proxy.$t('btn.empty'), trigger: "change" }],
    mmPriceControl: [{ required: true, message: '价格控制'+ proxy.$t('btn.empty'), trigger: "blur" }],
    mmPriceUnit: [{ required: true, message: '价格单位'+ proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    mmInventory: [{ required: true, message: '库存'+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF51: [{ required: true, message: '自定义1'+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF52: [{ required: true, message: '自定义2'+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF53: [{ required: true, message: '自定义3'+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF54: [{ required: true, message: '自定义4'+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF55: [{ required: true, message: '自定义5'+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF56: [{ required: true, message: '自定义6'+ proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_plant_list: [],
    // 行业类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ind_type: [],
    // 物料类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_mats_type: [],
    // 物料组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_item_group: [],
    // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_pur_group: [],
    // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_pur_type: [],
    // 特殊采购类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_pur_spec: [],
    // 检验否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_flag_list: [],
    // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_prctr_list: [],
    // 批次管理 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_flag_list: [],
    // 评估类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    la_val_type: [],
    // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ccy_type: [],
    // 采购仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_sloc_list: [],
    // 仓位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_warehouse_location: [],
    // EOL 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_eol_type: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_is_deleted: [],
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
    mmGuid: null,
    mmLastDate: null,
    mmPlnt: null,
    mmMatItem: null,
    mmIndustry: null,
    mmMatType: null,
    mmMatDes: null,
    mmBaseUnit: null,
    mmProLevel: null,
    mmMatGroup: null,
    mmPurGroup: null,
    mmPurType: null,
    mmSpecType: null,
    mmBulkMat: null,
    mmMoq: null,
    mmRoundingVal: null,
    mmLeadTime: null,
    mmProDays: null,
    mmisChecked: null,
    mmProfitCenter: null,
    mmDiffCode: null,
    mmisLot: null,
    mmMpn: null,
    mmMfrs: null,
    mmValType: null,
    mmMovingAvg: null,
    mmCcy: null,
    mmPriceControl: null,
    mmPriceUnit: null,
    mmSLoc: null,
    mmESLoc: null,
    mmLocPosn: null,
    mmInventory: null,
    mmLocEol: null,
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
  title.value = proxy.$t('btn.add')+'物料信息'
  opertype.value = 1
  form.value.mmGuid= crypto.randomUUID()
  form.value.mmLastDate= new Date()
  form.value.mmPlnt= []
  form.value.mmIndustry= []
  form.value.mmMatType= []
  form.value.mmMatGroup= []
  form.value.mmPurGroup= []
  form.value.mmPurType= []
  form.value.mmSpecType= []
  form.value.mmMoq= 0
  form.value.mmRoundingVal= 0
  form.value.mmLeadTime= 0
  form.value.mmProDays= 0
  form.value.mmisChecked= []
  form.value.mmProfitCenter= []
  form.value.mmisLot= []
  form.value.mmValType= []
  form.value.mmMovingAvg= 0
  form.value.mmCcy= []
  form.value.mmPriceUnit= 0
  form.value.mmSLoc= []
  form.value.mmLocPosn= []
  form.value.mmInventory= 0
  form.value.mmLocEol= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.mmGuid || ids.value
  getMmMarb(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+'物料信息'
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

      if (form.value.mmGuid != undefined && opertype.value === 2) {
        updateMmMarb(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addMmMarb(form.value).then((res) => {
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
  const Ids = row.mmGuid || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delMmMarb(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"物料信息", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/material/MmMarb/export', { ...queryParams })
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
    sums[8] = '未完成台数：' + ThousandWithNumber(formatNumber(sums[6]) - formatNumber(sums[7])).toString()
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