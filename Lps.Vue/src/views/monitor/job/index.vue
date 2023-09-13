<template>
  <div class="app-container">
    <el-form :model="queryParams" inline @submit.prevent ref="queryRef" v-show="searchToggle" label-width="auto">
      <el-form-item :label="$t('pjob.taskType')" prop="taskType">
        <el-select clearable v-model="queryParams.taskType" :placeholder="$t('btn.select')+$t('pjob.taskType')"
          size="small">
          <el-option v-for="item in options.taskTypeOptions" :key="item.dictValue" :label="item.dictLabel"
            :value="parseInt(item.dictValue)" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('pjob.queryText')" prop="queryText">
        <el-input v-model="queryParams.queryText" :placeholder="$t('btn.enter')+$t('pjob.queryText')" clearable
          prefix-icon="el-icon-search" @keyup.enter="handleQuery" @clear="handleQuery" size="small" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" size="small" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button type="info" plain icon="refresh" size="small" @click="handleReset">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row class="mb8" :gutter="20">
      <el-col :span="1.5">
        <el-button v-hasPermi="['monitor:job:add']" plain type="primary" icon="plus" size="small" @click="handleCreate">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport"
          v-hasPermi="['monitor:job:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button plain v-hasPermi="['monitor:job:query']" type="info" icon="operation" size="small"
          @click="onJobLogView()">
          {{ $t('btn.log') }}
        </el-button>
      </el-col>
      <right-toolbar :showSearch="searchToggle" :columns="columns" @queryTable="handleQuery"></right-toolbar>
    </el-row>
    <el-row>
      <!-- 数据区域 -->
      <el-table ref="tasks" v-loading="loading" :data="dataTasks" border="" row-key="id" @sort-change="handleSortable">
        <!-- <el-table-column type="index" :index="handleIndexCalc" label="#" align="center" /> -->
        <el-table-column prop="id" label="id" align="center" :show-overflow-tooltip="true"
          v-if="columns.showColumn('id')" />
        <el-table-column prop="name" :label="$t('pjob.name')" width="100" />
        <el-table-column prop="taskType" :label="$t('pjob.taskType')" align="center" width="140"
          v-if="columns.showColumn('taskType')">
          <template #default="scope">
            <dict-tag :options="options.taskTypeOptions" :value="scope.row.taskType" />
          </template>
        </el-table-column>
        <el-table-column prop="triggerType" :label="$t('pjob.triggerType')" align="center" width="120"
          v-if="columns.showColumn('triggerType')">
          <template #default="scope">
            <dict-tag :options="options.triggerTypeOptions" :value="scope.row.triggerType" />
          </template>
        </el-table-column>
        <el-table-column sortable prop="isStart" align="center" :label="$t('pjob.isStart')" width="140">
          <template #default="scope">
            <dict-tag :value="scope.row.isStart" :options="options.isStartOptions"></dict-tag>
          </template>
        </el-table-column>
        <el-table-column prop="jobGroup" :show-overflow-tooltip="true" align="center" :label="$t('pjob.jobGroup')"
          width="120" v-if="columns.showColumn('jobGroup')" />
        <el-table-column prop="assemblyName" :label="$t('pjob.assemblyName')" v-if="columns.showColumn('assemblyName')"
          :show-overflow-tooltip="true" />
        <el-table-column prop="className" :label="$t('pjob.className')" v-if="columns.showColumn('className')" />
        <el-table-column prop="runTimes" align="center" :label="$t('pjob.runTimes')" width="100" />
        <el-table-column prop="intervalSecond" align="center" :label="$t('pjob.intervalSecond')"
          v-if="columns.showColumn('intervalSecond')" width="90" />
        <el-table-column prop="cron" align="center" :label="$t('pjob.cron')" v-if="columns.showColumn('cron')"
          :show-overflow-tooltip="true" />
        <el-table-column prop="reMarks" align="center" :label="$t('pjob.reMarks')" v-if="columns.showColumn('reMarks')"
          :show-overflow-tooltip="true" />
        <el-table-column prop="jobParams" :label="$t('pjob.jobParams')" align="center" :show-overflow-tooltip="true"
          v-if="columns.showColumn('jobParams')" />
        <el-table-column prop="lastRunTime" :label="$t('pjob.lastRunTime')" align="center" :show-overflow-tooltip="true"
          v-if="columns.showColumn('lastRunTime')" />
        <el-table-column prop="apiUrl" :label="$t('pjob.apiUrl')" v-if="columns.showColumn('apiUrl')" />
        <el-table-column :label="$t('btn.operation')" width="220" align="center">
          <template #default="scope">
            <el-button-group class="ml-4">
              <el-button color="#663cee" size="small" icon="view" v-hasPermi="['monitor:job:query']"
                @click="handleDetails(scope.row)" :title="$t('btn.details')">
              </el-button>
              <el-button type="success" size="small" icon="document" v-hasPermi="['monitor:job:query']"
                @click="handleJobLog(scope.row)" :title="$t('btn.log')">
              </el-button>
              <el-dropdown @command="handleCommand($event, scope.row)">
                <el-button color="#333cee" size="small" icon="arrow-down" :title="$t('btn.more')">
                </el-button>
                <template #dropdown>
                  <el-dropdown-menu>
                    <div v-hasPermi="['monitor:job:run']" v-if="scope.row.isStart">
                      <el-dropdown-item command="run">
                        <el-button icon="remove" :title="$t('pjob.runOnce')"> {{ $t('pjob.runOnce') }} </el-button>
                      </el-dropdown-item>
                    </div>
                    <div v-if="scope.row.isStart" v-hasPermi="['monitor:job:stop']">
                      <el-dropdown-item command="stop">
                        <el-button type="danger" icon="video-pause" :title="$t('pjob.runStop')">
                          {{ $t('pjob.runStop') }}
                        </el-button>
                      </el-dropdown-item>
                    </div>
                    <div v-if="!scope.row.isStart" v-hasPermi="['monitor:job:start']">
                      <el-dropdown-item command="start">
                        <el-button type="primary" icon="video-play" :title="$t('btn.start')">
                          {{ $t('btn.start') }}
                        </el-button>
                      </el-dropdown-item>
                    </div>
                    <div v-if="!scope.row.isStart" v-hasPermi="['monitor:job:edit']">
                      <el-dropdown-item command="update">
                        <el-button type="success" icon="edit" :title="$t('btn.edit')">
                          {{ $t('btn.edit') }}
                        </el-button>
                      </el-dropdown-item>
                    </div>
                    <div v-if="!scope.row.isStart" v-hasPermi="['monitor:job:delete']">
                      <el-dropdown-item command="delete">
                        <el-button type="danger" icon="delete" :title="$t('btn.delete')">
                          {{ $t('btn.delete') }}
                        </el-button>
                      </el-dropdown-item>
                    </div>
                  </el-dropdown-menu>
                </template>
              </el-dropdown>
            </el-button-group>
          </template>
        </el-table-column>
      </el-table>
      <pagination v-model:total="total" v-model:page="queryParams.PageNum" v-model:limit="queryParams.pageSize"
        @pagination="getList" />
    </el-row>
    <!-- 添加或修任务管理对话框 -->
    <el-dialog :title="title" v-model="open" width="650px" draggable append-to-body>
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-row>
          <el-col :lg="24" v-if="form.id">
            <el-form-item label="ID">
              <div>{{ form.id }}</div>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('pjob.name')" maxlength="200" prop="name">
              <el-input v-model="form.name" :placeholder="$t('btn.enter')+$t('pjob.name')" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('pjob.triggerType')" prop="triggerType">
              <el-select v-model="form.triggerType" :placeholder="$t('btn.select')+$t('pjob.triggerType')"
                style="width: 100%">
                <el-option v-for="item in options.triggerTypeOptions" :key="item.dictValue" :label="item.dictLabel"
                  :value="parseInt(item.dictValue)" />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('pjob.jobGroup')" maxlength="200" prop="jobGroup">
              <el-select v-model="form.jobGroup" :placeholder="$t('btn.select')+$t('pjob.jobGroup')">
                <el-option v-for="dict in options.jobGroupOptions" :key="dict.dictValue" :label="dict.dictLabel"
                  :value="dict.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pjob.taskType')" prop="taskType">
              <el-radio-group v-model="form.taskType">
                <el-radio :label="1">{{$t('pjob.runassemblyName')}}</el-radio>
                <el-radio :label="2">{{$t('pjob.runapiUrl')}}</el-radio>
                <el-radio :label="3">{{$t('pjob.runsqlText')}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24" v-if="form.taskType == 2">
            <el-form-item :label="$t('pjob.apiUrl')" prop="apiUrl">
              <el-input v-model="form.apiUrl" :placeholder="$t('btn.enter')+$t('pjob.apiUrl')">
                <template #prepend>
                  <el-select v-model="form.requestMethod" :placeholder="$t('btn.select')+$t('pjob.apiUrlmethod')"
                    style="width: 125px">
                    <el-option label="GET" value="GET" />
                    <el-option label="POST" value="POST" />
                  </el-select>
                </template>
              </el-input>
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.taskType == 3">
            <el-form-item :label="$t('pjob.sqlText')" prop="sqlText">
              <el-input :rows="5" type="textarea" v-model="form.sqlText"
                :placeholder="$t('btn.enter')+$t('pjob.sqlText')"> </el-input>
            </el-form-item>
          </el-col>
          <template v-if="form.taskType == 1">
            <el-col :lg="24">
              <el-form-item :label="$t('pjob.assemblyName')" maxlength="200" prop="assemblyName">
                <el-input v-model="form.assemblyName" :placeholder="$t('btn.enter')+$t('pjob.assemblyName')" />
              </el-form-item>
            </el-col>
            <el-col :lg="24">
              <el-form-item :label="$t('pjob.className')" maxlength="200" prop="className">
                <el-input v-model="form.className" :placeholder="$t('btn.enter')+$t('pjob.className')" />
              </el-form-item>
            </el-col>
          </template>

          <el-col :lg="24">
            <el-form-item :label="$t('pjob.jobParams')" prop="jobParams">
              <template #label>
                <span>
                  <el-tooltip content="eg：{ token: abc123} or token=abc123&uid=1000" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{$t('pjob.jobParams')}}
                </span>
              </template>

              <el-input v-model="form.jobParams" :placeholder="$t('btn.enter')+$t('pjob.jobParams')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.triggerType == 1">
            <el-form-item :label="$t('pjob.cron')" prop="cron">
              <el-input v-model="form.cron" :placeholder="$t('btn.enter')+$t('pjob.cron')">
                <template #append>
                  <el-button type="primary" @click="handleShowCron" style="width: 100px">
                    {{$t('pjob.cron')}}
                    <el-icon><time /></el-icon>
                  </el-button>
                </template>
              </el-input>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('pjob.beginTime')" prop="beginTime">
              <template #label>
                <span>
                  <el-tooltip :content="$t('pjob.beginTimeMemo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{$t('pjob.beginTime')}}
                </span>
              </template>
              <el-date-picker v-model="form.beginTime" style="width: 100%" type="date"
                :placeholder="$t('btn.select')+$t('pjob.beginTime')" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('pjob.endTime')" prop="endTime">
              <el-date-picker v-model="form.endTime" style="width: 100%" type="date"
                :placeholder="$t('btn.select')+$t('pjob.endTime')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item v-show="form.triggerType == 0" :label="$t('pjob.intervalSecond')" prop="intervalSecond">
              <el-input-number v-model="form.intervalSecond" :max="9999999999" step-strictly controls-position="right"
                :min="1" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pjob.reMarks')" prop="reMarks">
              <el-input type="textarea" v-model="form.reMarks" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pjob.lastRunTime')" prop="lastRunTime">
              {{ form.lastRunTime }}
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer v-if="btnVisible">
        <div class="dialog-footer">
          <el-button type="info" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>

    <el-dialog :title="$t('pjob.CronGen')" v-model="openCron" append-to-body destroy-on-close>
      <crontab ref="crontabRef" @hide="openCron = false" @fill="crontabFill" :expression="expression"></crontab>
    </el-dialog>

    <el-drawer :title="logTitle" v-model="drawer">
      <el-form :inline="true" @submit.prevent>
        <el-form-item>
          <el-date-picker v-model="logForm.beginTime" :placeholder="$t('btn.select')" :shortcuts="dateOptions" clearable
            type="date" />
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="search" @click="handleJobLog">{{ $t('btn.search') }}</el-button>
        </el-form-item>
      </el-form>

      <el-timeline>
        <el-timeline-item :timestamp="item.createTime" placement="top" v-for="(item, i) in jobLogList" :key="i">
          <h4>{{ item.jobMessage }}</h4>
          <p style="color: red">{{ item.exception }}</p>
        </el-timeline-item>
      </el-timeline>
      <el-empty v-if="jobLogList.length <= 0"></el-empty>
    </el-drawer>
  </div>
