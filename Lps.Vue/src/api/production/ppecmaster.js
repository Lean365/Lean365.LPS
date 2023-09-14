import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 主设变分页查询
* @param {查询条件} data
*/
export function listPpEcMaster(query) {
  return request({
    url: 'production/PpEcMaster/list',
    method: 'get',
    params: query,
  })
}

/**
* 主设变tree查询
* @param {查询条件} data
*/
export function treelistPpEcMaster(query) {
  return request({
    url: 'production/PpEcMaster/treelist',
    method: 'get',
    params: query,
  })
}
/**
* 新增主设变
* @param data
*/
export function addPpEcMaster(data) {
  return request({
    url: 'production/PpEcMaster',
    method: 'post',
    data: data,
  })
}
/**
* 修改主设变
* @param data
*/
export function updatePpEcMaster(data) {
  return request({
    url: 'production/PpEcMaster',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取主设变详情
* @param {Id}
*/
export function getPpEcMaster(id) {
  return request({
    url: 'production/PpEcMaster/' + id,
    method: 'get'
  })
}

/**
* 删除主设变
* @param {主键} pid
*/
export function delPpEcMaster(pid) {
  return request({
    url: 'production/PpEcMaster/' + pid,
    method: 'delete'
  })
}
// 导出主设变
export async function exportPpEcMaster(query) {
  await downFile('production/PpEcMaster/export', { ...query })
}
