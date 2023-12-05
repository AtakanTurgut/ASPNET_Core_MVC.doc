# Used Packages for StoreApp (.\Store\StoreApp)
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
#### StoreApp:
- [Microsoft.EntityFrameworkCore.Sqlite 6.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/6.0.0)
```
    > dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.0
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
```

## sqlite Command Sets
```sql
    > sqlite3 .\ProductDb.db
    sqlite> .tables
    sqlite> .mode box
    sqlite> select * from Products;
    sqlite> .system cls
    sqlite> .quit
```

```cs
href="/Home/Index"  ->  asp-controller="Home" asp-action="Index"
```