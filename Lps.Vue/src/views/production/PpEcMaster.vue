<!--
 * @Descripttion: (主设变/pp_ec_master)
 * @Author: (Lean365)
 * @Date: (2023-09-14)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="发行日">
        <el-date-picker 
          v-model="dateRangeEmEcIssueDate" 
          type="datetimerange" 
          range-separator="-"
          start-placeholder="开始日期" 
          end-placeholder="结束日期" 
          placeholder="请选择发行日"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="设变No." prop="emEcNo">
        <el-input v-model="queryParams.emEcNo" placeholder="请输入设变No." />
      </el-form-item>
      <el-form-item label="状态" prop="emEcStatus">
        <el-select clearable  v-model="queryParams.emEcStatus" placeholder="请选择状态">
          <el-option v-for="item in  options.sys_ec_status " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="担当" prop="emEcAssigned">
        <el-select clearable  v-model="queryParams.emEcAssigned" placeholder="请选择担当">
          <el-option v-for="item in  options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="管理区分" prop="emEcManageCategory">
        <el-select clearable  v-model="queryParams.emEcManageCategory" placeholder="请选择管理区分">
          <el-option v-for="item in  options.sys_ec_mgtype " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="输入部门" prop="emEcImpDept">
        <el-select clearable  v-model="queryParams.emEcImpDept" placeholder="请选择输入部门">
          <el-option v-for="item in  options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="输入日">
        <el-date-picker 
          v-model="dateRangeEmEcEntryDate" 
          type="datetimerange" 
          range-separator="-"
          start-placeholder="开始日期" 
          end-placeholder="结束日期" 
          placeholder="请选择输入日"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="SOP" prop="esSopStae">
        <el-select clearable  v-model="queryParams.esSopStae" placeholder="请选择SOP">
          <el-option v-for="item in  options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:ecmaster:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
       <el-col :span="1.5">
        <el-button type="info" plain icon="sort" @click="toggleExpandAll">展开/折叠</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:ecmaster:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecmaster:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table
      v-if="refreshTable"
      :data="dataList"
      v-loading="loading"
      ref="tableRef"
      border
      highlight-current-row
      @selection-change="handleSelectionChange"
      :default-expand-all="isExpandAll"
      row-key="emEcNo"
      :tree-props="{ children: 'children', hasChildren: 'hasChildren' }">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="emGuid" label="Guid" align="center" />
      <el-table-column prop="emEcIssueDate" label="发行日" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcNo" label="设变No." align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcDoc" label="关联文件" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcStatus" label="状态" align="center">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.emEcStatus" />
        </template>
      </el-table-column>
      <el-table-column prop="emEcTitle" label="标题" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcContent" label="内容" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcAssigned" label="担当" align="center">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.emEcAssigned" />
        </template>
      </el-table-column>
      <el-table-column prop="emEcLossAmount" label="损失金额" align="center" />
      <el-table-column prop="emEcManageCategory" label="管理区分" align="center">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_mgtype " :value="scope.row.emEcManageCategory" />
        </template>
      </el-table-column>
      <el-table-column prop="emEcLiaisonNo" label="联络No." align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcLiaisonDoc" label="联络文件" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcEppLiaisonNo" label="EppNo." align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcEppLiaisonDoc" label="Epp文件" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcFppLiaisonNo" label="FppNo." align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcFppLiaisonDoc" label="Fpp文件" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcExternalNo" label="外部No." align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcExternalDoc" label="外部文件" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="emEcImpDept" label="输入部门" align="center">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.emEcImpDept" />
        </template>
      </el-table-column>
      <el-table-column prop="emEcEntryDate" label="输入日" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="esSopStae" label="SOP" align="center">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.esSopStae" />
        </template>
      </el-table-column>
      <el-table-column prop="reMarks" label="备注" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="createTime" label="创建时间" align="center" :show-overflow-tooltip="true" />

      <el-table-column label="操作" align="center" width="140">
        <template #default="scope">
          <el-button v-hasPermi="['pp:ecmaster:edit']" type="success" icon="edit" title="编辑" 
            @click="handleUpdate(scope.row)"></el-button>      
          <el-button v-hasPermi="['pp:ecmaster:delete']" type="danger" icon="delete" title="删除" 
            @click="handleDelete(scope.row)"></el-button>
        </template>      
      </el-table-column>
    </el-table>

    <!-- 添加或修改主设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="Guid" prop="emGuid">
              <el-input-number v-model.number="form.emGuid" controls-position="right" placeholder="请输入Guid" :disabled="title=='修改数据'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行日" prop="emEcIssueDate">
              <el-date-picker v-model="form.emEcIssueDate" type="datetime" placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="父级id" prop="emEcNo">
              <el-cascader
                class="w100"
                :options="dataList"
                :props="{ checkStrictly: true, value: 'emEcNo', label: 'emEcNo', emitPath: false }"
                placeholder="请选择上级菜单"
                clearable
                v-model="form.emEcNo"
              >
                <template #default="{ node, data }">
                  <span>{{ data.emEcNo }}</span>
                  <span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
                </template>
              </el-cascader>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="关联文件" prop="emEcDoc">
              <UploadFile v-model="form.emEcDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状态" prop="emEcStatus">
              <el-radio-group v-model="form.emEcStatus">
                <el-radio v-for="item in  options.sys_ec_status " :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标题" prop="emEcTitle">
              <el-input v-model="form.emEcTitle" placeholder="请输入标题" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="内容" prop="emEcContent">
              <el-input type="textarea" v-model="form.emEcContent" placeholder="请输入内容"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当" prop="emEcAssigned">
              <el-select v-model="form.emEcAssigned" placeholder="请选择担当">
                <el-option v-for="item in  options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="损失金额" prop="emEcLossAmount">
              <el-input-number v-model.number="form.emEcLossAmount" controls-position="right" placeholder="请输入损失金额" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="管理区分" prop="emEcManageCategory">
              <el-select v-model="form.emEcManageCategory" placeholder="请选择管理区分">
                <el-option v-for="item in  options.sys_ec_mgtype " :key="item.dictValue" :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联络No." prop="emEcLiaisonNo">
              <el-input v-model="form.emEcLiaisonNo" placeholder="请输入联络No." />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="联络文件" prop="emEcLiaisonDoc">
              <UploadFile v-model="form.emEcLiaisonDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EppNo." prop="emEcEppLiaisonNo">
              <el-input v-model="form.emEcEppLiaisonNo" placeholder="请输入EppNo." />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="Epp文件" prop="emEcEppLiaisonDoc">
              <UploadFile v-model="form.emEcEppLiaisonDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="FppNo." prop="emEcFppLiaisonNo">
              <el-input v-model="form.emEcFppLiaisonNo" placeholder="请输入FppNo." />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="Fpp文件" prop="emEcFppLiaisonDoc">
              <UploadFile v-model="form.emEcFppLiaisonDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部No." prop="emEcExternalNo">
              <el-input v-model="form.emEcExternalNo" placeholder="请输入外部No." />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="外部文件" prop="emEcExternalDoc">
              <UploadFile v-model="form.emEcExternalDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入部门" prop="emEcImpDept">
              <el-select v-model="form.emEcImpDept" placeholder="请选择输入部门">
                <el-option v-for="item in  options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日" prop="emEcEntryDate">
              <el-date-picker v-model="form.emEcEntryDate" type="datetime" placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="SOP" prop="esSopStae">
              <el-radio-group v-model="form.esSopStae">
                <el-radio v-for="item in  options.sys_flag_list " :key="item.dictValue" :label="item.dictValue">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义A" prop="uDF01">
              <el-input v-model="form.uDF01" placeholder="请输入自定义A" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义B" prop="uDF02">
              <el-input v-model="form.uDF02" placeholder="请输入自定义B" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义C" prop="uDF03">
              <el-input v-model="form.uDF03" placeholder="请输入自定义C" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义D" prop="uDF04">
              <el-input v-model="form.uDF04" placeholder="请输入自定义D" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义E" prop="uDF05">
              <el-input v-model="form.uDF05" placeholder="请输入自定义E" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义F" prop="uDF06">
              <el-input v-model="form.uDF06" placeholder="请输入自定义F" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义1" prop="uDF51">
              <el-input v-model="form.uDF51" placeholder="请输入自定义1" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input v-model="form.uDF52" placeholder="请输入自定义2" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input v-model="form.uDF53" placeholder="请输入自定义3" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input v-model="form.uDF54" placeholder="请输入自定义4" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input v-model="form.uDF55" placeholder="请输入自定义5" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input v-model="form.uDF56" placeholder="请输入自定义6" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in  options.sys_is_deleted " :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="reMarks">
              <el-input type="textarea" v-model="form.reMarks" placeholder="请输入备注"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input v-model="form.createBy" placeholder="请输入创建者" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" placeholder="请输入更新者" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>

  </div>
