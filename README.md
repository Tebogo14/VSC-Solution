# VSC-Solution


Technologies Used

DotNetCore 3.1
EntityFrameworkcore 
PostgreSQL
SwaggerUI 
Nswag (to generate typescript services ) 
Angular 10

For Database connection

1.Change the connection String on this AppSetting.Json to your connection string. 
2.Open powershell on the VSC.EntityFrameworkcore project and run the following command 
	1.dotnet ef migrations add VCSBb 
	2.dotnet ef database update 
	3.A database will be created on your server.