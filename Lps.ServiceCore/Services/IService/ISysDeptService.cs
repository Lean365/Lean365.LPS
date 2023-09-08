using System.Collections.Generic;
using Lps.ServiceCore.Model.Dto;
using Lps.Model.System.Vo;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    public interface ISysDeptService : IBaseService<SysDept>
    {
        List<SysDept> GetSysDepts(SysDeptQueryDto dept);
        string CheckDeptNameUnique(SysDept dept);
        int InsertDept(SysDept dept);
        int UpdateDept(SysDept dept);
        void UpdateDeptChildren(long deptId, string newAncestors, string oldAncestors);
        List<SysDept> GetChildrenDepts(List<SysDept> depts, long deptId);
        List<SysDept> BuildDeptTree(List<SysDept> depts);
        List<TreeSelectVo> BuildDeptTreeSelect(List<SysDept> depts);
        List<SysRoleDept> SelectRoleDeptByRoleId(long roleId);

        List<long> SelectRoleDepts(long roleId);
        bool DeleteRoleDeptByRoleId(long roleId);
        int InsertRoleDepts(SysRole role);
    }

    public interface ISysRoleDeptService : IBaseService<SysRoleDept>
    {
        List<SysRoleDept> SelectRoleDeptByRoleId(long roleId);
    }
}
