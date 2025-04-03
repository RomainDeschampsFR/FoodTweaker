using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using ModSettings;

namespace FoodTweaker
{
    public enum PresetChoice
    {
        Custom, Default, Realistic 
    }
    public enum MeatAndFishChoice
    {
        Calories, VitaminC, Hydration, CookingTime
    }
    public enum OtherFoodChoice
    {
        Calories, VitaminC, Hydration, CookingTime, WarmingTime
    }
    public enum RecipeChoice
    {
        Calories, VitaminC, Hydration, CookingTime, PrepTime, WarmingTime
    }

    class FoodTweakerSettings : JsonModSettings
    {   
        // MEAT SECTION
        [Section("Cooked Meat")]
        [Name("Cooked Meat Presets")]
        [Description("Warning : Each preset choice will be applied for all the food characteristics in this section\nGAME DEFAULT: Game values will remain unchanged.\nREALISTIC: Based on real-world values.\nCUSTOM: Set your own values.\n\nWARNING : CONFIRM YOUR CHANGES BEFORE TWEAKING ANOTHER SECTION!\nDefault & Realistic are here to serve as template. Current Settings are the ones used in game.")]
        [Choice("Current Settings", "Game Default", "Realistic")]
        public PresetChoice presetMeat = PresetChoice.Custom;

        [Name("Cooked Meat Shrinkage")]
        [Description("Weight difference between RAW and COOKED piece of meat.\nGAME DEFAULT: 0%.\nREALISTIC: 25%")]
        [Slider(0, 100, NumberFormat = "{0:d}%")]
        public int meatShrinkage = 0;

        [Name("Cooked Meat Characteristics")]
        [Description("Select a food characteristic")]
        [Choice("Calories (kcal/kg)", "Vitamin C (mg/kg)", "Hydration", "Cooking Time (mins/kg)")]
        public MeatAndFishChoice propertyMeat = MeatAndFishChoice.Calories;

