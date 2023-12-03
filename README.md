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
``` 

```cs
href="/Home/Index"  ->  asp-controller="Home" asp-action="Index"
```