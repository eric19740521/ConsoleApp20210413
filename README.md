# ConsoleApp20210413

Linux Docker安裝SQLServer 2017並使用 &  vs code  C# 使用Dapper套件 讀取資料
參考資料：
https://docs.microsoft.com/zh-tw/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash

https://blog.poychang.net/note-dapper/

sqlserver 安裝限制
至少 2 GB 的磁碟空間。 至少 2 GB 的 RAM。

下載映像檔..從 Microsoft Container Registry 提取 SQL Server 2017 Linux 容器映像。
sudo docker pull mcr.microsoft.com/mssql/server:2017-latest

執行容器映像
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" \
   -p 1433:1433 --name sql1 -h sql1 \
   -d \
   mcr.microsoft.com/mssql/server:2017-latest

檢視 Docker 容器，請使用 docker ps 命令。
sudo docker ps -a
變更 SA 密碼
sudo docker exec -it sql1 /opt/mssql-tools/bin/sqlcmd \
   -S localhost -U SA -P "<YourStrong@Passw0rd>" \
   -Q 'ALTER LOGIN SA WITH PASSWORD="<YourNewStrong@Passw0rd>"'
連接至 SQL Server
sudo docker exec -it sql1 "bash"


/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "<YourNewStrong@Passw0rd>"

列資料庫名稱
SELECT Name from sys.Databases

建立及查詢資料
CREATE DATABASE TestDB

 

GO








插入資料



USE TestDB

CREATE TABLE Member (mem_no INT, mem_name NVARCHAR(50))

INSERT INTO Member VALUES (1, 'A001'); INSERT Member VALUES (2, 'A002');


選取資料
SELECT * FROM member WHERE mem_no > 1;


QUIT


從容器外部連線
sqlcmd -S <ip_address>,1433 -U SA -P "<YourNewStrong@Passw0rd>"



移除容器

sudo docker stop sql1
sudo docker rm sql1



















C#   SDK 2.1.814 dotnet core

Test03專案

dotnet new globaljson


{
"sdk": {
"version": "2.1.814"
}
}

Dotnet new console


dotnet add package System.Data.SqlClient --version 4.8.2


dotnet add package Dapper --version 2.0.78