        // MEAT CALORIES
        [Name("     Bear")]
        [Description("Set the calorie value of 1kg of COOKED Bear.\nDefault Game Value: 900\nRealistic Value: 1305 (1630 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int bearCooked = 900;

        [Name("     Deer")]
        [Description("Set the calorie value of 1kg of COOKED Deer.\nDefault Game Value: 800\nRealistic Value: 1172 (1465 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int deerCooked = 800;

        [Name("     Moose")]
        [Description("Set the calorie value of 1kg of COOKED Moose.\nDefault Game Value: 900\nRealistic Value: 1040 (1300 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int mooseCooked = 900;

        [Name("     Ptarmigan")]
        [Description("Set the calorie value of 1kg of COOKED Ptarmigan.\nDefault Game Value: 450\nRealistic Value: 980 (1225 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int ptarmiganCooked = 450;

        [Name("     Rabbit")]
        [Description("Set the calorie value of 1kg of COOKED Rabbit.\nDefault Game Value: 450\nRealistic Value: 932 (1140 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int rabbitCooked = 450;

        [Name("     Wolf")]
        [Description("Set the calorie value of 1kg of COOKED Wolf.\nDefault Game Value: 700\nRealistic Value: 875 (1165 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int wolfCooked = 700;

        [Name("     Cougar")]
        [Description("Set the calorie value of 1kg of COOKED Cougar.\nDefault Game Value: 800\nRealistic Value: 875 (1165 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int cougarCooked = 800;

        // MEAT VITAMIN C
        [Name("     Bear")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int bearCookedVit = 0;

        [Name("     Deer")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int deerCookedVit = 0;

        [Name("     Moose")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int mooseCookedVit = 0;

        [Name("     Ptarmigan")]
        [Description("Default Game Value: 0\nRealistic Value:")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int ptarmiganCookedVit = 0;

        [Name("     Rabbit")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int rabbitCookedVit = 0;

        [Name("     Wolf")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int wolfCookedVit = 0;

        [Name("     Cougar")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int cougarCookedVit = 0;

        // MEAT HYDRATION
        [Name("     Bear")]
        [Description("Default Game Value: -15\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int bearCookedHydro = -15;

        [Name("     Deer")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int deerCookedHydro = -5;

        [Name("     Moose")]
        [Description("Default Game Value: -5\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int mooseCookedHydro = -5;

        [Name("     Ptarmigan")]
        [Description("Default Game Value: -5\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int ptarmiganCookedHydro = -5;

        [Name("     Rabbit")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int rabbitCookedHydro = -5;

        [Name("     Wolf")]
        [Description("Default Game Value: -10\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int wolfCookedHydro = -10;

        [Name("     Cougar")]
        [Description("Default Game Value: -5\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int cougarCookedHydro = -5;

        // MEAT COOKING TIME
        [Name("     Bear")]
        [Description("Adjust cooking time, in minutes, for 1kg Bear meat.\nGAME DEFAULT: 81,25 min/kg.\nREALISTIC: 35 min/kg (24.5 with Cooking lvl 5)")]
        [Slider(1, 120, NumberFormat = "{0:d} mins")]
        public int bearCookedTime = 81;

        [Name("     Deer")]
        [Description("Adjust cooking time, in minutes, for 1kg Deer meat.\nGAME DEFAULT: 56,25 min/kg.\nREALISTIC: 20 min/kg (14 with Cooking lvl 5)")]
        [Slider(1, 120, NumberFormat = "{0:d} mins")]
        public int deerCookedTime = 56;

        [Name("     Moose")]
        [Description("Adjust cooking time, in minutes, for 1kg Moose meat.\nGAME DEFAULT: 81,25 min/kg.\nREALISTIC: 25 min/kg (17.5 with Cooking lvl 5)")]
        [Slider(1, 120, NumberFormat = "{0:d} mins")]
        public int mooseCookedTime = 81;

        [Name("     Ptarmigan")]
        [Description("Adjust cooking time, in minutes, for 1kg Moose meat.\nGAME DEFAULT: 37,5 min/kg.\nREALISTIC: 28 min/kg (19.6 with Cooking lvl 5)")]
        [Slider(1, 120, NumberFormat = "{0:d} mins")]
        public int ptarmiganCookedTime = 37;

        [Name("     Rabbit")]
        [Description("Adjust cooking time, in minutes, for 1kg Rabbit meat\nGAME DEFAULT: 37,5 min/kg.\nREALISTIC: 28 min/kg (19.6 with Cooking lvl 5)")]
        [Slider(1, 120, NumberFormat = "{0:d} mins")]
        public int rabbitCookedTime = 37;

        [Name("     Wolf")]
        [Description("Adjust cooking time, in minutes, for 1kg Wolf meat.\nGAME DEFAULT: 68,75 min/kg.\nREALISTIC: 35 min/kg (24.5 with Cooking lvl 5)")]
        [Slider(1, 120, NumberFormat = "{0:d} mins")]
        public int wolfCookedTime = 69;

        [Name("     Cougar")]
        [Description("Adjust cooking time, in minutes, for 1kg Cougar meat.\nGAME DEFAULT: 68,75 min/kg.\nREALISTIC: 35 min/kg (24.5 with Cooking lvl 5)")]
        [Slider(1, 120, NumberFormat = "{0:d} mins")]
        public int cougarCookedTime = 69;

        // FISH SECTION
        [Section("Cooked Fish")]
        [Name("Cooked Fish Presets")]
        [Description("Warning : Each preset choice will be applied for all the food characteristics in this section\nGAME DEFAULT: Game values will remain unchanged.\nREALISTIC: Based on real-world values + some assumptions.\nCUSTOM: Set your own values.\n\nWARNING : CONFIRM YOUR CHANGES BEFORE TWEAKING ANOTHER SECTION!\nDefault & Realistic are here to serve as template. Current Settings are the ones used in game.")]
        [Choice("Current Settings", "Game Default", "Realistic")]
        public PresetChoice presetFish = PresetChoice.Custom;

        // FISH SHRINKAGE
        [Name("Cooked Fish Shrinkage & Cleaning Loss")]
        [Description("Weight difference between WHOLE, RAW FISH and CLEANED, COOKED FISH.\nGAME DEFAULT: 33%. REALISTIC: 50%\nCUSTOM: Set your own values.")]
        [Slider(0, 100, NumberFormat = "{0:d}%")]
        public int fishShrinkage = 33;

        [Name("Cooked Fish Characteristics")]
        [Description("Select a food characteristic")]
        [Choice("Calories (kcal/kg)", "Vitamin C (mg/kg)", "Hydration", "Cooking Time (min/kg)")]
        public MeatAndFishChoice propertyFish = MeatAndFishChoice.Calories;

        // FISH CALORIES
        [Name("     Coho Salmon ")]
        [Description("Set the calorie value of 1kg of COOKED Coho Salmon.\nDefault Game Value: 454\nRealistic Value: 1120 (1400 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int salmonCooked = 454;

        [Name("     Lake Whitefish ")]
        [Description("Set the calorie value of 1kg of COOKED Lake Whitefish.\nDefault Game Value: 383\nRealistic Value: 1065 (1330 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int whitefishCooked = 383;

        [Name("     Rainbow Trout ")]
        [Description("Set the calorie value of 1kg of COOKED Rainbow Trout.\nDefault Game Value: 383\nRealistic Value: 1200 (1500 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int troutCooked = 383;

        [Name("     Smallmouth Bass ")]
        [Description("Set the calorie value of 1kg of COOKED Smallmouth Bass.\nDefault Game Value: 454\nRealistic Value: 1168 (1460 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int bassCooked = 454;

        [Name("     Burbot ")]
        [Description("Set the calorie value of 1kg of COOKED Burbot.\nDefault Game Value: 488\nRealistic Value: 1150 (1437 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int burbotCooked = 488;

        [Name("     Goldeye ")]
        [Description("Set the calorie value of 1kg of COOKED Goldeye Fish.\nDefault Game Value: 450\nRealistic Value: 2500 (3125 at Cooking lvl 5)")]
        [Slider(250, 3000, 551, NumberFormat = "{0:d}")]
        public int goldeyeCooked = 450;

        [Name("     Red Irish Lord ")]
        [Description("Set the calorie value of 1kg of COOKED Red Irish Lord.\nDefault Game Value: 450\nRealistic Value: 1150 (1437 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int redIrishLordCooked = 450;

        [Name("     Rockfish ")]
        [Description("Set the calorie value of 1kg of COOKED Rockfish.\nDefault Game Value: 450\nRealistic Value: 1090 (1362 at Cooking lvl 5)")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d}")]
        public int rockfishCooked = 450;

        // FISH VITAMIN C
        [Name("     Coho Salmon")]
        [Description("Default Game Value: 9 per kg\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int salmonCookedVit = 9;

        [Name("     Lake Whitefish")]
        [Description("Default Game Value: 16 per kg\nRealistic Value:")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int whitefishCookedVit = 16;

        [Name("     Rainbow Trout")]
        [Description("Default Game Value: 15 per kg\nRealistic Value:")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int troutCookedVit = 15;

        [Name("     Smallmouth Bass")]
        [Description("Default Game Value: 8 per kg\nRealistic Value:")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int bassCookedVit = 8;

        [Name("     Burbot")]
        [Description("Default Game Value: 0\nRealistic Value:")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int burbotCookedVit = 0;

        [Name("     Goldeye")]
        [Description("Default Game Value: 0\nRealistic Value:")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int goldeyeCookedVit = 0;

        [Name("     Red Irish Lord")]
        [Description("Default Game Value: 0\nRealistic Value:")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int redIrishLordCookedVit = 0;

        [Name("     Rockfish")]
        [Description("Default Game Value: 0\nRealistic Value:")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int rockfishCookedVit = 0;

        // FISH HYDRATION
        [Name("     Coho Salmon")]
        [Description("Default Game Value: -5\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int salmonCookedHydro = -5;

        [Name("     Lake Whitefish")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int whitefishCookedHydro = -5;

        [Name("     Rainbow Trout")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int troutCookedHydro = -5;

        [Name("     Smallmouth Bass")]
        [Description("Default Game Value: -5\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int bassCookedHydro = -5;

        [Name("     Burbot")]
        [Description("Default Game Value: -5\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int burbotCookedHydro = -5;

        [Name("     Goldeye")]
        [Description("Default Game Value: -5\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int goldeyeCookedHydro = -5;

        [Name("     Red Irish Lord")]
        [Description("Default Game Value: -5\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int redIrishLordCookedHydro = -5;

        [Name("     Rockfish")]
        [Description("Default Game Value: -5\nRealistic Value:")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int rockfishCookedHydro = -5;

        // FISH COOKING TIME
        [Name("Coho Salmon (mins/kg)")]
        [Description("Adjust cooking time, in minutes, for 1kg Coho Salmon.\nGAME DEFAULT: 12 mins.\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:d} mins")]
        public int salmonCookedTime = 12;

        [Name("     Lake Whitefish")]
        [Description("Adjust cooking time, in minutes, for 1kg Lake Whitefish.\nGAME DEFAULT: 21 mins.\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:d} mins")]
        public int whitefishCookedTime = 21;

        [Name("     Rainbow Trout")]
        [Description("Adjust cooking time, in minutes, for 1kg Rainbow Trout.\nGAME DEFAULT: 29 mins.\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:d} mins")]
        public int troutCookedTime = 29;

        [Name("     Smallmouth Bass")]
        [Description("Adjust cooking time, in minutes, for 1kg Smallmouth Bass.\nGAME DEFAULT: 15 mins.\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:d} mins")]
        public int bassCookedTime = 15;

        [Name("     Burbot")]
        [Description("Adjust cooking time, in minutes, for 1kg Burbot.\nGAME DEFAULT: 11 mins.\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:d} mins")]
        public int burbotCookedTime = 11;

        [Name("     Goldeye")]
        [Description("Adjust cooking time, in minutes, for 1kg Goldeye.\nGAME DEFAULT: 17 mins .\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:d} mins")]
        public int goldeyeCookedTime = 17;

        [Name("     Red Irish Lord")]
        [Description("Adjust cooking time, in minutes, for 1kg Red Irish Lord.\nGAME DEFAULT: 15 mins .\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:d} mins")]
        public int redIrishLordCookedTime = 15;

        [Name("     Rockfish")]
        [Description("Adjust cooking time, in minutes, for 1kg rockfish.\nGAME DEFAULT: 11 mins .\nREALISTIC: 15 mins")]
        [Slider(1, 60, 60, NumberFormat = "{0:d} mins")]
        public int rockfishCookedTime = 11;

        // DRINKS SECTION
        [Section("Drinks")]
        [Name("Drinks Presets")]
        [Description("Warning : Each preset choice will be applied for all the food characteristics in this section\nGAME DEFAULT: Game values will remain unchanged.\nREALISTIC: Based on real-world values.\nCUSTOM: Set your own values.\n\nWARNING Again : CONFIRM YOUR CHANGES BEFORE TWEAKING ANOTHER SECTION!\nDefault & Realistic are here to serve as template. Current Settings are the ones used in game.")]
        [Choice("Current Settings", "Game Default", "Realistic")]
        public PresetChoice presetDrinks = PresetChoice.Custom;

        [Name("Drinks Characteristics")]
        [Description("Select a food characteristic")]
        [Choice("Calories", "Vitamin C", "Hydration", "Cooking Time", "Warming Time")]
        public OtherFoodChoice propertyDrinks = OtherFoodChoice.Calories;

        // DRINKS CALORIES
        [Name("     Acorn Coffee")]
        [Description("Default Game Value: 100\nRealistic Value: 5")]
        [Slider(1, 100, 100, NumberFormat = "{0:d} kcal")]
        public int acornCoffee = 100;

        [Name("     Birch Bark Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 5")]
        [Slider(1, 100, 100, NumberFormat = "{0:d} kcal")]
        public int birchbarkTea = 100;

        [Name("     Burdock Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 5")]
        [Slider(1, 100, 100, NumberFormat = "{0:d} kcal")]
        public int burdockTea = 100;

        [Name(     "Coffee")]
        [Description("Default Game Value: 100\nRealistic Value: 5")]
        [Slider(1, 100, 100, NumberFormat = "{0:d} kcal")]
        public int coffee = 100;

        [Name(     "Go! Energy Drink")]
        [Description("Default Game Value: 100\nRealistic Value: 115")]
        [Slider(5, 500, 100, NumberFormat = "{0:d} kcal")]
        public int goEnergyDrink = 100;

        [Name(     "Herbal Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 5")]
        [Slider(1, 100, 100, NumberFormat = "{0:d} kcal")]
        public int herbalTea = 100;

        [Name(     "Orange Soda")]
        [Description("Default Game Value: 250\nRealistic Value: 160")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int orangeSoda = 250;

        [Name(     "Reishi Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 5")]
        [Slider(1, 100, 100, NumberFormat = "{0:d} kcal")]
        public int reishiTea = 100;

        [Name(     "Rose Hip Tea")]
        [Description("Default Game Value: 100\nRealistic Value: 5")]
        [Slider(1, 100, 100, NumberFormat = "{0:d} kcal")]
        public int roseHipTea = 100;

        [Name(     "Stacey's Grape Soda")]
        [Description("Default Game Value: 250\nRealistic Value: 170")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int grapeSoda = 250;

        [Name(     "Summit Soda")]
        [Description("Default Game Value: 250\nRealistic Value: 120")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int summitSoda = 250;

        // DRINKS VITAMIN C
        [Name(     "Acorn Coffee")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int acornCoffeeVit = 0;

        [Name(     "Birch Bark Tea")]
        [Description("Default Game Value: 6\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int birchbarkTeaVit = 6;

        [Name(     "Burdock Tea")]
        [Description("Default Game Value: 7\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int burdockTeaVit = 7;

        [Name(     "Coffee")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int coffeeVit = 0;

        [Name(     "Go! Energy Drink")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int goEnergyDrinkVit = 0;

        [Name(     "Herbal Tea")]
        [Description("Default Game Value: 11\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int herbalTeaVit = 11;

        [Name(     "Orange Soda")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int orangeSodaVit = 0;

        [Name(     "Reishi Tea")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int reishiTeaVit = 5;

        [Name(     "Rose Hip Tea")]
        [Description("Default Game Value: 13\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int roseHipTeaVit = 13;

        [Name(     "Stacey's Grape Soda")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int grapeSodaVit = 0;

        [Name(     "Summit Soda")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int summitSodaVit = 0;

        // DRINKS HYDRATION
        [Name(     "Acorn Coffee")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int acornCoffeeHydro = 30;

        [Name(     "Birch Bark Tea")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int birchbarkTeaHydro = 30;

        [Name(     "Burdock Tea")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int burdockTeaHydro = 30;

        [Name(     "Coffee")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int coffeeHydro = 30;

        [Name(     "Go! Energy Drink")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int goEnergyDrinkHydro = 30;

        [Name(     "Herbal Tea")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int herbalTeaHydro = 30;

        [Name(     "Orange Soda")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int orangeSodaHydro = 30;

        [Name(     "Reishi Tea")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int reishiTeaHydro = 30;

        [Name(     "Rose Hip Tea")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int roseHipTeaHydro = 30;

        [Name(     "Stacey's Grape Soda")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int grapeSodaHydro = 30;

        [Name(     "Summit Soda")]
        [Description("Default Game Value: 30\nRealistic Value: 15")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int summitSodaHydro = 30;

        // DRINKS COOKING TIME
        [Name(     "Acorn Coffee")]
        [Description("Default Game Value: 12.5 mins\nRealistic Value: 10 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int acornCoffeeTime = 12;

        [Name(     "Birch Bark Tea")]
        [Description("Default Game Value: 12.5 mins\nRealistic Value: 10 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int birchbarkTeaTime = 12;

        [Name(     "Burdock Tea")]
        [Description("Default Game Value: 12.5 mins\nRealistic Value: 10 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int burdockTeaTime = 12;

        [Name(     "Coffee")]
        [Description("Default Game Value: 12.5 mins\nRealistic Value: 10 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int coffeeTime = 12;

        [Name(     "Herbal Tea")]
        [Description("Default Game Value: 12.5 mins\nRealistic Value: 10 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int herbalTeaTime = 12;

        [Name(     "Reishi Tea")]
        [Description("Default Game Value: 12.5 mins\nRealistic Value: 10 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int reishiTeaTime = 12;

        [Name(     "Rose Hip Tea")]
        [Description("Default Game Value: 12.5 mins\nRealistic Value: 10 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int roseHipTeaTime = 12;

        //DRINKS WARMING TIME
        [Name(     "Acorn Coffee")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int acornCoffeeWarmTime = 7;

        [Name(     "Birch Bark Tea")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int birchbarkTeaWarmTime = 7;

        [Name(     "Burdock Tea")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int burdockTeaWarmTime = 7;

        [Name(     "Coffee")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int coffeeWarmTime = 7;

        [Name(     "Herbal Tea")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int herbalTeaWarmTime = 7;

        [Name(     "Reishi Tea")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int reishiTeaWarmTime = 7;

        [Name(     "Rose Hip Tea")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int roseHipTeaWarmTime = 7;

        //OTHER FOOD SECTION
        [Section("Other food")]
        [Name("Other food presets")]
        [Description("Warning : Each preset choice will be applied for all the food characteristics in this section\nGAME DEFAULT: Game values will remain unchanged.\nREALISTIC: Based on real-world values.\nCUSTOM: Set your own values.")]
        [Choice("Current Settings", "Game Default", "Realistic")]
        public PresetChoice presetOtherFood = PresetChoice.Custom;

        [Name("Other food characteriestics")]
        [Description("Select a food characteristic")]
        [Choice("Calories", "Vitamin C", "Hydration", "Cooking Time", "Warming Time")]
        public OtherFoodChoice propertyOtherFood = OtherFoodChoice.Calories;

        //OTHER FOOD CALORIES
        [Name(     "Acorn")]
        [Description("Default Game Value: 100\nRealistic Value: 150")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int acorn = 100;

        [Name(     "Acorn : Large portion")]
        [Description("Default Game Value: 400\nRealistic Value: 600")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int acornBig = 400;

        [Name(     "Airline Food: Chicken")]
        [Description("Default Game Value: 620\nRealistic Value: 620")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int airlineChicken = 620;

        [Name(     "Airline Food: Vegetarian")]
        [Description("Default Game Value: 560\nRealistic Value: 560")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int airlineVegetarian = 560;

        [Name(     "Beef Jerky")]
        [Description("Default Game Value: 350\nRealistic Value: 410")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int beefJerky = 350;

        [Name(     "Burdock prepared")]
        [Description("Default Game Value: 275\nRealistic Value: 108")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int burdockPrepared = 275;

        [Name(     "Cattail Stalk")]
        [Description("Default Game Value: 150\nRealistic Value: 15")]
        [Slider(5, 500, NumberFormat = "{0:d} kcal")]
        public int cattailStalk = 150;

        [Name(     "Chocolate Bar")]
        [Description("Default Game Value: 250\nRealistic Value: 585")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int chocolateBar = 250;

        [Name(     "Condensed Milk")]
        [Description("Default Game Value: 750\nRealistic Value: 815")]
        [Slider(250, 1000, NumberFormat = "{0:d} kcal")]
        public int condensedMilk = 750;

        [Name(     "Dog Food")]
        [Description("Default Game Value: 500\nRealistic Value: 425")]
        [Slider(250, 1000, NumberFormat = "{0:d} kcal")]
        public int dogFood = 500;

        [Name(     "Energy Bar")]
        [Description("Default Game Value: 500\nRealistic Value: 500")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int energyBar = 500;

        [Name(     "Granola Bar")]
        [Description("Default Game Value: 300\nRealistic Value: 300")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int granolaBar = 300;

        [Name(     "Ketchup Chips")]
        [Description("Default Game Value: 300\nRealistic Value: 540")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int ketchupChips = 300;

        [Name(     "Maple Syrup")]
        [Description("Default Game Value: 850\nRealistic Value: 920")]
        [Slider(500, 1500, NumberFormat = "{0:d} kcal")]
        public int mapleSyrup = 850;

        [Name(     "Military-Grade MRE")]
        [Description("Default Game Value: 1750\nRealistic Value: 1200")]
        [Slider(1000, 2500, NumberFormat = "{0:d} kcal")]
        public int mre = 1750;

        [Name(     "Peanut Butter")]
        [Description("Default Game Value: 900\nRealistic Value: 3060")]
        [Slider(500, 3500, NumberFormat = "{0:d} kcal")]
        public int peanutButter = 900;

        [Name(     "Pinnacle Peaches")]
        [Description("Default Game Value: 450\nRealistic Value: 245")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int pinnaclePeaches = 450;

        [Name(     "Pork and Beans")]
        [Description("Default Game Value: 600\nRealistic Value: 265")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int porkAndBeans = 600;

        [Name(     "Salty Crackers")]
        [Description("Default Game Value: 600\nRealistic Value: 515")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int saltyCrackers = 600;

        [Name(     "Tin of Sardines")]
        [Description("Default Game Value: 300\nRealistic Value: 230")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int sardines = 300;

        [Name(     "Tomato Soup")]
        [Description("Default Game Value: 300\nRealistic Value: 150")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int tomatoSoup = 300;

        [Name(     "Animal Fat")]
        [Description("Default Game Value: 900\nRealistic Value: 7700")]
        [Slider(250, 8000, NumberFormat = "{0:d} kcal")]
        public int animalFat = 900;

        [Name(     "Canned Corn")]
        [Description("Default Game Value: 295\nRealistic Value: 273")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int cannedCorn = 295;

        [Name(     "Canned Ham")]
        [Description("Default Game Value: 550\nRealistic Value: 480")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int cannedHam = 550;

        [Name(     "Canned Pineapple")]
        [Description("Default Game Value: 295\nRealistic Value: 170")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int cannedPineapple = 295;

        [Name(     "Carrot")]
        [Description("Default Game Value: 175\nRealistic Value: 41")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int carrot = 175;

        [Name(     "Cereal")]
        [Description("Default Game Value: 700\nRealistic Value: 760")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int cereal = 700;

        [Name(     "Cooked Potato")]
        [Description("Default Game Value: 250\nRealistic Value: 131")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int potatoCooked = 250;

        [Name(     "Cured Meat")]
        [Description("Default Game Value: 900\nRealistic Value: 600")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int curedMeat = 900;

        [Name(     "Cured Fish")]
        [Description("Default Game Value: 900\nRealistic Value: 400")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int curedFish = 900;

        [Name(     "Dried Apples")]
        [Description("Default Game Value: 400\nRealistic Value: 400")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int driedApples = 400;

        [Name(     "Pickles")]
        [Description("Default Game Value: 650\nRealistic Value: 180")]
        [Slider(100, 1000, NumberFormat = "{0:d} kcal")]
        public int pickles = 650;

        //OTHER FOOD VITAMIN C
        [Name(     "Acorn")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int acornVit = 0;

        [Name(     "Acorn : Large portion")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int acornBigVit = 0;

        [Name(     "Airline Food: Chicken")]
        [Description("Default Game Value: 29\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int airlineChickenVit = 29;

        [Name(     "Airline Food: Vegetarian")]
        [Description("Default Game Value: 73\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int airlineVegetarianVit = 73;

        [Name(     "Beef Jerky")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int beefJerkyVit = 0;

        [Name(     "Burdock prepared")]
        [Description("Default Game Value: 8\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int burdockPreparedVit = 8;

        [Name(     "Cattail Stalk")]
        [Description("Default Game Value: 1\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int cattailStalkVit = 1;

        [Name(     "Chocolate Bar")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int chocolateBarVit = 0;

        [Name(     "Condensed Milk")]
        [Description("Default Game Value: 12\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int condensedMilkVit = 12;

        [Name(     "Dog Food")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int dogFoodVit = 0;

        [Name(     "Energy Bar")]
        [Description("Default Game Value: 4\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int energyBarVit = 4;

        [Name(     "Granola Bar")]
        [Description("Default Game Value: 2\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int granolaBarVit = 2;

        [Name(     "Ketchup Chips")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int ketchupChipsVit = 5;

        [Name(     "Maple Syrup")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int mapleSyrupVit = 0;

        [Name(     "Military-Grade MRE")]
        [Description("Default Game Value: 65\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int mreVit = 65;

        [Name(     "Peanut Butter")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int peanutButterVit = 0;

        [Name(     "Pinnacle Peaches")]
        [Description("Default Game Value: 56\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int pinnaclePeachesVit = 56;

        [Name(     "Pork and Beans")]
        [Description("Default Game Value: 2\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int porkAndBeansVit = 2;

        [Name(     "Salty Crackers")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int saltyCrackersVit = 0;

        [Name(     "Tin of Sardines")]
        [Description("Default Game Value: 3\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int sardinesVit = 3;

        [Name(     "Tomato Soup")]
        [Description("Default Game Value: 30\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int tomatoSoupVit = 30;

        [Name(     "Animal Fat")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int animalFatVit = 0;

        [Name(     "Canned Corn")]
        [Description("Default Game Value: 52\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int cannedCornVit = 52;

        [Name(     "Canned Ham")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int cannedHamVit = 0;

        [Name(     "Canned Pineapple")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int cannedPineappleVit = 0;

        [Name(     "Carrot")]
        [Description("Default Game Value: 9\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int carrotVit = 0;

        [Name(     "Cereal")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int cerealVit = 0;

        [Name(     "Cooked Potato")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int potatoCookedVit = 0;

        [Name(     "Cured Meat")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int curedMeatVit = 0;

        [Name(     "Cured Fish")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int curedFishVit = 0;

        [Name(     "Dried Apples")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int driedApplesVit = 0;

        [Name(     "Pickles")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int picklesVit = 0;

        //OTHER FOOD HYDRATION
        [Name(     "Acorn")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int acornHydro = 0;

        [Name(     "Acorn : Large portion")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int acornBigHydro = 0;

        [Name(     "Airline Food: Chicken")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int airlineChickenHydro = 5;

        [Name(     "Airline Food: Vegetarian")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int airlineVegetarianHydro = 5;

        [Name(     "Beef Jerky")]
        [Description("Default Game Value: -10\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int beefJerkyHydro = -10;

        [Name(     "Burdock prepared")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int burdockPreparedHydro = -3;

        [Name(     "Cattail Stalk")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int cattailStalkHydro = 0;

        [Name(     "Chocolate Bar")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int chocolateBarHydro = -3;

        [Name(     "Condensed Milk")]
        [Description("Default Game Value: 25\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int condensedMilkHydro = 25;

        [Name(     "Dog Food")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int dogFoodHydro = 5;

        [Name(     "Energy Bar")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int energyBarHydro = 0;

        [Name(     "Granola Bar")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int granolaBarHydro = 0-5;

        [Name(     "Ketchup Chips")]
        [Description("Default Game Value: -6\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int ketchupChipsHydro = -6;

        [Name(     "Maple Syrup")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int mapleSyrupHydro = 0;

        [Name(     "Military-Grade MRE")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int mreHydro = 5;

        [Name(     "Peanut Butter")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int peanutButterHydro = -5;

        [Name(     "Pinnacle Peaches")]
        [Description("Default Game Value: 20\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int pinnaclePeachesHydro = 20;

        [Name(     "Pork and Beans")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int porkAndBeansHydro = -5;

        [Name(     "Salty Crackers")]
        [Description("Default Game Value: -20\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int saltyCrackersHydro = -20;

        [Name(     "Tin of Sardines")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int sardinesHydro = 5;

        [Name(     "Tomato Soup")]
        [Description("Default Game Value: 10\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int tomatoSoupHydro = 10;

        [Name(     "Animal Fat")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int animalFatHydro = 0;

        [Name(     "Canned Corn")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int cannedCornHydro = 5;

        [Name(     "Canned Ham")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int cannedHamHydro = -5;

        [Name(     "Canned Pineapple")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int cannedPineappleHydro = 5;

        [Name(     "Carrot")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int carrotHydro = 0;

        [Name(     "Cereal")]
        [Description("Default Game Value: -10\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int cerealHydro = -10;

        [Name(     "Cooked Potato")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int potatoCookedHydro = -3;

        [Name(     "Cured Meat")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int curedMeatHydro = -5;

        [Name(     "Cured Fish")]
        [Description("Default Game Value: -5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int curedFishHydro = -5;

        [Name(     "Dried Apples")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int driedApplesHydro = 0;

        [Name(     "Pickles")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int picklesHydro = 5;

        //OTHER FOOD COOKING TIME
        [Name(     "Acorn (boiling)")]
        [Description("Default Game Value: 12,5 mins\nRealistic Value: 90 mins")]
        [Slider(0, 60, NumberFormat = "{0:d} min")]
        public int acornTime = 12;

        [Name(     "Acorn : Large portion (Boiling)")]
        [Description("Default Game Value: 12,5 mins\nRealistic Value: 90 mins")]
        [Slider(0, 60, NumberFormat = "{0:d} min")]
        public int acornBigTime = 12;

        [Name(     "Cooked Potato")]
        [Description("Default Game Value: 60 mins\nRealistic Value: 20 mins")]
        [Slider(0, 60, NumberFormat = "{0:d} min")]
        public int potatoCookedTime = 60;

        //OTHER FOOD WARMING TIME
        [Name(     "Pinnacle Peaches")]
        [Description("Default Game Value: 15 mins\nRealistic Value: 7 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int pinnaclePeachesWarmTime = 15;

        [Name(     "Pork and Beans")]
        [Description("Default Game Value: 15 mins\nRealistic Value: 7 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int porkAndBeansWarmTime = 15;

        [Name(     "Tomato Soup")]
        [Description("Default Game Value: 15 mins\nRealistic Value: 7 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int tomatoSoupWarmTime = 15;

        [Name(     "Canned Corn")]
        [Description("Default Game Value: 15 mins\nRealistic Value: 7 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int cannedCornWarmTime = 15;

        [Name(     "Canned Pineapple")]
        [Description("Default Game Value: 15 mins\nRealistic Value: 7 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int cannedPineappleWarmTime = 15;

        //RECIPE SECTION
        [Section("Recipe")]
        [Name("Recipe Presets")]
        [Description("Warning : Each preset choice will be applied for all the food characteristics in this section\nGAME DEFAULT: Game values will remain unchanged.\nREALISTIC: Based on real-world values.\nCUSTOM: Set your own values.")]
        [Choice("Current Settings", "Game Default", "Realistic")]
        public PresetChoice presetRecipe = PresetChoice.Custom;

        [Name("Recipe characteristics")]
        [Description("GAME DEFAULT: Game values will remain unchanged.\nREALISTIC: Based on real-world values.\nCUSTOM: Set your own values.")]
        [Choice("Calories", "Vitamin C", "Hydration", "Cooking Time", "Prepping Time", "Warming Time")]
        public RecipeChoice propertyRecipe = RecipeChoice.Calories;

        //RECIPE CALORIES
        [Name(     "Acorn Bannock")]
        [Description("Default Game Value: 250\nRealistic Value: 327")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal ")]
        public int acornBannock = 250;

        [Name(     "Acorn Pancakes")]
        [Description("Default Game Value: 750\nRealistic Value: 808")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int acornPancake = 750;

        [Name(     "Bannock")]
        [Description("Default Game Value: 200\nRealistic Value: 427")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int bannock = 200;

        [Name(     "Breyerhouse Pie")]
        [Description("Default Game Value: 2125\nRealistic Value: 2397")]
        [Slider(500, 3500, 601, NumberFormat = "{0:d} kcal")]
        public int meatPie = 2125;

        [Name(     "Broth")]
        [Description("Default Game Value: 170\nRealistic Value: 48")]
        [Slider(5, 500, 100, NumberFormat = "{0:d} kcal")]
        public int broth = 170;

        [Name(     "Camber Flight Porridge")]
        [Description("Default Game Value: 1250\nRealistic Value: 559")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int fruitPorridge = 1250;

        [Name(     "Coastal Fishcakes")]
        [Description("Default Game Value: 312\nRealistic Value: 229")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int fishcakes = 312;

        [Name(     "Dockworker's Pie")]
        [Description("Default Game Value: 1500\nRealistic Value: 1421")]
        [Slider(500, 3500, 601, NumberFormat = "{0:d} kcal")]
        public int fishermansPie = 1500;

        [Name(     "Last Resort Soup")]
        [Description("Default Game Value: 800\nRealistic Value: 287")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int soupPotato = 800;

        [Name(     "Lily's Pancakes")]
        [Description("Default Game Value: 1000\nRealistic Value: 1053")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int peachPancake = 1000;

        [Name(     "Pancakes")]
        [Description("Default Game Value: 500\nRealistic Value: 708")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int pancake = 500;

        [Name(     "Peach Pie")]
        [Description("Default Game Value: 250\nRealistic Value: 367")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int peachFruitPie = 250;

        [Name(     "Porridge")]
        [Description("Default Game Value: 350\nRealistic Value: 96")]
        [Slider(5, 1000, 200, NumberFormat = "{0:d} kcal")]
        public int porridge = 350;

        [Name(     "Ptarmigan Pie")]
        [Description("Default Game Value: 250\nRealistic Value: 448")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int ptarmiganMeatPie = 250;

        [Name(     "Ptarmigan Stew")]
        [Description("Default Game Value: 900\nRealistic Value: 738")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int ptarmiganMeatStew = 900;

        [Name(     "Pemmican Bar")]
        [Description("Default Game Value: 450\nRealistic Value: 450")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int pemmicanBar = 450;

        [Name(     "Prepper's Pie")]
        [Description("Default Game Value: 350\nRealistic Value: 1205")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int cookedPieForagers = 350;

        [Name(     "Porter's Soup")]
        [Description("Default Game Value: 1200\nRealistic Value: 420")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int soupPtarmigan = 1200;

        [Name(     "Rabbit Pie")]
        [Description("Default Game Value: 250\nRealistic Value: 440")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int rabbitMeatPie = 250;

        [Name(     "Rabbit Stew")]
        [Description("Default Game Value: 750\nRealistic Value: 714")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int rabbitMeatStew = 750;

        [Name(     "Ranger Stew")]
        [Description("Default Game Value: 1600\nRealistic Value: 1561")]
        [Slider(500, 3500, 601, NumberFormat = "{0:d} kcal")]
        public int meatStew = 1600;

        [Name(     "Rose Hip Pie")]
        [Description("Default Game Value: 225\nRealistic Value: 328")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int roseHipFruitPie = 225;

        [Name(     "Stalker's Pie")]
        [Description("Default Game Value: 1600\nRealistic Value: 1745")]
        [Slider(500, 3500, 601, NumberFormat = "{0:d} kcal")]
        public int predatorPie = 1600;

        [Name(     "Thomson Family Stew")]
        [Description("Default Game Value: 900\nRealistic Value: 994")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int vegetableStew = 900;

        [Name(     "Trout Stew")]
        [Description("Default Game Value: 750\nRealistic Value: 848")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int troutMeatStew = 750;

        [Name(     "Vagabond Soup")]
        [Description("Default Game Value: 550\nRealistic Value: 420")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int soupRabbit = 550;

        [Name(     "Venison Pie")]
        [Description("Default Game Value: 325\nRealistic Value: 480")]
        [Slider(100, 1000, 181, NumberFormat = "{0:d} kcal")]
        public int venisonMeatPie = 325;

        [Name(     "Venison Stew")]
        [Description("Default Game Value: 900\nRealistic Value: 834")]
        [Slider(250, 2000, 351, NumberFormat = "{0:d} kcal")]
        public int venisonStew = 900;

        //RECIPE VITAMIN C
        [Name(     "Acorn Bannock")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int acornBannockVit = 0;

        [Name(     "Acorn Pancakes")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int acornPancakeVit = 0;

        [Name(     "Bannock")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int bannockVit = 0;

        [Name(     "Breyerhouse Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int meatPieVit = 0;

        [Name(     "Broth")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int brothVit = 0;

        [Name(     "Camber Flight Porridge")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int fruitPorridgeVit = 0;

        [Name(     "Coastal Fishcakes")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int fishcakesVit = 0;

        [Name(     "Dockworker's Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int fishermansPieVit = 0;

        [Name(     "Last Resort Soup")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int soupPotatoVit = 0;

        [Name(     "Lily's Pancakes")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int peachPancakeVit = 0;

        [Name(     "Pancakes")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int pancakeVit = 0;

        [Name(     "Peach Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int peachFruitPieVit = 0;

        [Name(     "Porridge")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int porridgeVit = 0;

        [Name(     "Ptarmigan Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int ptarmiganMeatPieVit = 0;

        [Name(     "Ptarmigan Stew")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int ptarmiganMeatStewVit = 0;

        [Name(     "Pemmican Bar")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int pemmicanBarVit = 0;

        [Name(     "Prepper's Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int cookedPieForagersVit = 0;

        [Name(     "Porter's Soup")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int soupPtarmiganVit = 0;

        [Name(     "Rabbit Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int rabbitMeatPieVit = 0;

        [Name(     "Rabbit Stew")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int rabbitMeatStewVit = 0;

        [Name(     "Ranger Stew")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int meatStewVit = 0;

        [Name(     "Rose Hip Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int roseHipFruitPieVit = 0;

        [Name(     "Stalker's Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int predatorPieVit = 0;

        [Name(     "Thomson Family Stew")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int vegetableStewVit = 0;

        [Name(     "Trout Stew")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int troutMeatStewVit = 0;

        [Name(     "Vagabond Soup")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int soupRabbitVit = 0;

        [Name(     "Venison Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int venisonMeatPieVit = 0;

        [Name(     "Venison Stew")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(0, 100, NumberFormat = "{0:d} mg")]
        public int venisonStewVit = 0;

        //RECIPE HYDRATION
        [Name(     "Acorn Bannock")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int acornBannockHydro = -3;

        [Name(     "Acorn Pancakes")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int acornPancakeHydro = -3;

        [Name(     "Bannock")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int bannockHydro = -3;

        [Name(     "Breyerhouse Pie")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int meatPieHydro = -3;

        [Name(     "Broth")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int brothHydro = 5;

        [Name(     "Camber Flight Porridge")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int fruitPorridgeHydro = 0;

        [Name(     "Coastal Fishcakes")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int fishcakesHydro = 0;

        [Name(     "Dockworker's Pie")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int fishermansPieHydro = -3;

        [Name(     "Last Resort Soup")]
        [Description("Default Game Value: 6\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int soupPotatoHydro = 6;

        [Name(     "Lily's Pancakes")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int peachPancakeHydro = 0;

        [Name(     "Pancakes")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int pancakeHydro = -3;

        [Name(     "Peach Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int peachFruitPieHydro = 0;

        [Name(     "Porridge")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int porridgeHydro = 0;

        [Name(     "Ptarmigan Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int ptarmiganMeatPieHydro = 0;

        [Name(     "Ptarmigan Stew")]
        [Description("Default Game Value: 3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int ptarmiganMeatStewHydro = 3;

        [Name(     "Pemmican Bar")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int pemmicanBarHydro = 0;

        [Name(     "Prepper's Pie")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int cookedPieForagersHydro = -3;

        [Name(     "Porter's Soup")]
        [Description("Default Game Value: 6\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int soupPtarmiganHydro = 6;

        [Name(     "Rabbit Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int rabbitMeatPieHydro = 0;

        [Name(     "Rabbit Stew")]
        [Description("Default Game Value: 5\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int rabbitMeatStewHydro = 5;

        [Name(     "Ranger Stew")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int meatStewHydro = -3;

        [Name(     "Rose Hip Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int roseHipFruitPieHydro = 0;
         
        [Name(     "Stalker's Pie")]
        [Description("Default Game Value: -3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int predatorPieHydro = -3;

        [Name(     "Thomson Family Stew")]
        [Description("Default Game Value: 3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int vegetableStewHydro = 3;

        [Name(     "Trout Stew")]
        [Description("Default Game Value: 3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int troutMeatStewHydro = 3;

        [Name(     "Vagabond Soup")]
        [Description("Default Game Value: 6\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int soupRabbitHydro = 6;

        [Name(     "Venison Pie")]
        [Description("Default Game Value: 0\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int venisonMeatPieHydro = 0;

        [Name(     "Venison Stew")]
        [Description("Default Game Value: 3\nRealistic Value: ")]
        [Slider(-50, 50, NumberFormat = "{0:d}%")]
        public int venisonStewHydro = 3;

        //RECIPE PREPPING TIME
        [Name(     "Acorn Bannock")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int acornBannockPrepTime = 10;

        [Name(     "Acorn Pancakes")]
        [Description("Default Game Value: 5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int acornPancakePrepTime = 5;

        [Name(     "Bannock")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int bannockPrepTime = 10;

        [Name(     "Breyerhouse Pie")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int meatPiePrepTime = 20;

        [Name(     "Broth")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int brothPrepTime = 10;

        [Name(     "Camber Flight Porridge")]
        [Description("Default Game Value: 8 mins\nRealistic Value: 8 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int fruitPorridgePrepTime = 8;

        [Name(     "Coastal Fishcakes")]
        [Description("Default Game Value: 15 mins\nRealistic Value: 15 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int fishcakesPrepTime = 15;

        [Name(     "Dockworker's Pie")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int fishermansPiePrepTime = 20;

        [Name(     "Last Resort Soup")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int soupPotatoPrepTime = 10;

        [Name(     "Lily's Pancakes")]
        [Description("Default Game Value: 8 mins\nRealistic Value: 8 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int peachPancakePrepTime = 8;

        [Name(     "Pancakes")]
        [Description("Default Game Value: 5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int pancakePrepTime = 5;

        [Name(     "Peach Pie")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int peachFruitPiePrepTime = 20;

        [Name(     "Porridge")]
        [Description("Default Game Value: 5 mins\nRealistic Value: 5 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int porridgePrepTime = 5;

        [Name(     "Ptarmigan Pie")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int ptarmiganMeatPiePrepTime = 20;

        [Name(     "Ptarmigan Stew")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int ptarmiganMeatStewPrepTime = 20;

        [Name(     "Pemmican Bar")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int pemmicanBarPrepTime = 10;

        [Name(     "Prepper's Pie")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int cookedPieForagersPrepTime = 20;

        [Name(     "Porter's Soup")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int soupPtarmiganPrepTime = 10;

        [Name(     "Rabbit Pie")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int rabbitMeatPiePrepTime = 20;

        [Name(     "Rabbit Stew")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int rabbitMeatStewPrepTime = 20;

        [Name(     "Ranger Stew")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int meatStewPrepTime = 20;

        [Name(     "Rose Hip Pie")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int roseHipFruitPiePrepTime = 20;

        [Name(     "Stalker's Pie")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int predatorPiePrepTime = 20;

        [Name(     "Thomson Family Stew")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int vegetableStewPrepTime = 20;

        [Name(     "Trout Stew")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int troutMeatStewPrepTime = 20;

        [Name(     "Vagabond Soup")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int soupRabbitPrepTime = 10;

        [Name(     "Venison Pie")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int venisonMeatPiePrepTime = 20;

        [Name(     "Venison Stew")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 10 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int venisonStewPrepTime = 20;

        [Name(     "Oil")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 5 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int oilPrepTime = 10;

        //RECIPE COOKING TIME
        [Name(     "Acorn Bannock")]
        [Description("Default Game Value: 40 mins\nRealistic Value: 40 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int acornBannockTime = 40;

        [Name(     "Acorn Pancakes")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int acornPancakeTime = 10;

        [Name(     "Bannock")]
        [Description("Default Game Value: 40 mins\nRealistic Value: 40 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int bannockTime = 40;

        [Name(     "Breyerhouse Pie")]
        [Description("Default Game Value: 80 mins\nRealistic Value: 80 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int meatPieTime = 80;

        [Name(     "Broth")]
        [Description("Default Game Value: 60 mins\nRealistic Value: 60 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int brothTime = 60;

        [Name(     "Camber Flight Porridge")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int fruitPorridgeTime = 20;

        [Name(     "Coastal Fishcakes")]
        [Description("Default Game Value: 30 mins\nRealistic Value: 30 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int fishcakesTime = 30;

        [Name(     "Dockworker's Pie")]
        [Description("Default Game Value: 80 mins\nRealistic Value: 80 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int fishermansPieTime = 80;

        [Name(     "Last Resort Soup")]
        [Description("Default Game Value: 40 mins\nRealistic Value: 40 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int soupPotatoTime = 40;

        [Name(     "Lily's Pancakes")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int peachPancakeTime = 10;

        [Name(     "Pancakes")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int pancakeTime = 10;

        [Name(     "Peach Pie")]
        [Description("Default Game Value: 80 mins\nRealistic Value: 80 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int peachFruitPieTime = 80;

        [Name(     "Porridge")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int porridgeTime = 20;

        [Name(     "Ptarmigan Pie")]
        [Description("Default Game Value: 80 mins\nRealistic Value: 80 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int ptarmiganMeatPieTime = 80;

        [Name(     "Ptarmigan Stew")]
        [Description("Default Game Value: 120 mins\nRealistic Value: 10 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int ptarmiganMeatStewTime = 120;

        [Name(     "Pemmican Bar")]
        [Description("Default Game Value: 10 mins\nRealistic Value: 10 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int pemmicanBarTime = 10;

        [Name(     "Prepper's Pie")]
        [Description("Default Game Value: 80 mins\nRealistic Value: 80 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int cookedPieForagersTime = 80;

        [Name(     "Porter's Soup")]
        [Description("Default Game Value: 40 mins\nRealistic Value: 40 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int soupPtarmiganTime = 40;

        [Name(     "Rabbit Pie")]
        [Description("Default Game Value: 80 mins\nRealistic Value: 80 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int rabbitMeatPieTime = 80;

        [Name(     "Rabbit Stew")]
        [Description("Default Game Value: 120 mins\nRealistic Value: 120 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int rabbitMeatStewTime = 120;

        [Name(     "Ranger Stew")]
        [Description("Default Game Value: 120 mins\nRealistic Value: 120 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int meatStewTime = 120;

        [Name(     "Rose Hip Pie")]
        [Description("Default Game Value: 80 mins\nRealistic Value: 80 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int roseHipFruitPieTime = 80;

        [Name(     "Stalker's Pie")]
        [Description("Default Game Value: 80 mins\nRealistic Value: 80 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int predatorPieTime = 80;

        [Name(     "Thomson Family Stew")]
        [Description("Default Game Value: 120 mins\nRealistic Value: 120 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int vegetableStewTime = 120;

        [Name(     "Trout Stew")]
        [Description("Default Game Value: 120 mins\nRealistic Value: 120 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int troutMeatStewTime = 120;

        [Name(     "Vagabond Soup")]
        [Description("Default Game Value: 40 mins\nRealistic Value: 40 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int soupRabbitTime = 40;

        [Name(     "Venison Pie")]
        [Description("Default Game Value: 80 mins\nRealistic Value: 80 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int venisonMeatPieTime = 80;

        [Name(     "Venison Stew")]
        [Description("Default Game Value: 120 mins\nRealistic Value: 120 mins")]
        [Slider(0, 180, NumberFormat = "{0:d} min")]
        public int venisonStewTime = 120;

        [Name(     "Oil")]
        [Description("Default Game Value: 20 mins\nRealistic Value: 20 mins")]
        [Slider(0, 120, NumberFormat = "{0:d} min")]
        public int oilTime = 20;

        //RECIPE WARMING TIME
        [Name(     "Broth")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int brothWarmTime = 7;

        [Name(     "Last Resort Soup")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int soupPotatoWarmTime = 7;

        [Name(     "Ptarmigan Stew")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int ptarmiganMeatStewWarmTime = 7;

        [Name(     "Porter's Soup")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int soupPtarmiganWarmTime = 7;

        [Name(     "Rabbit Stew")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int rabbitMeatStewWarmTime = 7;

        [Name(     "Ranger Stew")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int meatStewWarmTime = 7;

        [Name(     "Thomson Family Stew")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int vegetableStewWarmTime = 7;

        [Name(     "Trout Stew")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int troutMeatStewWarmTime = 7;

        [Name(     "Vagabond Soup")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:d} min")]
        public int soupRabbitWarmTime = 7;

        [Name(     "Venison Stew")]
        [Description("Default Game Value: 7,5 mins\nRealistic Value: 7,5 mins")]
        [Slider(0, 45, NumberFormat = "{0:D} min")]
        public int venisonStewWarmTime = 7;

        // WARMING BUFF SECTION
        [Section("Warming Up Buff")]
        [Name("Does all cookables get a Warming Up buff ?")]
        [Description("All cookware without Warming Up buff (Fish, Meat, Acorns & all recipes) will now get one")]
        public bool allItemHeating = false;

        [Name(     "Buff Duration (HOURS)")]
        [Description("How long the Warming Up buff lasts.\nGame Defaults: Pinnacle Peaches = 0.75,\nPork & Beans = 1.0, Tomato Soup = 1.0")]
        [Slider(0.25f, 6, 24, NumberFormat = "{0:0.00}")]
        public float warmingUpDuration = 2;

        [Name(     "Buff Initial Warmth increase")]
        [Description("Immediate % increase to Warmth meter.\nGame Defaults: Pinnacle Peaches = 8%,\nPork & Beans = 10%, Tomato Soup = 20%")]
        [Slider(0, 100, NumberFormat = "{0:d}%")]
        public int initialWarmthBonus = 15;

        // MRE SECTION 
        [Section("MRE Self-Heating")]
        [Name("Does MRE self-heat when opened ?")]
        [Description("GAME DEFAULT: No.\nREALITY: Canadian MREs (IMPs) do NOT have self-heating.\nUSA MREs DO have self-heating")]
        public bool mreHeating = false;

        [Name(     "Buff Duration (HOURS)")]
        [Description("How long the Warming Up buff lasts.\nGame Defaults: Pinnacle Peaches = 0.75,\nPork & Beans = 1.0, Tomato Soup = 1.0")]
        [Slider(0.25f, 6, 24, NumberFormat = "{0:0.00}")]
        public float mreWarmingUpDuration = 2;

        [Name(     "Buff Initial Warmth increase")]
        [Description("Immediate % increase to Warmth meter.\nGame Defaults: Pinnacle Peaches = 8%,\nPork & Beans = 10%, Tomato Soup = 20%")]
        [Slider(0, 100, NumberFormat = "{0:d}%")]
        public int mreInitialWarmthBonus = 15;
        
        // COOKING POT SECTION 
        [Section("COOKING POT")]
        [Name("Recycled Can multiplier")]
        [Description("How efficient is the recylced can for cooking or boiling water\nGAME DEFAULT : 1 \nREALISTIC : 1 ")]
        [Slider(0.1f, 2f, 20, NumberFormat = "{0:0.0}")]
        public float recycledCan = 1f;

        [Name("Cooking Pot multiplier")]
        [Description("How efficient is the cooking pot for cooking or boiling water\nGAME DEFAULT : 0.8 \nREALISTIC : 1 ")]
        [Slider(0.1f, 2f, 20, NumberFormat = "{0:0.0}")]
        public float cookingPot = 0.8f;

        [Name("Skillet multiplier")]
        [Description("How efficient is the skillet for cooking or boiling water\nGAME DEFAULT : 0.8 \nREALISTIC : 1 ")]
        [Slider(0.1f, 2f, 20, NumberFormat = "{0:0.0}")]
        public float skillet = 0.8f;

        // WATER SECTION
        [Section("WATER")]
        [Name("Melting snow time")]
        [Description("How long it takes to get 1L of water from melted snow\nGAME DEFAULT : 37,5 mins \nREALISTIC : 5 mins ")]
        [Slider(1, 60, NumberFormat = "{0:0}")]
        public int meltingTime = 37;

        [Name("Boiling water time")]
        [Description("How long it takes to boil 1L of water\nGAME DEFAULT : 37,5 mins \nREALISTIC : 10 mins ")]
        [Slider(1, 60, NumberFormat = "{0:0}")]
        public int boilingTime = 37;

        [Name("Evaporating water time")]
        [Description("How long it takes to get 1L of boiling water to evaporate\nGAME DEFAULT : 30 mins \nREALISTIC : 30 mins ")]
        [Slider(1, 60, NumberFormat = "{0:0}")]
        public int evaporatingTime = 30;

        internal void ApplyPresetMeat()
        {
            var preset = this.presetMeat;
            var choice = this.propertyMeat;
            Reload();
            this.propertyMeat = choice;

            if (preset == PresetChoice.Default)
            {
                this.presetMeat = PresetChoice.Default;
                // MEAT SHRINKAGE
                this.meatShrinkage = Main.defaultMeatShrinkage;

                // MEAT CALORIES
                this.bearCooked = Main.defaultCookedBearCalories;
                this.deerCooked = Main.defaultCookedDeerCalories;
                this.mooseCooked = Main.defaultCookedMooseCalories;
                this.ptarmiganCooked = Main.defaultCookedPtarmiganCalories;
                this.rabbitCooked = Main.defaultCookedRabbitCalories;
                this.wolfCooked = Main.defaultCookedWolfCalories;
                this.cougarCooked = Main.defaultCookedCougarCalories;

                // MEAT VITAMIN C
                this.bearCookedVit = Main.defaultCookedBearVit;
                this.deerCookedVit = Main.defaultCookedDeerVit;
                this.mooseCookedVit = Main.defaultCookedMooseVit;
                this.ptarmiganCookedVit = Main.defaultCookedPtarmiganVit;
                this.rabbitCookedVit = Main.defaultCookedRabbitVit;
                this.wolfCookedVit = Main.defaultCookedWolfVit;
                this.cougarCookedVit = Main.defaultCookedCougarVit;

                // MEAT HYDRATION
                this.bearCookedHydro = Main.defaultCookedBearHydro;
                this.deerCookedHydro = Main.defaultCookedDeerHydro;
                this.mooseCookedHydro = Main.defaultCookedMooseHydro;
                this.ptarmiganCookedHydro = Main.defaultCookedPtarmiganHydro;
                this.rabbitCookedHydro = Main.defaultCookedRabbitHydro;
                this.wolfCookedHydro = Main.defaultCookedWolfHydro;
                this.cougarCookedHydro = Main.defaultCookedCougarHydro;

                // MEAT COOKING TIME
                this.bearCookedTime = Main.defaultBearTime;
                this.deerCookedTime = Main.defaultDeerTime;
                this.mooseCookedTime = Main.defaultMooseTime;
                this.ptarmiganCookedTime = Main.defaultPtarmiganTime;
                this.rabbitCookedTime = Main.defaultRabbitTime;
                this.wolfCookedTime = Main.defaultWolfTime;
                this.cougarCookedTime = Main.defaultCougarTime;
            }
            else if (preset == PresetChoice.Realistic)
            {
                this.presetMeat = PresetChoice.Realistic;
                // MEAT SHRINKAGE
                this.meatShrinkage = Main.realisticMeatShrinkage;

                // MEAT CALORIES
                this.bearCooked = Main.realisticCookedBearCalories;
                this.deerCooked = Main.realisticCookedDeerCalories;
                this.mooseCooked = Main.realisticCookedMooseCalories;
                this.ptarmiganCooked = Main.realisticCookedPtarmiganCalories;
                this.rabbitCooked = Main.realisticCookedRabbitCalories;
                this.wolfCooked = Main.realisticCookedWolfCalories;
                this.cougarCooked = Main.realisticCookedCougarCalories;

                // MEAT VITAMIN C
                this.bearCookedVit = Main.realisticCookedBearVit;
                this.deerCookedVit = Main.realisticCookedDeerVit;
                this.mooseCookedVit = Main.realisticCookedMooseVit;
                this.ptarmiganCookedVit = Main.realisticCookedPtarmiganVit;
                this.rabbitCookedVit = Main.realisticCookedRabbitVit;
                this.wolfCookedVit = Main.realisticCookedWolfVit;
                this.cougarCookedVit = Main.realisticCookedCougarVit;

                // MEAT HYDRATION
                this.bearCookedHydro = Main.realisticCookedBearHydro;
                this.deerCookedHydro = Main.realisticCookedDeerHydro;
                this.mooseCookedHydro = Main.realisticCookedMooseHydro;
                this.ptarmiganCookedHydro = Main.realisticCookedPtarmiganHydro;
                this.rabbitCookedHydro = Main.realisticCookedRabbitHydro;
                this.wolfCookedHydro = Main.realisticCookedWolfHydro;
                this.cougarCookedHydro = Main.realisticCookedCougarHydro;

                // MEAT COOKING TIME
                this.bearCookedTime = Main.realisticBearTime;
                this.deerCookedTime = Main.realisticDeerTime;
                this.mooseCookedTime = Main.realisticMooseTime;
                this.ptarmiganCookedTime = Main.realisticPtarmiganTime;
                this.rabbitCookedTime = Main.realisticRabbitTime;
                this.wolfCookedTime = Main.realisticWolfTime;
                this.cougarCookedTime = Main.realisticCougarTime;
            }

            RefreshGUI();
        }

        internal void ApplyPresetFish()
        {
            var preset = this.presetFish;
            var choice = this.propertyFish;
            Reload();
            this.propertyFish = choice;

            if (preset == PresetChoice.Default)
            {
                this.presetFish = PresetChoice.Default;
                // FISH SHRINKAGE
                this.fishShrinkage = Main.defaultFishShrinkage;

                // FISH CALORIES
                this.salmonCooked = Main.defaultCookedSalmonCalories;
                this.whitefishCooked = Main.defaultCookedWhitefishCalories;
                this.troutCooked = Main.defaultCookedTroutCalories;
                this.bassCooked = Main.defaultCookedBassCalories;
                this.burbotCooked = Main.defaultCookedBurbotCalories;
                this.goldeyeCooked = Main.defaultCookedGoldeyeCalories;
                this.redIrishLordCooked = Main.defaultCookedRedIrishLordCalories;
                this.rockfishCooked = Main.defaultCookedRockfishCalories;

                // FISH VITAMIN C
                this.salmonCookedVit = Main.defaultCookedSalmonVit;
                this.whitefishCookedVit = Main.defaultCookedWhitefishVit;
                this.troutCookedVit = Main.defaultCookedTroutVit;
                this.bassCookedVit = Main.defaultCookedBassVit;
                this.burbotCookedVit = Main.defaultCookedBurbotVit;
                this.goldeyeCookedVit = Main.defaultCookedGoldeyeVit;
                this.redIrishLordCookedVit = Main.defaultCookedRedIrishLordVit;
                this.rockfishCookedVit = Main.defaultCookedRockfishVit;

                // FISH HYDRATION
                this.salmonCookedHydro = Main.defaultCookedSalmonHydro;
                this.whitefishCookedHydro = Main.defaultCookedWhitefishHydro;
                this.troutCookedHydro = Main.defaultCookedTroutHydro;
                this.bassCookedHydro = Main.defaultCookedBassHydro;
                this.burbotCookedHydro = Main.defaultCookedBurbotHydro;
                this.goldeyeCookedHydro = Main.defaultCookedGoldeyeHydro;
                this.redIrishLordCookedHydro = Main.defaultCookedRedIrishLordHydro;
                this.rockfishCookedHydro = Main.defaultCookedRockfishHydro;

                // FISH COOKING TIME
                this.salmonCookedTime = Main.defaultSalmonTime;
                this.whitefishCookedTime = Main.defaultWhitefishTime;
                this.troutCookedTime = Main.defaultTroutTime;
                this.bassCookedTime = Main.defaultBassTime;
                this.burbotCookedTime = Main.defaultBurbotTime;
                this.goldeyeCookedTime = Main.defaultGoldeyeTime;
                this.redIrishLordCookedTime = Main.defaultRedIrishLordTime;
                this.rockfishCookedTime = Main.defaultRockfishTime;
            }
            else if (preset == PresetChoice.Realistic)
            {
                this.presetFish = PresetChoice.Realistic;
                // FISH SHRINKAGE
                this.fishShrinkage = Main.realisticFishShrinkage;

                // FISH CALORIES
                this.salmonCooked = Main.realisticCookedSalmonCalories;
                this.whitefishCooked = Main.realisticCookedWhitefishCalories;
                this.troutCooked = Main.realisticCookedTroutCalories;
                this.bassCooked = Main.realisticCookedBassCalories;
                this.burbotCooked = Main.realisticCookedBurbotCalories;
                this.goldeyeCooked = Main.realisticCookedGoldeyeCalories;
                this.redIrishLordCooked = Main.realisticCookedRedIrishLordCalories;
                this.rockfishCooked = Main.realisticCookedRockfishCalories;

                // FISH VITAMIN C
                this.salmonCookedVit = Main.realisticCookedSalmonVit;
                this.whitefishCookedVit = Main.realisticCookedWhitefishVit;
                this.troutCookedVit = Main.realisticCookedTroutVit;
                this.bassCookedVit = Main.realisticCookedBassVit;
                this.burbotCookedVit = Main.realisticCookedBurbotVit;
                this.goldeyeCookedVit = Main.realisticCookedGoldeyeVit;
                this.redIrishLordCookedVit = Main.realisticCookedRedIrishLordVit;
                this.rockfishCookedVit = Main.realisticCookedRockfishVit;

                // FISH HYDRATION
                this.salmonCookedHydro = Main.realisticCookedSalmonHydro;
                this.whitefishCookedHydro = Main.realisticCookedWhitefishHydro;
                this.troutCookedHydro = Main.realisticCookedTroutHydro;
                this.bassCookedHydro = Main.realisticCookedBassHydro;
                this.burbotCookedHydro = Main.realisticCookedBurbotHydro;
                this.goldeyeCookedHydro = Main.realisticCookedGoldeyeHydro;
                this.redIrishLordCookedHydro = Main.realisticCookedRedIrishLordHydro;
                this.rockfishCookedHydro = Main.realisticCookedRockfishHydro;

                // FISH COOKING TIME
                this.salmonCookedTime = Main.realisticFishTime;
                this.whitefishCookedTime = Main.realisticFishTime;
                this.troutCookedTime = Main.realisticFishTime;
                this.bassCookedTime = Main.realisticFishTime;
                this.burbotCookedTime = Main.realisticFishTime;
                this.goldeyeCookedTime = Main.realisticFishTime;
                this.redIrishLordCookedTime = Main.realisticFishTime;
                this.rockfishCookedTime = Main.realisticFishTime;
            }
            RefreshGUI();
        }

        internal void ApplyPresetDrinks()
        {
            var preset = this.presetDrinks;
            var choice = this.propertyDrinks;
            Reload();
            this.propertyDrinks = choice;

            if (preset == PresetChoice.Default)
            {
                this.presetDrinks = PresetChoice.Default;
                //DRINKS CALORIES
                this.acornCoffee = Main.defaultAcornCoffeeCalories;
                this.birchbarkTea = Main.defaultBirchBarkTeaCalories;
                this.burdockTea = Main.defaultBurdockTeaCalories;
                this.coffee = Main.defaultCoffeeCalories;
                this.herbalTea = Main.defaultHerbalTeaCalories;
                this.orangeSoda = Main.defaultOrangeSodaCalories;
                this.goEnergyDrink = Main.defaultGoEnergyDrinkCalories;
                this.reishiTea = Main.defaultReishiTeaCalories;
                this.roseHipTea = Main.defaultRoseHipTeaCalories;
                this.grapeSoda = Main.defaultGrapeSodaCalories;
                this.summitSoda = Main.defaultSummitSodaCalories;
                //DRINKS VITAMIN C
                this.acornCoffeeVit = Main.defaultAcornCoffeeVit;
                this.birchbarkTeaVit = Main.defaultBirchBarkTeaVit;
                this.burdockTeaVit = Main.defaultBurdockTeaVit;
                this.coffeeVit = Main.defaultCoffeeVit;
                this.herbalTeaVit = Main.defaultHerbalTeaVit;
                this.orangeSodaVit = Main.defaultOrangeSodaVit;
                this.goEnergyDrinkVit = Main.defaultGoEnergyDrinkVit;
                this.reishiTeaVit = Main.defaultReishiTeaVit;
                this.roseHipTeaVit = Main.defaultRoseHipTeaVit;
                this.grapeSodaVit = Main.defaultGrapeSodaVit;
                this.summitSodaVit = Main.defaultSummitSodaVit;
                //DRINKS HYDRATION
                this.acornCoffeeHydro = Main.defaultAcornCoffeeHydro;
                this.birchbarkTeaHydro = Main.defaultBirchBarkTeaHydro;
                this.burdockTeaHydro = Main.defaultBurdockTeaHydro;
                this.coffeeHydro = Main.defaultCoffeeHydro;
                this.herbalTeaHydro = Main.defaultHerbalTeaHydro;
                this.orangeSodaHydro = Main.defaultOrangeSodaHydro;
                this.goEnergyDrinkHydro = Main.defaultGoEnergyDrinkHydro;
                this.reishiTeaHydro = Main.defaultReishiTeaHydro;
                this.roseHipTeaHydro = Main.defaultRoseHipTeaHydro;
                this.grapeSodaHydro = Main.defaultGrapeSodaHydro;
                this.summitSodaHydro = Main.defaultSummitSodaHydro;
                //DRINKS COOKING TIME
                this.acornCoffeeTime = Main.defaultAcornCoffeeTime;
                this.birchbarkTeaTime = Main.defaultBirchBarkTeaTime;
                this.burdockTeaTime = Main.defaultBurdockTeaTime;
                this.coffeeTime = Main.defaultCoffeeTime;
                this.herbalTeaTime = Main.defaultHerbalTeaTime;
                this.reishiTeaTime = Main.defaultReishiTeaTime;
                this.roseHipTeaTime = Main.defaultRoseHipTeaTime;
                //DRINKS WARMING TIME
                this.acornCoffeeWarmTime = Main.defaultAcornCoffeeWarmTime;
                this.birchbarkTeaWarmTime = Main.defaultBirchBarkTeaWarmTime;
                this.burdockTeaWarmTime = Main.defaultBurdockTeaWarmTime;
                this.coffeeWarmTime = Main.defaultCoffeeWarmTime;
                this.herbalTeaWarmTime = Main.defaultHerbalTeaWarmTime;
                this.reishiTeaWarmTime = Main.defaultReishiTeaWarmTime;
                this.roseHipTeaWarmTime = Main.defaultRoseHipTeaWarmTime;
            }
            else if (preset == PresetChoice.Realistic)
            {
                this.presetDrinks = PresetChoice.Realistic;
                //DRINKS CALORIES
                this.acornCoffee = Main.realisticAcornCoffeeCalories;
                this.birchbarkTea = Main.realisticBirchBarkTeaCalories;
                this.burdockTea = Main.realisticBurdockTeaCalories;
                this.coffee = Main.realisticCoffeeCalories;
                this.herbalTea = Main.realisticHerbalTeaCalories;
                this.orangeSoda = Main.realisticOrangeSodaCalories;
                this.goEnergyDrink = Main.realisticGoEnergyDrinkCalories;
                this.reishiTea = Main.realisticReishiTeaCalories;
                this.roseHipTea = Main.realisticRoseHipTeaCalories;
                this.grapeSoda = Main.realisticGrapeSodaCalories;
                this.summitSoda = Main.realisticSummitSodaCalories;
                //DRINKS VITAMIN C
                this.acornCoffeeVit = Main.realisticAcornCoffeeVit;
                this.birchbarkTeaVit = Main.realisticBirchBarkTeaVit;
                this.burdockTeaVit = Main.realisticBurdockTeaVit;
                this.coffeeVit = Main.realisticCoffeeVit;
                this.herbalTeaVit = Main.realisticHerbalTeaVit;
                this.orangeSodaVit = Main.realisticOrangeSodaVit;
                this.goEnergyDrinkVit = Main.realisticGoEnergyDrinkVit;
                this.reishiTeaVit = Main.realisticReishiTeaVit;
                this.roseHipTeaVit = Main.realisticRoseHipTeaVit;
                this.grapeSodaVit = Main.realisticGrapeSodaVit;
                this.summitSodaVit = Main.realisticSummitSodaVit;
                //DRINKS HYDRATION
                this.acornCoffeeHydro = Main.realisticAcornCoffeeHydro;
                this.birchbarkTeaHydro = Main.realisticBirchBarkTeaHydro;
                this.burdockTeaHydro = Main.realisticBurdockTeaHydro;
                this.coffeeHydro = Main.realisticCoffeeHydro;
                this.herbalTeaHydro = Main.realisticHerbalTeaHydro;
                this.orangeSodaHydro = Main.realisticOrangeSodaHydro;
                this.goEnergyDrinkHydro = Main.realisticGoEnergyDrinkHydro;
                this.reishiTeaHydro = Main.realisticReishiTeaHydro;
                this.roseHipTeaHydro = Main.realisticRoseHipTeaHydro;
                this.grapeSodaHydro = Main.realisticGrapeSodaHydro;
                this.summitSodaHydro = Main.realisticSummitSodaHydro;
                //DRINKS COOKING TIME
                this.acornCoffeeTime = Main.realisticAcornCoffeeTime;
                this.birchbarkTeaTime = Main.realisticBirchBarkTeaTime;
                this.burdockTeaTime = Main.realisticBurdockTeaTime;
                this.coffeeTime = Main.realisticCoffeeTime;
                this.herbalTeaTime = Main.realisticHerbalTeaTime;
                this.reishiTeaTime = Main.realisticReishiTeaTime;
                this.roseHipTeaTime = Main.realisticRoseHipTeaTime;
                //DRINKS WARMING TIME
                this.acornCoffeeWarmTime = Main.realisticAcornCoffeeWarmTime;
                this.birchbarkTeaWarmTime = Main.realisticBirchBarkTeaWarmTime;
                this.burdockTeaWarmTime = Main.realisticBurdockTeaWarmTime;
                this.coffeeWarmTime = Main.realisticCoffeeWarmTime;
                this.herbalTeaWarmTime = Main.realisticHerbalTeaWarmTime;
                this.reishiTeaWarmTime = Main.realisticReishiTeaWarmTime;
                this.roseHipTeaWarmTime = Main.realisticRoseHipTeaWarmTime;
            }
            RefreshGUI();
        }

        internal void ApplyPresetOtherFood()
        {
            var preset = this.presetOtherFood;
            var choice = this.propertyOtherFood;
            Reload();
            this.propertyOtherFood = choice;

            if (preset == PresetChoice.Default)
            {
                this.presetOtherFood = PresetChoice.Default;
                //OTHER FOOD CALORIES
                this.acorn = Main.defaultAcornCalories;
                this.acornBig = Main.defaultAcornBigCalories;
                this.airlineChicken = Main.defaultAirlineChickenCalories;
                this.airlineVegetarian = Main.defaultAirlineVegetableCalories;
                this.beefJerky = Main.defaultBeefJerkyCalories;
                this.burdockPrepared = Main.defaultBurdockPreparedCalories;
                this.cattailStalk = Main.defaultCattailStalkCalories;
                this.chocolateBar = Main.defaultChocolateBarCalories;
                this.condensedMilk = Main.defaultCondensedMilkCalories;
                this.dogFood = Main.defaultDogFoodCalories;
                this.energyBar = Main.defaultEnergyBarCalories;
                this.granolaBar = Main.defaultGranolaBarCalories;
                this.ketchupChips = Main.defaultKetchupChipsCalories;
                this.mapleSyrup = Main.defaultMapleSyrupCalories;
                this.mre = Main.defaultMreCalories;
                this.peanutButter = Main.defaultPeanutButterCalories;
                this.pinnaclePeaches = Main.defaultPinnaclePeachesCalories;
                this.porkAndBeans = Main.defaultPorkAndBeansCalories;
                this.saltyCrackers = Main.defaultSaltyCrackersCalories;
                this.sardines = Main.defaultSardinesCalories;
                this.tomatoSoup = Main.defaultTomatoSoupCalories;
                this.cannedCorn = Main.defaultCannedCornCalories;
                this.cannedHam = Main.defaultCannedHamCalories;
                this.carrot = Main.defaultCarrotCalories;
                this.potatoCooked = Main.defaultPotatoCookedCalories;
                this.animalFat = Main.defaultAnimalFatCalories;
                this.cannedPineapple = Main.defaultCannedPineappleCalories;
                this.cereal = Main.defaultCerealCalories;
                this.curedMeat = Main.defaultCuredMeatCalories;
                this.curedFish = Main.defaultCuredFishCalories;
                this.driedApples = Main.defaultDriedApplesCalories;
                this.pickles = Main.defaultPicklesCalories;
                //OTHER FOOD VITAMIN C
                this.acornVit = Main.defaultAcornVit;
                this.acornBigVit = Main.defaultAcornBigVit;
                this.airlineChickenVit = Main.defaultAirlineChickenVit;
                this.airlineVegetarianVit = Main.defaultAirlineVegetableVit;
                this.beefJerkyVit = Main.defaultBeefJerkyVit;
                this.burdockPreparedVit = Main.defaultBurdockPreparedVit;
                this.cattailStalkVit = Main.defaultCattailStalkVit;
                this.chocolateBarVit = Main.defaultChocolateBarVit;
                this.condensedMilkVit = Main.defaultCondensedMilkVit;
                this.dogFoodVit = Main.defaultDogFoodVit;
                this.energyBarVit = Main.defaultEnergyBarVit;
                this.granolaBarVit = Main.defaultGranolaBarVit;
                this.ketchupChipsVit = Main.defaultKetchupChipsVit;
                this.mapleSyrupVit = Main.defaultMapleSyrupVit;
                this.mreVit = Main.defaultMreVit;
                this.peanutButterVit = Main.defaultPeanutButterVit;
                this.pinnaclePeachesVit = Main.defaultPinnaclePeachesVit;
                this.porkAndBeansVit = Main.defaultPorkAndBeansVit;
                this.saltyCrackersVit = Main.defaultSaltyCrackersVit;
                this.sardinesVit = Main.defaultSardinesVit;
                this.tomatoSoupVit = Main.defaultTomatoSoupVit;
                this.cannedCornVit = Main.defaultCannedCornVit;
                this.cannedHamVit = Main.defaultCannedHamVit;
                this.carrotVit = Main.defaultCarrotVit;
                this.potatoCookedVit = Main.defaultPotatoCookedVit;
                this.animalFatVit = Main.defaultAnimalFatVit;
                this.cannedPineappleVit = Main.defaultCannedPineappleVit;
                this.cerealVit = Main.defaultCerealVit;
                this.curedMeatVit = Main.defaultCuredMeatVit;
                this.curedFishVit = Main.defaultCuredFishVit;
                this.driedApplesVit = Main.defaultDriedApplesVit;
                this.picklesVit = Main.defaultPicklesVit;
                //OTHER FOOD HYDRATION
                this.acornHydro = Main.defaultAcornHydro;
                this.acornBigHydro = Main.defaultAcornBigHydro;
                this.airlineChickenHydro = Main.defaultAirlineChickenHydro;
                this.airlineVegetarianHydro = Main.defaultAirlineVegetableHydro;
                this.beefJerkyHydro = Main.defaultBeefJerkyHydro;
                this.burdockPreparedHydro = Main.defaultBurdockPreparedHydro;
                this.cattailStalkHydro = Main.defaultCattailStalkHydro;
                this.chocolateBarHydro = Main.defaultChocolateBarHydro;
                this.condensedMilkHydro = Main.defaultCondensedMilkHydro;
                this.dogFoodHydro = Main.defaultDogFoodHydro;
                this.energyBarHydro = Main.defaultEnergyBarHydro;
                this.granolaBarHydro = Main.defaultGranolaBarHydro;
                this.ketchupChipsHydro = Main.defaultKetchupChipsHydro;
                this.mapleSyrupHydro = Main.defaultMapleSyrupHydro;
                this.mreHydro = Main.defaultMreHydro;
                this.peanutButterHydro = Main.defaultPeanutButterHydro;
                this.pinnaclePeachesHydro = Main.defaultPinnaclePeachesHydro;
                this.porkAndBeansHydro = Main.defaultPorkAndBeansHydro;
                this.saltyCrackersHydro = Main.defaultSaltyCrackersHydro;
                this.sardinesHydro = Main.defaultSardinesHydro;
                this.tomatoSoupHydro = Main.defaultTomatoSoupHydro;
                this.cannedCornHydro = Main.defaultCannedCornHydro;
                this.cannedHamHydro = Main.defaultCannedHamHydro;
                this.carrotHydro = Main.defaultCarrotHydro;
                this.potatoCookedHydro = Main.defaultPotatoCookedHydro;
                this.animalFatHydro = Main.defaultAnimalFatHydro;
                this.cannedPineappleHydro = Main.defaultCannedPineappleHydro;
                this.cerealHydro = Main.defaultCerealHydro;
                this.curedMeatHydro = Main.defaultCuredMeatHydro;
                this.curedFishHydro = Main.defaultCuredFishHydro;
                this.driedApplesHydro = Main.defaultDriedApplesHydro;
                this.picklesHydro = Main.defaultPicklesHydro;
                //OTHER FOOD COOKING TIME
                this.acornTime = Main.defaultAcornTime;
                this.acornBigTime = Main.defaultAcornBigTime;
                this.potatoCookedTime = Main.defaultPotatoTime;
                //OTHER FOOD WARMING TIME
                this.pinnaclePeachesWarmTime = Main.defaultPinnaclePeachesWarmTime;
                this.porkAndBeansWarmTime = Main.defaultPorkAndBeansWarmTime;
                this.tomatoSoupWarmTime = Main.defaultTomatoSoupWarmTime;
                this.cannedCornWarmTime = Main.defaultCannedCornWarmTime;
                this.cannedPineappleWarmTime = Main.defaultCannedPineappleWarmTime;
            }
            else if (preset == PresetChoice.Realistic)
            {
                this.presetOtherFood = PresetChoice.Realistic;
                //OTHER FOOD CALORIES
                this.acorn = Main.realisticAcornCalories;
                this.acornBig = Main.realisticAcornBigCalories;
                this.airlineChicken = Main.realisticAirlineChickenCalories;
                this.airlineVegetarian = Main.realisticAirlineVegetableCalories;
                this.beefJerky = Main.realisticBeefJerkyCalories;
                this.burdockPrepared = Main.realisticBurdockPreparedCalories;
                this.cattailStalk = Main.realisticCattailStalkCalories;
                this.chocolateBar = Main.realisticChocolateBarCalories;
                this.condensedMilk = Main.realisticCondensedMilkCalories;
                this.dogFood = Main.realisticDogFoodCalories;
                this.energyBar = Main.realisticEnergyBarCalories;
                this.granolaBar = Main.realisticGranolaBarCalories;
                this.ketchupChips = Main.realisticKetchupChipsCalories;
                this.mapleSyrup = Main.realisticMapleSyrupCalories;
                this.mre = Main.realisticMreCalories;
                this.peanutButter = Main.realisticPeanutButterCalories;
                this.pinnaclePeaches = Main.realisticPinnaclePeachesCalories;
                this.porkAndBeans = Main.realisticPorkAndBeansCalories;
                this.saltyCrackers = Main.realisticSaltyCrackersCalories;
                this.sardines = Main.realisticSardinesCalories;
                this.tomatoSoup = Main.realisticTomatoSoupCalories;
                this.cannedCorn = Main.realisticCannedCornCalories;
                this.cannedHam = Main.realisticCannedHamCalories;
                this.carrot = Main.realisticCarrotCalories;
                this.potatoCooked = Main.realisticPotatoCookedCalories;
                this.animalFat = Main.realisticAnimalFatCalories;
                this.cannedPineapple = Main.realisticCannedPineappleCalories;
                this.cereal = Main.realisticCerealCalories;
                this.curedMeat = Main.realisticCuredMeatCalories;
                this.curedFish = Main.realisticCuredFishCalories;
                this.driedApples = Main.realisticDriedApplesCalories;
                this.pickles = Main.realisticPicklesCalories;
                //OTHER FOOD VITAMIN C
                this.acornVit = Main.realisticAcornVit;
                this.acornBigVit = Main.realisticAcornBigVit;
                this.airlineChickenVit = Main.realisticAirlineChickenVit;
                this.airlineVegetarianVit = Main.realisticAirlineVegetableVit;
                this.beefJerkyVit = Main.realisticBeefJerkyVit;
                this.burdockPreparedVit = Main.realisticBurdockPreparedVit;
                this.cattailStalkVit = Main.realisticCattailStalkVit;
                this.chocolateBarVit = Main.realisticChocolateBarVit;
                this.condensedMilkVit = Main.realisticCondensedMilkVit;
                this.dogFoodVit = Main.realisticDogFoodVit;
                this.energyBarVit = Main.realisticEnergyBarVit;
                this.granolaBarVit = Main.realisticGranolaBarVit;
                this.ketchupChipsVit = Main.realisticKetchupChipsVit;
                this.mapleSyrupVit = Main.realisticMapleSyrupVit;
                this.mreVit = Main.realisticMreVit;
                this.peanutButterVit = Main.realisticPeanutButterVit;
                this.pinnaclePeachesVit = Main.realisticPinnaclePeachesVit;
                this.porkAndBeansVit = Main.realisticPorkAndBeansVit;
                this.saltyCrackersVit = Main.realisticSaltyCrackersVit;
                this.sardinesVit = Main.realisticSardinesVit;
                this.tomatoSoupVit = Main.realisticTomatoSoupVit;
                this.cannedCornVit = Main.realisticCannedCornVit;
                this.cannedHamVit = Main.realisticCannedHamVit;
                this.carrotVit = Main.realisticCarrotVit;
                this.potatoCookedVit = Main.realisticPotatoCookedVit;
                this.animalFatVit = Main.realisticAnimalFatVit;
                this.cannedPineappleVit = Main.realisticCannedPineappleVit;
                this.cerealVit = Main.realisticCerealVit;
                this.curedMeatVit = Main.realisticCuredMeatVit;
                this.curedFishVit = Main.realisticCuredFishVit;
                this.driedApplesVit = Main.realisticDriedApplesVit;
                this.picklesVit = Main.realisticPicklesVit;
                //OTHER FOOD HYDRATION
                this.acornHydro = Main.realisticAcornHydro;
                this.acornBigHydro = Main.realisticAcornBigHydro;
                this.airlineChickenHydro = Main.realisticAirlineChickenHydro;
                this.airlineVegetarianHydro = Main.realisticAirlineVegetableHydro;
                this.beefJerkyHydro = Main.realisticBeefJerkyHydro;
                this.burdockPreparedHydro = Main.realisticBurdockPreparedHydro;
                this.cattailStalkHydro = Main.realisticCattailStalkHydro;
                this.chocolateBarHydro = Main.realisticChocolateBarHydro;
                this.condensedMilkHydro = Main.realisticCondensedMilkHydro;
                this.dogFoodHydro = Main.realisticDogFoodHydro;
                this.energyBarHydro = Main.realisticEnergyBarHydro;
                this.granolaBarHydro = Main.realisticGranolaBarHydro;
                this.ketchupChipsHydro = Main.realisticKetchupChipsHydro;
                this.mapleSyrupHydro = Main.realisticMapleSyrupHydro;
                this.mreHydro = Main.realisticMreHydro;
                this.peanutButterHydro = Main.realisticPeanutButterHydro;
                this.pinnaclePeachesHydro = Main.realisticPinnaclePeachesHydro;
                this.porkAndBeansHydro = Main.realisticPorkAndBeansHydro;
                this.saltyCrackersHydro = Main.realisticSaltyCrackersHydro;
                this.sardinesHydro = Main.realisticSardinesHydro;
                this.tomatoSoupHydro = Main.realisticTomatoSoupHydro;
                this.cannedCornHydro = Main.realisticCannedCornHydro;
                this.cannedHamHydro = Main.realisticCannedHamHydro;
                this.carrotHydro = Main.realisticCarrotHydro;
                this.potatoCookedHydro = Main.realisticPotatoCookedHydro;
                this.animalFatHydro = Main.realisticAnimalFatHydro;
                this.cannedPineappleHydro = Main.realisticCannedPineappleHydro;
                this.cerealHydro = Main.realisticCerealHydro;
                this.curedMeatHydro = Main.realisticCuredMeatHydro;
                this.curedFishHydro = Main.realisticCuredFishHydro;
                this.driedApplesHydro = Main.realisticDriedApplesHydro;
                this.picklesHydro = Main.realisticPicklesHydro;
                //OTHER FOOD COOKING TIME
                this.acornTime = Main.realisticAcornTime;
                this.acornBigTime = Main.realisticAcornBigTime;
                this.potatoCookedTime = Main.realisticPotatoTime;
                //OTHER FOOD WARMING TIME
                this.pinnaclePeachesWarmTime = Main.realisticPinnaclePeachesWarmTime;
                this.porkAndBeansWarmTime = Main.realisticPorkAndBeansWarmTime;
                this.tomatoSoupWarmTime = Main.realisticTomatoSoupWarmTime;
                this.cannedCornWarmTime = Main.realisticCannedCornWarmTime;
                this.cannedPineappleWarmTime = Main.realisticCannedPineappleWarmTime;
            }
            RefreshGUI();
        }

        internal void ApplyPresetRecipe()
        {
            var preset = this.presetRecipe;
            var choice = this.propertyRecipe;
            Reload();
            this.propertyRecipe = choice;

            if (preset == PresetChoice.Default)
            {
                this.presetRecipe = PresetChoice.Default;
                //RECIPES CALORIES
                this.acornBannock = Main.defaultAcornBannockCalories;
                this.acornPancake = Main.defaultAcornPancakeCalories;
                this.bannock = Main.defaultBannockCalories;
                this.fishcakes = Main.defaultFishcakesCalories;
                this.fruitPorridge = Main.defaultFruitPorridgeCalories;
                this.meatPie = Main.defaultMeatPieCalories;
                this.broth = Main.defaultBrothCalories;
                this.fishermansPie = Main.defaultFishermansPieCalories;
                this.peachPancake = Main.defaultPeachPancakeCalories;
                this.pancake = Main.defaultPancakeCalories;
                this.peachFruitPie = Main.defaultPeachFruitPieCalories;
                this.porridge = Main.defaultPorridgeCalories;
                this.ptarmiganMeatPie = Main.defaultPtarmiganMeatPieCalories;
                this.ptarmiganMeatStew = Main.defaultPtarmiganMeatStewCalories;
                this.cookedPieForagers = Main.defaultCookedPieForagersCalories;
                this.rabbitMeatPie = Main.defaultRabbitMeatPieCalories;
                this.rabbitMeatStew = Main.defaultRabbitMeatStewCalories;
                this.meatStew = Main.defaultMeatStewCalories;
                this.roseHipFruitPie = Main.defaultRoseHipFruitPieCalories;
                this.predatorPie = Main.defaultPredatorPieCalories;
                this.vegetableStew = Main.defaultVegetableStewCalories;
                this.troutMeatStew = Main.defaultTroutMeatStewCalories;
                this.venisonMeatPie = Main.defaultVenisonMeatPieCalories;
                this.venisonStew = Main.defaultVenisonStewCalories;
                this.soupPotato = Main.defaultSoupPotatoCalories;
                this.pemmicanBar = Main.defaultPemmicanBarCalories;
                this.soupPtarmigan = Main.defaultSoupPtarmiganCalories;
                this.soupRabbit = Main.defaultSoupRabbitCalories;
                //RECIPES VITAMIN C
                this.acornBannockVit = Main.defaultAcornBannockVit;
                this.acornPancakeVit = Main.defaultAcornPancakeVit;
                this.bannockVit = Main.defaultBannockVit;
                this.fishcakesVit = Main.defaultFishcakesVit;
                this.fruitPorridgeVit = Main.defaultFruitPorridgeVit;
                this.meatPieVit = Main.defaultMeatPieVit;
                this.brothVit = Main.defaultBrothVit;
                this.fishermansPieVit = Main.defaultFishermansPieVit;
                this.peachPancakeVit = Main.defaultPeachPancakeVit;
                this.pancakeVit = Main.defaultPancakeVit;
                this.peachFruitPieVit = Main.defaultPeachFruitPieVit;
                this.porridgeVit = Main.defaultPorridgeVit;
                this.ptarmiganMeatPieVit = Main.defaultPtarmiganMeatPieVit;
                this.ptarmiganMeatStewVit = Main.defaultPtarmiganMeatStewVit;
                this.cookedPieForagersVit = Main.defaultCookedPieForagersVit;
                this.rabbitMeatPieVit = Main.defaultRabbitMeatPieVit;
                this.rabbitMeatStewVit = Main.defaultRabbitMeatStewVit;
                this.meatStewVit = Main.defaultMeatStewVit;
                this.roseHipFruitPieVit = Main.defaultRoseHipFruitPieVit;
                this.predatorPieVit = Main.defaultPredatorPieVit;
                this.vegetableStewVit = Main.defaultVegetableStewVit;
                this.troutMeatStewVit = Main.defaultTroutMeatStewVit;
                this.venisonMeatPieVit = Main.defaultVenisonMeatPieVit;
                this.venisonStewVit = Main.defaultVenisonStewVit;
                this.soupPotatoVit = Main.defaultSoupPotatoVit;
                this.pemmicanBarVit = Main.defaultPemmicanBarVit;
                this.soupPtarmiganVit = Main.defaultSoupPtarmiganVit;
                this.soupRabbitVit = Main.defaultSoupRabbitVit;
                //RECIPES HYDRATION
                this.acornBannockHydro = Main.defaultAcornBannockHydro;
                this.acornPancakeHydro = Main.defaultAcornPancakeHydro;
                this.bannockHydro = Main.defaultBannockHydro;
                this.fishcakesHydro = Main.defaultFishcakesHydro;
                this.fruitPorridgeHydro = Main.defaultFruitPorridgeHydro;
                this.meatPieHydro = Main.defaultMeatPieHydro;
                this.brothHydro = Main.defaultBrothHydro;
                this.fishermansPieHydro = Main.defaultFishermansPieHydro;
                this.peachPancakeHydro = Main.defaultPeachPancakeHydro;
                this.pancakeHydro = Main.defaultPancakeHydro;
                this.peachFruitPieHydro = Main.defaultPeachFruitPieHydro;
                this.porridgeHydro = Main.defaultPorridgeHydro;
                this.ptarmiganMeatPieHydro = Main.defaultPtarmiganMeatPieHydro;
                this.ptarmiganMeatStewHydro = Main.defaultPtarmiganMeatStewHydro;
                this.cookedPieForagersHydro = Main.defaultCookedPieForagersHydro;
                this.rabbitMeatPieHydro = Main.defaultRabbitMeatPieHydro;
                this.rabbitMeatStewHydro = Main.defaultRabbitMeatStewHydro;
                this.meatStewHydro = Main.defaultMeatStewHydro;
                this.roseHipFruitPieHydro = Main.defaultRoseHipFruitPieHydro;
                this.predatorPieHydro = Main.defaultPredatorPieHydro;
                this.vegetableStewHydro = Main.defaultVegetableStewHydro;
                this.troutMeatStewHydro = Main.defaultTroutMeatStewHydro;
                this.venisonMeatPieHydro = Main.defaultVenisonMeatPieHydro;
                this.venisonStewHydro = Main.defaultVenisonStewHydro;
                this.soupPotatoHydro = Main.defaultSoupPotatoHydro;
                this.pemmicanBarHydro = Main.defaultPemmicanBarHydro;
                this.soupPtarmiganHydro = Main.defaultSoupPtarmiganHydro;
                this.soupRabbitHydro = Main.defaultSoupRabbitHydro;
                //RECIPES PREPPING TIME
                this.acornBannockPrepTime = Main.defaultAcornBannockPrepTime;
                this.acornPancakePrepTime = Main.defaultAcornPancakePrepTime;
                this.bannockPrepTime = Main.defaultBannockPrepTime;
                this.fishcakesPrepTime = Main.defaultFishcakesPrepTime;
                this.fruitPorridgePrepTime = Main.defaultFruitPorridgePrepTime;
                this.meatPiePrepTime = Main.defaultMeatPiePrepTime;
                this.brothPrepTime = Main.defaultBrothPrepTime;
                this.fishermansPiePrepTime = Main.defaultFishermansPiePrepTime;
                this.peachPancakePrepTime = Main.defaultPeachPancakePrepTime;
                this.pancakePrepTime = Main.defaultPancakePrepTime;
                this.peachFruitPiePrepTime = Main.defaultPeachFruitPiePrepTime;
                this.porridgePrepTime = Main.defaultPorridgePrepTime;
                this.ptarmiganMeatPiePrepTime = Main.defaultPtarmiganMeatPiePrepTime;
                this.ptarmiganMeatStewPrepTime = Main.defaultPtarmiganMeatStewPrepTime;
                this.cookedPieForagersPrepTime = Main.defaultCookedPieForagersPrepTime;
                this.rabbitMeatPiePrepTime = Main.defaultRabbitMeatPiePrepTime;
                this.rabbitMeatStewPrepTime = Main.defaultRabbitMeatStewPrepTime;
                this.meatStewPrepTime = Main.defaultMeatStewPrepTime;
                this.roseHipFruitPiePrepTime = Main.defaultRoseHipFruitPiePrepTime;
                this.predatorPiePrepTime = Main.defaultPredatorPiePrepTime;
                this.vegetableStewPrepTime = Main.defaultVegetableStewPrepTime;
                this.troutMeatStewPrepTime = Main.defaultTroutMeatStewPrepTime;
                this.venisonMeatPiePrepTime = Main.defaultVenisonMeatPiePrepTime;
                this.venisonStewPrepTime = Main.defaultVenisonStewPrepTime;
                this.soupPotatoPrepTime = Main.defaultSoupPotatoPrepTime;
                this.pemmicanBarPrepTime = Main.defaultPemmicanBarPrepTime;
                this.soupPtarmiganPrepTime = Main.defaultSoupPtarmiganPrepTime;
                this.soupRabbitPrepTime = Main.defaultSoupRabbitPrepTime;
                //RECIPES COOKING TIME
                this.acornBannockTime = Main.defaultAcornBannockTime;
                this.acornPancakeTime = Main.defaultAcornPancakeTime;
                this.bannockTime = Main.defaultBannockTime;
                this.fishcakesTime = Main.defaultFishcakesTime;
                this.fruitPorridgeTime = Main.defaultFruitPorridgeTime;
                this.meatPieTime = Main.defaultMeatPieTime;
                this.brothTime = Main.defaultBrothTime;
                this.fishermansPieTime = Main.defaultFishermansPieTime;
                this.peachPancakeTime = Main.defaultPeachPancakeTime;
                this.pancakeTime = Main.defaultPancakeTime;
                this.peachFruitPieTime = Main.defaultPeachFruitPieTime;
                this.porridgeTime = Main.defaultPorridgeTime;
                this.ptarmiganMeatPieTime = Main.defaultPtarmiganMeatPieTime;
                this.ptarmiganMeatStewTime = Main.defaultPtarmiganMeatStewTime;
                this.cookedPieForagersTime = Main.defaultCookedPieForagersTime;
                this.rabbitMeatPieTime = Main.defaultRabbitMeatPieTime;
                this.rabbitMeatStewTime = Main.defaultRabbitMeatStewTime;
                this.meatStewTime = Main.defaultMeatStewTime;
                this.roseHipFruitPieTime = Main.defaultRoseHipFruitPieTime;
                this.predatorPieTime = Main.defaultPredatorPieTime;
                this.vegetableStewTime = Main.defaultVegetableStewTime;
                this.troutMeatStewTime = Main.defaultTroutMeatStewTime;
                this.venisonMeatPieTime = Main.defaultVenisonMeatPieTime;
                this.venisonStewTime = Main.defaultVenisonStewTime;
                this.soupPotatoTime = Main.defaultSoupPotatoTime;
                this.pemmicanBarTime = Main.defaultPemmicanBarTime;
                this.soupPtarmiganTime = Main.defaultSoupPtarmiganTime;
                this.soupRabbitTime = Main.defaultSoupRabbitTime;
                //RECIPES WARMING TIME TIME
                this.brothWarmTime = Main.defaultBrothWarmTime;
                this.ptarmiganMeatStewWarmTime = Main.defaultPtarmiganMeatStewWarmTime;
                this.rabbitMeatStewWarmTime = Main.defaultRabbitMeatStewWarmTime;
                this.meatStewWarmTime = Main.defaultMeatStewWarmTime;
                this.vegetableStewWarmTime = Main.defaultVegetableStewWarmTime;
                this.troutMeatStewWarmTime = Main.defaultTroutMeatStewWarmTime;
                this.venisonStewWarmTime = Main.defaultVenisonStewWarmTime;
                this.soupPotatoWarmTime = Main.defaultSoupPotatoWarmTime;
                this.soupPtarmiganWarmTime = Main.defaultSoupPtarmiganWarmTime;
                this.soupRabbitWarmTime = Main.defaultSoupRabbitWarmTime;
            }
            else if (preset == PresetChoice.Realistic)
            {
                this.presetRecipe = PresetChoice.Realistic;
                //RECIPES CALORIES
                this.acornBannock = Main.realisticAcornBannockCalories;
                this.acornPancake = Main.realisticAcornPancakeCalories;
                this.bannock = Main.realisticBannockCalories;
                this.fishcakes = Main.realisticFishcakesCalories;
                this.fruitPorridge = Main.realisticFruitPorridgeCalories;
                this.meatPie = Main.realisticMeatPieCalories;
                this.broth = Main.realisticBrothCalories;
                this.fishermansPie = Main.realisticFishermansPieCalories;
                this.peachPancake = Main.realisticPeachPancakeCalories;
                this.pancake = Main.realisticPancakeCalories;
                this.peachFruitPie = Main.realisticPeachFruitPieCalories;
                this.porridge = Main.realisticPorridgeCalories;
                this.ptarmiganMeatPie = Main.realisticPtarmiganMeatPieCalories;
                this.ptarmiganMeatStew = Main.realisticPtarmiganMeatStewCalories;
                this.cookedPieForagers = Main.realisticCookedPieForagersCalories;
                this.rabbitMeatPie = Main.realisticRabbitMeatPieCalories;
                this.rabbitMeatStew = Main.realisticRabbitMeatStewCalories;
                this.meatStew = Main.realisticMeatStewCalories;
                this.roseHipFruitPie = Main.realisticRoseHipFruitPieCalories;
                this.predatorPie = Main.realisticPredatorPieCalories;
                this.vegetableStew = Main.realisticVegetableStewCalories;
                this.troutMeatStew = Main.realisticTroutMeatStewCalories;
                this.venisonMeatPie = Main.realisticVenisonMeatPieCalories;
                this.venisonStew = Main.realisticVenisonStewCalories;
                this.soupPotato = Main.realisticSoupPotatoCalories;
                this.pemmicanBar = Main.realisticPemmicanBarCalories;
                this.soupPtarmigan = Main.realisticSoupPtarmiganCalories;
                this.soupRabbit = Main.realisticSoupRabbitCalories;
                //RECIPES VITAMIN C
                this.acornBannockVit = Main.realisticAcornBannockVit;
                this.acornPancakeVit = Main.realisticAcornPancakeVit;
                this.bannockVit = Main.realisticBannockVit;
                this.fishcakesVit = Main.realisticFishcakesVit;
                this.fruitPorridgeVit = Main.realisticFruitPorridgeVit;
                this.meatPieVit = Main.realisticMeatPieVit;
                this.brothVit = Main.realisticBrothVit;
                this.fishermansPieVit = Main.realisticFishermansPieVit;
                this.peachPancakeVit = Main.realisticPeachPancakeVit;
                this.pancakeVit = Main.realisticPancakeVit;
                this.peachFruitPieVit = Main.realisticPeachFruitPieVit;
                this.porridgeVit = Main.realisticPorridgeVit;
                this.ptarmiganMeatPieVit = Main.realisticPtarmiganMeatPieVit;
                this.ptarmiganMeatStewVit = Main.realisticPtarmiganMeatStewVit;
                this.cookedPieForagersVit = Main.realisticCookedPieForagersVit;
                this.rabbitMeatPieVit = Main.realisticRabbitMeatPieVit;
                this.rabbitMeatStewVit = Main.realisticRabbitMeatStewVit;
                this.meatStewVit = Main.realisticMeatStewVit;
                this.roseHipFruitPieVit = Main.realisticRoseHipFruitPieVit;
                this.predatorPieVit = Main.realisticPredatorPieVit;
                this.vegetableStewVit = Main.realisticVegetableStewVit;
                this.troutMeatStewVit = Main.realisticTroutMeatStewVit;
                this.venisonMeatPieVit = Main.realisticVenisonMeatPieVit;
                this.venisonStewVit = Main.realisticVenisonStewVit;
                this.soupPotatoVit = Main.realisticSoupPotatoVit;
                this.pemmicanBarVit = Main.realisticPemmicanBarVit;
                this.soupPtarmiganVit = Main.realisticSoupPtarmiganVit;
                this.soupRabbitVit = Main.realisticSoupRabbitVit;
                //RECIPES HYDRATION
                this.acornBannockHydro = Main.realisticAcornBannockHydro;
                this.acornPancakeHydro = Main.realisticAcornPancakeHydro;
                this.bannockHydro = Main.realisticBannockHydro;
                this.fishcakesHydro = Main.realisticFishcakesHydro;
                this.fruitPorridgeHydro = Main.realisticFruitPorridgeHydro;
                this.meatPieHydro = Main.realisticMeatPieHydro;
                this.brothHydro = Main.realisticBrothHydro;
                this.fishermansPieHydro = Main.realisticFishermansPieHydro;
                this.peachPancakeHydro = Main.realisticPeachPancakeHydro;
                this.pancakeHydro = Main.realisticPancakeHydro;
                this.peachFruitPieHydro = Main.realisticPeachFruitPieHydro;
                this.porridgeHydro = Main.realisticPorridgeHydro;
                this.ptarmiganMeatPieHydro = Main.realisticPtarmiganMeatPieHydro;
                this.ptarmiganMeatStewHydro = Main.realisticPtarmiganMeatStewHydro;
                this.cookedPieForagersHydro = Main.realisticCookedPieForagersHydro;
                this.rabbitMeatPieHydro = Main.realisticRabbitMeatPieHydro;
                this.rabbitMeatStewHydro = Main.realisticRabbitMeatStewHydro;
                this.meatStewHydro = Main.realisticMeatStewHydro;
                this.roseHipFruitPieHydro = Main.realisticRoseHipFruitPieHydro;
                this.predatorPieHydro = Main.realisticPredatorPieHydro;
                this.vegetableStewHydro = Main.realisticVegetableStewHydro;
                this.troutMeatStewHydro = Main.realisticTroutMeatStewHydro;
                this.venisonMeatPieHydro = Main.realisticVenisonMeatPieHydro;
                this.venisonStewHydro = Main.realisticVenisonStewHydro;
                this.soupPotatoHydro = Main.realisticSoupPotatoHydro;
                this.pemmicanBarHydro = Main.realisticPemmicanBarHydro;
                this.soupPtarmiganHydro = Main.realisticSoupPtarmiganHydro;
                this.soupRabbitHydro = Main.realisticSoupRabbitHydro;
                //RECIPES PREPPING TIME
                this.acornBannockPrepTime = Main.realisticAcornBannockPrepTime;
                this.acornPancakePrepTime = Main.realisticAcornPancakePrepTime;
                this.bannockPrepTime = Main.realisticBannockPrepTime;
                this.fishcakesPrepTime = Main.realisticFishcakesPrepTime;
                this.fruitPorridgePrepTime = Main.realisticFruitPorridgePrepTime;
                this.meatPiePrepTime = Main.realisticMeatPiePrepTime;
                this.brothPrepTime = Main.realisticBrothPrepTime;
                this.fishermansPiePrepTime = Main.realisticFishermansPiePrepTime;
                this.peachPancakePrepTime = Main.realisticPeachPancakePrepTime;
                this.pancakePrepTime = Main.realisticPancakePrepTime;
                this.peachFruitPiePrepTime = Main.realisticPeachFruitPiePrepTime;
                this.porridgePrepTime = Main.realisticPorridgePrepTime;
                this.ptarmiganMeatPiePrepTime = Main.realisticPtarmiganMeatPiePrepTime;
                this.ptarmiganMeatStewPrepTime = Main.realisticPtarmiganMeatStewPrepTime;
                this.cookedPieForagersPrepTime = Main.realisticCookedPieForagersPrepTime;
                this.rabbitMeatPiePrepTime = Main.realisticRabbitMeatPiePrepTime;
                this.rabbitMeatStewPrepTime = Main.realisticRabbitMeatStewPrepTime;
                this.meatStewPrepTime = Main.realisticMeatStewPrepTime;
                this.roseHipFruitPiePrepTime = Main.realisticRoseHipFruitPiePrepTime;
                this.predatorPiePrepTime = Main.realisticPredatorPiePrepTime;
                this.vegetableStewPrepTime = Main.realisticVegetableStewPrepTime;
                this.troutMeatStewPrepTime = Main.realisticTroutMeatStewPrepTime;
                this.venisonMeatPiePrepTime = Main.realisticVenisonMeatPiePrepTime;
                this.venisonStewPrepTime = Main.realisticVenisonStewPrepTime;
                this.soupPotatoPrepTime = Main.realisticSoupPotatoPrepTime;
                this.pemmicanBarPrepTime = Main.realisticPemmicanBarPrepTime;
                this.soupPtarmiganPrepTime = Main.realisticSoupPtarmiganPrepTime;
                this.soupRabbitPrepTime = Main.realisticSoupRabbitPrepTime;
                //RECIPES COOKING TIME
                this.acornBannockTime = Main.realisticAcornBannockTime;
                this.acornPancakeTime = Main.realisticAcornPancakeTime;
                this.bannockTime = Main.realisticBannockTime;
                this.fishcakesTime = Main.realisticFishcakesTime;
                this.fruitPorridgeTime = Main.realisticFruitPorridgeTime;
                this.meatPieTime = Main.realisticMeatPieTime;
                this.brothTime = Main.realisticBrothTime;
                this.fishermansPieTime = Main.realisticFishermansPieTime;
                this.peachPancakeTime = Main.realisticPeachPancakeTime;
                this.pancakeTime = Main.realisticPancakeTime;
                this.peachFruitPieTime = Main.realisticPeachFruitPieTime;
                this.porridgeTime = Main.realisticPorridgeTime;
                this.ptarmiganMeatPieTime = Main.realisticPtarmiganMeatPieTime;
                this.ptarmiganMeatStewTime = Main.realisticPtarmiganMeatStewTime;
                this.cookedPieForagersTime = Main.realisticCookedPieForagersTime;
                this.rabbitMeatPieTime = Main.realisticRabbitMeatPieTime;
                this.rabbitMeatStewTime = Main.realisticRabbitMeatStewTime;
                this.meatStewTime = Main.realisticMeatStewTime;
                this.roseHipFruitPieTime = Main.realisticRoseHipFruitPieTime;
                this.predatorPieTime = Main.realisticPredatorPieTime;
                this.vegetableStewTime = Main.realisticVegetableStewTime;
                this.troutMeatStewTime = Main.realisticTroutMeatStewTime;
                this.venisonMeatPieTime = Main.realisticVenisonMeatPieTime;
                this.venisonStewTime = Main.realisticVenisonStewTime;
                this.soupPotatoTime = Main.realisticSoupPotatoTime;
                this.pemmicanBarTime = Main.realisticPemmicanBarTime;
                this.soupPtarmiganTime = Main.realisticSoupPtarmiganTime;
                this.soupRabbitTime = Main.realisticSoupRabbitTime;
                //RECIPES WARMING TIME TIME
                this.brothWarmTime = Main.realisticBrothWarmTime;
                this.ptarmiganMeatStewWarmTime = Main.realisticPtarmiganMeatStewWarmTime;
                this.rabbitMeatStewWarmTime = Main.realisticRabbitMeatStewWarmTime;
                this.meatStewWarmTime = Main.realisticMeatStewWarmTime;
                this.vegetableStewWarmTime = Main.realisticVegetableStewWarmTime;
                this.troutMeatStewWarmTime = Main.realisticTroutMeatStewWarmTime;
                this.venisonStewWarmTime = Main.realisticVenisonStewWarmTime;
                this.soupPotatoWarmTime = Main.realisticSoupPotatoWarmTime;
                this.soupPtarmiganWarmTime = Main.realisticSoupPtarmiganWarmTime;
                this.soupRabbitWarmTime = Main.realisticSoupRabbitWarmTime;
            }
            RefreshGUI();
        }

        internal void RefreshFields()
        {
            // ----------------------- MEAT SECTION ----------------------- 
            //MEAT CALORIES
            SetFieldVisible(nameof(bearCooked), Settings.settings.propertyMeat == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(deerCooked), Settings.settings.propertyMeat == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(mooseCooked), Settings.settings.propertyMeat == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(ptarmiganCooked), Settings.settings.propertyMeat == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(rabbitCooked), Settings.settings.propertyMeat == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(wolfCooked), Settings.settings.propertyMeat == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(cougarCooked), Settings.settings.propertyMeat == MeatAndFishChoice.Calories);
            //MEAT VITAMIN C
            SetFieldVisible(nameof(bearCookedVit), Settings.settings.propertyMeat == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(deerCookedVit), Settings.settings.propertyMeat == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(mooseCookedVit), Settings.settings.propertyMeat == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(ptarmiganCookedVit), Settings.settings.propertyMeat == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(rabbitCookedVit), Settings.settings.propertyMeat == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(wolfCookedVit), Settings.settings.propertyMeat == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(cougarCookedVit), Settings.settings.propertyMeat == MeatAndFishChoice.VitaminC);
            //MEAT HYDRATION
            SetFieldVisible(nameof(bearCookedHydro), Settings.settings.propertyMeat == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(deerCookedHydro), Settings.settings.propertyMeat == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(mooseCookedHydro), Settings.settings.propertyMeat == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(ptarmiganCookedHydro), Settings.settings.propertyMeat == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(rabbitCookedHydro), Settings.settings.propertyMeat == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(wolfCookedHydro), Settings.settings.propertyMeat == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(cougarCookedHydro), Settings.settings.propertyMeat == MeatAndFishChoice.Hydration);
            //MEAT COOKING TIME
            SetFieldVisible(nameof(bearCookedTime), Settings.settings.propertyMeat == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(deerCookedTime), Settings.settings.propertyMeat == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(mooseCookedTime), Settings.settings.propertyMeat == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(ptarmiganCookedTime), Settings.settings.propertyMeat == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(rabbitCookedTime), Settings.settings.propertyMeat == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(wolfCookedTime), Settings.settings.propertyMeat == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(cougarCookedTime), Settings.settings.propertyMeat == MeatAndFishChoice.CookingTime);

            // ----------------------- FISH SECTION ----------------------- 
            //FISH CALORIES
            SetFieldVisible(nameof(salmonCooked), Settings.settings.propertyFish == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(whitefishCooked), Settings.settings.propertyFish == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(troutCooked), Settings.settings.propertyFish == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(bassCooked), Settings.settings.propertyFish == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(burbotCooked), Settings.settings.propertyFish == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(goldeyeCooked), Settings.settings.propertyFish == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(redIrishLordCooked), Settings.settings.propertyFish == MeatAndFishChoice.Calories);
            SetFieldVisible(nameof(rockfishCooked), Settings.settings.propertyFish == MeatAndFishChoice.Calories);
            //FISH VITAMIN C
            SetFieldVisible(nameof(salmonCookedVit), Settings.settings.propertyFish == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(whitefishCookedVit), Settings.settings.propertyFish == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(troutCookedVit), Settings.settings.propertyFish == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(bassCookedVit), Settings.settings.propertyFish == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(burbotCookedVit), Settings.settings.propertyFish == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(goldeyeCookedVit), Settings.settings.propertyFish == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(redIrishLordCookedVit), Settings.settings.propertyFish == MeatAndFishChoice.VitaminC);
            SetFieldVisible(nameof(rockfishCookedVit), Settings.settings.propertyFish == MeatAndFishChoice.VitaminC);
            //FISH HYDRATION
            SetFieldVisible(nameof(salmonCookedHydro), Settings.settings.propertyFish == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(whitefishCookedHydro), Settings.settings.propertyFish == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(troutCookedHydro), Settings.settings.propertyFish == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(bassCookedHydro), Settings.settings.propertyFish == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(burbotCookedHydro), Settings.settings.propertyFish == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(goldeyeCookedHydro), Settings.settings.propertyFish == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(redIrishLordCookedHydro), Settings.settings.propertyFish == MeatAndFishChoice.Hydration);
            SetFieldVisible(nameof(rockfishCookedHydro), Settings.settings.propertyFish == MeatAndFishChoice.Hydration);
            //FISH COOKING TIME
            SetFieldVisible(nameof(salmonCookedTime), Settings.settings.propertyFish == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(whitefishCookedTime), Settings.settings.propertyFish == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(troutCookedTime), Settings.settings.propertyFish == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(bassCookedTime), Settings.settings.propertyFish == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(burbotCookedTime), Settings.settings.propertyFish == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(goldeyeCookedTime), Settings.settings.propertyFish == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(redIrishLordCookedTime), Settings.settings.propertyFish == MeatAndFishChoice.CookingTime);
            SetFieldVisible(nameof(rockfishCookedTime), Settings.settings.propertyFish == MeatAndFishChoice.CookingTime);

            // ----------------------- DRINKS SECTION ----------------------- 
            //DRINKS CALORIES
            SetFieldVisible(nameof(acornCoffee), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(birchbarkTea), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(burdockTea), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(coffee), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(herbalTea), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(orangeSoda), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(goEnergyDrink), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(reishiTea), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(roseHipTea), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(grapeSoda), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(summitSoda), Settings.settings.propertyDrinks == OtherFoodChoice.Calories);
            //DRINKS VITAMIN C
            SetFieldVisible(nameof(acornCoffeeVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(birchbarkTeaVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(burdockTeaVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(coffeeVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(herbalTeaVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(orangeSodaVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(goEnergyDrinkVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(reishiTeaVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(roseHipTeaVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(grapeSodaVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(summitSodaVit), Settings.settings.propertyDrinks == OtherFoodChoice.VitaminC);
            //DRINKS HYDRATION
            SetFieldVisible(nameof(acornCoffeeHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(birchbarkTeaHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(burdockTeaHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(coffeeHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(herbalTeaHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(orangeSodaHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(goEnergyDrinkHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(reishiTeaHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(roseHipTeaHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(grapeSodaHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(summitSodaHydro), Settings.settings.propertyDrinks == OtherFoodChoice.Hydration);
            //DRINKS COOKING TIME
            SetFieldVisible(nameof(acornCoffeeTime), Settings.settings.propertyDrinks == OtherFoodChoice.CookingTime);
            SetFieldVisible(nameof(birchbarkTeaTime), Settings.settings.propertyDrinks == OtherFoodChoice.CookingTime);
            SetFieldVisible(nameof(burdockTeaTime), Settings.settings.propertyDrinks == OtherFoodChoice.CookingTime);
            SetFieldVisible(nameof(coffeeTime), Settings.settings.propertyDrinks == OtherFoodChoice.CookingTime);
            SetFieldVisible(nameof(herbalTeaTime), Settings.settings.propertyDrinks == OtherFoodChoice.CookingTime);
            SetFieldVisible(nameof(reishiTeaTime), Settings.settings.propertyDrinks == OtherFoodChoice.CookingTime);
            SetFieldVisible(nameof(roseHipTeaTime), Settings.settings.propertyDrinks == OtherFoodChoice.CookingTime);
            //DRINKS WARMING TIME
            SetFieldVisible(nameof(acornCoffeeWarmTime), Settings.settings.propertyDrinks == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(birchbarkTeaWarmTime), Settings.settings.propertyDrinks == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(burdockTeaWarmTime), Settings.settings.propertyDrinks == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(coffeeWarmTime), Settings.settings.propertyDrinks == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(herbalTeaWarmTime), Settings.settings.propertyDrinks == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(reishiTeaWarmTime), Settings.settings.propertyDrinks == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(roseHipTeaWarmTime), Settings.settings.propertyDrinks == OtherFoodChoice.WarmingTime);

            // ----------------------- OTHER FOOD SECTION ----------------------- 
            //OTHER FOOD CALORIES
            SetFieldVisible(nameof(acorn), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(acornBig), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(airlineChicken), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(airlineVegetarian), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(beefJerky), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(burdockPrepared), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(cattailStalk), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(chocolateBar), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(condensedMilk), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(dogFood), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(energyBar), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(granolaBar), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(ketchupChips), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(mapleSyrup), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(mre), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(peanutButter), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(pinnaclePeaches), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(porkAndBeans), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(saltyCrackers), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(sardines), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(tomatoSoup), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(cannedCorn), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(cannedHam), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(carrot), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(potatoCooked), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(animalFat), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(cannedPineapple), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(cereal), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(curedMeat), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(curedFish), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(driedApples), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            SetFieldVisible(nameof(pickles), Settings.settings.propertyOtherFood == OtherFoodChoice.Calories);
            //OTHER FOOD VITAMIN C
            SetFieldVisible(nameof(acornVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(acornBigVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(airlineChickenVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(airlineVegetarianVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(beefJerkyVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(burdockPreparedVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(cattailStalkVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(chocolateBarVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(condensedMilkVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(dogFoodVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(energyBarVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(granolaBarVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(ketchupChipsVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(mapleSyrupVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(mreVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(peanutButterVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(pinnaclePeachesVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(porkAndBeansVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(saltyCrackersVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(sardinesVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(tomatoSoupVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(cannedCornVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(cannedHamVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(carrotVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(potatoCookedVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(animalFatVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(cannedPineappleVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(cerealVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(curedMeatVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(curedFishVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(driedApplesVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            SetFieldVisible(nameof(picklesVit), Settings.settings.propertyOtherFood == OtherFoodChoice.VitaminC);
            //OTHER FOOD HYDRATION
            SetFieldVisible(nameof(acornHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(acornBigHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(airlineChickenHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(airlineVegetarianHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(beefJerkyHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(burdockPreparedHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(cattailStalkHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(chocolateBarHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(condensedMilkHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(dogFoodHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(energyBarHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(granolaBarHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(ketchupChipsHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(mapleSyrupHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(mreHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(peanutButterHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(pinnaclePeachesHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(porkAndBeansHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(saltyCrackersHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(sardinesHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(tomatoSoupHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(cannedCornHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(cannedHamHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(carrotHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(potatoCookedHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(animalFatHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(cannedPineappleHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(cerealHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(curedMeatHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(curedFishHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(driedApplesHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            SetFieldVisible(nameof(picklesHydro), Settings.settings.propertyOtherFood == OtherFoodChoice.Hydration);
            //OTHER FOOD COOKING TIME
            SetFieldVisible(nameof(acornTime), Settings.settings.propertyOtherFood == OtherFoodChoice.CookingTime);
            SetFieldVisible(nameof(acornBigTime), Settings.settings.propertyOtherFood == OtherFoodChoice.CookingTime);
            SetFieldVisible(nameof(potatoCookedTime), Settings.settings.propertyOtherFood == OtherFoodChoice.CookingTime);
            //OTHER FOOD WARMING TIME
            SetFieldVisible(nameof(pinnaclePeachesWarmTime), Settings.settings.propertyOtherFood == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(porkAndBeansWarmTime), Settings.settings.propertyOtherFood == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(tomatoSoupWarmTime), Settings.settings.propertyOtherFood == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(cannedCornWarmTime), Settings.settings.propertyOtherFood == OtherFoodChoice.WarmingTime);
            SetFieldVisible(nameof(cannedPineappleWarmTime), Settings.settings.propertyOtherFood == OtherFoodChoice.WarmingTime);

            // ----------------------- RECIPES SECTION ----------------------- 
            //RECIPES CALORIES
            SetFieldVisible(nameof(acornBannock), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(acornPancake), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(bannock), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(fishcakes), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(fruitPorridge), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(meatPie), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(broth), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(fishermansPie), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(peachPancake), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(pancake), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(peachFruitPie), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(porridge), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(ptarmiganMeatPie), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(ptarmiganMeatStew), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(cookedPieForagers), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(rabbitMeatPie), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(rabbitMeatStew), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(meatStew), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(roseHipFruitPie), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(predatorPie), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(vegetableStew), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(troutMeatStew), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(venisonMeatPie), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(venisonStew), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(soupPotato), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(pemmicanBar), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(soupPtarmigan), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            SetFieldVisible(nameof(soupRabbit), Settings.settings.propertyRecipe == RecipeChoice.Calories);
            //RECIPES VITAMIN C
            SetFieldVisible(nameof(acornBannockVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(acornPancakeVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(bannockVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(fishcakesVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(fruitPorridgeVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(meatPieVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(brothVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(fishermansPieVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(peachPancakeVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(pancakeVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(peachFruitPieVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(porridgeVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(ptarmiganMeatPieVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(ptarmiganMeatStewVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(cookedPieForagersVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(rabbitMeatPieVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(rabbitMeatStewVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(meatStewVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(roseHipFruitPieVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(predatorPieVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(vegetableStewVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(troutMeatStewVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(venisonMeatPieVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(venisonStewVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(soupPotatoVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(pemmicanBarVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(soupPtarmiganVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            SetFieldVisible(nameof(soupRabbitVit), Settings.settings.propertyRecipe == RecipeChoice.VitaminC);
            //RECIPES HYDRATION
            SetFieldVisible(nameof(acornBannockHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(acornPancakeHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(bannockHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(fishcakesHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(fruitPorridgeHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(meatPieHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(brothHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(fishermansPieHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(peachPancakeHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(pancakeHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(peachFruitPieHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(porridgeHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(ptarmiganMeatPieHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(ptarmiganMeatStewHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(cookedPieForagersHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(rabbitMeatPieHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(rabbitMeatStewHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(meatStewHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(roseHipFruitPieHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(predatorPieHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(vegetableStewHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(troutMeatStewHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(venisonMeatPieHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(venisonStewHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(soupPotatoHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(pemmicanBarHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(soupPtarmiganHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            SetFieldVisible(nameof(soupRabbitHydro), Settings.settings.propertyRecipe == RecipeChoice.Hydration);
            //RECIPES PREPPING TIME
            SetFieldVisible(nameof(acornBannockPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(acornPancakePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(bannockPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(fishcakesPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(fruitPorridgePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(meatPiePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(brothPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(fishermansPiePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(peachPancakePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(pancakePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(peachFruitPiePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(porridgePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(ptarmiganMeatPiePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(ptarmiganMeatStewPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(cookedPieForagersPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(rabbitMeatPiePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(rabbitMeatStewPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(meatStewPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(roseHipFruitPiePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(predatorPiePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(vegetableStewPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(troutMeatStewPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(venisonMeatPiePrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(venisonStewPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(soupPotatoPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(pemmicanBarPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(soupPtarmiganPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(soupRabbitPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            SetFieldVisible(nameof(oilPrepTime), Settings.settings.propertyRecipe == RecipeChoice.PrepTime);
            //RECIPES COOKING TIME
            SetFieldVisible(nameof(acornBannockTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(acornPancakeTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(bannockTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(fishcakesTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(fruitPorridgeTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(meatPieTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(brothTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(fishermansPieTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(peachPancakeTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(pancakeTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(peachFruitPieTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(porridgeTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(ptarmiganMeatPieTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(ptarmiganMeatStewTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(cookedPieForagersTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(rabbitMeatPieTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(rabbitMeatStewTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(meatStewTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(roseHipFruitPieTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(predatorPieTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(vegetableStewTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(troutMeatStewTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(venisonMeatPieTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(venisonStewTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(soupPotatoTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(pemmicanBarTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(soupPtarmiganTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(soupRabbitTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            SetFieldVisible(nameof(oilTime), Settings.settings.propertyRecipe == RecipeChoice.CookingTime);
            //RECIPES WARMING TIME TIME
            SetFieldVisible(nameof(brothWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);
            SetFieldVisible(nameof(ptarmiganMeatStewWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);
            SetFieldVisible(nameof(rabbitMeatStewWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);
            SetFieldVisible(nameof(meatStewWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);
            SetFieldVisible(nameof(vegetableStewWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);
            SetFieldVisible(nameof(troutMeatStewWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);
            SetFieldVisible(nameof(venisonStewWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);
            SetFieldVisible(nameof(soupPotatoWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);
            SetFieldVisible(nameof(soupPtarmiganWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);
            SetFieldVisible(nameof(soupRabbitWarmTime), Settings.settings.propertyRecipe == RecipeChoice.WarmingTime);

            // ----------------------- WARMING UP BUFF SECTION ----------------------- 
            //ALL COOKABLES
            SetFieldVisible(nameof(warmingUpDuration), Settings.settings.allItemHeating);
            SetFieldVisible(nameof(initialWarmthBonus), Settings.settings.allItemHeating);
            //MRE
            SetFieldVisible(nameof(mreWarmingUpDuration), Settings.settings.mreHeating);
            SetFieldVisible(nameof(mreInitialWarmthBonus), Settings.settings.mreHeating);

        }

        protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
        {
            if (field.Name == nameof(presetMeat)) ApplyPresetMeat();
            if (field.Name == nameof(presetFish)) ApplyPresetFish();
            if (field.Name == nameof(presetDrinks)) ApplyPresetDrinks();
            if (field.Name == nameof(presetOtherFood)) ApplyPresetOtherFood();
            if (field.Name == nameof(presetRecipe)) ApplyPresetRecipe();


            if (field.Name == nameof(presetMeat) ||
               field.Name == nameof(propertyMeat) ||
               field.Name == nameof(presetFish) ||
               field.Name == nameof(propertyFish) ||
               field.Name == nameof(presetDrinks) ||
               field.Name == nameof(propertyDrinks) ||
               field.Name == nameof(presetOtherFood) ||
               field.Name == nameof(propertyOtherFood) ||
               field.Name == nameof(presetRecipe) ||
               field.Name == nameof(propertyRecipe) ||
               field.Name == nameof(allItemHeating) ||
               field.Name == nameof(mreHeating))
            {
                RefreshFields();
            }

        }

        protected override void OnConfirm()
        {
            this.presetMeat = PresetChoice.Custom;
            this.presetFish = PresetChoice.Custom;
            this.presetDrinks = PresetChoice.Custom;
            this.presetOtherFood = PresetChoice.Custom;
            this.presetRecipe = PresetChoice.Custom;
            base.OnConfirm();
            Main.ChangePrefabs();
            RefreshGUI();
        }
    }

    internal static class Settings
    {
        public static FoodTweakerSettings settings = new();

        public static void OnLoad()
        {
           settings.AddToModSettings("Food Tweaker");
           settings.RefreshFields();
        }
    }
}
