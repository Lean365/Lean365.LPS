<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryRef" :inline="true" v-show="showSearch">
      <el-form-item :label="$t('pmenu.parentMenu')" prop="parentId">
        <el-cascader class="w100" :options="menuQueryOptions"
          :props="{ checkStrictly: true, value: 'menuId', label: 'menuName', emitPath: false }"
          :placeholder="$t('btn.select')+$t('pmenu.parentMenu')" clearable v-model="queryParams.parentId" size="small">
          <template #default="{ node, data }">
            <span>{{ data.menuName }}</span>
            <span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
          </template>
        </el-cascader>
      </el-form-item>
      <el-form-item :label="$t('pmenu.menuName')" prop="menuName">
        <el-input v-model="queryParams.menuName" :placeholder="$t('btn.enter')+$t('pmenu.menuName')" clearable
          @keyup.enter="handleQuery" size="small" />
      </el-form-item>
      <el-form-item :label="$t('pmenu.menuState')" prop="isStatus">
        <el-select v-model="queryParams.isStatus" :placeholder="$t('btn.select')+$t('pmenu.menuState')" clearable
          size="small">
          <el-option v-for="dict in sys_normal_disable" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('pmenu.isShow')" prop="visible">
        <el-select v-model="queryParams.visible" :placeholder="$t('btn.select')+$t('pmenu.isShow')" clearable
          size="small">
          <el-option v-for="dict in sys_show_hide" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="Search" size="small" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button type="info" plain icon="Refresh" size="small" @click="resetQuery">{{ $t('btn.reset')
          }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" plain icon="Plus" size="small" @click="handleAdd" v-hasPermi="['system:menu:add']">{{
          $t('btn.add')
          }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="Sort" size="small" @click="toggleExpandAll">{{ $t('btn.expand') }}/{{
          $t('btn.collapse')
          }}</el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table v-if="refreshTable" v-loading="loading" :data="menuList" row-key="menuId"
      :default-expand-all="isExpandAll" border lazy ref="listRef" :load="loadMenu" height="670"
      :tree-props="{ children: 'children', hasChildren: 'hasChildren' }">
      <el-table-column prop="menuName" :label="$t('pmenu.menuName')" :show-overflow-tooltip="true" width="160">
        <template #default="scope">
          <span v-if="scope.row.menuNameKey">
            {{ $t(scope.row.menuNameKey) }}
          </span>
          <span v-else>
            {{ scope.row.menuName }}
          </span>
        </template>
      </el-table-column>
      <el-table-column prop="icon" :label="$t('pmenu.icon')" align="center" width="60">
        <template #default="scope">
          <svg-icon :name="scope.row.icon" />
        </template>
      </el-table-column>
      <el-table-column prop="menuId" :label="$t('pmenu.menuid')" :show-overflow-tooltip="true" width="100"
        align="center"></el-table-column>
      <el-table-column prop="menuType" :label="$t('pmenu.menuType')" align="center" width="120">
        <template #default="scope">
          <el-tag type="danger" v-if="scope.row.menuType == 'M' && scope.row.isFrame == 1">{{ $t('pmenu.link')
            }}</el-tag>
          <el-tag v-else-if="scope.row.menuType == 'C'">{{ $t('pmenu.menu') }}</el-tag>
          <el-tag type="success" v-else-if="scope.row.menuType == 'M'">{{ $t('pmenu.directory') }}</el-tag>
          <el-tag type="warning" v-else-if="scope.row.menuType == 'F'">{{ $t('pmenu.button') }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="orderNum" :label="$t('pmenu.sort')" width="90" sortable align="center">
        <template #default="scope">
          <span v-show="editIndex != scope.$index" @click="editCurrRow(scope.$index)">{{ scope.row.orderNum }}</span>
          <el-input :ref="setColumnsRef" v-show="editIndex == scope.$index" v-model="scope.row.orderNum"
            @blur="handleChangeSort(scope.row)"></el-input>
        </template>
      </el-table-column>
      <el-table-column prop="perms" :label="$t('pmenu.authorityID')" :show-overflow-tooltip="true"></el-table-column>
      <el-table-column prop="component" :label="$t('pmenu.componentPath')"
        :show-overflow-tooltip="true"></el-table-column>
      <el-table-column prop="visible" :label="$t('pmenu.isShow')" width="80" align="center">
        <template #default="scope">
          <dict-tag :options="sys_show_hide" :value="scope.row.visible" />
        </template>
      </el-table-column>
      <el-table-column prop="isStatus" :label="$t('pmenu.menuState')" width="90" align="center">
        <template #default="scope">
          <dict-tag :options="sys_normal_disable" :value="scope.row.isStatus" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('common.addTime')" align="center" prop="createTime" :show-overflow-tooltip="true">
        <template #default="scope">
          <span>{{ parseTime(scope.row.createTime) }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" width="170" class-name="small-padding fixed-width">
        <template #default="scope">
          <el-button type="success" size="small" icon="Edit" @click="handleUpdate(scope.row)"
            v-hasPermi="['system:menu:edit']"></el-button>
          <el-button type="primary" plain size="small" icon="Plus" @click="handleAdd(scope.row)"
            v-hasPermi="['system:menu:add']"></el-button>
          <el-button type="danger" plain size="small" icon="Delete" @click="handleDelete(scope.row)"
            v-hasPermi="['system:menu:remove']"></el-button>
        </template>
      </el-table-column>
    </el-table>

    <!-- 添加或修改菜单对话框 -->
    <el-dialog :title="title" v-model="open" width="720px" append-to-body>
      <el-form ref="menuRef" :model="form" :rules="rules" label-width="auto">
        <el-row>
          <el-col :lg="24">
            <el-form-item :label="$t('pmenu.parentMenu')">
              <el-cascader class="w100" :options="menuOptions"
                :props="{ checkStrictly: true, value: 'menuId', label: 'menuName', emitPath: false }"
                :placeholder="$t('btn.select')+$t('pmenu.parentMenu')" clearable v-model="form.parentId">
                <template #default="{ node, data }">
                  <span>{{ data.menuName }}</span>
                  <span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
                </template>
              </el-cascader>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pmenu.menuType')" prop="menuType">
              <el-radio-group v-model="form.menuType">
                <el-radio label="M">{{ $t('pmenu.directory') }}</el-radio>
                <el-radio label="C">{{ $t('pmenu.menu') }}</el-radio>
                <el-radio label="F">{{ $t('pmenu.button') }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pmenu.menuName')" prop="menuName">
              <el-input v-model="form.menuName" :placeholder="$t('btn.enter')+$t('pmenu.menuName')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('pmenu.menuNameKey')" prop="menuNameKey">
              <template #label>
                <span>
                  <el-tooltip :content="$t('pmenu.menuNameKeymemo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{ $t('pmenu.menuNameKey') }}
                </span>
              </template>
              <el-input v-model="form.menuNameKey" :placeholder="$t('btn.enter')+$t('pmenu.menuNameKey')" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('pmenu.sort')" prop="orderNum">
              <el-input-number v-model="form.orderNum" controls-position="right" :min="0" />
            </el-form-item>
          </el-col>
          <el-col :lg="12" v-if="form.menuType != 'F'">
            <el-form-item :label="$t('pmenu.icon')" prop="icon">
              <el-popover placement="bottom-start" :teleported="false" :width="540" :visible="showChooseIcon"
                trigger="click">
                <template #reference>
                  <el-input v-model="form.icon" :placeholder="$t('btn.select')+$t('pmenu.selectIcon')"
                    @click="showSelectIcon" readonly>
                    <template #prefix>
                      <svg-icon v-if="form.icon" :name="form.icon" />
                      <el-icon v-else>
                        <search />
                      </el-icon>
                    </template>
                  </el-input>
                </template>
                <icon-select ref="iconSelectRef" @selected="selected" />
              </el-popover>
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.menuType != 'F'">
            <el-form-item>
              <template #label>
                <span>
                  <el-tooltip :content="$t('pmenu.linkMemo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{ $t('pmenu.isFrame') }}
                </span>
              </template>
              <el-radio-group v-model="form.isFrame">
                <el-radio label="1">{{ $t('common.yes') }}</el-radio>
                <el-radio label="0">{{ $t('common.no') }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.menuType != 'F'">
            <el-form-item prop="path">
              <template #label>
                <span>
                  <el-tooltip :content="$t('pmenu.routePathmemo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{ $t('pmenu.routePath') }}
                </span>
              </template>
              <el-input v-model="form.path" :placeholder="$t('btn.enter')+$t('pmenu.routePath')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.menuType == 'C'">
            <el-form-item prop="component">
              <template #label>
                <span>
                  <el-tooltip :content="$t('btn.enter')+$t('pmenu.componentPathmemo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{ $t('pmenu.componentPath') }}
                </span>
              </template>
              <el-input v-model="form.component" :placeholder="$t('btn.enter')+$t('pmenu.componentPath')"
                style="width: 250px">
                <template #prepend>
                  <span style="width: 50px">src/views/</span>
                </template>
              </el-input>
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.menuType != 'M'">
            <el-form-item>
              <el-input v-model="form.perms" :placeholder="$t('btn.enter')+$t('pmenu.permissionStr')" maxlength="100" />
              <template #label>
                <span>
                  <el-tooltip :content="$t('pmenu.permissionStrmemo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{ $t('pmenu.permissionStr') }}
                </span>
              </template>
            </el-form-item>
          </el-col>
          <!-- <el-col :lg="12" v-if="form.menuType == 'C'">
            <el-form-item>
              <el-input v-model="form.query" placeholder="请输入路由参数" maxlength="255" />
              <template #label>
                <el-tooltip content='访问路由的默认传递参数，如：`{"id": 1, "name": "ry"}`' placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                路由参数
              </template>
            </el-form-item>
          </el-col> -->
          <el-col :lg="24" v-if="form.menuType == 'C'">
            <el-form-item prop="isCache">
              <template #label>
                <span>
                  <el-tooltip :content="$t('pmenu.isCachememo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{ $t('pmenu.isCache') }}
                </span>
              </template>
              <el-radio-group v-model="form.isCache">
                <el-radio label="0">{{ $t('common.yes') }}</el-radio>
                <el-radio label="1">{{ $t('common.no') }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="12" v-if="form.menuType != 'F'">
            <el-form-item prop="visible">
              <template #label>
                <span>
                  <el-tooltip :content="$t('pmenu.isShowmemo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{ $t('pmenu.isShow') }}
                </span>
              </template>
              <el-radio-group v-model="form.visible">
                <el-radio v-for="dict in sys_show_hide" :key="dict.dictValue" :label="dict.dictValue">{{ dict.dictLabel
                  }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="12" v-if="form.menuType != 'F'">
            <el-form-item>
              <template #label>
                <span>
                  <el-tooltip :content="$t('pmenu.menuStatememo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{ $t('pmenu.menuState') }}
                </span>
              </template>
              <el-radio-group v-model="form.isStatus">
                <el-radio v-for="dict in sys_normal_disable" :key="dict.dictValue" :label="parseInt(dict.dictValue)">{{
                  dict.dictLabel }}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <el-button type="info" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="sysmenu">
  import { addMenu, delMenu, getMenu, listMenu, updateMenu, changeMenuSort as changeSort, listMenuById } from '@/api/system/menu'
  import SvgIcon from '@/components/SvgIcon'
  import IconSelect from '@/components/IconSelect'

  const { proxy } = getCurrentInstance()

  var dictParams = [{ dictType: 'sys_show_hide' }, { dictType: 'sys_normal_disable' }]
  const menuList = ref([])
  const open = ref(false)
  const loading = ref(true)
  const showSearch = ref(true)
  const title = ref('')
  const menuOptions = ref([])
  const menuQueryOptions = ref([])
  const isExpandAll = ref(false)
  const refreshTable = ref(true)
  const showChooseIcon = ref(false)
  const iconSelectRef = ref(null)
  const menuRef = ref(null)
  const listRef = ref(null)
  const loadNodeMap = new Map()
  const state = reactive({
    form: {},
    queryParams: {
      menuName: undefined,
      visible: undefined,
      menuTypeIds: 'M,C',
      parentId: undefined
    },
    rules: {
      menuName: [{ required: true, message: proxy.$t('pmenu.menuName') + proxy.$t('btn.empty'), trigger: 'blur' }],
      menuNameKey: [{ pattern: /^[A-Za-z].+$/, message: proxy.$t('pmenu.menuNameKey') + proxy.$t('btn.empty'), trigger: 'blur' }],
      orderNum: [{ required: true, message: proxy.$t('pmenu.sort') + proxy.$t('btn.empty'), trigger: 'blur' }],
      path: [
        { required: true, message: proxy.$t('pmenu.routePath') + proxy.$t('btn.empty'), trigger: 'blur' },
        { pattern: /^[A-Za-z].+$/, message: proxy.$t('pmenu.routePath'), trigger: 'blur' }
      ],
      visible: [{ required: true, message: proxy.$t('pmenu.menuState') + proxy.$t('btn.empty'), trigger: 'blur' }]
    },
    sys_show_hide: [],
    sys_normal_disable: []
  })

  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state[element.dictType] = element.list
    })
  })

  const { queryParams, form, rules, sys_show_hide, sys_normal_disable } = toRefs(state)

  /** 查询菜单列表 */
  function getList(type) {
    loading.value = true
    if (queryParams.value.parentId != undefined || queryParams.value.menuName != undefined) {
      queryParams.value.menuTypeIds = ''
    } else {
      queryParams.value.menuTypeIds = 'M,C'
    }
    listMenu(queryParams.value).then((response) => {
      menuList.value = response.data
      if (type == 1) {
        menuQueryOptions.value = response.data
      }
      loading.value = false
    })
  }
  /** 查询菜单下拉树结构 */
  function getTreeselect() {
    listMenu({ menuTypeIds: 'M,C,F' }).then((response) => {
      menuOptions.value = response.data
    })
  }
  /** 取消按钮 */
  function cancel() {
    open.value = false
    reset()
  }
  /** 表单重置 */
  function reset() {
    form.value = {
      menuId: undefined,
      parentId: 0,
      menuName: undefined,
      icon: undefined,
      menuType: 'M',
      orderNum: 999,
      isFrame: '0',
      isCache: '0',
      visible: '0',
      isStatus: 0
    }
    proxy.resetForm('menuRef')
  }
  /** 展示下拉图标 */
  function showSelectIcon() {
    iconSelectRef.value.reset()
    showChooseIcon.value = true
  }
  /** 选择图标 */
  function selected(name) {
    form.value.icon = name
    showChooseIcon.value = false
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    proxy.resetForm('queryRef')
    handleQuery()
  }
  /** 新增按钮操作 */
  function handleAdd(row) {
    reset()
    getTreeselect()
    if (row != null && row.menuId != undefined) {
      form.value.parentId = row.menuId
    } else {
      form.value.parentId = 0
    }
    open.value = true
    title.value = proxy.$t('btn.add')
  }
  /** 展开/折叠操作 */
  function toggleExpandAll() {
    refreshTable.value = false
    isExpandAll.value = !isExpandAll.value
    nextTick(() => {
      refreshTable.value = true
    })
  }
  /** 修改按钮操作 */
  async function handleUpdate(row) {
    reset()
    getTreeselect()
    getMenu(row.menuId).then((response) => {
      form.value = response.data
      open.value = true
      title.value = proxy.$t('btn.edit')
    })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['menuRef'].validate((valid) => {
      if (valid) {
        if (form.value.menuId != undefined) {
          updateMenu(form.value).then(() => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            refreshMenu(form.value.parentId)
          })
        } else {
          addMenu(form.value).then(() => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            refreshMenu(form.value.parentId)
          })
        }
      }
    })
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    proxy.$modal
      .confirm(proxy.$t('common.confirmDel') + row.menuName + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delMenu(row.menuId)
      })
      .then(() => {
        // getList()
        refreshMenu(row.parentId)
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
      })
      .catch(() => { })
  }
  // ******************自定义编辑 start **********************
  // 动态ref设置值
  const columnRefs = ref([])
  const setColumnsRef = (el) => {
    if (el) {
      columnRefs.value.push(el)
    }
  }
  const editIndex = ref(-1)
  // 显示编辑排序
  function editCurrRow(rowId) {
    editIndex.value = rowId

    setTimeout(() => {
      columnRefs.value[rowId].focus()
    }, 100)
  }
  // 保存排序
  function handleChangeSort(info) {
    editIndex.value = -1
    proxy
      .$confirm(proxy.$t('common.confirmSave'))
      .then(function () {
        return changeSort({ value: info.orderNum, id: info.menuId })
      })
      .then(() => {
        handleQuery()
        refreshMenu(info.parentId)
        proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
      })
      .catch(() => {
        handleQuery()
      })
  }
  // ******************自定义编辑 end **********************
  const loadMenu = (row, treeNode, resolve) => {
    listMenuById(row.menuId).then((res) => {
      loadNodeMap.set(row.menuId, { row, treeNode, resolve })
      resolve(res.data)
    })
  }
  // 刷新懒加载后的数据
  function refreshMenu(pid) {
    loading.value = true
    // console.log(loadNodeMap)
    if (loadNodeMap.size > 0) {
      const hasNode = loadNodeMap.has(pid)
      if (hasNode) {
        const { row, treeNode, resolve } = loadNodeMap.get(pid)
        proxy.$refs.listRef.store.states.lazyTreeNodeMap[pid] = []
        loadMenu(row, treeNode, resolve)
      }
      loading.value = false
    } else {
      getList()
    }
  }

  // listMenu({ menuTypeIds: 'M,C' }).then((response) => {
  //   menuQueryOptions.value = response.data
  // })

  // 首次列表加载（只加载一层）
  getList(1)
</script>