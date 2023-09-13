<template>
  <div class="app-container">
    <el-row>
      <el-col :lg="24" class="card-box" v-if="server.cpu">
        <el-card class="box-card">
          <template #header>
            <div class="card-header">
              <div>
                <Cpu style="width: 1em; height: 1em; vertical-align: middle" /> <span
                  style="vertical-align: middle">{{$t('pserverlog.serverCpu')}}</span>
              </div>
              <el-button text @click="getList()">{{$t('pserverlog.refresh')}}</el-button>
            </div>
          </template>

          <div class="col-item">
            <div class="title">{{$t('pserverlog.cpuRate')}}</div>
            <div class="content">
              <el-progress type="dashboard" :percentage="parseFloat(server.cpu.cpuRate)" />
            </div>
            <div class="footer" v-if="server.sys">{{ server.sys.cpuNum }} {{$t('pserverlog.cpuNum')}}</div>
          </div>

          <div class="col-item">
            <div class="title">{{$t('pserverlog.serverRAM')}}</div>
            <el-tooltip placement="top-end">
              <template #content>
                <div style="font-size: 12px">
                  <div style="padding: 3px">{{$t('pserverlog.totalRAM')}}{{ server.cpu.totalRAM }}</div>
                  <div style="padding: 3px">{{$t('pserverlog.usedRam')}}{{ server.cpu.usedRam }}</div>
                  <div style="padding: 3px">{{$t('pserverlog.freeRam')}}{{ server.cpu.freeRam }}</div>
                </div>
              </template>

              <div class="content">
                <el-progress type="dashboard" :percentage="parseFloat(server.cpu.ramRate)" />
              </div>
            </el-tooltip>
            <div class="footer">{{ server.cpu.usedRam }} / {{ server.cpu.totalRAM }}</div>
          </div>

          <div class="col-item">
            <div class="title">{{$t('pserverlog.serverNet')}}</div>
            <div class="content">
              <el-progress type="dashboard" :percentage="parseFloat(appPercent)" />
            </div>
            <div class="footer" v-if="server.app">{{ server.app.appRAM }}</div>
          </div>
        </el-card>
      </el-col>

      <el-col :lg="24" class="card-box">
        <el-card>
          <template #header>
            <Files style="width: 1em; height: 1em; vertical-align: middle" /> <span
              style="vertical-align: middle">{{$t('pserverlog.serverDisk')}}</span>
          </template>
          <div class="col-item" v-for="sysFile in server.disk" :key="sysFile.diskName">
            <div class="title">{{ sysFile.diskName }}{{$t('pserverlog.serverDiskRate')}}</div>
            <div class="content">
              <el-tooltip placement="top-end">
                <template #content>
                  <div style="font-size: 12px">
                    <div style="padding: 3px">{{$t('pserverlog.totalRAM')}}{{ sysFile.totalSize }}GB</div>
                    <div style="padding: 3px">{{$t('pserverlog.freeRam')}}{{ sysFile.availableFreeSpace }}GB</div>
                    <div style="padding: 3px">{{$t('pserverlog.usedRam')}}{{ sysFile.used }}GB</div>
                  </div>
                </template>
                <div class="content">
                  <el-progress type="dashboard" :percentage="parseFloat(sysFile.availablePercent)" />
                </div>
              </el-tooltip>
            </div>
            <div class="footer">{{ sysFile.availableFreeSpace }}GB{{$t('pserverlog.serverDiskavailableFreeSpace')}}{{
              sysFile.totalSize }}GB</div>
          </div>
        </el-card>
      </el-col>

      <el-col :lg="24" class="card-box">
        <el-card>
          <template #header>
            <Monitor style="width: 1em; height: 1em; vertical-align: middle" /> <span
              style="vertical-align: middle">{{$t('pserverlog.serverHost')}}</span>
          </template>
          <div class="el-table el-table--enable-row-hover el-table--medium">
            <table cellspacing="0" style="width: 100%" v-if="server.sys">
              <tbody>
                <tr>
                  <td>
                    <div class="cell">{{$t('pserverlog.computerName')}}</div>
                  </td>
                  <td>
                    <div class="cell">{{ server.sys.computerName }}</div>
                  </td>
                  <td>
                    <div class="cell">{{$t('pserverlog.osName')}}</div>
                  </td>
                  <td>
                    <div class="cell">{{ server.sys.osName }}</div>
                  </td>
                </tr>
                <tr>
                  <td>
                    <div class="cell">{{$t('pserverlog.serverIP')}}</div>
                  </td>
                  <td>
                    <div class="cell">{{ server.sys.serverIP }}</div>
                  </td>
                  <td>
                    <div class="cell">{{$t('pserverlog.osArch')}}</div>
                  </td>
                  <td>
                    <div class="cell">{{ server.sys.osArch }}</div>
                  </td>
                </tr>
                <tr>
                  <td>
                    <div class="cell">{{$t('pserverlog.runTime')}}</div>
                  </td>
                  <td>
                    <div class="cell">{{ server.sys.runTime }}</div>
                  </td>
                  <td>
                    <div class="cell"></div>
                  </td>
                  <td>
                    <div class="cell"></div>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </el-card>
      </el-col>

      <el-col :lg="24" class="card-box">
        <el-card>
          <template #header>
            <Platform style="width: 1em; height: 1em; vertical-align: middle" /> <span
              style="vertical-align: middle">{{$t('pserverlog.serverNetinfo')}}</span>
          </template>
          <div class="el-table el-table--enable-row-hover el-table--medium">
            <table cellspacing="0" style="width: 100%">
              <tbody>
                <tr>
                  <td>
                    <div class="cell">{{$t('pserverlog.pathName')}}</div>
                  </td>
                  <td>
                    <div v-if="server.app">{{ server.app.name }}</div>
                  </td>
                  <td>
                    <div class="cell">{{$t('pserverlog.netVersion')}}</div>
                  </td>
                  <td>
                    <div v-if="server.app">{{ server.app.version }}</div>
                  </td>
                </tr>
                <tr>
                  <td>
                    <div class="cell">{{$t('pserverlog.hoststartTime')}}</div>
                  </td>
                  <td>
                    <div v-if="server.app">{{ server.app.startTime }}</div>
                  </td>
                  <td>
                    <div class="cell">{{$t('pserverlog.hostRunTime')}}</div>
                  </td>
                  <td>
                    <div v-if="server.app">{{ server.app.runTime }}</div>
                  </td>
                </tr>
                <tr>
                  <td>
                    <div class="cell">{{$t('pserverlog.appRAM')}}</div>
                  </td>
                  <td>
                    <div v-if="server.app">{{ server.app.appRAM }}</div>
                  </td>
                  <td>
                    <div class="cell">{{$t('pserverlog.appHostAddr')}}</div>
                  </td>
                  <td>
                    <div v-if="server.app">{{ server.app.host }}</div>
                  </td>
                </tr>
                <tr>
                  <td>
                    <div class="cell">ContentRootPath</div>
                  </td>
                  <td>
                    <div v-if="server.app">{{ server.app.rootPath }}</div>
                  </td>
                  <td>
                    <div class="cell">webPath</div>
                  </td>
                  <td>
                    <div v-if="server.app">{{ server.app.webRootPath }}</div>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>

