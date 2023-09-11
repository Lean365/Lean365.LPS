import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 工厂物料数据分页查询
* @param {查询条件} data
*/
export function listMmMarc(query) {
  return request({
    url: 'material/MmMarc/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增工厂物料数据
* @param data
*/
export function addMmMarc(data) {
  return request({
    url: 'material/MmMarc',
    method: 'post',
    data: data,
  })
}
/**
* 修改工厂物料数据
* @param data
*/
export function updateMmMarc(data) {
  return request({
    url: 'material/MmMarc',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取工厂物料数据详情
* @param {Id}
*/
export function getMmMarc(id) {
  return request({
    url: 'material/MmMarc/' + id,
    method: 'get'
  })
}

/**
* 删除工厂物料数据
* @param {主键} pid
*/
export function delMmMarc(pid) {
  return request({
    url: 'material/MmMarc/' + pid,
    method: 'delete'
  })
}
// 导出工厂物料数据
export async function exportMmMarc(query) {
  await downFile('material/MmMarc/export', { ...query })
}
