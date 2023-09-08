﻿using System;

namespace Lps.CodeGenerator.Model
{
    public class ReplaceDto
    {
        /// <summary>
        /// 主键字段
        /// </summary>
        public string PKName { get; set; }
        /// <summary>
        /// 首字母小写主键
        /// </summary>
        public string FistLowerPk { get; set; }
        /// <summary>
        /// 主键类型
        /// </summary>
        public string PKType { get; set; }
        /// <summary>
        /// 控制器权限
        /// </summary>
        public string PermissionPrefix { get; set; }
        /// <summary>
        /// C#类名
        /// </summary>
        public string ModelTypeName { get; set; }
        //vue、api
        //public string VueViewFormResetHtml { get; set; }
        /// <summary>
        /// 前端列表查询html
        /// </summary>
        public string VueViewListHtml { get; set; }
        /// <summary>
        /// 前端添加、编辑表格html
        /// </summary>
        public string VueViewFormHtml { get; set; }
        /// <summary>
        /// 前端搜索表单html
        /// </summary>
        public string VueQueryFormHtml { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string QueryCondition { get; set; } = "";
        /// <summary>
        /// 导出
        /// </summary>
        public bool ShowBtnExport { get; set; }
        /// <summary>
        /// 新增
        /// </summary>
        public bool ShowBtnAdd { get; set; }
        /// <summary>
        /// 编辑
        /// </summary>
        public bool ShowBtnEdit { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public bool ShowBtnDelete { get; set; }
        /// <summary>
        /// 查看
        /// </summary>
        public bool ShowBtnView { get; set; }
        /// <summary>
        /// 清空
        /// </summary>
        public bool ShowBtnTruncate { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public bool ShowBtnMultiDel { get; set; }
        /// <summary>
        /// 导入
        /// </summary>
        public bool ShowBtnImport { get; set; }
        /// <summary>
        /// 上传URL data
        /// </summary>
        //public string VueUploadUrl { get; set; }
        public int UploadFile { get; set; } = 0;
        /// <summary>
        /// 下拉多选
        /// </summary>
        public int SelectMulti { get; set; }
        /// <summary>
        /// 下拉远程
        /// </summary>
        public int SelectRemote { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string AddTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        /// <summary>
        /// 是否有编辑器
        /// </summary>
        public int ShowEditor { get; set; }
        /// <summary>
        /// vue页面文件名
        /// </summary>
        public string ViewFileName { get; set; }
        /// <summary>
        /// 操作按钮样式
        /// </summary>
        public int OperBtnStyle { get; set; }
    }
}
