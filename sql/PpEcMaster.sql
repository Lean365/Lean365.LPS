use Lean365;

-- 主设变菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by, create_time,menuName_key) 
VALUES ('主设变', 310010, 999, 'PpEcMaster', 'production/PpEcMaster', 0, 0, 'C', '0', '0', 'pp:ecmaster:list', 'icon1', 'system', GETDATE(), 'menu.pp.ecmaster');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:query', '', 'system', GETDATE(), 'btn.search');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:add', '', 'system', GETDATE(), 'btn.add');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:delete', '', 'system', GETDATE(), 'btn.delete');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:edit', '', 'system', GETDATE(), 'btn.edit');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:export', '', 'system', GETDATE(), 'btn.export');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:import', '', 'system', GETDATE(), 'btn.import');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;


-- 主设变多语言
-- SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT) AS '随机数'

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+310010001,'zh-cn', 'menu.pp.ecmaster', '主设变', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+310010002,'zh-tw', 'menu.pp.ecmaster', 'TW_主设变', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+310010003,'en', 'menu.pp.ecmaster', 'EN_主设变', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+310010004,'ja', 'menu.pp.ecmaster', 'JA_主设变', GETDATE());