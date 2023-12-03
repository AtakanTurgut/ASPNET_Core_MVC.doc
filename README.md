### dotnet Command Sets
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
``` 

## Used Packages for StoreApp (.\Store\StoreApp)
Packages can be installed from the "[.NET CLI](https://learn.microsoft.com/tr-tr/dotnet/core/tools/)".
```cs
    > dotnet list package
```
- [Microsoft.EntityFrameworkCore 6.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.0)
```
    > dotnet add package Microsoft.EntityFrameworkCore --version 6.0.0
```
- [Microsoft.EntityFrameworkCore.Design 6.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/6.0.0)
```
    > dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0
```
- [Microsoft.EntityFrameworkCore.Sqlite 6.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/6.0.0)
```
    > dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.0
```

### Migrations
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

### sqlite Command Sets
```sql
    > sqlite3 .\ProductDb.db
    sqlite> .tables
    sqlite> select * from Products;
    sqlite> .system cls
    sqlite> .quit
```

```cs
href="/Home/Index"  ->  asp-controller="Home" asp-action="Index"
```