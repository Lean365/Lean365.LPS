use Lean365;

-- 从设变菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by, create_time,menuName_key) 
VALUES ('从设变', 310010, 999, 'PpEcSlave', 'production/PpEcSlave', 0, 0, 'C', '0', '0', 'pp:ecslave:list', 'icon1', 'system', GETDATE(), 'menu.PpEcSlave');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecslave:query', '', 'system', GETDATE(), 'btn.search');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecslave:add', '', 'system', GETDATE(), 'btn.add');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecslave:delete', '', 'system', GETDATE(), 'btn.delete');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecslave:edit', '', 'system', GETDATE(), 'btn.edit');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecslave:export', '', 'system', GETDATE(), 'btn.export');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecslave:import', '', 'system', GETDATE(), 'btn.import');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;


-- 从设变多语言
-- SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT) AS '随机数'

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+310010001,'zh-cn', 'menu.PpEcSlave', '从设变', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+310010002,'zh-tw', 'menu.PpEcSlave', 'TW_从设变', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+310010003,'en', 'menu.PpEcSlave', 'EN_从设变', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+310010004,'ja', 'menu.PpEcSlave', 'JA_从设变', GETDATE());