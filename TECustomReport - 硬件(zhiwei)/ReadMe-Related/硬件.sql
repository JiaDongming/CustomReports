--��ȡĳ�ڵ������з�������������



Insert Into TmpTable exec querytree '19635' --��ĳ�ڵ������е��ӽڵ��Լ����������ʱ��

--��ȡ���з�������������
select  ProjectID,SubProjectID,BugID,BugTitle,(CONVERT(varchar(4), PlanedEndDate, 120 )+N'��'+substring(CONVERT(varchar(10), PlanedEndDate, 120 ),6,2)+N'��'+substring(CONVERT(varchar(10), PlanedEndDate, 120 ),9,2)+N'��') as PlanedEndDate,
((CONVERT(varchar(4), IssueFinishDate, 120 )+N'��'+substring(CONVERT(varchar(10), IssueFinishDate, 120 ),6,2)+N'��'+substring(CONVERT(varchar(10), IssueFinishDate, 120 ),9,2)+N'��')) AS IssueFinishDate from Bug where ProjectID=563 and TargetReleaseID=1  and SubProjectID in (
select subprojectid from TmpTable
)

--ȥ����ʱ��
delete from  TmpTable



--Bug.TargetReleaseID=1: �ؼ��ڵ㣺��

select * from SubProject where ProjectID=563
select * from SubProjectTree where ProjectID=563


--��ȡ��Ŀ�б� 19365
select ProjectID,SubProjectID,Title from SubProject where ProjectID=563 and SubProjectID in (select ChildID from SubProjectTree where ProjectID=563 and ParentID=0)




