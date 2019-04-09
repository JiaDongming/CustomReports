create proc querytree
@subprojectid varchar(100)
as
begin
declare @id int
declare @T_tmp table(projectid int, parentid int,subprojectid int,displayorder int)
insert into @T_tmp select * from SubProjectTree where ParentID=@subprojectid
while(@@rowcount>0)
begin
insert into @T_tmp select * from SubProjectTree where parentid in (select subprojectid from @T_tmp) and ChildID not in(select subprojectid from @T_tmp)
end
insert into @T_tmp select * from SubProjectTree where ChildID=@subprojectid and ParentID=0
select * from @T_tmp 
end


create table TmpTable(projectid int, parentid int,subprojectid int,displayorder int) --创建临时表
--drop proc querytree
exec querytree '19635'

