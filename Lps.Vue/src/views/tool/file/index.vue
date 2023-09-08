<template>
  <div class="app-container">
    <!-- :model属性用于表单验证使用 比如下面的el-form-item 的 prop属性用于对表单值进行验证操作 -->
    <el-form :model="queryParams" label-position="left" inline ref="queryForm" v-show="showSearch" @submit.prevent>
      <el-form-item label="" prop="fileId">
        <el-input v-model="queryParams.fileId" :placeholder="$t('btn.enter')+$t('fupload.fileID')" clearable
          size="small" />
      </el-form-item>
      <el-form-item label="">
        <el-date-picker v-model="dateRangeAddTime" type="daterange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
          :placeholder="$t('btn.dateselect')" size="small"></el-date-picker>
      </el-form-item>
      <el-form-item label="" prop="storeType">
        <!-- <el-select v-model="queryParams.storeType" :placeholder="$t('btn.select')+$t('fupload.storageType')" clearable=""
          size="small">
          <el-option v-for="item in storeTypeOptions" :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue"></el-option>
        </el-select> -->
        <el-radio-group v-model="queryParams.storeType" :placeholder="$t('btn.select')+$t('fupload.storageType')">
          <el-radio-button> {{$t('layout.all')}} </el-radio-button>
          <el-radio-button v-for="item in storeTypeOptions" :key="item.dictValue" :label="item.dictValue">
            {{ item.dictLabel }}
          </el-radio-button>
        </el-radio-group>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" size="small" icon="search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button type="danger" icon="refresh" size="small" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" size="small" v-hasPermi="['tool:file:add']" plain icon="upload" @click="handleAdd">
          {{ $t('btn.upload') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['tool:file:delete']" size="small" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <right-toolbar :showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <!-- <el-table-column prop="id" label="文件id" align="center" width="150" /> -->
      <el-table-column prop="fileName" :label="$t('fupload.fileDown')" align="left" :show-overflow-tooltip="true">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.accessUrl" target="_blank">{{ scope.row.fileName }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="accessUrl" align="center" :label="$t('fupload.filePreview')">
        <template #default="{ row }">
          <el-image preview-teleported :src="row.accessUrl" :preview-src-list="[row.accessUrl]"
            :hide-on-click-modal="true" fit="contain" lazy class="el-avatar">
            <template #error>
              <el-icon class="el-avatar" style="background:rgb(64, 60, 88); color: white">
                <Hide />
              </el-icon>
            </template>
          </el-image>
        </template>
      </el-table-column>
      <el-table-column prop="fileSize" :label="$t('fupload.fileSize')" align="center" :show-overflow-tooltip="true"
        width="180px" />
      <el-table-column prop="fileExt" :label="$t('fupload.fileExt')" align="center" :show-overflow-tooltip="true"
        width="80px" />
      <!-- <el-table-column prop="storeType" label="存储类型" align="center">
        <template #default="scope">
          <dict-tag :options="storeTypeOptions" :value="parseInt(scope.row.storeType)" />
        </template>
      </el-table-column> -->
      <!-- <el-table-column prop="accessUrl" label="访问路径">
        <template #default="scope">
          <el-link target="_blank" v-bind:href="scope.row.accessUrl">
            {{scope.row.accessUrl}}
          </el-link>
        </template>

      </el-table-column> -->
      <el-table-column prop="create_by" :label="$t('fupload.fileOperator')" align="center" width="180px" />
      <el-table-column prop="create_time" :label="$t('fupload.fileCreatedate')" align="center" width="180px" />
      <el-table-column :label="$t('fupload.fileOperation')" align="center" width="220">
        <template #default="scope">
          <el-button color="#826aef" size="small" plain icon="view" :title="$t('btn.view')"
            @click="handleView(scope.row)"></el-button>
          <el-button class="copy-btn-main" plain icon="document-copy" :title="$t('btn.copy')" color="blue" size="small"
            @click="copyText(scope.row.accessUrl)"> </el-button>
          <el-button v-hasPermi="['tool:file:delete']" :title="$t('btn.delete')" type="danger" plain size="small"
            icon="delete" @click="handleDelete(scope.row)"> </el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改文件存储对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" width="850px" draggable>
      <el-form ref="formRef" :model="form" :rules="rules" label-width="90px" label-position="left">
        <el-row>
          <el-col :lg="24">
            <el-form-item :label="proxy.$t('upload.StorageType')" label-width="auto" prop="storeType">
              <el-radio-group v-model="form.storeType" :placeholder="proxy.$t('upload.StorageType')">
                <el-radio-button v-for="item in storeTypeOptions" :key="item.dictValue"
                  :label="parseInt(item.dictValue)">
                  {{ item.dictLabel }}
                </el-radio-button>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('upload.StorageFolder')" label-width="auto" prop="storePath">
              <template #label>
                <span>
                  <el-tooltip :content="$t('upload.defaultStorageFolder')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{$t('upload.StorageFolder')}}
                </span>
              </template>
              <!-- <el-input v-model="form.storePath" placeholder="请输入文件目录，默认yyyy/MMdd格式" clearable="" auto-complete="" /> -->
              <el-select style="width: 100%" v-model="form.storePath" allow-create clearable filterable
                default-first-option :reserve-keyword="false" :placeholder="$t('upload.defaultStorageFolder')">
                <el-option v-for="item in saveDirOptions" :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue" />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="proxy.$t('upload.Filenamerules')" label-width="auto" prop="fileNameType">
              <el-radio-group v-model="form.fileNameType" :placeholder="proxy.$t('upload.Filenamerules')">
                <el-radio v-for="item in fileNameTypeOptions" :key="item.dictValue" :label="parseInt(item.dictValue)">
                  {{ item.dictLabel }}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.fileNameType == 2">
            <el-form-item label-width="auto" :label="proxy.$t('upload.Customfilenames')" prop="fileName">
              <el-input v-model="form.fileName" :placeholder="proxy.$t('upload.Customfilenames')" clearable="" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <UploadFile ref="uploadRef" v-model="form.accessUrl" :fileType="[]" :fileSize="100" :drag="true"
              :data="uploadData" :autoUpload="false" @success="handleUploadSuccess" />
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="submitUpload">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>

    <!-- 添加或修改文件存储对话框 -->
    <el-dialog :title="$t('fupload.viewTitlename')" :lock-scroll="false" v-model="openView">
      <el-form ref="form" :model="formView" :rules="rules" label-width="100px">
        <el-row>
          <el-col :lg="12">
            <el-form-item label-width="auto" :label="$t('fupload.fileID') +':'">{{ formView.id }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label-width="auto" :label="$t('fupload.viewSourcefilee')">{{ formView.realName
              }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label-width="auto" :label="$t('fupload.viewFiletype')">
              <el-tag>{{ formView.fileType }}</el-tag>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label-width="auto" :label="$t('fupload.viewFileext')">
              <el-tag>{{ formView.fileExt }}</el-tag>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label-width="auto" :label="$t('fupload.viewFilename')">{{ formView.fileName }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label-width="auto" :label="$t('fupload.viewFilestorage')">{{ formView.storePath
              }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label-width="auto" :label="$t('fupload.viewFilesize')">{{ formView.fileSize }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label-width="auto" :label="$t('fupload.viewFilecreate')">{{ formView.create_by
              }}</el-form-item>
          </el-col>
          <el-col :lg="24" v-if="['.png', '.jpg', '.jpeg'].includes(formView.fileExt)">
            <el-form-item label-width="auto" :label="$t('fupload.viewFilethumbnail')">
              <el-image :src="formView.accessUrl" fit="contain" style="width: 100px"></el-image>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item label-width="auto" :label="$t('fupload.viewFileurl')">
              {{ formView.accessUrl }}
              <el-button class="copy-btn-main" icon="document-copy" text @click="copyText(formView.accessUrl)">
                {{ $t('btn.copy') }}
              </el-button>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item label-width="auto" :label="$t('fupload.viewFilestoragepath')">
              <div>
                {{ formView.fileUrl }}
              </div>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
    </el-dialog>
  </div>
</template>
<script setup name="file">
  import { listSysfile, delSysfile, getSysfile } from '@/api/tool/file.js'
  import { useClipboard } from '@vueuse/core'

  const { proxy } = getCurrentInstance()
  // 选中id数组
  const ids = ref([])
  // 非单个禁用
  const single = ref(true)
  // 非多个禁用
  const multiple = ref(true)
  // 遮罩层
  const loading = ref(true)
  // 显示搜索条件
  const showSearch = ref(true)
  // 弹出层标题
  const title = ref('')
  // 是否显示弹出层
  const open = ref(false)
  const openView = ref(false)
  // 表单
  const formRef = ref(null)
  const formView = ref({})
  const uploadRef = ref(null)
  // 上传时间时间范围
  const dateRangeAddTime = ref([])
  // 存储类型选项列表
  const storeTypeOptions = ref([
    { dictLabel: proxy.$t('upload.localStorage'), dictValue: 1 },
    { dictLabel: proxy.$t('upload.aliyunStorage'), dictValue: 2, }
  ])
  //文件名产生选项列表
  const fileNameTypeOptions = ref([
    { dictLabel: proxy.$t('upload.originalFilename'), dictValue: 1 },
    { dictLabel: proxy.$t('upload.customizationFilename'), dictValue: 2 },
    { dictLabel: proxy.$t('upload.autoFilename'), dictValue: 3 }
  ])
  // 存储目录前缀
  const saveDirOptions = ref([
    { dictLabel: proxy.$t('upload.avatarFolder'), dictValue: 'uploads\\avatar' },
    { dictLabel: proxy.$t('upload.videoFolder'), dictValue: 'uploads\\video' },
    { dictLabel: proxy.$t('upload.ppFolder'), dictValue: 'uploads\\pp\\ec' },
    { dictLabel: proxy.$t('upload.gmFolder'), dictValue: 'uploads\\office\\notices' }
  ])
  // 数据列表
  const dataList = ref([])
  // 总记录数
  const total = ref(0)

  const state = reactive({
    form: {
      storeType: 1
    },
    rules: {
      accessUrl: [
        {
          required: true,
          message: '上传文件' + proxy.$t('btn.isEmpty'),
          trigger: 'blur'
        }
      ],
      storeType: [
        {
          required: true,
          message: '存储类型' + proxy.$t('btn.isEmpty'),
          trigger: 'blur'
        }
      ],
      fileName: [
        {
          required: true,
          message: '文件名' + proxy.$t('btn.isEmpty'),
          trigger: 'blur'
        }
      ]
    },
    queryParams: {
      pageNum: 1,
      pageSize: 17,
      storeType: 1, // 存储类型 1、本地 2、阿里云
      fileId: undefined
    }
  })
  const { queryParams, form, rules } = toRefs(state)

  const uploadData = ref()
  // 查询数据
  function getList() {
    proxy.addDateRange(queryParams.value, dateRangeAddTime.value, 'Create_time')
    loading.value = true
    listSysfile(queryParams.value).then((res) => {
      if (res.code == 200) {
        dataList.value = res.data.result
        total.value = res.data.totalNum
        loading.value = false
      }
    })
  }
  // 取消按钮
  function cancel() {
    open.value = false
    reset()
  }
  // 重置数据表单
  function reset() {
    form.value = {
      fileName: '',
      fileUrl: '',
      storePath: '',
      fileSize: 0,
      fileExt: '',
      storeType: 1,
      accessUrl: '',
      fileNameType: 1
    }
    proxy.resetForm('formRef')
  }
  /** 重置查询操作 */
  function resetQuery() {
    // 上传时间时间范围
    dateRangeAddTime.value = []
    proxy.resetForm('queryForm')
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.id)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  /** 新增按钮操作 */
  function handleAdd() {
    reset()
    open.value = true
    title.value = proxy.$t('btn.upload')
    // form.value.storeType = queryParams.storeType
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const Ids = row.id || ids.value

    proxy
      .$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delSysfile(Ids)
      })
      .then(() => {
        handleQuery()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
      .catch(() => { })
  }
  /** 查看按钮操作 */
  function handleView(row) {
    const id = row.id || ids.value
    getSysfile(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        openView.value = true
        formView.value = data
      }
    })
  }
  // 上传成功方法
  function handleUploadSuccess(filelist) {
    open.value = false
    getList()
  }
  // 手动上传
  function submitUpload() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        var result = new Promise((resolve) => {
          uploadData.value = {
            fileDir: form.value.storePath,
            fileName: form.value.fileName,
            storeType: form.value.storeType,
            fileNameType: form.value.fileNameType
          }
          resolve(true)
        })
        //使用异步解决第一次上次获取不到表单的值
        result.then(() => {
          proxy.$refs.uploadRef.submitUpload()
        })
      }
    })
  }

  const { copy, isSupported } = useClipboard()
  const copyText = async (val) => {
    if (isSupported) {
      copy(val)
      proxy.$modal.msgSuccess(proxy.$t('common.copySucceed'))
    } else {
      proxy.$modal.msgError(proxy.$t('layout.mybrowserNg'))
    }
  }
  handleQuery()
</script>
<style scoped>
  .el-avatar {
    display: inline-block;
    text-align: center;
    background: #ccc;
    color: #fff;
    white-space: nowrap;
    position: relative;
    overflow: hidden;
    vertical-align: middle;
    width: 32px;
    height: 32px;
    line-height: 32px;
    border-radius: 16px;
  }
</style>