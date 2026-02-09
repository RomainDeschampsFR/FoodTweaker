using Il2CppTLD.Cooking;
using Il2CppTLD.Gameplay;
using Il2CppTLD.IntBackedUnit;

namespace FoodTweaker
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName.Contains("MainMenu"))
            {
                ChangePrefabs();
            }

        }

        public static GearItem GetGearItemPrefab(string name) => GearItem.LoadGearItemPrefab(name).GetComponent<GearItem>();

        public static void UpdateGearItemPrefab(string name, int calories, int hydration, int vitamin, bool warmingBuff = false)
        {
            GearItem gearItem = GetGearItemPrefab(name);
            if (gearItem == null)
            {
                MelonLogger.Msg(name + " GearItem Prefab is NULL!");
                return;
            }
            FoodItem foodItem = gearItem.GetComponent<FoodItem>();
            if (foodItem == null)
            {
                MelonLogger.Msg(name + " FoodItem Prefab is NULL!");
                return;
            }
            if (warmingBuff)
            {
                foodItem.m_HeatedWhenCooked = true;
                foodItem.m_PercentHeatLossPerMinuteIndoors = 1f;
                foodItem.m_PercentHeatLossPerMinuteOutdoors = 2f;
                foodItem.m_HeatPercent = 0;

                if (!gearItem.m_FreezingBuff)
                {
                    gearItem.m_FreezingBuff = gearItem.gameObject.AddComponent<FreezingBuff>();
                }
                gearItem.m_FreezingBuff.m_InitialPercentDecrease = Settings.settings.initialWarmthBonus;
                gearItem.m_FreezingBuff.m_RateOfIncreaseScale = 0.5f;
                gearItem.m_FreezingBuff.m_DurationHours = Settings.settings.warmingUpDuration;
            }

            //if (foodItem.m_Nutrients != null && foodItem.m_Nutrients.Count > 0 && foodItem.m_Nutrients[0] != null) MelonLogger.Msg(name + " -- Vitamin C : " + foodItem.m_Nutrients[0].m_Amount);
            //MelonLogger.Msg(name + " -- Calories_Remaining : " + foodItem.m_CaloriesRemaining);
            //MelonLogger.Msg(name + " -- Calories_Total : " + foodItem.m_CaloriesTotal);
            //MelonLogger.Msg(name + " -- Hydration : " + foodItem.m_ReduceThirst);


            if (gearItem.name == "GEAR_CuredMeat" || gearItem.name == "GEAR_CuredFish" || gearItem.name == "GEAR_AnimalFat")
            {
                foodItem.m_CaloriesRemaining = (float)calories;
                foodItem.m_CaloriesTotal = (float)calories;
            }
            else if (foodItem.m_IsMeat)
            {
                if (gearItem.m_FoodWeight == null) gearItem.m_FoodWeight = gearItem.gameObject.AddComponent<FoodWeight>();
                if (foodItem.m_IsRawMeat)
                {
                    gearItem.m_FoodWeight.m_MaxWeight = ItemWeight.FromKilograms(1f);
                    gearItem.m_FoodWeight.m_MinWeight = ItemWeight.FromKilograms(1f);
                    //gearItem.m_FoodWeight.m_CaloriesPerKG = (float)calories; --- Enable  if you add calorie tweaking for raw meat in the settings
                }
                else
                {
                    float shrinkage = Settings.settings.meatShrinkage / 100f;
                    gearItem.m_FoodWeight.m_MaxWeight = ItemWeight.FromKilograms(1f - shrinkage);
                    gearItem.m_FoodWeight.m_MinWeight = ItemWeight.FromKilograms(1f - shrinkage);
                    gearItem.m_FoodWeight.m_CaloriesPerKG = (float)calories;
                }
            }
            else if(foodItem.m_IsFish)
            {

                if (foodItem.m_IsRawMeat)
                {
                    //gearItem.m_FoodWeight.m_MaxWeight = ItemWeight.FromKilograms()); --- Enable and configure settings if you want to tweaked the min weight for catched fish
                    //gearItem.m_FoodWeight.m_MinWeight = ItemWeight.FromKilograms()); --- Enable and configure settings if you want to tweaked the min weight for catched fish
                    //gearItem.m_FoodWeight.m_CaloriesPerKG = (float)calories; --- Enable if you add calorie tweaking for raw fish in the settings
                }
                else
                {
                    float shrinkage = Settings.settings.fishShrinkage / 100f;
                    string rawName = name.Replace("Cooked", "Raw");
                    GearItem gearItemRaw = GetGearItemPrefab(rawName);
                    if (gearItemRaw == null)
                    {
                        MelonLogger.Msg(name + " FishItemRaw Prefab is NULL!");
                        return;
                    }
                    float maxWeight = gearItemRaw.m_FoodWeight.m_MaxWeight.ToQuantity(1);
                    float minWeight = gearItemRaw.m_FoodWeight.m_MinWeight.ToQuantity(1);

                    gearItem.m_FoodWeight.m_MaxWeight = ItemWeight.FromKilograms(maxWeight - (maxWeight * shrinkage));
                    gearItem.m_FoodWeight.m_MinWeight = ItemWeight.FromKilograms(minWeight - (minWeight * shrinkage));
                    gearItem.m_FoodWeight.m_CaloriesPerKG = (float)calories;
                }
            }
            else
            {
                foodItem.m_CaloriesRemaining = (float)calories;
                foodItem.m_CaloriesTotal = (float)calories;
            }

            foodItem.m_ReduceThirst = (float)hydration;

            if (foodItem.m_Nutrients != null && foodItem.m_Nutrients.Count > 0 && foodItem.m_Nutrients[0] != null)
            {
                foodItem.m_Nutrients[0].m_Amount = vitamin;
            }
            else
            {
                foodItem.m_Nutrients.Add(new FoodItem.Nutrient { m_Amount = vitamin, m_Nutrient = new AssetReferenceNutrientDefinition("13a8bda1e12982e428b7551cc01b01df") });
            }
        }

        public static void UpdateCookable(string name, int cookingOrWarmingTime, int preppingTime = 0)
        {
            GearItem gearItem = GetGearItemPrefab(name);
            if (gearItem == null)
            {
                MelonLogger.Msg(name + " GearItem Prefab is NULL!");
                return;
            }
            Cookable cookable = gearItem.GetComponent<Cookable>();
            if (cookable == null)
            {
                MelonLogger.Msg(name + " Cookable Prefab is NULL!");
                return;
            }

            //MelonLogger.Msg(name + " --- CookOrWarmTime : " + cookable.m_CookTimeMinutes);
            cookable.m_CookTimeMinutes = (float)cookingOrWarmingTime;

            FoodItem foodItem = gearItem.GetComponent<FoodItem>();
            if (foodItem != null)
            {
                if (foodItem.m_IsFish)
                {
                    FoodWeight foodWeight = gearItem.GetComponent<FoodWeight>();
                    cookable.m_CookTimeMinutes = cookingOrWarmingTime * foodWeight.m_MaxWeight.ToQuantity(1);
                }
            }

            if (preppingTime != 0)
            {
                if (name.Contains("GEAR_Uncooked"))
                {
                    Il2CppSystem.Collections.Generic.List<RecipeData> recipeList = GameObject.Find("SCRIPT_PlayerSystems").GetComponent<RecipeBook>().AllRecipes;
                    if (recipeList != null)
                    {
                        foreach (var recipe in recipeList)
                        {
                            if (name == recipe.m_DishBlueprint.m_CraftedResultGear.name)
                            {
                                //MelonLogger.Msg(name + " --- PrepTime : " + recipe.m_DishBlueprint.m_DurationMinutes);
                                recipe.m_DishBlueprint.m_DurationMinutes = preppingTime;
                            }
                        }
                    }
                }
            }
        }

        public static void UpdateCookingPotItemPrefab(string name, float multiplier)
        {
            GearItem gearItem = GetGearItemPrefab(name);
            if (gearItem == null)
            {
                MelonLogger.Msg(name + " GearItem Prefab is NULL!");
                return;
            }
            CookingPotItem cookingPot = gearItem.GetComponent<CookingPotItem>();
            if (cookingPot == null)
            {
                MelonLogger.Msg(name + " CookingPotItem Prefab is NULL!");
                return;
            }
            cookingPot.m_BoilingTimeMultiplier = multiplier;
            cookingPot.m_CookingTimeMultiplier = multiplier;
        }

        internal static void ChangePrefabs()
        {
            //MEAT COOKED
            UpdateGearItemPrefab("GEAR_CookedMeatBear", Settings.settings.bearCooked, Settings.settings.bearCookedHydro, Settings.settings.bearCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedMeatDeer", Settings.settings.deerCooked, Settings.settings.deerCookedHydro, Settings.settings.deerCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedMeatMoose", Settings.settings.mooseCooked, Settings.settings.mooseCookedHydro, Settings.settings.mooseCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedMeatPtarmigan", Settings.settings.ptarmiganCooked, Settings.settings.ptarmiganCookedHydro, Settings.settings.ptarmiganCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedMeatRabbit", Settings.settings.rabbitCooked, Settings.settings.rabbitCookedHydro, Settings.settings.rabbitCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedMeatWolf", Settings.settings.wolfCooked, Settings.settings.wolfCookedHydro, Settings.settings.wolfCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedMeatCougar", Settings.settings.cougarCooked, Settings.settings.cougarCookedHydro, Settings.settings.cougarCookedVit, Settings.settings.allItemHeating);
            //FISH COOKED 
            UpdateGearItemPrefab("GEAR_CookedCohoSalmon", Settings.settings.salmonCooked, Settings.settings.salmonCookedHydro, Settings.settings.salmonCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedLakeWhiteFish", Settings.settings.whitefishCooked, Settings.settings.whitefishCookedHydro, Settings.settings.whitefishCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedRainbowTrout", Settings.settings.troutCooked, Settings.settings.troutCookedHydro, Settings.settings.troutCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedSmallMouthBass", Settings.settings.bassCooked, Settings.settings.bassCookedHydro, Settings.settings.bassCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedBurbot", Settings.settings.burbotCooked, Settings.settings.burbotCookedHydro, Settings.settings.burbotCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedGoldeye", Settings.settings.goldeyeCooked, Settings.settings.goldeyeCookedHydro, Settings.settings.goldeyeCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedRedIrishLord", Settings.settings.redIrishLordCooked, Settings.settings.redIrishLordCookedHydro, Settings.settings.redIrishLordCookedVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedRockfish", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit, Settings.settings.allItemHeating);
            //DRINKS
            UpdateGearItemPrefab("GEAR_AcornCoffeeCup", Settings.settings.acornCoffee, Settings.settings.acornCoffeeHydro, Settings.settings.acornCoffeeVit);
            UpdateGearItemPrefab("GEAR_BirchbarkTea", Settings.settings.birchbarkTea, Settings.settings.birchbarkTeaHydro, Settings.settings.birchbarkTeaVit);
            UpdateGearItemPrefab("GEAR_BurdockTea", Settings.settings.burdockTea, Settings.settings.burdockTeaHydro, Settings.settings.burdockTeaVit);
            UpdateGearItemPrefab("GEAR_CoffeeCup", Settings.settings.coffee, Settings.settings.coffeeHydro, Settings.settings.coffeeVit);
            UpdateGearItemPrefab("GEAR_GreenTeaCup", Settings.settings.herbalTea, Settings.settings.herbalTeaHydro, Settings.settings.herbalTeaVit);
            UpdateGearItemPrefab("GEAR_SodaOrange", Settings.settings.orangeSoda, Settings.settings.orangeSodaHydro, Settings.settings.orangeSodaVit);
            UpdateGearItemPrefab("GEAR_SodaEnergy", Settings.settings.goEnergyDrink, Settings.settings.goEnergyDrinkHydro, Settings.settings.goEnergyDrinkVit);
            UpdateGearItemPrefab("GEAR_ReishiTea", Settings.settings.reishiTea, Settings.settings.reishiTeaHydro, Settings.settings.reishiTeaVit);
            UpdateGearItemPrefab("GEAR_RoseHipTea", Settings.settings.roseHipTea, Settings.settings.roseHipTeaHydro, Settings.settings.roseHipTeaVit);
            UpdateGearItemPrefab("GEAR_SodaGrape", Settings.settings.grapeSoda, Settings.settings.grapeSodaHydro, Settings.settings.grapeSodaVit);
            UpdateGearItemPrefab("GEAR_Soda", Settings.settings.summitSoda, Settings.settings.summitSodaHydro, Settings.settings.summitSodaVit);
            //OTHER FOOD
            UpdateGearItemPrefab("GEAR_AcornCooked", Settings.settings.acorn, Settings.settings.acornHydro, Settings.settings.acornVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_AcornCookedBig", Settings.settings.acornBig, Settings.settings.acornBigHydro, Settings.settings.acornBigVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_AirlineFoodChick", Settings.settings.airlineChicken, Settings.settings.airlineChickenHydro, Settings.settings.airlineChickenVit);
            UpdateGearItemPrefab("GEAR_AirlineFoodVeg", Settings.settings.airlineVegetarian, Settings.settings.airlineVegetarianHydro, Settings.settings.airlineVegetarianVit);
            UpdateGearItemPrefab("GEAR_BeefJerky", Settings.settings.beefJerky, Settings.settings.beefJerkyHydro, Settings.settings.beefJerkyVit);
            UpdateGearItemPrefab("GEAR_BurdockPrepared", Settings.settings.burdockPrepared, Settings.settings.burdockPreparedHydro, Settings.settings.burdockPreparedVit);
            UpdateGearItemPrefab("GEAR_CandyBar", Settings.settings.chocolateBar, Settings.settings.chocolateBarHydro, Settings.settings.chocolateBarVit);
            UpdateGearItemPrefab("GEAR_CattailStalk", Settings.settings.cattailStalk, Settings.settings.cattailStalkHydro, Settings.settings.cattailStalkVit);
            UpdateGearItemPrefab("GEAR_CondensedMilk", Settings.settings.condensedMilk, Settings.settings.condensedMilkHydro, Settings.settings.condensedMilkVit);
            UpdateGearItemPrefab("GEAR_DogFood", Settings.settings.dogFood, Settings.settings.dogFoodHydro, Settings.settings.dogFoodVit);
            UpdateGearItemPrefab("GEAR_EnergyBar", Settings.settings.energyBar, Settings.settings.energyBarHydro, Settings.settings.energyBarVit);
            UpdateGearItemPrefab("GEAR_GranolaBar", Settings.settings.granolaBar, Settings.settings.granolaBarHydro, Settings.settings.granolaBarVit);
            UpdateGearItemPrefab("GEAR_KetchupChips", Settings.settings.ketchupChips, Settings.settings.ketchupChipsHydro, Settings.settings.ketchupChipsVit);
            UpdateGearItemPrefab("GEAR_MapleSyrup", Settings.settings.mapleSyrup, Settings.settings.mapleSyrupHydro, Settings.settings.mapleSyrupVit);
            UpdateGearItemPrefab("GEAR_MRE", Settings.settings.mre, Settings.settings.mreHydro, Settings.settings.mreVit);
            UpdateGearItemPrefab("GEAR_PeanutButter", Settings.settings.peanutButter, Settings.settings.peanutButterHydro, Settings.settings.peanutButterVit);
            UpdateGearItemPrefab("GEAR_PinnacleCanPeaches", Settings.settings.pinnaclePeaches, Settings.settings.pinnaclePeachesHydro, Settings.settings.pinnaclePeachesVit);
            UpdateGearItemPrefab("GEAR_CannedBeans", Settings.settings.porkAndBeans, Settings.settings.porkAndBeansHydro, Settings.settings.porkAndBeansVit);
            UpdateGearItemPrefab("GEAR_Crackers", Settings.settings.saltyCrackers, Settings.settings.saltyCrackersHydro, Settings.settings.saltyCrackersVit);
            UpdateGearItemPrefab("GEAR_CannedSardines", Settings.settings.sardines, Settings.settings.sardinesHydro, Settings.settings.sardinesVit);
            UpdateGearItemPrefab("GEAR_TomatoSoupCan", Settings.settings.tomatoSoup, Settings.settings.tomatoSoupHydro, Settings.settings.tomatoSoupVit);
            UpdateGearItemPrefab("GEAR_CannedCorn", Settings.settings.cannedCorn, Settings.settings.cannedCornHydro, Settings.settings.cannedCornVit);
            UpdateGearItemPrefab("GEAR_CannedHam", Settings.settings.cannedHam, Settings.settings.cannedHamHydro, Settings.settings.cannedHamVit);
            UpdateGearItemPrefab("GEAR_Carrot", Settings.settings.carrot, Settings.settings.carrotHydro, Settings.settings.carrotVit);
            UpdateGearItemPrefab("GEAR_PotatoCooked", Settings.settings.potatoCooked, Settings.settings.potatoCookedHydro, Settings.settings.potatoCookedVit);
            UpdateGearItemPrefab("GEAR_AnimalFat", Settings.settings.animalFat, Settings.settings.animalFatHydro, Settings.settings.animalFatVit);
            UpdateGearItemPrefab("GEAR_CannedPineapple", Settings.settings.cannedPineapple, Settings.settings.cannedPineappleHydro, Settings.settings.cannedPineappleVit);
            UpdateGearItemPrefab("GEAR_Cereal_A", Settings.settings.cereal, Settings.settings.cerealHydro, Settings.settings.cerealVit);
            UpdateGearItemPrefab("GEAR_CuredMeat", Settings.settings.curedMeat, Settings.settings.curedMeatHydro, Settings.settings.curedMeatVit);
            UpdateGearItemPrefab("GEAR_CuredFish", Settings.settings.curedFish, Settings.settings.curedFishHydro, Settings.settings.curedFishVit);
            UpdateGearItemPrefab("GEAR_DriedApples", Settings.settings.driedApples, Settings.settings.driedApplesHydro, Settings.settings.driedApplesVit);
            UpdateGearItemPrefab("GEAR_Pickles", Settings.settings.pickles, Settings.settings.picklesHydro, Settings.settings.picklesVit);
            //RECIPE
            UpdateGearItemPrefab("GEAR_CookedBannockAcorn", Settings.settings.acornBannock, Settings.settings.acornBannockHydro, Settings.settings.acornBannockVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPancakeAcorn", Settings.settings.acornPancake, Settings.settings.acornPancakeHydro, Settings.settings.acornPancakeVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedBannock", Settings.settings.bannock, Settings.settings.bannockHydro, Settings.settings.bannockVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPieMeat", Settings.settings.meatPie, Settings.settings.meatPieHydro, Settings.settings.meatPieVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_Broth", Settings.settings.broth, Settings.settings.brothHydro, Settings.settings.brothVit);
            UpdateGearItemPrefab("GEAR_CookedPorridgeFruit", Settings.settings.fruitPorridge, Settings.settings.fruitPorridgeHydro, Settings.settings.fruitPorridgeVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedFishcakes", Settings.settings.fishcakes, Settings.settings.fishcakesHydro, Settings.settings.fishcakesVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPieFishermans", Settings.settings.fishermansPie, Settings.settings.fishermansPieHydro, Settings.settings.fishermansPieVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPancakePeach", Settings.settings.peachPancake, Settings.settings.peachPancakeHydro, Settings.settings.peachPancakeVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPancake", Settings.settings.pancake, Settings.settings.pancakeHydro, Settings.settings.pancakeVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPiePeach", Settings.settings.peachFruitPie, Settings.settings.peachFruitPieHydro, Settings.settings.peachFruitPieVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPorridge", Settings.settings.porridge, Settings.settings.porridgeHydro, Settings.settings.porridgeVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPiePtarmigan", Settings.settings.ptarmiganMeatPie, Settings.settings.ptarmiganMeatPieHydro, Settings.settings.ptarmiganMeatPieVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedStewPtarmigan", Settings.settings.ptarmiganMeatStew, Settings.settings.ptarmiganMeatStewHydro, Settings.settings.ptarmiganMeatStewVit);
            UpdateGearItemPrefab("GEAR_CookedPieForagers", Settings.settings.cookedPieForagers, Settings.settings.cookedPieForagersHydro, Settings.settings.cookedPieForagersVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPieRabbit", Settings.settings.rabbitMeatPie, Settings.settings.rabbitMeatPieHydro, Settings.settings.rabbitMeatPieVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedStewRabbit", Settings.settings.rabbitMeatStew, Settings.settings.rabbitMeatStewHydro, Settings.settings.rabbitMeatStewVit);
            UpdateGearItemPrefab("GEAR_CookedStewMeat", Settings.settings.meatStew, Settings.settings.meatStewHydro, Settings.settings.meatStewVit);
            UpdateGearItemPrefab("GEAR_CookedPieRoseHip", Settings.settings.roseHipFruitPie, Settings.settings.roseHipFruitPieHydro, Settings.settings.roseHipFruitPieVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedPiePredator", Settings.settings.predatorPie, Settings.settings.predatorPieHydro, Settings.settings.predatorPieVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedStewVegetables", Settings.settings.vegetableStew, Settings.settings.vegetableStewHydro, Settings.settings.vegetableStewVit);
            UpdateGearItemPrefab("GEAR_CookedStewTrout", Settings.settings.troutMeatStew, Settings.settings.troutMeatStewHydro, Settings.settings.troutMeatStewVit);
            UpdateGearItemPrefab("GEAR_CookedPieVenison", Settings.settings.venisonMeatPie, Settings.settings.venisonMeatPieHydro, Settings.settings.venisonMeatPieVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedStewVenison", Settings.settings.venisonStew, Settings.settings.venisonStewHydro, Settings.settings.venisonStewVit);
            UpdateGearItemPrefab("GEAR_CookedBarPemmican", Settings.settings.pemmicanBar, Settings.settings.pemmicanBarHydro, Settings.settings.pemmicanBarVit, Settings.settings.allItemHeating);
            UpdateGearItemPrefab("GEAR_CookedSoupPotato", Settings.settings.soupPotato, Settings.settings.soupPotatoHydro, Settings.settings.soupPotatoVit);
            UpdateGearItemPrefab("GEAR_CookedSoupPtarmigan", Settings.settings.soupPtarmigan, Settings.settings.soupPtarmiganHydro, Settings.settings.soupPtarmiganVit);
            UpdateGearItemPrefab("GEAR_CookedSoupRabbit", Settings.settings.soupRabbit, Settings.settings.soupRabbitHydro, Settings.settings.soupRabbitVit);

            //COOKING TIMES (& PREPPING TIME FOR RECIPES)
            //MEAT RAW
            UpdateCookable("GEAR_RawMeatBear", Settings.settings.bearCookedTime);
            UpdateCookable("GEAR_RawMeatDeer", Settings.settings.deerCookedTime);
            UpdateCookable("GEAR_RawMeatMoose", Settings.settings.mooseCookedTime);
            UpdateCookable("GEAR_RawMeatPtarmigan", Settings.settings.ptarmiganCookedTime);
            UpdateCookable("GEAR_RawMeatRabbit", Settings.settings.rabbitCookedTime);
            UpdateCookable("GEAR_RawMeatWolf", Settings.settings.wolfCookedTime);
            UpdateCookable("GEAR_RawMeatCougar", Settings.settings.cougarCookedTime);
            //FISH RAW
            UpdateCookable("GEAR_RawCohoSalmon", Settings.settings.salmonCookedTime);
            UpdateCookable("GEAR_RawLakeWhiteFish", Settings.settings.whitefishCookedTime);
            UpdateCookable("GEAR_RawRainbowTrout", Settings.settings.troutCookedTime);
            UpdateCookable("GEAR_RawSmallMouthBass", Settings.settings.bassCookedTime);
            UpdateCookable("GEAR_RawBurbot", Settings.settings.burbotCookedTime);
            UpdateCookable("GEAR_RawGoldeye", Settings.settings.goldeyeCookedTime);
            UpdateCookable("GEAR_RawRedIrishLord", Settings.settings.redIrishLordCookedTime);
            UpdateCookable("GEAR_RawRockfish", Settings.settings.rockfishCookedTime);
            //RECIPE
            UpdateCookable("GEAR_UncookedBannockAcorn", Settings.settings.acornBannockTime, Settings.settings.acornBannockPrepTime);
            UpdateCookable("GEAR_UncookedPancakeAcorn", Settings.settings.acornPancakeTime, Settings.settings.acornPancakePrepTime);
            UpdateCookable("GEAR_UncookedBannock", Settings.settings.bannockTime, Settings.settings.bannockPrepTime);
            UpdateCookable("GEAR_UncookedPieMeat", Settings.settings.meatPieTime, Settings.settings.meatPiePrepTime);
            UpdateCookable("GEAR_UncookedBroth", Settings.settings.brothTime, Settings.settings.brothPrepTime);
            UpdateCookable("GEAR_UncookedPorridgeFruit", Settings.settings.fruitPorridgeTime, Settings.settings.fruitPorridgePrepTime);
            UpdateCookable("GEAR_UncookedFishcakes", Settings.settings.fishcakesTime, Settings.settings.fishcakesPrepTime);
            UpdateCookable("GEAR_UncookedPieFishermans", Settings.settings.fishermansPieTime, Settings.settings.fishermansPiePrepTime);
            UpdateCookable("GEAR_UncookedPancakePeach", Settings.settings.peachPancakeTime, Settings.settings.peachPancakePrepTime);
            UpdateCookable("GEAR_UncookedPancake", Settings.settings.pancakeTime, Settings.settings.pancakePrepTime);
            UpdateCookable("GEAR_UncookedPiePeach", Settings.settings.peachFruitPieTime, Settings.settings.peachFruitPiePrepTime);
            UpdateCookable("GEAR_UncookedPorridge", Settings.settings.porridgeTime, Settings.settings.porridgePrepTime);
            UpdateCookable("GEAR_UncookedPiePtarmigan", Settings.settings.ptarmiganMeatPieTime, Settings.settings.ptarmiganMeatPiePrepTime);
            UpdateCookable("GEAR_UncookedStewPtarmigan", Settings.settings.ptarmiganMeatStewTime, Settings.settings.ptarmiganMeatStewPrepTime);
            UpdateCookable("GEAR_UncookedPieForagers", Settings.settings.cookedPieForagersTime, Settings.settings.cookedPieForagersPrepTime);
            UpdateCookable("GEAR_UncookedPieRabbit", Settings.settings.rabbitMeatPieTime, Settings.settings.rabbitMeatPiePrepTime);
            UpdateCookable("GEAR_UncookedStewRabbit", Settings.settings.rabbitMeatStewTime, Settings.settings.rabbitMeatStewPrepTime);
            UpdateCookable("GEAR_UncookedStewMeat", Settings.settings.meatStewTime, Settings.settings.meatStewPrepTime);
            UpdateCookable("GEAR_UncookedPieRoseHip", Settings.settings.roseHipFruitPieTime, Settings.settings.roseHipFruitPiePrepTime);
            UpdateCookable("GEAR_UncookedPiePredator", Settings.settings.predatorPieTime, Settings.settings.predatorPiePrepTime);
            UpdateCookable("GEAR_UncookedStewVegetables", Settings.settings.vegetableStewTime, Settings.settings.vegetableStewPrepTime);
            UpdateCookable("GEAR_UncookedStewTrout", Settings.settings.troutMeatStewTime, Settings.settings.troutMeatStewPrepTime);
            UpdateCookable("GEAR_UncookedPieVenison", Settings.settings.venisonMeatPieTime, Settings.settings.venisonMeatPiePrepTime);
            UpdateCookable("GEAR_UncookedStewVenison", Settings.settings.venisonStewTime, Settings.settings.venisonStewPrepTime);
            UpdateCookable("GEAR_UncookedBarPemmican", Settings.settings.pemmicanBarTime, Settings.settings.pemmicanBarPrepTime);
            UpdateCookable("GEAR_UncookedSoupPotato", Settings.settings.soupPotatoTime, Settings.settings.soupPotatoPrepTime);
            UpdateCookable("GEAR_UncookedSoupPtarmigan", Settings.settings.soupPtarmiganTime, Settings.settings.soupPtarmiganPrepTime);
            UpdateCookable("GEAR_UncookedSoupRabbit", Settings.settings.soupRabbitTime, Settings.settings.soupRabbitPrepTime);
            UpdateCookable("GEAR_UncookedOil", Settings.settings.oilTime, Settings.settings.oilPrepTime);
            //OTHER FOOD
            UpdateCookable("GEAR_Potato", Settings.settings.potatoCookedTime);
            UpdateCookable("GEAR_AcornShelled", Settings.settings.acornTime);
            UpdateCookable("GEAR_AcornShelledBig", Settings.settings.acornBigTime);
            //DRINKS
            UpdateCookable("GEAR_BurdockPrepared", Settings.settings.burdockTeaTime);
            UpdateCookable("GEAR_BirchbarkPrepared", Settings.settings.birchbarkTeaTime);
            UpdateCookable("GEAR_ReishiPrepared", Settings.settings.reishiTeaTime);
            UpdateCookable("GEAR_RosehipsPrepared", Settings.settings.roseHipTeaTime);
            UpdateCookable("GEAR_GreenTeaPackage", Settings.settings.herbalTeaTime);
            UpdateCookable("GEAR_CoffeeTin", Settings.settings.coffeeTime);
            UpdateCookable("GEAR_AcornGrounds", Settings.settings.acornCoffeeTime);

            //WARMING TIMES
            //DRINKS
            UpdateCookable("GEAR_AcornCoffeeCup", Settings.settings.acornCoffeeWarmTime);
            UpdateCookable("GEAR_BirchbarkTea", Settings.settings.birchbarkTeaWarmTime);
            UpdateCookable("GEAR_BurdockTea", Settings.settings.burdockTeaWarmTime);
            UpdateCookable("GEAR_CoffeeCup", Settings.settings.coffeeWarmTime);
            UpdateCookable("GEAR_GreenTeaCup", Settings.settings.herbalTeaWarmTime);
            UpdateCookable("GEAR_ReishiTea", Settings.settings.reishiTeaWarmTime);
            UpdateCookable("GEAR_RoseHipTea", Settings.settings.roseHipTeaWarmTime);
            //OTHER FOOD
            UpdateCookable("GEAR_PinnacleCanPeaches", Settings.settings.pinnaclePeachesWarmTime);
            UpdateCookable("GEAR_CannedBeans", Settings.settings.porkAndBeansWarmTime);
            UpdateCookable("GEAR_TomatoSoupCan", Settings.settings.tomatoSoupWarmTime);
            UpdateCookable("GEAR_CannedCorn", Settings.settings.cannedCornWarmTime);
            UpdateCookable("GEAR_CannedPineapple", Settings.settings.cannedPineappleWarmTime);

            //RECIPE
            UpdateCookable("GEAR_Broth", Settings.settings.brothWarmTime);
            UpdateCookable("GEAR_CookedStewPtarmigan", Settings.settings.ptarmiganMeatStewWarmTime);
            UpdateCookable("GEAR_CookedStewRabbit", Settings.settings.rabbitMeatStewWarmTime);
            UpdateCookable("GEAR_CookedStewMeat", Settings.settings.meatStewWarmTime);
            UpdateCookable("GEAR_CookedStewVegetables", Settings.settings.vegetableStewWarmTime);
            UpdateCookable("GEAR_CookedStewTrout", Settings.settings.troutMeatStewWarmTime);
            UpdateCookable("GEAR_CookedStewVenison", Settings.settings.venisonStewWarmTime);
            UpdateCookable("GEAR_CookedSoupPotato", Settings.settings.soupPotatoWarmTime);
            UpdateCookable("GEAR_CookedSoupPtarmigan", Settings.settings.soupPtarmiganWarmTime);
            UpdateCookable("GEAR_CookedSoupRabbit", Settings.settings.soupRabbitWarmTime);

            // COOKING POTS
            UpdateCookingPotItemPrefab("GEAR_RecycledCan", Settings.settings.recycledCan);
            UpdateCookingPotItemPrefab("GEAR_CookingPot", Settings.settings.cookingPot);
            UpdateCookingPotItemPrefab("GEAR_Skillet", Settings.settings.skillet);

            //WATER SETTINGS
            Panel_CookWater waterPanel = InterfaceManager.GetPanel<Panel_CookWater>();
            waterPanel.m_CookSettings.m_MinutesToMeltSnowPerLiter = (float)Settings.settings.meltingTime;
            waterPanel.m_CookSettings.m_MinutesToBoilWaterPerLiter = (float)Settings.settings.boilingTime;
            waterPanel.m_CookSettings.m_MinutesReadyTimeBoilingWater = (float)Settings.settings.evaporatingTime;


            /*
            //MEAT RAW
            UpdateGearItemPrefab("GEAR_RawMeatBear", Settings.settings.bearCooked, Settings.settings.bearCookedHydro, Settings.settings.bearCookedVit);
            UpdateGearItemPrefab("GEAR_RawMeatDeer", Settings.settings.deerCooked, Settings.settings.deerCookedHydro, Settings.settings.deerCookedVit);
            UpdateGearItemPrefab("GEAR_RawMeatMoose", Settings.settings.mooseCooked, Settings.settings.mooseCookedHydro, Settings.settings.mooseCookedVit);
            UpdateGearItemPrefab("GEAR_RawMeatPtarmigan", Settings.settings.ptarmiganCooked, Settings.settings.ptarmiganCookedHydro, Settings.settings.ptarmiganCookedVit);
            UpdateGearItemPrefab("GEAR_RawMeatRabbit", Settings.settings.rabbitCooked, Settings.settings.rabbitCookedHydro, Settings.settings.rabbitCookedVit);
            UpdateGearItemPrefab("GEAR_RawMeatWolf", Settings.settings.wolfCooked, Settings.settings.wolfCookedHydro, Settings.settings.wolfCookedVit);
            UpdateGearItemPrefab("GEAR_RawMeatCougar", Settings.settings.cougarCooked, Settings.settings.cougarCookedHydro, Settings.settings.cougarCookedVit);
            //FISH RAW
            UpdateGearItemPrefab("GEAR_RawCohoSalmon", Settings.settings.salmonCooked, Settings.settings.salmonCookedHydro, Settings.settings.salmonCookedVit);
            UpdateGearItemPrefab("GEAR_RawLakeWhiteFish", Settings.settings.whitefishCooked, Settings.settings.whitefishCookedHydro, Settings.settings.whitefishCookedVit);
            UpdateGearItemPrefab("GEAR_RawRainbowTrout", Settings.settings.troutCooked, Settings.settings.troutCookedHydro, Settings.settings.troutCookedVit);
            UpdateGearItemPrefab("GEAR_RawSmallMouthBass", Settings.settings.bassCooked, Settings.settings.bassCookedHydro, Settings.settings.bassCookedVit);
            UpdateGearItemPrefab("GEAR_RawBurbot", Settings.settings.burbotCooked, Settings.settings.burbotCookedHydro, Settings.settings.burbotCookedVit);
            UpdateGearItemPrefab("GEAR_RawGoldeye", Settings.settings.goldeyeCooked, Settings.settings.goldeyeCookedHydro, Settings.settings.goldeyeCookedVit);
            UpdateGearItemPrefab("GEAR_RawRedIrishLord", Settings.settings.redIrishLordCooked, Settings.settings.redIrishLordCookedHydro, Settings.settings.redIrishLordCookedVit);
            UpdateGearItemPrefab("GEAR_RawRockfish", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            //RECIPE
            UpdateGearItemPrefab("GEAR_UncookedBannockAcorn", Settings.settings.acornBannock, Settings.settings.acornBannockHydro, Settings.settings.acornBannockVit);
            UpdateGearItemPrefab("GEAR_UncookedPancakeAcorn", Settings.settings.acornPancake, Settings.settings.acornPancakeHydro, Settings.settings.acornPancakeVit);
            UpdateGearItemPrefab("GEAR_UncookedBannock", Settings.settings.bannock, Settings.settings.bannockHydro, Settings.settings.bannockVit);
            UpdateGearItemPrefab("GEAR_UncookedPieMeat", Settings.settings.meatPie, Settings.settings.meatPieHydro, Settings.settings.meatPieVit);
            UpdateGearItemPrefab("GEAR_UncookedBroth", Settings.settings.broth, Settings.settings.brothHydro, Settings.settings.brothVit);
            UpdateGearItemPrefab("GEAR_UncookedPorridgeFruit", Settings.settings.fruitPorridge, Settings.settings.fruitPorridgeHydro, Settings.settings.fruitPorridgeVit);
            UpdateGearItemPrefab("GEAR_UncookedFishcakes", Settings.settings.fishcakes, Settings.settings.fishcakesHydro, Settings.settings.fishcakesVit);
            UpdateGearItemPrefab("GEAR_UncookedPieFishermans", Settings.settings.fishermansPie, Settings.settings.fishermansPieHydro, Settings.settings.fishermansPieVit);
            UpdateGearItemPrefab("GEAR_UncookedPancakePeach", Settings.settings.peachPancake, Settings.settings.peachPancakeHydro, Settings.settings.peachPancakeVit);
            UpdateGearItemPrefab("GEAR_UncookedPancake", Settings.settings.pancake, Settings.settings.pancakeHydro, Settings.settings.pancakeVit);
            UpdateGearItemPrefab("GEAR_UncookedPiePeach", Settings.settings.peachFruitPie, Settings.settings.peachFruitPieHydro, Settings.settings.peachFruitPieVit);
            UpdateGearItemPrefab("GEAR_UncookedPorridge", Settings.settings.porridge, Settings.settings.porridgeHydro, Settings.settings.porridgeVit);
            UpdateGearItemPrefab("GEAR_UncookedPiePtarmigan", Settings.settings.ptarmiganMeatPie, Settings.settings.ptarmiganMeatPieHydro, Settings.settings.ptarmiganMeatPieVit);
            UpdateGearItemPrefab("GEAR_UncookedStewPtarmigan", Settings.settings.ptarmiganMeatStew, Settings.settings.ptarmiganMeatStewHydro, Settings.settings.ptarmiganMeatStewVit);
            UpdateGearItemPrefab("GEAR_UncookedPieForagers", Settings.settings.cookedPieForagers, Settings.settings.cookedPieForagersHydro, Settings.settings.cookedPieForagersVit);
            UpdateGearItemPrefab("GEAR_UncookedPieRabbit", Settings.settings.rabbitMeatPie, Settings.settings.rabbitMeatPieHydro, Settings.settings.rabbitMeatPieVit);
            UpdateGearItemPrefab("GEAR_UncookedStewRabbit", Settings.settings.rabbitMeatStew, Settings.settings.rabbitMeatStewHydro, Settings.settings.rabbitMeatStewVit);
            UpdateGearItemPrefab("GEAR_UncookedStewMeat", Settings.settings.meatStew, Settings.settings.meatStewHydro, Settings.settings.meatStewVit);
            UpdateGearItemPrefab("GEAR_UncookedPieRoseHip", Settings.settings.roseHipFruitPie, Settings.settings.roseHipFruitPieHydro, Settings.settings.roseHipFruitPieVit);
            UpdateGearItemPrefab("GEAR_UncookedPiePredator", Settings.settings.predatorPie, Settings.settings.predatorPieHydro, Settings.settings.predatorPieVit);
            UpdateGearItemPrefab("GEAR_UncookedStewVegetables", Settings.settings.vegetableStew, Settings.settings.vegetableStewHydro, Settings.settings.vegetableStewVit);
            UpdateGearItemPrefab("GEAR_UncookedStewTrout", Settings.settings.troutMeatStew, Settings.settings.troutMeatStewHydro, Settings.settings.troutMeatStewVit);
            UpdateGearItemPrefab("GEAR_UncookedPieVenison", Settings.settings.venisonMeatPie, Settings.settings.venisonMeatPieHydro, Settings.settings.venisonMeatPieVit);
            UpdateGearItemPrefab("GEAR_UncookedStewVenison", Settings.settings.venisonStew, Settings.settings.venisonStewHydro, Settings.settings.venisonStewVit);
            UpdateGearItemPrefab("GEAR_UncookedBarPemmican", Settings.settings.pemmicanBar, Settings.settings.pemmicanBarHydro, Settings.settings.pemmicanBarVit);
            UpdateGearItemPrefab("GEAR_UncookedSoupPotato", Settings.settings.soupPotato, Settings.settings.soupPotatoHydro, Settings.settings.soupPotatoVit);
            UpdateGearItemPrefab("GEAR_UncookedSoupPtarmigan", Settings.settings.soupPtarmigan, Settings.settings.soupPtarmiganHydro, Settings.settings.soupPtarmiganVit);
            UpdateGearItemPrefab("GEAR_UncookedSoupRabbit", Settings.settings.soupRabbit, Settings.settings.soupRabbitHydro, Settings.settings.soupRabbitVit);

            UpdateGearItemPrefab("GEAR_Potato", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_BurdockPrepared", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_BirchbarkPrepared", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_ReishiPrepared", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_RosehipsPrepared", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_GreenTeaPackage", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_CoffeeTin", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_AcornShelled", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_AcornShelledBid", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_AcornCooked", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_AcornCookedBig", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);
            UpdateGearItemPrefab("GEAR_UncookedOil", Settings.settings.rockfishCooked, Settings.settings.rockfishCookedHydro, Settings.settings.rockfishCookedVit);*/


        }

        ////////////////////////////////////////////////////////////////////////
        // ------------------------- DEFAULT VALUES ------------------------- //
        ////////////////////////////////////////////////////////////////////////

        //DEFAULT MEAT SHRINKAGE
        public const int defaultMeatShrinkage = 0;
        //DEFAULT MEAT CALORIES
        public const int defaultCookedBearCalories = 900;
        public const int defaultCookedDeerCalories = 800;
        public const int defaultCookedMooseCalories = 900;
        public const int defaultCookedPtarmiganCalories = 450;
        public const int defaultCookedRabbitCalories = 450;
        public const int defaultCookedWolfCalories = 700;
        public const int defaultCookedCougarCalories = 800;
        //DEFAULT MEAT VITAMIN C
        public const int defaultCookedBearVit = 0;
        public const int defaultCookedDeerVit = 0;
        public const int defaultCookedMooseVit = 0;
        public const int defaultCookedPtarmiganVit = 0;
        public const int defaultCookedRabbitVit = 0;
        public const int defaultCookedWolfVit = 0;
        public const int defaultCookedCougarVit = 0;
        //DEFAULT MEAT HYDRATION
        public const int defaultCookedBearHydro = -15;
        public const int defaultCookedDeerHydro = -5;
        public const int defaultCookedMooseHydro = -5;
        public const int defaultCookedPtarmiganHydro = -5;
        public const int defaultCookedRabbitHydro = -5;
        public const int defaultCookedWolfHydro = -10;
        public const int defaultCookedCougarHydro = -5;
        //DEFAULT MEAT COOKING TIME
        public const int defaultBearTime = 81;
        public const int defaultDeerTime = 56;
        public const int defaultMooseTime = 81;
        public const int defaultPtarmiganTime = 37;
        public const int defaultRabbitTime = 37;
        public const int defaultWolfTime = 69;
        public const int defaultCougarTime = 69;

        //DEFAULT FISH SHRINKAGE
        public const int defaultFishShrinkage = 33;
        //DEFAULT FISH CALORIES
        public const int defaultCookedSalmonCalories = 454;
        public const int defaultCookedWhitefishCalories = 383;
        public const int defaultCookedTroutCalories = 383;
        public const int defaultCookedBassCalories = 454;
        public const int defaultCookedBurbotCalories = 488;
        public const int defaultCookedGoldeyeCalories = 450;
        public const int defaultCookedRedIrishLordCalories = 450;
        public const int defaultCookedRockfishCalories = 450;
        //DEFAULT FISH VITAMIN C
        public const int defaultCookedSalmonVit = 9;
        public const int defaultCookedWhitefishVit = 16;
        public const int defaultCookedTroutVit = 15;
        public const int defaultCookedBassVit = 8;
        public const int defaultCookedBurbotVit = 0;
        public const int defaultCookedGoldeyeVit = 0;
        public const int defaultCookedRedIrishLordVit = 0;
        public const int defaultCookedRockfishVit = 0;
        //DEFAULT FISH HYDRATION
        public const int defaultCookedSalmonHydro = -5;
        public const int defaultCookedWhitefishHydro = -5;
        public const int defaultCookedTroutHydro = -5;
        public const int defaultCookedBassHydro = -5;
        public const int defaultCookedBurbotHydro = -5;
        public const int defaultCookedGoldeyeHydro = -5;
        public const int defaultCookedRedIrishLordHydro = -5;
        public const int defaultCookedRockfishHydro = -5;
        //DEFAULT FISH COOKING TIME
        public const int defaultSalmonTime = 12;
        public const int defaultWhitefishTime = 21;
        public const int defaultTroutTime = 29;
        public const int defaultBassTime = 15;
        public const int defaultBurbotTime = 11;
        public const int defaultGoldeyeTime = 17;
        public const int defaultRedIrishLordTime = 15;
        public const int defaultRockfishTime = 11;

        //DEFAULT DRINKS CALORIES
        public const int defaultAcornCoffeeCalories = 100;
        public const int defaultBirchBarkTeaCalories = 100;
        public const int defaultBurdockTeaCalories = 100;
        public const int defaultCoffeeCalories = 100;
        public const int defaultGoEnergyDrinkCalories = 100;
        public const int defaultHerbalTeaCalories = 100;
        public const int defaultOrangeSodaCalories = 250;
        public const int defaultReishiTeaCalories = 100;
        public const int defaultRoseHipTeaCalories = 100;
        public const int defaultGrapeSodaCalories = 250;
        public const int defaultSummitSodaCalories = 250;
        //DEFAULT DRINKS VITAMIN C
        public const int defaultAcornCoffeeVit = 0;
        public const int defaultBirchBarkTeaVit = 6;
        public const int defaultBurdockTeaVit = 7;
        public const int defaultCoffeeVit = 0;
        public const int defaultGoEnergyDrinkVit = 0;
        public const int defaultHerbalTeaVit = 11;
        public const int defaultOrangeSodaVit = 0;
        public const int defaultReishiTeaVit = 5;
        public const int defaultRoseHipTeaVit = 13;
        public const int defaultGrapeSodaVit = 0;
        public const int defaultSummitSodaVit = 0;
        //DEFAULT DRINKS HYDRATION
        public const int defaultAcornCoffeeHydro = 30;
        public const int defaultBirchBarkTeaHydro = 30;
        public const int defaultBurdockTeaHydro = 30;
        public const int defaultCoffeeHydro = 30;
        public const int defaultGoEnergyDrinkHydro = 30;
        public const int defaultHerbalTeaHydro = 30;
        public const int defaultOrangeSodaHydro = 30;
        public const int defaultReishiTeaHydro = 30;
        public const int defaultRoseHipTeaHydro = 30;
        public const int defaultGrapeSodaHydro = 30;
        public const int defaultSummitSodaHydro = 30;
        //DEFAULT DRINKS COOKING TIME
        public const int defaultAcornCoffeeTime = 12;
        public const int defaultBirchBarkTeaTime = 12;
        public const int defaultBurdockTeaTime = 12;
        public const int defaultCoffeeTime = 12;
        public const int defaultHerbalTeaTime = 12;
        public const int defaultReishiTeaTime = 12;
        public const int defaultRoseHipTeaTime = 12;
        //DEFAULT DRINKS WARMING TIME
        public const int defaultAcornCoffeeWarmTime = 7;
        public const int defaultBirchBarkTeaWarmTime = 7;
        public const int defaultBurdockTeaWarmTime = 7;
        public const int defaultCoffeeWarmTime = 7;
        public const int defaultHerbalTeaWarmTime = 7;
        public const int defaultReishiTeaWarmTime = 7;
        public const int defaultRoseHipTeaWarmTime = 7;

        //DEFAULT OTHER FOOD CALORIES
        public const int defaultAcornCalories = 100;
        public const int defaultAcornBigCalories = 400;
        public const int defaultAirlineChickenCalories = 620;
        public const int defaultAirlineVegetableCalories = 560;
        public const int defaultBeefJerkyCalories = 350;
        public const int defaultBurdockPreparedCalories = 108;
        public const int defaultCattailStalkCalories = 150;
        public const int defaultChocolateBarCalories = 250;
        public const int defaultCondensedMilkCalories = 750;
        public const int defaultDogFoodCalories = 500;
        public const int defaultEnergyBarCalories = 500;
        public const int defaultGranolaBarCalories = 300;
        public const int defaultKetchupChipsCalories = 300;
        public const int defaultMapleSyrupCalories = 850;
        public const int defaultMreCalories = 1750;
        public const int defaultPeanutButterCalories = 900;
        public const int defaultPinnaclePeachesCalories = 450;
        public const int defaultPorkAndBeansCalories = 600;
        public const int defaultSaltyCrackersCalories = 600;
        public const int defaultSardinesCalories = 300;
        public const int defaultTomatoSoupCalories = 300;
        public const int defaultCannedCornCalories = 295;
        public const int defaultCannedHamCalories = 550;
        public const int defaultCarrotCalories = 175;
        public const int defaultPotatoCookedCalories = 250;
        public const int defaultAnimalFatCalories = 900;
        public const int defaultCannedPineappleCalories = 295;
        public const int defaultCerealCalories = 700;
        public const int defaultCuredFishCalories = 900;
        public const int defaultCuredMeatCalories = 900;
        public const int defaultDriedApplesCalories = 400;
        public const int defaultPicklesCalories = 650;
        //DEFAULT OTHER FOOD VITAMIN C
        public const int defaultAcornVit = 0;
        public const int defaultAcornBigVit = 0;
        public const int defaultAirlineChickenVit = 29;
        public const int defaultAirlineVegetableVit = 73;
        public const int defaultBeefJerkyVit = 0;
        public const int defaultBurdockPreparedVit = 8;
        public const int defaultCattailStalkVit = 1;
        public const int defaultChocolateBarVit = 0;
        public const int defaultCondensedMilkVit = 12;
        public const int defaultDogFoodVit = 0;
        public const int defaultEnergyBarVit = 4;
        public const int defaultGranolaBarVit = 2;
        public const int defaultKetchupChipsVit = 5;
        public const int defaultMapleSyrupVit = 0;
        public const int defaultMreVit = 65;
        public const int defaultPeanutButterVit = 0;
        public const int defaultPinnaclePeachesVit = 56;
        public const int defaultPorkAndBeansVit = 2;
        public const int defaultSaltyCrackersVit = 0;
        public const int defaultSardinesVit = 3;
        public const int defaultTomatoSoupVit = 30;
        public const int defaultCannedCornVit = 52;
        public const int defaultCannedHamVit = 0;
        public const int defaultCarrotVit = 9;
        public const int defaultPotatoCookedVit = 24;
        public const int defaultAnimalFatVit = 0;
        public const int defaultCannedPineappleVit = 52;
        public const int defaultCerealVit = 0;
        public const int defaultCuredFishVit = 0;
        public const int defaultCuredMeatVit = 0;
        public const int defaultDriedApplesVit = 4;
        public const int defaultPicklesVit = 50;
        //DEFAULT OTHER FOOD HYDRATION
        public const int defaultAcornHydro = 0;
        public const int defaultAcornBigHydro = 0;
        public const int defaultAirlineChickenHydro = 5;
        public const int defaultAirlineVegetableHydro = 5;
        public const int defaultBeefJerkyHydro = -10;
        public const int defaultBurdockPreparedHydro = -3;
        public const int defaultCattailStalkHydro = 0;
        public const int defaultChocolateBarHydro = -3;
        public const int defaultCondensedMilkHydro = 25;
        public const int defaultDogFoodHydro = 5;
        public const int defaultEnergyBarHydro = 0;
        public const int defaultGranolaBarHydro = -5;
        public const int defaultKetchupChipsHydro = -6;
        public const int defaultMapleSyrupHydro = 0;
        public const int defaultMreHydro = 5;
        public const int defaultPeanutButterHydro = -5;
        public const int defaultPinnaclePeachesHydro = 20;
        public const int defaultPorkAndBeansHydro = -5;
        public const int defaultSaltyCrackersHydro = -20;
        public const int defaultSardinesHydro = 5;
        public const int defaultTomatoSoupHydro = 10;
        public const int defaultCannedCornHydro = 5;
        public const int defaultCannedHamHydro = -5;
        public const int defaultCarrotHydro = 0;
        public const int defaultPotatoCookedHydro = -3;
        public const int defaultAnimalFatHydro = 0;
        public const int defaultCannedPineappleHydro = 5;
        public const int defaultCerealHydro = -10;
        public const int defaultCuredFishHydro = -5;
        public const int defaultCuredMeatHydro = -5;
        public const int defaultDriedApplesHydro = 0;
        public const int defaultPicklesHydro = 5;
        //DEFAULT OTHER FOOD COOKING TIME
        public const int defaultAcornTime = 12;
        public const int defaultAcornBigTime = 12;
        public const int defaultBurdockPreparedTime = 15;
        public const int defaultPotatoTime = 60;
        //DEFAULT OTHER FOOD WARMING TIME
        public const int defaultPinnaclePeachesWarmTime = 15;
        public const int defaultPorkAndBeansWarmTime = 15;
        public const int defaultTomatoSoupWarmTime = 15;
        public const int defaultCannedCornWarmTime = 15;
        public const int defaultCannedPineappleWarmTime = 15;

        //DEFAULT RECIPE CALORIES
        public const int defaultAcornBannockCalories = 250;
        public const int defaultAcornPancakeCalories = 750;
        public const int defaultBannockCalories = 200;
        public const int defaultMeatPieCalories = 2125;
        public const int defaultBrothCalories = 170;
        public const int defaultFruitPorridgeCalories = 1250;
        public const int defaultFishcakesCalories = 312;
        public const int defaultFishermansPieCalories = 1500;
        public const int defaultPeachPancakeCalories = 1000;
        public const int defaultPancakeCalories = 500;
        public const int defaultPeachFruitPieCalories = 250;
        public const int defaultPorridgeCalories = 350;
        public const int defaultPtarmiganMeatPieCalories = 250;
        public const int defaultPtarmiganMeatStewCalories = 750;
        public const int defaultCookedPieForagersCalories = 900;
        public const int defaultRabbitMeatPieCalories = 250;
        public const int defaultRabbitMeatStewCalories = 750;
        public const int defaultMeatStewCalories = 1600;
        public const int defaultRoseHipFruitPieCalories = 225;
        public const int defaultPredatorPieCalories = 1600;
        public const int defaultVegetableStewCalories = 900;
        public const int defaultTroutMeatStewCalories = 750;
        public const int defaultVenisonMeatPieCalories = 325;
        public const int defaultVenisonStewCalories = 900;
        public const int defaultSoupPotatoCalories = 800;
        public const int defaultPemmicanBarCalories = 450;
        public const int defaultSoupPtarmiganCalories = 1200;
        public const int defaultSoupRabbitCalories = 550;
        //DEFAULT RECIPE VITAMIN C
        public const int defaultAcornBannockVit = 0;
        public const int defaultAcornPancakeVit = 0;
        public const int defaultBannockVit = 0;
        public const int defaultMeatPieVit = 0;
        public const int defaultBrothVit = 0;
        public const int defaultFruitPorridgeVit = 59;
        public const int defaultFishcakesVit = 14;
        public const int defaultFishermansPieVit = 68;
        public const int defaultPeachPancakeVit = 57;
        public const int defaultPancakeVit = 0;
        public const int defaultPeachFruitPieVit = 19;
        public const int defaultPorridgeVit = 0;
        public const int defaultPtarmiganMeatPieVit = 0;
        public const int defaultPtarmiganMeatStewVit = 0;
        public const int defaultCookedPieForagersVit = 22;
        public const int defaultRabbitMeatPieVit = 0;
        public const int defaultRabbitMeatStewVit = 0;
        public const int defaultMeatStewVit = 42;
        public const int defaultRoseHipFruitPieVit = 6;
        public const int defaultPredatorPieVit = 0;
        public const int defaultVegetableStewVit = 80;
        public const int defaultTroutMeatStewVit = 17;
        public const int defaultVenisonMeatPieVit = 0;
        public const int defaultVenisonStewVit = 0;
        public const int defaultSoupPotatoVit = 40;
        public const int defaultPemmicanBarVit = 14;
        public const int defaultSoupPtarmiganVit = 24;
        public const int defaultSoupRabbitVit = 0;
        //DEFAULT RECIPE HYDRATION
        public const int defaultAcornBannockHydro = -3;
        public const int defaultAcornPancakeHydro = -3;
        public const int defaultBannockHydro = -3;
        public const int defaultMeatPieHydro = -3;
        public const int defaultBrothHydro = 5;
        public const int defaultFruitPorridgeHydro = 0;
        public const int defaultFishcakesHydro = 0;
        public const int defaultFishermansPieHydro = -3;
        public const int defaultPeachPancakeHydro = 0;
        public const int defaultPancakeHydro = -3;
        public const int defaultPeachFruitPieHydro = 0;
        public const int defaultPorridgeHydro = 0;
        public const int defaultPtarmiganMeatPieHydro = 0;
        public const int defaultPtarmiganMeatStewHydro = 3;
        public const int defaultCookedPieForagersHydro = -3;
        public const int defaultRabbitMeatPieHydro = 0;
        public const int defaultRabbitMeatStewHydro = 3;
        public const int defaultMeatStewHydro = -3;
        public const int defaultRoseHipFruitPieHydro = 0;
        public const int defaultPredatorPieHydro = -3;
        public const int defaultVegetableStewHydro = 3;
        public const int defaultTroutMeatStewHydro = 3;
        public const int defaultVenisonMeatPieHydro = 0;
        public const int defaultVenisonStewHydro = 3;
        public const int defaultSoupPotatoHydro = 6;
        public const int defaultPemmicanBarHydro = 0;
        public const int defaultSoupPtarmiganHydro = 6;
        public const int defaultSoupRabbitHydro = 6;
        //DEFAULT RECIPE PREPPING TIME
        public const int defaultAcornBannockPrepTime = 10;
        public const int defaultAcornPancakePrepTime = 5;
        public const int defaultBannockPrepTime = 10;
        public const int defaultMeatPiePrepTime = 20;
        public const int defaultBrothPrepTime = 10;
        public const int defaultFruitPorridgePrepTime = 8;
        public const int defaultFishcakesPrepTime = 15;
        public const int defaultFishermansPiePrepTime = 20;
        public const int defaultPeachPancakePrepTime = 8;
        public const int defaultPancakePrepTime = 5;
        public const int defaultPeachFruitPiePrepTime = 20;
        public const int defaultPorridgePrepTime = 5;
        public const int defaultPtarmiganMeatPiePrepTime = 20;
        public const int defaultPtarmiganMeatStewPrepTime = 20;
        public const int defaultCookedPieForagersPrepTime = 20;
        public const int defaultRabbitMeatPiePrepTime = 20;
        public const int defaultRabbitMeatStewPrepTime = 20;
        public const int defaultMeatStewPrepTime = 20;
        public const int defaultRoseHipFruitPiePrepTime = 20;
        public const int defaultPredatorPiePrepTime = 20;
        public const int defaultVegetableStewPrepTime = 20;
        public const int defaultTroutMeatStewPrepTime = 20;
        public const int defaultVenisonMeatPiePrepTime = 20;
        public const int defaultVenisonStewPrepTime = 20;
        public const int defaultSoupPotatoPrepTime = 10;
        public const int defaultPemmicanBarPrepTime = 10;
        public const int defaultSoupPtarmiganPrepTime = 10;
        public const int defaultSoupRabbitPrepTime = 10;
        public const int defaultOilPrepTime = 10;
        //DEFAULT RECIPE COOKING TIME
        public const int defaultAcornBannockTime = 40;
        public const int defaultAcornPancakeTime = 10;
        public const int defaultBannockTime = 40;
        public const int defaultMeatPieTime = 80;
        public const int defaultBrothTime = 60;
        public const int defaultFruitPorridgeTime = 20;
        public const int defaultFishcakesTime = 30;
        public const int defaultFishermansPieTime = 80;
        public const int defaultPeachPancakeTime = 10;
        public const int defaultPancakeTime = 10;
        public const int defaultPeachFruitPieTime = 80;
        public const int defaultPorridgeTime = 20;
        public const int defaultPtarmiganMeatPieTime = 80;
        public const int defaultPtarmiganMeatStewTime = 120;
        public const int defaultCookedPieForagersTime = 80;
        public const int defaultRabbitMeatPieTime = 80;
        public const int defaultRabbitMeatStewTime = 120;
        public const int defaultMeatStewTime = 120;
        public const int defaultRoseHipFruitPieTime = 80;
        public const int defaultPredatorPieTime = 80;
        public const int defaultVegetableStewTime = 120;
        public const int defaultTroutMeatStewTime = 120;
        public const int defaultVenisonMeatPieTime = 80;
        public const int defaultVenisonStewTime = 120;
        public const int defaultSoupPotatoTime = 40;
        public const int defaultPemmicanBarTime = 10;
        public const int defaultSoupPtarmiganTime = 40;
        public const int defaultSoupRabbitTime = 40;
        public const int defaultOilTime = 20;
        //DEFAULT RECIPE WARMING TIME
        public const int defaultBrothWarmTime = 7;
        public const int defaultPtarmiganMeatStewWarmTime = 7;
        public const int defaultRabbitMeatStewWarmTime = 7;
        public const int defaultMeatStewWarmTime = 7;
        public const int defaultVegetableStewWarmTime = 7;
        public const int defaultTroutMeatStewWarmTime = 7;
        public const int defaultVenisonStewWarmTime = 7;
        public const int defaultSoupPotatoWarmTime = 7;
        public const int defaultSoupPtarmiganWarmTime = 7;
        public const int defaultSoupRabbitWarmTime = 7;

        ////////////////////////////////////////////////////////////////////////
        // ------------------------ REALISTIC VALUES ------------------------ //
        ////////////////////////////////////////////////////////////////////////

        //REALISTIC MEAT SHRINKAGE
        public const int realisticMeatShrinkage = 25;
        //REALISTIC MEAT CALORIES
        public const int realisticCookedBearCalories = 1305;
        public const int realisticCookedDeerCalories = 1172;
        public const int realisticCookedMooseCalories = 1040;
        public const int realisticCookedPtarmiganCalories = 980;
        public const int realisticCookedRabbitCalories = 932;
        public const int realisticCookedWolfCalories = 875;
        public const int realisticCookedCougarCalories = 875;
        //REALISTIC MEAT VITAMIN C
        public const int realisticCookedBearVit = 0;
        public const int realisticCookedDeerVit = 0;
        public const int realisticCookedMooseVit = 0;
        public const int realisticCookedPtarmiganVit = 0;
        public const int realisticCookedRabbitVit = 0;
        public const int realisticCookedWolfVit = 0;
        public const int realisticCookedCougarVit = 0;
        //REALISTIC MEAT HYDRATION
        public const int realisticCookedBearHydro = 0;
        public const int realisticCookedDeerHydro = 0;
        public const int realisticCookedMooseHydro = 0;
        public const int realisticCookedPtarmiganHydro = 0;
        public const int realisticCookedRabbitHydro = 0;
        public const int realisticCookedWolfHydro = 0;
        public const int realisticCookedCougarHydro = 0;
        //REALISTIC MEAT COOKING TIME
        public const int realisticBearTime = 35;
        public const int realisticDeerTime = 20;
        public const int realisticMooseTime = 25;
        public const int realisticPtarmiganTime = 28;
        public const int realisticRabbitTime = 28;
        public const int realisticWolfTime = 35;
        public const int realisticCougarTime = 35;


        //REALISTIC FISH SHRINKAGE
        public const int realisticFishShrinkage = 50;
        //REALISTIC FISH CALORIES
        public const int realisticCookedSalmonCalories = 1120;
        public const int realisticCookedWhitefishCalories = 1065;
        public const int realisticCookedTroutCalories = 1200;
        public const int realisticCookedBassCalories = 1170;
        public const int realisticCookedBurbotCalories = 1150;
        public const int realisticCookedGoldeyeCalories = 2500;
        public const int realisticCookedRedIrishLordCalories = 1150;
        public const int realisticCookedRockfishCalories = 1090;
        //REALISTIC FISH VITAMIN C
        public const int realisticCookedSalmonVit = 0;
        public const int realisticCookedWhitefishVit = 0;
        public const int realisticCookedTroutVit = 0;
        public const int realisticCookedBassVit = 0;
        public const int realisticCookedBurbotVit = 0;
        public const int realisticCookedGoldeyeVit = 0;
        public const int realisticCookedRedIrishLordVit = 0;
        public const int realisticCookedRockfishVit = 0;
        //REALISTIC FISH HYDRATION
        public const int realisticCookedSalmonHydro = 0;
        public const int realisticCookedWhitefishHydro = 0;
        public const int realisticCookedTroutHydro = 0;
        public const int realisticCookedBassHydro = 0;
        public const int realisticCookedBurbotHydro = 0;
        public const int realisticCookedGoldeyeHydro = 0;
        public const int realisticCookedRedIrishLordHydro = 0;
        public const int realisticCookedRockfishHydro = 0;
        //REALISTIC FISH COOKING TIME
        public const int realisticFishTime = 15;

        //REALISTIC DRINKS CALORIES
        public const int realisticAcornCoffeeCalories = 5;
        public const int realisticBirchBarkTeaCalories = 5;
        public const int realisticBurdockTeaCalories = 5;
        public const int realisticCoffeeCalories = 5;
        public const int realisticGoEnergyDrinkCalories = 115;
        public const int realisticHerbalTeaCalories = 5;
        public const int realisticOrangeSodaCalories = 160;
        public const int realisticReishiTeaCalories = 5;
        public const int realisticRoseHipTeaCalories = 5;
        public const int realisticGrapeSodaCalories = 170;
        public const int realisticSummitSodaCalories = 120;
        //REALISTIC DRINKS VITAMIN C
        public const int realisticAcornCoffeeVit = 0;
        public const int realisticBirchBarkTeaVit = 0;
        public const int realisticBurdockTeaVit = 0;
        public const int realisticCoffeeVit = 0;
        public const int realisticGoEnergyDrinkVit = 0;
        public const int realisticHerbalTeaVit = 0;
        public const int realisticOrangeSodaVit = 0;
        public const int realisticReishiTeaVit = 0;
        public const int realisticRoseHipTeaVit = 0;
        public const int realisticGrapeSodaVit = 0;
        public const int realisticSummitSodaVit = 0;
        //REALISTIC DRINKS HYDRATION
        public const int realisticAcornCoffeeHydro = 0;
        public const int realisticBirchBarkTeaHydro = 0;
        public const int realisticBurdockTeaHydro = 0;
        public const int realisticCoffeeHydro = 0;
        public const int realisticGoEnergyDrinkHydro = 0;
        public const int realisticHerbalTeaHydro = 0;
        public const int realisticOrangeSodaHydro = 0;
        public const int realisticReishiTeaHydro = 0;
        public const int realisticRoseHipTeaHydro = 0;
        public const int realisticGrapeSodaHydro = 0;
        public const int realisticSummitSodaHydro = 0;
        //REALISTIC DRINKS COOKING TIME
        public const int realisticAcornCoffeeTime = 10;
        public const int realisticBirchBarkTeaTime = 10;
        public const int realisticBurdockTeaTime = 10;
        public const int realisticCoffeeTime = 10;
        public const int realisticHerbalTeaTime = 10;
        public const int realisticReishiTeaTime = 10;
        public const int realisticRoseHipTeaTime = 10;
        //REALISTIC DRINKS WARMING TIME
        public const int realisticAcornCoffeeWarmTime = 5;
        public const int realisticBirchBarkTeaWarmTime = 5;
        public const int realisticBurdockTeaWarmTime = 5;
        public const int realisticCoffeeWarmTime = 5;
        public const int realisticHerbalTeaWarmTime = 5;
        public const int realisticReishiTeaWarmTime = 5;
        public const int realisticRoseHipTeaWarmTime = 5;

        //REALISTIC OTHER FOOD CALORIES
        public const int realisticAcornCalories = 150;
        public const int realisticAcornBigCalories = 600;
        public const int realisticAirlineChickenCalories = 620;
        public const int realisticAirlineVegetableCalories = 560;
        public const int realisticBeefJerkyCalories = 410;
        public const int realisticBurdockPreparedCalories = 108;
        public const int realisticCattailStalkCalories = 15;
        public const int realisticChocolateBarCalories = 585;
        public const int realisticCondensedMilkCalories = 815;
        public const int realisticDogFoodCalories = 425;
        public const int realisticEnergyBarCalories = 500;
        public const int realisticGranolaBarCalories = 300;
        public const int realisticKetchupChipsCalories = 540;
        public const int realisticMapleSyrupCalories = 920;
        public const int realisticMreCalories = 1200;
        public const int realisticPeanutButterCalories = 3060;
        public const int realisticPinnaclePeachesCalories = 245;
        public const int realisticPorkAndBeansCalories = 265;
        public const int realisticSaltyCrackersCalories = 515;
        public const int realisticSardinesCalories = 230;
        public const int realisticTomatoSoupCalories = 150;
        public const int realisticCannedCornCalories = 273;
        public const int realisticCannedHamCalories = 480;
        public const int realisticCarrotCalories = 41;
        public const int realisticPotatoCookedCalories = 131;
        public const int realisticAnimalFatCalories = 7700;
        public const int realisticCannedPineappleCalories = 170;
        public const int realisticCerealCalories = 760;
        public const int realisticCuredFishCalories = 400;
        public const int realisticCuredMeatCalories = 600;
        public const int realisticDriedApplesCalories = 400;
        public const int realisticPicklesCalories = 180;
        //REALISTIC OTHER FOOD VITAMIN C
        public const int realisticAcornVit = 0;
        public const int realisticAcornBigVit = 0;
        public const int realisticAirlineChickenVit = 0;
        public const int realisticAirlineVegetableVit = 0;
        public const int realisticBeefJerkyVit = 0;
        public const int realisticBurdockPreparedVit = 0;
        public const int realisticCattailStalkVit = 0;
        public const int realisticChocolateBarVit = 0;
        public const int realisticCondensedMilkVit = 0;
        public const int realisticDogFoodVit = 0;
        public const int realisticEnergyBarVit = 0;
        public const int realisticGranolaBarVit = 0;
        public const int realisticKetchupChipsVit = 0;
        public const int realisticMapleSyrupVit = 0;
        public const int realisticMreVit = 0;
        public const int realisticPeanutButterVit = 0;
        public const int realisticPinnaclePeachesVit = 0;
        public const int realisticPorkAndBeansVit = 0;
        public const int realisticSaltyCrackersVit = 0;
        public const int realisticSardinesVit = 0;
        public const int realisticTomatoSoupVit = 0;
        public const int realisticCannedCornVit = 0;
        public const int realisticCannedHamVit = 0;
        public const int realisticCarrotVit = 0;
        public const int realisticPotatoCookedVit = 0;
        public const int realisticAnimalFatVit = 0;
        public const int realisticCannedPineappleVit = 0;
        public const int realisticCerealVit = 0;
        public const int realisticCuredFishVit = 0;
        public const int realisticCuredMeatVit = 0;
        public const int realisticDriedApplesVit = 0;
        public const int realisticPicklesVit = 0;
        //REALISTIC OTHER FOOD HYDRATION
        public const int realisticAcornHydro = 0;
        public const int realisticAcornBigHydro = 0;
        public const int realisticAirlineChickenHydro = 0;
        public const int realisticAirlineVegetableHydro = 0;
        public const int realisticBeefJerkyHydro = 0;
        public const int realisticBurdockPreparedHydro = 0;
        public const int realisticCattailStalkHydro = 0;
        public const int realisticChocolateBarHydro = 0;
        public const int realisticCondensedMilkHydro = 0;
        public const int realisticDogFoodHydro = 0;
        public const int realisticEnergyBarHydro = 0;
        public const int realisticGranolaBarHydro = 0;
        public const int realisticKetchupChipsHydro = 0;
        public const int realisticMapleSyrupHydro = 0;
        public const int realisticMreHydro = 0;
        public const int realisticPeanutButterHydro = 0;
        public const int realisticPinnaclePeachesHydro = 0;
        public const int realisticPorkAndBeansHydro = 0;
        public const int realisticSaltyCrackersHydro = 0;
        public const int realisticSardinesHydro = 0;
        public const int realisticTomatoSoupHydro = 0;
        public const int realisticCannedCornHydro = 0;
        public const int realisticCannedHamHydro = 0;
        public const int realisticCarrotHydro = 0;
        public const int realisticPotatoCookedHydro = 0;
        public const int realisticAnimalFatHydro = 0;
        public const int realisticCannedPineappleHydro = 0;
        public const int realisticCerealHydro = 0;
        public const int realisticCuredFishHydro = 0;
        public const int realisticCuredMeatHydro = 0;
        public const int realisticDriedApplesHydro = 0;
        public const int realisticPicklesHydro = 0;
        //REALISTIC OTHER FOOD COOKING TIME
        public const int realisticAcornTime = 90;
        public const int realisticAcornBigTime = 90;
        public const int realisticPotatoTime = 20;
        //REALISTIC OTHER FOOD WARMING TIME
        public const int realisticPinnaclePeachesWarmTime = 7;
        public const int realisticPorkAndBeansWarmTime = 7;
        public const int realisticTomatoSoupWarmTime = 7;
        public const int realisticCannedCornWarmTime = 7;
        public const int realisticCannedPineappleWarmTime = 7;

        //REALISTIC RECIPE CALORIES
        public const int realisticAcornBannockCalories = 327;
        public const int realisticAcornPancakeCalories = 808;
        public const int realisticBannockCalories = 427;
        public const int realisticMeatPieCalories = 2397;
        public const int realisticBrothCalories = 48;
        public const int realisticFruitPorridgeCalories = 560;
        public const int realisticFishcakesCalories = 230;
        public const int realisticFishermansPieCalories = 1420;
        public const int realisticPeachPancakeCalories = 1053;
        public const int realisticPancakeCalories = 708;
        public const int realisticPeachFruitPieCalories = 367;
        public const int realisticPorridgeCalories = 96;
        public const int realisticPtarmiganMeatPieCalories = 448;
        public const int realisticPtarmiganMeatStewCalories = 738;
        public const int realisticCookedPieForagersCalories = 1205;
        public const int realisticRabbitMeatPieCalories = 440;
        public const int realisticRabbitMeatStewCalories = 714;
        public const int realisticMeatStewCalories = 1561;
        public const int realisticRoseHipFruitPieCalories = 328;
        public const int realisticPredatorPieCalories = 1745;
        public const int realisticVegetableStewCalories = 994;
        public const int realisticTroutMeatStewCalories = 848;
        public const int realisticVenisonMeatPieCalories = 480;
        public const int realisticVenisonStewCalories = 834;
        public const int realisticSoupPotatoCalories = 287;
        public const int realisticPemmicanBarCalories = 450;
        public const int realisticSoupPtarmiganCalories = 660;
        public const int realisticSoupRabbitCalories = 500;
        //REALISTIC RECIPE VITAMIN C
        public const int realisticAcornBannockVit = 0;
        public const int realisticAcornPancakeVit = 0;
        public const int realisticBannockVit = 0;
        public const int realisticMeatPieVit = 0;
        public const int realisticBrothVit = 0;
        public const int realisticFruitPorridgeVit = 0;
        public const int realisticFishcakesVit = 0;
        public const int realisticFishermansPieVit = 0;
        public const int realisticPeachPancakeVit = 0;
        public const int realisticPancakeVit = 0;
        public const int realisticPeachFruitPieVit = 0;
        public const int realisticPorridgeVit = 0;
        public const int realisticPtarmiganMeatPieVit = 0;
        public const int realisticPtarmiganMeatStewVit = 0;
        public const int realisticCookedPieForagersVit = 0;
        public const int realisticRabbitMeatPieVit = 0;
        public const int realisticRabbitMeatStewVit = 0;
        public const int realisticMeatStewVit = 0;
        public const int realisticRoseHipFruitPieVit = 0;
        public const int realisticPredatorPieVit = 0;
        public const int realisticVegetableStewVit = 0;
        public const int realisticTroutMeatStewVit = 0;
        public const int realisticVenisonMeatPieVit = 0;
        public const int realisticVenisonStewVit = 0;
        public const int realisticSoupPotatoVit = 0;
        public const int realisticPemmicanBarVit = 0;
        public const int realisticSoupPtarmiganVit = 0;
        public const int realisticSoupRabbitVit = 0;
        //REALISTIC RECIPE HYDRATION
        public const int realisticAcornBannockHydro = 0;
        public const int realisticAcornPancakeHydro = 0;
        public const int realisticBannockHydro = 0;
        public const int realisticMeatPieHydro = 0;
        public const int realisticBrothHydro = 0;
        public const int realisticFruitPorridgeHydro = 0;
        public const int realisticFishcakesHydro = 0;
        public const int realisticFishermansPieHydro = 0;
        public const int realisticPeachPancakeHydro = 0;
        public const int realisticPancakeHydro = 0;
        public const int realisticPeachFruitPieHydro = 0;
        public const int realisticPorridgeHydro = 0;
        public const int realisticPtarmiganMeatPieHydro = 0;
        public const int realisticPtarmiganMeatStewHydro = 0;
        public const int realisticCookedPieForagersHydro = 0;
        public const int realisticRabbitMeatPieHydro = 0;
        public const int realisticRabbitMeatStewHydro = 0;
        public const int realisticMeatStewHydro = 0;
        public const int realisticRoseHipFruitPieHydro = 0;
        public const int realisticPredatorPieHydro = 0;
        public const int realisticVegetableStewHydro = 0;
        public const int realisticTroutMeatStewHydro = 0;
        public const int realisticVenisonMeatPieHydro = 0;
        public const int realisticVenisonStewHydro = 0;
        public const int realisticSoupPotatoHydro = 0;
        public const int realisticPemmicanBarHydro = 0;
        public const int realisticSoupPtarmiganHydro = 0;
        public const int realisticSoupRabbitHydro = 0;
        //REALISTIC RECIPE PREPPING TIME
        public const int realisticAcornBannockPrepTime = 10;
        public const int realisticAcornPancakePrepTime = 5;
        public const int realisticBannockPrepTime = 10;
        public const int realisticMeatPiePrepTime = 20;
        public const int realisticBrothPrepTime = 10;
        public const int realisticFruitPorridgePrepTime = 8;
        public const int realisticFishcakesPrepTime = 15;
        public const int realisticFishermansPiePrepTime = 20;
        public const int realisticPeachPancakePrepTime = 8;
        public const int realisticPancakePrepTime = 5;
        public const int realisticPeachFruitPiePrepTime = 20;
        public const int realisticPorridgePrepTime = 5;
        public const int realisticPtarmiganMeatPiePrepTime = 20;
        public const int realisticPtarmiganMeatStewPrepTime = 10;
        public const int realisticCookedPieForagersPrepTime = 20;
        public const int realisticRabbitMeatPiePrepTime = 20;
        public const int realisticRabbitMeatStewPrepTime = 10;
        public const int realisticMeatStewPrepTime = 10;
        public const int realisticRoseHipFruitPiePrepTime = 20;
        public const int realisticPredatorPiePrepTime = 20;
        public const int realisticVegetableStewPrepTime = 10;
        public const int realisticTroutMeatStewPrepTime = 10;
        public const int realisticVenisonMeatPiePrepTime = 20;
        public const int realisticVenisonStewPrepTime = 10;
        public const int realisticSoupPotatoPrepTime = 10;
        public const int realisticPemmicanBarPrepTime = 10;
        public const int realisticSoupPtarmiganPrepTime = 10;
        public const int realisticSoupRabbitPrepTime = 10;
        public const int realisticOilPrepTime = 5;
        //REALISTIC RECIPE COOKING TIME
        public const int realisticAcornBannockTime = 40;
        public const int realisticAcornPancakeTime = 10;
        public const int realisticBannockTime = 40;
        public const int realisticMeatPieTime = 80;
        public const int realisticBrothTime = 60;
        public const int realisticFruitPorridgeTime = 20;
        public const int realisticFishcakesTime = 30;
        public const int realisticFishermansPieTime = 80;
        public const int realisticPeachPancakeTime = 10;
        public const int realisticPancakeTime = 10;
        public const int realisticPeachFruitPieTime = 80;
        public const int realisticPorridgeTime = 20;
        public const int realisticPtarmiganMeatPieTime = 80;
        public const int realisticPtarmiganMeatStewTime = 120;
        public const int realisticCookedPieForagersTime = 80;
        public const int realisticRabbitMeatPieTime = 80;
        public const int realisticRabbitMeatStewTime = 120;
        public const int realisticMeatStewTime = 120;
        public const int realisticRoseHipFruitPieTime = 80;
        public const int realisticPredatorPieTime = 80;
        public const int realisticVegetableStewTime = 120;
        public const int realisticTroutMeatStewTime = 120;
        public const int realisticVenisonMeatPieTime = 80;
        public const int realisticVenisonStewTime = 120;
        public const int realisticSoupPotatoTime = 40;
        public const int realisticPemmicanBarTime = 10;
        public const int realisticSoupPtarmiganTime = 40;
        public const int realisticSoupRabbitTime = 40;
        public const int realisticOilTime = 20;
        //REALISTIC RECIPE WARMING TIME
        public const int realisticBrothWarmTime = 7;
        public const int realisticPtarmiganMeatStewWarmTime = 7;
        public const int realisticRabbitMeatStewWarmTime = 7;
        public const int realisticMeatStewWarmTime = 7;
        public const int realisticVegetableStewWarmTime = 7;
        public const int realisticTroutMeatStewWarmTime = 7;
        public const int realisticVenisonStewWarmTime = 7;
        public const int realisticSoupPotatoWarmTime = 7;
        public const int realisticSoupPtarmiganWarmTime = 7;
        public const int realisticSoupRabbitWarmTime = 7;

        /* VANILLA WEIGHTS
        public const float birchbarkTeaWeight = 0.1f;
        public const float coffeeWeight = 0.1f;
        public const float acornCoffeeWeight = 0.1f;
        public const float burdockTeaWeight = 0.1f;
        public const float goEnergyDrinkWeight = 0.25f;
        public const float herbalTeaWeight = 0.1f;
        public const float orangeSodaWeight = 0.25f;
        public const float reishiTeaWeight = 0.1f;
        public const float roseHipTeaWeight = 0.1f;
        public const float grapeSodaWeight = 0.25f;
        public const float summitSodaWeight = 0.25f;
        public const float acornWeight = 0.03f;
        public const float acornBigWeight = 0.12f;
        public const float airlineChickenWeight = 0.25f;
        public const float airlineVegetableWeight = 0.25f;
        public const float beefJerkyWeight = 0.1f;
        public const float burdockPreparedWeight = 0.15f;
        public const float cattailStalkWeight = 0.05f;
        public const float chocolateBarWeight = 0.1f;
        public const float condensedMilkWeight = 0.25f;
        public const float dogFoodWeight = 0.3f;
        public const float energyBarWeight = 0.1f;
        public const float granolaBarWeight = 0.1f;
        public const float ketchupChipsWeight = 0.1f;
        public const float mapleSyrupWeight = 0.3f;
        public const float mreWeight = 0.5f;
        public const float peanutButterWeight = 0.5f;
        public const float pinnaclePeachesWeight = 0.5f;
        public const float porkAndBeansWeight = 0.25f;
        public const float saltyCrackersWeight = 0.1f;
        public const float sardinesWeight = 0.1f;
        public const float tomatoSoupWeight = 0.25f;
        public const float cannedCornWeight = 0.30f;
        public const float cannedHamWeight = 0.40f;
        public const float carrotWeight = 0.10f;
        public const float potatoCookedWeight = 0.15f;
        public const float cannedPineappleWeight = 0.40f;
        public const float cerealWeight = 0.20f;
        public const float animalFatWeight = 1f;
        public const float curedMeatWeight = 0.15f;
        public const float curedFishWeight = 0.15f;
        public const float driedApplesWeight = 0.15f;
        public const float picklesWeight = 0.15f;
        public const float acornBannockWeight = 0.05f;
        public const float acornPancakeWeight = 0.15f;
        public const float bannockWeight = 0.05f;
        public const float meatPieWeight = 0.20f;
        public const float brothWeight = 0.80f;
        public const float fruitPorridgeWeight = 0.30f;
        public const float fishcakesWeight = 0.05f;
        public const float fishermansPieWeight = 0.30f;
        public const float soupPotatoWeight = 0.10f;
        public const float peachPancakeWeight = 0.20f;
        public const float pancakeWeight = 0.15f;
        public const float peachFruitPieWeight = 0.10f;
        public const float porridgeWeight = 0.20f;
        public const float ptarmiganMeatPieWeight = 0.10f;
        public const float ptarmiganMeatStewWeight = 0.35f;
        public const float pemmicanBarWeight = 0.0625f;
        public const float cookedPieForagersWeight = 0.20f;
        public const float soupPtarmiganWeight = 0.10f;
        public const float rabbitMeatPieWeight = 0.10f;
        public const float rabbitMeatStewWeight = 0.35f;
        public const float meatStewWeight = 0.40f;
        public const float roseHipFruitPieWeight = 0.10f;
        public const float predatorPieWeight = 0.20f;
        public const float vegetableStewWeight = 0.35f;
        public const float troutMeatStewWeight = 0.35f;
        public const float venisonMeatPieWeight = 0.10f;
        public const float venisonStewWeight = 0.35f;
        public const float soupRabbitWeight = 0.10f;*/
    }
}
