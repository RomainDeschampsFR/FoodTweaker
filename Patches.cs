namespace FoodTweaker
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.ApplyBuffs))]
    internal static class ApplyBuffs
    {
        private static void Postfix(GearItem __instance, float normalizedValue)
        {
            if (__instance.m_FoodItem)
            {
                if (__instance.name.Contains("GEAR_MRE") && Settings.settings.mreHeating)
                {
                    if (Mathf.Abs(__instance.m_FoodItem.m_CaloriesRemaining - __instance.m_FoodItem.m_CaloriesTotal * (1 - normalizedValue)) < 1) // Initial self-heating
                    {
                        if (!__instance.m_FreezingBuff)
                        {
                            __instance.m_FreezingBuff = __instance.gameObject.AddComponent<FreezingBuff>();
                        }
                        __instance.m_FreezingBuff.m_InitialPercentDecrease = Settings.settings.mreInitialWarmthBonus;
                        __instance.m_FreezingBuff.m_RateOfIncreaseScale = 0.5f;
                        __instance.m_FreezingBuff.m_DurationHours = Settings.settings.mreWarmingUpDuration;
                        __instance.m_FoodItem.m_HeatPercent = 100;
                        __instance.m_FoodItem.m_PercentHeatLossPerMinuteIndoors = 1f;
                        __instance.m_FoodItem.m_PercentHeatLossPerMinuteOutdoors = 2f;

                        __instance.m_FreezingBuff.Apply(normalizedValue);
                    }
                }
            }
        }
    }
}
