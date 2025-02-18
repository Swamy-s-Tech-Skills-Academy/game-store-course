# Game Store Solution

I am learning Game Store .NET 8/9 from different Video Courses, Books, and Websites.

## Solution Setup

```powershell
D:\STSA\game-store-course> dotnet new sln -n GameStore

D:\STSA\game-store-course\src> dotnet new web -n GameStore.Api

PS D:\STSA\game-store-course> dotnet sln add .\src\GameStore.Api\GameStore.Api.csproj
```

## MSSQLLocalDB Setup

```text
PS C:\Users\swamy> SqlLocalDB stop MSSQLLocalDB -k
LocalDB instance "MSSQLLocalDB" stopped.
PS C:\Users\swamy> SqlLocalDB delete MSSQLLocalDB
LocalDB instance "MSSQLLocalDB" deleted.
PS C:\Users\swamy> SqlLocalDB create MSSQLLocalDB
LocalDB instance "MSSQLLocalDB" created with version 15.0.4382.1.
PS C:\Users\swamy> SqlLocalDB start MSSQLLocalDB
LocalDB instance "MSSQLLocalDB" started.
PS C:\Users\swamy>
```
