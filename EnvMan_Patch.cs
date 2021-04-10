using HarmonyLib;

namespace ToastyTorches
{
    [HarmonyPatch(typeof(EnvMan), "IsCold")]
    class EnvMan_Patch
    {
        public static bool Postfix(bool __result)
        {
            if (!ToastyTorches.torchRemovesCold.Value)
                return __result;

            Player player = Player.m_localPlayer;

            if(player != null && !player.IsDead())
            {
                if ((player.GetRightItem() != null && player.GetRightItem().m_shared.m_name == "$item_torch") || (player.GetLeftItem() != null && player.GetLeftItem().m_shared.m_name == "$item_torch"))
                {
                    __result = false;
                    return __result;
                }
            }
            return __result;
        }
    }
}
