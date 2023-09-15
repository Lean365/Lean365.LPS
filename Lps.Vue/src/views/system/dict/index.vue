<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch" label-width="auto">
      <el-form-item :label="$t('pdict.dictType')" prop="dictType">
        <el-input v-model="queryParams.dictType" :placeholder="$t('btn.enter')+$t('pdict.dictType')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('pdict.dictName')" prop="dictName">
        <el-input v-model="queryParams.dictName" :placeholder="$t('btn.enter')+$t('pdict.dictType')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('pdict.isStatus')" prop="isStatus">
        <el-select v-model="queryParams.isStatus" :placeholder="$t('btn.select')+$t('pdict.dictType')" clearable
          size="small">
          <el-option v-for="dict in statusOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('pdict.type')" prop="type">
        <el-select v-model="queryParams.type" :placeholder="$t('btn.select')+$t('pdict.dictType')" clearable
          size="small">
          <el-option v-for="dict in typeOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :abel="$t('pdict.createTime')">
        <el-date-picker v-model="dateRange" type="daterange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime" :shortcuts="dateOptions" size="small">
        </el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" size="small" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button type="info" plain icon="refresh" size="small" @click="resetQuery">{{ $t('btn.reset')
          }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" plain icon="plus" size="small" @click="handleAdd" v-hasPermi="['system:dict:add']"> {{
          $t('btn.add') }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" plain icon="edit" :disabled="single" size="small" @click="handleUpdate"
          v-hasPermi="['system:dict:edit']">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" :disabled="multiple" size="small" @click="handleDelete"
          v-hasPermi="['system:dict:remove']">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport"
          v-hasPermi="['system:dict:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar :showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table :data="typeList" v-loading="loading" border @selection-change="handleSelectionChange" height="640">
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column :label="$t('pdict.dictId')" align="center" prop="dictId" width="100" sortable />
      <el-table-column :label="$t('pdict.dictType')" :show-overflow-tooltip="true">
        <template #default="scope">
          <el-link type="primary" @click="showDictData(scope.row)">{{ scope.row.dictType }}</el-link>
        </template>
      </el-table-column>
      <el-table-column :label="$t('pdict.dictName')" align="center" prop="dictName" :show-overflow-tooltip="true" />
      <el-table-column :label="$t('pdict.isStatus')" align="center" prop="isStatus">
        <template #default="scope">
          <dict-tag :options="statusOptions" :value="scope.row.isStatus" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('pdict.reMarks')" prop="reMarks" :show-overflow-tooltip="true" />
      <el-table-column :label="$t('pdict.createTime')" align="center" prop="createTime" width="180">
        <template #default="scope">
          <span>{{ scope.row.createTime }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" class-name="small-padding fixed-width">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" @click="handleUpdate(scope.row)"
            v-hasPermi="['system:dict:edit']" :title=" $t('btn.edit') ">

          </el-button>
          <el-button type="danger" plain size="small" icon="delete" @click="handleDelete(scope.row)"
            v-hasPermi="['system:dict:remove']" :title="  $t('btn.delete') ">

          </el-button>
        </template>
      </el-table-column>
    </el-table>

    <pagination v-show="total > 0" :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改参数配置对话框 -->
    <el-dialog :title="title" v-model="open" draggable width="500px" append-to-body>
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-form-item :label="$t('pdict.dictName')" prop="dictName">
          <el-input v-model="form.dictName" :placeholder="$t('btn.enter')+$t('pdict.dictName')" />
        </el-form-item>
        <el-form-item label="$t('pdict.dictType')" prop="dictType">
          <template #label>
            <span>
              <el-tooltip :content="$t('pdict.dictTypememo')" placement="top">
                <el-icon :size="15">
                  <questionFilled />
                </el-icon>
              </el-tooltip>
              {{$t('pdict.dictType')}}
            </span>
          </template>
          <el-input v-model="form.dictType" :placeholder="$t('btn.enter')+$t('pdict.dictType')" />
        </el-form-item>
        <el-form-item :label="$t('pdict.isStatus')" prop="isStatus">
          <el-radio-group v-model="form.isStatus">
            <el-radio v-for="dict in statusOptions" :key="dict.dictValue" :label="dict.dictValue">{{ dict.dictLabel
              }}</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item :label="$t('pdict.type')" prop="type">
          <el-radio-group v-model="form.type">
            <el-radio v-for="dict in typeOptions" :key="dict.dictValue" :label="dict.dictValue">{{ dict.dictLabel
              }}</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item :label="$t('pdict.reMarks')" prop="reMarks">
          <el-input v-model="form.reMarks" type="textarea"
            :placeholder="$t('btn.enter')+$t('pdict.reMarks')"></el-input>
        </el-form-item>
        <el-form-item :label="$t('pdict.customSql')" prop="customSql">
          <template #label>
            <span>
              <el-tooltip :content="$t('pdict.customSqlmemo')" placement="top">
                <el-icon :size="15">
                  <questionFilled />
                </el-icon>
              </el-tooltip>
              {{$t('pdict.sql')}}
            </span>
          </template>
          <el-input v-model="form.customSql" type="textarea" :placeholder="$t('btn.enter')+$t('pdict.sql')"></el-input>
        </el-form-item>
      </el-form>
      <template #footer>
        <el-button type="info" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>

    <el-dialog v-model="dictDataVisible" draggable width="60%" :lock-scroll="false">
      <dict-data v-model:dictId="dictId"></dict-data>
    </el-dialog>
  </div>
</template>

<script setup name="dict">
  import dictData from '@/views/components/dictData'
  import { listType, getType, delType, addType, updateType, exportType } from '@/api/system/dict/type'

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
  // 字典表格数据
  const typeList = ref([])
  // 弹出层标题
  const title = ref('')
  // 是否显示弹出层
  const open = ref(false)
  // 字典弹出层
  const dictDataVisible = ref(false)
  // 状态数据字典
  const statusOptions = ref([])
  // 是否内置
  const typeOptions = ref([])
  // 日期范围
  const dateRange = ref([])
  // 查询参数

  const formRef = ref()
  // 字典Id传值给子组件
  const dictId = ref(0)

  const state = reactive({
    rules: {
      dictName: [{ required: true, message: proxy.$t('pdict.dictName') + proxy.$t('btn.empty'), trigger: 'blur' }],
      dictType: [{ required: true, message: proxy.$t('pdict.dictType') + proxy.$t('btn.empty'), trigger: 'blur' }]
    },
    form: {},
    queryParams: {
      pageNum: 1,
      pageSize: 13,
      dictName: undefined,
      dictType: undefined,
      isStatus: undefined
    }
  })
  const { rules, form, queryParams } = toRefs(state)

  /** 查询字典类型列表 */
  function getList() {
    loading.value = true
    listType(proxy.addDateRange(queryParams.value, dateRange.value)).then((response) => {
      typeList.value = response.data.result
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
      dictId: undefined,
      dictName: undefined,
      dictType: undefined,
      isStatus: '0',
      type: 'N',
      reMarks: undefined
    }
    proxy.resetForm('formRef')
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
  /** 新增按钮操作 */
  function handleAdd() {
    reset()
    open.value = true
    title.value = proxy.$t('btn.add') + proxy.$t('pdict.dictType')
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.dictId)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }
  /** 修改按钮操作 */
  function handleUpdate(row) {
    reset()
    const dictId = row.dictId || ids.value
    getType(dictId).then((response) => {
      form.value = response.data
      open.value = true
      title.value = proxy.$t('btn.edit') + proxy.$t('pdict.dictType')
    })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.dictId != undefined) {
          updateType(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addType(form.value).then((response) => {
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
    const dictIds = row.dictId || ids.value
    proxy
      .$confirm(proxy.$t('common.confirmDel') + dictIds + proxy.$t('common.confirmDelDataitems'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return delType(dictIds)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.confirmExport') + proxy.$t('pdict.dict'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return exportType(queryParams.value)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }
  function showDictData(row) {
    dictId.value = row.dictId
    dictDataVisible.value = true
  }

  getList()
  proxy.getDicts('sys_normal_disable').then((response) => {
    statusOptions.value = response.data
  })
  proxy.getDicts('sys_yes_no').then((response) => {
    typeOptions.value = response.data
  })
</script>