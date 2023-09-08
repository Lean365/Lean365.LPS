<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch">
      <el-form-item :label="$t('pdept.deptName')" prop="deptName">
        <el-input v-model="queryParams.deptName" :placeholder="$t('btn.enter')+$t('pdept.deptName')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('pdept.isStatus')" prop="isStatus">
        <el-select v-model="queryParams.isStatus" :placeholder="$t('btn.enter')+$t('pdept.isStatus')" clearable
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
        <el-button plain type="primary" icon="plus" size="small" @click="handleAdd" v-hasPermi="['system:dept:add']">{{
          $t('btn.add')
          }}</el-button>
      </el-col>

      <el-col :span="1.5">
        <el-button type="warning" plain icon="sort" size="small" @click="toggleExpandAll">{{ $t('btn.expand') }}/{{
          $t('btn.collapse')
          }}</el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" size="small" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table v-if="refreshTable" v-loading="loading" :data="deptList" row-key="deptId"
      :default-expand-all="isExpandAll" :tree-props="{ children: 'children', hasChildren: 'hasChildren' }" height="670">
      <el-table-column prop="deptName" :label="$t('pdept.deptName')" width="260"></el-table-column>
      <el-table-column prop="deptId" :label="$t('pdept.deptId')"></el-table-column>
      <el-table-column prop="leader" :label="$t('pdept.leader')" width="150"></el-table-column>
      <el-table-column prop="orderNum" :label="$t('pdept.orderNum')"></el-table-column>
      <el-table-column prop="isStatus" :label="$t('pdept.isStatus')" align="center">
        <template #default="scope">
          <dict-tag :options="statusOptions" :value="scope.row.isStatus" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('pdept.createTime')" align="center" prop="createTime" width="200">
        <template #default="scope">
          <span>{{ parseTime(scope.row.createTime) }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" width="200">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" @click="handleUpdate(scope.row)"
            v-hasPermi="['system:dept:update']" :title=" $t('btn.edit') ">

          </el-button>
          <el-button type="primary" size="small" plain icon="plus" @click="handleAdd(scope.row)"
            v-hasPermi="['system:dept:add']" :title="  $t('btn.add') ">

          </el-button>
          <el-button type="danger" size="small" plain v-if="scope.row.parentId != 0" icon="delete"
            @click="handleDelete(scope.row)" v-hasPermi="['system:dept:remove']" :title="  $t('btn.delete') ">

          </el-button>
        </template>
      </el-table-column>
    </el-table>

    <!-- 添加或修改部门对话框 -->
    <el-dialog :title="title" v-model="open" width="600px" append-to-body>
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-row :gutter="20">
          <el-col :lg="24" v-if="form.parentId !== 0">
            <el-form-item :label="$t('pdept.parentDepartment')" prop="parentId">
              <el-tree-select v-model="form.parentId" :data="deptOptions"
                :props="{ value: 'deptId', label: 'deptName', children: 'children' }" value-key="deptId"
                :placeholder="$t('btn.select')+$t('pdept.parentDepartment')" check-strictly
                :render-after-expand="false" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pdept.deptName')" prop="deptName">
              <el-input v-model="form.deptName" :placeholder="$t('btn.enter')+$t('pdept.deptName')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pdept.orderNum')" prop="orderNum">
              <el-input-number v-model="form.orderNum" controls-position="right" :min="0" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pdept.leader')" prop="leader">
              <el-input v-model="form.leader" :placeholder="$t('btn.enter')+$t('pdept.leader')" maxlength="20" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pdept.phone')" prop="phone">
              <el-input v-model="form.phone" :placeholder="$t('btn.enter')+$t('pdept.phone')" maxlength="11" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pdept.email')" prop="email">
              <el-input v-model="form.email" :placeholder="$t('btn.enter')+$t('pdept.email')" maxlength="50" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pdept.isStatus')">
              <el-radio-group v-model="form.status">
                <el-radio v-for="dict in statusOptions" :key="dict.dictValue" :label="parseInt(dict.dictValue)">{{
                  dict.dictLabel }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <el-button type="info" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="dept">
  import { listDept, getDept, delDept, addDept, updateDept, listDeptExcludeChild } from '@/api/system/dept'
  const { proxy } = getCurrentInstance()
  // 遮罩层
  const loading = ref(true)
  // 显示搜索条件
  const showSearch = ref(true)
  // 表格树数据
  const deptList = ref([])
  // 是否展开，默认全部折叠
  const isExpandAll = ref(false)
  // 重新渲染表格状态
  const refreshTable = ref(true)
  // 部门树选项
  const deptOptions = ref([])
  // 弹出层标题
  const title = ref('')
  // 是否显示弹出层
  const open = ref(false)
  // 状态数据字典
  const statusOptions = ref([])
  // 查询参数
  const queryParams = reactive({
    deptName: undefined,
    status: undefined
  })
  const state = reactive({
    // 表单参数
    form: {},
    // 表单校验
    rules: {
      // parentId: [{ required: true, message: '上级部门不能为空', trigger: 'blur' }],
      deptName: [{ required: true, message: proxy.$t('pdept.deptName') + proxy.$t('btn.empty'), trigger: 'blur' }],
      orderNum: [{ required: true, message: proxy.$t('pdept.orderNum') + proxy.$t('btn.empty'), trigger: 'blur' }],
      email: [{ type: 'email', message: proxy.$t('pdept.email') + proxy.$t('btn.empty'), trigger: ['blur', 'change'] }],
      phone: [{ pattern: /^1[3|4|5|6|7|8|9][0-9]\d{8}$/, message: proxy.$t('pdept.phone') + proxy.$t('btn.empty'), trigger: 'blur' }]
    }
  })
  const formRef = ref()
  const { form, rules } = toRefs(state)

  /** 查询部门列表 */
  function getList() {
    loading.value = true
    listDept(queryParams).then((response) => {
      deptList.value = proxy.handleTree(response.data, 'deptId')
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
      deptId: undefined,
      parentId: undefined,
      deptName: undefined,
      orderNum: 999,
      leader: undefined,
      phone: undefined,
      email: undefined,
      status: 0
    }
    proxy.resetForm('formRef')
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    proxy.resetForm('queryForm')
    handleQuery()
  }
  /** 新增按钮操作 */
  function handleAdd(row) {
    reset()
    if (row != undefined) {
      form.value.parentId = row.deptId
    }
    open.value = true
    title.value = proxy.$t('btn.add') + proxy.$t('pdept.dept')
    listDept().then((response) => {
      deptOptions.value = proxy.handleTree(response.data, 'deptId')
    })
  }
  /** 修改按钮操作 */
  function handleUpdate(row) {
    reset()
    getDept(row.deptId).then((response) => {
      form.value = response.data
      open.value = true
      title.value = proxy.$t('btn.edit') + proxy.$t('pdept.dept')
    })
    listDeptExcludeChild(row.deptId).then((response) => {
      deptOptions.value = proxy.handleTree(response.data, 'deptId')
    })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.deptId != undefined) {
          updateDept(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addDept(form.value).then((response) => {
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
    proxy
      .$confirm(proxy.$t('common.confirmDel') + row.deptName + proxy.$t('common.confirmDelDataitems'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return delDept(row.deptId)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
  }
  //展开/折叠操作
  function toggleExpandAll() {
    refreshTable.value = false
    isExpandAll.value = !isExpandAll.value
    nextTick(() => {
      refreshTable.value = true
    })
  }
  getList()
  proxy.getDicts('sys_normal_disable').then((response) => {
    statusOptions.value = response.data
  })
</script>