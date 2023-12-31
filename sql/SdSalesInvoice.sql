use Lean365;

-- 销售凭证菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by, create_time,menuName_key) 
VALUES ('销售凭证', 5100, 999, 'SdSalesInvoice', 'sales/SdSalesInvoice', 0, 0, 'C', '0', '0', 'sd:salesinvoice:list', 'icon1', 'system', GETDATE(), 'menu.sd.salesinvoice');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'sd:salesinvoice:query', '', 'system', GETDATE(), 'btn.search');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'sd:salesinvoice:add', '', 'system', GETDATE(), 'btn.add');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'sd:salesinvoice:delete', '', 'system', GETDATE(), 'btn.delete');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'sd:salesinvoice:edit', '', 'system', GETDATE(), 'btn.edit');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'sd:salesinvoice:export', '', 'system', GETDATE(), 'btn.export');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'sd:salesinvoice:import', '', 'system', GETDATE(), 'btn.import');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;


-- 销售凭证多语言
-- SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT) AS '随机数'

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+5100001,'zh-cn', 'menu.sd.salesinvoice', '销售凭证', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+5100002,'zh-tw', 'menu.sd.salesinvoice', 'TW_销售凭证', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+5100003,'en', 'menu.sd.salesinvoice', 'EN_销售凭证', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+5100004,'ja', 'menu.sd.salesinvoice', 'JA_销售凭证', GETDATE());