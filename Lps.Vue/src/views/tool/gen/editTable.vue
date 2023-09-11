<template>
  <div>
    <el-tabs v-model="activeName" tab-position="top">
      <el-tab-pane :label="$t('gencode.basic')" name="basic">
        <basic-info-form ref="basicInfo" :info="info" />
      </el-tab-pane>
      <el-tab-pane :label="$t('gencode.genInfo')" name="genInfo">
        <gen-info-form ref="genInfo" :info="info" :tables="tables" :columns="columns" />
      </el-tab-pane>
      <el-tab-pane :label="$t('gencode.cloum')" name="cloum">
        <el-table ref="dragTableRef" v-loading="loading" :data="columns" row-key="columnId" min-height="100px"
          :max-height="tableHeight">
          <el-table-column label="#" type="index" class-name="allowDrag" width="60" fixed />
          <el-table-column :label="$t('gencode.columnName')" prop="columnName" :show-overflow-tooltip="true" width="90"
            fixed />
          <el-table-column :label="$t('gencode.columnComment')" fixed width="120">
            <template #default="scope">
              <el-input v-model="scope.row.columnComment" :ref="setColumnsRef"
                @keydown="nextFocus(scope.row, scope.$index, $event)"> </el-input>
            </template>
          </el-table-column>
          <el-table-column :label="$t('gencode.columnType')" prop="columnType" :show-overflow-tooltip="true"
            width="90" />
          <el-table-column :label="$t('gencode.csharpType')" width="100">
            <template #default="scope">
              <el-select v-model="scope.row.csharpType">
                <el-option label="int" value="int" />
                <el-option label="long" value="long" />
                <el-option label="string" value="string" />
                <el-option label="double" value="double" />
                <el-option label="decimal" value="decimal" />
                <el-option label="DateTime" value="DateTime" />
                <el-option label="bool" value="bool" />
                <el-option label="Guid" value="Guid" />
              </el-select>
            </template>
          </el-table-column>
          <el-table-column :label="$t('gencode.csharpField')" width="100">
            <template #default="scope">
              <el-input v-model="scope.row.csharpField"></el-input>
            </template>
          </el-table-column>
          <el-table-column :label="$t('gencode.isRequired')" width="60" align="center">
            <template #default="scope">
              <el-checkbox v-model="scope.row.isRequired"></el-checkbox>
            </template>
          </el-table-column>
          <el-table-column :label="$t('gencode.front')" align="center" label-class-name="text-info">
            <el-table-column :label="$t('gencode.isList')" width="80" align="center">
              <template #default="scope">
                <el-checkbox v-model="scope.row.isList"></el-checkbox>
              </template>
            </el-table-column>
            <el-table-column :label="$t('gencode.isSort')" width="80" align="center">
              <template #default="scope">
                <el-checkbox v-model="scope.row.isSort"
                  :disabled="scope.row.htmlType == 'imageUpload' || scope.row.htmlType == 'fileUpload'"></el-checkbox>
              </template>
            </el-table-column>
          </el-table-column>
          <el-table-column :label="$t('gencode.back')" align="center" label-class-name="text-hotpink">
            <!-- <el-table-column label="插入" width="60" align="center" v-if="info.tplCategory != 'select'">
              <template #default="scope">
                <el-checkbox v-model="scope.row.isInsert" :disabled="scope.row.isIncrement"></el-checkbox>
              </template>
            </el-table-column> -->
            <el-table-column :label="$t('gencode.isEdit')" width="60" align="center"
              v-if="info.tplCategory != 'select'">
              <template #default="scope">
                <el-checkbox v-model="scope.row.isEdit"
                  :disabled="scope.row.isPk || scope.row.isIncrement"></el-checkbox>
              </template>
            </el-table-column>
            <el-table-column :label="$t('gencode.autoFillType')" width="120" align="center">
              <template #default="scope">
                <el-select v-model="scope.row.autoFillType">
                  <el-option label=" " :value="0" />
                  <el-option :label="$t('gencode.autoFillInsert')" :value="1" />
                  <el-option :label="$t('gencode.isEdit')" :value="2" />
                  <el-option :label="$t('gencode.autoFillInsertEdit')" :value="3" />
                </el-select>
              </template>
            </el-table-column>
            <el-table-column :label="$t('gencode.isExport')" width="120" align="center">
              <template #default="scope">
                <el-checkbox v-model="scope.row.isExport"> </el-checkbox>
              </template>
            </el-table-column>
          </el-table-column>
          <el-table-column :label="$t('gencode.query')" align="center" label-class-name="text-green">
            <el-table-column :label="$t('gencode.isQuery')" width="80" align="center">
              <template #default="scope">
                <el-checkbox v-model="scope.row.isQuery"
                  :disabled="scope.row.htmlType == 'imageUpload' || scope.row.htmlType == 'fileUpload'">
                </el-checkbox>
              </template>
            </el-table-column>
            <el-table-column :label="$t('gencode.queryType')" width="120" align="center">
              <template #default="scope">
                <el-select v-model="scope.row.queryType" :disabled="scope.row.htmlType == 'datetime'"
                  v-if="scope.row.isQuery">
                  <el-option label="=" value="EQ" />
                  <el-option label="!=" value="NE" />
                  <el-option label=">" value="GT" />
                  <el-option label=">=" value="GTE" />
                  <el-option label="<" value="LT" />
                  <el-option label="<=" value="LTE" />
                  <el-option label="LIKE" value="LIKE" />
                  <el-option label="BETWEEN" value="BETWEEN" />
                </el-select>
              </template>
            </el-table-column>
          </el-table-column>

          <el-table-column :label="$t('gencode.htmlType')" width="140">
            <template #default="scope">
              <el-select v-model="scope.row.htmlType">
                <el-option :label="$t('gencode.forminput')" value="input" />
                <el-option :label="$t('gencode.forminputNumber')" value="inputNumber" />
                <el-option :label="$t('gencode.formtextarea')" value="textarea" />
                <el-option :label="$t('gencode.formselect')" value="select" />
                <el-option :label="$t('gencode.formselectRemote')" value="selectRemote" />
                <el-option :label="$t('gencode.formselectMulti')" value="selectMulti" />
                <el-option :label="$t('gencode.formradio')" value="radio" />
                <el-option :label="$t('gencode.formcheckbox')" value="checkbox" />
                <el-option :label="$t('gencode.formdatetime')" value="datetime" />
                <el-option :label="$t('gencode.formdatePicker')" value="datePicker" />
                <el-option :label="$t('gencode.formimageUpload')" value="imageUpload" />
                <el-option :label="$t('gencode.formfileUpload')" value="fileUpload" />
                <el-option :label="$t('gencode.formeditor')" value="editor" />
                <el-option :label="$t('gencode.formcustomInput')" value="customInput" />
                <el-option :label="$t('gencode.formselectRadio')" value="selectRadio" />
                <el-option :label="$t('gencode.formcolorPicker')" value="colorPicker" />
                <el-option :label="$t('gencode.formmonth')" value="month" />
                <el-option :label="$t('gencode.formswitch')" value="switch" />
                <el-option :label="$t('gencode.slider')" value="slider" />
              </el-select>
            </template>
          </el-table-column>
          <el-table-column :label="$t('gencode.dictType')" min-width="140">
            <template #default="scope">
              <el-select v-model="scope.row.dictType" clearable filterable placeholder="请选择字典类型" v-if="
                  scope.row.htmlType == 'selectMulti' ||
                  scope.row.htmlType == 'selectRemote' ||
                  scope.row.htmlType == 'select' ||
                  scope.row.htmlType == 'radio' ||
                  scope.row.htmlType == 'checkbox' ||
                  scope.row.htmlType == 'selectRadio'
                ">
                <el-option v-for="dict in dictOptions" :key="dict.dictType" :label="dict.dictName"
                  :value="dict.dictType">
                  <span style="float: left">{{ dict.dictName }}</span>
                  <span style="float: right; color: #8492a6; font-size: 13px">{{ dict.dictType }}</span>
                </el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column :label="$t('gencode.reMarks')" align="center">
            <template #default="scope">
              <el-input v-model="scope.row.reMarks"> </el-input>
            </template>
          </el-table-column>
        </el-table>
        <div style="font-size: 12px; color: #8492a6">{{$t('gencode.promptTip')}}</div>
      </el-tab-pane>
    </el-tabs>
    <footer class="mt20" style="text-align: center">
      <el-button type="primary" icon="check" :loading="submitLoading"
        @click="submitForm()">{{$t('gencode.genSubmit')}}</el-button>
      <el-button type="success" icon="refresh" @click="handleQuery()">{{$t('gencode.genRefresh')}}</el-button>
      <el-button type="info" icon="back" @click="close()">{{$t('gencode.genReturn')}}</el-button>
    </footer>
  </div>
