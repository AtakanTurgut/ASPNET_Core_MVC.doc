## StoreApp Project Layers
Main Project: .\Store\StoreApp <br />
```cs
    > dotnet list .\StoreApp\ reference
```
```cs
    Entities
    Repositories  =>  Entities
    Services      =>  Entities + Repositories
    StoreApp      =>  Entities + Repositories + Services ++ Presentation

    + Presentation => Services
```

# Used Packages for StoreApp 
Packages can be installed from the "[.NET CLI](https://learn.microsoft.com/tr-tr/dotnet/core/tools/)".
```cs
    > dotnet list package
```
#### Repositories:
- [Microsoft.EntityFrameworkCore.Design 6.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/6.0.0)
```
    > dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0
```
- [Microsoft.EntityFrameworkCore 6.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.0)
```
    > dotnet add package Microsoft.EntityFrameworkCore --version 6.0.0
```
- + [Microsoft.EntityFrameworkCore.SqlServer 6.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/6.0.0)
```
    > dotnet add .\Repositories\ package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.0
```
#### Services:
- [AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/)
```
    > dotnet add .\Services\ package AutoMapper.Extensions.Microsoft.DependencyInjection
```
#### StoreApp:
- [Microsoft.EntityFrameworkCore.Sqlite 6.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/6.0.0)
```
    > dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.0
```
#### + Presentation:
- [Microsoft.AspNetCore.Mvc.Core 2.2.5](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Core/)
```
    > dotnet add .\Presentation\ package Microsoft.AspNetCore.Mvc.Core
```

<hr />

## dotnet Command Sets
```cs
dotnet
dotnet --verison
dotnet --list-sdks
dotnet new --help
dotnet new list
dotnet new mvc -h

dotnet new mvc -f net6.0 -o basics
cd basics
basics> dotnet build
dotnet run
dotnet watch

dotnet new sln -o Store
dotnet new web -f net6.0 -o .\Store\StoreApp
dotnet sln .\Store\ add .\Store\StoreApp\
dotnet sln .\Store.sln list

---
dotnet tool -h
dotnet tool list -h
dotnet tool list -g

dotnet tool install --global dotnet-ef --version 6.0.0
dotnet tool install -g Microsoft.Web.LibraryManager.Cli

--06--
dotnet new classlib -f net6.0 -o .\Store\Entities
dotnet sln .\Store.sln add .\Entities\
dotnet add .\StoreApp\ reference .\Entities\

dotnet new classlib -f net6.0 -o .\Store\Repositories
dotnet sln .\Store\ add .\Store\Repositories\
dotnet sln .\Store\ list
dotnet add .\Store\StoreApp\ reference .\Store\Repositories\

dotnet add .\Store\Repositories\ package Microsoft.EntityFrameworkCore --version 6.0.0
dotnet add .\Store\Repositories\ package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.0
dotnet list .\Store\Repositories\ package

dotnet remove .\Store\StoreApp\ package Microsoft.EntityFrameworkCore
dotnet remove .\Store\StoreApp\ package Microsoft.EntityFrameworkCore.Sqlite

dotnet add .\Repositories\ reference .\Entities\

--07--
dotnet new classlib -f net6.0 -o Services
dotnet sln .\Store.sln add .\Services\

dotnet add .\Services\ reference .\Entities\
dotnet add .\Services\ reference .\Repositories\
dotnet add .\StoreApp\ reference .\Services\

dotnet list .\Services\ package
``` 

# API Implementation 
```cs
--17--
dotnet new classlib -f net6.0 -o Presentation 

dotnet sln .\Store.sln list
dotnet sln .\Store.sln add .\Presentation\

dotnet add .\Presentation\ package Microsoft.AspNetCore.Mvc.Core

dotnet add .\Presentation\ reference .\Services\
dotnet add .\StoreApp\ reference .\Presentation\
```

## libman Command Sets
```cs
libman -h
libman init -p cdnjs
libman install -h 

libman install bootstrap -d wwwroot/lib/bootstrap 
libman install font-awesome -d wwwroot/lib/font-awesome
libman install jquery -d wwwroot/lib/jquery
```
[libman source](https://learn.microsoft.com/tr-tr/aspnet/core/client-side/libman/libman-cli?view=aspnetcore-7.0) 
<br />

[dotnet-ef source](https://learn.microsoft.com/tr-tr/ef/core/cli/dotnet) 

## Migrations
Use this commands for the `Migration Operations`:
```cs
    > dotnet ef migrations -h
    > dotnet ef database -h
```
- Create Migration  
```
    > dotnet ef migrations add init 
```
- Update Data   (Add Configurations)
```
    > dotnet ef database update
```
- Drop the Database
```
    > dotnet ef database drop
    ? Y
```
- Delete Migrations
```
    > del .\Migrations\
    ? A
```

## sqlite Command Sets
```sql
    > sqlite3 .\ProductDb.db
    sqlite> .tables
    sqlite> .mode box
    sqlite> select * from Products;
    sqlite> .system cls
    sqlite> .quit

    sqlite> insert into Categories(CategoryName) VALUES('Telephone');
```

## + SqlServer Configuration
```cs
    dotnet list .\Repositories\ package
    dotnet add .\Repositories\ package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.0

    del .\Migrations\
    dotnet ef database drop
```
```cs
    - StoreApp.appsettings.json => "ConnectionStrings": { "mssqlConnection": "" }
    - StoreApp.Infrastructure.Extensions.ServiceExtension.ConfigureDbContext() =>
            .UseSqlServer() - "mssqlConnection"  -->  mssql db
            .UseSqlite()    - "sqlConnection"    -->  sqlite db
```

#### Users - Names and Passwords
```cs
    Admin:
        Name: Admin  Password: admin123456.
    
    User:
        Name: Atakan Password: 123456+
```

```cs
href="/Home/Index"  ->  asp-controller="Home" asp-action="Index"
```