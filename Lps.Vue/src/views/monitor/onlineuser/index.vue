<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryRef" :inline="true">
      <el-form-item>
        <el-button plain type="danger" size="small" @click="onLockAll()" icon="lock"
          v-hasPermi="['monitor:online:forceLogout']">{{$t('ponline.forceLogoutAll')}}</el-button>
      </el-form-item>
      <el-form-item>
        <el-radio-group v-model="viewSwitch" fill='#d4237a' size="small">
          <el-radio-button label="1">{{$t('ponline.viewSwitchGrid')}}</el-radio-button>
          <el-radio-button label="2">{{$t('ponline.viewSwitchCard')}}</el-radio-button>
        </el-radio-group>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="Search" size="small" @click="handleQuery">{{$t('ponline.reFresh')}}</el-button>
      </el-form-item>
    </el-form>
    <!-- <el-row :gutter="10" class="mb8">
      <el-col :span="2"> </el-col>
    </el-row> -->
    <el-table :data="onlineUsers" v-loading="loading" ref="tableRef" border highlight-current-row
      v-if="viewSwitch == 1">
      <el-table-column label="No" type="index" width="50" align="center">
        <template #default="scope">
          <span>{{ (queryParams.pageNum - 1) * queryParams.pageSize + scope.$index + 1 }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="name" :label="$t('ponline.userName')" align="center" />
      <el-table-column prop="location" :label="$t('ponline.loginLocation')" align="center"> </el-table-column>
      <el-table-column prop="userIP" :label="$t('ponline.userIP')" align="center"></el-table-column>
      <el-table-column prop="browser" :label="$t('ponline.LoginBrowser')" width="240"></el-table-column>
      <el-table-column prop="platform" :label="$t('ponline.LoginDevice')" align="center"></el-table-column>
      <el-table-column prop="loginTime" :label="$t('ponline.loginTime')" witdh="280px">
        <template #default="scope">
          {{ dayjs(scope.row.loginTime).format('YYYY-MM-DD HH:mm:ss') }}
          <div>{{$t('ponline.OnlineDuration')}}{{ scope.row.onlineTime }}{{$t('ponline.TimeUnit')}}</div>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" width="160">
        <template #default="scope">
          <el-button color="#626aef" size="small" @click="onChat(scope.row)" icon="ChatDotRound" v-hasRole="['admin']"
            :title="$t('ponline.Notice')"></el-button>
          <el-button type="danger" plain size="small" @click="onLock(scope.row)" icon="lock"
            v-hasPermi="['monitor:online:forceLogout']" :title="$t('ponline.forceLogout')"></el-button>
        </template>
      </el-table-column>
    </el-table>

    <el-row :gutter="20" v-if="viewSwitch == 2">
      <el-col v-for="item in onlineUsers" :lg="4" :span="24">
        <el-card :body-style="{ padding: '15px 15px 10' }">
          <el-descriptions :column="1" :title="item.name">
            <el-descriptions-item :label="$t('ponline.LoginPlatform')">{{ item.platform }}</el-descriptions-item>
            <el-descriptions-item :label="$t('ponline.loginLocation')">{{ item.location }}</el-descriptions-item>
            <el-descriptions-item :label="$t('ponline.OnlineDuration')" :span="2">
              <el-tag type="success">{{ item.onlineTime }}{{$t('ponline.TimeUnit')}}</el-tag>
            </el-descriptions-item>
          </el-descriptions>
          <el-text truncated>{{ item.browser }}</el-text>
          <div style="top:30%;text-align:center;">
            <el-button color=" #626aef" szie="small" @click="onChat(item)" icon="ChatDotRound"
              :title="$t('ponline.Notice')" v-hasRole="['admin']"></el-button>
            <el-button type="danger" plain szie="small" @click="onLock(item)" icon="lock"
              :title="$t('ponline.forceLogout')" v-hasPermi="['monitor:online:forceLogout']"></el-button>
          </div>
        </el-card>
      </el-col>

      <el-empty v-show="total == 0" description="no data" />
    </el-row>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />
  </div>
</template>

<script setup name="onlineuser">
  import { listOnline, forceLogout, forceLogoutAll } from '@/api/monitor/online'
  import dayjs from 'dayjs'
  import useSocketStore from '@/store/modules/socket'
  const { proxy } = getCurrentInstance()
  const queryRef = ref(null)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 14
  })

  const onlineNum = computed(() => {
    return useSocketStore().onlineNum
  })
  const viewSwitch = ref(1)
  const loading = ref(false)
  const onlineUsers = ref([])
  const total = ref(0)
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  function getList() {
    loading.value = true
    listOnline(queryParams).then((res) => {
      if (res.code == 200) {
        total.value = res.data.totalNum
        onlineUsers.value = res.data.result
        setTimeout(() => {
          loading.value = false
        }, 200)
      }
    })
  }
  getList()

  function onChat(item) {
    proxy
      .$prompt(proxy.$t('ponline.notificationContent'), {
        confirmButtonText: proxy.$t('ponline.send'),
        cancelButtonText: proxy.$t('ponline.cancel'),
        type: "info",
        inputPattern: /\S/,
        inputErrorMessage: proxy.$t('ponline.empty')
      })
      .then(({ value }) => {
        proxy.signalr.SR.invoke('sendMessage', item.connnectionId, item.userid, value).catch(function (err) {
          console.error(err.toString())
        })
      })
      .catch(() => { })
  }
  function onLock(row) {
    proxy
      .$prompt(proxy.$t('ponline.forceReason'), {
        confirmButtonText: proxy.$t('ponline.send'),
        cancelButtonText: proxy.$t('ponline.cancel'),
        type: "warning",
        inputPattern: /\S/,
        inputErrorMessage: proxy.$t('ponline.empty')
      })
      .then((val) => {
        forceLogout({ ...row, time: 10, reason: val.value, clientId: row.clientId }).then(() => {
          proxy.$modal.msgSuccess(proxy.$t('ponline.forceSuccessful'))
        })
      })
  }

  // 批量强退
  function onLockAll() {
    proxy
      .$prompt(proxy.$t('ponline.forceReason'), {
        confirmButtonText: proxy.$t('ponline.send'),
        cancelButtonText: proxy.$t('ponline.cancel'),
        type: "warning",
        inputPattern: /\S/,
        inputErrorMessage: proxy.$t('ponline.empty')
      })
      .then((val) => {
        forceLogoutAll({ time: 10, reason: val.value }).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('ponline.forceSuccessful'))
        })
      })
  }
  watch(
    onlineNum,
    () => {
      handleQuery()
    },
    {
      immediate: true
    }
  )
</script>
<style>
  .el-col {
    margin-bottom: 10px;
  }
</style>