using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace ChefLife.UnlockLevelupRecipes
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        internal static new ManualLogSource Log;

        public override void Load()
        {
            Log = base.Log;
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded");
            new Harmony(MyPluginInfo.PLUGIN_GUID).PatchAll();
            Log.LogInfo("Plugin fully initialized");
        }
    }

    [HarmonyPatch(typeof(Arrabbiata.PlayerDatabase), "Initialize")]
    internal static class PlayerDatabaseInitializePatch
    {
        [HarmonyPostfix]
        static void Postfix()
        {
            var instance = Arrabbiata.PlayerProfile.currentArb;
            if (instance == null) return;
            instance.ShowLevelUpItemIds();
            Plugin.Log.LogInfo("Called PlayerProfile.ShowLevelUpItemIds() from PlayerDatabase.Initialize");
        }
    }
}