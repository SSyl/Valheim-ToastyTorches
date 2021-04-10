using System.Reflection;
using HarmonyLib;
using BepInEx;
using BepInEx.Configuration;

namespace ToastyTorches
{
    [BepInPlugin("SSyl.ToastyTorches", "Toasty Torches", "1.0.0")]
    public class ToastyTorches : BaseUnityPlugin
    {
        public static ConfigEntry<bool> enableMod;
        public static ConfigEntry<bool> torchRemovesCold;
        public static ConfigEntry<bool> torchWetChanges;
        public static ConfigEntry<float> torchWetReduction;
        public static ConfigEntry<int> nexusID;

        private void Awake()
        {
            enableMod = Config.Bind("General", "Enable Mod", true, "Setting this to false disables all features of this mod.");
            torchRemovesCold = Config.Bind("General", "Torch Removes Cold", true, "When set to true it makes the torch remove the cold debuff.");
            torchWetChanges = Config.Bind("General", "Torch Dries Wetness", true, "When set to true it allows the torch to dry you from being wet.\nUse in conjunction with the ");
            torchWetReduction = Config.Bind("General", "Torch Dries Wetness Amount", 4f, "This value sets how fast you'll dry when you have a torch out.\nFor reference, in the Vanilla game, a campfire dries at a value of 10 and burning has a value of 50.");
            nexusID = Config.Bind("General", "NexusID", 971, "Nexus mod ID for update checker. Do not change this value.");

            if (!enableMod.Value)
                return;

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "SSyl.ToastyTorches");
        }
    }
}
