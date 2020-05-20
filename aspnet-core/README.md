# TransactionExchangeCentre Web API

This project work together with TransactionExchangeCentre.Angular. This is the backend server of the project.  

## Setup development environment

Install [Visual Studio GitLab Extension](https://marketplace.visualstudio.com/items?itemName=MysticBoy.GitLabExtensionforVisualStudio).  
Clone this repository to your local drive.  
Change your Connection string at `appsettings.json` in `DataSolutions.TransactionExchangeCentre.Web.Host` to your flavour. FYI, my connection string is workable in office.  
> Server={copy your local machine name here from SQL server management studio}\\SQLEXPRESS;Integrated Security=true; Database=TransactionExchangeCentreDb;  

Open `Package Manager Console` at the bottom of Visual Studio.  
Set the default project to `DataSolutions.TransactionExchangeCentre.EntityFrameworkCore`.  
Type `Update-Database` in the console. It may takes about a minute. After that a new database should be already generated.  
Set the start up project to `DataSolutions.TransactionExchangeCentre.Web.Host`. Press `IIS Express` button to launch the debug environment.  

## Asp Net Boilerplate

Please refer to the document for [ASP.NET Core, Entity Framework and Angular](https://aspnetboilerplate.com/Pages/Documents/Articles/Developing-MultiTenant-SaaS-ASP.NET-CORE-Angular/index.html)  

## Adding feature

### Entity

Please refer to [Abp Entities](https://aspnetboilerplate.com/Pages/Documents/Entities).  
Add a class extending `Entity` in `DataSolutions.TransactionExchangeCentre.Core`.  
Add a `DbSet` in `TransactionExchangeCentreDbContext` at `EntityFrameworkCore` project.  
Type `Add-Migration` in the console. Type `V{your version number here}_{version name}`. It may takes about a minute. After that a new table should be already generated.  

### Application Service

Please refer to [Abp Application Services](https://aspnetboilerplate.com/Pages/Documents/Application-Services).  
Please use class name end with `AppService` as it will generate WebAPI controller for you.  
Extending `AsyncCrudAppService` is good as it will provide basic CRUD of a DTO.  
  
Jeremy Wong