<!--
 * @Descripttion: (销售凭证/sd_sales_invoice)
 * @version: (4.0.0)
 * @Author: (Lean365)
 * @Date: (2023-09-14)
-->
<template>
  <div>
    <!-- 工具区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-form-item label="工厂" prop="spPlnt">
        <el-select filterable clearable  v-model="queryParams.spPlnt" :placeholder="$t('btn.select')+'工厂'" size="small">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="期间" prop="spFy">
        <el-select filterable clearable  v-model="queryParams.spFy" :placeholder="$t('btn.select')+'期间'" size="small">
          <el-option v-for="item in  options.sql_period_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="spYm">
        <el-select filterable clearable  v-model="queryParams.spYm" :placeholder="$t('btn.select')+'年月'" size="small">
          <el-option v-for="item in  options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="客户" prop="spCustomerCode">
        <el-select filterable clearable  v-model="queryParams.spCustomerCode" :placeholder="$t('btn.select')+'客户'" size="small">
          <el-option v-for="item in  options.sql_cus_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="利润中心" prop="spPrctr">
        <el-select filterable clearable  v-model="queryParams.spPrctr" :placeholder="$t('btn.select')+'利润中心'" size="small">
          <el-option v-for="item in  options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="spSalesItem">
        <el-input  clearable v-model="queryParams.spSalesItem" :placeholder="$t('btn.enter')+'物料'" size="small"/>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" size="small" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" type="info" plain size="small" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['sd:salesinvoice:add']" plain icon="plus" size="small" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['sd:salesinvoice:edit']" plain icon="edit" size="small" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['sd:salesinvoice:delete']" plain icon="delete" size="small" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['sd:salesinvoice:import']" >
          <el-button color="#626aef" plain icon="Upload" size="small">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="sales/SdSalesInvoice/importTemplate"
                  importUrl="/sales/SdSalesInvoice/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport" v-hasPermi="['sd:salesinvoice:export']">
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
      <el-table-column prop="spGuid" label="Guid" align="center" v-if="columns.showColumn('spGuid')"/>
      <el-table-column prop="spPlnt" label="工厂" align="center" v-if="columns.showColumn('spPlnt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.spPlnt"  />
        </template>
      </el-table-column>
      <el-table-column prop="spFy" label="期间" align="center" v-if="columns.showColumn('spFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_period_list " :value="scope.row.spFy"  />
        </template>
      </el-table-column>
      <el-table-column prop="spYm" label="年月" align="center" v-if="columns.showColumn('spYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.spYm"  />
        </template>
      </el-table-column>
      <el-table-column prop="spAccDocNo" label="销售凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spAccDocNo')"/>
      <el-table-column prop="spAccDocLineNo" label="凭证明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spAccDocLineNo')"/>
      <el-table-column prop="spCustomerCode" label="客户" align="center" v-if="columns.showColumn('spCustomerCode')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.spCustomerCode"  />
        </template>
      </el-table-column>
      <el-table-column prop="spPrctr" label="利润中心" align="center" v-if="columns.showColumn('spPrctr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.spPrctr"  />
        </template>
      </el-table-column>
      <el-table-column prop="spSalesItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spSalesItem')"/>
      <el-table-column prop="spAccountCode" label="科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spAccountCode')"/>
      <el-table-column prop="spSalesQty" label="销售数量" align="center" v-if="columns.showColumn('spSalesQty')"/>
      <el-table-column prop="spSalesUnit" label="销售单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spSalesUnit')"/>
      <el-table-column prop="spOriginalAmount" label="原币销售额" align="center" v-if="columns.showColumn('spOriginalAmount')"/>
      <el-table-column prop="spOriginalCcy" label="原币币种" align="center" v-if="columns.showColumn('spOriginalCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.spOriginalCcy"  />
        </template>
      </el-table-column>
      <el-table-column prop="spLocalAmount" label="本币销售额" align="center" v-if="columns.showColumn('spLocalAmount')"/>
      <el-table-column prop="spLocalCcy" label="本币币种" align="center" v-if="columns.showColumn('spLocalCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.spLocalCcy"  />
        </template>
      </el-table-column>
      <el-table-column prop="spRefDocNo" label="参考凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spRefDocNo')"/>
      <el-table-column prop="spRefDocLineNo" label="参考明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spRefDocLineNo')"/>
      <el-table-column prop="spPostingDate" label="过账日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('spPostingDate')"/>
      <el-table-column prop="spPostingUser" label="用户" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spPostingUser')"/>
      <el-table-column prop="spEntryDate" label="输入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('spEntryDate')"/>
      <el-table-column prop="spEntryTime" label="输入时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spEntryTime')"/>
      <el-table-column prop="spOrigin" label="来源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spOrigin')"/>
      <el-table-column prop="spPgroup" label="产品组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spPgroup')"/>
      <el-table-column prop="spAccDocType" label="凭证类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spAccDocType')"/>
      <el-table-column prop="spAccDocText" label="凭证名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spAccDocText')"/>
      <el-table-column prop="reMarks" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('reMarks')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column :label="$t('btn.operation')" width="180" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['sd:salesinvoice:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" icon="delete" plain :title="$t('btn.delete')" v-hasPermi="['sd:salesinvoice:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改销售凭证对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="Guid" prop="spGuid">
              <el-input v-model="form.spGuid" :placeholder="$t('btn.enter')+'Guid'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="spPlnt">
              <el-select filterable clearable v-model="form.spPlnt"  :placeholder="$t('btn.select')+'工厂'">
                <el-option
                  v-for="item in options.sys_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间" prop="spFy">
              <el-select filterable clearable v-model="form.spFy"  :placeholder="$t('btn.select')+'期间'">
                <el-option
                  v-for="item in options.sql_period_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="spYm">
              <el-select filterable clearable v-model="form.spYm"  :placeholder="$t('btn.select')+'年月'">
                <el-option
                  v-for="item in options.sql_ym_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售凭证" prop="spAccDocNo">
              <el-input clearable v-model="form.spAccDocNo" :placeholder="$t('btn.enter')+'销售凭证'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证明细" prop="spAccDocLineNo">
              <el-input clearable v-model="form.spAccDocLineNo" :placeholder="$t('btn.enter')+'凭证明细'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户" prop="spCustomerCode">
              <el-select filterable clearable v-model="form.spCustomerCode"  :placeholder="$t('btn.select')+'客户'">
                <el-option
                  v-for="item in options.sql_cus_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="spPrctr">
              <el-select filterable clearable v-model="form.spPrctr"  :placeholder="$t('btn.select')+'利润中心'">
                <el-option
                  v-for="item in options.sql_prctr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="spSalesItem">
              <el-input clearable v-model="form.spSalesItem" :placeholder="$t('btn.enter')+'物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目" prop="spAccountCode">
              <el-input clearable v-model="form.spAccountCode" :placeholder="$t('btn.enter')+'科目'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售数量" prop="spSalesQty">
              <el-input clearable v-model="form.spSalesQty" :placeholder="$t('btn.enter')+'销售数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售单位" prop="spSalesUnit">
              <el-input clearable v-model="form.spSalesUnit" :placeholder="$t('btn.enter')+'销售单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币销售额" prop="spOriginalAmount">
              <el-input clearable v-model="form.spOriginalAmount" :placeholder="$t('btn.enter')+'原币销售额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币币种" prop="spOriginalCcy">
              <el-select filterable clearable v-model="form.spOriginalCcy"  :placeholder="$t('btn.select')+'原币币种'">
                <el-option
                  v-for="item in options.sys_ccy_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币销售额" prop="spLocalAmount">
              <el-input clearable v-model="form.spLocalAmount" :placeholder="$t('btn.enter')+'本币销售额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币币种" prop="spLocalCcy">
              <el-select filterable clearable v-model="form.spLocalCcy"  :placeholder="$t('btn.select')+'本币币种'">
                <el-option
                  v-for="item in options.sys_ccy_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考凭证" prop="spRefDocNo">
              <el-input clearable v-model="form.spRefDocNo" :placeholder="$t('btn.enter')+'参考凭证'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考明细" prop="spRefDocLineNo">
              <el-input clearable v-model="form.spRefDocLineNo" :placeholder="$t('btn.enter')+'参考明细'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过账日期" prop="spPostingDate">
              <el-date-picker v-model="form.spPostingDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用户" prop="spPostingUser">
              <el-input clearable v-model="form.spPostingUser" :placeholder="$t('btn.enter')+'用户'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日期" prop="spEntryDate">
              <el-date-picker v-model="form.spEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入时间" prop="spEntryTime">
              <el-input clearable v-model="form.spEntryTime" :placeholder="$t('btn.enter')+'输入时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="来源" prop="spOrigin">
              <el-input clearable v-model="form.spOrigin" :placeholder="$t('btn.enter')+'来源'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品组" prop="spPgroup">
              <el-input clearable v-model="form.spPgroup" :placeholder="$t('btn.enter')+'产品组'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证类型" prop="spAccDocType">
              <el-input clearable v-model="form.spAccDocType" :placeholder="$t('btn.enter')+'凭证类型'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证名称" prop="spAccDocText">
              <el-input clearable v-model="form.spAccDocText" :placeholder="$t('btn.enter')+'凭证名称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="reMarks">
              <el-input clearable v-model="form.reMarks" :placeholder="$t('btn.enter')+'说明'" />
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

<script setup name="sdsalesinvoice">
import { listSdSalesInvoice,
 addSdSalesInvoice, delSdSalesInvoice, 
 updateSdSalesInvoice,getSdSalesInvoice, 
 } 
from '@/api/sales/sdsalesinvoice.js'
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
  spPlnt: undefined,
  spFy: undefined,
  spYm: undefined,
  spCustomerCode: undefined,
  spPrctr: undefined,
  spSalesItem: undefined,
})
//字段显示控制
const columns = ref([
  { visible: false, prop: 'spGuid', label: 'Guid' },

  { visible: true, prop: 'spPlnt', label: '工厂' },
  { visible: true, prop: 'spFy', label: '期间' },
  { visible: true, prop: 'spYm', label: '年月' },
  { visible: true, prop: 'spAccDocNo', label: '销售凭证' },
  { visible: true, prop: 'spAccDocLineNo', label: '凭证明细' },
  { visible: true, prop: 'spCustomerCode', label: '客户' },
  { visible: true, prop: 'spPrctr', label: '利润中心' },
  { visible: true, prop: 'spSalesItem', label: '物料' },
  { visible: false, prop: 'spAccountCode', label: '科目' },
  { visible: false, prop: 'spSalesQty', label: '销售数量' },
  { visible: false, prop: 'spSalesUnit', label: '销售单位' },
  { visible: false, prop: 'spOriginalAmount', label: '原币销售额' },
  { visible: false, prop: 'spOriginalCcy', label: '原币币种' },
  { visible: false, prop: 'spLocalAmount', label: '本币销售额' },
  { visible: false, prop: 'spLocalCcy', label: '本币币种' },
  { visible: false, prop: 'spRefDocNo', label: '参考凭证' },
  { visible: false, prop: 'spRefDocLineNo', label: '参考明细' },
  { visible: false, prop: 'spPostingDate', label: '过账日期' },
  { visible: false, prop: 'spPostingUser', label: '用户' },
  { visible: false, prop: 'spEntryDate', label: '输入日期' },
  { visible: false, prop: 'spEntryTime', label: '输入时间' },
  { visible: false, prop: 'spOrigin', label: '来源' },
  { visible: false, prop: 'spPgroup', label: '产品组' },
  { visible: false, prop: 'spAccDocType', label: '凭证类型' },
  { visible: false, prop: 'spAccDocText', label: '凭证名称' },
  { visible: false, prop: 'reMarks', label: '说明' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
])
// 记录数
const total = ref(0)
// 定义销售凭证表格数据变量
const dataList = ref([])
// 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

//字典参数
var dictParams = [
  { dictType: "sys_plant_list" },
  { dictType: "sql_period_list" },
  { dictType: "sql_ym_list" },
  { dictType: "sql_cus_list" },
  { dictType: "sql_prctr_list" },
  { dictType: "sys_ccy_type" },
  { dictType: "sys_ccy_type" },
  { dictType: "sys_is_deleted" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取销售凭证/sd_sales_invoice表记录数据
function getList(){
  loading.value = true
  listSdSalesInvoice(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.spGuid);
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
    spGuid: [{ required: true, message: 'Guid'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spPlnt: [{ required: true, message: '工厂'+ proxy.$t('btn.empty'), trigger: "change" }],
    spFy: [{ required: true, message: '期间'+ proxy.$t('btn.empty'), trigger: "change" }],
    spYm: [{ required: true, message: '年月'+ proxy.$t('btn.empty'), trigger: "change" }],
    spAccDocNo: [{ required: true, message: '销售凭证'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spAccDocLineNo: [{ required: true, message: '凭证明细'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spCustomerCode: [{ required: true, message: '客户'+ proxy.$t('btn.empty'), trigger: "change" }],
    spPrctr: [{ required: true, message: '利润中心'+ proxy.$t('btn.empty'), trigger: "change" }],
    spSalesItem: [{ required: true, message: '物料'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spAccountCode: [{ required: true, message: '科目'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spSalesQty: [{ required: true, message: '销售数量'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spSalesUnit: [{ required: true, message: '销售单位'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spOriginalAmount: [{ required: true, message: '原币销售额'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spOriginalCcy: [{ required: true, message: '原币币种'+ proxy.$t('btn.empty'), trigger: "change" }],
    spLocalAmount: [{ required: true, message: '本币销售额'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spLocalCcy: [{ required: true, message: '本币币种'+ proxy.$t('btn.empty'), trigger: "change" }],
    spRefDocNo: [{ required: true, message: '参考凭证'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spRefDocLineNo: [{ required: true, message: '参考明细'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spPostingDate: [{ required: true, message: '过账日期'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spPostingUser: [{ required: true, message: '用户'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spEntryDate: [{ required: true, message: '输入日期'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spEntryTime: [{ required: true, message: '输入时间'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spOrigin: [{ required: true, message: '来源'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spPgroup: [{ required: true, message: '产品组'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spAccDocType: [{ required: true, message: '凭证类型'+ proxy.$t('btn.empty'), trigger: "blur" }],
    spAccDocText: [{ required: true, message: '凭证名称'+ proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_plant_list: [],
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_period_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_ym_list: [],
    // 客户 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_cus_list: [],
    // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_prctr_list: [],
    // 原币币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ccy_type: [],
    // 本币币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ccy_type: [],
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
    spGuid: null,
    spPlnt: null,
    spFy: null,
    spYm: null,
    spAccDocNo: null,
    spAccDocLineNo: null,
    spCustomerCode: null,
    spPrctr: null,
    spSalesItem: null,
    spAccountCode: null,
    spSalesQty: null,
    spSalesUnit: null,
    spOriginalAmount: null,
    spOriginalCcy: null,
    spLocalAmount: null,
    spLocalCcy: null,
    spRefDocNo: null,
    spRefDocLineNo: null,
    spPostingDate: null,
    spPostingUser: null,
    spEntryDate: null,
    spEntryTime: null,
    spOrigin: null,
    spPgroup: null,
    spAccDocType: null,
    spAccDocText: null,
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
  title.value = proxy.$t('btn.add')+'销售凭证'
  opertype.value = 1
  form.value.spGuid= crypto.randomUUID()
  form.value.spPlnt= []
  form.value.spFy= []
  form.value.spYm= []
  form.value.spCustomerCode= []
  form.value.spPrctr= []
  form.value.spSalesQty= 0
  form.value.spOriginalAmount= 0
  form.value.spOriginalCcy= []
  form.value.spLocalAmount= 0
  form.value.spLocalCcy= []
  form.value.spPostingDate= new Date()
  form.value.spEntryDate= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.spGuid || ids.value
  getSdSalesInvoice(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+'销售凭证'
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

      if (form.value.spGuid != undefined && opertype.value === 2) {
        updateSdSalesInvoice(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addSdSalesInvoice(form.value).then((res) => {
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
  const Ids = row.spGuid || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delSdSalesInvoice(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"销售凭证", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/sales/SdSalesInvoice/export', { ...queryParams })
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