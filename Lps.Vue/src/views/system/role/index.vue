<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryForm" v-show="showSearch" :inline="true">
      <el-form-item :label="$t('prole.roleName')" prop="roleName">
        <el-input v-model="queryParams.roleName" :placeholder="$t('btn.enter')+$t('prole.roleName')" clearable
          @keyup.enter="handleQuery" />
      </el-form-item>
      <!-- <el-form-item label="权限字符" prop="roleKey">
        <el-input v-model="queryParams.roleKey" placeholder="请输入权限字符" clearable  style="width: 240px" @keyup.enter.native="handleQuery" />
      </el-form-item> -->
      <el-form-item :label="$t('prole.isStatus')" prop="isStatus">
        <el-select v-model="queryParams.isStatus" :placeholder="$t('btn.select')+$t('prole.isStatus')" clearable>
          <el-option :label="$t('prole.all')" :value="-1" />
          <el-option v-for="dict in statusOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" size="small" icon="search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button type="info" size="small" plain icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" size="small" plain icon="plus" @click="handleAdd" v-hasPermi="['system:role:add']">{{
          $t('btn.add')
          }}</el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table v-loading="loading" :data="roleList" highlight-current-row @selection-change="handleSelectionChange">
      <el-table-column :label="$t('prole.troleID')" prop="roleId" width="80" />
      <el-table-column :label="$t('prole.troleName')" prop="roleName" />
      <el-table-column :label="$t('prole.troleSort')" prop="roleSort" align="center"></el-table-column>
      <el-table-column :label="$t('prole.troleKey')" prop="roleKey" />
      <el-table-column :label="$t('prole.troleScope')" prop="dataScope" :formatter="dataScopeFormat"></el-table-column>
      <el-table-column :label="$t('prole.isStatus')" align="center" width="120">
        <template #default="scope">
          <el-switch v-model="scope.row.isStatus" :disabled="scope.row.roleKey == 'admin'" :active-value="0"
            :inactive-value="1" @change="handleStatusChange(scope.row)"></el-switch>
        </template>
      </el-table-column>
      <el-table-column :label="$t('prole.userNum')" align="center" prop="userNum" width="180">
        <template #default="scope">
          <el-link type="primary" @click="handleAuthUser(scope.row)">{{ scope.row.userNum }}</el-link>
        </template>
      </el-table-column>
      <el-table-column :label="$t('prole.createTime')" prop="createTime" width="180" />
      <el-table-column :label="$t('prole.reMarks')" align="center" prop="reMarks" width="180"
        :show-overflow-tooltip="true" />
      <el-table-column :label="$t('btn.operation')" align="center" width="200">
        <template #default="scope">

          <div v-if="scope.row.roleKey != 'admin'">
            <el-button-group class="ml-4">
              <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')"
                @click.stop="handleUpdate(scope.row)" v-hasPermi="['system:role:edit']">
              </el-button>
              <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')"
                @click.stop="handleDelete(scope.row)" v-hasPermi="['system:role:remove']">
              </el-button>
              <el-dropdown @command="(command) => handleCommand(command, scope.row)"
                v-hasPermi="['system:role:edit', 'system:role:authorize', 'system:roleusers:list']">
                <el-button type="primary" size="small" icon="arrow-down" :title="$t('btn.more') ">
                </el-button>
                <template #dropdown>
                  <el-dropdown-menu>
                    <el-dropdown-item command="handleDataScope">
                      <el-button type="success" size="small" plain icon="circle-check" link>
                        {{ $t('menu.menuPermi') }}</el-button></el-dropdown-item>
                    <el-dropdown-item command="handleAuthUser">
                      <el-button color="#f89898" size="small" plain icon="user" link>
                        {{ $t('menu.assignUsers') }}</el-button></el-dropdown-item>
                    <el-dropdown-item command="handleExportMenu">
                      <el-button type="warning" size="small" plain icon="download" link>
                        {{ $t('prole.exportMenu') }}</el-button></el-dropdown-item>
                  </el-dropdown-menu>
                </template>
              </el-dropdown>
            </el-button-group>
          </div>

        </template>

      </el-table-column>
    </el-table>
    <pagination v-show="total > 0" :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 角色菜单弹框 -->
    <zr-dialog :title="$t('prole.drolePermi')" v-model="showRoleScope" width="700px" @close="cancel">
      <el-form :model="form" label-width="auto">
        <el-form-item :label="$t('prole.droleQuery')">
          <el-input :placeholder="$t('btn.enter')+$t('btn.keywords')" v-model="searchText"></el-input>
        </el-form-item>
        <el-form-item :label="$t('prole.troleKey')">
          {{ form.roleKey }}
        </el-form-item>
        <el-form-item :label="$t('prole.droleMenuPermi')">
          <el-checkbox v-model="menuExpand"
            @change="handleCheckedTreeExpand($event, 'menu')">{{$t('prole.expandCollapse')}}</el-checkbox>
          <el-checkbox v-model="menuNodeAll"
            @change="handleCheckedTreeNodeAll($event, 'menu')">{{$t('prole.selectAllorNo')}}</el-checkbox>
          <el-checkbox v-model="form.menuCheckStrictly"
            @change="handleCheckedTreeConnect($event, 'menu')">{{$t('prole.Linkage')}}</el-checkbox>
          <el-tree class="tree-border" :data="menuOptions" show-checkbox ref="menuRef" node-key="id"
            :check-strictly="!form.menuCheckStrictly" :empty-text="$t('prole.loading')" highlight-current
            :filter-node-method="menuFilterNode"
            :props="{ children: 'children', label: 'label', class: customNodeClass }">
            <template #default="{ node, data }">
              <div class="custom-tree-node">
                <span style="float: left">{{ node.label }}</span>
                <span style="float:right ;margin-left: 10px;">
                  <el-tag v-if="data.status == 1" type="danger">{{$t('prole.stop')}}</el-tag>
                </span>
              </div>
            </template>
          </el-tree>
        </el-form-item>
      </el-form>
      <template #footer>
        <el-button type="info" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitDataScope" v-hasPermi="['system:role:authorize']">{{ $t('btn.save')
          }}</el-button>
      </template>
    </zr-dialog>

    <!-- 添加或修改角色配置对话框 -->
    <zr-dialog :title="title" v-model="open" width="700px" append-to-body @close="cancel">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-row>
          <el-col :lg="24">
            <el-form-item :label="$t('prole.roleName')" prop="roleName">
              <el-input v-model="form.roleName" :placeholder="$t('btn.enter')+$t('prole.roleName')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('prole.troleKey')" prop="roleKey">
              <el-input v-model="form.roleKey" :placeholder="$t('btn.enter')+$t('prole.troleKey')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('prole.troleSort')" prop="roleSort">
              <el-input-number v-model="form.roleSort" controls-position="right" :min="0" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('prole.troleScope')">
              <el-select v-model="form.dataScope" @change="dataScopeSelectChange">
                <el-option v-for="item in dataScopeOptions" :key="item.dictValue" :label="item.dictLabel"
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('prole.isStatus')">
              <el-radio-group v-model="form.isStatus">
                <el-radio v-for="dict in statusOptions" :key="dict.dictValue" :label="parseInt(dict.dictValue)">{{
                  dict.dictLabel }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('prole.dataPermi')" v-show="form.dataScope == 2">
              <el-checkbox v-model="deptExpand"
                @change="handleCheckedTreeExpand($event, 'dept')">{{$t('prole.expandCollapse')}}</el-checkbox>
              <el-checkbox v-model="deptNodeAll"
                @change="handleCheckedTreeNodeAll($event, 'dept')">{{$t('prole.selectAllorNo')}}</el-checkbox>
              <el-checkbox v-model="form.deptCheckStrictly" @change="handleCheckedTreeConnect($event, 'dept')">
                {{$t('prole.Linkage')}}
                <el-tooltip :content="$t('prole.check')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
              </el-checkbox>
              <el-tree class="tree-border" :data="deptOptions" show-checkbox default-expand-all ref="deptRef"
                node-key="id" :check-strictly="!form.deptCheckStrictly" :empty-text="$t('prole.loading')"
                :props="defaultProps"></el-tree>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('prole.reMarks')">
              <el-input v-model="form.remark" type="textarea"
                :placeholder="$t('btn.enter')+$t('prole.reMarks')"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <el-button type="info" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </zr-dialog>
  </div>
</template>

<script setup name="role">
  import { listRole, getRole, delRole, addRole, updateRole, exportRole, dataScope, changeRoleStatus, exportRoleMenu } from '@/api/system/role'
  import { roleMenuTreeselect } from '@/api/system/menu'
  import { treeselect as deptTreeselect, roleDeptTreeselect } from '@/api/system/dept'

  const { proxy } = getCurrentInstance()

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
  // 角色表格数据
  const roleList = ref([])
  // 弹出层标题
  const title = ref('')
  // 是否显示弹出层
  const open = ref(false)
  const menuExpand = ref(true)
  const menuNodeAll = ref(false)
  const deptExpand = ref(true)
  const deptNodeAll = ref(false)
  // 日期范围
  const dateRange = ref([])
  // 状态数据字典
  const statusOptions = ref([])
  // 是否显示下拉菜单分配
  const showRoleScope = ref(false)
  // 数据范围选项
  const dataScopeOptions = ref([
    {
      dictValue: '1',
      dictLabel: proxy.$t('prole.all')
    },
    {
      dictValue: '2',
      dictLabel: proxy.$t('prole.customization')
    },
    {
      dictValue: '3',
      dictLabel: proxy.$t('prole.department')
    },
    {
      dictValue: '4',
      dictLabel: proxy.$t('prole.departmentandbelow')
    },
    {
      dictValue: '5',
      dictLabel: proxy.$t('prole.onlyme')
    }
  ])
  // 菜单列表
  const menuOptions = ref([])
  // 部门列表
  const deptOptions = ref([])
  // 查询参数
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    roleName: undefined,
    roleKey: undefined,
    status: -1
  })
  const searchText = ref('')

  const state = reactive({
    form: {},
    rules: {
      roleName: [{ required: true, message: proxy.$t('prole.roleName') + proxy.$t('btn.empty'), trigger: 'blur' }],
      roleKey: [{ required: true, message: proxy.$t('prole.troleKey') + proxy.$t('btn.empty'), trigger: 'blur' }],
      roleSort: [{ required: true, message: proxy.$t('prole.troleSort') + proxy.$t('btn.empty'), trigger: 'blur' }]
    },
    defaultProps: {
      children: 'children',
      label: 'label',
      menuType: customNodeClass
    }
  })
  const menuRef = ref()
  const deptRef = ref()
  const formRef = ref()
  const { form, rules, defaultProps } = toRefs(state)

  watch(searchText, (val) => {
    proxy.$refs.menuRef.filter(val)
  })

  /** 查询角色列表 */
  function getList() {
    loading.value = true

    listRole(proxy.addDateRange(queryParams, dateRange.value)).then((response) => {
      roleList.value = response.data.result
      total.value = response.data.totalNum
      loading.value = false
    })
  }

  /** 查询部门树结构 */
  function getDeptTreeselect() {
    deptTreeselect().then((response) => {
      deptOptions.value = response.data
    })
  }
  // 所有菜单节点数据
  function getMenuAllCheckedKeys() {
    // 目前被选中的菜单节点
    const checkedKeys = proxy.$refs.menuRef.getCheckedKeys()
    // 半选中的菜单节点
    const halfCheckedKeys = proxy.$refs.menuRef.getHalfCheckedKeys()
    checkedKeys.unshift.apply(checkedKeys, halfCheckedKeys)
    return checkedKeys
  }
  // 所有部门节点数据
  function getDeptAllCheckedKeys() {
    // 目前被选中的部门节点
    const checkedKeys = proxy.$refs.deptRef.getCheckedKeys()
    // 半选中的部门节点
    const halfCheckedKeys = proxy.$refs.deptRef.getHalfCheckedKeys()
    checkedKeys.unshift.apply(checkedKeys, halfCheckedKeys)
    return checkedKeys
  }
  /** 根据角色ID查询菜单树结构 */
  function getRoleMenuTreeselect(roleId) {
    return roleMenuTreeselect(roleId).then((response) => {
      menuOptions.value = response.data.menus
      return response
    })
  }
  /** 根据角色ID查询部门树结构 */
  function getRoleDeptTreeselect(roleId) {
    return roleDeptTreeselect(roleId).then((response) => {
      deptOptions.value = response.data.depts
      return response
    })
  }
  // 角色状态修改
  function handleStatusChange(row) {
    const text = row.status == '0' ? '启用' : '停用'

    proxy
      .$confirm('确认要"' + text + '""' + row.roleName + '"角色吗?', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
      .then(function () {
        return changeRoleStatus(row.roleId, row.status)
      })
      .then(() => {
        proxy.$modal.msgSuccess(text + '成功')
      })
      .catch(function () {
        row.status = row.status == 0 ? 1 : 0
      })
  }
  // 取消按钮
  function cancel() {
    open.value = false
    showRoleScope.value = false
    reset()
  }
  // 表单重置
  function reset() {
    if (proxy.$refs.menuRef != undefined) {
      proxy.$refs.menuRef.setCheckedKeys([])
    }
    ; (menuExpand.value = false),
      (menuNodeAll.value = false),
      (deptExpand.value = true),
      (deptNodeAll.value = false),
      (form.value = {
        roleId: undefined,
        roleName: undefined,
        roleKey: undefined,
        roleSort: 99,
        status: 0,
        menuIds: [],
        deptIds: [],
        dataScope: 1,
        menuCheckStrictly: true,
        deptCheckStrictly: true,
        remark: undefined
      })
    proxy.resetForm('form')
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
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.roleId)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }
  // 更多操作触发
  function handleCommand(command, row) {
    switch (command) {
      case 'handleDataScope':
        handleDataScope(row)
        break
      case 'handleAuthUser':
        handleAuthUser(row)
        break
      case 'handleExportMenu':
        handleExportMenu(row)
      default:
        break
    }
  }
  // 树权限（展开/折叠）
  function handleCheckedTreeExpand(value, type) {
    if (type == 'menu') {
      const treeList = menuOptions.value
      for (let i = 0; i < treeList.length; i++) {
        proxy.$refs.menuRef.store.nodesMap[treeList[i].id].expanded = value
      }
    } else if (type == 'dept') {
      const treeList = deptOptions.value
      for (let i = 0; i < treeList.length; i++) {
        proxy.$refs.deptRef.store.nodesMap[treeList[i].id].expanded = value
      }
    }
  }

  // 树权限（全选/全不选）
  function handleCheckedTreeNodeAll(value, type) {
    if (type == 'menu') {
      proxy.$refs.menuRef.setCheckedNodes(value ? menuOptions.value : [])
    } else if (type == 'dept') {
      proxy.$refs.deptRef.setCheckedNodes(value ? deptOptions.value : [])
    }
  }

  // 树权限（父子联动）
  function handleCheckedTreeConnect(value, type) {
    if (type == 'menu') {
      form.value.menuCheckStrictly = !!value
    } else if (type == 'dept') {
      form.value.deptCheckStrictly = !!value
    }
  }

  // 菜单筛选
  function menuFilterNode(value, data) {
    if (!value) return true
    return data.label.indexOf(value) !== -1
  }

  /** 新增按钮操作 */
  function handleAdd() {
    reset()
    getDeptTreeselect()
    open.value = true
    title.value = proxy.$t('btn.add') + proxy.$t('prole.role')
    showRoleScope.value = false
  }

  /** 修改按钮操作 ok */
  function handleUpdate(row) {
    reset()
    showRoleScope.value = false
    const roleId = row.roleId || ids.value
    const roleDeptTreeselect = getRoleDeptTreeselect(row.roleId)
    getRole(roleId).then((response) => {
      form.value = response.data
      open.value = true
      title.value = proxy.$t('btn.edit') + proxy.$t('prole.role')

      nextTick(() => {
        roleDeptTreeselect.then((res) => {
          proxy.$refs.deptRef.setCheckedKeys(res.data.checkedKeys)
        })
      })
    })
  }
  /** 选择角色权限范围触发 */
  function dataScopeSelectChange(value) {
    if (value !== '2') {
      proxy.$refs.deptRef.setCheckedKeys([])
    }
  }
  // 数据权限
  function dataScopeFormat(row, column) {
    return proxy.selectDictLabel(dataScopeOptions.value, row.dataScope)
  }
  /** 分配角色权限按钮操作 */
  // 新增 和上面代码基本相同
  function handleDataScope(row) {
    if (row.roleId == 1) {
      showRoleScope.value = false
      return
    }
    reset()
    showRoleScope.value = true
    const roleId = row.roleId || ids.value
    const roleMenu = getRoleMenuTreeselect(roleId)

    roleMenu.then((res) => {
      const checkedKeys = res.data.checkedKeys
      checkedKeys.forEach((v) => {
        nextTick(() => {
          proxy.$refs.menuRef.setChecked(v, true, false)
        })
      })
    })
    form.value = {
      roleId: row.roleId,
      roleName: row.roleName,
      roleKey: row.roleKey,
      menuCheckStrictly: row.menuCheckStrictly
    }
  }
  const router = useRouter()
  /** 分配用户操作 */
  function handleAuthUser(row) {
    const roleId = row.roleId
    var hasPermi = proxy.$auth.hasPermi(['system:role:authorize', 'system:roleusers:list'])
    if (hasPermi) {
      router.push({ path: '/system/roleusers', query: { roleId } })
    } else {
      proxy.$modal.msgError(proxy.$t('prole.noPermission'))
    }
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.roleId != undefined && form.value.roleId > 0) {
          form.value.type = 'edit'
          form.value.deptIds = getDeptAllCheckedKeys()
          updateRole(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          form.value.type = 'add'
          form.value.deptIds = getDeptAllCheckedKeys()
          addRole(form.value).then((response) => {
            open.value = false
            if (response.code == 200) {
              proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
              getList()
            } else {
              proxy.$modal.msgError(response.msg)
            }
          })
        }
      }
    })
  }

  /** 提交按钮（菜单数据权限） */
  function submitDataScope() {
    if (form.value.roleId != undefined) {
      form.value.menuIds = getMenuAllCheckedKeys()
      dataScope(form.value).then((response) => {
        proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
        getList()
        cancel()
      })
    } else {
      proxy.$modal.msgError(proxy.$t('prole.selectRole'))
    }
  }

  /** 删除按钮操作 */
  function handleDelete(row) {
    const roleIds = row.roleId || ids.value
    proxy
      .$confirm(proxy.$t('common.confirmDel') + roleIds + proxy.$t('common.confirmDelDataitems'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return delRole(roleIds)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
  }

  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.confirmExport') + proxy.$t('prole.role'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return exportRole(queryParams)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }
  // 导出角色菜单
  function handleExportMenu(row) {
    proxy
      .$confirm(proxy.$t('common.confirmExport') + proxy.$t('prole.role') + proxy.$t('pmenu.menu'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(async () => {
        await exportRoleMenu({ roleId: row.roleId })
      })
  }
  getList()
  proxy.getDicts('sys_normal_disable').then((response) => {
    statusOptions.value = response.data
  })

  function customNodeClass(data, node) {
    if (data.menuType == 'C') {
      return 'tree-item-flex'
    }
    return null
  }
</script>
<style scoped>
  /* tree border */
  .tree-border {
    margin-top: 5px;
    border: 1px solid #e5e6e7;
    background: var(--base-bg-main) none;
    border-radius: 4px;
    width: 100%;
  }

  .el-dropdown-link {
    cursor: pointer;
    color: var(--el-color-primary);
    display: flex;
    align-items: center;
  }

  .el-dropdown {
    vertical-align: middle;
  }
</style>