--1创建insert触发器
if (object_id('tgr_PPM_ProblemTrace_Insert', 'tr') is not null)
    drop trigger tgr_PPM_ProblemTrace_Insert
go
create trigger tgr_PPM_ProblemTrace_Insert
on PPM_ProblemTrace
    for insert --插入触发
as
    --定义变量
    declare @id int, 
    @findPersonCode varchar(50), --提出人
    @findPerson nvarchar(50),--提出人姓名
    @dealPersonCode varchar(50), --处理人
    @dealPerson nvarchar(50),--处理人姓名
    @projectManagerCode VARCHAR(50);--项目经理    
    --在inserted表中查询已经插入记录信息
    select @id = id, @findPersonCode = FindPersonCode, 
    @projectManagerCode=ProjectManagerCode ,@dealPersonCode=DealPersonCode from inserted;
    --查询提出人的姓名
    SELECT @findPerson=UserName FROM SYS_User WHERE UserCode=@findPersonCode;
    --查询处理人姓名
    SELECT @dealPerson=UserName FROM SYS_User WHERE UserCode=@dealPersonCode;
    --插入消息记录表 提出人发给处理人 
    IF EXISTS(SELECT 1 FROM dbo.SYS_User WHERE UserCode=@findPersonCode) 
	AND EXISTS (SELECT 1 FROM dbo.SYS_User WHERE UserCode=@dealPersonCode)
	begin
	    insert into dbo.PPM_MessageRecord(MessageFrom,MessageTo,ProblemTraceID,MsgContent,MsgType) 
		values(@findPersonCode, @dealPersonCode, @id,'你有一个要处理的任务，提出人:'+@findPerson+'，任务号:'+CONVERT(NVARCHAR(50),@id),0); 
	END
	--插入消息记录表，如果处理人不是项目经理，则需要通知项目经理 
	IF @dealPersonCode<>@projectManagerCode
	BEGIN	
		IF EXISTS(SELECT 1 FROM dbo.SYS_User WHERE UserCode=@findPersonCode) 
		AND EXISTS (SELECT 1 FROM dbo.SYS_User WHERE UserCode=@projectManagerCode)
		begin
			insert into dbo.PPM_MessageRecord(MessageFrom,MessageTo,ProblemTraceID,MsgContent,MsgType) 
			values(@findPersonCode, @projectManagerCode, @id,'你收到一条通知，'+@findPerson+'给'+@dealPerson+'提出了一个任务，任务号：'+CONVERT(NVARCHAR(50),@id),1); 
		END
    END   
GO

--2创建update触发器
if (object_id('tgr_PPM_ProblemTrace_update', 'tr') is not null)
    drop trigger tgr_PPM_ProblemTrace_update
go
create trigger tgr_PPM_ProblemTrace_update
on PPM_ProblemTrace
    for update
as
    declare @id INT ,
            @findPersonCode VARCHAR(50),--提出人
            @findPerson NVARCHAR(50),--提出人姓名
            @oldDealPersonCode VARCHAR(50), @newDealPersonCode varchar(50),--处理人
            @newDealPerson NVARCHAR(50),--处理人姓名
            @oldStatus varchar(50), @newStatus varchar(50),--状态
            @TeamLeader VARCHAR(50);--模块负责人
    --更换处理人
    SELECT @oldDealPersonCode = DealPersonCode from deleted;--更新前的数据    
    select @id=ID,@findPersonCode=FindPersonCode,@newDealPersonCode = DealPersonCode from inserted;--更新后的数据
    --findPerson名称
    SELECT @findPerson=UserName FROM dbo.SYS_User WHERE UserCode=@findPersonCode;
    IF(@oldDealPersonCode<>@newDealPersonCode)
    BEGIN		
		IF EXISTS(SELECT 1 FROM dbo.SYS_User WHERE UserCode=@findPersonCode) 
		AND EXISTS (SELECT 1 FROM dbo.SYS_User WHERE UserCode=@newDealPersonCode)
		begin
			insert into dbo.PPM_MessageRecord(MessageFrom,MessageTo,ProblemTraceID,MsgContent,MsgType) 
			values(@findPersonCode, @newDealPersonCode, @id,'你有一个要处理的任务，提出人:'+@findPerson+'，任务号:'+CONVERT(NVARCHAR(50),@id),0); 
		END
    END
    --更换状态
    SELECT @oldStatus=STATUS FROM deleted;
    SELECT @newStatus=STATUS FROM inserted;  
    --提出人findPerson名称
	SELECT @newDealPerson=UserName FROM dbo.SYS_User WHERE UserCode=@newDealPersonCode;
	--处理人的老师（模块负责人）
	SELECT @TeamLeader=TeamLeader FROM dbo.PPM_ProjectTeam WHERE TeamMember=@newDealPersonCode;  
    IF @oldStatus<>@newStatus
    BEGIN
		IF @newStatus='已提交未审核'
		BEGIN				
			--将提交的任务反馈给模块负责人（老师）
			insert into dbo.PPM_MessageRecord(MessageFrom,MessageTo,ProblemTraceID,MsgContent,MsgType) 
			values(@newDealPersonCode, @TeamLeader, @id,'你有一个要检查的任务，处理人:'+@newDealPerson+'，任务号:'+CONVERT(NVARCHAR(50),@id),2); 			
		END
		ELSE IF @newStatus='完成'--项目经理或模块负责人检查完毕之后，需要提交到测试人员测试
		BEGIN
			IF @findPersonCode<>@TeamLeader--如果提出人员同时也是项目经理（模块负责人），则无需发送测试任务
			BEGIN
				insert into dbo.PPM_MessageRecord(MessageFrom,MessageTo,ProblemTraceID,MsgContent,MsgType) 
				values(@newDealPersonCode, @TeamLeader, @id,'你有一个要测试的任务，处理人:'+@newDealPerson+'，任务号:'+CONVERT(NVARCHAR(50),@id),3); 			
			END
		END
		ELSE IF @newStatus='未通过'
		BEGIN
			insert into dbo.PPM_MessageRecord(MessageFrom,MessageTo,ProblemTraceID,MsgContent,MsgType) 
			values(@newDealPersonCode, @TeamLeader, @id,'你有一个要处理的任务，提出人:'+@findPersonCode+'，任务号:'+CONVERT(NVARCHAR(50),@id),0); 			
		END
    END
    
    
go
