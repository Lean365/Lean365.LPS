<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch" label-width="auto">
      <el-form-item :label="$t('poperlog.title')" prop="title">
        <el-input v-model="queryParams.title" :placeholder="$t('btn.enter')+$t('poperlog.title')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('poperlog.operName')" prop="operName">
        <el-input v-model="queryParams.operName" :placeholder="$t('btn.enter')+$t('poperlog.operName')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('poperlog.businessType')" prop="businessType">
        <el-select v-model="queryParams.businessType" :placeholder="$t('btn.select')+$t('poperlog.businessType')"
          clearable>
          <el-option v-for="dict in options.businessTypeOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" size="small" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('poperlog.isStatus')" prop="isStatus">
        <el-select v-model="queryParams.isStatus" :placeholder="$t('btn.select')+$t('poperlog.isStatus')" clearable>
          <el-option v-for="dict in options.statusOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" size="small" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('poperlog.operParam')" prop="operParam">
        <el-input v-model="queryParams.operParam" :placeholder="$t('btn.enter')+$t('poperlog.operParam')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('poperlog.operTime')">
        <el-date-picker v-model="dateRange" type="datetimerange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss" :shortcuts="dateOptions" size="small"></el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" size="small" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" type="info" plain size="small" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" :disabled="multiple" size="small" @click="handleDelete"
          v-hasPermi="['monitor:operlog:remove']">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#c45656" plain icon="delete" size="small" @click="handleClean"
          v-hasPermi="['monitor:operlog:remove']">{{
          $t('btn.clean') }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport"
          v-hasPermi="['system:operlog:export']">{{
          $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar :showSearch="showSearch" :columns="columns" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table v-loading="loading" border :data="list" @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column :label="$t('poperlog.operId')" align="center" prop="operId" width="60px"
        :show-overflow-tooltip="true" v-if="columns.showColumn('operId')" />
      <el-table-column :label="$t('poperlog.title')" align="center" prop="title" :show-overflow-tooltip="true"
        v-if="columns.showColumn('title')" />
      <el-table-column prop="businessType" :label="$t('poperlog.businessType')" align="center"
        v-if="columns.showColumn('businessType')">
        <template #default="scope">
          <dict-tag :options="options.businessTypeOptions" :value="scope.row.businessType" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('poperlog.requestMethod')" align="center" prop="requestMethod"
        v-if="columns.showColumn('requestMethod')" />
      <el-table-column :label="$t('poperlog.operName')" align="center" prop="operName"
        v-if="columns.showColumn('operName')" />

      <el-table-column :label="$t('poperlog.operIp')" align="center" prop="operIp" width="120"
        v-if="columns.showColumn('operIp')">
        <template #default="{ row }">
          <div>{{ row.operLocation }}</div>
          <div>{{ row.operIp }}</div>
        </template>
      </el-table-column>
      <el-table-column :label="$t('poperlog.isStatus')" align="center" prop="isStatus"
        v-if="columns.showColumn('isStatus')">
        <template #default="{ row }">
          <dict-tag :options="options.statusOptions" :value="row.isStatus"></dict-tag>
        </template>
      </el-table-column>
      <el-table-column :label="$t('poperlog.elapsed')" align="center" prop="elapsed"
        v-if="columns.showColumn('elapsed')">
        <template #default="scope">
          <span
            :style="scope.row.elapsed < 1000 ? 'color:green' : scope.row.elapsed < 3000 ? 'color:orange' : 'color:red'">
            {{ scope.row.elapsed }} ms
          </span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('poperlog.errorMsg')" align="center" prop="errorMsg" :show-overflow-tooltip="true"
        v-if="columns.showColumn('errorMsg')" />
      <el-table-column :label="$t('poperlog.operTime')" align="center" prop="operTime" width="180"
        v-if="columns.showColumn('operTime')">
        <template #default="scope">
          <span>{{ scope.row.operTime }}</span>
        </template>
      </el-table-column>

      <el-table-column prop="method" :label="$t('poperlog.method')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('method')" />
      <el-table-column prop="operParam" :label="$t('poperlog.operParam')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('operParam')" />
      <el-table-column prop="jsonResult" :label="$t('poperlog.jsonResult')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('jsonResult')" />
      <el-table-column :label="$t('btn.operation')" align="center" class-name="small-padding fixed-width" width="140">
        <template #default="scope">
          <el-button size="small" color="#663cee" plain icon="view" @click="handleView(scope.row, scope.index)"
            v-hasPermi="['monitor:operlog:query']" :title="$t('btn.details')">

          </el-button>
          <el-button size="small" type="danger" plain icon="delete" @click="handleDelete(scope.row)"
            v-hasPermi="['monitor:operlog:remove']" :title="$t('btn.delete')"> </el-button>
        </template>
      </el-table-column>
    </el-table>

    <pagination v-show="total > 0" :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 操作日志详细 -->
    <el-dialog :title="$t('poperlog.logView')" v-model="open" width="700px" append-to-body>
      <el-form ref="formRef" :model="form" label-width="auto">
        <el-row>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.title')">{{ form.title }} </el-form-item>
            <el-form-item :label="$t('poperlog.operIp')">
              <el-tag>{{ form.operName }}</el-tag> {{ form.operIp }} / {{ form.operLocation }}
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.operUrl')">{{ form.operUrl }}</el-form-item>
            <el-form-item :label="$t('poperlog.requestMethod')">{{ form.requestMethod }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.method')">{{ form.method }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.businessType')">
              <dict-tag :options="options.businessTypeOptions" :value="form.businessType" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.isStatus')">
              <dict-tag :options="options.statusOptions" :value="form.isStatus"></dict-tag>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.operTime')">{{ parseTime(form.operTime) }}</el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.operParam">
            <el-form-item :label="$t('poperlog.operParam')">
              <el-input type="textarea" rows="5" v-model="form.operParam"> </el-input>
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.jsonResult">
            <el-form-item :label="$t('poperlog.jsonResult')">
              <el-input type="textarea" rows="10" v-model="form.jsonResult"> </el-input>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('poperlog.errorMsg')" v-if="form.isStatus === 1">
              <div class="text-danger">{{ form.errorMsg }}</div>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <el-button type="info" plain @click="open = false">{{$t('btn.close')}}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="operlog">
  import { list as listOperLog, delOperlog, cleanOperlog, exportOperlog } from '@/api/monitor/operlog'

  const { proxy } = getCurrentInstance()
  // 遮罩层
  const loading = ref(true)
  // 选中数组
  const ids = ref([])
  // 非多个禁用
  const multiple = ref(true)
  // 显示搜索条件
  const showSearch = ref(true)
  // 总条数
  const total = ref(0)
  // 表格数据
  const list = ref([])
  // 是否显示弹出层
  const open = ref(false)
  // 类型数据字典
  const statusOptions = ref([])
  // 业务类型（0其它 1新增 2修改 3删除）选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
  const businessTypeOptions = ref([])
  // 日期范围
  const dateRange = ref([])

  const state = reactive({
    form: {},
    queryParams: {
      pageNum: 1,
      pageSize: 20,
      title: undefined,
      operName: undefined,
      businessType: undefined,
      status: undefined,
      operParam: undefined
    },
    options: {
      //业务类型（0其它 1新增 2修改 3删除）选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      businessTypeOptions: [],
      statusOptions: []
    }
  })
  const columns = ref([
    { visible: true, prop: 'operId', label: '操作id' },
    { visible: true, prop: 'title', label: '系统模块' },
    { visible: true, prop: 'businessType', label: '业务类型' },
    { visible: true, prop: 'requestMethod', label: '请求方式' },
    { visible: true, prop: 'operatorType', label: '操作类型' },
    { visible: true, prop: 'operName', label: '操作人员' },
    //{ visible: true, prop: 'deptName', label: '部门' },
    { visible: true, prop: 'operUrl', label: '请求地址' },
    { visible: false, prop: 'operIP', label: '请求IP' },
    { visible: true, prop: 'status', label: '操作状态' },
    { visible: true, prop: 'operLocation', label: '操作人地址' },
    { visible: true, prop: 'operTime', label: '操作时间' },
    { visible: true, prop: 'method', label: '操作方法' },
    { visible: true, prop: 'operParam', label: '请求参数' },
    { visible: true, prop: 'jsonResult', label: '返回结果' },
    { visible: true, prop: 'errorMsg', label: '错误信息' },
    { visible: true, prop: 'elapsed', label: '操作用时' }
  ])
  const { form, queryParams, options } = toRefs(state)
  var dictParams = [
    { dictType: 'sys_oper_type', columnName: 'businessTypeOptions' },
    { dictType: 'sys_common_status', columnName: 'statusOptions' }
  ]
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.columnName] = element.list
    })
  })
  /** 查询登录日志 */
  function getList() {
    loading.value = true
    listOperLog(proxy.addDateRange(queryParams.value, dateRange.value)).then((response) => {
      loading.value = false
      if (response.code == 200) {
        list.value = response.data.result
        total.value = response.data.totalNum
      } else {
        total.value = 0
        list.value = []
      }
    })
  }
  // 操作日志状态字典翻译
  function statusFormat(row, column) {
    return proxy.selectDictLabel(statusOptions.value, row.status)
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.value.pageNum = 1
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    dateRange.value = []
    proxy.resetForm('queryForm')
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.operId)
    multiple.value = !selection.length
  }
  const formRef = ref()
  /** 重置操作表单 */
  function reset() {
    form.value = {
      operId: undefined,
      title: undefined,
      businessType: undefined,
      method: undefined,
      requestMethod: undefined,
      operatorType: undefined,
      //deptName: undefined,
      operUrl: undefined,
      operIp: undefined,
      operLocation: undefined,
      operParam: undefined,
      jsonResult: undefined,
      status: 0,
      errorMsg: undefined,
      operTime: undefined,
      elapsed: 0
    }
    proxy.resetForm('formRef')
  }
  /** 详细按钮操作 */
  function handleView(row) {
    reset()
    open.value = true
    form.value = row
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const operIds = row.operId || ids.value
    proxy
      .$confirm('是否确认删除日志编号为"' + operIds + '"的数据项?', '警告', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
      .then(function () {
        return delOperlog(operIds)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess('删除成功')
      })
  }
  /** 清空按钮操作 */
  function handleClean() {
    proxy
      .$confirm('是否确认清空所有操作日志数据项?', '警告', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
      .then(function () {
        return cleanOperlog()
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess('清空成功')
      })
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm('是否确认导出所有操作日志?', '警告', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
      .then(async () => {
        await proxy.downFile('/monitor/OperLog/export', { ...queryParams.value })
      })
  }
  handleQuery()
</script>