<!--
 * @Descripttion: (数据差异日志/SqlDiffLog)
 * @Author: (lean365)
 * @Date: (2023-08-17)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item :label="$t('psqldiff.tableName')" prop="tableName">
        <el-input v-model="queryParams.tableName" :placeholder="$t('btn.enter')+$t('psqldiff.tableName')"
          size="small" />
      </el-form-item>
      <el-form-item :label="$t('psqldiff.diffType')" prop="diffType">
        <el-select clearable v-model="queryParams.diffType" :placeholder="$t('btn.enter')+$t('psqldiff.diffType')"
          size="small">
          <el-option v-for="item in options.diffTypeOptions" :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary)">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('psqldiff.userName')" prop="userName">
        <el-input v-model="queryParams.userName" :placeholder="$t('btn.enter')+$t('psqldiff.userName')" size="small" />
      </el-form-item>
      <el-form-item :label="$t('psqldiff.addTime')">
        <el-date-picker v-model="dateRangeaddTime" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions" size="small">
        </el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" size="small" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" type="info" plain size="small" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" size="small" @click="handleExport"
          v-hasPermi="['sqldifflog:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table :data="dataList" v-loading="loading" ref="table" border header-cell-class-name="el-table-header-cell"
      highlight-current-row @sort-change="sortChange" height="652" style="width: 100%">
      <el-table-column prop="pId" :label="$t('psqldiff.pId')" align="center" v-if="columns.showColumn('pId')"
        width="180" />
      <el-table-column prop="tableName" :label="$t('psqldiff.tableName')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tableName')" />
      <el-table-column prop="diffType" :label="$t('psqldiff.diffType')" align="center"
        v-if="columns.showColumn('diffType')">
        <template #default="scope">
          <dict-tag :options="options.diffTypeOptions" :value="scope.row.diffType" />
        </template>
      </el-table-column>
      <el-table-column prop="businessData" :label="$t('psqldiff.businessData')" align="center"
        :show-overflow-tooltip="true" v-if="columns.showColumn('businessData')" />
      <el-table-column prop="sql" :label="$t('psqldiff.sql')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sql')" />
      <el-table-column prop="beforeData" :label="$t('psqldiff.beforeData')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('beforeData')" />
      <el-table-column prop="afterData" :label="$t('psqldiff.afterData')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('afterData')" />
      <el-table-column prop="userName" :label="$t('psqldiff.userName')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('userName')" />
      <el-table-column prop="addTime" :label="$t('psqldiff.addTime')" :show-overflow-tooltip="true"
        v-if="columns.showColumn('addTime')" />
      <el-table-column prop="configId" :label="$t('psqldiff.configId')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('configId')" />
      <el-table-column :label="$t('btn.operation')" width="140" align="center">
        <template #default="scope">
          <el-button color="#663cee" icon="view" :title="$t('btn.details')" size="small" plain
            @click="handlePreview(scope.row)"></el-button>
          <el-button v-hasPermi="['sqldifflog:delete']" icon="delete" :title="$t('btn.delete')" type="danger" plain
            size="small" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改数据差异日志对话框 -->
    <zr-dialog :title="title" :lock-scroll="false" v-model="open" @close="cancel">
      <el-form ref="formRef" :model="form" label-width="auto">
        <el-row :gutter="20">
          <el-col :lg="12">
            <el-form-item :label="$t('psqldiff.pId')" prop="pId">
              <el-input v-model.number="form.pId" :disabled="opertype != 1" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item :label="$t('psqldiff.tableName')" prop="tableName">
              <el-input v-model="form.tableName" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item :label="$t('psqldiff.businessData')" prop="businessData">
              <el-input type="textarea" v-model="form.businessData" :disabled="opertype != 1" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item :label="$t('psqldiff.diffType')" prop="diffType">
              <dict-tag :options="options.diffTypeOptions" :value="form.diffType"></dict-tag>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item :label="$t('psqldiff.configId')" prop="configId">
              <el-input v-model="form.configId" :value="form.configId" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item :label="$t('psqldiff.sql')" prop="sql">
              <el-input type="textarea" v-model="form.sql" :disabled="opertype != 1" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item :label="$t('psqldiff.beforeData')" prop="beforeData">
              <el-input type="textarea" v-model="form.beforeData" :disabled="opertype != 1" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item :label="$t('psqldiff.afterData')" prop="afterData">
              <el-input type="textarea" v-model="form.afterData" :disabled="opertype != 1" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item :label="$t('psqldiff.userName')" prop="userName">
              <el-input v-model="form.userName" disabled />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item :label="$t('psqldiff.addTime')" prop="addTime">
              <el-date-picker v-model="form.addTime" disabled type="datetime" :teleported="false"></el-date-picker>
            </el-form-item>
          </el-col>


        </el-row>
      </el-form>
      <template #footer v-if="opertype != 1">
        <el-button type="info" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
      </template>
    </zr-dialog>
  </div>
