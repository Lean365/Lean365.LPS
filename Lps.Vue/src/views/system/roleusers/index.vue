<template>
  <div class="app-container">
    <el-form :inline="true" @submit.prevent>
      <el-form-item :label="$t('prole.troleName')">
        <el-input v-model="roleUserQueryParams.roleName" disabled />
      </el-form-item>
      <el-form-item :label="$t('prole.troleKey')">
        <el-input v-model="roleUserQueryParams.roleKey" disabled />
      </el-form-item>
      <el-form-item :label="$t('puser.userName')">
        <el-input v-model="roleUserQueryParams.userName" :placeholder="$t('btn.enter')+$t('puser.userName')" clearable
          prefix-icon="search" @keyup.enter="searchRoleUser" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="searchRoleUser">{{ $t('btn.search') }}</el-button>
        <!-- <el-button icon="refresh"  @click="resetQuery">重置</el-button> -->
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" plain icon="plus" @click="handleGetUserTable" v-hasPermi="['system:roleusers:add']">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" plain icon="circle-close" @click="cancelAuthUserAll"
          v-hasPermi="['system:roleusers:remove']">
          {{ $t('btn.multi') }}{{ $t('btn.cancel') }}{{ $t('btn.authorize') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="close" @click="handleClose">{{ $t('btn.close') }}</el-button>
      </el-col>
    </el-row>

    <el-table ref="roleUserTableRef" v-loading="loading" :data="roleUserList"
      @selection-change="handleCancelSelectionChange" row-key="userId" stripe border>
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column prop="userId" align="center" :label="$t('puser.userID')" width="150" />
      <el-table-column prop="userName" align="center" :label="$t('puser.userName')" width="150" />
      <el-table-column prop="nickName" align="center" :label="$t('puser.userNick')" width="150" />
      <el-table-column prop="isStatus" align="center" :label="$t('puser.userStat')" width="80">
        <template #default="scope">
          <dict-tag :options="statusOptions" :value="scope.row.isStatus" />
        </template>
      </el-table-column>
      <el-table-column prop="reMarks" :show-overflow-tooltip="true" align="center" :label="$t('puser.memo')" />
      <el-table-column align="center" :label="$t('btn.operation')" width="180">
        <template #default="scope">
          <el-button text size="small" icon="el-icon-circle-close" @click="handleCancelPerm(scope.row)"
            v-if="scope.row.userId != 1" v-hasPermi="['system:roleusers:del']">
            {{ $t('btn.cancel') }} {{ $t('btn.authorize') }}
          </el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination v-model:total="roleUserCount" v-model:page="roleUserQueryParams.pageNum"
      v-model:limit="roleUserQueryParams.pageSize" @pagination="getRoleUser" />

    <!-- 添加或修改菜单对话框 -->
    <el-dialog :title="$t('btn.add')+$t('puser.userName')" v-model="open" append-to-body @close="cancel">
      <el-form :inline="true" @submit.prevent>
        <el-form-item>
          <el-input v-model="userQueryParams.userName" :placeholder="$t('btn.enter')+$t('puser.userName')" clearable
            prefix-icon="search" @keyup.enter="handleSearchRoleUser" />
        </el-form-item>
      </el-form>
      <el-row>
        <el-col>
          <el-table ref="userTable" v-loading="loadingUser" :data="dataUserTable"
            @selection-change="handleSelectionChange" row-key="userId" stripe border :height="tableHeight * 0.5">
            <el-table-column type="selection" width="55" align="center" />
            <el-table-column prop="userId" align="center" :label="$t('puser.userID')" width="150" />
            <el-table-column prop="userName" align="center" :label="$t('puser.userName')" width="150" />
            <el-table-column prop="nickName" align="center" :label="$t('puser.userNick')" width="150" />
            <el-table-column prop="isStatus" align="center" :label="$t('puser.userStat')">
              <template #default="scope">
                <dict-tag :options="statusOptions" :value="scope.row.isStatus" />
              </template>
            </el-table-column>
          </el-table>
          <pagination :total="dataUserCount" v-model:page="userQueryParams.pageNum"
            v-model:limit="userQueryParams.pageSize" @pagination="handleGetUserTable" />
        </el-col>
      </el-row>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="open = false">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="handleSubmit">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>
  </div>
</template>
<script setup name="roleUsers">
  // import { listRole } from "@/api/system/role";
  import { getRole } from '@/api/system/role'
  import { getRoleUsers, createRoleUsers, deleteRoleUsers, getExcludeUsers } from '@/api/system/userRoles'

  const loadingUser = ref(false)
  const loading = ref(false)
  // 表格高度
  const tableHeight = ref(window.innerHeight)
  // 已添加用户列表
  const roleUserList = ref([])
  const roleUserCount = ref(0)
  // 未添加用户列表
  const dataUserTable = ref([])
  const dataUserCount = ref(0)
  // 勾选添加用户列表
  const addSelections = ref([])
  // 勾选删除用户列表
  const delSelections = ref([])
  // 是否显示弹出层
  const open = ref(false)
  const roleUserTableRef = ref()
  // 角色用户查询参数
  const roleUserQueryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    roleId: undefined,
    userName: undefined,
    roleName: undefined,
    roleKey: undefined
  })
  const userQueryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    roleId: undefined,
    userName: undefined
  })
  // 状态字典
  const statusOptions = ref([])

  const { proxy } = getCurrentInstance()
  const route = useRoute()
  proxy.getDicts('sys_normal_disable').then((response) => {
    statusOptions.value = response.data
  })
  const role_id = route.query.roleId
  roleUserQueryParams.roleId = role_id
  userQueryParams.roleId = role_id

  function init() {
    searchRoleUser()

    getRole(roleUserQueryParams.roleId).then((response) => {
      const { code, data } = response
      if (code == 200) {
        roleUserQueryParams.roleName = data.roleName
        roleUserQueryParams.roleKey = data.roleKey
      }
    })
  }

  function searchRoleUser() {
    roleUserQueryParams.pageNum = 1
    getRoleUser()
  }

  // 获取角色用户
  function getRoleUser() {
    loading.value = true
    getRoleUsers(roleUserQueryParams).then((response) => {
      roleUserList.value = response.data.result
      roleUserCount.value = response.data.totalNum
      loading.value = false
    })
  }
  // 返回按钮
  function handleClose() {
    const obj = { path: '/system/role' }
    proxy.$tab.closeOpenPage(obj)
  }
  function handleCancelSelectionChange(selection) {
    delSelections.value = selection.map((item) => item.userId)
  }
  // 批量删除角色用户
  function cancelAuthUserAll() {
    if (delSelections.value.length === 0) {
      proxy.$modal.msgError(proxy.$t('prole.selectdelUser'))
      return
    }
    proxy
      .$confirm(proxy.$t('common.confirmDel') + delSelections.value.length + proxy.$t('common.confirmDelDataitems'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(() => {
        deleteRoleUsers({
          roleId: role_id,
          userIds: delSelections.value
        }).then((response) => {
          if (response.code === 200) {
            proxy.$message({
              message: proxy.$t('prole.deletedSuccessfully') + response.data + proxy.$t('prole.deleteRecord'),
              type: 'success'
            })
            getRoleUser()
          }
        })
      })
      .catch(() => { })
  }
  // 取消授权
  function handleCancelPerm(row) {
    delSelections.value = []
    delSelections.value.push(row.userId)

    deleteRoleUsers({
      roleId: role_id,
      userIds: delSelections.value
    }).then((response) => {
      if (response.code === 200) {
        proxy.$message({
          message: proxy.$t('prole.deletedSuccessfully') + response.data + proxy.$t('prole.deleteRecord'),
          type: 'success'
        })
        getRoleUser()
      }
    })
  }
  // 选中角色
  // 多选框选中数据
  function handleSelectionChange(selection) {
    addSelections.value = selection.map((item) => item.userId)
  }

  function handleSearchRoleUser() {
    userQueryParams.pageNum = 1
    handleGetUserTable()
  }
  // 获取未添加角色列表
  function handleGetUserTable() {
    open.value = true
    loadingUser.value = true
    getExcludeUsers(userQueryParams).then((response) => {
      dataUserTable.value = response.data.result
      dataUserCount.value = response.data.totalNum
      loadingUser.value = false
    })
  }
  // 新增用户角色
  function handleSubmit() {
    if (addSelections.value.length <= 0) {
      proxy.$modal.msgError(proxy.$t('prole.selectaddUser'))
      return
    }
    createRoleUsers({
      roleId: role_id,
      userIds: addSelections.value
    }).then((response) => {
      if (response.code === 200) {
        proxy.$message({
          message: proxy.$t('prole.addedSuccessfully') + response.data + proxy.$t('prole.addRecord'),
          type: 'success'
        })
        getRoleUser()
        open.value = false
      }
    })
  }
  function cancel() {
    open.value = false
  }
  init()
</script>