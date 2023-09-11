<template>
  <el-form ref="basicInfoForm" :model="info" :rules="rules" label-width="100px">
    <el-row>
      <el-col :lg="6">
        <el-form-item :label="$t('gencode.tableName')" prop="tableName">
          <el-input :placeholder="$t('btn.enter')+$t('gencode.tableName')" v-model="info.tableName" />
        </el-form-item>
      </el-col>
      <el-col :lg="6">
        <el-form-item :label="$t('gencode.tableComment')" prop="tableComment">
          <el-input :placeholder="$t('btn.enter')+$t('gencode.tableComment')" v-model="info.tableComment" />
        </el-form-item>
      </el-col>

      <el-col :lg="6">
        <el-form-item :label="$t('gencode.className')" prop="className">
          <el-input :placeholder="$t('btn.enter')+$t('gencode.className')" v-model="info.className" />
        </el-form-item>
      </el-col>
      <el-col :lg="6">
        <el-form-item :label="$t('gencode.functionAuthor')" prop="functionAuthor">
          <el-input :placeholder="$t('btn.enter')+$t('gencode.functionAuthor')" v-model="info.functionAuthor" />
        </el-form-item>
      </el-col>
      <el-col :lg="24">
        <el-form-item :label="$t('gencode.reMarks')" prop="reMarks">
          <el-input type="textarea" :rows="3" v-model="info.reMarks"
            :placeholder="$t('btn.enter')+$t('gencode.reMarks')"></el-input>
        </el-form-item>
      </el-col>
    </el-row>
  </el-form>
</template>
<script setup name="BasicInfoForm">
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  const props = defineProps({
    info: {
      type: Object,
      default: null,
    },
  })
  const rules = reactive({
    tableName: [{ required: true, message: proxy.$t('gencode.tableName') + proxy.$t('btn.emtpy'), trigger: 'blur' }],
    tableComment: [{ required: true, message: proxy.$t('gencode.tableName') + proxy.$t('btn.emtpy'), trigger: 'blur' }],
    className: [{ required: true, message: proxy.$t('gencode.tableName') + proxy.$t('btn.emtpy'), trigger: 'blur' }],
    functionAuthor: [{ required: true, message: proxy.$t('gencode.tableName') + proxy.$t('btn.emtpy'), trigger: 'blur' }],
  })
</script>