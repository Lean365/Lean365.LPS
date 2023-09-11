<template>
  <el-form ref="genInfoForm" :model="info" :rules="rules" label-width="auto">
    <el-row>
      <el-col :lg="12">
        <el-form-item prop="tplCategory">
          <template #label>{{$t('gencode.tplCategory')}}</template>
          <el-select v-model="info.tplCategory" @change="tplSelectChange">
            <el-option :label="$t('gencode.crud')" value="crud" />
            <!-- <el-option label="单表查询" value="select" /> -->
            <el-option :label="$t('gencode.tree')" value="tree" />
            <!-- <el-option label="导航查询(1对1)" value="subNav"></el-option>
            <el-option label="导航查询(1对多)" value="subNavMore"></el-option> -->
            <el-option :label="$t('gencode.subNavMore')" value="subNavMore" />
          </el-select>
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="baseNameSpace">
          <template #label>
            {{$t('gencode.baseNameSpace')}}
            <span>
              <el-tooltip :content="$t('gencode.baseNameSpaceMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.baseNameSpace" />
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="moduleName">
          <template #label>
            {{$t('gencode.moduleName')}}
            <span>
              <el-tooltip :content="$t('gencode.moduleNameMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.moduleName" auto-complete="" />
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="businessName">
          <template #label>
            {{$t('gencode.businessName')}}
            <span>
              <el-tooltip :content="$t('gencode.businessNameMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.businessName" />
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="functionName">
          <template #label>
            {{$t('gencode.functionName')}}
            <span>
              <el-tooltip :content="$t('gencode.functionNameMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.functionName" />
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item>
          <template #label>
            {{$t('gencode.Parentmenu')}}
            <span>
              <el-tooltip :content="$t('gencode.ParentmenuMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-cascader class="w100" :options="menuOptions"
            :props="{ checkStrictly: true, value: 'menuId', label: 'menuName', emitPath: false }"
            :placeholder="$t('btn.select')+$t('gencode.Parentmenu')" clearable @change="clearParentMent($event)"
            v-model="info.parentMenuId">
            <template #default="{ node, data }">
              <span>{{ data.menuName }}</span>
              <span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
            </template>
          </el-cascader>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item :label="$t('gencode.sortField')">
          <el-select v-model="info.sortField" :placeholder="$t('btn.select')+$t('gencode.sortField')" class="mr10"
            clearable="">
            <el-option v-for="item in columns" :key="item.columnId" :label="item.csharpField" :value="item.csharpField">
            </el-option>
          </el-select>

          <el-radio v-model="info.sortType" label="asc">{{$t('gencode.sortAsc')}}</el-radio>
          <el-radio v-model="info.sortType" label="desc">{{$t('gencode.sortDesc')}}</el-radio>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="permissionPrefix">
          <template #label>
            {{$t('gencode.permissionPrefix')}}
            <span>
              <el-tooltip :content="$t('gencode.permissionPrefixMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.permissionPrefix"
            :placeholder="$t('btn.enter')+$t('gencode.permissionPrefix')"></el-input>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="genType">
          <template #label>
            {{$t('gencode.genType')}}
            <span>
              <el-tooltip :content="$t('gencode.defCustomPath')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-radio v-model="info.genType" label="0">{{$t('gencode.Zip')}}</el-radio>
          <el-radio v-model="info.genType" label="1">{{$t('gencode.CustomPath')}}</el-radio>
        </el-form-item>
      </el-col>

      <el-col :lg="12" v-if="info.genType == '1'">
        <el-form-item prop="genPath">
          <template #label>
            {{$t('gencode.CustomPath')}}
            <span>
              <el-tooltip :content="$t('gencode.CustomPathMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.genPath" :placeholder="$t('btn.enter')+$t('gencode.genPath')"></el-input>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item :label="$t('gencode.isRepository')">
          <template #label>
            {{$t('gencode.isRepository')}}
            <span>
              <el-tooltip :content="$t('gencode.isRepositoryMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-radio-group v-model="info.generateRepo">
            <el-radio :label="1">{{$t('gencode.Repyes')}}</el-radio>
            <el-radio :label="0">{{$t('gencode.Repno')}}</el-radio>
          </el-radio-group>
        </el-form-item>
      </el-col>

      <el-col :lg="12" v-if="info.genType == '1'">
        <el-form-item prop="generateMenu" :label="$t('gencode.isMenu')">
          <template #label>
            {{$t('gencode.isMenu')}}
            <span>
              <el-tooltip :content="$t('gencode.isMenuMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-switch v-model="info.generateMenu" class="ml-2" />
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="colNum" :label="$t('gencode.oneRowDisp')">
          <el-radio v-model="info.colNum" :label="12">{{$t('gencode.col2')}}</el-radio>
          <el-radio v-model="info.colNum" :label="24">{{$t('gencode.col1')}}</el-radio>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="operBtnStyle" :label="$t('gencode.buttonStyle')">
          <el-radio v-model="info.operBtnStyle" :label="1">button</el-radio>
          <el-radio v-model="info.operBtnStyle" :label="2">text button</el-radio>
        </el-form-item>
      </el-col>
      <el-col :lg="24" v-show="info.tplCategory != 'select'">
        <el-form-item :label="$t('gencode.Buildfunction')">
          <el-checkbox-group v-model="info.checkedBtn" @change="checkedBtnSelect">
            <el-checkbox :label="1">
              <el-tag>{{$t('gencode.funadd')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="2">
              <el-tag type="success">{{$t('gencode.funedit')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="3">
              <el-tag type="danger">{{$t('gencode.fundelete')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="4">
              <el-tag type="warning">{{$t('gencode.funexport')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="5">
              <el-tag type="info">{{$t('gencode.funview')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="6">
              <el-tag type="danger">{{$t('gencode.funclear')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="7">
              <el-tag type="danger">{{$t('gencode.fundelmutil')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="8">
              <el-tag>{{$t('gencode.funimport')}}</el-tag>
            </el-checkbox>
          </el-checkbox-group>
        </el-form-item>
      </el-col>
    </el-row>

    <!-- 树表配置 -->
    <el-row v-if="info.tplCategory == 'tree'">
      <el-col :lg="24">
        <h4 class="form-header">{{$t('gencode.treetable')}}</h4>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="treeCode">
          <template #label>
            {{$t('gencode.treeCode')}}
            <span>
              <el-tooltip :content="$t('gencode.treeCodeMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.treeCode" :placeholder="$t('btn.select')+$t('gencode.treeCode')">
            <el-option v-for="(column, index) in columns" :key="index" :label="column.columnComment"
              :value="column.csharpField">
              <span style="float: left">{{ column.csharpField }}</span>
              <span style="float: right">{{ column.columnComment }}</span>
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="treeName">
          <template #label>
            {{$t('gencode.treeName')}}
            <span>
              <el-tooltip :content="$t('gencode.treeNameMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.treeName" :placeholder="$t('btn.select')+$t('gencode.treeName')">
            <el-option v-for="(column, index) in columns" :key="index" :label="column.csharpField"
              :value="column.csharpField">
              <span style="float: left">{{ column.csharpField }}</span>
              <span style="float: right">{{ column.columnComment }}</span>
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>
      <el-col :lg="24">
        <el-form-item prop="treeParentCode">
          <template #label>
            {{$t('gencode.treeParentCode')}}
            <span>
              <el-tooltip :content="$t('gencode.treeParentCodeMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.treeParentCode" :placeholder="$t('btn.select')+$t('gencode.treeParentCode')">
            <el-option v-for="(column, index) in columns" :key="index"
              :label="column.csharpField + '：' + column.columnComment" :value="column.csharpField">
              <span style="float: left">{{ column.csharpField }}</span>
              <span style="float: right">{{ column.columnComment }}</span>
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>
    </el-row>

    <!-- 主子表配置 -->
    <el-row v-if="info.tplCategory == 'sub' || info.tplCategory == 'subNav' || info.tplCategory == 'subNavMore'">
      <el-col :lg="24">
        <h4 class="form-header">{{$t('gencode.associatedTable')}}</h4>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="subTableName">
          <template #label>
            {{$t('gencode.subTableName')}}
            <span>
              <el-tooltip :content="$t('gencode.subTableNameMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.subTableName" filterable :placeholder="$t('btn.select')+$t('gencode.subTableName')"
            @change="subSelectChange(this)">
            <el-option v-for="(table, index) in tables" :disabled="table.tableName == info.tableName" :key="index"
              :label="table.tableName + '：' + table.tableComment" :value="table.tableName">
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="subTableFkName">
          <template #label>
            {{$t('gencode.subTableFkName')}}
            <span>
              <el-tooltip :content="$t('gencode.subTableFkNameMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.subTableFkName">
            <el-option v-for="(column, index) in subColumns" :key="index" :label="column.csharpField"
              :value="column.csharpField">
              <span style="float: left">{{ column.csharpField }}</span>
              <span style="float: right">{{ column.columnComment }}</span>
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>
    </el-row>
  </el-form>
</template>

<script setup name="genInfoForm">
  import { listMenu } from '@/api/system/menu'
  import { queryColumnInfo } from '@/api/tool/gen'
  const { proxy } = getCurrentInstance()
  const subColumns = ref([])
  const menuOptions = ref([])

  const props = defineProps({
    info: {
      type: Object,
      default: null
    },
    // 字表
    tables: {
      type: Array,
      default: null
    },
    // 列
    columns: {
      type: Array,
      default: []
    }
  })
  // 表单校验
  const rules = ref({
    tplCategory: [{ required: true, message: proxy.$t('btn.select') + proxy.$t('gen.tplCategory'), trigger: 'blur' }],
    moduleName: [
      {
        required: true,
        message: proxy.$t('btn.enter') + proxy.$t('gen.moduleName'),
        trigger: 'blur',
        pattern: /^[A-Za-z]+$/
      }
    ],
    businessName: [
      {
        required: true,
        message: proxy.$t('btn.enter') + proxy.$t('gen.businessName'),
        trigger: 'blur',
        pattern: /^[A-Za-z]+$/
      }
    ],
    functionName: [{ required: true, message: proxy.$t('btn.enter') + proxy.$t('gen.functionName'), trigger: 'blur' }],
    permissionPrefix: {
      required: true,
      message: proxy.$t('btn.enter') + proxy.$t('gen.permissionPrefix'),
      trigger: 'blur'
    },
    genType: [{ required: true, message: proxy.$t('btn.select') + proxy.$t('gen.genType'), trigger: 'blur' }],
    treeCode: [{ required: true, message: proxy.$t('btn.select') + proxy.$t('gen.treeCode'), trigger: 'blur' }],
    treeParentCode: [{ required: true, message: proxy.$t('btn.select') + proxy.$t('gen.treeParentCode'), trigger: 'blur' }],
    subTableName: [{ required: true, message: proxy.$t('btn.select') + proxy.$t('gen.subTableName'), trigger: 'blur' }],
    subTableFkName: [{ required: true, message: proxy.$t('btn.select') + proxy.$t('gen.subTableFkName'), trigger: 'blur' }]
  })
  function subSelectChange(value) {
    props.info.subTableFkName = ''
  }
  function tplSelectChange(value) {
    if (value !== 'sub') {
      props.info.subTableName = ''
      props.info.subTableFkName = ''
    }
  }
  function clearParentMent(e) {
    if (e == null) {
      props.info.parentMenuId = 0
    }
  }
  function setSubTableColumns(value) {
    if (value == null || value == undefined || value == '') {
      return
    }
    for (var item in props.tables) {
      const obj = props.tables[item]
      if (value === obj.tableName) {
        queryColumnInfo(obj.tableId).then((res) => {
          if (res.code == 200) {
            subColumns.value = res.data.columns
          }
        })
        break
      }
    }
  }
  /** 查询菜单下拉树结构 */
  function getMenuTreeselect() {
    /** 查询菜单下拉列表 */
    listMenu({ menuTypeIds: 'M,C' }).then((response) => {
      menuOptions.value = response.data
    })
  }
  function checkedBtnSelect(value) {
    console.log(value)
  }
  watch(
    () => props.info.subTableName,
    (val) => {
      setSubTableColumns(val)
    }
  )

  getMenuTreeselect()
</script>