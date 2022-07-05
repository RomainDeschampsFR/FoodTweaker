﻿using HarmonyLib;
using MelonLoader;

namespace FoodTweaker
{
    class PatchCooking
    {
        [HarmonyPatch(typeof(CookingPotItem), "ModifiedCookTimeMinutes")]
        internal class AdjustCookTime
        {
            private static float Postfix(float __result,  CookingPotItem __instance)
            {
                if (Settings.settings.modFunction)
                {
                    if (Settings.settings.meatCookingTime != Choice.Default)
                    {
                        if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatBear")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.bearCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (35 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatDeer")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.deerCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (20 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatMoose")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.mooseCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (25 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatRabbit")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.rabbitCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (28 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawMeatWolf")
                        {
                            if (Settings.settings.meatCookingTime == Choice.Custom) return (Settings.settings.wolfCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (35 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                    }
                    if (Settings.settings.fishCookingTime != Choice.Default)
                    {
                        if (__instance.m_GearItemBeingCooked.name == "GEAR_RawCohoSalmon")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.salmonCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (15 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawLakeWhiteFish")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.whitefishCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (15 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawRainbowTrout")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.troutCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (15 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                        else if (__instance.m_GearItemBeingCooked.name == "GEAR_RawSmallMouthBass")
                        {
                            if (Settings.settings.fishCookingTime == Choice.Custom) return (Settings.settings.bassCookingTime * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                            return (15 * __instance.m_GearItemBeingCooked.m_WeightKG) * (__instance.m_CanOnlyWarmUpFood ? __instance.m_NearFireWarmUpCookingTimeMultiplier : __instance.GetTotalCookMultiplier());
                        }
                    }
                }
                return __result;
            }
        }

        [HarmonyPatch(typeof(CookingPotItem), "SetCookedGearProperties")]
        internal class AdjustCookedMeatAndFish
        {
            private static void Postfix(GearItem rawItem, GearItem cookedItem)
            {
                if (Settings.settings.modFunction)
                {
                    if (rawItem.m_FoodItem.m_IsFish)
                    {
                        cookedItem.m_FoodItem.m_CaloriesRemaining = rawItem.m_FoodItem.m_CaloriesRemaining * GameManager.GetSkillCooking().GetCalorieScale();
                        cookedItem.m_FoodItem.m_CaloriesTotal = rawItem.m_FoodItem.m_CaloriesTotal * GameManager.GetSkillCooking().GetCalorieScale();

                        float salmonCaloriesPerKg = 454.5f;
                        float whitefishCaloriesPerKg = 383.5f;
                        float troutCaloriesPerKg = 383.5f;
                        float bassCaloriesPerKg = 454.5f;

                        if (Settings.settings.caloriesFish == Choice.Realistic)
                        {
                            salmonCaloriesPerKg = 1390;
                            whitefishCaloriesPerKg = 1340;
                            troutCaloriesPerKg = 1500;
                            bassCaloriesPerKg = 1460;
                        }
                        else if (Settings.settings.caloriesFish == Choice.Custom)
                        {
                            salmonCaloriesPerKg = Settings.settings.salmonCooked;
                            whitefishCaloriesPerKg = Settings.settings.whitefishCooked;
                            troutCaloriesPerKg = Settings.settings.troutCooked;
                            bassCaloriesPerKg = Settings.settings.bassCooked;
                        }
                        if (cookedItem.m_GearName == "GEAR_CookedCohoSalmon") cookedItem.m_FoodWeight.m_CaloriesPerKG = salmonCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        if (cookedItem.m_GearName == "GEAR_CookedLakeWhiteFish") cookedItem.m_FoodWeight.m_CaloriesPerKG = whitefishCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        if (cookedItem.m_GearName == "GEAR_CookedRainbowTrout") cookedItem.m_FoodWeight.m_CaloriesPerKG = troutCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();
                        if (cookedItem.m_GearName == "GEAR_CookedSmallMouthBass") cookedItem.m_FoodWeight.m_CaloriesPerKG = bassCaloriesPerKg * GameManager.GetSkillCooking().GetCalorieScale();

                        // Shrinkage
                        float fishShrinkage = 0.66f;

                        if (Settings.settings.fishShrinkage == Choice.Realistic) fishShrinkage = 0.5f;
                        else if (Settings.settings.fishShrinkage == Choice.Custom)
                        {
                            if (cookedItem.m_GearName == "GEAR_CookedCohoSalmon") fishShrinkage = 1 - Settings.settings.salmonShrinks;
                            if (cookedItem.m_GearName == "GEAR_CookedLakeWhiteFish") fishShrinkage = 1 - Settings.settings.whitefishShrinks;
                            if (cookedItem.m_GearName == "GEAR_CookedRainbowTrout") fishShrinkage = 1 - Settings.settings.troutShrinks;
                            if (cookedItem.m_GearName == "GEAR_CookedSmallMouthBass") fishShrinkage = 1 - Settings.settings.bassShrinks;
                        }
                        cookedItem.m_WeightKG = rawItem.m_WeightKG * fishShrinkage;
                    }
                    else if (rawItem.m_FoodItem.m_IsMeat)
                    {
                        float cookedBearCalories = 900;
                        float cookedDeerCalories = 800;
                        float cookedMooseCalories = 900;
                        float cookedRabbitCalories = 450;
                        float cookedWolfCalories = 700;

                        if (Settings.settings.caloriesMeat == Choice.Realistic)
                        {
                            cookedBearCalories = 1630;
                            cookedDeerCalories = 1450;
                            cookedMooseCalories = 1300;
                            cookedRabbitCalories = 1140;
                            cookedWolfCalories = 1165;
                        }
                        else if (Settings.settings.caloriesMeat == Choice.Custom)
                        {
                            cookedBearCalories = Settings.settings.bearCooked;
                            cookedDeerCalories = Settings.settings.deerCooked;
                            cookedMooseCalories = Settings.settings.mooseCooked;
                            cookedRabbitCalories = Settings.settings.rabbitCooked;
                            cookedWolfCalories = Settings.settings.wolfCooked;
                        }

                        // Shrinkage
                        float bearShrinkage = 1f;
                        float deerShrinkage = 1f;
                        float mooseShrinkage = 1f;
                        float rabbitShrinkage = 1f;
                        float wolfShrinkage = 1f;

                        if (Settings.settings.meatShrinkage == Choice.Realistic)
                        {
                            bearShrinkage = 0.75f;
                            deerShrinkage = 0.75f;
                            mooseShrinkage = 0.75f;
                            rabbitShrinkage = 0.75f;
                            wolfShrinkage = 0.75f;
                        }
                        else if (Settings.settings.meatShrinkage == Choice.Custom)
                        {
                            bearShrinkage = 1 - Settings.settings.bearShrinks;
                            deerShrinkage = 1 - Settings.settings.deerShrinks;
                            mooseShrinkage = 1 - Settings.settings.mooseShrinks;
                            rabbitShrinkage = 1 - Settings.settings.rabbitShrinks;
                            wolfShrinkage = 1 - Settings.settings.wolfShrinks;
                        }

                        if (Settings.settings.caloriesMeat == Choice.Default && Settings.settings.meatShrinkage != Choice.Default)
                        {
                            cookedBearCalories = 900 / bearShrinkage;
                            cookedDeerCalories = 800 / deerShrinkage;
                            cookedMooseCalories = 900 / mooseShrinkage;
                            cookedRabbitCalories = 450 / rabbitShrinkage;
                            cookedWolfCalories = 700 / wolfShrinkage;
                        }

                        if (cookedItem.m_GearName == "GEAR_CookedMeatBear")
                        {
                            cookedItem.m_WeightKG = rawItem.m_WeightKG * bearShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItem.m_WeightKG * cookedBearCalories * GameManager.GetSkillCooking().GetCalorieScale();
                            cookedItem.m_FoodItem.m_CaloriesTotal = cookedItem.m_FoodItem.m_CaloriesRemaining;
                        }
                        else if (cookedItem.m_GearName == "GEAR_CookedMeatDeer")
                        {
                            cookedItem.m_WeightKG = rawItem.m_WeightKG * deerShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItem.m_WeightKG * cookedDeerCalories * GameManager.GetSkillCooking().GetCalorieScale();
                            cookedItem.m_FoodItem.m_CaloriesTotal = cookedItem.m_FoodItem.m_CaloriesRemaining / cookedItem.m_WeightKG;
                        }
                        else if (cookedItem.m_GearName == "GEAR_CookedMeatMoose")
                        {
                            cookedItem.m_WeightKG = rawItem.m_WeightKG * mooseShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItem.m_WeightKG * cookedMooseCalories * GameManager.GetSkillCooking().GetCalorieScale();
                            cookedItem.m_FoodItem.m_CaloriesTotal = cookedItem.m_FoodItem.m_CaloriesRemaining;
                        }
                        else if (cookedItem.m_GearName == "GEAR_CookedMeatRabbit")
                        {
                            cookedItem.m_WeightKG = rawItem.m_WeightKG * rabbitShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItem.m_WeightKG * cookedRabbitCalories * GameManager.GetSkillCooking().GetCalorieScale();
                            cookedItem.m_FoodItem.m_CaloriesTotal = cookedItem.m_FoodItem.m_CaloriesRemaining;
                        }
                        else if (cookedItem.m_GearName == "GEAR_CookedMeatWolf")
                        {
                            cookedItem.m_WeightKG = rawItem.m_WeightKG * wolfShrinkage;
                            cookedItem.m_FoodItem.m_CaloriesRemaining = cookedItem.m_WeightKG * cookedWolfCalories * GameManager.GetSkillCooking().GetCalorieScale();
                            cookedItem.m_FoodItem.m_CaloriesTotal = cookedItem.m_FoodItem.m_CaloriesRemaining;
                        }
                    }
                }
            }
        }
    }
}