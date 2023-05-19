using HarmonyLib;
using NeosModLoader;

namespace UnsafeLogix
{
    public class UnsafeLogix : NeosMod
    {
        public override string Name => "UnsafeLogix";
        public override string Author => "APnda";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/ap6661/UnsafeLogix/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.APnda.UnsafeLogix");
            harmony.PatchAll();
        }
		
        [HarmonyPatch(typeof(FrooxEngine.LogiX.LogixHelper), "CanReachOutput")]
        class UnsafeLogixPatch
        {
            public static bool Prefix(ref bool __result)
            {
                __result = false;
                return false;//dont run rest of method
            }
        }
    }
}
