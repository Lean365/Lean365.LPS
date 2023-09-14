<template>
  <div class="app-container">
    <el-row :gutter="20">
      <!--部门数据-->
      <el-col :span="4" :xs="24">
        <div class="head-container">
          <el-input v-model="deptName" :placeholder="$t('btn.enter')+$t('puser.deptName')" clearable
            prefix-icon="el-icon-search" style="margin-bottom: 20px" />
        </div>
        <div class="head-container">
          <el-tree :data="deptOptions" :props="{ label: 'label', children: 'children' }" :expand-on-click-node="false"
            :filter-node-method="filterNode" ref="deptTreeRef" node-key="id" highlight-current default-expand-all
            @node-click="handleNodeClick" />
        </div>
      </el-col>
      <!--用户数据-->
      <el-col :lg="20" :xm="24">
        <el-form :model="queryParams" ref="queryRef" :inline="true" v-show="showSearch" label-width="68px">
          <el-form-item :label="$t('puser.userName')" prop="userName">
            <el-input v-model="queryParams.userName" :placeholder="$t('btn.enter')+$t('puser.deptName')" clearable
              style="width: 240px" @keyup.enter="handleQuery" />
          </el-form-item>
          <el-form-item :label="$t('puser.userMobile')" prop="phonenumber">
            <el-input v-model="queryParams.phonenumber" :placeholder="$t('btn.enter')+$t('puser.userMobile')" clearable
              style="width: 240px" @keyup.enter="handleQuery" />
          </el-form-item>
          <el-form-item :label="$t('puser.userStat')" prop="isStatus">
            <el-select v-model="queryParams.isStatus" :placeholder="$t('btn.select')+$t('puser.userStat')" clearable
              style="width: 240px">
              <el-option :label="$t('layout.all')" :value="-1" />
              <el-option v-for="dict in statusOptions" :key="dict.dictValue" :label="dict.dictLabel"
                :value="dict.dictValue" />
            </el-select>
          </el-form-item>
          <el-form-item :label="$t('puser.Createdate')">
            <el-date-picker v-model="dateRange" style="width: 240px" type="daterange" range-separator="-"
              :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')" :default-time="defaultTime"
              :shortcuts="dateOptions"></el-date-picker>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" icon="search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
            <el-button color="#CDD0D6" plain icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
          </el-form-item>
        </el-form>

        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button type="primary" plain icon="Plus" @click="handleAdd" v-hasPermi="['system:user:add']">
              {{ $t('btn.add') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button type="success" plain icon="Edit" :disabled="single" @click="handleUpdate"
              v-hasPermi="['system:user:edit']">
              {{ $t('btn.edit') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button type="danger" plain icon="Delete" :disabled="single" @click="handleDelete"
              v-hasPermi="['system:user:remove']">
              {{ $t('btn.delete') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button type="info" plain icon="Upload" @click="handleImport" v-hasPermi="['system:user:import']">
              {{ $t('btn.import') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button type="warning" plain icon="Download" @click="handleExport" v-hasPermi="['system:user:export']">
              {{ $t('btn.export') }}
            </el-button>
          </el-col>

          <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
        </el-row>

        <el-table border v-loading="loading" :data="userList" @selection-change="handleSelectionChange">
          <el-table-column type="selection" width="50" align="center" />
          <el-table-column :label="$t('puser.userID')" align="center" key="userId" prop="userId"
            v-if="columns.showColumn('userId')" />
          <el-table-column :label="$t('puser.userName')" align="center" key="userName" prop="userName"
            v-if="columns.showColumn('userName')" :show-overflow-tooltip="true" />
          <el-table-column :label="$t('puser.userNick')" align="center" key="nickName" prop="nickName"
            v-if="columns.showColumn('nickName')" :show-overflow-tooltip="true" />
          <el-table-column :label="$t('puser.deptName')" align="center" key="deptName" prop="deptName"
            v-if="columns.showColumn('deptName')" :show-overflow-tooltip="true" />
          <el-table-column :label="$t('puser.userMobile')" align="center" key="phonenumber" prop="phonenumber"
            v-if="columns.showColumn('phonenumber')" width="120" />
          <el-table-column :label="$t('puser.userStat')" align="center" key="isStatus" prop="isStatus"
            v-if="columns.showColumn('isStatus')">
            <template #default="scope">
              <el-switch v-model="scope.row.isStatus" :active-value="0" :inactive-value="1"
                @change="handleStatusChange(scope.row)"></el-switch>
            </template>
          </el-table-column>
          <el-table-column :label="$t('puser.Createdate')" align="center" prop="createTime"
            v-if="columns.showColumn('createTime')" width="160"></el-table-column>
          <el-table-column prop="sex" :label="$t('puser.sex')" align="center" v-if="columns.showColumn('sex')">
            <template #default="scope">
              <dict-tag :options="sexOptions" :value="scope.row.sex" />
            </template>
          </el-table-column>
          <el-table-column prop="avatar" :label="$t('puser.avatar')" align="center" v-if="columns.showColumn('avatar')">
            <template #default="scope">
              <el-image preview-teleported :hide-on-click-modal="true" lazy class="avatar" fit="contain"
                :src="scope.row.avatar" :preview-src-list="[scope.row.avatar]">
                <div>
                  <el-icon :size="15">
                    <document />
                  </el-icon>
                </div>
              </el-image>
            </template>
          </el-table-column>
          <el-table-column prop="email" :label="$t('puser.email')" align="center" v-if="columns.showColumn('email')" />
          <el-table-column prop="loginDate" :label="$t('puser.loginDate')" align="center"
            v-if="columns.showColumn('loginDate')" />
          <el-table-column :label="$t('btn.operation')" align="center" width="180"
            class-name="small-padding fixed-width">
            <template #default="scope">
              <el-button v-if="scope.row.userId !== 1" size="small" type="success" icon="Edit" :title="$t('btn.edit')"
                @click="handleUpdate(scope.row)" v-hasPermi="['system:user:edit']">
              </el-button>
              <el-button v-if="scope.row.userId !== 1" size="small" type="danger" plain icon="Delete"
                :title="$t('btn.delete')" @click="handleDelete(scope.row)" v-hasPermi="['system:user:remove']">
              </el-button>
              <el-button v-if="scope.row.userId !== 1" size="small" color="#eebe77" plain icon="Key"
                :title="$t('btn.resetPassword')" @click="handleResetPwd(scope.row)"
                v-hasPermi="['system:user:resetPwd']"></el-button>
            </template>
          </el-table-column>
        </el-table>
        <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
          @pagination="getList" />
      </el-col>
    </el-row>

    <!-- 添加或修改用户配置对话框 -->
    <el-dialog :title="title" v-model="open" width="600px" append-to-body>
      <el-form :model="form" :rules="rules" ref="userRef" label-width="auto">
        <el-row :gutter="20">
          <el-col :lg="24">
            <el-form-item :label="$t('puser.userName')" prop="userName">
              <el-input :disabled="form.userId != undefined" v-model="form.userName"
                :placeholder="$t('btn.enter')+$t('puser.userName')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.userId == undefined">
            <el-form-item :label="$t('puser.loginPwd')" prop="password">
              <template #label>
                <span>
                  <el-tooltip content="eg: The default password for new users is: 123456" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{$t('puser.loginPwd')}}
                </span>
              </template>
              <el-input v-model="form.password" :placeholder="$t('btn.enter')+$t('puser.loginPwd')" type="password" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('puser.userNick')" prop="nickName">
              <el-input v-model="form.nickName" :placeholder="$t('btn.enter')+$t('puser.userNick')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('puser.deptName')" prop="deptId">
              <el-tree-select v-model="form.deptId" :data="deptOptions"
                :props="{ value: 'id', label: 'label', children: 'children' }" value-key="id"
                :placeholder="$t('btn.select')+$t('puser.deptName')" check-strictly :render-after-expand="false" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('puser.userMobile')" prop="phonenumber">
              <el-input v-model="form.phonenumber" :placeholder="$t('btn.enter')+$t('puser.userMobile')"
                maxlength="11" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('puser.email')" prop="email">
              <el-input v-model="form.email" :placeholder="$t('btn.enter')+$t('puser.email')" maxlength="50" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('puser.sex')">
              <el-radio-group v-model="form.sex" :placeholder="$t('btn.select')+$t('puser.sex')">
                <el-radio v-for="dict in sexOptions" :key="dict.dictValue" :label="parseInt(dict.dictValue)">{{
                  dict.dictLabel }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('puser.userStat')">
              <el-radio-group v-model="form.isStatus">
                <el-radio v-for="dict in statusOptions" :key="dict.dictValue" :label="parseInt(dict.dictValue)">{{
                  dict.dictLabel }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('puser.userPost')">
              <el-select v-model="form.postIds" multiple :placeholder="$t('btn.select')+$t('puser.userPost')"
                class="w100">
                <el-option v-for="item in postOptions" :key="item.postId" :label="item.postName" :value="item.postId"
                  :disabled="item.isStatus == 1">
                </el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('puser.userRole')">
              <el-select v-model="form.roleIds" multiple :placeholder="$t('btn.select')+$t('puser.userRole')"
                style="width: 100%" @change="selectRole($event)">
                <el-option v-for="item in roleOptions" :key="item.roleId" :label="item.roleName" :value="item.roleId"
                  :disabled="item.isStatus == 1">
                  <span style="float: left">{{ item.roleName }}</span>
                  <span style="float: right">{{ item.roleKey }}</span>
                </el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('puser.memo')">
              <el-input v-model="form.reMarks" type="textarea"
                :placeholder="$t('btn.enter')+$t('puser.memo')"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <el-button color="#CDD0D6" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>

    <!-- 用户导入对话框 -->
    <el-dialog :title="upload.title" v-model="upload.open" width="400px" append-to-body>
      <el-upload name="file" ref="uploadRef" :limit="1" accept=".xlsx,.xls" :headers="upload.headers"
        :action="upload.url + '?updateSupport=' + upload.updateSupport" :disabled="upload.isUploading"
        :on-progress="handleFileUploadProgress" :on-success="handleFileSuccess" :auto-upload="false" drag>
        <el-icon class="el-icon--upload">
          <upload-filled />
        </el-icon>
        <div class="el-upload__text">{{$t('upload.Drag')}}<em>{{$t('upload.Clickupload')}}</em></div>
        <template #tip>
          <div class="el-upload__tip text-center">
            <!-- <div class="el-upload__tip">
              <el-checkbox v-model="upload.updateSupport" /> 是否更新已经存在的用户数据
            </div> -->
            <span>{{$t('fupload.uploadFileSizeMsga')}}<b style="color: #f56c6c">{{ $t('fupload.uploadFileSize')
                }}</b>{{$t('fupload.uploadFileSizeMsgb')}}</span>
            <el-link type="primary" :underline="false" style="font-size: 12px; vertical-align: baseline"
              @click="importTemplate">{{$t('fupload.downloadTemplate')}}</el-link>
          </div>
        </template>
      </el-upload>
      <template #footer>
        <el-button @click="upload.open = false">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitFileForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="user">
  import { getToken } from '@/utils/auth'
  import { treeselect } from '@/api/system/dept'
  import { changeUserStatus, listUser, resetUserPwd, delUser, getUser, updateUser, addUser, exportUser } from '@/api/system/user'

  const { proxy } = getCurrentInstance()

  const statusOptions = ref([])
  const sexOptions = ref([])
  proxy.getDicts('sys_normal_disable').then((response) => {
    statusOptions.value = response.data
  })
  proxy.getDicts('sys_user_sex').then((response) => {
    sexOptions.value = response.data
  })
  const userList = ref([])
  const open = ref(false)
  const loading = ref(true)
  const showSearch = ref(true)
  const ids = ref([])
  const single = ref(true)
  const multiple = ref(true)
  const total = ref(0)
  const title = ref('')
  const dateRange = ref([])
  const deptName = ref('')
  const deptOptions = ref(undefined)
  const initPassword = ref(undefined)
  const postOptions = ref([])
  const roleOptions = ref([])
  /*** 用户导入参数 */
  const upload = reactive({
    // 是否显示弹出层（用户导入）
    open: false,
    // 弹出层标题（用户导入）
    title: '',
    // 是否禁用上传
    isUploading: false,
    // 是否更新已经存在的用户数据
    updateSupport: 0,
    // 设置上传的请求头部
    headers: { Authorization: 'Bearer ' + getToken() },
    // 上传的地址
    url: import.meta.env.VITE_APP_BASE_API + '/system/user/importData'
  })
  // 列显隐信息
  const columns = ref([
    { key: 0, label: proxy.$t('puser.userID'), visible: true, prop: 'userId' },
    { key: 1, label: proxy.$t('puser.userName'), visible: true, prop: 'userName' },
    { key: 2, label: proxy.$t('puser.userNick'), visible: true, prop: 'nickName' },
    { key: 3, label: proxy.$t('puser.deptName'), visible: true, prop: 'deptName' },
    { key: 4, label: proxy.$t('puser.userMobile'), visible: true, prop: 'phonenumber' },
    { key: 5, label: proxy.$t('puser.userStat'), visible: true, prop: 'isStatus' },
    { key: 6, label: proxy.$t('puser.Createdate'), visible: true, prop: 'createTime' },
    { key: 7, label: proxy.$t('puser.sex'), visible: false, prop: 'sex' },
    { key: 8, label: proxy.$t('puser.avatar'), visible: false, prop: 'avatar' },
    { key: 9, label: proxy.$t('puser.email'), visible: false, prop: 'email' },
    { key: 10, label: proxy.$t('puser.loginDate'), visible: false, prop: 'loginDate' }
  ])
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
  const data = reactive({
    form: {},
    queryParams: {
      pageNum: 1,
      pageSize: 10,
      userName: undefined,
      phonenumber: undefined,
      isStatus: -1,
      deptId: undefined
    },
    rules: {
      userName: [
        { required: true, message: proxy.$t('puser.userName') + proxy.$t('btn.empty'), trigger: 'blur' },
        {
          min: 6,
          max: 20,
          message: proxy.$t('puser.userNameMemo'),
          trigger: 'blur'
        }
      ],
      nickName: [{ required: true, message: proxy.$t('puser.userNick') + proxy.$t('btn.empty'), trigger: 'blur' }],
      password: [
        { required: true, message: proxy.$t('puser.loginPwd') + proxy.$t('btn.empty'), trigger: 'blur' },
        {
          min: 6,
          max: 20,
          message: proxy.$t('puser.loginPwdMemo'),
          trigger: 'blur'
        }
      ],
      email: [
        {
          required: true,
          type: 'email',
          message: proxy.$t('puser.emailMemo'),
          trigger: ['blur', 'change']
        }
      ],
      phonenumber: [
        {
          pattern: /^1[3|4|5|6|7|8|9][0-9]\d{8}$/,
          message: proxy.$t('puser.userMobileMemo'),
          trigger: 'blur'
        }
      ]
    }
  })

  const { queryParams, form, rules } = toRefs(data)

  proxy.getConfigKey('sys.user.initPassword').then((response) => {
    initPassword.value = response.data
  })

  /** 通过条件过滤节点  */
  const filterNode = (value, data) => {
    if (!value) return true
    return data.label.indexOf(value) !== -1
  }
  /** 根据名称筛选部门树 */
  watch(deptName, (val) => {
    proxy.$refs['deptTreeRef'].filter(val)
  })
  /** 查询部门下拉树结构 */
  function getTreeselect() {
    treeselect().then((response) => {
      deptOptions.value = response.data
    })
  }
  /** 查询用户列表 */
  function getList() {
    loading.value = true
    listUser(proxy.addDateRange(queryParams.value, dateRange.value)).then((res) => {
      loading.value = false
      userList.value = res.data.result
      total.value = res.data.totalNum
    })
  }
  /** 节点单击事件 */
  function handleNodeClick(data) {
    queryParams.value.deptId = data.id
    handleQuery()
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.value.pageNum = 1
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    dateRange.value = []
    proxy.resetForm('queryRef')
    queryParams.value.deptId = undefined
    proxy.$refs.deptTreeRef.setCurrentKey(null)
    handleQuery()
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const userIds = row.userId || ids.value
    proxy.$modal
      .confirm(proxy.$t('common.confirmDel') + userIds + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delUser(userIds)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
      .catch(() => { })
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy.$modal
      .confirm(proxy.$t('common.confirmExport') + proxy.$t('puser.bulkExport'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(async () => {
        await exportUser(queryParams.value)
      })
  }
  /** 用户状态修改  */
  function handleStatusChange(row) {
    let text = row.isStatus === 0 ? proxy.$t('puser.statStart') : proxy.$t('puser.statStop')
    proxy
      .$confirm(proxy.$t('puser.statconfirm') + '< ' + row.userName + ' >' + proxy.$t('puser.statMemo') + text + proxy.$t('puser.statconfirmMemo'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
        //center: true,
        //icon: 'WarnTriangleFilled',
      })

      .then(function () {
        return changeUserStatus(row.userId, row.isStatus)
      })

      .then(() => {
        proxy.$modal.msgSuccess(proxy.$t('puser.userName') + '< ' + row.userName + ' >' + text + proxy.$t('puser.statSucceed'))
      })
      .catch(function () {
        row.isStatus = row.isStatus == 0 ? 1 : 0
      })
  }
  /** 重置密码按钮操作 */
  function handleResetPwd(row) {
    proxy
      .$prompt(proxy.$t('puser.loginPwdinput') + row.userName + proxy.$t('puser.loginPwdinputMemo'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "info",
        //icon: 'InfoFilled',
        //center: true,
        closeOnClickModal: false,
        inputPattern: /^.{5,20}$/,
        inputErrorMessage: proxy.$t('puser.loginPwdMemo')
      })
      .then(({ value }) => {
        resetUserPwd(row.userId, value).then((response) => {
          proxy.$modal.msgSuccess(proxy.$t('puser.loginPwdNew') + value)
        })
      })
      .catch(() => { })
  }
  /** 选择条数  */
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.userId)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }
  /** 导入按钮操作 */
  function handleImport() {
    upload.title = proxy.$t('puser.bulkImport')
    upload.open = true
  }
  /** 下载模板操作 */
  function importTemplate() {
    proxy.download('/system/user/importTemplate', proxy.$t('puser.importTmpl'))
  }
  /**文件上传中处理 */
  const handleFileUploadProgress = (event, file, fileList) => {
    upload.isUploading = true
  }
  /** 文件上传成功处理 */
  const handleFileSuccess = (response, file, fileList) => {
    const { code, msg, data } = response
    upload.open = false
    upload.isUploading = false
    proxy.$refs['uploadRef'].clearFiles()
    proxy.$alert("<div style='overflow: auto;overflow-x: hidden;max-height: 70vh;padding: 10px 20px 0;'>" + data.item1 + '</div>', proxy.$t('puser.importResults'), {
      dangerouslyUseHTMLString: true
    })
    getList()
  }
  /** 提交上传文件 */
  function submitFileForm() {
    proxy.$refs['uploadRef'].submit()
  }
  /** 初始化部门数据 */
  function initTreeData() {
    // 判断部门的数据是否存在，存在不获取，不存在则获取
    if (deptOptions.value === undefined) {
      treeselect().then((response) => {
        deptOptions.value = response.data
      })
    }
  }
  /** 重置操作表单 */
  function reset() {
    form.value = {
      userId: undefined,
      deptId: undefined,
      userName: undefined,
      nickName: undefined,
      password: undefined,
      phonenumber: undefined,
      email: undefined,
      sex: 2,
      isStatus: 0,
      remark: undefined,
      postIds: [],
      roleIds: []
    }
    proxy.resetForm('userRef')
  }
  /** 取消按钮 */
  function cancel() {
    open.value = false
    reset()
  }
  /** 新增按钮操作 */
  function handleAdd() {
    reset()
    initTreeData()
    getUser().then((response) => {
      postOptions.value = response.data.posts
      roleOptions.value = response.data.roles
      open.value = true
      title.value = proxy.$t('btn.add') + proxy.$t('puser.userName')
      form.value.password = initPassword.value
    })
  }
  /** 修改按钮操作 */
  function handleUpdate(row) {
    reset()
    initTreeData()
    const userId = row.userId || ids.value

    getUser(userId).then((response) => {
      var data = response.data
      form.value = {
        userId: data.user.userId,
        deptId: data.user.deptId,
        userName: data.user.userName,
        nickName: data.user.nickName,
        password: '',
        phonenumber: data.user.phonenumber,
        email: data.user.email,
        sex: data.user.sex,
        isStatus: data.user.isStatus,
        remark: data.user.remark,
        postIds: data.postIds,
        roleIds: data.roleIds
      }
      roleOptions.value = response.data.roles
      postOptions.value = response.data.posts
      open.value = true
      title.value = proxy.$t('btn.edit') + proxy.$t('puser.userName')
      form.password = ''
    })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['userRef'].validate((valid) => {
      if (valid) {
        if (form.value.userId != undefined) {
          updateUser(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addUser(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
        }
      }
    })
  }
  /**
   * 解决编辑时角色选中不了问题
   */
  function selectRole(e) {
    proxy.$forceUpdate()
  }
  getTreeselect()
  getList()
</script>
<style scoped>
  .avatar {
    width: 40px;
  }
</style>