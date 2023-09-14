import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 从设变分页查询
* @param {查询条件} data
*/
export function listPpEcSlave(query) {
  return request({
    url: 'production/PpEcSlave/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增从设变
* @param data
*/
export function addPpEcSlave(data) {
  return request({
    url: 'production/PpEcSlave',
    method: 'post',
    data: data,
  })
}
/**
* 修改从设变
* @param data
*/
export function updatePpEcSlave(data) {
  return request({
    url: 'production/PpEcSlave',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取从设变详情
* @param {Id}
*/
export function getPpEcSlave(id) {
  return request({
    url: 'production/PpEcSlave/' + id,
    method: 'get'
  })
}

/**
* 删除从设变
* @param {主键} pid
*/
export function delPpEcSlave(pid) {
  return request({
    url: 'production/PpEcSlave/' + pid,
    method: 'delete'
  })
}
// 导出从设变
export async function exportPpEcSlave(query) {
  await downFile('production/PpEcSlave/export', { ...query })
}
