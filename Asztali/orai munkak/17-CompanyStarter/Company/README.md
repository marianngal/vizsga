# Workflow
## Visual Studio 2022

- `Create a new project`
- Select `WPF application`
- Fill the `[project name]`
- Select Framework `.NET 8.0 (LTS)`

## Csomagok telepítés grafikusan
- `Tools` menüpont
- `NuGet Package Manager` 
- `Manage NuGet Packages for solution...`
- `Browse` tab

	- MySql.EntityFrameworkCore 8.0.20
	- Microsoft.EntityFrameworkCore.Tools 8.0.20
	- CommunityToolkit.Mvvm 8.4.0

## Csomagok telepítése parancssorról

- `Tools`
- `NuGet Package Manager`
- `Package Manager Console`

	```
	Install-Package -Version 8.0.20 MySql.EntityFrameworkCore
	Install-Package -Version 8.0.20 Microsoft.EntityFrameworkCore.Tools
	Install-Package -Version 8.4.0 CommunityToolkit.Mvvm
	```

## Adatbázis leképezése

- `Package Manager Console`

	```
	Scaffold-DbContext "server=localhost;database=[NAME];user=[USER];password=[PASSWORD]" -Provider MySql.EntityFrameworkCore -OutputDir Models -ContextDir Context -Tables [TABLE_1], [TABLE_2], ..., [TABLE_N]
	```

## CRUD műveletek megvalósítása

- Create Services folder
- Create IDatabaseService interface
- Create DatabaseSerbivce class
- Implement the interface

## Prezentációs réteg

- Create ViewModels folder
- Create MainViewModel class
- Make it partial
- Inherit from ObservableObject
- Add an ObservableCollection field
- Annotate with [ObservableProperty]
- Add an Selected Entity field
- Annotate with [ObservableProperty]
- Add an IDatabaseService field
- Inject the dependency through the constructor

## Ablak

- Add the clr-namespace ViewModels
- Set the Window.DataContext
- Build the project