</template>
<script setup name="genedit">
  import { updateGenTable, getGenTable } from '@/api/tool/gen'
  import { listType } from '@/api/system/dict/type'
  import basicInfoForm from './basicInfoForm'
  import genInfoForm from './genInfoForm'
  import { useRoute } from 'vue-router'
  import Sortable from 'sortablejs'

  // 选中选项卡的 name
  const activeName = ref('basic')
  // 表格的高度
  const tableHeight = ref(document.documentElement.scrollHeight - 275 + 'px')
  // 表信息
  const tables = ref([])
  // 表列信息
  const columns = ref([])
  // 字典信息
  const dictOptions = ref([])
  // 表详细信息
  const info = ref({})
  const loading = ref(true)
  const dragTableRef = ref()
  const route = useRoute()
  const { proxy } = getCurrentInstance()
  const submitLoading = ref(false)
  function handleQuery() {
    const tableId = route.query && route.query.tableId

    if (tableId) {
      // 获取表详细信息
      getGenTable(tableId).then((res) => {
        loading.value = false
        columns.value = res.data.info.columns
        info.value = { ...res.data.info, ...res.data.info.options }
        tables.value = res.data.tables // 子表
      })
    }
  }
  /** 提交按钮 */
  function submitForm() {
    submitLoading.value = true
    const basicForm = proxy.$refs.basicInfo.$refs.basicInfoForm
    const genForm = proxy.$refs.genInfo.$refs.genInfoForm

    Promise.all([basicForm, genForm].map(getFormPromise)).then((res) => {
      const validateResult = res.every((item) => !!item)

      if (validateResult) {
        const genTable = Object.assign({}, info.value)
        genTable.columns = columns.value

        // 额外参数拼接
        var options = {
          treeCode: info.value.treeCode,
          treeName: info.value.treeName,
          treeParentCode: info.value.treeParentCode,
          parentMenuId: info.value.parentMenuId,
          sortField: info.value.sortField,
          sortType: info.value.sortType,
          checkedBtn: info.value.checkedBtn,
          permissionPrefix: info.value.permissionPrefix,
          colNum: info.value.colNum,
          generateRepo: info.value.generateRepo,
          generateMenu: info.value.generateMenu
        }
        genTable.params = options

        updateGenTable(genTable)
          .then((res) => {
            proxy.$modal.msgSuccess(res.msg)
            if (res.code === 200) {
              close()
            }
          })
          .catch(() => {
            submitLoading.value = false
          })
      } else {
        submitLoading.value = false
        proxy.$modal.msgError(proxy.$t('gencode.formValidation'))
      }
    })
  }

  function getFormPromise(form) {
    return new Promise((resolve) => {
      form.validate((res) => {
        resolve(res)
      })
    })
  }

  /** 查询字典下拉列表 */
  listType({ pageSize: 100 }).then((response) => {
    dictOptions.value = response.data.result
  })
  /** 关闭按钮 */
  function close() {
    const obj = {
      path: '/tool/gen',
      query: { t: Date.now(), pageNum: route.query.pageNum }
    }
    proxy.$tab.closeOpenPage(obj)
  }

  /*************** table column  回车代码 start*************/
  // 动态ref设置值
  const columnRefs = ref([])
  const setColumnsRef = (el) => {
    if (el) {
      columnRefs.value.push(el)
    }
  }

  // 回车到下一行
  function nextFocus(row, index, e) {
    var length = columnRefs.value.length
    var keyCode = e.keyCode || e.which || e.charCode
    if (keyCode === 13) {
      if (length - 1 == index) {
        console.log(proxy.$t('gencode.lastRow'))
      } else {
        columnRefs.value[index + 1].focus()
      }
    }
  }
  /*************** table column  回车代码 end *************/
  // 拖动排序
  const tableSort = () => {
    const tbody = document.querySelector('.el-table__body > tbody')

    Sortable.create(tbody, {
      dragClass: 'sortable-ghost',
      onEnd: (evt) => {
        const targetRow = columns.value.splice(evt.oldIndex, 1)[0]
        columns.value.splice(evt.newIndex, 0, targetRow)
        for (const index in columns.value) {
          columns.value[index].sort = parseInt(index) + 1
        }
      }
    })
  }

  onMounted(() => {
    tableSort()
  })

  handleQuery()
</script>
<style>
  .sortable-ghost {
    background: burlywood;
  }
</style>