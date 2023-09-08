﻿using System.Collections.Generic;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Model.Dto
{
    public class SysRoleDto : SysBase
    {
        public long RoleId { get; set; }
        /// <summary>
        /// 要添加的菜单集合
        /// </summary>
        public List<long> MenuIds { get; set; } = new List<long>();
        public string RoleName { get; set; }
        public string RoleKey { get; set; }
        public int RoleSort { get; set; }
        public int IsStatus { get; set; }
        public int DataScope { get; set; }
        public int[] DeptIds { get; set; }
        /// <summary>
        /// 减少菜单集合
        /// </summary>
        public List<long> DelMenuIds { get; set; } = new List<long>();
        public bool MenuCheckStrictly { get; set; }
        public bool DeptCheckStrictly { get; set; }

    }
}