</template>

<script setup name="sqldifflog">
  import { listSqlDiffLog, delSqlDiffLog } from '@/api/monitor/sqldifflog.js'
  const { proxy } = getCurrentInstance()
  const ids = ref([])
  const loading = ref(false)
  const showSearch = ref(true)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 14,
    sort: 'PId',
    sortType: 'desc',
    tableName: undefined,
    diffType: undefined,
    userName: undefined,
    addTime: undefined
  })
  const columns = ref([
    { visible: true, prop: 'pId', label: '主键' },
    { visible: true, prop: 'tableName', label: '表名' },
    { visible: true, prop: 'businessData', label: '业务数据内容' },
    { visible: true, prop: 'diffType', label: '差异类型' },
    { visible: true, prop: 'sql', label: '执行sql语句' },
    { visible: true, prop: 'beforeData', label: '变更前数据' },
    { visible: true, prop: 'afterData', label: '变更后数据' },
    { visible: true, prop: 'userName', label: '操作用户名' },
    { visible: false, prop: 'addTime', label: '操作时间' },
    { visible: false, prop: 'configId', label: '数据库配置id' }
  ])
  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  // addTime时间范围
  const dateRangeaddTime = ref([])

  var dictParams = []

  function getList() {
    proxy.addDateRange(queryParams, dateRangeaddTime.value, 'addTime')
    loading.value = true
    listSqlDiffLog(queryParams).then((res) => {
      const { code, data } = res
      if (code == 200) {
        dataList.value = data.result
        total.value = data.totalNum
        loading.value = false
      }
    })
  }

  // 查询
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }

  // 重置查询操作
  function resetQuery() {
    // addTime时间范围
    dateRangeaddTime.value = []
    proxy.resetForm('queryRef')
    handleQuery()
  }
  // 自定义排序
  function sortChange(column) {
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

  /*************** form操作 ***************/
  const formRef = ref()
  const title = ref('')
  // 操作类型 1、add 2、edit 3、view
  const opertype = ref(0)
  const open = ref(false)
  const state = reactive({
    single: true,
    multiple: true,
    form: {},
    options: {
      // 差异类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      diffTypeOptions: [
        { dictLabel: 'insert', dictValue: 'insert' },
        { dictLabel: 'update', dictValue: 'update', listClass: 'success' },
        { dictLabel: 'delete', dictValue: 'delete', listClass: 'danger' }
      ]
    }
  })

  const { form, options } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      pId: null,
      tableName: null,
      businessData: null,
      diffType: null,
      sql: null,
      beforeData: null,
      afterData: null,
      userName: null,
      addTime: null,
      configId: null
    }
    proxy.resetForm('formRef')
  }

  // 删除按钮操作
  function handleDelete(row) {
    const Ids = row.pId || ids.value

    proxy
      .$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？')
      .then(function () {
        return delSqlDiffLog(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess('删除成功')
      })
      .catch(() => { })
  }

  /**
   * 查看
   * @param {*} row
   */
  function handlePreview(row) {
    reset()
    open.value = true
    title.value = '查看'
    opertype.value = 3
    form.value = { ...row }
  }

  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm('是否确认导出数据差异日志数据项?', '警告', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
      .then(async () => {
        await proxy.downFile('/monitor/SqlDiffLog/export', { ...queryParams })
      })
  }

  handleQuery()
</script>