<script setup name="server">
  import { getServer } from '@/api/monitor/server'
  import { onBeforeRouteLeave } from 'vue-router'
  onBeforeRouteLeave((to) => {
    clear()
  })
  const appPercent = ref(0)
  // 服务器信息
  const server = ref([])
  const intervalId = ref(null)
  const { proxy } = getCurrentInstance()
  /** 查询服务器信息 */
  function getList() {
    getServer()
      .then((response) => {
        server.value = response.data
        proxy.$modal.closeLoading()
      })
      .catch((err) => {
        proxy.$modal.closeLoading()
      })
  }
  // 打开加载层
  function openLoading() {
    proxy.$modal.loading(proxy.$t('pserverlog.serLoading'))
  }
  function dataRefreh() {
    if (intervalId.value != null) {
      return
    }
    intervalId.value = setInterval(() => {
      getList()
    }, 10000)
  }
  /**
   * 停止定时器
   */
  function clear() {
    clearInterval(intervalId.value)
    intervalId.value = null
  }
  watch(
    () => server.value,
    (val) => {
      if (val && val.app) {
        const appRam = val.app.appRAM.replace(' MB', '')
        const totalRam = val.cpu.totalRAM.replace('GB', '') * 1024

        const p = appRam / totalRam
        appPercent.value = p.toFixed(2)
      }
    },
    { immediate: true }
  )
  getList()
  openLoading()
  dataRefreh()
</script>
<style scoped>
  table tr {
    height: 30px;
  }

  .is-leaf {
    text-align: center;
    padding: 0 10px;
  }

  .title {
    text-align: center;
    font-size: 15px;
    font-weight: 500;
    color: #999;
    margin-bottom: 16px;
  }

  .footer {
    text-align: center;
    font-size: 15px;
    font-weight: 500;
    color: #999;
    margin-top: -5px;
    margin-bottom: 10px;
  }

  .content {
    text-align: center;
    margin-top: 5px;
    margin-bottom: 5px;
  }

  .col-item {
    width: 200px;
    display: inline-block;
  }

  .card-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }
</style>