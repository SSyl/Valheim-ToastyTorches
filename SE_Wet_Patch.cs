using HarmonyLib;

namespace ToastyTorches
{
    [HarmonyPatch(typeof(SE_Wet), "UpdateStatusEffect")]
    class SE_Wet_Patch
    {
        public static void Postfix(float dt, ref float ___m_time, ref Character ___m_character)
        {
            if (!ToastyTorches.torchWetChanges.Value)
                return;

            if (___m_character.IsPlayer() && ___m_character as Player && ___m_character.GetSEMan().HaveStatusEffect("Wet"))
            {
                Player player = ___m_character as Player;
                if ((player.GetRightItem() != null && player.GetRightItem().m_shared.m_name == "$item_torch") || (player.GetLeftItem() != null && player.GetLeftItem().m_shared.m_name == "$item_torch"))
                {
                    ___m_time += dt * ToastyTorches.torchWetReduction.Value;
                }
            }
        }
    }
}
