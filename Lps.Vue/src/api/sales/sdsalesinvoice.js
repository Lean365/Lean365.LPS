import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 销售凭证分页查询
* @param {查询条件} data
*/
export function listSdSalesInvoice(query) {
  return request({
    url: 'sales/SdSalesInvoice/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增销售凭证
* @param data
*/
export function addSdSalesInvoice(data) {
  return request({
    url: 'sales/SdSalesInvoice',
    method: 'post',
    data: data,
  })
}
/**
* 修改销售凭证
* @param data
*/
export function updateSdSalesInvoice(data) {
  return request({
    url: 'sales/SdSalesInvoice',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取销售凭证详情
* @param {Id}
*/
export function getSdSalesInvoice(id) {
  return request({
    url: 'sales/SdSalesInvoice/' + id,
    method: 'get'
  })
}

/**
* 删除销售凭证
* @param {主键} pid
*/
export function delSdSalesInvoice(pid) {
  return request({
    url: 'sales/SdSalesInvoice/' + pid,
    method: 'delete'
  })
}
// 导出销售凭证
export async function exportSdSalesInvoice(query) {
  await downFile('sales/SdSalesInvoice/export', { ...query })
}
