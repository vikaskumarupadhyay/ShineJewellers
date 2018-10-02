
if not exists (select * from sys.objects obj join sys.all_columns col on obj.object_id = col.object_id where obj.name='ProductCategory' and  col.name='CategoryOrder')
Begin
alter table ProductCategory
add CategoryOrder int not null
end



if not exists (select * from sys.objects obj join sys.all_columns col on obj.object_id = col.object_id where obj.name='ProductCategory' and  col.name='Content')
Begin
alter table ProductCategory
add Content int not null
end

if not exists (select * from sys.objects obj join sys.all_columns col on obj.object_id = col.object_id where obj.name='ProductCategory' and  col.name='Content')
Begin
alter table ProductCategory
add Content int not null
end

if not exists (select * from sys.objects obj join sys.all_columns col on obj.object_id = col.object_id where obj.name='ProductCategory' and  col.name='RouteControllerName')
Begin
alter table ProductCategory
add RouteControllerName int not null
end


if not exists (select * from sys.objects obj join sys.all_columns col on obj.object_id = col.object_id where obj.name='ProductCategory' and  col.name='RouteActionName')
Begin
alter table ProductCategory
add RouteActionName int not null
end

