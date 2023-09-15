<template>
  <!-- 导入表 -->
  <el-dialog :title="$t('gen.ImportTable')" v-model="visible" width="900px" top="5vh" append-to-body>
    <el-form ref="queryRef" :inline="true" :rules="rules" :model="queryParams">
      <el-form-item :label="$t('gen.DataBase')" prop="dbName">
        <el-select v-model="queryParams.dbName" clearable :placeholder="$t('btn.select')+$t('gen.DataBase')"
          @change="handleQuery">
          <el-option v-for="item in dbList" :key="item" :label="item" :value="item" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('gen.TableName')">
        <el-input v-model="queryParams.tableName" clearable :placeholder="$t('btn.enter')+$t('gen.ImportTable')" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleQuery()">{{$t('btn.search')}}</el-button>
      </el-form-item>
    </el-form>
    <el-row>
      <el-table ref="table" @row-click="clickRow" :data="dbTableList" highlight-current-row height="300px"
        @selection-change="handleSelectionChange">
        <el-table-column type="selection" width="55"></el-table-column>
        <el-table-column prop="name" :label="$t('gen.TableName')" sortable="custom" width="380" />
        <el-table-column prop="description" :label="$t('gen.TableDescription')" />
      </el-table>
      <pagination v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" v-model:total="total"
        @pagination="getList" />
    </el-row>
    <template #footer>
      <el-button text @click="visible = false">{{ $t('btn.cancel') }}</el-button>
      <el-button type="primary" @click="handleImportTable">{{ $t('btn.submit') }}</el-button>
    </template>
  </el-dialog>
</template>

<script setup>
  import { listDbTable, importTable, codeGetDBList } from '@/api/tool/gen'

  const total = ref(0)
  const visible = ref(false)
  const tables = ref([])
  const dbTableList = ref([])
  const { proxy } = getCurrentInstance()
  // 数据库数据
  const dbList = ref([])
  const queryParams = reactive({
    dbName: '',
    pageNum: 1,
    pageSize: 10,
    tableName: undefined
  })
  const rules = reactive({
    dbName: [{ required: true, message: proxy.$t('btn.select') + proxy.$t('gen.DataBase'), trigger: 'blur' }]
  })
  const emit = defineEmits(['ok'])

  /** 查询参数列表 */
  function show() {
    getList()
    visible.value = true
  }
  /** 单击选择行 */
  function clickRow(row) {
    proxy.$refs.table.toggleRowSelection(row)
  }
  /** 多选框选中数据 */
  function handleSelectionChange(selection) {
    tables.value = selection.map((item) => item.name)
    console.log(tables.value)
  }
  /** 查询表数据 */
  function getList() {
    codeGetDBList().then((res) => {
      dbList.value = res.data.dbList
    })
    if (queryParams.dbName !== '') {
      listDbTable(queryParams).then((res) => {
        dbTableList.value = res.data.result
        total.value = res.data.totalNum
      })
    }
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    proxy.resetForm('queryRef')
    handleQuery()
  }
  /** 导入按钮操作 */
  function handleImportTable() {
    importTable({
      tables: tables.value.join(','),
      dbName: queryParams.dbName
    }).then((res) => {
      proxy.$modal.msgSuccess(res.msg)
      if (res.code === 200) {
        visible.value = false
        emit('ok')
      }
    })
  }

  defineExpose({
    show
  })
</script>