IF OBJECT_ID('V_ProjectPlan') IS NOT NULL
DROP VIEW V_ProjectPlan
go
CREATE VIEW  V_ProjectPlan AS 
SELECT a.ID,a.Unit,a.Activity,a.BusinessCode,a.Task,a.BudgetWorkload,a.BudgetBeginDate,
a.BudgetEndDate,a.DeleteFlag,a.ProjectCode,a.HideFlag,
a.RealWorkload ,b.BeginDealDate AS RealBeginDate ,
b.EndDealDate AS RealEndDate , b.TestPassDate,
CASE WHEN b.ID IS NULL THEN '未开始' ELSE b.Status END AS Status ,
CASE WHEN b.ID IS NULL THEN a.ResourceName ELSE b.DealPerson END AS DealPerson,b.TestPerson,
b.ID AS ProblemTraceID, CASE WHEN b.ID IS NOT NULL THEN '已分配' ELSE '未分配' END AS DispatchStatus,
a.DiffAnalyze
FROM dbo.PPM_ProjectPlan a
LEFT JOIN dbo.PPM_ProblemTrace b ON a.ID=b.ProjectPlanID
go