</template>

<script setup name="job">
  import { queryTasks, getTasks, createTasks, updateTasks, deleteTasks, startTasks, stopTasks, runTasks, exportTasks } from '@/api/monitor/job'
  import { listJobLog } from '@/api/monitor/jobLog'
  import Crontab from '@/components/Crontab'

  const router = useRouter()
  const { proxy } = getCurrentInstance()
  // 是否显示Cron表达式弹出层
  const openCron = ref(false)
  // 传入的表达式
  const expression = ref('')
  const drawer = ref(false)
  // 是否显示弹出层
  const open = ref(false)
  // 表单标题
  const title = ref('')
  // 显示搜索
  const searchToggle = ref(true)
  // 合计条数
  const total = ref(0)
  // 遮罩层
  const loading = ref(false)
  // 查询参数
  const queryParams = reactive({
    queryText: undefined,
    PageNum: 1,
    pageSize: 14,
    orderby: '',
    sort: '',
    taskType: undefined
  })
  const columns = ref([
    // { visible: true, prop: 'name', label: '名称' },
    { visible: true, prop: 'taskType', label: '任务类型' },
    { visible: true, prop: 'triggerType', label: '触发器类型' },
    { visible: true, prop: 'jobGroup', label: '任务分组' },
    { visible: true, prop: 'assemblyName', label: '程序集名称' },
    { visible: true, prop: 'className', label: '类名' },
    { visible: true, prop: 'lastRunTime', label: '最后运行时间' },
    { visible: false, prop: 'reMarks', label: '备注' },
    { visible: false, prop: 'id', label: '任务id' },
    { visible: false, prop: 'cron', label: 'cron表达式' },
    // { visible: true, prop: 'runTimes', label: '运行次数' },
    // { visible: false, prop: 'beginTime', label: '开始时间' },
    // { visible: false, prop: 'endTime', label: '结束时间' },
    { visible: false, prop: 'intervalSecond', label: '执行每隔(s)' },
    // { visible: false, prop: 'isStart', label: '是否启动' },
    { visible: false, prop: 'jobParams', label: '任务参数' },
    { visible: false, prop: 'apiUrl', label: '网络请求地址' }
    // { visible: false, prop: 'sqlText', label: 'sql脚本' }
  ])
  // 计划任务列表
  const dataTasks = ref([])
  // 任务日志列表
  const jobLogList = ref([])
  const logTitle = ref('')
  const formRef = ref(null)
  const queryRef = ref(null)

  const state = reactive({
    form: {},
    // 表单校验
    rules: {
      name: [{ required: true, message: proxy.$t('pjob.name') + proxy.$t('btn.empty'), trigger: 'blur' }],
      jobGroup: [{ required: true, message: proxy.$t('pjob.jobGroup') + proxy.$t('btn.empty'), trigger: 'blur' }],
      assemblyName: [{ required: true, message: proxy.$t('pjob.runassemblyName') + proxy.$t('btn.empty'), trigger: 'blur' }],
      className: [{ required: true, message: proxy.$t('pjob.className') + proxy.$t('btn.empty'), trigger: 'blur' }],
      triggerType: [{ required: true, message: proxy.$t('pjob.triggerType') + proxy.$t('btn.empty'), trigger: 'blur' }],
      apiUrl: [{ required: true, message: proxy.$t('pjob.runapiUrl') + proxy.$t('btn.empty'), trigger: 'blur' }],
      cron: [{ required: true, message: proxy.$t('pjob.cron') + proxy.$t('btn.empty'), trigger: 'change' }],
      beginTime: [{ required: false, message: proxy.$t('pjob.beginTime') + proxy.$t('btn.empty'), trigger: 'blur' }],
      endTime: [{ required: false, message: proxy.$t('pjob.endTime') + proxy.$t('btn.empty'), trigger: 'blur' }],
      intervalSecond: [{ message: proxy.$t('pjob.intervalSecond') + proxy.$t('btn.empty'), type: 'number', trigger: 'blur' }],
      sqlText: [{ required: true, message: proxy.$t('pjob.runsqlText') + proxy.$t('btn.empty'), trigger: 'blur' }],
      requestMethod: [{ required: true, message: proxy.$t('pjob.requestMethod') + proxy.$t('btn.empty'), trigger: 'blur' }]
    },
    options: {
      // 触发器类型
      triggerTypeOptions: [
        { dictLabel: proxy.$t('pjob.general'), dictValue: '0' },
        { dictLabel: proxy.$t('pjob.expression'), dictValue: '1' }
      ],
      taskTypeOptions: [
        { dictLabel: proxy.$t('pjob.assembly'), dictValue: '1' },
        { dictLabel: proxy.$t('pjob.requestApi'), dictValue: '2', listClass: 'danger' },
        { dictLabel: proxy.$t('pjob.SQLScript'), dictValue: '3', listClass: 'info' }
      ],
      // 任务状态字典
      isStartOptions: [
        { dictLabel: proxy.$t('pjob.runing'), dictValue: '1', listClass: 'success' },
        { dictLabel: proxy.$t('pjob.stopped'), dictValue: '0', listClass: 'danger' }
      ],
      // 任务组名字典
      jobGroupOptions: []
    }
  })
  // 按钮是否可见
  const btnVisible = ref(true)
  const { rules, form, options } = toRefs(state)

  /** 查询计划任务列表 */
  function getList() {
    loading.value = true
    queryTasks(queryParams).then((response) => {
      dataTasks.value = response.data.result
      total.value = response.data.totalNum
      loading.value = false
    })
  }
  function handleQuery() {
    getList()
  }
  /** 重置按钮操作 */
  function handleReset() {
    proxy.resetForm('queryRef')
    getList()
  }
  /** 新增按钮操作 */
  function handleCreate() {
    reset()
    btnVisible.value = true
    open.value = true
    title.value = proxy.$t('btn.add') + proxy.$t('pjob.name')
  }
  /** 修改按钮操作 */
  function handleUpdate(row) {
    reset()
    btnVisible.value = true
    getTasks(row.id).then((res) => {
      form.value = res.data
      open.value = true
      title.value = proxy.$t('btn.edit') + proxy.$t('pjob.name')
    })
  }

  /** cron表达式按钮操作 */
  function handleShowCron() {
    expression.value = form.value.cron
    openCron.value = true
  }
  /** 确定后回传值 */
  function crontabFill(value) {
    form.value.cron = value
  }

  // 启动按钮
  function handleStart(row) {
    startTasks(row.id).then((response) => {
      if (response.code === 200) {
        proxy.$modal.msgSuccess(response.msg)
        open.value = false
        getList()
      }
    })
  }
  // 停止按钮
  function handleStop(row) {
    stopTasks(row.id).then((response) => {
      if (response.code === 200) {
        proxy.$modal.msgSuccess(response.msg)
        open.value = false
        getList()
      }
    })
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const jobInfo = row

    proxy
      .$confirm(proxy.$t('common.confirmDel') + jobInfo.name + proxy.$t('common.confirmDelDataitems'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(() => {
        deleteTasks(jobInfo.id).then((response) => {
          if (response.code === 200) {
            getList()
            proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
          }
        })
      })
      .catch(function () { })
  }
  /* 立即执行一次 */
  function handleRun(row) {
    const jobInfo = row

    proxy
      .$confirm(proxy.$t('pjob.runOnceMemo') + jobInfo.name + proxy.$t('pjob.runOnceTaskMemo'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then((res) => {
        runTasks(jobInfo.id).then((res) => {
          if (res.code === 200) {
            proxy.$modal.msgSuccess(proxy.$t('pjob.runCompleted'))
            getList()
          }
        })
      })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.id !== undefined) {
          updateTasks(form.value).then((response) => {
            if (response.code === 200) {
              proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
              open.value = false
              getList()
            }
          })
        } else {
          createTasks(form.value).then((response) => {
            if (response.code === 200) {
              proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
              open.value = false
              getList()
            }
          })
        }
      }
    })
  }
  // 排序操作
  function handleSortable(column) {
    var sort = undefined
    var sortType = undefined

    if (column.prop != null && column.order != null) {
      sort = column.prop
      sortType = column.order
    }
    queryParams.sort = sort
    queryParams.sortType = sortType
    handleQuery()
  }
  // 表单重置
  function reset() {
    form.value = {
      id: undefined,
      name: undefined,
      jobGroup: undefined,
      assemblyName: 'Lps.Tasks',
      className: undefined,
      jobParams: undefined,
      triggerType: 1,
      beginTime: undefined,
      endTime: undefined,
      intervalSecond: 1,
      cron: undefined,
      taskType: 1,
      requestMethod: 'GET'
    }
    proxy.resetForm('formRef')
  }

  // 取消按钮
  function cancel() {
    open.value = false
    reset()
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm('是否确认导出所有任务?', '警告', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
      .then(() => {
        return exportTasks()
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }

  getList()
  proxy.getDicts('sys_job_group').then((response) => {
    state.options.jobGroupOptions = response.data
  })

  watch(
    () => form.value.triggerType,
    (val) => {
      if (val == 0) {
        form.value.cron = ''
      }
    },
    {
      deep: true,
      immediate: true
    }
  )

  /** 任务日志 */

  const logForm = reactive({
    beginTime: undefined,
    jobId: undefined,
    title: undefined
  })
  function onJobLogView() {
    router.push({ path: '/monitor/job/log' })
  }
  /** 任务日志列表查询 */
  function handleJobLog(row) {
    if (undefined != row.id) {
      logForm.jobId = row.id
      logForm.title = row.name
    }

    drawer.value = true
    jobLogList.value = []
    logTitle.value = logForm.title
    listJobLog(logForm).then((response) => {
      jobLogList.value = response.data.result
    })
  }
  function handleDetails(row) {
    reset()
    getTasks(row.id).then((res) => {
      form.value = res.data
      open.value = true
      title.value = '详情'
      btnVisible.value = false
    })
  }

  function handleCommand(command, row) {
    console.log(command, row)
    switch (command) {
      case 'update':
        handleUpdate(row)
        break
      case 'start':
        handleStart(row)
        break
      case 'stop':
        handleStop(row)
        break
      case 'delete':
        handleDelete(row)
        break
      case 'run':
        handleRun(row)
        break
    }
  }
</script>