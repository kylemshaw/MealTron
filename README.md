# MealTron Readme

## Daily Commands

### C# Web API

Change to the API folder: `cd ./Mealtron.API`

Start API dev server: 

```PowerShell
dotnet run
```

Run API dev server with live reload (not always reliable):

```PowerShell
dotnet watch
```

Stop dev server then create new migrations in `./Mealtron.API/Data/Migrations`:

```PowerShell
dotnet ef migrations -h
dotnet ef migrations add <migrationName> -o Data/Migrations
```

Apply migrations to the database:

```PowerShell
dotnet ef database update
```

Delete (sqlite) database for a fresh start:

```PowerShell
dotnet ef database drop
```

### Angular

Change to the angular SPA client folder: `cd ./Mealtron.Client`

Run test server (`ctrl + r` to restart):

```PowerShell
ng serve
```

