# Unlock Levelup Recipes

This README explains how to install the required tools, configure the project locally, build the plugin, and deploy it for **Chef Life: A Restaurant Simulator** using **BepInEx 6 IL2CPP** (v6.0.0-be.697-pre.0.2).

Plugin patches `Arrabbiata.PlayerDatabase.Initialize()` to call `PlayerProfile.currentArb.ShowLevelUpItemIds()`, displaying leveled-up recipes in-game.

## Requirements

Before building the plugin, make sure the following tools are installed:

- **Chef Life: A Restaurant Simulator**
- **BepInEx 6 IL2CPP** (pre-0.2): https://github.com/BepInEx/BepInEx/releases/tag/v6.0.0-pre.2
- **.NET 6 SDK**
- **Visual Studio Code**
- The **C# extension for Visual Studio Code** (ms-dotnettools.csdevkit)

## Install BepInEx 6 IL2CPP

Follow the official documentation:

https://docs.bepinex.dev/master/articles/user_guide/installation/unity_il2cpp.html

Install BepInEx into the Chef Life game folder before continuing.

## First game launch

After installing BepInEx, launch the game **once**.

This generates IL2CPP interop assemblies (`BepInEx/interop/`). Do not build before this step.

## Configure the local game path

Copy `Directory.Build.props.example` to `Directory.Build.props` (next to `.csproj`), then edit to fit your installation:

```xml
<Project>
  <PropertyGroup>
    <ChefLifeDir>C:\Program Files (x86)\Steam\steamapps\common\Chef Life A Restaurant Simulator</ChefLifeDir>
  </PropertyGroup>
</Project>
```

**Do not commit** `Directory.Build.props` to source control.

## Open the project in VS Code

1. Open **Visual Studio Code**.
2. Open the plugin project folder.
3. Install/enable **C# Dev Kit** extension.
4. Let VS Code restore the project environment.

## Restore NuGet packages

```powershell
dotnet restore
```

## Build the plugin

```powershell
dotnet build
```

## Automatic deployment

Build automatically copies `UnlockLevelupRecipes.dll` to `<ChefLifeDir>/BepInEx/plugins/`.

Output also in `bin/Debug/net6.0/`.

## Run the game

Launch the game. Plugin loads automatically.

## Verify that the plugin loads

Check `BepInEx/LogOutput.log`:
```log
[Info   :Chef Life Unlock Level up Recipes Plugin] Plugin ChefLife.UnlockLevelupRecipes is loaded
[Info   :Chef Life Unlock Level up Recipes Plugin] Plugin fully initialized
```

## Verify that the plugin patch is correctly applied when launching a save

Check `BepInEx/LogOutput.log`:
```log
[Info   :Chef Life Unlock Level up Recipes Plugin] Called PlayerProfile.ShowLevelUpItemIds() from PlayerDatabase.Initialize
```

## Common problems

### `BepInEx/interop` is missing
**Fix**: Launch game once after BepInEx.

### Build cannot find `Assembly-CSharp.dll`
**Fix**: Check `ChefLifeDir` in `Directory.Build.props`; ensure `interop/Assembly-CSharp.dll` exists.

### Plugin does not load
**Fix**: Rebuild; confirm DLL in `plugins/`; check log errors.

## Typical workflow

1. Edit code in VS Code.
2. `dotnet build`
3. Auto-deploy to `plugins/`.
4. Launch game.
5. Check log.
6. Repeat.

## Bug Reports
If you encounter an issue, please open an issue on the [GitHub repository](https://github.com/hydrastik/chef-life-unlock-levelup-recipes). Include your `BepInEx/LogOutput.log` and a description of what happened.

## License
MIT License.