</template>

<script setup name="ppecmaster">
import { treelistPpEcMaster, listPpEcMaster, 
 addPpEcMaster, delPpEcMaster, updatePpEcMaster,getPpEcMaster,
 } from '@/api/production/ppecmaster.js'

const { proxy } = getCurrentInstance()
// 是否展开，默认全部折叠
const isExpandAll = ref(false)
const refreshTable = ref(true)
// 展开/折叠操作
function toggleExpandAll() {
  refreshTable.value = false
  isExpandAll.value = !isExpandAll.value
  nextTick(() => {
    refreshTable.value = true
  })
}

// 选中emGuid数组数组
const ids = ref([])
const single = ref(true)
const multiple = ref(true)
const loading = ref(false)
const showSearch = ref(true)
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
  emEcImpDept: undefined,
  emEcEntryDate: undefined,
  esSopStae: undefined,
})
const total = ref(0)
const dataList = ref([])
const queryRef = ref()
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

// 发行日时间范围
const dateRangeEmEcIssueDate = ref([])

// 输入日时间范围
const dateRangeEmEcEntryDate = ref([])


var dictParams = [
  { dictType: "sys_ec_status" },
  { dictType: "sql_ec_group" },
  { dictType: "sys_ec_mgtype" },
  { dictType: "sql_dept_list" },
  { dictType: "sys_flag_list" },
  { dictType: "sys_is_deleted" },
]

proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})

function getList(){
  proxy.addDateRange(queryParams, dateRangeEmEcIssueDate.value, 'EmEcIssueDate');
  proxy.addDateRange(queryParams, dateRangeEmEcEntryDate.value, 'EmEcEntryDate');
  loading.value = true
  treelistPpEcMaster(queryParams).then(res => {
    const { code, data } = res
    if (code == 200) {
      //dataList.value = res.data.result
      //total.value = res.data.totalNum
      dataList.value = res.data
      loading.value = false
    }
  })
    .catch(() => {
      loading.value = false
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
const formRef = ref()
const title = ref("")
// 操作类型 1、add 2、edit
const opertype = ref(0)
const open = ref(false)
const state = reactive({
  form: {},
  rules: {
    emGuid: [{ required: true, message: "Guid不能为空", trigger: "blur" }],
    emEcIssueDate: [{ required: true, message: "发行日不能为空", trigger: "blur" }],
    emEcNo: [{ required: true, message: "设变No.不能为空", trigger: "blur" }],
    emEcStatus: [{ required: true, message: "状态不能为空", trigger: "blur" }],
    emEcTitle: [{ required: true, message: "标题不能为空", trigger: "blur" }],
    emEcContent: [{ required: true, message: "内容不能为空", trigger: "blur" }],
    emEcAssigned: [{ required: true, message: "担当不能为空", trigger: "change" }],
    emEcLossAmount: [{ required: true, message: "损失金额不能为空", trigger: "blur" }],
    emEcManageCategory: [{ required: true, message: "管理区分不能为空", trigger: "change", type: "number" }],
    emEcImpDept: [{ required: true, message: "输入部门不能为空", trigger: "change" }],
    emEcEntryDate: [{ required: true, message: "输入日不能为空", trigger: "blur" }],
    esSopStae: [{ required: true, message: "SOP不能为空", trigger: "blur" }],
  },
  options: {
    // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ec_status: [],
    // 担当 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_ec_group: [],
    // 管理区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ec_mgtype: [],
    // 输入部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_dept_list: [],
    // SOP 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_flag_list: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_is_deleted: [],
  }
})

const { form, rules, options } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  proxy.resetForm("formRef")
}

// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = '添加'
  opertype.value = 1
}

// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.emGuid || ids.value
  getPpEcMaster(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = "修改数据"
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
      if (form.value.emGuid != undefined && opertype.value === 2) {
        updatePpEcMaster(form.value).then((res) => {
          proxy.$modal.msgSuccess("修改成功")
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addPpEcMaster(form.value).then((res) => {
            proxy.$modal.msgSuccess("新增成功")
            open.value = false
            getList()
          })
          .catch(() => {})
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.emGuid || ids.value

  proxy.$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？')
  .then(function () {
      return delPpEcMaster(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess("删除成功")
  })
  .catch(() => {})
}

// 导出按钮操作
function handleExport() {
  proxy
    .$confirm("是否确认导出主设变数据项?", "警告", {
      confirmButtonText: "确定",
      cancelButtonText: "取消",
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/production/PpEcMaster/export', { ...queryParams })
    })
}

handleQuery()
</script>