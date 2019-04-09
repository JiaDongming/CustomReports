--获取某节点下所有符合条件的任务



Insert Into TmpTable exec querytree '19635' --把某节点下所有的子节点以及自身插入临时表

--获取所有符合条件的任务
select  ProjectID,SubProjectID,BugID,BugTitle,(CONVERT(varchar(4), PlanedEndDate, 120 )+N'年'+substring(CONVERT(varchar(10), PlanedEndDate, 120 ),6,2)+N'月'+substring(CONVERT(varchar(10), PlanedEndDate, 120 ),9,2)+N'日') as PlanedEndDate,
((CONVERT(varchar(4), IssueFinishDate, 120 )+N'年'+substring(CONVERT(varchar(10), IssueFinishDate, 120 ),6,2)+N'月'+substring(CONVERT(varchar(10), IssueFinishDate, 120 ),9,2)+N'日')) AS IssueFinishDate from Bug where ProjectID=563 and TargetReleaseID=1  and SubProjectID in (
select subprojectid from TmpTable
)

--去除临时表
delete from  TmpTable



--Bug.TargetReleaseID=1: 关键节点：是

select * from SubProject where ProjectID=563
select * from SubProjectTree where ProjectID=563


--获取项目列表 19365
select ProjectID,SubProjectID,Title from SubProject where ProjectID=563 and SubProjectID in (select ChildID from SubProjectTree where ProjectID=563 and ParentID=0)




