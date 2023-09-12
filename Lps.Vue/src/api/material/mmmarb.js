import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 物料信息分页查询
* @param {查询条件} data
*/
export function listMmMarb(query) {
  return request({
    url: 'material/MmMarb/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增物料信息
* @param data
*/
export function addMmMarb(data) {
  return request({
    url: 'material/MmMarb',
    method: 'post',
    data: data,
  })
}
/**
* 修改物料信息
* @param data
*/
export function updateMmMarb(data) {
  return request({
    url: 'material/MmMarb',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取物料信息详情
* @param {Id}
*/
export function getMmMarb(id) {
  return request({
    url: 'material/MmMarb/' + id,
    method: 'get'
  })
}

/**
* 删除物料信息
* @param {主键} pid
*/
export function delMmMarb(pid) {
  return request({
    url: 'material/MmMarb/' + pid,
    method: 'delete'
  })
}
// 导出物料信息
export async function exportMmMarb(query) {
  await downFile('material/MmMarb/export', { ...query })
}
