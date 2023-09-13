<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch" label-width="auto">
      <el-form-item :label="$t('pjob.jobName')" prop="jobName">
        <el-input v-model="queryParams.jobName" :placeholder="$t('btn.enter')+$t('pjob.jobName')" clearable
          style="width: 240px" @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('pjob.jobGroup')" prop="jobGroup">
        <el-select v-model="queryParams.jobGroup" :placeholder="$t('btn.select')+$t('pjob.jobGroup')" clearable
          style="width: 240px" size="small">
          <el-option v-for="dict in jobGroupOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('pjob.isStatus')" prop="isStatus">
        <el-select v-model="queryParams.isStatus" :placeholder="$t('btn.select')+$t('pjob.isStatus')" clearable
          style="width: 240px" size="small">
          <el-option v-for="dict in statusOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('pjob.createTime')">
        <el-date-picker v-model="dateRange" value-format="YYYY-MM-DD HH:mm:ss" type="datetimerange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')" :shortcuts="dateOptions"
          size="small"></el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" size="small" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button type="info" plain icon="refresh" size="small" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" :disabled="multiple" size="small" @click="handleDelete"
          v-hasPermi="['PRIV_JOBLOG_DELETE']"> {{ $t('btn.delete') }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" size="small" @click="handleClean" :disabled="total <= 0"
          v-hasPermi="['PRIV_JOBLOG_REMOVE']"> {{ $t('btn.clean') }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport"
          v-hasPermi="['PRIV_JOBLOG_EXPORT']"> {{ $t('btn.export') }}</el-button>
      </el-col>
      <right-toolbar :showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table v-loading="loading" :data="jobLogList" @selection-change="handleSelectionChange" height="652"
      style="width: 100%">
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column :label="$t('pjob.jobLogId')" width="80" align="center" prop="jobLogId" />
      <el-table-column :label="$t('pjob.jobName')" align="center" prop="jobName" :show-overflow-tooltip="true" />
      <el-table-column :label="$t('pjob.jobGroup')" align="center" prop="" :formatter="jobGroupFormat"
        :show-overflow-tooltip="true" />
      <el-table-column :label="$t('pjob.invokeTarget')" align="center" prop="invokeTarget"
        :show-overflow-tooltip="true" />
      <el-table-column :label="$t('pjob.jobMessage')" align="center" prop="jobMessage" :show-overflow-tooltip="true" />
      <el-table-column :label="$t('pjob.isStatus')" align="center" prop="isStatus">
        <template #default="scope">
          <dict-tag :options="statusOptions" :value="scope.row.isStatus" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('pjob.elapsed')" align="center" prop="elapsed">
        <template #default="scope">
          <span
            :style="scope.row.elapsed < 1000 ? 'color:green' : scope.row.elapsed < 3000 ? 'color:orange' : 'color:red'">
            {{ Math.floor(scope.row.elapsed) / 1000 }} ms
          </span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('pjob.createTime')" align="center" prop="createTime" width="180">
        <template #default="scope">
          <span>{{ parseTime(scope.row.createTime) }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" width="180" align="center" class-name="small-padding fixed-width">
        <template #default="scope">
          <el-button color="#667ecc" plain icon="view" size="small" @click="handleView(scope.row)"
            title="$t('btn.details')"></el-button>
        </template>
      </el-table-column>
    </el-table>

    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 调度日志详细 -->
    <el-dialog :title="$t('pjob.logdetails')" v-model="open" width="700px" append-to-body>
      <el-form ref="formRef" :model="form" label-width="auto">
        <el-row>
          <el-col :span="12">
            <el-form-item :label="$t('pjob.jobLogId')">{{ form.jobLogId }}</el-form-item>
            <el-form-item :label="$t('pjob.jobName')">{{ form.jobName }}</el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item :label="$t('pjob.jobGroup')">{{ form.jobGroup }}</el-form-item>
            <el-form-item :label="$t('pjob.createTime')">{{ form.createTime }}</el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item :label="$t('pjob.invokeTarget')">{{ form.invokeTarget }}</el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item :label="$t('pjob.jobMessage')">{{ form.jobMessage }}</el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item :label="$t('pjob.isStatus')">
              <div v-if="form.isStatus == 0">{{$t('pjob.Normal')}}</div>
              <div v-else-if="form.isStatus == 1">{{$t('pjob.Failure')}}</div>
            </el-form-item>
          </el-col>
          <el-col :span="24" v-if="form.isStatus == 1">
            <el-form-item :label="$t('pjob.exception')">{{ form.exception }}</el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="open = false">{{$t('btn.close')}}</el-button>
        </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="job/log">
  import { listJobLog, delJobLog, exportJobLog, cleanJobLog } from '@/api/monitor/jobLog'
  const { proxy } = getCurrentInstance()
  const route = useRoute()

  const loading = ref(true)
  const ids = ref([])
  const multiple = ref(true)
  const showSearch = ref(true)
  const total = ref(0)
  const jobLogList = ref([])
  const open = ref(false)
  const dateRange = ref([])
  const statusOptions = ref([])
  const jobGroupOptions = ref([])
  const formRef = ref()

  const data = reactive({
    form: {},
    queryParams: {
      pageNum: 1,
      pageSize: 10,
      jobName: undefined,
      jobGroup: undefined,
      status: undefined,
      jobId: undefined
    }
  })

  const { form, queryParams } = toRefs(data)
  queryParams.value.jobId = route.query.jobId

  proxy.getDicts('sys_job_status').then((response) => {
    statusOptions.value = response.data
  })
  proxy.getDicts('sys_job_group').then((response) => {
    jobGroupOptions.value = response.data
  })

  /** 查询调度日志列表 */
  function getList() {
    loading.value = true
    listJobLog(proxy.addDateRange(queryParams.value, dateRange.value)).then((response) => {
      jobLogList.value = response.data.result
      total.value = response.data.totalNum
      loading.value = false
    })
  }

  // 任务组名字典翻译
  function jobGroupFormat(row, column) {
    return proxy.selectDictLabel(jobGroupOptions.value, row.jobGroup)
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
  function reset() {
    form.value = {
      createTime: undefined,
      elapsed: 0,
      exception: undefined,
      invokeTarget: undefined,
      jobGroup: undefined,
      jobId: 0,
      jobLogId: 0,
      jobMessage: undefined,
      jobName: undefined,
      status: undefined
    }
    proxy.resetForm('formRef')
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.jobLogId)
    multiple.value = !selection.length
  }
  /** 详细按钮操作 */
  function handleView(row) {
    reset()
    open.value = true
    form.value = row
    console.log(row)
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const jobLogIds = ids.value
    proxy
      .$confirm(proxy.$t('common.confirmDel') + jobLogIds + proxy.$t('common.confirmDelDataitems'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return delJobLog(jobLogIds)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
  }
  /** 清空按钮操作 */
  function handleClean() {
    proxy
      .$confirm(proxy.$t('common.confirmClean'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return cleanJobLog()
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Cleancompleted'))
      })
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.confirmExport') + proxy.$t('pjob.jobMessage'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return exportJobLog(queryParams.value)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }
  handleQuery()
</script>