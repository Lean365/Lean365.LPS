<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch" label-width="auto">
      <el-form-item :label="$t('pconfig.configName')" prop="configName">
        <el-input v-model="queryParams.configName" :placeholder="$t('btn.enter')+$t('pconfig.configName')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('pconfig.configKey')" prop="configKey">
        <el-input v-model="queryParams.configKey" :placeholder="$t('btn.enter')+$t('pconfig.configKey')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('pconfig.configType')" prop="configType">
        <el-select v-model="queryParams.configType" :placeholder="$t('btn.select')+$t('pconfig.configType')" clearable
          size="small">
          <el-option v-for="dict in sysYesNoOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" size="small" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button type="info" plain icon="refresh" size="small" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" plain icon="plus" size="small" @click="handleAdd" v-hasPermi="['system:config:add']">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" plain icon="edit" size="small" :disabled="single" @click="handleUpdate"
          v-hasPermi="['system:config:edit']">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" size="small" :disabled="multiple" @click="handleDelete"
          v-hasPermi="['system:config:remove']">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <!-- <el-col :span="1.5">
        <el-button type="danger" plain icon="refresh" size="small" @click="handleRefreshCache" v-hasPermi="['system:config:remove']">刷新缓存</el-button>
      </el-col> -->
      <right-toolbar :showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table v-loading="loading" :data="configList" border @selection-change="handleSelectionChange" height="602">
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column :label="$t('pconfig.configId')" align="center" prop="configId" />
      <el-table-column :label="$t('pconfig.configName')" prop="configName" :show-overflow-tooltip="true" />
      <el-table-column :label="$t('pconfig.configKey')" prop="configKey" :show-overflow-tooltip="true" />
      <el-table-column :label="$t('pconfig.configValue')" prop="configValue" />
      <el-table-column :label="$t('pconfig.configType')" prop="configType">
        <template #default="scope">
          <dict-tag :options="sysYesNoOptions" :value="scope.row.configType" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('pconfig.reMarks')" prop="reMarks" :show-overflow-tooltip="true" />
      <el-table-column :label="$t('pconfig.createTime')" prop="createTime" width="180">
        <template #default="scope">
          <span>{{ scope.row.createTime }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" class-name="small-padding fixed-width">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" @click="handleUpdate(scope.row)"
            v-hasPermi="['system:config:edit']" :title="  $t('btn.edit') ">

          </el-button>
          <el-button type="danger" plain size="small" icon="delete" @click="handleDelete(scope.row)"
            v-hasPermi="['system:config:remove']" :title="  $t('btn.delete') ">

          </el-button>
        </template>
      </el-table-column>
    </el-table>

    <pagination v-model:total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改参数配置对话框 -->
    <el-dialog :title="title" v-model="open" width="500px" append-to-body>
      <el-form ref="formRef" :model="form" :rules="rules" label-width="80px">
        <el-form-item :label="$t('pconfig.configName')" prop="configName">
          <el-input v-model="form.configName" :placeholder="$t('btn.enter')+$t('pconfig.configName')" />
        </el-form-item>
        <el-form-item :label="$t('pconfig.configKey')" prop="configKey">
          <el-input v-model="form.configKey" :placeholder="$t('btn.enter')+$t('pconfig.configKey')" />
        </el-form-item>
        <el-form-item :label="$t('pconfig.configValue')" prop="configValue">
          <el-input v-model="form.configValue" :placeholder="$t('btn.enter')+$t('pconfig.configValue')" />
        </el-form-item>
        <el-form-item :label="$t('pconfig.configType')" prop="configType">
          <el-radio-group v-model="form.configType">
            <el-radio v-for="dict in sysYesNoOptions" :key="dict.dictValue" :label="dict.dictValue">{{ dict.dictLabel
              }}</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item :label="$t('pconfig.reMarks')" prop="reMarks">
          <el-input v-model="form.reMarks" type="textarea" :placeholder="$t('btn.enter')+$t('pconfig.reMarks')" />
        </el-form-item>
      </el-form>
      <template #footer>
        <el-button type="danger" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="config">

  // 引入 config操作方法
  import { listConfig, getConfig, delConfig, addConfig, updateConfig, refreshCache } from '@/api/system/config'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 遮罩层
  const loading = ref(true)
  // 选中数组
  const ids = ref([])
  // 非单个禁用
  const single = ref(true)
  // 非多个禁用
  const multiple = ref(true)
  // 显示搜索条件
  const showSearch = ref(true)
  // 总条数
  const total = ref(0)
  // 参数表格数据
  const configList = ref([])
  // 弹出层标题
  const title = ref('')
  // 是否显示弹出层
  const open = ref(false)
  // 日期范围
  const dateRange = ref([])
  // 系统是否
  const sysYesNoOptions = ref([])
  //使用reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    configName: undefined,
    configKey: undefined,
    configType: undefined,
  })
  //reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
  const state = reactive({
    form: {},
    rules: {
      configName: [{ required: true, message: proxy.$t('pconfig.configName') + proxy.$t('btn.empty'), trigger: 'blur' }],
      configKey: [{ required: true, message: proxy.$t('pconfig.configKey') + proxy.$t('btn.empty'), trigger: 'blur' }],
      configValue: [{ required: true, message: proxy.$t('pconfig.configValue') + proxy.$t('btn.empty'), trigger: 'blur' }],
    },
  })
  const formRef = ref()
  const { form, rules } = toRefs(state)


  /** 查询参数列表 */
  function getList() {
    loading.value = true
    listConfig(proxy.addDateRange(queryParams, dateRange.value)).then((response) => {
      configList.value = response.data.result
      total.value = response.data.totalNum
      loading.value = false
    })
  }
  // 取消按钮
  function cancel() {
    open.value = false
    reset()
  }
  // 表单重置
  function reset() {
    form.value = {
      configId: undefined,
      configName: undefined,
      configKey: undefined,
      configValue: undefined,
      configType: 'Y',
      remark: undefined,
    }
    proxy.resetForm('formRef')
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    dateRange.value = []
    proxy.resetForm('queryForm')
    handleQuery()
  }
  /** 新增按钮操作 */
  function handleAdd() {
    reset()
    open.value = true
    title.value = proxy.$t('btn.add') + proxy.$t('btn.config')
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.configId)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }
  /** 修改按钮操作 */
  function handleUpdate(row) {
    reset()
    const configId = row.configId || ids.value
    getConfig(configId).then((response) => {
      form.value = response.data
      open.value = true
      title.value = proxy.$t('btn.edit') + proxy.$t('btn.config')
    })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.configId != undefined) {
          updateConfig(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addConfig(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
        }
      }
    })
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const configIds = row.configId || ids.value
    proxy
      .$confirm(proxy.$t('common.confirmDel') + configIds + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delConfig(configIds)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
      .catch(() => { })
  }
  /** 刷新缓存按钮操作 */
  function handleRefreshCache() {
    refreshCache().then(() => {
      proxy.$modal.msgSuccess(proxy.$t('common.Refreshcompleted'))
    })
  }
  proxy.getDicts('sys_yes_no').then((response) => {
    sysYesNoOptions.value = response.data
  })
  getList()
</script>