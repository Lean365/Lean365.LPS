<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch" label-width="auto">
      <el-form-item :label="$t('ppost.postCode')" prop="postCode">
        <el-input v-model="queryParams.postCode" :placeholder="$t('btn.enter')+$t('ppost.postCode')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('ppost.postName')" prop="postName">
        <el-input v-model="queryParams.postName" :placeholder="$t('btn.enter')+$t('ppost.postCode')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('ppost.isStatus')" prop="isStatus">
        <el-select v-model="queryParams.isStatus" :placeholder="$t('btn.select')+$t('ppost.postCode')" clearable
          size="small">
          <el-option v-for="dict in statusOptions" :key="dict.dictValue" :label="dict.dictLabel"
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
        <el-button type="primary" plain icon="plus" size="small" @click="handleAdd" v-hasPermi="['system:post:add']">{{
          $t('btn.add')
          }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" plain icon="edit" :disabled="single" @click="handleUpdate"
          v-hasPermi="['system:post:edit']" size="small">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" :disabled="multiple" size="small" @click="handleDelete"
          v-hasPermi="['system:post:remove']">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport"
          v-hasPermi="['system:post:export']">{{
          $t('btn.export') }}</el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table v-loading="loading" :data="postList" @selection-change="handleSelectionChange" height="670">
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column :label="$t('layout.indexNo')" align="center" prop="postId" />
      <el-table-column :label="$t('ppost.postCode')" align="center" prop="postCode" />
      <el-table-column :label="$t('ppost.postName')" align="center" prop="postName" />
      <el-table-column :label="$t('ppost.postSort')" align="center" prop="postSort" />
      <el-table-column :label="$t('ppost.isStatus')" align="center" prop="isStatus">
        <template #default="scope">
          <dict-tag :options="statusOptions" :value="scope.row.isStatus" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('ppost.createTime')" align="center" prop="createTime" width="180">
        <template #default="scope">
          <span>{{ parseTime(scope.row.createTime) }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" class-name="small-padding fixed-width">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" @click="handleUpdate(scope.row)"
            v-hasPermi="['system:post:edit']" :title=" $t('btn.edit') ">

          </el-button>
          <el-button type="danger" size="small" icon="delete" @click="handleDelete(scope.row)"
            v-hasPermi="['system:post:remove']" :title=" $t('btn.delete') ">

          </el-button>
        </template>
      </el-table-column>
    </el-table>

    <pagination v-show="total > 0" :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改岗位对话框 -->
    <el-dialog :title="title" v-model="open" width="500px" append-to-body>
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-form-item :label="$t('ppost.postName')" prop="postName">
          <el-input v-model="form.postName" :placeholder="$t('btn.enter')+$t('ppost.postName')" />
        </el-form-item>
        <el-form-item :label="$t('ppost.postCode')" prop="postCode">
          <el-input v-model="form.postCode" :placeholder="$t('btn.enter')+$t('ppost.postName')" />
        </el-form-item>
        <el-form-item :label="$t('ppost.postSort')" prop="postSort">
          <el-input-number v-model="form.postSort" controls-position="right" :min="0" />
        </el-form-item>
        <el-form-item :label="$t('ppost.isStatus')" prop="isStatus">
          <el-radio-group v-model="form.isStatus">
            <el-radio v-for="dict in statusOptions" :key="dict.dictValue" :label="dict.dictValue">{{ dict.dictLabel
              }}</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item :label="$t('ppost.reMarks')" prop="reMarks">
          <el-input v-model="form.reMarks" type="textarea" :placeholder="$t('btn.enter')+$t('ppost.postName')" />
        </el-form-item>
      </el-form>
      <template #footer>
        <el-button type="info" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="post">
  import { listPost, getPost, delPost, addPost, updatePost, exportPost } from '@/api/system/post'

  const { proxy } = getCurrentInstance()
  const loading = ref(true)
  const ids = ref([])
  const single = ref(true)
  const multiple = ref(true)
  // 显示搜索条件
  const showSearch = ref(true)
  // 总条数
  const total = ref(0)
  // 岗位表格数据
  const postList = ref([])
  // 弹出层标题
  const title = ref('')
  // 是否显示弹出层
  const open = ref(false)
  // 状态数据字典
  const statusOptions = ref([])
  // 查询参数
  let queryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    postCode: undefined,
    postName: undefined,
    isStatus: undefined
  })
  // 表单校验

  const state = reactive({
    form: {},
    rules: {
      postName: [{ required: true, message: proxy.$t('ppost.postName') + proxy.$t('btn.empty'), trigger: 'blur' }],
      postCode: [{ required: true, message: proxy.$t('ppost.postCode') + proxy.$t('btn.empty'), trigger: 'blur' }],
      postSort: [{ required: true, message: proxy.$t('ppost.postSort') + proxy.$t('btn.empty'), trigger: 'blur' }]
    }
  })
  const formRef = ref(null)
  const { form, rules } = toRefs(state)
  /** 查询岗位列表 */
  function getList() {
    loading.value = true
    listPost(queryParams).then((response) => {
      postList.value = response.data.result
      total.value = response.data.totalNum
      loading.value = false
    })
  }

  function cancel() {
    open.value = false
    reset()
  }
  // 表单重置
  function reset() {
    form.value = {
      postId: undefined,
      postCode: undefined,
      postName: undefined,
      postSort: 0,
      isStatus: '0',
      reMarks: undefined
    }
    proxy.resetForm('formRef')
  }
  proxy.getDicts('sys_normal_disable').then((response) => {
    statusOptions.value = response.data
  })
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    proxy.resetForm('queryForm')
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.postId)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }
  /** 新增按钮操作 */
  function handleAdd() {
    reset()
    open.value = true
    title.value = proxy.$t('btn.add') + proxy.$t('ppost.post')
  }
  /** 修改按钮操作 */
  function handleUpdate(row) {
    reset()
    const postId = row.postId || ids.value
    getPost(postId).then((response) => {
      form.value = response.data
      open.value = true
      title.value = proxy.$t('btn.edit') + proxy.$t('ppost.post')
    })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.postId != undefined) {
          updatePost(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addPost(form.value).then((response) => {
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
    const postIds = row.postId || ids.value
    proxy
      .$confirm(proxy.$t('common.confirmDel') + postIds + proxy.$t('common.confirmDelDataitems'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return delPost(postIds)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.confirmExport') + "机构信息", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(async () => {
        await exportPost(queryParams)
      })
  }
  handleQuery()
</script>