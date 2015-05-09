--1、必须在 MSDB 数据库中的 QueryNotificationService 服务上向Guest用户授予发送权限。方法如下，注意要区分大小写。
USE MSDB
GRANT SEND ON SERVICE::
[http://schemas.microsoft.com/SQL/Notifications/QueryNotificationService]
TO GUEST

--2、启用CLR。在一个消息到达服务队列时，一个包含.Net代码的存储过程sp_DispatcherProc将使用一个队列来派发消息。因此必须启用Sql Server中的CLR功能。启用方法如下：
Use Master
Exec sp_configure 'clr enabled',1
RECONFIGURE

--3,SqlDependency 对象会使用 Service Broker 将消息发送给 QueryNotificationService服务,所以需要启用 Service Broker,可以通过下边语句查看是否启用
select DatabasePropertyex('BugTrace','IsBrokerEnabled')--返回1表示true，返加0表示false
--启动Service Broker语句如下： 
use master
--ALTER AUTHORIZATION  ON DATABASE::BugTrace    TO sa;
--ALTER DATABASE BugTrace SET NEW_BROKER
--ALTER DATABASE BugTrace SET NEW_BROKER WITH ROLLBACK IMMEDIATE;
Alter Database BugTrace set enable_broker

