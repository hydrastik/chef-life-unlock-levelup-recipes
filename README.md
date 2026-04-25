# Unlock Levelup Recipes

**Unlock Levelup Recipes** is a BepInEx plugin for **Chef Life: A Restaurant Simulator**. It automatically displays in-game the recipes you have already leveled up.

## Features
- Unlock recipes that you have aleady leveled up in the recipe book and allow you to cook them.
- Minimal, clean logging.
- Works seamlessly with other mods like UnityExplorer.

## Requirements
- **BepInEx 6.0.0-be.697-pre.0.2** (tested version). Download from [BepInEx GitHub Releases](https://github.com/BepInEx/BepInEx/releases/tag/v6.0.0-pre.2) and follow [IL2CPP installation docs](https://docs.bepinex.dev/master/articles/user_guide/installation/unity_il2cpp.html).
- Chef Life: A Restaurant Simulator.

## Installation
1. Install BepInEx 6 pre-0.2 into the game folder (launch game once to generate `BepInEx/interop`).
2. Download **ChefLife.UnlockLevelupRecipes.dll**.
3. Copy it to `<GameRoot>/BepInEx/plugins/`.
4. Launch the game. 
5. Start your save or a new one. 
6. Leveled up recipes now display in-game!

## Troubleshooting
- Missing interop? Launch game once after BepInEx install.
- Not seing unlocked recipes ? Check `BepInEx/LogOutput.log` for following logs:
```log
[Info   :Chef Life Unlock Level up Recipes Plugin] Plugin ChefLife.UnlockLevelupRecipes is loaded
[Info   :Chef Life Unlock Level up Recipes Plugin] Plugin fully initialized
[Info   :Chef Life Unlock Level up Recipes Plugin] Called PlayerProfile.ShowLevelUpItemIds() from PlayerDatabase.Initialize
```
- No plugin log are present ? Verify DLL presence in `plugins/` and BepInEx version.

## Bug Reports
If you encounter an issue, please open an issue on the [GitHub repository](https://github.com/hydrastik/chef-life-unlock-levelup-recipes). Include your `BepInEx/LogOutput.log` and a description of what happened.

## License
MIT License.
