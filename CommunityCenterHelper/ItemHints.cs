﻿using StardewModdingAPI;
using StardewValley;
using StardewValley.Locations;
using StardewValley.TokenizableStrings;
using System;
using System.Collections.Generic;

namespace CommunityCenterHelper
{
    /// <summary>Provides hint text for how to obtain items.</summary>
    public class ItemHints
    {
        public static ITranslationHelper str;
        public static IModRegistry modRegistry;
        public static ModConfig Config;
        
        /****************************
         ** Main Hint Text Methods **
         ****************************/
        
        /// <summary>Returns hint text for an item, given an item ID and quality.</summary>
        /// <param name="id">The item ID.</param>
        /// <param name="quality">Minimum required quality of item.</param>
        /// <param name="category">The item category, for items that accept anything in the category.</param>
        /// <param name="preservesID">The ID of the base item for artisan goods.</param>
        public static string getHintText(string id, int quality, int? category = 0, string preservesID = null)
        {
            try
            {
                string recipeUnlockTip = "";
                
                switch (id)
                {
                    /********** [Base Game Bundles] Pantry **********/
                    
                    // Spring Crops Bundle
                    
                    case ItemID.IT_Parsnip:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.IT_GreenBean:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.IT_Cauliflower:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.IT_Potato:
                        return strSeasonalCrop("spring", quality);
                    
                    // Summer Crops Bundle
                    
                    case ItemID.IT_Tomato:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.IT_HotPepper:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.IT_Blueberry:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.IT_Melon:
                        return strSeasonalCrop("summer", quality);
                    
                    // Fall Crops Bundle
                    
                    case ItemID.IT_Corn:
                        return strSeasonalCrop(seasonList: new string[] { "summer", "fall" }, quality: quality);
                    
                    case ItemID.IT_Eggplant:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.IT_Pumpkin:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.IT_Yam:
                        return strSeasonalCrop("fall", quality)
                             + (quality == 0? "\n" + strDroppedByMonster("Duggy") : ""); // Base quality only
                    
                    // Animal Bundle
                    
                    case ItemID.IT_LargeMilk:
                        return strAnimalProduct("animalCow", true);
                    
                    case ItemID.IT_LargeEggBrown:
                        return strAnimalProduct("animalChicken", true);
                    
                    case ItemID.IT_LargeEgg:
                        return strAnimalProduct("animalChicken", true);
                    
                    case ItemID.IT_LargeGoatMilk:
                        return strAnimalProduct("animalGoat", true);
                    
                    case ItemID.IT_Wool:
                        return strAnimalProduct("animalSheep") + "\n"
                             + strAnimalProduct("animalRabbit");
                    
                    case ItemID.IT_DuckEgg:
                        return strAnimalProduct("animalDuck");
                    
                    // Artisan Bundle
                    
                    case ItemID.IT_TruffleOil:
                        return strPutItemInMachine(ItemID.IT_Truffle, ItemID.BC_OilMaker);
                    
                    case ItemID.IT_Cloth:
                        return strPutItemInMachine(ItemID.IT_Wool, ItemID.BC_Loom) + "\n"
                             + strPutItemInMachine(ItemID.IT_SoggyNewspaper, ItemID.BC_RecyclingMachine);
                    
                    case ItemID.IT_GoatCheese:
                        return strMachineOrCaskForQuality(ItemID.IT_GoatMilk, ItemID.BC_CheesePress, ItemID.IT_GoatCheese, quality);
                    
                    case ItemID.IT_Cheese:
                        return strMachineOrCaskForQuality(ItemID.IT_Milk, ItemID.BC_CheesePress, ItemID.IT_Cheese, quality);
                    
                    case ItemID.IT_Honey:
                        return strNoItemMachine(ItemID.BC_BeeHouse) + "\n"
                             + strBuyFromOasisWeekday("friday");
                    
                    case ItemID.IT_Jelly:
                        return strPutItemInMachine(preservesID == null? StardewValley.Object.FruitsCategory.ToString() : preservesID,
                                                   ItemID.BC_PreservesJar)
                             + (preservesID != null? "\n" + subItemHints(preservesID) : "");
                    
                    case ItemID.IT_Apple:
                        return strFruitTreeDuringSeason("treeApple", "fall")
                             + possibleSourceFruitBatCave();
                    
                    case ItemID.IT_Apricot:
                        return strFruitTreeDuringSeason("treeApricot", "spring")
                             + possibleSourceFruitBatCave();
                    
                    case ItemID.IT_Orange:
                        return strFruitTreeDuringSeason("treeOrange", "summer")
                             + possibleSourceFruitBatCave();
                    
                    case ItemID.IT_Peach:
                        return strFruitTreeDuringSeason("treePeach", "summer")
                             + possibleSourceFruitBatCave();
                    
                    case ItemID.IT_Pomegranate:
                        return strFruitTreeDuringSeason("treePomegranate", "fall")
                             + possibleSourceFruitBatCave();
                    
                    case ItemID.IT_Cherry:
                        return strFruitTreeDuringSeason("treeCherry", "spring")
                             + possibleSourceFruitBatCave();
                    
                    /********** [Base Game Bundles] Crafts Room **********/
                    
                    // Spring Foraging Bundle
                    
                    case ItemID.IT_WildHorseradish:
                        return strSeasonalForage("spring");
                    
                    case ItemID.IT_Daffodil:
                        return strSeasonalForage("spring") + "\n"
                             + strBuyFrom("shopFlowerDance");
                    
                    case ItemID.IT_Leek:
                        return strSeasonalForage("spring");
                    
                    case ItemID.IT_Dandelion:
                        return strSeasonalForage("spring") + "\n"
                             + strBuyFrom("shopFlowerDance");
                    
                    // Summer Foraging Bundle
                    
                    case ItemID.IT_SpiceBerry:
                        return strSeasonalForage("summer")
                             + possibleSourceFruitBatCave();
                    
                    case ItemID.IT_Grape:
                        return strSeasonalForage("summer") + "\n"
                             + strSeasonalCrop("fall", quality);
                    
                    case ItemID.IT_SweetPea:
                        return strSeasonalForage("summer");
                    
                    // Fall Foraging Bundle
                    
                    case ItemID.IT_CommonMushroom:
                        return strSeasonalForage("fall") + "\n"
                             + strSeasonalLocationalForage(seasonList: new string[] { "spring", "fall" }, locationKey: "locationWoods");
                    
                    case ItemID.IT_WildPlum:
                        return strSeasonalForage("fall")
                             + possibleSourceFruitBatCave();
                    
                    case ItemID.IT_Hazelnut:
                        return strSeasonalForage("fall");
                    
                    case ItemID.IT_Blackberry:
                        return strSeasonalForage("fall")
                             + possibleSourceFruitBatCave();
                    
                    // Winter Foraging Bundle
                    
                    case ItemID.IT_WinterRoot:
                        return strSeasonalTilling("winter") + "\n"
                             + strDroppedByMonster("Frost Jelly");
                    
                    case ItemID.IT_CrystalFruit:
                        return strSeasonalForage("winter") + "\n"
                             + strDroppedByMonster("Dust Spirit");
                    
                    case ItemID.IT_SnowYam:
                        return strSeasonalTilling("winter");
                    
                    case ItemID.IT_Crocus:
                        return strSeasonalForage("winter");
                    
                    // Construction Bundle
                    
                    case ItemID.IT_Wood:
                        return strChopWood() + "\n"
                             + strBuyFrom("shopCarpenter");
                    
                    case ItemID.IT_Stone:
                        return strHitRocks() + "\n"
                             + strBuyFrom("shopCarpenter");
                    
                    case ItemID.IT_Hardwood:
                        return strChopHardwood();
                    
                    // Exotic Foraging Bundle
                    
                    case ItemID.IT_Coconut:
                        return strLocationalForage(isDesertKnown()? "locationDesert" : "locationUnknown") + "\n"
                             + strBuyFromOasisWeekday("monday");
                    
                    case ItemID.IT_CactusFruit:
                        return strLocationalForage(isDesertKnown()? "locationDesert" : "locationUnknown") + "\n"
                             + strBuyFromOasisWeekday("tuesday");
                    
                    case ItemID.IT_CaveCarrot:
                        return str.Get("smashCrates") + "\n"
                             + strLocationalTilling("locationMines");
                    
                    case ItemID.IT_RedMushroom:
                        return strLocationalForage("locationMines") + "\n"
                             + strSeasonalLocationalForage(seasonList: new string[] { "summer", "fall" },
                                                           locationKey: "locationWoods") + "\n"
                             + strTapTree("treeMushroom")
                             + possibleSourceMushroomCave()
                             + possibleSourceSpecialFarmSeasonal("forest", "fall");
                    
                    case ItemID.IT_PurpleMushroom:
                        return strLocationalForage("locationMinesArea3")
                             + possibleSourceMushroomCave()
                             + possibleSourceSpecialFarmSeasonal("forest", "fall");
                    
                    case ItemID.IT_MapleSyrup:
                        return strTapTree("treeMaple");
                    
                    case ItemID.IT_OakResin:
                        return strTapTree("treeOak");
                    
                    case ItemID.IT_PineTar:
                        return strTapTree("treePine");
                    
                    case ItemID.IT_Morel:
                        return strSeasonalLocationalForage("spring", "locationWoods")
                             + possibleSourceMushroomCave()
                             + possibleSourceSpecialFarmSeasonal("forest", "spring");
                    
                    /********** [Base Game Bundles] Fish Tank **********/
                    
                    // River Fish Bundle
                    
                    case ItemID.IT_Sunfish:
                        bool fishableFarm = haveSpecialFarmType("riverlands") || haveSpecialFarmType("wilderness");
                        return strFishBase(waterList: new string[] { "waterRivers", fishableFarm? "waterSpecialFarm" : "" },
                                           start: "6am", end: "7pm",
                                           seasonList: new string[] { "spring", "summer" }, weatherKey: "weatherSun");
                    
                    case ItemID.IT_Catfish:
                        return strFishBase("waterRivers", "6am", "12am", seasonList: new string[] { "spring", "fall", "winter" },
                                           weatherKey: "weatherRain") + "\n"
                             + strFishBase("waterWoods", "6am", "12am", weatherKey: "weatherRain");
                    
                    case ItemID.IT_Shad:
                        return strFishBase("waterRivers", "9am", "2am",
                                           seasonList: new string[] { "spring", "summer", "fall" }, weatherKey: "weatherRain");
                    
                    case ItemID.IT_TigerTrout:
                        return strFishBase("waterRivers", "6am", "7pm",
                                           seasonList: new string[] { "fall", "winter" });
                    
                    // Lake Fish Bundle
                    
                    case ItemID.IT_LargemouthBass:
                        return strFishBase("waterMountain", "6am", "7pm");
                    
                    case ItemID.IT_Carp:
                        return strFishBase("waterMountain", seasonList: new string[] { "spring", "summer", "fall" }) + "\n"
                             + strFishBase(waterList: new string[] { "waterWoods", isSewerKnown()? "waterSewer" : "" });
                    
                    case ItemID.IT_Bullhead:
                        return strFishBase("waterMountain");
                    
                    case ItemID.IT_Sturgeon:
                        return strFishBase("waterMountain", "6am", "7pm", seasonList: new string[] { "summer", "winter" });
                    
                    // Ocean Fish Bundle
                    
                    case ItemID.IT_Sardine:
                        return strFishBase("waterOcean", "6am", "7pm", seasonList: new string[] { "spring", "fall", "winter" });
                    
                    case ItemID.IT_Tuna:
                        return strFishBase("waterOcean", "6am", "7pm", seasonList: new string[] { "summer", "winter" })
                             + (isIslandKnown()? "\n" + strFishBase(waterList: new string[] { "waterIslandOcean", "waterIslandCove" },
                                                                   start: "6am", end: "7pm") : "");
                    
                    case ItemID.IT_RedSnapper:
                        return strFishBase("waterOcean", "6am", "7pm", seasonList: new string[] { "summer", "fall", "winter" },
                                           weatherKey: "weatherRain");
                    
                    case ItemID.IT_Tilapia:
                        return strFishBase("waterOcean", "6am", "2pm", seasonList: new string[] { "summer", "fall" })
                             + (isIslandKnown()? "\n" + strFishBase("waterIslandRiver", "6am", "2pm") : "");
                    
                    // Night Fishing Bundle
                    
                    case ItemID.IT_Walleye:
                        return strFishBase(waterList: new string[] { "waterRivers", "waterMountain", "waterForestPond" },
                                           start: "12pm", end: "2am", seasonList: new string[] { "fall", "winter" },
                                           weatherKey: "weatherRain");
                    
                    case ItemID.IT_Bream:
                        return strFishBase("waterRivers", "6pm", "2am");
                    
                    case ItemID.IT_Eel:
                        return strFishBase("waterOcean", "4pm", "2am", seasonList: new string[] { "spring", "fall" },
                                           weatherKey: "weatherRain");
                    
                    // Crab Pot Bundle
                    
                    case ItemID.IT_Lobster:
                        return strCrabPot("waterTypeOcean");
                    
                    case ItemID.IT_Crayfish:
                        return strCrabPot("waterTypeFresh");
                    
                    case ItemID.IT_Crab:
                        return strCrabPot("waterTypeOcean") + "\n"
                             + strDroppedByMonster("Rock Crab") + "\n"
                             + strDroppedByMonster("Lava Crab");
                    
                    case ItemID.IT_Cockle:
                        return strCrabPot("waterTypeOcean") + "\n"
                             + strLocationalForage("locationBeach");
                    
                    case ItemID.IT_Mussel:
                        return strCrabPot("waterTypeOcean") + "\n"
                             + strLocationalForage("locationBeach");
                    
                    case ItemID.IT_Shrimp:
                        return strCrabPot("waterTypeOcean");
                    
                    case ItemID.IT_Snail:
                        return strCrabPot("waterTypeFresh");
                    
                    case ItemID.IT_Periwinkle:
                        return strCrabPot("waterTypeFresh");
                    
                    case ItemID.IT_Oyster:
                        return strCrabPot("waterTypeOcean") + "\n"
                             + strLocationalForage("locationBeach");
                    
                    case ItemID.IT_Clam:
                        return strCrabPot("waterTypeOcean") + "\n"
                             + strLocationalForage("locationBeach");
                    
                    // Specialty Fish Bundle
                    
                    case ItemID.IT_Pufferfish:
                        return strFishBase("waterOcean", "12pm", "4pm", "summer", "weatherSun")
                             + (isIslandKnown()? "\n" + strFishBase(waterList: new string[] { "waterIslandOcean", "waterIslandCove" },
                                                                   start: "12pm", end: "4pm", weatherKey: "weatherSun") : "");
                    
                    case ItemID.IT_Ghostfish:
                        return strFishBase("waterMines") + "\n"
                             + strDroppedByMonster("Ghost");
                    
                    case ItemID.IT_Sandfish:
                        return strFishBase(isDesertKnown()? "waterDesert" : "waterUnknown", "6am", "8pm");
                    
                    case ItemID.IT_Woodskip:
                        return strFishBase(waterList: new string[] { "waterWoods",
                                                                     haveSpecialFarmType("forest")? "waterSpecialFarm" : "" });
                    
                    /********** [Base Game Bundles] Boiler Room **********/
                    
                    // Blacksmith's Bundle
                    
                    case ItemID.IT_CopperBar:
                        return strPutItemInMachine(ItemID.IT_CopperOre, ItemID.BC_Furnace);
                    
                    case ItemID.IT_IronBar:
                        return strPutItemInMachine(ItemID.IT_IronOre, ItemID.BC_Furnace)
                             + (DataLoader.CraftingRecipes(Game1.content).ContainsKey("Transmute (Fe)")?
                                "\n" + strCraftRecipe("Transmute (Fe)") : ""); // Recipe may be removed by Alchemistry
                    
                    case ItemID.IT_GoldBar:
                        return strPutItemInMachine(ItemID.IT_GoldOre, ItemID.BC_Furnace)
                             + (DataLoader.CraftingRecipes(Game1.content).ContainsKey("Transmute (Au)")?
                                "\n" + strCraftRecipe("Transmute (Au)") : ""); // Recipe may be removed by Alchemistry
                    
                    // Geologist's Bundle
                    
                    case ItemID.IT_Quartz:
                        return strLocationalForage("locationMines");
                    
                    case ItemID.IT_EarthCrystal:
                        return strLocationalForage("locationMinesArea1") + "\n"
                             + strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode) + "\n"
                             + strDroppedByMonster("Duggy") + "\n"
                             + strPanning();
                    
                    case ItemID.IT_FrozenTear:
                        return strLocationalForage("locationMinesArea2") + "\n"
                             + strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode) + "\n"
                             + strDroppedByMonster("Dust Spirit") + "\n"
                             + strPanning();
                    
                    case ItemID.IT_FireQuartz:
                        return strLocationalForage("locationMinesArea3") + "\n"
                             + strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode) + "\n"
                             + strPanning();
                    
                    // Adventurer's Bundle
                    
                    case ItemID.IT_Slime:
                        return strDroppedByMonster(monsterKey: "monsterGeneralSlime");
                    
                    case ItemID.IT_BatWing:
                        return strDroppedByMonster(monsterKey: "monsterGeneralBat");
                    
                    case ItemID.IT_SolarEssence:
                        return strDroppedByMonster("Ghost") + "\n"
                             + strDroppedByMonster("Squid Kid") + "\n"
                             + strDroppedByMonster("Metal Head") + "\n"
                             + strBuyFromKrobus()
                             + (isSkullCavernKnown()? "\n" + strDroppedByMonster("Mummy") : "") + "\n"
                             + strFishPond(ItemID.IT_Sunfish, 10);
                    
                    case ItemID.IT_VoidEssence:
                        return strDroppedByMonster("Shadow Brute") + "\n"
                             + strBuyFromKrobus()
                             + (isSkullCavernKnown()? "\n" + strDroppedByMonster("Serpent") : "") + "\n"
                             + strFishPond(ItemID.IT_VoidSalmon, 9);
                    
                    /********** [Base Game Bundles] Bulletin Board **********/
                    
                    // Chef's Bundle
                    
                    case ItemID.IT_FiddleheadFern:
                        return strSeasonalLocationalForage("summer", "locationWoods");
                    
                    case ItemID.IT_Truffle:
                        return strAnimalProduct("animalPig", mustBeOutside: true);
                        
                    case ItemID.IT_Poppy:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.IT_MakiRoll:
                        return strCookRecipe("Maki Roll") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_FriedEgg:
                        return strCookRecipe("Fried Egg") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    // Dye Bundle
                    
                    case ItemID.IT_SeaUrchin:
                        if (fixedBridgeToEastBeach())
                            return strLocationalForage("locationBeachEast");
                        else
                            return strLocationalForage(locationLiteral: str.Get("locationBeachEastInaccessible",
                                                                                new { wood = getItemName(ItemID.IT_Wood) }));
                    
                    case ItemID.IT_Sunflower:
                        return strSeasonalCrop(seasonList: new string[] { "summer", "fall" }, quality: quality);
                    
                    case ItemID.IT_DuckFeather:
                        return strAnimalProduct("animalDuck", true);
                    
                    case ItemID.IT_Aquamarine:
                        return str.Get("gemAquamarine") + "\n"
                             + str.Get("smashCrates") + "\n"
                             + strFishingChest(2) + "\n"
                             + strPanning();
                    
                    case ItemID.IT_RedCabbage:
                        return strSeasonalCrop("summer", quality, startingYear: 2);
                    
                    // Field Research Bundle
                    
                    case ItemID.IT_NautilusShell:
                        return strSeasonalLocationalForage("winter", "locationBeach");
                    
                    case ItemID.IT_Chub:
                        return strFishBase(waterList: new string[] { "waterMountain", "waterForestRiver" });
                    
                    case ItemID.IT_FrozenGeode:
                        return strHitRocks("locationMinesArea2") + "\n"
                             + strSeasonalLocationalForage("winter", "locationFarm") + "\n"
                             + strFishingChest() + "\n"
                             + strFishPond(ItemID.IT_IcePip, 9);
                    
                    // Fodder Bundle
                    
                    case ItemID.IT_Wheat:
                        return strSeasonalCrop(seasonList: new string[] { "summer", "fall" }, quality: quality);
                    
                    case ItemID.IT_Hay:
                        return strBuyFrom(shopLiteral: multiKey("shopMarnie", isDesertKnown()? "shopDesertTrader" : "")) + "\n"
                             + str.Get("harvestHay", new { wheat = getItemName(ItemID.IT_Wheat) })
                             + (modRegistry.IsLoaded("ppja.artisanvalleyPFM")? // Artisan Valley machine rules
                                "\n" + strPutItemInMachine(ItemID.IT_Fiber, machineName: "Drying Rack") : "");
                    
                    // Enchanter's Bundle
                    
                    case ItemID.IT_Wine: // Also in Missing Bundle at silver quality
                        return strMachineOrCaskForQuality(StardewValley.Object.FruitsCategory.ToString(), ItemID.BC_Keg, ItemID.IT_Wine, quality);
                    
                    case ItemID.IT_RabbitsFoot:
                        return strAnimalProduct("animalRabbit", true) + "\n"
                             + strDroppedByMonster("Serpent");
                    
                    /********** [Base Game Bundles] The Missing Bundle **********/
                    
                    case ItemID.IT_DinosaurMayonnaise:
                        return strPutItemInMachine(ItemID.IT_DinosaurEgg, ItemID.BC_MayonnaiseMachine);
                    
                    case ItemID.IT_PrismaticShard:
                        return str.Get("gemPrismaticShard") + "\n"
                             + strFishingChest(6) + "\n"
                             + strFishPond(ItemID.IT_RainbowTrout, 9);
                    
                    case ItemID.IT_AncientFruit:
                        if (!Game1.player.knowsRecipe("Ancient Seeds"))
                            recipeUnlockTip = parenthesize(getCraftingRecipeSources("Ancient Seeds"));
                        return strGrowSeeds(ItemID.IT_AncientSeeds, recipeUnlockTip, quality);
                    
                    case ItemID.IT_VoidSalmon:
                        return strFishBase(isWitchSwampKnown()? "waterSwamp" : "waterUnknown");
                    
                    case ItemID.IT_Caviar:
                        return strPutItemInMachine(ItemID.IT_Roe, itemLiteral: getFishRoeName(ItemID.IT_Sturgeon),
                                                   machineID: ItemID.BC_PreservesJar);
                    
                    /********** [Base Game Remixed Bundles] Pantry **********/
                    
                    // [Remixed] Spring Crops Bundle
                    
                    case ItemID.IT_Kale:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.IT_Carrot:
                        return strGrowSeeds(ItemID.IT_CarrotSeeds, parenthesize(strSeasonalForage("spring")), quality);
                    
                    // [Remixed] Summer Crops Bundle
                    
                    case ItemID.IT_SummerSquash:
                        return strGrowSeeds(ItemID.IT_SummerSquashSeeds, parenthesize(strSeasonalForage("summer")), quality);
                    
                    // [Remixed] Fall Crops Bundle
                    
                    case ItemID.IT_Broccoli:
                        return strGrowSeeds(ItemID.IT_BroccoliSeeds, parenthesize(strSeasonalForage("fall")), quality);
                        
                    // [Remixed] Rare Crops Bundle
                    
                    case ItemID.IT_SweetGemBerry:
                        return strGrowSeeds(ItemID.IT_RareSeed, parenthesize(str.Get("shopTravelingCartSeason",
                                                                             new { season = multiSeason("spring", "summer") })),
                                            quality);
                    
                    // [Remixed] Fish Farmer's Bundle
                    
                    case ItemID.IT_Roe:
                        return str.Get("fishPondAny");
                    
                    case ItemID.IT_AgedRoe:
                        return strPutItemInMachine(ItemID.IT_Roe, ItemID.BC_PreservesJar);
                    
                    case ItemID.IT_SquidInk:
                        return strDroppedByMonster("Squid Kid") + "\n"
                             + strFishPond(ItemID.IT_Squid, 1) + "\n"
                             + strFishPond(ItemID.IT_MidnightSquid, 1);
                    
                    // [Remixed] Garden Bundle
                    
                    case ItemID.IT_Tulip:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.IT_BlueJazz:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.IT_SummerSpangle:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.IT_FairyRose:
                        return strSeasonalCrop("fall", quality);
                    
                    // [Remixed] Brewer's Bundle
                    
                    case ItemID.IT_Mead:
                        return strMachineOrCaskForQuality(ItemID.IT_Honey, ItemID.BC_Keg, ItemID.IT_Mead, quality);
                    
                    case ItemID.IT_Juice:
                        return strPutItemInMachine(preservesID == null? StardewValley.Object.VegetableCategory.ToString() : preservesID,
                                                   ItemID.BC_Keg)
                             + (preservesID != null? "\n" + subItemHints(preservesID) : "");
                    
                    case ItemID.IT_PaleAle:
                        return strMachineOrCaskForQuality(ItemID.IT_Hops, ItemID.BC_Keg, ItemID.IT_PaleAle, quality);
                    
                    case ItemID.IT_GreenTea:
                        return strPutItemInMachine(ItemID.IT_TeaLeaves, ItemID.BC_Keg);
                    
                    /********** [Base Game Remixed Bundles] Crafts Room  **********/
                    
                    // [Remixed] Spring Foraging Bundle
                    
                    case ItemID.IT_SpringOnion:
                        return strSeasonalLocationalForage("spring", "locationForest");
                    
                    // [Remixed] Winter Foraging Bundle
                    
                    case ItemID.IT_Holly:
                        return strSeasonalForage("winter");
                    
                    // [Remixed] Sticky Bundle
                    
                    case ItemID.IT_Sap:
                        return strChopTrees() + "\n"
                             + strDroppedByMonster(monsterKey: "monsterGeneralSlime");
                    
                    // [Remixed] Forest Bundle
                    
                    case ItemID.IT_Moss:
                        return str.Get("treeMoss");
                        
                    case ItemID.IT_Fiber:
                        return str.Get("clearWeeds");
                    
                    case ItemID.IT_Acorn:
                        return str.Get("seedFromTree", new { tree = str.Get("treeOak") });
                    
                    case ItemID.IT_MapleSeed:
                        return str.Get("seedFromTree", new { tree = str.Get("treeMaple") });
                    
                    // [Remixed] Wild Medicine Bundle
                    
                    case ItemID.IT_WhiteAlgae:
                        return strFishBase(waterList: new string[] { isSewerKnown()? "waterSewer" : "",
                                                                     isWitchSwampKnown()? "waterSwamp" : "",
                                                                     "waterMines" });
                    
                    case ItemID.IT_Hops:
                        return strSeasonalCrop("summer", quality);
                    
                    /********** [Base Game Remixed Bundles] Fish Tank **********/
                    
                    // [Remixed] Master Fisher's Bundle
                    
                    case ItemID.IT_LavaEel:
                        return strFishBase("waterMines100", fishingLevel: 7);
                    
                    case ItemID.IT_ScorpionCarp:
                        return strFishBase(isDesertKnown()? "waterDesert" : "waterUnknown", "6am", "8pm");
                    
                    case ItemID.IT_Octopus:
                        return strFishBase("waterOcean", "6am", "1pm", "summer") + "\n"
                             + (isIslandKnown()? strFishBase("waterIslandOceanWest", "6am", "1pm") + "\n" : "")
                             + str.Get("fishSubmarine");
                    
                    case ItemID.IT_Blobfish:
                        return str.Get("fishSubmarine");
                    
                    /********** [Base Game Remixed Bundles] Boiler Room **********/
                    
                    // [Remixed] Adventurer's Bundle
                    
                    case ItemID.IT_BoneFragment:
                        return strDroppedByMonster("Skeleton") + "\n"
                             + strDroppedByMonster("Lava Lurk");
                    
                    // [Remixed] Treasure Hunter's Bundle
                    
                    case ItemID.IT_Amethyst:
                        return str.Get("gemAmethyst") + "\n"
                             + strFishingChest(2) + "\n"
                             + strPanning();
                    
                    case ItemID.IT_Topaz:
                        return str.Get("gemTopaz") + "\n"
                             + strFishingChest(2) + "\n"
                             + strPanning();
                    
                    case ItemID.IT_Emerald:
                        return str.Get("gemEmerald") + "\n"
                             + strFishingChest(2) + "\n"
                             + strPanning();
                    
                    case ItemID.IT_Diamond:
                        return str.Get("gemDiamond") + "\n"
                             + strPanning();
                    
                    case ItemID.IT_Ruby:
                        return str.Get("gemRuby") + "\n"
                             + strFishingChest(2) + "\n"
                             + strPanning();
                    
                    // [Remixed] Engineer's Bundle
                    
                    case ItemID.IT_IridiumOre:
                        return str.Get("mineIridiumOre") + "\n"
                             + strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode) + "\n"
                             + strFishingChest() + "\n"
                             + strDroppedByMonster(monsterKey: "monsterPurpleSlime") + "\n"
                             + strDroppedByMonster("Iridium Crab") + "\n"
                             + strDroppedByMonster("Iridium Bat") + "\n"
                             + strFishPond(ItemID.IT_SuperCucumber, 9) + "\n"
                             + (Config.ShowSpoilers || Game1.year >= 3? strNoItemMachine(ItemID.BC_StatueOfPerfection)
                                                                      : str.Get("unknownSource")) + "\n"
                             + strPanning();
                    
                    case ItemID.IT_BatteryPack:
                        return strNoItemMachine(ItemID.BC_LightningRod);
                    
                    case ItemID.IT_RefinedQuartz:
                        return strPutItemInMachine(ItemID.IT_BrokenCD, ItemID.BC_RecyclingMachine) + "\n"
                             + strPutItemInMachine(ItemID.IT_BrokenGlasses, ItemID.BC_RecyclingMachine) + "\n"
                             + strPutItemInMachine(ItemID.IT_Quartz, ItemID.BC_Furnace) + "\n"
                             + strPutItemInMachine(ItemID.IT_FireQuartz, ItemID.BC_Furnace);
                    
                    /********** [Base Game Remixed Bundles] Bulletin Board **********/
                    
                    // [Remixed] Dye Bundle
                    
                    case ItemID.IT_Beet:
                        return strSeasonalCrop("fall", quality, isDesertKnown()? "shopOasis" : "shopUnknown");
                    
                    case ItemID.IT_Amaranth:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.IT_Starfruit:
                        return strSeasonalCrop("summer", quality, isDesertKnown()? "shopOasis" : "shopUnknown");
                    
                    case ItemID.IT_IridiumBar:
                        return strPutItemInMachine(ItemID.IT_IridiumOre, ItemID.BC_Furnace);
                    
                    // [Remixed] Children's Bundle
                    
                    case ItemID.IT_Salmonberry:
                        return strBushForageDayRange("spring", 15, 18)
                             + possibleSourceFruitBatCave();
                    
                    case ItemID.IT_Cookies:
                        return strCookRecipe("Cookies") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_AncientDoll:
                        return str.Get("artifactDigging") + "\n"
                             + strFishingChest(2);
                    
                    case ItemID.IT_IceCream:
                        return strCookRecipe("Ice Cream") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    // [Remixed] Home Cook's Bundle
                    
                    case ItemID.IT_WheatFlour:
                        return strBuyFrom(shopLiteral: getSeedShopsString());
                    
                    // [Remixed] Helper's Bundle
                    
                    case ItemID.IT_PrizeTicket:
                        return str.Get("prizeTicket");
                    
                    case ItemID.IT_MysteryBox:
                        if (areMysteryBoxesUnlocked())
                            return str.Get("artifactDigging") + "\n"
                                 + str.Get("fishingChest") + "\n"
                                 + str.Get("hitRocks");
                        else
                        {
                            if (Config.ShowSpoilers)
                                return str.Get("mysteryBoxesLocked");
                            else
                                return str.Get("unknownSource");
                        }
                    
                    // [Remixed] Spirit's Eve Bundle
                    
                    case ItemID.IT_JackOLantern:
                        return strBuyFrom("shopSpiritsEve");
                    
                    // [Remixed] Winter Star Bundle
                    
                    case ItemID.IT_PlumPudding:
                        return strCookRecipe("Plum Pudding");
                    
                    case ItemID.IT_Stuffing:
                        return strCookRecipe("Stuffing") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Powdermelon:
                        return strGrowSeeds(ItemID.IT_PowdermelonSeeds, parenthesize(strSeasonalForage("winter")), quality);
                    
                    /********** [Challenging CC Bundles Vanilla] Pantry **********/
                    
                    // [Challenging Vanilla] Spring Crops Bundle
                    
                    case ItemID.IT_Garlic:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.IT_Rhubarb:
                        return strSeasonalCrop("spring", quality, isDesertKnown()? "shopOasis" : "shopUnknown");
                    
                    case ItemID.IT_UnmilledRice:
                        return strSeasonalCrop("spring", quality, startingYear: 2);
                    
                    case ItemID.IT_Strawberry:
                        return strSeasonalCrop("spring", quality, "shopEggFestival");
                    
                    // [Challenging Vanilla] Summer Crops Bundle
                    
                    case ItemID.IT_Radish:
                        return strSeasonalCrop("summer", quality);
                    
                    // [Challenging Vanilla] Fall Crops Bundle
                    
                    case ItemID.IT_BokChoy:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.IT_Cranberries:
                        return strSeasonalCrop("fall", quality);
                    
                    // [Challenging Vanilla] Quality Crops Bundle
                    
                    case ItemID.IT_Artichoke:
                        return strSeasonalCrop("fall", quality, startingYear: 2);
                    
                    case ItemID.IT_CoffeeBean:
                        return strSeasonalCrop(seasonList: new string[] { "spring", "summer" }, quality: quality,
                                               shopKey: "shopTravelingCartRandom");
                    
                    // [Challenging Vanilla] Animal Bundle
                    
                    case ItemID.IT_Mayonnaise:
                        return strPutItemInMachine(ItemID.IT_Egg, ItemID.BC_MayonnaiseMachine);
                    
                    // [Challenging Vanilla] Fish Farmer's Bundle
                    
                    case ItemID.IT_Pearl:
                        bool gotPearl = Game1.player.mailReceived.Contains("gotPearl");
                        bool showPearlHint = Config.ShowSpoilers || Game1.player.secretNotesSeen.Contains(15);
                        return (!gotPearl? (str.Get("mermaidPearl", new { hint = showPearlHint? str.Get("mermaidHint") : "" }) + "\n")
                                         : "")
                             + str.Get("fishSubmarine") + "\n"
                             + strFishPond(ItemID.IT_Blobfish, 9);
                    
                    case ItemID.IT_Coral:
                        if (fixedBridgeToEastBeach())
                            return strLocationalForage("locationBeachEast");
                        else
                            return strLocationalForage(locationLiteral: str.Get("locationBeachEastInaccessible",
                                                                                new { wood = getItemName(ItemID.IT_Wood) }));
                    
                    case ItemID.IT_SoggyNewspaper:
                        return str.Get("trash");
                    
                    // [Challenging Vanilla] Artisan Bundle
                    
                    case ItemID.IT_Pickles:
                        return strPutItemInMachine(preservesID == null? StardewValley.Object.VegetableCategory.ToString() : preservesID,
                                                   ItemID.BC_PreservesJar)
                             + (preservesID != null? "\n" + subItemHints(preservesID) : "");
                    
                    // [Challenging Vanilla] Brewer's Bundle
                    
                    case ItemID.IT_Beer:
                        return (quality == 0? (strBuyFrom("shopSaloon") + "\n") : "") // Include Saloon for base quality only
                             + strMachineOrCaskForQuality(ItemID.IT_Wheat, ItemID.BC_Keg, ItemID.IT_Beer, quality);
                    
                    case ItemID.IT_Coffee:
                        return strPutItemInMachine(ItemID.IT_CoffeeBean, ItemID.BC_Keg, itemQuantity: 5)
                             + strBuyFrom("shopSaloon");
                    
                    /********** [Challenging CC Bundles Vanilla] Crafts Room **********/
                    
                    // [Challenging Vanilla] Fall Foraging Bundle
                    
                    case ItemID.IT_Chanterelle:
                        return strSeasonalLocationalForage("fall", "locationWoods")
                             + possibleSourceMushroomCave();
                    
                    // [Challenging Vanilla] Winter Foraging Bundle
                    
                    case ItemID.IT_PineCone:
                        return str.Get("seedFromTree", new { tree = str.Get("treePine") });
                    
                    // [Challenging Vanilla] Construction Bundle
                    
                    case ItemID.IT_WoodFence:
                        return strCraftRecipe("Wood Fence");
                    
                    case ItemID.IT_Clay:
                        return str.Get("generalTilling") + "\n"
                             + str.Get("openAnyGeode");
                    
                    // [Challenging Vanilla] Sticky Bundle
                    
                    case ItemID.IT_MinersTreat:
                        return strCookRecipe("Miner's Treat") + "\n"
                             + strBuyFromDwarf() + "\n"
                             + strBuyFromKrobusWeekday("saturday") + "\n"
                             + strDroppedByMonster("Mummy");
                    
                    // [Challenging Vanilla] Forest Bundle
                    
                    case ItemID.IT_TreeFertilizer:
                        return strCraftRecipe("Tree Fertilizer");
                    
                    case ItemID.IT_GrassStarter:
                        return strBuyFrom("shopPierre") + "\n"
                             + strCraftRecipe("Grass Starter");
                    
                    case ItemID.IT_RiverJelly:
                        return strFishBase(waterList: new string[] { "waterRivers", "waterMountain", "waterForestPond", "waterWoods" }, extraLinebreak: true) + "\n"
                             + strFishPond(ItemID.IT_MidnightCarp, 7);
                    
                    // [Challenging Vanilla] Exotic Foraging Bundle
                    
                    case ItemID.IT_Torch:
                        return strCraftRecipe("Torch") + "\n"
                             + strPutItemInMachine(ItemID.IT_SoggyNewspaper, ItemID.BC_RecyclingMachine);
                    
                    case ItemID.IT_MixedSeeds:
                        return str.Get("clearWeeds") + "\n"
                             + str.Get("generalTilling")
                             + (Game1.player.FishingLevel < 2? "\n" + strFishingChest() : "") + "\n"
                             + strBuyFromKrobusWeekday("thursday");
                    
                    // [Challenging Vanilla] Wild Medicine Bundle
                    
                    case ItemID.IT_TeaLeaves:
                        if (!Game1.player.knowsRecipe("Tea Sapling"))
                            recipeUnlockTip = parenthesize(getCraftingRecipeSources("Tea Sapling"));
                        return strGrowSeeds(ItemID.IT_TeaSapling, recipeUnlockTip, quality);
                    
                    case ItemID.IT_Salad:
                        return strCookRecipe("Salad") + "\n"
                             + strBuyFrom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_AlgaeSoup:
                        return strCookRecipe("Algae Soup");
                    
                    /********** [Challenging CC Bundles Vanilla] Fish Tank **********/
                    
                    // [Challenging Vanilla] River Fish Bundle
                    
                    case ItemID.IT_Dorado:
                        return strFishBase("waterForestRiver", "6am", "7pm", "summer");
                    
                    case ItemID.IT_SmallmouthBass:
                        return strFishBase(waterList: new string[] { "waterTown", "waterForestPond" },
                                           seasonList: new string[] { "spring", "fall" });
                    
                    case ItemID.IT_Salmon:
                        return strFishBase("waterRivers", "6am", "7pm", "fall");
                    
                    case ItemID.IT_Pike:
                        return strFishBase(waterList: new string[] { "waterRivers", "waterForestPond" },
                                           seasonList: new string[] { "summer", "winter" });
                    
                    case ItemID.IT_Lingcod:
                        return strFishBase(waterList: new string[] { "waterRivers", "waterMountain" }, seasonKey: "winter");
                    
                    // [Challenging Vanilla] Lake Fish Bundle
                    
                    case ItemID.IT_Perch:
                        return strFishBase(waterList: new string[] { "waterRivers", "waterMountain", "waterForestPond" },
                                           seasonKey: "winter");
                    
                    case ItemID.IT_RainbowTrout:
                        return strFishBase(waterList: new string[] { "waterRivers", "waterMountain" },
                                           start: "6am", end: "7pm", seasonKey: "summer");
                    
                    // [Challenging Vanilla] Ocean Fish Bundle
                    
                    case ItemID.IT_Anchovy:
                        return strFishBase("waterOcean", seasonList: new string[] { "spring", "fall" });
                    
                    case ItemID.IT_RedMullet:
                        return strFishBase("waterOcean", "6am", "7pm", seasonList: new string[] { "summer", "winter" });
                    
                    case ItemID.IT_Herring:
                        return strFishBase("waterOcean", seasonList: new string[] { "spring", "winter" });
                    
                    case ItemID.IT_SeaCucumber:
                        return strFishBase("waterOcean", "6am", "7pm", seasonList: new string[] { "fall", "winter" }) + "\n"
                             + str.Get("fishSubmarine");
                    
                    case ItemID.IT_Flounder:
                        return strFishBase("waterOcean", "6am", "8pm", seasonList: new string[] { "spring", "summer" })
                             + (isIslandKnown()? "\n" + strFishBase(waterList: new string[] { "waterIslandOcean", "waterIslandCove" },
                                                                    start: "6am", end: "8pm") : "");
                    
                    // [Challenging Vanilla] Night Fishing Bundle
                    
                    case ItemID.IT_Squid:
                        return strFishBase("waterOcean", "6pm", "2am", "winter");
                    
                    case ItemID.IT_SuperCucumber:
                        return strFishBase("waterOcean", "6pm", "2am", seasonList: new string[] { "summer", "fall" }) + "\n"
                             + (isIslandKnown()? strFishBase(waterList: new string[] { "waterIslandOcean", "waterIslandCove" },
                                                             start: "6pm", end: "2am") + "\n" : "")
                             + str.Get("fishSubmarine");
                    
                    case ItemID.IT_Albacore:
                        return strFishBase("waterOcean", "6am", "11am", start2: "6pm", end2: "2am",
                                           seasonList: new string[] { "fall", "winter" });
                    
                    case ItemID.IT_Halibut:
                        return strFishBase("waterOcean", "6am", "11am", start2: "7pm", end2: "2am",
                                           seasonList: new string[] { "spring", "summer", "winter" });
                    
                    case ItemID.IT_MidnightCarp:
                        return strFishBase(waterList: new string[] { "waterMountain", "waterForestPond" },
                                           start: "10pm", end: "2am", seasonList: new string[] { "fall", "winter" })
                             + (isIslandKnown()? "\n" + strFishBase("waterIslandRiver", "10pm", "2am") : "");
                    
                    // [Challenging Vanilla] Crab Pot Bundle
                    
                    case ItemID.IT_Driftwood:
                        return str.Get("trash");
                    
                    // [Challenging Vanilla] Specialty Fish Bundle
                    
                    case ItemID.IT_Stonefish:
                        return strFishBase("waterMines20", fishingLevel: 3);
                    
                    case ItemID.IT_IcePip:
                        return strFishBase("waterMines60", fishingLevel: 5);
                    
                    case ItemID.IT_SpookFish:
                        return str.Get("fishSubmarine");
                    
                    /********** [Challenging CC Bundles Vanilla] Boiler Room **********/
                    
                    // [Challenging Vanilla] Blacksmith's Bundle
                    
                    case ItemID.IT_Coal:
                        return strHitRocks() + "\n"
                             + strBuyFrom("shopBlacksmith") + "\n"
                             + strDroppedByMonster("Dust Spirit") + "\n"
                             + strPutItemInMachine(ItemID.IT_Wood, ItemID.BC_CharcoalKiln, itemQuantity: 10) + "\n"
                             + strFishingChest() + "\n"
                             + strPanning();
                    
                    // [Challenging Vanilla] Geologist's Bundle
                    
                    case ItemID.IT_Mudstone:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Geode:
                        return strHitRocks("locationMinesArea1") + "\n"
                             + strDroppedByMonster("Duggy") + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_Celestine:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_PetrifiedSlime:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    // [Challenging Vanilla] Adventurer's Bundle
                    
                    case ItemID.IT_MonsterMusk:
                        return strCraftRecipe("Monster Musk");
                    
                    case ItemID.IT_AncientSword:
                        return strLocationalArtifact(locationList: new string[] { "locationForest", "locationMountains" }) + "\n"
                             + strFishingChest(2);
                    
                    // [Challenging Vanilla] Treasure Hunter's Bundle
                    
                    case ItemID.IT_Jade:
                        return str.Get("gemJade") + "\n"
                             + strFishingChest(2);
                    
                    // [Challenging Vanilla] Engineers's Bundle
                    
                    case ItemID.IT_CherryBomb:
                        return strCraftRecipe("Cherry Bomb") + "\n"
                             + strBuyFromDwarf() + "\n"
                             + strDroppedByMonster("Rock Crab") + "\n"
                             + strDroppedByMonster("Duggy");
                    
                    case ItemID.IT_Bomb:
                        return strCraftRecipe("Bomb") + "\n"
                             + strBuyFromDwarf();
                    
                    case ItemID.IT_MegaBomb:
                        return strCraftRecipe("Mega Bomb") + "\n"
                             + strDroppedByMonster("Squid Kid") + "\n"
                             + strDroppedByMonster("Iridium Bat") + "\n"
                             + strBuyFromDwarf() + "\n"
                             + str.Get(isTheatherKnown()? "winCraneGame" : "unknownSource");
                    
                    case ItemID.IT_RustyCog:
                        return str.Get("artifactDigging") + "\n"
                             + strFishingChest(2);
                    
                    case ItemID.IT_BrokenCD:
                        return str.Get("trash");
                    
                    case ItemID.IT_ExplosiveAmmo:
                        return strCraftRecipe("Explosive Ammo")
                             + (Game1.player.knowsRecipe("Explosive Ammo")? "\n" + strBuyFrom("shopGuild") : "");
                    
                    /********** [Challenging CC Bundles Vanilla] Bulletin Board **********/
                    
                    // [Challenging Vanilla] Chef's Bundle
                    
                    case ItemID.IT_PumpkinPie:
                        return strCookRecipe("Pumpkin Pie");
                    
                    case ItemID.IT_LobsterBisque:
                        return strCookRecipe("Lobster Bisque");
                    
                    case ItemID.IT_ArtichokeDip:
                        return strCookRecipe("Artichoke Dip");
                    
                    case ItemID.IT_TripleShotEspresso:
                        return strCookRecipe("Triple Shot Espresso");
                    
                    case ItemID.IT_SurvivalBurger:
                        return strCookRecipe("Survival Burger") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Escargot:
                        return strCookRecipe("Escargot");
                   
                    case ItemID.IT_ShrimpCocktail:
                        return strCookRecipe("Shrimp Cocktail");
                    
                    // [Challenging Vanilla] Dye Bundle
                    
                    case ItemID.IT_Sandstone:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_RedSlimeEgg:
                        return strPutItemInMachine(ItemID.IT_Slime, ItemID.BC_SlimeEggPress, itemQuantity: 100) + "\n"
                             + strDroppedByMonster(monsterKey: "monsterRedSlime");
                    
                    case ItemID.IT_BlueSlimeEgg:
                        return strPutItemInMachine(ItemID.IT_Slime, ItemID.BC_SlimeEggPress, itemQuantity: 100) + "\n"
                             + strDroppedByMonster(monsterKey: "monsterBlueSlime");
                    
                    // [Challenging Vanilla] Field Research Bundle
                    
                    case ItemID.IT_RedPlate:
                        return strCookRecipe("Red Plate") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_AncientSeeds:
                        return strCraftRecipe("Ancient Seeds");
                    
                    case ItemID.IT_AmphibianFossil:
                        return strLocationalArtifact(locationList: new string[] { "locationForest", "locationMountains" }) + "\n"
                             + strFishingChest(2) + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_FieldSnack:
                        return strCraftRecipe("Field Snack");
                    
                    // [Challenging Vanilla] Fodder Bundle
                    
                    case ItemID.IT_Seaweed:
                        return strFishBase("waterOcean") + "\n"
                             + (fixedBridgeToEastBeach()? strLocationalForage("locationBeachEast")
                                                        : strLocationalForage(locationLiteral: str.Get("locationBeachEastInaccessible",
                                                                              new { wood = getItemName(ItemID.IT_Wood) }))) + "\n"
                             + str.Get("trashCan");
                    
                    case ItemID.IT_GreenAlgae:
                        return strFishBase("waterRivers") + "\n"
                             + str.Get("trashCan");
                    
                    case ItemID.IT_Bait:
                        return strBuyFrom("shopFish") + "\n"
                             + strCraftRecipe("Bait") + "\n"
                             + strFishingChest() + "\n"
                             + strNoItemMachine(ItemID.BC_WormBin);
                    
                    // [Challenging Vanilla] Enchanter's Bundle
                    
                    case ItemID.IT_RainbowShell:
                        return strSeasonalLocationalForage("summer", "locationBeach");
                    
                    case ItemID.IT_DwarfScroll1:
                        return strLocationalForage("locationMines") + "\n"
                             + strDroppedByMonster("Bat") + "\n"
                             + strDroppedByMonster("Bug") + "\n"
                             + strDroppedByMonster("Fly") + "\n"
                             + strDroppedByMonster("Duggy") + "\n"
                             + strDroppedByMonster("Green Slime") + "\n"
                             + strDroppedByMonster("Grub") + "\n"
                             + strDroppedByMonster("Rock Crab") + "\n"
                             + strDroppedByMonster("Stone Golem");
                    
                    case ItemID.IT_SeafoamPudding:
                        return strCookRecipe("Seafoam Pudding");
                    
                    case ItemID.IT_GoldenMask:
                        return strLocationalArtifact(isDesertKnown()? "locationDesert" : "locationUnknown");
                    
                    case ItemID.IT_DriedMushrooms:
                        if (preservesID == null)
                            return strPutItemInMachine(itemLiteral: str.Get("itemCategoryMushroom"), machineID: ItemID.BC_Dehydrator);
                        else
                            return strPutItemInMachine(preservesID, ItemID.BC_Dehydrator) + "\n"
                                 + subItemHints(preservesID);
                    
                    case ItemID.IT_LifeElixir:
                        return strCraftRecipe("Life Elixir") + "\n"
                             + strDroppedByMonster("Iridium Bat");
                    
                    case ItemID.IT_GoldenPumpkin:
                        return str.Get("goldenPumpkin");
                    
                    case ItemID.IT_WarpTotemFarm:
                        return strCraftRecipe("Warp Totem: Farm") + "\n"
                             + strFishPond(ItemID.IT_Blobfish, 9) + "\n"
                             + str.Get(isTheatherKnown()? "winCraneGame" : "unknownSource");
                    
                    // [Challenging Vanilla] Children's Bundle
                    
                    case ItemID.IT_BlueberryTart:
                        return strCookRecipe("Blueberry Tart") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_CranberryCandy:
                        return strCookRecipe("Cranberry Candy");
                    
                    case ItemID.IT_PoppyseedMuffin:
                        return strCookRecipe("Poppyseed Muffin");
                    
                    case ItemID.IT_PinkCake:
                        return strCookRecipe("Pink Cake") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_TentKit:
                        return strCraftRecipe("Tent Kit");
                    
                    // [Challenging Vanilla] Forager's Bundle
                    
                    case ItemID.IT_MahoganySeed:
                        return str.Get("seedFromTree", new { tree = str.Get("treeMahogany") });
                    
                    case ItemID.IT_SpringSeeds:
                        return strCraftRecipe("Wild Seeds (Sp)");
                    
                    case ItemID.IT_SummerSeeds:
                        return strCraftRecipe("Wild Seeds (Su)");
                        
                    case ItemID.IT_FallSeeds:
                        return strCraftRecipe("Wild Seeds (Fa)");
                    
                    case ItemID.IT_WinterSeeds:
                        return strCraftRecipe("Wild Seeds (Wi)");
                    
                    // [Challenging Vanilla] Home Cook's Bundle
                    
                    case ItemID.IT_VegetableMedley:
                        return strCookRecipe("Vegetable Stew") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Tortilla:
                        return strCookRecipe("Tortilla") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_FruitSalad:
                        return strCookRecipe("Fruit Salad");
                    
                    case ItemID.IT_SalmonDinner:
                        return strCookRecipe("Salmon Dinner") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_CompleteBreakfast:
                        return strCookRecipe("Complete Breakfast") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Pizza:
                        return strCookRecipe("Pizza") + "\n"
                             + strBuyFrom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Spaghetti:
                        return strCookRecipe("Spaghetti") + "\n"
                             + strBuyFrom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Bruschetta:
                        return strCookRecipe("Bruschetta");
                    
                    case ItemID.IT_Pancakes:
                        return strCookRecipe("Pancakes") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    // [Challenging Vanilla] Helper's Bundle
                    
                    case ItemID.IT_DeluxeBait:
                        return strBuyFrom("shopFish") + (Game1.player.FishingLevel < 4? levelRequirementString("fishing", 4) : "") + "\n"
                             + strCraftRecipe("Deluxe Bait") + "\n"
                             + strFishingChest(6) + "\n"
                             + strNoItemMachine(ItemID.BC_DeluxeWormBin);
                        
                    case ItemID.IT_SmokedFish:
                        return strPutItemInMachine(preservesID == null? StardewValley.Object.FishCategory.ToString() : preservesID,
                                                   ItemID.BC_FishSmoker)
                             + (preservesID != null? "\n" + subItemHints(preservesID) : "");
                        
                    case ItemID.IT_MossSoup:
                        return strCookRecipe("Moss Soup");
                    
                    case ItemID.IT_Trash:
                        return str.Get("trash");
                    
                    case ItemID.IT_CaveJelly:
                        return strFishBase(waterList: new string[] { "waterMines20", "waterMines60", "waterMines100" }, extraLinebreak: true) + "\n"
                             + strFishPond(ItemID.IT_LavaEel, 8);
                    
                    case ItemID.IT_ChewingStick:
                        return strLocationalArtifact(locationList: new string[] { "locationMountains", "locationForest" }) + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_PaleBroth:
                        return strCookRecipe("Pale Broth") + "\n"
                             + strFishPond(ItemID.IT_Ghostfish, 9);
                    
                    // [Challenging Vanilla] Spirit's Eve Bundle
                    
                    case ItemID.IT_PumpkinSoup:
                        return strCookRecipe("Pumpkin Soup") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_SquidInkRavioli:
                        return strCookRecipe("Squid Ink Ravioli");
                    
                    case ItemID.IT_MidnightSquid:
                        return str.Get("fishSubmarine");
                    
                    case ItemID.IT_OilOfGarlic:
                        return strCraftRecipe("Oil Of Garlic") + "\n"
                             + strBuyFromDwarf();
                    
                    case ItemID.IT_BugSteak:
                        return strCraftRecipe("Bug Steak");
                    
                    case ItemID.IT_BoneFlute:
                        return strLocationalArtifact(locationList: new string[] { "locationMountains", "locationForest" }) + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_GhostCrystal:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    // [Challenging Vanilla] Winter Star Bundle
                    
                    case ItemID.IT_CranberrySauce:
                        return strCookRecipe("Cran. Sauce") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_RoastedHazelnuts:
                        return strCookRecipe("Roasted Hazelnuts");
                    
                    case ItemID.IT_CrystalPath:
                        return strCraftRecipe("Crystal Path");
                    
                    case ItemID.IT_Raisins:
                        return strPutItemInMachine(ItemID.IT_Grape, ItemID.BC_Dehydrator, itemQuantity: 5);
                    
                    case ItemID.IT_DriedFruit:
                        return strPutItemInMachine(preservesID == null? StardewValley.Object.FruitsCategory.ToString() : preservesID,
                                                   ItemID.BC_Dehydrator)
                             + (preservesID != null? "\n" + subItemHints(getHintText(preservesID, 0)) : "");
                    
                    case ItemID.IT_FluteBlock:
                        return strCraftRecipe("Flute Block");
                    
                    /********** [Challenging CC Bundles Vanilla] The Missing Bundle **********/
                    
                    case ItemID.IT_MagicRockCandy:
                        return strBuyFrom("shopDesertTrader") + "\n"
                             + strDroppedByMonster(monsterKey: "monsterHauntedSkull");
                    
                    case ItemID.IT_VoidMayonnaise:
                        return strPutItemInMachine(ItemID.IT_VoidEgg, ItemID.BC_MayonnaiseMachine);
                    
                    case ItemID.IT_Slimejack:
                        return strFishBase("waterBugLand");
                    
                    case ItemID.IT_SuperMeal:
                        return strCookRecipe("Super Meal") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_FishTaco:
                        return strCookRecipe("Fish Taco") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_StarShards:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_PepperPoppers:
                        return strCookRecipe("Pepper Poppers") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_DwarfGadget:
                        return strLocationalTilling("locationMinesArea2") + "\n"
                             + strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    /********** [Challenging CC Bundles Cornucopia_RSV_SVE] Pantry **********/
                    
                    // [Challenging Cornucopia_RSV_SVE] Spring Crops Bundle
                    
                    case ItemID.SVE_SalalBerry:
                        return strGrowSeeds(ItemID.SVE_ShrubSeed, parenthesize(strLocationalForage("locationWoods")), quality);
                    
                    case ItemID.CNC_Onion:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.CNC_Vanilla:
                        return strSeasonalCrop("spring", quality, startingYear: 2);
                    
                    case ItemID.CNC_Basil:
                        return strSeasonalCrop("spring", quality)
                             + (modRegistry.IsLoaded("alja.FTMCCCB")? // Challenging CC Bundles bundle forage pack
                                "\n" + strSeasonalForage("spring") : "");
                    
                    // [Challenging Cornucopia_RSV_SVE] Summer Crops Bundle
                    
                    case ItemID.CNC_Lettuce:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.CNC_BellPepper:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.SVE_AncientFiber:
                        return strGrowSeeds(ItemID.SVE_AncientFernSeed, parenthesize(strLocationalForage("locationWoods")), quality);
                    
                    case ItemID.SVE_ButternutSquash:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.CNC_Kiwifruit:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.CNC_Lotus:
                        return strSeasonalCrop("summer", quality, "shopOasis");
                    
                    // [Challenging Cornucopia_RSV_SVE] Fall Crops Bundle
                    
                    case ItemID.CNC_Olive:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.CNC_Peanut:
                        return strSeasonalCrop("fall", quality, startingYear: 2);
                    
                    case ItemID.SVE_SweetPotato:
                        return strSeasonalCrop("fall", quality);
                    
                    // [Challenging Cornucopia_RSV_SVE] Quality Crops Bundle
                    
                    case ItemID.CNC_Rose:
                        return strSeasonalCrop(seasonList: new string[] { "spring", "summer", "fall" }, quality: quality);
                    
                    case ItemID.SVE_Cucumber:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.CNC_Cucumber:
                        return strSeasonalCrop("summer", quality, startingYear: 2);
                    
                    // [Challenging Cornucopia_RSV_SVE] Animal Bundle
                    
                    case ItemID.CNC_Butter:
                        return strPutItemInMachine(ItemID.IT_Milk, ItemID.CNC_BC_ButterChurn);
                    
                    // [Challenging Cornucopia_RSV_SVE] Garden Bundle
                    
                    case ItemID.CNC_Pansy:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.CNC_MorningGlory:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.CNC_Iris:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.CNC_Lily:
                        return strSeasonalCrop("summer", quality, startingYear: 2);
                    
                    // [Challenging Cornucopia_RSV_SVE] Artisan Products Bundle
                    
                    case ItemID.CNC_Pistachio:
                        return strFruitTreeDuringSeason("treePistachio", "fall");
                    
                    case ItemID.CNC_Avocado:
                        return strFruitTreeDuringSeason("treeAvocado", "summer");
                    
                    case ItemID.RSV_TropiUgliFruit:
                        return strFruitTreeDuringSeason("treeTropiUgliFruit", "summer", "shopNightingaleOrchard");
                    
                    case ItemID.SVE_Persimmon:
                        return strFruitTreeDuringSeason("treePersimmon", "fall");
                    
                    case ItemID.CNC_CocoaPod:
                        return strFruitTreeDuringSeason("treeCocoaPod", "spring", startingYear: 2);
                    
                    case ItemID.CNC_Pear:
                        return strFruitTreeDuringSeason("treePear", "winter", startingYear: 2);
                    
                    // [Challenging Cornucopia_RSV_SVE] Brewer's Bundle
                    
                    case ItemID.SVE_BlueMoonWine:
                        return strBuyFrom("shopSophiaLedger");
                    
                    /********** [Challenging CC Bundles Cornucopia_RSV_SVE] Crafts Room **********/
                    
                    // [Challenging Cornucopia_RSV_SVE] Spring Foraging Bundle
                    
                    case ItemID.RSV_RidgeAzoreanFlower:
                        return strSeasonalForage("spring");
                    
                    case ItemID.RSV_RidgeCherry:
                        return strSeasonalForage("spring");
                    
                    case ItemID.SVE_Conch:
                        return strLocationalForage("locationBeach");
                    
                    // [Challenging Cornucopia_RSV_SVE] Summer Foraging Bundle
                    
                    case ItemID.RSV_ForestAmancay:
                        return strSeasonalForage("summer");
                    
                    case ItemID.SVE_SandDollar:
                        return strSeasonalLocationalForage(seasonList: new string[] { "summer", "fall" },
                                                           locationKey: "locationBeach");
                    
                    case ItemID.CNC_Peppercorn:
                        return strSeasonalForage(seasonList: new string[] { "spring", "summer" }) + "\n"
                             + strSeasonalCrop(seasonList: new string[] { "spring", "summer", "fall" }, quality: quality,
                                               shopKey: "shopTravelingCartRandom");
                    
                    case ItemID.RSV_MountainChico:
                        return strSeasonalForage("summer");
                    
                    // [Challenging Cornucopia_RSV_SVE] Fall Foraging Bundle
                    
                    case ItemID.RSV_SummitSnowbell:
                        return strSeasonalForage("fall");
                    
                    case ItemID.SVE_MushroomColony:
                        return strSeasonalForage("fall");
                    
                    case ItemID.RSV_AutumnDropBerry:
                        return strSeasonalForage("fall");
                    
                    // [Challenging Cornucopia_RSV_SVE] Winter Foraging Bundle
                    
                    case ItemID.RSV_FrostClumpBerry:
                        return strSeasonalForage("winter");
                    
                    case ItemID.SVE_Bearberry:
                        return strSeasonalLocationalForage("winter", "locationWoods");
                    
                    case ItemID.RSV_SierraWintergreen:
                        return strSeasonalForage("winter");
                    
                    // [Challenging Cornucopia_RSV_SVE] Construction Bundle
                    
                    case ItemID.CNC_OliveOil:
                        return strPutItemInMachine(ItemID.CNC_Olive, ItemID.BC_OilMaker);
                    
                    case ItemID.SVE_FirWax:
                        return strTapTree("treeFir") + "\n"
                             + strBuyFrom("shopWestForestBear");
                    
                    // [Challenging Cornucopia_RSV_SVE] Sticky Bundle
                    
                    case ItemID.SVE_BirchSyrup:
                        return strCookRecipe("Birch Syrup");
                    
                    // [Challenging Cornucopia_RSV_SVE] Exotic Foraging Bundle
                    
                    case ItemID.SVE_PoisonMushroom:
                        return strSeasonalLocationalForage(seasonList: new string[] { "summer", "fall" }, locationKey: "locationWoods");
                    
                    case ItemID.RSV_LavaLily:
                        return strSeasonalForage("fall");
                    
                    // [Challenging Cornucopia_RSV_SVE] Wild Medicine Bundle
                    
                    case ItemID.SVE_Rafflesia:
                        return strSeasonalLocationalForage(seasonList: new string[] { "spring", "summer", "fall" }, locationKey: "locationWoods");
                    
                    case ItemID.CNC_DriedHerb:
                        return strPutItemInMachine(itemLiteral: str.Get("itemCategoryHerb"), machineID: ItemID.BC_Dehydrator) + "\n"
                             + strPutItemInMachine(itemLiteral: str.Get("itemCategoryHerb"), machineID: ItemID.CNC_BC_DryingRack);
                    
                    case ItemID.RSV_MountainMistbloom:
                        return strLocationalForage("locationRidgeForest");
                    
                    /********** [Challenging CC Bundles Cornucopia_RSV_SVE] Fish Tank **********/
                    
                    // [Challenging Cornucopia_RSV_SVE] River Fish Bundle
                    
                    case ItemID.RSV_MountainRedbellyDace:
                        return strFishBase(waterList: new string[] { "waterRidgesideRiver", "waterRidge", "waterRidgeForest", "waterRidgeFalls" },
                                           start: "6am", end: "7pm", extraLinebreak: true);
                    
                    case ItemID.SVE_Butterfish:
                        return strFishBase("waterShearwaterBridge",
                                           seasonList: new string[] { "spring", "summer", "fall" }, weatherKey: "weatherSun");
                    
                    case ItemID.RSV_HarvesterTrout:
                        return strFishBase("waterRidgesideRiver", "8am", "4pm", seasonList: new string[] { "spring", "fall", "winter" });
                    
                    // [Challenging Cornucopia_RSV_SVE] Lake Fish Bundle
                    
                    case ItemID.SVE_Minnow:
                        return strFishBase(waterList: new string[] { "waterBlueMoonVineyard", "waterShearwaterBridge", "waterAdventurerSummit" },
                                           start: "6am", end: "6pm");
                    
                    case ItemID.RSV_CrimsonSpikedClam:
                        return strFishBase("waterRidgeForest", "10am", "4pm", seasonList: new string[] { "spring", "summer", "winter" });
                    
                    case ItemID.RSV_PebbleBackCrab:
                        return strFishBase("waterRidgeForest", "3pm", "10pm", seasonList: new string[] { "spring", "summer", "winter" });
                    
                    // [Challenging Cornucopia_RSV_SVE] Ocean Fish Bundle
                    
                    case ItemID.SVE_Starfish:
                        return strFishBase(waterList: new string[] { "waterOcean", "waterBlueMoonVineyard" },
                                           seasonList: new string[] { "spring", "summer", "fall" }, start: "6am", end: "10pm")
                             + (isIslandKnown()? "\n" + strFishBase("waterIsland", "6am", "10pm") : "");
                    
                    // [Challenging Cornucopia_RSV_SVE] Night Fishing Bundle
                    
                    case ItemID.SVE_Tadpole:
                        return strFishBase("waterMountain", seasonList: new string[] { "spring", "summer" });
                    
                    case ItemID.RSV_LullabyCarp:
                        return strFishBase("waterRidgeFalls", "3pm", "2am", seasonList: new string[] { "spring", "summer", "winter" });
                    
                    // [Challenging Cornucopia_RSV_SVE] Crab Pot Bundle
                    
                    case ItemID.CNC_SeaSalt:
                        return strLocationalForage("locationBeach");
                    
                    // [Challenging Cornucopia_RSV_SVE] Specialty Fish Bundle
                    
                    case ItemID.SVE_Puppyfish:
                        return strFishBase("waterShearwaterBridge", seasonList: new string[] { "spring", "summer", "fall" }) + "\n"
                             + strFishBase("waterForestWest", seasonKey: "summer");
                    
                    case ItemID.RSV_FairytaleLionfish:
                        return strFishBase("waterRidgeFalls", "11am", "8pm", seasonList: new string[] { "spring", "summer", "fall" });
                    
                    // [Challenging Cornucopia_RSV_SVE] Quality Fish Bundle
                    
                    case ItemID.SVE_GrassCarp:
                        return strFishBase("waterWoods", seasonList: new string[] { "spring", "summer" });
                    
                    case ItemID.RSV_RidgesideBass:
                        return strFishBase(waterList: new string[] { "waterRidgesideRiver", "waterRidge", "waterRidgeForest", "waterRidgeFalls" },
                            start: "6am", end: "2am", extraLinebreak: true);
                    
                    // [Challenging Cornucopia_RSV_SVE] Master Fisher's Bundle
                    
                    case ItemID.SVE_RadioactiveBass:
                        return strFishBase("waterSewer", fishingLevel: 10);
                    
                    case ItemID.RSV_GoldenRoseFin:
                        return strFishBase("waterRidgeFalls", "7am", "7pm", seasonList: new string[] { "spring", "fall", "winter" });
                    
                    /********** [Challenging CC Bundles Cornucopia_RSV_SVE] Boiler Room **********/
                    
                    // [Challenging Cornucopia_RSV_SVE] Adventurer's Bundle
                    
                    case ItemID.RSV_SpiritualEssence:
                        return strDroppedByMonster(monsterKey: "monsterRidgeForest");
                    
                    /********** [Challenging CC Bundles Cornucopia_RSV_SVE] Bulletin Board **********/
                    
                    // [Challenging Cornucopia_RSV_SVE] Chef's Bundle
                    
                    case ItemID.RSV_ClementineCake:
                        return strCookRecipe("Clementine Cake");
                    
                    case ItemID.SVE_GlazedButterfish:
                        return strCookRecipe("Glazed Butterfish") + "\n"
                             + strFishPond(fishItemName: "Butterfish", numRequired: 10);
                    
                    case ItemID.SVE_FrogLegs:
                        return strCookRecipe("Frog Legs");
                    
                    case ItemID.CNC_CenturyEgg:
                        return strPutItemInMachine(ItemID.IT_VoidEgg, ItemID.BC_PreservesJar);
                    
                    // [Challenging Cornucopia_RSV_SVE] Dye Bundle
                    
                    case ItemID.CNC_Chrysanthemum:
                        return strSeasonalCrop("fall", quality, startingYear: 2);
                    
                    case ItemID.CNC_CottonBoll:
                        return strSeasonalCrop(seasonList: new string[] { "summer", "fall" }, quality: quality);
                    
                    // [Challenging Cornucopia_RSV_SVE] Field Research Bundle
                    
                    case ItemID.SVE_GrilledCheeseSandwich:
                        return strCookRecipe("Grilled Cheese Sandwich");
                    
                    case ItemID.SVE_Amber:
                        return strLocationalArtifact(locationList: new string[] { "locationAdventurerSummit", "locationMountains" });
                    
                    case ItemID.CNC_SnackCheese:
                        return strPutItemInMachine(ItemID.IT_Cheese, ItemID.CNC_BC_WaxBarrel);
                    
                    case ItemID.RSV_PillowsoftCheezySandwich:
                        return strCookRecipe("Pillowsoft Cheezy Sandwich");
                    
                    case ItemID.SVE_Nectarine:
                        return strFruitTreeDuringSeason("treeNectarine", "summer");
                    
                    case ItemID.SVE_MushroomBerryRice:
                        return strCookRecipe("Mushroom Berry Rice");
                    
                    // [Challenging Cornucopia_RSV_SVE] Fodder Bundle
                    
                    case ItemID.RSV_RidgeWildApple:
                        return strSeasonalForage("summer");
                    
                    case ItemID.CNC_Soybeans:
                        return strBuyFrom("shopTravelingCartRandom");
                    
                    case ItemID.CNC_Turnip:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.SVE_DulseSeaweed:
                        return strFishBase("waterOcean");
                    
                    // [Challenging Cornucopia_RSV_SVE] Enchanter's Bundle
                    
                    case ItemID.CNC_Candles:
                        return strPutItemInMachine(itemLiteral: str.Get("itemCategoryFlower"), machineID: ItemID.CNC_BC_WaxBarrel) + "\n"
                             + strPutItemInMachine(itemLiteral: str.Get("itemCategoryFruit"), machineID: ItemID.CNC_BC_WaxBarrel) + "\n"
                             + strPutItemInMachine(itemLiteral: str.Get("itemCategoryNut"), machineID: ItemID.CNC_BC_WaxBarrel) + "\n"
                             + strPutItemInMachine(itemLiteral: str.Get("itemCategoryHerb"), machineID: ItemID.CNC_BC_WaxBarrel);
                    
                    case ItemID.SVE_Frog:
                        return strFishBase("waterMountain", "6pm", "2am",
                                           seasonList: new string[] { "spring", "summer" }, weatherKey: "weatherRain");
                    
                    // [Challenging Cornucopia_RSV_SVE] Children's Bundle
                    
                    case ItemID.RSV_HighlandIceCream:
                        return strCookRecipe("Highland Ice Cream");
                    
                    case ItemID.RSV_HighlandBlueberryPie:
                        return strCookRecipe("Highland Blueberry Pie");
                    
                    case ItemID.SVE_Candy:
                        return strCookRecipe("Candy");
                    
                    case ItemID.SVE_MixedBerryPie:
                        return strCookRecipe("Mixed Berry Pie");
                    
                    // [Challenging Cornucopia_RSV_SVE] Home Cook's Bundle
                    
                    case ItemID.CNC_FlavoredYogurt:
                        return strPutItemInMachine(itemLiteral: str.Get("itemCategoryFruit"), machineID: ItemID.CNC_BC_YogurtJar);
                    
                    case ItemID.SVE_BakedBerryOatmeal:
                        return strCookRecipe("Baked Berry Oatmeal");
                    
                    case ItemID.RSV_FluffyAppleCrumble:
                        return strCookRecipe("Fluffy Apple Crumble");
                    
                    // [Challenging Cornucopia_RSV_SVE] Winter Star Bundle
                    
                    case ItemID.RSV_SweetCranberryCheesecake:
                        return strCookRecipe("Sweet Cranberry Cheesecake");
                    
                    case ItemID.SVE_NectarineFruitBread:
                        return strCookRecipe("Nectarine Fruit Bread");
                    
                    /********** [Challenging CC Bundles Cornucopia_RSV_SVE] The Missing Bundle **********/
                    
                    case ItemID.RSV_Foxbloom:
                        return str.Get("foxbloom");
                    
                    case ItemID.SVE_VoidPebble:
                        return strFishPond(fishItemName: "Void Eel", numRequired: 8) + "\n"
                             + strDroppedByMonster("Mummy") + "\n"
                             + strDroppedByMonster("Serpent") + "\n"
                             + strDroppedByMonster("Carbon Ghost");
                    
                    case ItemID.RSV_MatchaLatte:
                        return strCookRecipe("Matcha Latte");
                    
                    case ItemID.SVE_VoidDelight:
                        return strCookRecipe("Void Delight");
                    
                    case ItemID.SVE_PineappleCustardCrepe:
                        return strCookRecipe("Pineapple Custard Crepe");
                    
                    /********** [Challenging CC Bundles Cornucopia_SVE] Crafts Room **********/
                    
                    // [Challenging Cornucopia_SVE] Summer Foraging Bundle
                    
                    case ItemID.CNC_Raspberry:
                        return strSeasonalCrop("summer", quality, startingYear: 2)
                             + (modRegistry.IsLoaded("minervamaga.FTM.PPJAForage")? // Forage pack included with bundle mod
                                "\n" + strSeasonalForage("summer") : "");
                        
                    /********** [Challenging CC Bundles Cornucopia_SVE] Pantry **********/
                    
                    // [Challenging Cornucopia_SVE] Artisan Bundle
                    
                    case ItemID.SVE_Pear:
                        return strFruitTreeDuringSeason("treePear", "spring");
                    
                    /********** [Challenging CC Bundles Cornucopia_SVE] Bulletin Board **********/
                    
                    // [Challenging Cornucopia_SVE] // Children's Bundle 
                    
                    case ItemID.SVE_IceCreamSundae:
                        return strCookRecipe("Ice Cream Sundae") + "\n"
                             + strBuyFrom("shopIceCream");
                    
                    /********** [Challenging CC Bundles RSV_SVE] Pantry **********/
                    
                    // [Challenging RSV_SVE] Animal Bundle
                    
                    case ItemID.SVE_Butter:
                        return strPutItemInMachine(itemLiteral: str.Get("itemCategoryMilk"), machineID: ItemID.SVE_BC_ButterChurner) + "\n"
                             + strFishPond(ItemID.SVE_Butterfish, 7);
                    
                    // [Challenging RSV_SVE] Artisan Bundle
                    
                    case ItemID.RSV_EmberBloodLime:
                        return strFruitTreeDuringSeason("treeEmberBloomLime", "fall", "shopNightingaleOrchard");
                    
                    /********** [Custom CC Bundles Cornucopia_RSV_SVE] Pantry **********/
                    
                    // [Custom Cornucopia_RSV_SVE] Garden Bundle
                    
                    case ItemID.CNC_BlueMist:
                        return strSeasonalCrop("summer", quality)
                             + (modRegistry.IsLoaded("alja.FTMCCCB")? // Challenging CC Bundles bundle forage pack
                                "\n" + strSeasonalForage("summer") : "");
                    
                    // [Custom Cornucopia_RSV_SVE] Artisan Bundle
                    
                    case ItemID.RSV_CherryPluot:
                        return strFruitTreeDuringSeason("treeCherryPluot", "spring", "shopNightingaleOrchard");
                    
                    case ItemID.RSV_MountainPlumcot:
                        return strFruitTreeDuringSeason("treeMountainPlumcot", "spring", "shopNightingaleOrchard");
                    
                    case ItemID.RSV_DesertTangelo:
                        return strFruitTreeDuringSeason("treeDesertTangelo", "summer", "shopNightingaleOrchard", 2);
                    
                    case ItemID.RSV_ParadiseRangpur:
                        return strFruitTreeDuringSeason("treeParadiseRangpur", "summer", "shopNightingaleOrchard");
                    
                    // [Custom Cornucopia_RSV_SVE] Brewer's Bundle
                    
                    case ItemID.SVE_AgedBlueMoonWine:
                        return strBuyFrom("shopSophiaLedger");
                    
                    /********** [Custom CC Bundles Cornucopia_RSV_SVE] Fish Tank **********/
                    
                    // [Custom Cornucopia_RSV_SVE] Night Fishing Bundle
                    
                    case ItemID.RSV_CardiaSeptalJellyfish:
                        return strFishBase("locationRidgeForest", "8pm", "2am", seasonList: new string[] { "spring", "fall", "winter" });
                    
                    /********** [Custom CC Bundles Cornucopia_RSV_SVE] Bulletin Board **********/
                    
                    // [Custom Cornucopia_RSV_SVE] Chef's Bundle
                    
                    case ItemID.SVE_BigBarkBurger:
                        return strCookRecipe("Big Bark Burger");
                    
                    case ItemID.RSV_PinkFrostedSprinkledDoughnut:
                        return strCookRecipe("Pink Frosted Sprinkled Doughnut");
                    
                    // [Custom Cornucopia_RSV_SVE] Home Cook's Bundle
                    
                    case ItemID.RSV_KeksStyleShortcake:
                        return strCookRecipe("Kek's Style Shortcake");
                    
                    case ItemID.CNC_Tofu:
                        return strPutItemInMachine(ItemID.CNC_Soybeans, ItemID.BC_CheesePress, itemQuantity: 2);
                    
                    /********** [Custom CC Bundles Cornucopia_RSV_SVE] The Missing Bundle **********/
                    
                    case ItemID.CNC_Watermelon:
                        return strSeasonalCrop("summer", quality);
                    
                    /********** [Custom CC Bundles Cornucopia_RSV] Bulletin Board **********/
                    
                    // [Custom Cornucopia_RSV] Children's Bundle
                    
                    case ItemID.RSV_WildAppleJuice:
                        return strCookRecipe("Wild Apple Juice");
                    
                    /********** [Minerva's Harder CC (Easy)] Pantry **********/
                    
                    // [Minerva's Easy] Animal Products Bundle
                    
                    case ItemID.IT_VoidEgg:
                        return strBuyFromKrobus() + "\n"
                             + str.Get("voidEggEvent") + (getCoopLevel() < 1? parenthesize(str.Get("animalReqCoopLv2")) : "") + "\n"
                             + strAnimalProduct("animalVoidChicken") + "\n"
                             + strFishPond(ItemID.IT_VoidSalmon, 9);
                    
                    // [Minerva's Easy] Artisan Products Bundle
                    
                    case ItemID.IT_DuckMayonnaise:
                        return strPutItemInMachine(ItemID.IT_DuckEgg, ItemID.BC_MayonnaiseMachine);
                    
                    /********** [Minerva's Harder CC (Easy)] Boiler Room **********/
                    
                    // [Minerva's Easy] Blacksmith's Bundle
                    
                    case ItemID.IT_CopperOre:
                        return str.Get("mineCopperOre") + "\n"
                             + strBuyFrom("shopBlacksmith") + "\n"
                             + str.Get("openAnyGeode") + "\n"
                             + strFishingChest() + "\n"
                             + str.Get("artifactDigging") + "\n"
                             + strLocationalForage("locationMines") + "\n"
                             + strPanning();
                    
                    case ItemID.IT_IronOre:
                        return str.Get("mineIronOre") + "\n"
                             + strBuyFrom("shopBlacksmith") + "\n"
                             + str.Get("openAnyGeode") + "\n"
                             + strFishingChest() + "\n"
                             + strLocationalForage("locationMines") + "\n"
                             + strPanning();
                    
                    case ItemID.IT_GoldOre:
                        return str.Get("mineGoldOre") + "\n"
                             + strBuyFrom("shopBlacksmith") + "\n"
                             + strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode) + "\n"
                             + strFishingChest() + "\n"
                             + strDroppedByMonster("Ghost") + "\n"
                             + strPanning();
                    
                    // [Minerva's Easy] Adventurer's Bundle
                    
                    case ItemID.IT_BugMeat:
                        return strDroppedByMonster(monsterKey: "monsterGeneralBug");
                    
                    /********** [Minerva's Harder CC (Easy)] Bulletin Board **********/
                    
                    // [Minerva's Easy] Saloon Menu Bundle
                    
                    case ItemID.IT_Chowder:
                        return strCookRecipe("Chowder");
                    
                    case ItemID.IT_CheeseCauliflower:
                        return strCookRecipe("Cheese Cauli.") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_EggplantParmesan:
                        return strCookRecipe("Eggplant Parm.") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    // [Minerva's Easy] Field Research Bundle
                    
                    case ItemID.IT_MagmaGeode:
                        return strHitRocks("locationMinesArea3") + "\n"
                             + strFishingChest() + "\n"
                             + strFishPond(ItemID.IT_LavaEel, 9);
                    
                    /********** [Minerva's Harder CC (Regular)] Pantry **********/
                    
                    // [Minerva's Regular] Animal Products Bundle
                    
                    case ItemID.IT_Milk:
                        return strAnimalProduct("animalCow");
                    
                    case ItemID.IT_GoatMilk:
                        return strAnimalProduct("animalGoat");
                    
                    /********** [Minerva's Harder CC (Regular)] Bulletin Board **********/
                    
                    // [Minerva's Regular] Saloon Menu Bundle
                    
                    case ItemID.IT_TroutSoup:
                        return strCookRecipe("Trout Soup") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_CrispyBass:
                        return strCookRecipe("Crispy Bass") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    // [Minerva's Regular] Field Research Bundle
                    
                    case ItemID.IT_OmniGeode:
                        return strHitRocks("locationMines21Plus") + "\n"
                             + strFishPond(ItemID.IT_Octopus, 9) + "\n"
                             + strDroppedByMonster("Carbon Ghost") + "\n"
                             + strBuyFromOasisWeekday("wednesday") + "\n"
                             + strBuyFromKrobusWeekday("tuesday") + "\n"
                             + strPanning() + "\n"
                             + str.Get(isTheatherKnown()? "winCraneGame" : "unknownSource");
                    
                    /********** [Minerva's Harder CC (Hard)] Bulletin Board **********/
                    
                    // [Minerva's Hard] Saloon Menu Bundle
                    
                    case ItemID.IT_ParsnipSoup:
                        return strCookRecipe("Parsnip Soup") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Coleslaw:
                        return strCookRecipe("Coleslaw");
                    
                    case ItemID.IT_FriedMushroom:
                        return strCookRecipe("Fried Mushroom") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    /********** [Minerva's Harder CC (OJRebalance)] Bulletin Board **********/
                    
                    // [Minerva's OJRebalance] Saloon Menu Bundle
                    
                    case ItemID.IT_BakedFish:
                        return strCookRecipe("Baked Fish") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_GlazedYams:
                        return strCookRecipe("Glazed Yams") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_FriedCalamari:
                        return strCookRecipe("Fried Calamari") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    /********** [Minerva's Harder CC (PPJA)] Crafts Room **********/
                    
                    // [Minerva's PPJA] Spring Foraging Bundle
                    
                    case ItemID.IT_RiceShoot:
                        return strBuyFrom(shopLiteral: str.Get("shopPierreSeason",
                                          new { season = str.Get("spring"), startingYear = getStartingYearString(2) })) + "\n"
                             + strFishingChest() + "\n"
                             + strDroppedByMonster("Grub");
                    
                    // [Minerva's PPJA] Crafting Bundle
                    
                    case ItemID.IT_WiltedBouquet:
                        return strPutItemInMachine(ItemID.IT_Bouquet, ItemID.BC_Furnace);
                    
                    /********** [Minerva's Harder CC (PPJA)] Boiler Room **********/
                    
                    // [Minerva's PPJA] Geologist's Bundle
                    
                    case ItemID.IT_Aerinite:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Kyanite:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Opal:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Slate:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Soapstone:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    /********** [Community Center Bundle Overhaul] Pantry **********/
                    
                    // [Bundle Overhaul] Animal Produce Bundle
                    
                    case ItemID.IT_BrownEgg:
                        return strAnimalProduct("animalChicken");
                    
                    case ItemID.IT_Egg:
                        return strAnimalProduct("animalChicken");
                    
                    // [Bundle Overhaul] Reduce, Reuse, Recycle Bundle
                    
                    case ItemID.IT_BrokenGlasses:
                        return str.Get("trash");
                    
                    case ItemID.IT_JojaCola:
                        return str.Get("trash") + "\n"
                             + (isJojaOpen()? strBuyFrom("shopJoja") + "\n" : "")
                             + strBuyFromRandom("shopSaloon");
                    
                    /********** [Community Center Bundle Overhaul] Fish Tank **********/
                    
                    // [Bundle Overhaul] Legendary Fish Bundle
                    
                    case ItemID.IT_MutantCarp:
                        return strFishBase(isSewerKnown()? "waterSewer" : "waterUnknown");
                    
                    case ItemID.IT_Angler:
                        return strFishBase("waterAnglerSpot", seasonKey: "fall", fishingLevel: 3, extraLinebreak: true);
                    
                    case ItemID.IT_Crimsonfish:
                        return strFishBase("waterCrimsonfishSpot", seasonKey: "summer", fishingLevel: 5, extraLinebreak: true);
                    
                    case ItemID.IT_Glacierfish:
                        return strFishBase("waterGlacierfishSpot", seasonKey: "winter", fishingLevel: 6, extraLinebreak: true);
                    
                    case ItemID.IT_Legend:
                        return strFishBase("waterLegendSpot", seasonKey: "spring", fishingLevel: 10, extraLinebreak: true);
                    
                    /********** [Community Center Bundle Overhaul] Boiler Room **********/
                    
                    // [Bundle Overhaul] Geology Bundle
                    
                    case ItemID.IT_Jamborite:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Alamite:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Fluorapatite:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_OceanStone:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_FairyStone:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_FireOpal:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Neptunite:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Helvite:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    /********** [Community Center Bundle Overhaul] Bulletin Board **********/
                    
                    // [Bundle Overhaul] Cooking Class Bundle
                    
                    case ItemID.IT_BlackberryCobbler:
                        return strCookRecipe("Blackberry Cobbler");
                    
                    case ItemID.IT_CrabCakes:
                        return strCookRecipe("Crab Cakes") + "\n"
                             + strDroppedByMonster("Iridium Crab");
                    
                    case ItemID.IT_RootsPlatter:
                        return strCookRecipe("Roots Platter") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_MapleBar:
                        return strCookRecipe("Maple Bar");
                    
                    case ItemID.IT_Sashimi:
                        return strCookRecipe("Sashimi") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    /********** [Alternate Bundles] Bulletin Board **********/
                    
                    // [Alternate Bundles] Chef's Bundle
                    
                    case ItemID.IT_Omelet:
                        return strCookRecipe("Omelet") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Hashbrowns:
                        return strCookRecipe("Hashbrowns") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Bread:
                        return strCookRecipe("Bread") + "\n"
                             + strBuyFrom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_Oil:
                        return strPutItemInMachine(itemLiteral: multiItem(ItemID.IT_Corn, ItemID.IT_SunflowerSeeds, ItemID.IT_Sunflower),
                                                   machineID: ItemID.BC_OilMaker);
                    
                    /********** [Easier Bundles] Fish Tank **********/
                    
                    // [Easier Bundles] River Fish Bundle
                    
                    case ItemID.IT_Esperite:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Calcite:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Orpiment:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    // [Easier Bundles] Lake Fish Bundle
                    
                    case ItemID.IT_Granite:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Limestone:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    /********** [Vegan Bundles] Fish Tank **********/
                    
                    // [Vegan Bundles] Sparkly Bundle
                    
                    case ItemID.IT_Geminite:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    /********** [Vegan Bundles] Boiler Room **********/
                    
                    // [Vegan Bundles] Explorer's Bundle
                    
                    case ItemID.IT_ChickenStatue:
                        return str.Get("artifactDigging") + "\n"
                             + strFishingChest(2);
                    
                    case ItemID.IT_GlassShards:
                        return str.Get("artifactDigging") + "\n"
                             + strFishingChest(2);
                    
                    /********** [Vegan Bundles] Bulletin Board **********/
                    
                    // [Vegan Bundles] Chef's Bundle
                    
                    case ItemID.IT_Rice:
                        return strBuyFrom(shopLiteral: getSeedShopsString()) + "\n"
                             + str.Get("putItemInMill", new { rawItem = getItemName(ItemID.IT_UnmilledRice) });
                    
                    /********** [Difficulty Option for Bundles (Very Hard)] The Missing Bundle **********/
                    
                    case ItemID.IT_SpicyEel:
                        return strCookRecipe("Spicy Eel") + "\n"
                             + strDroppedByMonster("Serpent") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday") + "\n"
                             + strFishPond(ItemID.IT_LavaEel, 9);
                    
                    case ItemID.IT_DinosaurEgg:
                        return strLocationalArtifact("locationMountains") + "\n"
                             + strFishingChest(2) + "\n"
                             + strDroppedByMonster("Pepper Rex") + "\n"
                             + strLocationalForage(isDesertKnown()? "locationSkullPrehistoric" : "locationUnknown") + "\n"
                             + str.Get(isTheatherKnown()? "winCraneGame" : "unknownSource");
                    
                    /********** [The Impossible Bundle] Pantry **********/
                    
                    // [The Impossible Bundle] Dwarf Bundle
                    
                    case ItemID.IT_DwarfScroll2:
                        return strLocationalForage("locationMinesArea1") + "\n"
                             + strDroppedByMonster(monsterKey: "monsterBlueSlime") + "\n"
                             + strDroppedByMonster("Dust Spirit") + "\n"
                             + strDroppedByMonster("Frost Bat") + "\n"
                             + strDroppedByMonster("Ghost");
                    
                    case ItemID.IT_DwarfScroll3:
                        return strDroppedByMonster(monsterKey: "monsterBRPCISlime") + "\n"
                             + strDroppedByMonster("Lava Bat") + "\n"
                             + strDroppedByMonster("Lava Crab") + "\n"
                             + strDroppedByMonster("Squid Kid") + "\n"
                             + strDroppedByMonster("Shadow Brute") + "\n"
                             + strDroppedByMonster("Shadow Shaman") + "\n"
                             + strDroppedByMonster("Metal Head");
                    
                    case ItemID.IT_DwarfScroll4:
                        return strLocationalForage("locationMinesArea3") + "\n"
                             + strDroppedByMonster(monsterKey: "monsterGeneralAnyInMines");
                    
                    /********** [The Impossible Bundle] The Edited Bundle **********/
                    
                    case ItemID.IT_BasicFertilizer:
                        return strCraftRecipe("Basic Fertilizer") + "\n"
                             + strBuyFrom("shopPierre");
                    
                    /********** [Very Hard for 1 Year Challenge 1.02] Bulletin Board **********/
                    
                    // [Very Hard 1YC 1.02] Cooking Bundle
                    
                    case ItemID.IT_RicePudding:
                        return strCookRecipe("Rice Pudding") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_AutumnsBounty:
                        return strCookRecipe("Autumn's Bounty") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_FishStew:
                        return strCookRecipe("Fish Stew");
                    
                    case ItemID.IT_TomKhaSoup:
                        return strCookRecipe("Tom Kha Soup") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    /********** [Very Hard for 1 Year Challenge 1.02C] Bulletin Board **********/
                    
                    // [Very Hard 1YC 1.02C] Cooking Bundle
                    
                    case ItemID.IT_StirFry:
                        return strCookRecipe("Stir Fry");
                    
                    case ItemID.IT_RadishSalad:
                        return strCookRecipe("Radish Salad");
                    
                    /********** [Legacy CC Bundles] Pantry **********/
                    
                    // [Legacy CC Bundles] Master Artisan Bundle
                    
                    case ItemID.IT_Sugar:
                        return strBuyFrom("shopPierre") + "\n"
                             + str.Get("putItemInMill", new { rawItem = getItemName(ItemID.IT_Beet) });
                    
                    /********** [Legacy CC Bundles] Bulletin Board **********/
                    
                    // [Legacy CC Bundles] Home Chef's Bundle
                    
                    case ItemID.IT_FriedEel:
                        return strCookRecipe("Fried Eel") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_ChocolateCake:
                        return strCookRecipe("Chocolate Cake") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    // [Legacy CC Bundles] Loved Cook's Bundle
                    
                    case ItemID.IT_StrangeBun:
                        return strCookRecipe("Strange Bun") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_BeanHotpot:
                        return strCookRecipe("Bean Hotpot") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    // [Legacy CC Bundles] Fisherman's Bundle
                    
                    case ItemID.IT_DressedSpinner:
                        return strBuyFrom("shopFish") + (Game1.player.FishingLevel < 8? levelRequirementString("fishing", 8) : "") + "\n"
                             + strCraftRecipe("Dressed Spinner") + "\n"
                             + strFishingChest(6);
                    
                    case ItemID.IT_CorkBobber:
                        return strBuyFrom("shopFish") + (Game1.player.FishingLevel < 7? levelRequirementString("fishing", 7) : "") + "\n"
                             + strCraftRecipe("Cork Bobber");
                    
                    case ItemID.IT_TrapBobber:
                        return strBuyFrom("shopFish") + (Game1.player.FishingLevel < 6? levelRequirementString("fishing", 6) : "") + "\n"
                             + strCraftRecipe("Trap Bobber");
                    
                    case ItemID.IT_TreasureHunter:
                        return strBuyFrom("shopFish") + (Game1.player.FishingLevel < 7? levelRequirementString("fishing", 7) : "") + "\n"
                             + strCraftRecipe("Treasure Hunter");
                    
                    /********** [Base Game Collections Tab] Farm & Forage **********/
                    
                    case ItemID.IT_Banana:
                        return strFruitTreeDuringSeason("treeBanana", "summer", isIslandKnown()? "shopIslandTrader" : "shopUnknown") + "\n"
                             + strFishPond(ItemID.IT_BlueDiscus, 4);
                    
                    case ItemID.IT_OstrichEgg:
                        return strAnimalProduct("animalOstrich");
                    
                    case ItemID.IT_TaroRoot:
                        return strGrowSeeds(ItemID.IT_TaroTuber, isIslandKnown()? parenthesize(strLocationalForage("locationIsland")) : "", quality)
                             + (isIslandKnown()? "\n" + subItemHints(ItemID.IT_TaroTuber, quality) : "");
                    
                    case ItemID.IT_TaroTuber: // For use in above Taro Root hint
                        return strBuyFrom("shopIslandTrader") + "\n"
                             + strDroppedByMonster("Tiger Slime") + "\n"
                             + strDroppedByMonster("Magma Duggy") + "\n"
                             + strFishPond(ItemID.IT_Lionfish, 4);
                    
                    case ItemID.IT_Pineapple:
                        return strGrowSeeds(ItemID.IT_PineappleSeeds, isIslandKnown()? parenthesize(strBuyFrom("shopIslandTrader")) : "", quality);
                    
                    case ItemID.IT_Mango:
                        return strFruitTreeDuringSeason("treeMango", "summer", isIslandKnown()? "shopIslandTrader" : "shopUnknown");
                    
                    case ItemID.IT_CinderShard:
                        return (isVolcanoKnown()? str.Get("gemCinderShard") : str.Get("unknownSource")) + "\n"
                             + strDroppedByMonster("Magma Sprite") + "\n"
                             + strDroppedByMonster("Magma Sparker") + "\n"
                             + strDroppedByMonster("Magma Duggy") + "\n"
                             + strDroppedByMonster("False Magma Cap") + "\n"
                             + strFishPond(ItemID.IT_Stingray, 7);
                    
                    case ItemID.IT_MagmaCap:
                        return (isVolcanoKnown()? strLocationalForage("locationVolcano") : str.Get("unknownSource")) + "\n"
                             + strDroppedByMonster("False Magma Cap") + "\n"
                             + strFishPond(ItemID.IT_Stingray, 4);
                    
                    case ItemID.IT_RadioactiveOre:
                        return str.Get("mineRadioactiveOre");
                    
                    case ItemID.IT_RadioactiveBar:
                        return strPutItemInMachine(ItemID.IT_RadioactiveOre, ItemID.BC_Furnace);
                    
                    case ItemID.IT_MysticSyrup:
                        return strTapTree("treeMystic");
                    
                    /********** [Base Game Collections Tab] Fish **********/
                    
                    case ItemID.IT_Stingray:
                        return strFishBase(isIslandKnown()? "waterIslandCove" : "waterUnknown");
                    
                    case ItemID.IT_Lionfish:
                        return strFishBase(isIslandKnown()? "waterIslandOcean" : "waterUnknown");
                    
                    case ItemID.IT_BlueDiscus:
                        return strFishBase(isIslandKnown()? "waterIslandRiver" : "waterUnknown");
                    
                    case ItemID.IT_SeaJelly:
                        return strFishBase("waterOcean") + "\n"
                             + strFishPond(ItemID.IT_Flounder, 7);
                    
                    case ItemID.IT_Goby:
                        return strFishBase("waterForestFalls");
                    
                    /********** [Base Game Collections Tab] Artifacts **********/
                    
                    case ItemID.IT_ChippedAmphora:
                        return strLocationalArtifact("locationTown");
                    
                    case ItemID.IT_Arrowhead:
                        return strLocationalArtifact("locationMountains") + "\n"
                             + strLocationalArtifact("locationForest");
                    
                    case ItemID.IT_ElvishJewelry:
                        return strLocationalArtifact("locationForest") + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_OrnamentalFan:
                        return strLocationalArtifact("locationBeach") + "\n"
                             + strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationTown");
                    
                    case ItemID.IT_RareDisc:
                        return strDroppedByMonster("Bat") + "\n"
                             + strDroppedByMonster("Shadow Brute") + "\n"
                             + strDroppedByMonster("Shadow Shaman") + "\n"
                             + strDroppedByMonster("Spider") + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_RustySpoon:
                        return strLocationalArtifact("locationTown") + "\n"
                             + strLocationalTilling("locationMines") + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_RustySpur:
                        return strLocationalArtifact("locationFarm") + "\n"
                             + strLocationalArtifact("locationMines") + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_AncientSeedArtifact:
                        return strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationMountains") + "\n"
                             + strFishingChest(2) + "\n"
                             + strDroppedByMonster("Bug") + "\n"
                             + strDroppedByMonster("Grub") + "\n"
                             + strDroppedByMonster("Fly");
                    
                    case ItemID.IT_PrehistoricTool:
                        return strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationMountains") + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_DriedStarfish:
                        return strLocationalArtifact("locationBeach") + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_Anchor:
                        return strLocationalArtifact("locationBeach") + "\n"
                             + strFishingChest();
                    
                    case ItemID.IT_PrehistoricHandaxe:
                        return strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationMountains");
                    
                    case ItemID.IT_DwarvishHelm:
                        return strLocationalTilling("locationMinesArea1") + "\n"
                             + strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_AncientDrum:
                        return strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationTown") + "\n"
                             + strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_GoldenRelic:
                        return strLocationalArtifact(isDesertKnown()? "locationDesert" : "locationUnknown");
                    
                    case ItemID.IT_StrangeDollGreen:
                        return strLocationalArtifact("locationFarm") + "\n"
                             + strLocationalArtifact("locationTown") + "\n"
                             + strLocationalArtifact("locationBeach") + "\n"
                             + strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationMountains") + "\n"
                             + strFishingChest(2) + "\n"
                             + strLocationalTilling("locationMines");
                    
                    case ItemID.IT_StrangeDollYellow:
                        return strLocationalArtifact("locationFarm") + "\n"
                             + strLocationalArtifact("locationTown") + "\n"
                             + strLocationalArtifact("locationBeach") + "\n"
                             + strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationMountains") + "\n"
                             + strFishingChest(2) + "\n"
                             + strLocationalTilling("locationMines");
                    
                    case ItemID.IT_PrehistoricScapula:
                        return strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationTown") + "\n"
                             + strDroppedByMonster("Skeleton") + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_PrehistoricTibia:
                        return strLocationalArtifact("locationForest") + "\n"
                             + strDroppedByMonster("Pepper Rex") + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_PrehistoricSkull:
                        return strLocationalArtifact("locationMountains") + "\n"
                             + strDroppedByMonster(monsterKey: "monsterHauntedSkull") + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_SkeletalHand:
                        return strLocationalArtifact("locationBeach") + "\n"
                             + strDroppedByMonster(monsterKey: "monsterHauntedSkull") + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_PrehistoricRib:
                        return strLocationalArtifact("locationTown") + "\n"
                             + strLocationalArtifact("locationFarm") + "\n"
                             + strDroppedByMonster("Pepper Rex") + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_PrehistoricVertebra:
                        return strLocationalArtifact("locationBus") + "\n"
                             + strDroppedByMonster("Pepper Rex") + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_SkeletalTail:
                        return strFishingChest() + "\n"
                             + strLocationalTilling("locationMines") + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_NautilusFossil:
                        return strLocationalArtifact("locationBeach") + "\n"
                             + strFishingChest() + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_PalmFossil:
                        return strLocationalArtifact(isDesertKnown()? "locationDesert" : "locationUnknown") + "\n"
                             + strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationBeach") + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    case ItemID.IT_Trilobite:
                        return strLocationalArtifact("locationBeach") + "\n"
                             + strLocationalArtifact("locationForest") + "\n"
                             + strLocationalArtifact("locationMountains") + "\n"
                             + (isIslandKnown()? str.Get("boneNode") : str.Get("unknownSource"));
                    
                    /********** [Base Game Collections Tab] Minerals **********/
                    
                    case ItemID.IT_Bixite:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Baryte:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Dolomite:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode) + "\n"
                             + strFishPond(ItemID.IT_Coral, 9);
                    
                    case ItemID.IT_Jagoite:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Lunarite:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Malachite:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_LemonStone:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Nekoite:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_ThunderEgg:
                        return strOpenGeode(ItemID.IT_Geode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Pyrite:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Tigerseye:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Jasper:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Marble:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Basalt:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Hematite:
                        return strOpenGeode(ItemID.IT_FrozenGeode, ItemID.IT_OmniGeode);
                    
                    case ItemID.IT_Obsidian:
                        return strOpenGeode(ItemID.IT_MagmaGeode, ItemID.IT_OmniGeode);
                    
                    /********** [Base Game Collections Tab] Cooking **********/
                    
                    case ItemID.IT_LuckyLunch:
                        return strCookRecipe("Lucky Lunch") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_CarpSurprise:
                        return strCookRecipe("Carp Surprise") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_RhubarbPie:
                        return strCookRecipe("Rhubarb Pie") + "\n"
                             + strBuyFromRandom("shopSaloon") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_FarmersLunch:
                        return strCookRecipe("Farmer's Lunch") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_DishOTheSea:
                        return strCookRecipe("Dish o' The Sea") + "\n"
                             + strBuyFromKrobusWeekday("saturday");
                    
                    case ItemID.IT_FiddleheadRisotto:
                        return strCookRecipe("Fiddlehead Risotto");
                    
                    case ItemID.IT_GingerAle:
                        return strCookRecipe("Ginger Ale");
                    
                    case ItemID.IT_BananaPudding:
                        return strCookRecipe("Banana Pudding");
                    
                    case ItemID.IT_MangoStickyRice:
                        return strCookRecipe("Mango Sticky Rice");
                    
                    case ItemID.IT_Poi:
                        return strCookRecipe("Poi");
                    
                    case ItemID.IT_TropicalCurry:
                        return strCookRecipe("Tropical Curry");
                    
                    /********** [Alchemistry Bundles] Pantry **********/
                    
                    // [Alchemistry] Spring Crops Bundle
                    
                    case ItemID.ALC_Hemlock:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.ALC_Inkberry:
                        return strSeasonalCrop("spring", quality);
                    
                    // [Alchemistry] Summer Crops Bundle
                    
                    case ItemID.ALC_StarlightHellebore:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.ALC_WerewolfsBane:
                        return strSeasonalCrop("summer", quality);
                    
                    // [Alchemistry] Fall Crops Bundle
                    
                    case ItemID.ALC_SunsetCastor:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.ALC_BansheesBell:
                        return strSeasonalCrop("fall", quality);
                    
                    // [Alchemistry] Magic Crops (Rare Crops) Bundle
                    
                    case ItemID.ALC_AddersTongue:
                        return strSeasonalCrop("spring", quality, "shopSevinae");
                    
                    case ItemID.ALC_DollsEyes:
                        return strSeasonalCrop("summer", quality, "shopSevinae");
                    
                    case ItemID.ALC_NightsShade:
                        return strSeasonalCrop("fall", quality, "shopSevinae");
                    
                    case ItemID.ALC_BleedingHeart:
                        return strSeasonalCrop("winter", quality, "shopSevinae");
                    
                    // [Alchemistry] Dried Herbs (Animal) Bundle
                    
                    case ItemID.ALC_DriedHemlock:
                        return strPutItemInMachine(ItemID.ALC_Hemlock, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedInkberry:
                        return strPutItemInMachine(ItemID.ALC_Inkberry, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedStarlightHellebore:
                        return strPutItemInMachine(ItemID.ALC_StarlightHellebore, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedWerewolfsBane:
                        return strPutItemInMachine(ItemID.ALC_WerewolfsBane, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedSunsetCastor:
                        return strPutItemInMachine(ItemID.ALC_SunsetCastor, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedBansheesBell:
                        return strPutItemInMachine(ItemID.ALC_BansheesBell, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedWinterWailer:
                        return strPutItemInMachine(ItemID.ALC_WinterWailer, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedMistletoe:
                        return strPutItemInMachine(ItemID.ALC_Mistletoe, ItemID.BC_Dehydrator);
                    
                    // [Alchemistry] Alchemist's Aquatic Goods (Fish Farmer's) Bundle
                    
                    case ItemID.ALC_OilOfNewt:
                        return strPutItemInMachine(ItemID.ALC_NewtsTail, ItemID.BC_OilMaker);
                    
                    case ItemID.ALC_FreshSqueezedLamprey:
                        return strPutItemInMachine(ItemID.ALC_Lamprey, ItemID.BC_OilMaker);
                    
                    case ItemID.ALC_ManaOrb:
                        return strPutItemInMachine(StardewValley.Object.FishCategory.ToString(), ItemID.ALC_BC_ManaExtractor) + "\n"
                             + strPutItemInMachine(itemLiteral: str.Get("itemCategoryBodyPart"), machineID: ItemID.ALC_BC_ManaExtractor);
                    
                    // [Alchemistry] Winter Crops (Garden) Bundle
                    
                    case ItemID.ALC_WinterWailer:
                        return strSeasonalCrop("winter", quality);
                    
                    case ItemID.ALC_Mistletoe:
                        return strSeasonalCrop("winter", quality);
                    
                    // [Alchemistry] Apothecary's Brews (Artisan) Bundle
                    
                    case ItemID.ALC_HemlockTincture:
                        return strPutItemInMachine(ItemID.ALC_HemlockPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_InkberryTincture:
                        return strPutItemInMachine(ItemID.ALC_InkberryPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_WerewolfsBaneTincture:
                        return strPutItemInMachine(ItemID.ALC_WerewolfsBanePowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_StarlightHelleboreTincture:
                        return strPutItemInMachine(ItemID.ALC_StarlightHelleborePowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_SunsetCastorTincture:
                        return strPutItemInMachine(ItemID.ALC_SunsetCastorPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_BansheesBellTincture:
                        return strPutItemInMachine(ItemID.ALC_BansheesBellPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_WinterWailerTincture:
                        return strPutItemInMachine(ItemID.ALC_WinterWailerPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_MistletoeTincture:
                        return strPutItemInMachine(ItemID.ALC_MistletoePowder, ItemID.ALC_BC_TinctureBin);
                    
                    // [Alchemistry] Apothecary's Rare Brews (Brewer's) Bundle
                    
                    case ItemID.ALC_AddersTongueTincture:
                        return strPutItemInMachine(ItemID.ALC_AddersTonguePowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_DollsEyesTincture:
                        return strPutItemInMachine(ItemID.ALC_DollsEyesPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_NightsShadeTincture:
                        return strPutItemInMachine(ItemID.ALC_NightsShadePowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_BleedingHeartTincture:
                        return strPutItemInMachine(ItemID.ALC_BleedingHeartPowder, ItemID.ALC_BC_TinctureBin);
                    
                    /********** [Alchemistry Bundles] Crafts Room **********/
                    
                    // [Alchemistry] Spring Foraging Bundle
                    
                    case ItemID.ALC_WizardsEye:
                        return strSeasonalLocationalForage("spring", "locationForest") + "\n"
                             + strSeasonalLocationalForage("spring", "locationWoods");
                    
                    case ItemID.ALC_NightCap:
                        return strSeasonalForage("spring");
                    
                    case ItemID.ALC_SunriseGlory:
                        return strSeasonalForage("spring");
                    
                    case ItemID.ALC_LostSouls:
                        return strSeasonalLocationalForage("spring", "locationWoods") + "\n"
                             + strSeasonalLocationalForage("spring", "locationMagesRest");
                    
                    case ItemID.ALC_WitchsWatcher:
                        return strLocationalBushForage("spring", 8, 14, "locationForest") + "\n"
                             + strLocationalBushForage("spring", 22, 28, "locationForest");
                    
                    // [Alchemistry] Summer Foraging Bundle
                    
                    case ItemID.ALC_LunarGlowcap:
                        return strSeasonalForage("summer");
                    
                    case ItemID.ALC_RedSmilers:
                        return strSeasonalLocationalForage("summer", "locationMagesRest");
                    
                    case ItemID.ALC_BeachedOyster:
                        return strLocationalForage("locationBeach")
                             + (isDesertKnown()? "\n" + strLocationalForage("locationDesert") : "");
                    
                    case ItemID.ALC_FalseMorel:
                        return strSeasonalLocationalForage("summer", "locationWoods") + "\n"
                             + strSeasonalLocationalForage("summer", "locationMagesRest");
                    
                    case ItemID.ALC_WeepingWidow:
                        return strBushForageDayRange("summer", 8, 14) + "\n"
                             + strBushForageDayRange("summer", 22, 28);
                    
                    // [Alchemistry] Fall Foraging Bundle
                    
                    case ItemID.ALC_InkCap:
                        return strSeasonalLocationalForage("fall", "locationWoods") + "\n"
                             + strSeasonalLocationalForage("fall", "locationMagesRest");
                    
                    case ItemID.ALC_MeteorCap:
                        return strSeasonalForage("fall");
                    
                    case ItemID.ALC_HellfireBolete:
                        return strSeasonalLocationalForage("fall", "locationForest") + "\n"
                             + strSeasonalLocationalForage("fall", "locationMagesRest");
                    
                    case ItemID.ALC_CapOLantern:
                        return strSeasonalLocationalForage("fall", "locationWoods") + "\n"
                             + strSeasonalLocationalForage("fall", "locationMagesRest");
                    
                    case ItemID.ALC_SoulFruit:
                        return strLocationalBushForage("fall", 12, 16, "locationForest") + "\n"
                             + strLocationalBushForage("fall", 24, 28, "locationForest");
                    
                    // [Alchemistry] Winter Foraging Bundle
                    
                    case ItemID.ALC_DawnsingerToadstool:
                        return strSeasonalForage("winter");
                    
                    case ItemID.ALC_FairieWings:
                        return strSeasonalLocationalForage("winter", "locationForest") + "\n"
                             + strSeasonalLocationalForage("winter", "locationWoods");
                    
                    case ItemID.ALC_PoisonPine:
                        return strBushForageDayRange("winter", 3, 7) + "\n"
                             + strBushForageDayRange("winter", 15, 18) + "\n"
                             + strBushForageDayRange("winter", 24, 28);
                    
                    // [Alchemistry] Dried Mushrooms (Construction) Bundle
                    
                    case ItemID.ALC_DriedNightCap:
                        return strPutItemInMachine(ItemID.ALC_NightCap, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedInkCap:
                        return strPutItemInMachine(ItemID.ALC_InkCap, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedBeachedOyster:
                        return strPutItemInMachine(ItemID.ALC_BeachedOyster, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedLunarGlowcap:
                        return strPutItemInMachine(ItemID.ALC_LunarGlowcap, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedMeteorCap:
                        return strPutItemInMachine(ItemID.ALC_MeteorCap, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedHellfireBolete:
                        return strPutItemInMachine(ItemID.ALC_HellfireBolete, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedDawnsingerToadstool:
                        return strPutItemInMachine(ItemID.ALC_DawnsingerToadstool, ItemID.BC_Dehydrator);
                    
                    // [Alchemistry] More Dried Mushrooms (Sticky) Bundle
                    
                    case ItemID.ALC_DriedLostSouls:
                        return strPutItemInMachine(ItemID.ALC_LostSouls, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedRedSmilers:
                        return strPutItemInMachine(ItemID.ALC_RedSmilers, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedCapOLantern:
                        return strPutItemInMachine(ItemID.ALC_CapOLantern, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedFairieWings:
                        return strPutItemInMachine(ItemID.ALC_FairieWings, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedFalseMorel:
                        return strPutItemInMachine(ItemID.ALC_FalseMorel, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedSunriseGlory:
                        return strPutItemInMachine(ItemID.ALC_SunriseGlory, ItemID.BC_Dehydrator);
                    
                    case ItemID.ALC_DriedWizardsEye:
                        return strPutItemInMachine(ItemID.ALC_WizardsEye, ItemID.BC_Dehydrator);
                    
                    // [Alchemistry] Forest Foraging (Forest) Bundle
                    
                    case ItemID.ALC_BirdSkull:
                        return strLocationalForage("locationForest") + "\n"
                             + strLocationalForage("locationWoods") + "\n"
                             + strLocationalForage("locationMountains") + "\n"
                             + strLocationalForage("locationBeach");
                    
                    case ItemID.ALC_StagsAntler:
                        return strSeasonalLocationalForage(seasonList: new string[] { "spring", "winter" }, locationKey: "locationForest") + "\n"
                             + strSeasonalLocationalForage(seasonList: new string[] { "spring", "winter" }, locationKey: "locationWoods");
                    
                    case ItemID.ALC_DeerHoof:
                        return strLocationalForage("locationForest") + "\n"
                             + strLocationalForage("locationWoods");
                    
                    case ItemID.ALC_DragonRoot:
                        return strLocationalForage("locationMagesRest");
                    
                    // [Alchemistry] Bush's Bounty (Exotic Foraging) Bundle
                    
                    case ItemID.ALC_MoonBerry:
                        return str.Get("bushForage");
                    
                    // [Alchemistry] Nature's Magic (Wild Medicine) Bundle
                    
                    case ItemID.ALC_AquaticEctoplasm:
                        return strPutItemInMachine(StardewValley.Object.FishCategory.ToString(), ItemID.ALC_BC_EssenceRestabilizer) + "\n"
                             + strFishPond(ItemID.ALC_Lamprey, 6);
                    
                    case ItemID.ALC_WildEctoplasm:
                        return strPutItemInMachine(itemLiteral: str.Get("itemCategoryBodyPart"), machineID: ItemID.ALC_BC_EssenceRestabilizer);
                    
                    case ItemID.ALC_MysticEctoplasm:
                        return strPutItemInMachine(ItemID.ALC_TrappedSoul, ItemID.ALC_BC_EssenceRestabilizer);
                    
                    /********** [Alchemistry Bundles] Fish Tank **********/
                    
                    // [Alchemistry] River Fish Bundle
                    
                    case ItemID.ALC_Lamprey:
                        return strFishBase(waterList: new string[] { "waterForestRiver", "waterTown" },
                                           seasonList: new string[] { "spring", "fall" }) + "\n"
                             + strFishBase("waterSwamp");
                    
                    // [Alchemistry] Lake Fish Bundle
                    
                    case ItemID.ALC_Newt:
                        return strFishBase(waterList: new string[] { "waterForestRiver", "waterMountain" },
                                           seasonList: new string[] { "spring", "summer", "fall" });
                    
                    // [Alchemistry] Ocean Fish Bundle
                    
                    case ItemID.ALC_VampireAnemone:
                        return strFishBase("waterOcean", seasonList: new string[] { "spring", "summer" })
                             + (isIslandKnown()? "\n" + strFishBase("waterIsland") : "");
                    
                    case ItemID.ALC_MoonlightJellyfish:
                        return strFishBase("waterOcean", seasonKey: "summer");
                    
                    // [Alchemistry] Aquatic Harvester's (Night Fishing) Bundle
                    
                    case ItemID.ALC_NewtsTail:
                        return strFishPond(ItemID.ALC_Newt);
                    
                    case ItemID.ALC_MoonlightJelly:
                        return strFishPond(ItemID.ALC_MoonlightJellyfish);
                    
                    case ItemID.ALC_CuredMoonlightJelly:
                        return strPutItemInMachine(ItemID.ALC_MoonlightJelly, ItemID.BC_PreservesJar);
                    
                    // [Alchemistry] Specialty Fish Bundle
                    
                    case ItemID.ALC_ZombieFish:
                        return strFishBase("waterMagesRest");
                    
                    /********** [Alchemistry Bundles] Boiler Room **********/
                    
                    // [Alchemistry] Gemologist's (Geologist's) Bundle
                    
                    case ItemID.ALC_MagmaRuby:
                        return strPutItemInMachine(ItemID.IT_Ruby, ItemID.ALC_BC_TransmuterCoil);
                    
                    case ItemID.ALC_MoonlitTear:
                        return strPutItemInMachine(ItemID.IT_Diamond, ItemID.ALC_BC_TransmuterCoil);
                    
                    case ItemID.ALC_NaturesEmerald:
                        return strPutItemInMachine(ItemID.IT_Emerald, ItemID.ALC_BC_TransmuterCoil);
                    
                    case ItemID.ALC_MagiWand:
                        return strPutItemInMachine(ItemID.IT_Amethyst, ItemID.ALC_BC_TransmuterCoil);
                    
                    // [Alchemistry] Adventurer's Bundle
                    
                    case ItemID.ALC_TrappedSoul:
                        return strDroppedByMonster("Ghost") + "\n"
                             + strDroppedByMonster("Putrid Ghost") + "\n"
                             + strDroppedByMonster("Carbon Ghost");
                    
                    case ItemID.ALC_EngorgedTick:
                        return strDroppedByMonster("Bat") + "\n"
                             + strDroppedByMonster("Frost Bat") + "\n"
                             + strDroppedByMonster("Lava Bat") + "\n"
                             + strDroppedByMonster("Iridium Bat");
                    
                    case ItemID.ALC_InsectMandible:
                        return strDroppedByMonster("Fly") + "\n"
                             + strDroppedByMonster("Bug");
                    
                    case ItemID.ALC_VampireFang:
                        return strDroppedByMonster("Lava Bat") + "\n"
                             + strDroppedByMonster("Iridium Bat");
                    
                    case ItemID.ALC_ShadowEye:
                        return strDroppedByMonster("Shadow Brute") + "\n"
                             + strDroppedByMonster("Shadow Shaman") + "\n"
                             + strDroppedByMonster("Shadow Sniper");
                    
                    // [Alchemistry] Treasure Hunter's Bundle
                    
                    case ItemID.ALC_IridiumCrabClaw:
                        return strDroppedByMonster("Iridium Crab");
                    
                    case ItemID.ALC_RottingBrain:
                        return strDroppedByMonster("Mummy") + "\n"
                             + strDroppedByMonster("Skeleton Warrior");
                    
                    case ItemID.ALC_ForkedLasher:
                        return strDroppedByMonster("Serpent") + "\n"
                             + strDroppedByMonster("Royal Serpent");
                    
                    // [Alchemistry] Engineer's Extractions (Engineer's) Bundle
                    
                    case ItemID.ALC_EmptyFlask:
                        return strPutItemInMachine(ItemID.IT_RefinedQuartz, ItemID.BC_Furnace) + "\n"
                             + strBuyFrom("shopClinic") + "\n"
                             + strBuyFrom("shopSevinae");
                    
                    /********** [Alchemistry Bundles] Bulletin Board **********/
                    
                    // [Alchemistry] On the Grind (Chef's) Bundle
                    
                    case ItemID.ALC_BoneDust:
                        return strPutItemInMachine(ItemID.ALC_BirdSkull, ItemID.ALC_BC_MortarPestle) + "\n"
                             + strPutItemInMachine(ItemID.ALC_StagsAntler, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_HemlockPowder:
                        return strPutItemInMachine(ItemID.ALC_DriedHemlock, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_InkberryPowder:
                        return strPutItemInMachine(ItemID.ALC_DriedInkberry, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_WerewolfsBanePowder:
                        return strPutItemInMachine(ItemID.ALC_DriedWerewolfsBane, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_StarlightHelleborePowder:
                        return strPutItemInMachine(ItemID.ALC_DriedStarlightHellebore, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_SunsetCastorPowder:
                        return strPutItemInMachine(ItemID.ALC_DriedSunsetCastor, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_BansheesBellPowder:
                        return strPutItemInMachine(ItemID.ALC_DriedBansheesBell, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_WinterWailerPowder:
                        return strPutItemInMachine(ItemID.ALC_DriedWinterWailer, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_MistletoePowder:
                        return strPutItemInMachine(ItemID.ALC_DriedMistletoe, ItemID.ALC_BC_MortarPestle);
                    
                    // [Alchemistry] Mushroom Tinctures (Field Research) Bundle
                    
                    case ItemID.ALC_WizardsEyeTincture:
                        return strPutItemInMachine(ItemID.ALC_WizardsEyePowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_MeteorCapTincture:
                        return strPutItemInMachine(ItemID.ALC_MeteorCapPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_LunarGlowcapTincture:
                        return strPutItemInMachine(ItemID.ALC_LunarGlowcapPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_CapOLanternTincture:
                        return strPutItemInMachine(ItemID.ALC_CapOLanternPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_InkCapTincture:
                        return strPutItemInMachine(ItemID.ALC_InkCapPowder, ItemID.ALC_BC_TinctureBin);
                    
                    case ItemID.ALC_DawnsingerToadstoolTincture:
                        return strPutItemInMachine(ItemID.ALC_DawnsingerToadstoolPowder, ItemID.ALC_BC_TinctureBin);
                    
                    // [Alchemistry] Precious Potions (Dye) Bundle
                    
                    case ItemID.ALC_BarkskinElixir:
                        return strAlchemistryCauldron("Morghoula.AlchemistryCP_BarkskinElixir");
                    
                    case ItemID.ALC_LesserWylderBrew:
                        return strAlchemistryCauldron("Morghoula.AlchemistryCP_LesserWylderBrew");
                    
                    case ItemID.ALC_TearOfDreamer:
                        return strAlchemistryCauldron("Morghoula.AlchemistryCP_TearofDreamer");
                    
                    case ItemID.ALC_Polaritea:
                        return strAlchemistryCauldron("Morghoula.AlchemistryCP_Polaritea");
                    
                    case ItemID.ALC_IronbarkElixir:
                        return strAlchemistryCauldron("Morghoula.AlchemistryCP_IronbarkElixir");
                    
                    case ItemID.ALC_GreaterWylderBrew:
                        return strAlchemistryCauldron("Morghoula.AlchemistryCP_GreaterWylderBrew");
                    
                    // [Alchemistry] Chemist's (Fodder) Bundle
                    
                    case ItemID.ALC_Glycerin:
                        return strAlchemistryCauldron("Morghoula.AlchemistryCP_Glycerin_Recipe");
                    
                    case ItemID.ALC_Lye:
                        return strCookRecipe("Morghoula.AlchemistryCP_Lye_Recipe");
                    
                    case ItemID.ALC_MoonBerryTincture:
                        return strPutItemInMachine(ItemID.ALC_MoonBerryPowder, ItemID.ALC_BC_TinctureBin);
                    
                    // [Alchemistry] Witch's Rare Reagents (Children's) Bundle
                    
                    case ItemID.ALC_ForestWisp:
                        return strSeasonalLocationalForage(seasonList: new string[] { "summer", "winter" }, locationKey: "locationWoods");
                    
                    // [Alchemistry] Back to the Grind (Home Cook's) Bundle
                    
                    case ItemID.ALC_AddersTonguePowder:
                        return strPutItemInMachine(ItemID.ALC_DriedAddersTongue, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_DollsEyesPowder:
                        return strPutItemInMachine(ItemID.ALC_DriedDollsEyes, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_NightsShadePowder:
                        return strPutItemInMachine(ItemID.ALC_DriedNightsShade, ItemID.ALC_BC_MortarPestle);
                    
                    case ItemID.ALC_BleedingHeartPowder:
                        return strPutItemInMachine(ItemID.ALC_DriedBleedingHeart, ItemID.ALC_BC_MortarPestle);
                    
                    /********** [Alchemistry Bundles] The Missing Bundle **********/
                    
                    case ItemID.ALC_ArcaneEye:
                        return strPutItemInMachine(ItemID.ALC_ShadowEye, ItemID.ALC_BC_TransmuterCoil) + "\n"
                             + strFishPond(ItemID.ALC_VampireAnemone, 10);
                    
                    /********** Additional/Orphaned Base Game Item Hints **********/
                    
                    case ItemID.IT_LuckyPurpleShorts:
                        return str.Get("luckyShorts")
                            + (modRegistry.IsLoaded("ppja.artisanvalleyPFM")? // Artisan Valley machine rules
                               "\n" + strPutItemInMachine(ItemID.IT_Amethyst, ItemID.BC_Loom) : "");
                    
                    case ItemID.IT_WildBait:
                        return strCraftRecipe("Wild Bait");
                    
                    /********** Orphaned Cornucopia Item Hints (from JSON asset references in Minerva's PPJA) **********/
                    
                    case ItemID.CNC_Honeysuckle:
                        return strSeasonalCrop(seasonList: new string[] { "spring", "summer" }, quality: quality, shopKey: "shopMarnie");
                    
                    case ItemID.CNC_Spinach:
                        return strSeasonalCrop(seasonList: new string[] { "spring", "fall" }, quality: quality);
                    
                    case ItemID.CNC_PassionFruit:
                        return strSeasonalCrop("spring", quality);
                    
                    case ItemID.CNC_Chives:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.CNC_ClarySage:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.CNC_Oregano:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.CNC_Sugarcane:
                        return strSeasonalCrop("summer", quality, shopKey: isDesertKnown()? "shopOasis" : "shopUnknown");
                    
                    case ItemID.CNC_SweetPotato:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.CNC_Jasmine:
                        return strSeasonalCrop("fall", quality);
                    
                    case ItemID.CNC_Mint:
                        return strSeasonalCrop("winter", quality);
                    
                    case ItemID.CNC_WasabiRoot:
                        return strSeasonalCrop("summer", quality);
                    
                    case ItemID.CNC_Lime:
                        return strFruitTreeDuringSeason("treeLime", "spring");
                    
                    case ItemID.CNC_Papaya:
                        return strFruitTreeDuringSeason("treePapaya", "summer", isDesertKnown()? "shopOasis" : "shopUnknown");
                    
                    case ItemID.CNC_Walnut:
                        return strFruitTreeDuringSeason("treeWalnut", "fall");
                    
                    case ItemID.CNC_Persimmon:
                        return strFruitTreeDuringSeason("treePersimmon", "winter");
                    
                    case ItemID.CNC_Shiitake:
                        return strSeasonalCrop(seasonList: new string[] { "spring", "fall" }, quality: quality, startingYear: 4)
                             + (modRegistry.IsLoaded("alja.FTMCCCB")? // Challenging CC Bundles bundle forage pack
                                "\n" + strSeasonalForage("fall") : "");
                    
                    case ItemID.CNC_EucalyptusLeaves:
                        return strFruitTreeDuringSeason("treeEucalyptus", "spring", "shopClinic", startingYear: 2);
                    
                    /********** Orphaned SVE Item Hints (from older versions of Challenging CC Bundles) **********/
                    
                    case ItemID.SVE_Clownfish:
                        return strFishBase(waterList: new string[] { "waterOcean", "waterBlueMoonVineyard" },
                                           start: "10am", end: "5pm", weatherKey: "weatherSun")
                             + (isIslandKnown()? "\n" + strFishBase("waterIsland", "10am", "5pm", weatherKey: "weatherSun") : "");
                    
                    case ItemID.SVE_KingSalmon:
                        return strFishBase("waterForestWest", "6am", "10pm", seasonList: new string[] { "spring", "summer" });
                    
                    case ItemID.SVE_VoidSalmonSushi:
                        return strCookRecipe("Void Salmon Sushi");
                    
                    /********** Orphaned More Fish Mod Item Hints (from Minerva's PPJA using old numerical IDs) **********/
                    
                    case ItemID.MFM_Starfish:
                    case ItemID.MNF_Starfish:
                        return strLocationalForage("locationBeach");
                    
                    case ItemID.MFM_CrownOfThornsStarfish:
                    case ItemID.MNF_CrownOfThornsStarfish:
                        return strLocationalForage("locationBeach");
                    
                    case ItemID.MFM_HolyGrenadeStarfish:
                    case ItemID.MNF_HolyGrenadeStarfish:
                        return strLocationalForage("locationBeach");
                    
                    case ItemID.MFM_Lionhead:
                    case ItemID.MNF_Lionhead:
                        return strFishBase("waterForestPond", "8am", "4pm", "spring", "weatherSun");
                    
                    case ItemID.MFM_Pacu:
                    case ItemID.MNF_Pacu:
                        return strFishBase(waterList: new string[] { "waterRivers", "waterMountain" },
                                           seasonList: new string[] { "spring", "summer", "fall" });
                    
                    case ItemID.MFM_GreenTerror:
                    case ItemID.MNF_GreenTerror:
                        return strFishBase("waterTown", "6am", "6pm",
                                           seasonList: new string[] { "spring", "summer" }, weatherKey: "weatherSun");
                    
                    case ItemID.MFM_Ladyfish:
                    case ItemID.MNF_Ladyfish:
                        return strFishBase("waterOcean", "6am", "7pm",
                                           seasonList: new string[] { "spring", "summer" }, weatherKey: "weatherSun");
                    
                    case ItemID.MFM_Barracuda:
                    case ItemID.MNF_Barracuda:
                        return strFishBase("waterOcean", "10am", "7pm", "spring", "weatherSun");
                    
                    case ItemID.MFM_ZebraTilapia:
                    case ItemID.MNF_ZebraTilapia:
                        return strFishBase("waterMountain", "8am", "4pm",
                                           seasonList: new string[] { "spring", "summer" }, weatherKey: "weatherSun");
                    
                    case ItemID.MFM_ClownLoach:
                    case ItemID.MNF_ClownLoach:
                        return strFishBase(waterList: new string[] { "waterForestPond", "waterMountain" },
                                           seasonList: new string[] { "spring", "summer" });
                    
                    case ItemID.MFM_Elephantfish:
                    case ItemID.MNF_Elephantfish:
                        return strFishBase(waterList: new string[] { "waterForestPond", "waterMountain" },
                                           start: "8am", end: "8pm", seasonList: new string[] { "spring", "summer" },
                                           weatherKey: "weatherSun");
                    
                    case ItemID.MFM_YamabukiKoi:
                    case ItemID.MNF_YamabukiKoi:
                        return strFishBase("waterWoods", "6am", "12am", "spring", "weatherRain");
                    
                    case ItemID.MFM_Pangasius:
                    case ItemID.MNF_Pangasius:
                        return strFishBase(waterList: new string[] { "waterForestPond", "waterMountain" },
                                           seasonList: new string[] { "spring", "summer", "fall" });
                    
                    case ItemID.MFM_KohakuKoi:
                    case ItemID.MNF_KohakuKoi:
                        return strFishBase("waterWoods", seasonKey: "spring");
                    
                    case ItemID.MFM_Comet:
                    case ItemID.MNF_Comet:
                        return strFishBase("waterForestPond", "8am", "4pm", "summer");
                    
                    case ItemID.MFM_Tucunare:
                    case ItemID.MNF_Tucunare:
                        return strFishBase("waterForestRiver", "6am", "4pm", "summer", "weatherRain");
                    
                    case ItemID.MFM_FreshwaterPufferfish:
                    case ItemID.MNF_FreshwaterPufferfish:
                        return strFishBase("waterRivers", seasonKey: "summer", weatherKey: "weatherRain");
                    
                    case ItemID.MFM_Anochoviella:
                    case ItemID.MNF_Anochoviella:
                        return strFishBase("waterOcean", "6am", "4pm",
                                           seasonList: new string[] { "spring", "summer" }, weatherKey: "weatherRain");
                    
                    case ItemID.MFM_RibbonEel:
                    case ItemID.MNF_RibbonEel:
                        return strFishBase("waterOcean", "8pm", "2am", "summer", "weatherSun");
                    
                    case ItemID.MFM_SmallMantaRay:
                    case ItemID.MNF_SmallMantaRay:
                        return strFishBase("waterOcean", "8am", "2pm", "summer");
                    
                    case ItemID.MFM_SmallSwordfish:
                    case ItemID.MNF_SmallSwordfish:
                        return strFishBase("waterOcean", "12pm", "6pm", "fall");
                    
                    case ItemID.MFM_BlueRingedOctopus:
                    case ItemID.MNF_BlueRingedOctopus:
                        return strFishBase("waterOcean", "6am", "12pm", "fall");
                    
                    case ItemID.MFM_GhostEel:
                    case ItemID.MNF_GhostEel:
                        return strFishBase("waterOcean", "8pm", "2am", "fall");
                    
                    case ItemID.MFM_ClownKnifefish:
                    case ItemID.MNF_ClownKnifefish:
                        return strFishBase("waterMountain", "12pm", "12am", "fall");
                    
                    case ItemID.MFM_RedtailShark:
                    case ItemID.MNF_RedtailShark:
                        return strFishBase(waterList: new string[] { "waterForestPond", "waterMountain" },
                                           start: "10am", end: "8pm", seasonKey: "fall");
                    
                    case ItemID.MFM_GhostKoi:
                    case ItemID.MNF_GhostKoi:
                        return strFishBase("waterWoods", "6am", "12am", "fall", "weatherRain");
                    
                    case ItemID.MFM_Telescope:
                    case ItemID.MNF_Telescope:
                        return strFishBase("waterForestPond", "6am", "6pm", "fall", "weatherRain");
                    
                    case ItemID.MFM_Trahira:
                    case ItemID.MNF_Trahira:
                        return strFishBase(waterList: new string[] { "waterTown", "waterMountain" },
                                           seasonList: new string[] { "spring", "summer", "fall" }) + "\n"
                             + strFishBase("waterForestRiver", seasonList: new string[] { "spring", "summer" }) + "\n"
                             + strFishBase(isSewerKnown()? "waterSewer" : "waterUnknown");
                    
                    case ItemID.MFM_CommonPleco:
                    case ItemID.MNF_CommonPleco:
                        return strFishBase(waterList: new string[] { "waterForestPond", "waterTown" },
                                           start: "6pm", end: "2am", seasonList: new string[] { "summer", "fall" },
                                           weatherKey: "weatherRain") + "\n"
                             + strFishBase("waterMountain", "6pm", "2am", "fall", "weatherRain");
                    
                    case ItemID.MFM_SnowballPleco:
                    case ItemID.MNF_SnowballPleco:
                        return strFishBase(waterList: new string[] { "waterForestPond", "waterTown", "waterMountain" },
                                           start: "6pm", end: "2am", seasonKey: "winter");
                    
                    case ItemID.MFM_ArcticChar:
                    case ItemID.MNF_ArcticChar:
                        return strFishBase("waterForestRiver", "8am", "6pm", "winter");
                    
                    case ItemID.MFM_Ide:
                    case ItemID.MNF_Ide:
                        return strFishBase(waterList: new string[] { "waterForestPond", "waterMountain" },
                                           start: "6am", end: "6pm", seasonKey: "winter");
                    
                    case ItemID.MFM_ShiroUtsuriKoi:
                    case ItemID.MNF_ShiroUtsuriKoi:
                        return strFishBase("waterWoods", seasonKey: "winter");
                    
                    case ItemID.MFM_Sauger:
                    case ItemID.MNF_Sauger:
                        return strFishBase(waterList: new string[] { "waterForestPond", "waterMountain" },
                                           start: "8am", end: "6pm", seasonKey: "winter");
                    
                    case ItemID.MFM_Tench:
                    case ItemID.MNF_Tench:
                        return strFishBase(waterList: new string[] { "waterForestPond", "waterMountain" },
                                           start: "6am", end: "4pm", seasonList: new string[] { "fall", "winter" });
                    
                    case ItemID.MFM_Haddock:
                    case ItemID.MNF_Haddock:
                        return strFishBase("waterOcean", "10am", "8pm", seasonList: new string[] { "fall", "winter" });
                    
                    case ItemID.MFM_Hagfish:
                    case ItemID.MNF_Hagfish:
                        return strFishBase("waterOcean", "8am", "6pm", "winter");
                    
                    case ItemID.MFM_KingCrab:
                    case ItemID.MNF_KingCrab:
                        return strFishBase("waterOcean", "8am", "10pm", "winter");
                    
                    case ItemID.MFM_FreshwaterCrab:
                    case ItemID.MNF_FreshwaterCrab:
                        return strCrabPot("waterTypeFresh");
                    
                    case ItemID.MFM_FreshwaterShrimp:
                    case ItemID.MNF_FreshwaterShrimp:
                        return strCrabPot("waterTypeFresh");
                    
                    case ItemID.MFM_Jellyfish:
                    case ItemID.MNF_Jellyfish:
                        return strCrabPot("waterTypeOcean");
                    
                    case ItemID.MFM_SwimmerCrab:
                    case ItemID.MNF_SwimmerCrab:
                        return strCrabPot("waterTypeOcean");
                    
                    case ItemID.MFM_Prawn:
                    case ItemID.MNF_Prawn:
                        return strCrabPot("waterTypeOcean");
                    
                    case ItemID.MFM_Nautilus:
                    case ItemID.MNF_Nautilus:
                        return strCrabPot("waterTypeOcean");
                    
                    case ItemID.MFM_BriefSquid:
                    case ItemID.MNF_BriefSquid:
                        return strCrabPot("waterTypeOcean");
                    
                    case ItemID.MFM_SandDollar:
                    case ItemID.MNF_SandDollar:
                        return strCrabPot("waterTypeOcean");
                    
                    case ItemID.MFM_BlueDragonSlug:
                    case ItemID.MNF_BlueDragonSlug:
                        return strCrabPot("waterTypeOcean");
                    
                    case ItemID.MFM_TigerFish:
                    case ItemID.MNF_TigerFish:
                        return strFishBase(isDesertKnown()? "waterDesert" : "waterUnknown", "8am", "2am");
                    
                    case ItemID.MFM_ElectricCatfish:
                    case ItemID.MNF_ElectricCatfish:
                        return strFishBase(isDesertKnown()? "waterDesert" : "waterUnknown");
                    
                    case ItemID.MFM_Blinky:
                    case ItemID.MNF_Blinky:
                        return strFishBase("waterSewer");
                    
                    case ItemID.MFM_Glassfish:
                    case ItemID.MNF_Glassfish:
                        return strFishBase("waterMines");
                    
                    case ItemID.MFM_Coelacanth:
                    case ItemID.MNF_Coelacanth:
                        return strFishBase("waterMines", "6am", "2am");
                    
                    case ItemID.MFM_Barreleye:
                    case ItemID.MNF_Barreleye:
                        return strFishBase("waterMines", "8pm", "2am");
                    
                    case ItemID.MFM_Lungfish:
                    case ItemID.MNF_Lungfish:
                        return strFishBase(isDesertKnown()? "waterDesert" : "waterUnknown", "8am", "2am");
                    
                    case ItemID.MFM_TrappedSoul:
                    case ItemID.MNF_TrappedSoul:
                        return strFishBase("waterSwamp");
                }
                
                // If item ID was not matched and category is specified, look for category match.
                
                switch (category)
                {
                    /********** [Base Game Remixed Bundles] Bulletin Board **********/
                    
                    // [Remixed] Home Cook's Bundle
                    
                    case StardewValley.Object.EggCategory:
                        return strAnimalProduct("animalChicken") + "\n"
                             + strAnimalProduct("animalDuck") + "\n"
                             + strAnimalProduct("animalOstrich");
                    
                    case StardewValley.Object.MilkCategory:
                        return strAnimalProduct("animalCow") + "\n"
                             + strAnimalProduct("animalGoat");
                }
                
                // If neither the item ID nor category was covered above, search by name.
                // This should only be for items from mods that have not yet been updated to give them the new string IDs.
                
                switch (getItemName(id, true))
                {
                    /********** [Minerva's Harder CC (PPJA)] Crafts Room **********/
                    
                    // [Minerva's PPJA] Crafting Bundle
                    
                    case "Beeswax": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_Honey, machineName: "Extruder");
                    
                    case "Thread": // Artisan Valley
                        return strPutItemInMachine(itemName: "Cotton Boll", machineID: ItemID.BC_Loom);
                    
                    case "Twine": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_Hay, ItemID.BC_Loom);
                    
                    /********** [Minerva's Harder CC (PPJA)] Boiler Room **********/
                    
                    // [Minerva's PPJA] Adventurer's Bundle
                    
                    case "Prismatic Popsicle": // Even More Recipes
                        return strCookRecipe("Prismatic Popsicle");
                    
                    case "Berry Fusion Tea": // More Recipes
                        return strCookRecipe("Berry Fusion Tea");
                    
                    case "Black Tea": // More Recipes
                        return strCookRecipe("Black Tea");
                    
                    case "Cranberry Pomegranate Tea": // More Recipes
                        return strCookRecipe("Cranberry Pomegranate Tea");
                    
                    case "Southern Sweet Tea": // More Recipes
                        return strCookRecipe("Southern Sweet Tea");
                    
                    case "Surimi": // Even More Recipes
                        return strCookRecipe("Surimi");
                    
                    case "PB&J Sandwich": // More Recipes
                        return strCookRecipe("PB&J Sandwich");
                    
                    /********** [Minerva's Harder CC (PPJA)] The Missing Bundle **********/
                    
                    case "Cactus Flower": // Fruits and Veggies
                        return strSeasonalCrop(seasonList: new string[] { "spring", "summer", "fall" }, quality: quality,
                                               shopKey: "shopOasis", startingYear: 3);
                    
                    case "Grilled Zucchini": // Even More Recipes
                        return strCookRecipe("Grilled Zucchini");
                    
                    case "Habanero Extract": // Artisan Valley
                        return strPutItemInMachine(itemName: "Habanero", machineName: "Pepper Blender");
                    
                    case "Chocolate Mouse Bread": // Even More Recipes
                        return strCookRecipe("Chocolate Mouse Bread");
                    
                    /********** [Challenging CC Bundles (PPJA)] Pantry **********/
                    
                    // [Challenging PPJA] Fall Crops Bundle
                    
                    case "Ginger": // Fruits and Veggies
                        return strSeasonalCrop("fall", quality, shopKey: isDesertKnown()? "shopOasis" : "shopUnknown");
                    
                    // [Challenging PPJA] Animal Products Bundle
                    
                    case "Butter": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_Milk, machineName: "Butter Churn");
                    
                    // [Challenging PPJA] Artisan Products Bundle
                    
                    case "Fruit Juice": // Artisan Valley
                        return strPutItemInMachine(StardewValley.Object.FruitsCategory.ToString(), machineName: "Juicer");
                    
                    case "Apple Cider": // Artisan Valley
                        return strPutItemInMachine(itemName: "Wine Yeast", machineID: ItemID.BC_Keg);
                    
                    case "Essential Oil": // Artisan Valley
                        return strPutItemInMachine(itemName: "Dried Flower", machineName: "Drying Rack");
                    
                    /********** [Challenging CC Bundles (PPJA)] Bulletin Board **********/
                    
                    // [Challenging PPJA] Chef's Bundle
                    
                    case "Poached Pear": // More Recipes
                        return strCookRecipe("Poached Pear");
                    
                    case "Avocado Eel Roll": // More Recipes
                        return strCookRecipe("Avocado Eel Roll");
                    
                    case "Rich Tiramisu": // Even More Recipes
                        return strCookRecipe("Rich Tiramisu");
                    
                    case "Mushroom and Pepper Crepe": // Even More Recipes
                        return strCookRecipe("Mushroom and Pepper Crepe");
                    
                    case "Halloumi Burger": // Even More Recipes
                        return strCookRecipe("Halloumi Burger");
                    
                    case "Sparkling Wine": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_Wine, ItemID.BC_Keg);
                    
                    case "Gin": // Artisan Valley
                        return strPutItemInMachine(itemName: "Juniper Berry", machineName: "Still");
                    
                    case "Brandy": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_Wine, machineName: "Still");
                    
                    case "Affogato": // Artisan Valley
                        return strPutItemInMachine(itemName: "Vanilla Ice Cream", machineName: "Espresso Machine");
                    
                    // [Challenging PPJA] Dye Bundle
                    
                    case "Gold Thread": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_GoldBar, ItemID.BC_Loom);
                    
                    case "Yarn": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_Fiber, ItemID.BC_Loom);
                    
                    case "Berry Fusion Kombucha": // Artisan Valley
                        return strPutItemInMachine(itemName: "Berry Fusion Tea", machineName: "Glass Jar");
                    
                    case "Dried Flower": // Artisan Valley
                        return strPutItemInMachine(StardewValley.Object.flowersCategory.ToString(), machineName: "Drying Rack");
                    
                    case "Herbal Lavender": // Mizu's Flowers
                        return strSeasonalCrop("summer", quality);
                    
                    // [Challenging PPJA] Field Research Bundle
                    
                    case "Handmade Soap": // Artisan Valley
                        return strPutItemInMachine(StardewValley.Object.flowersCategory.ToString(), machineName: "Soap Press") + "\n"
                             + strPutItemInMachine(itemLiteral: str.Get("itemCategoryNut"), machineName: "Soap Press");
                    
                    case "Aloe": // Fruits and Veggies
                        return strSeasonalCrop("summer", quality, "shopClinic", startingYear: 2);
                    
                    case "Ground Vegetable": // Artisan Valley
                        return strPutItemInMachine(StardewValley.Object.VegetableCategory.ToString(), machineName: "Grinder");
                    
                    case "Breakfast Tea": // More Recipes
                        return strCookRecipe("Breakfast Tea");
                    
                    // [Challenging PPJA] Fodder Bundle
                    
                    case "Soybean": // Fruits and Veggies
                        return strSeasonalCrop("fall", quality, startingYear: 2);
                    
                    case "Cabbage": // Fruits and Veggies
                        return strSeasonalCrop(seasonList: new string[] { "spring", "fall" }, quality: quality);
                    
                    case "Carrot": // Fruits and Veggies
                        return strSeasonalCrop("fall", quality);
                    
                    case "Apple Rind": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_Apple, machineName: "Grinder");
                    
                    case "Granny Smith Apple": // PPJA More Trees
                        return strFruitTreeDuringSeason("treeGranny", "fall");
                    
                    // [Challenging PPJA] Enchanter's Bundle
                    
                    case "Candle": // Artisan Valley
                        return strPutItemInMachine(StardewValley.Object.flowersCategory.ToString(), machineName: "Wax Barrel");
                    
                    case "Sun Tea": // More Recipes
                        return strCookRecipe("Sun Tea");
                    
                    case "Moonshine": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_Corn, machineName: "Still");
                    
                    /********** [Challenging CC Bundles (PPJA)] The Missing Bundle **********/
                    
                    case "Prismatic Ice Cream": // Artisan Valley
                        return strPutItemInMachine(ItemID.IT_PrismaticShard, machineName: "Ice Cream Machine");
                    
                    case "Jalapeno Extract": // Artisan Valley
                        return strPutItemInMachine(itemName: "Jalapeno", machineName: "Pepper Blender");
                    
                    case "Popcorn": // Even More Recipes
                        return strCookRecipe("Popcorn");
                    
                    case "Wasabi Peas": // Even More Recipes
                        return strCookRecipe("Wasabi Peas");
                    
                    case "Seaweed Chips": // Even More Recipes
                        return strCookRecipe("Seaweed Chips");
                    
                    case "Hot Irish Coffee": // Artisan Valley
                        return strPutItemInMachine(itemName: "Whiskey", machineName: "Espresso Machine");
                    
                    case "Dark Ale": // Artisan Valley
                        return strPutItemInMachine(itemName: "Durum", machineID: ItemID.BC_Keg);
                    
                    case "Strawberry Lemonade": // Even More Recipes
                        return strCookRecipe("Strawberry Lemonade");
                    
                    case "Ice Cream Brownie": // Even More Recipes
                        return strCookRecipe("Ice Cream Brownie");
                }
                
                return ModEntry.debugShowUnknownIDs? "??? (ID: " + id + ")" : "";
            }
            catch (Exception e)
            {
                ModEntry.Log("Error in getHintText: " + e.Message + Environment.NewLine + e.StackTrace);
                return "";
            }
        }
        
        /// <summary>Returns short hint text for some items, for use in another item's suggestion.</summary>
        /// <param name="id">The item ID.</param>
        public static string getShortHint(string id)
        {
            try
            {
                switch (id)
                {
                    case ItemID.IT_Hops:
                        return str.Get("shortHintSeasonalCrop", new { season = str.Get("summer") });
                    
                    case ItemID.IT_Wheat:
                    case ItemID.IT_Corn:
                    case ItemID.IT_Sunflower:
                        return str.Get("shortHintSeasonalCrop", new { season = multiSeason("summer", "fall") });
                    
                    case ItemID.IT_SunflowerSeeds:
                        return str.Get("shortHintSeasonalSeed", new { season = multiSeason("summer", "fall") });
                    
                    case ItemID.IT_SoggyNewspaper:
                    case ItemID.IT_BrokenCD:
                    case ItemID.IT_BrokenGlasses:
                        return str.Get("shortHintTrash");
                    
                    case ItemID.IT_Roe:
                        return str.Get("shortHintFishPond");
                    
                    case ItemID.IT_Fiber:
                        return str.Get("shortHintFiber");
                    
                    case ItemID.IT_Hay:
                        return str.Get("shortHintHay", new { wheat = getItemName(ItemID.IT_Wheat) });
                    
                    case ItemID.IT_Wine:
                        return str.Get("shortHintMachine", new { item = getItemName(StardewValley.Object.FruitsCategory.ToString()),
                                                                 machine = getBigCraftableName(ItemID.BC_Keg) });
                    
                    case ItemID.IT_Egg:
                        return str.Get("animalChicken");
                    
                    case ItemID.IT_DuckEgg:
                        return str.Get("animalDuck");
                    
                    case ItemID.IT_VoidEgg:
                        return str.Get("animalVoidChicken");
                    
                    case ItemID.IT_Milk:
                        return str.Get("animalCow");
                    
                    case ItemID.IT_GoatMilk:
                        return str.Get("animalGoat");
                    
                    case ItemID.IT_Truffle:
                        return str.Get("animalPig");
                    
                    case ItemID.IT_Wool:
                        return multiKey("animalSheep", "animalRabbit");
                    
                    case ItemID.IT_Bouquet:
                        return str.Get("shopPierre");
                    
                    case ItemID.IT_CoffeeBean:
                        return str.Get("shopTravelingCartRandom");
                    
                    case ItemID.IT_TeaLeaves:
                        return str.Get("recipeSourceHeartEvent", new { person = getPersonName("Caroline"), hearts = 2 });
                    
                    case ItemID.IT_Honey:
                        return getBigCraftableName(ItemID.BC_BeeHouse);
                    
                    case ItemID.IT_Quartz:
                    case ItemID.IT_FireQuartz:
                    case ItemID.IT_Amethyst:
                    case ItemID.IT_Ruby:
                    case ItemID.IT_Emerald:
                    case ItemID.IT_Diamond:
                        return str.Get("locationMines");
                }
                
                // If ID was not covered in the above switch statement (usually because it's a mod-added item), search by name.
                
                string itemByName = "";
                string machineByName = "";
                
                switch (getItemName(id, true))
                {
                    case "Cotton Boll":
                        return str.Get("shortHintSeasonalCrop", new { season = multiSeason(new string[] { "summer", "fall" }) });
                    
                    case "Jalapeno":
                    case "Durum":
                        return str.Get("shortHintSeasonalCrop", new { season = str.Get("fall") });
                    
                    case "Habanero":
                        return str.Get("shortHintSeasonalCropStartingYear", new { season = str.Get("fall"), year = 3 });
                    
                    case "Juniper Berry":
                        return str.Get("shortHintSeasonalCrop", new { season = str.Get("winter") });
                    
                    case "Wine Yeast":
                        return str.Get("shopPierre");
                    
                    case "Berry Fusion Tea":
                        return str.Get("shopSaloon");
                    
                    case "Dried Flower":
                        if (findBigCraftableIDByName("Drying Rack", out machineByName))
                            return getBigCraftableName(machineByName);
                        else
                            return "";
                    
                    case "Vanilla Ice Cream":
                        if (findBigCraftableIDByName("Ice Cream Machine", out machineByName))
                            return getBigCraftableName(machineByName);
                        else
                            return "";
                    
                    case "Whiskey":
                        if (findItemIDByName("Wheat Malt", out itemByName)
                         && findBigCraftableIDByName("Still", out machineByName))
                            return str.Get("shortHintMachine", new { item = getItemName(itemByName),
                                                                     machine = getBigCraftableName(machineByName) });
                        else
                            return "";
                }
                
                return "";
            }
            catch (Exception e)
            {
                ModEntry.Log("Error in getShortHint: " + e.Message + Environment.NewLine + e.StackTrace);
                return "";
            }
        }
        
        /*******************************
         ** Suggestion String Methods **
         *******************************/
        
        /// <summary>Suggestion for a crop grown during particular season(s).</summary>
        /// <param name="seasonKey">String key for season name (spring/summer/fall/winter).</param>
        /// <param name="quality">The quality required. Fertilizer is recommended for quality crops.</param>
        /// <param name="shopKey">String key for shop that sells the seeds (shopX). Defaults to Pierre's/JojaMart.</param>
        /// <param name="startingYear">What year the crop becomes available.</param>
        /// <param name="seasonList">Override for array of multiple season keys.</param>
        private static string strSeasonalCrop(string seasonKey = "", int quality = 0, string shopKey = "",
                                              int startingYear = 0, string[] seasonList = null)
        {
            string yearStr = getStartingYearString(startingYear);
            string qualityCrop = quality > 0? str.Get("qualityCrop") : "";
            
            return str.Get("seasonalCrop", new { seedShop = shopKey != ""? str.Get(shopKey) : getSeedShopsString(),
                                                 season = seasonList != null? multiSeason(seasonList) : str.Get(seasonKey),
                                                 startingYear = yearStr, qualityCrop = qualityCrop });
        }
        
        /// <summary>Suggestion for a crop grown from particular seeds, no specification of season.</summary>
        /// <param name="itemID">Item ID of the seeds.</param>
        /// <param name="seedTip">Tip for how to get seeds.</param>
        /// <param name="quality">The quality required.</param>
        private static string strGrowSeeds(string itemID, string seedTip, int quality)
        {
            string qualityCrop = quality > 0? str.Get("qualityCrop") : "";
            
            return str.Get("growSeeds", new { seeds = getItemName(itemID) + seedTip, qualityCrop = qualityCrop });
        }
        
        /// <summary>Suggestion for an item forageable during particular season(s).</summary>
        /// <param name="seasonKey">String key for season name (spring/summer/fall/winter).</param>
        /// <param name="seasonList">Override for array of multiple season keys.</param>
        private static string strSeasonalForage(string seasonKey = "", string[] seasonList = null)
        {
            return str.Get("seasonalForage", new { season = seasonList != null? multiSeason(seasonList) : str.Get(seasonKey) });
        }
        
        /// <summary>Suggestion of an item forageable in particular location.</summary>
        /// <param name="locationKey">String key for location name (locationX).</param>
        /// <param name="locationLiteral">Override for preformatted text.</param>
        private static string strLocationalForage(string locationKey = "", string locationLiteral = "")
        {
            return str.Get("locationalForage", new { location = locationLiteral != ""? locationLiteral : str.Get(locationKey) });
        }
        
        /// <summary>Suggestion of an item forageable in particular location during particular season(s).</summary>
        /// <param name="seasonKey">String key for season name (spring/summer/fall/winter).</param>
        /// <param name="locationKey">String key for location name (locationX).</param>
        /// <param name="seasonList">Override for array of multiple season keys.</param>
        /// <param name="locationLiteral">Override for preformatted text.</param>
        private static string strSeasonalLocationalForage(string seasonKey = "", string locationKey = "",
                                                          string[] seasonList = null, string locationLiteral = "")
        {
            return str.Get("seasonalLocationalForage", new { season = seasonList != null? multiSeason(seasonList) : str.Get(seasonKey),
                                                             location = locationLiteral != ""? locationLiteral : str.Get(locationKey) });
        }
        
        /// <summary>Suggestion of an item forageable from bushes during a range of days in a season.</summary>
        /// <param name="seasonKey">String key for season name (spring/summer/fall/winter).</param>
        /// <param name="startDay">The start of the day range.</param>
        /// <param name="endDay">The end of the day range.</param>
        /// <param name="seasonList">Override for array of multiple season keys.</param>
        private static string strBushForageDayRange(string seasonKey = "", int startDay = 1, int endDay = 28, string[] seasonList = null)
        {
            return str.Get("bushForageDayRange", new { season = seasonList != null? multiSeason(seasonList) : str.Get(seasonKey),
                                                       startDay = startDay, endDay = endDay });
        }
        
        /// <summary>Suggestion of an item forageable from bushes in particular location during a range of days in a season.</summary>
        /// <param name="seasonKey">String key for season name (spring/summer/fall/winter).</param>
        /// <param name="startDay">The start of the day range.</param>
        /// <param name="endDay">The end of the day range.</param>
        /// <param name="locationKey">String key for location name (locationX).</param>
        /// <param name="seasonList">Override for array of multiple season keys.</param>
        /// <param name="locationLiteral">Override for preformatted text.</param>
        private static string strLocationalBushForage(string seasonKey = "", int startDay = 1, int endDay = 28, string locationKey = "", string[] seasonList = null, string locationLiteral = "")
        {
            return str.Get("locationalBushForageDayRange", new { season = seasonList != null? multiSeason(seasonList) : str.Get(seasonKey),
                                                                 startDay = startDay, endDay = endDay,
                                                                 location = locationLiteral != ""? locationLiteral : str.Get(locationKey) });
        }
        
        /// <summary>Suggestion for a diggable item during particular season(s).</summary>
        /// <param name="seasonKey">String key for season name (spring/summer/fall/winter).</param>
        /// <param name="seasonList">Override for array of multiple season keys.</param>
        private static string strSeasonalTilling(string seasonKey = "", string[] seasonList = null)
        {
            return str.Get("seasonalTilling", new { season = seasonList != null? multiSeason(seasonList) : str.Get(seasonKey) });
        }
        
        /// <summary>Suggestion for a diggable item in particular location.</summary>
        /// <param name="locationKey">String key for location name (locationX).</param>
        /// <param name="locationLiteral">Override for preformatted text.</param>
        private static string strLocationalTilling(string locationKey = "", string locationLiteral = "")
        {
            return str.Get("locationalTilling", new { location = locationLiteral != ""? locationLiteral : str.Get(locationKey) });
        }
        
        /// <summary>Suggestion for a diggable artifact in particular location.</summary>
        /// <param name="locationKey">String key for location name (locationX).</param>
        /// <param name="locationList">Override for array of multiple location keys.</param>
        private static string strLocationalArtifact(string locationKey = "", string[] locationList = null)
        {
            return str.Get("locationalArtifact", new { location = locationList != null? multiKey(locationList) : str.Get(locationKey) });
        }
        
        /// <summary>Suggestion to hit rocks with pickaxe.</summary>
        /// <param name="locationKey">String key for specific location.</param>
        private static string strHitRocks(string locationKey = "")
        {
            if (locationKey != "")
                return str.Get("hitRocksInLocation", new { location = str.Get(locationKey) });
            else // Load "Pickaxe" tool name from strings
                return str.Get("hitRocks", new { pickaxe = TokenParser.ParseText(DataLoader.Tools(Game1.content)["Pickaxe"].DisplayName) });
        }
        
        /// <summary>Suggestion for where and when to catch fish.</summary>
        /// <param name="waterKey">String key for water location (waterX).</param>
        /// <param name="start">Start of catchable time range (i.e. "6am", "12pm").</param>
        /// <param name="end">End of catchable time range (i.e. "6am", "12pm").</param>
        /// <param name="seasonKey">String key for season name (spring/summer/fall/winter).</param>
        /// <param name="weatherKey">String key for specific weather (weatherSun, weatherRain).)</param>
        /// <param name="waterList">Override for array of multiple water keys.</param>
        /// <param name="seasonList">Override for array of multiple season keys.</param>
        /// <param name="start2">Start of second catchable time range (i.e. "6am", "12pm").</param>
        /// <param name="end2">End of second catchable time range (i.e. "6am", "12pm").</param>
        /// <param name="fishingLevel",>The minimum Fishing level required.</param>
        /// <param name="extraLinebreak">Whether to include an extra linebreak in the middle for long lines.</param>
        private static string strFishBase(string waterKey = "", string start = "", string end = "",
                                          string seasonKey = "allSeasons", string weatherKey = "",
                                          string[] waterList = null, string[] seasonList = null,
                                          string start2 = "", string end2 = "", int fishingLevel = 0, bool extraLinebreak = false)
        {
            string timeStr;
            if (start != "" && end != "")
            {
                timeStr = getTimeRange(start, end);
                if (start2 != "" && end2 != "")
                    timeStr += str.Get("multipleThingSeparator") + getTimeRange(start2, end2);
            }
            else
                timeStr = str.Get("anyTime");
            
            string water = waterList != null? multiKey(waterList) : str.Get(waterKey);
            string season = seasonList != null? multiSeason(seasonList) : str.Get(seasonKey);
            string weather = weatherKey != ""? str.Get(weatherKey) : "";
            
            return str.Get("fishBase", new { water = water,
                                             extraLinebreak = extraLinebreak? "\n" : "",
                                             time = timeStr,
                                             weather = weather,
                                             season = season })
                 + (fishingLevel > 0? levelRequirementString("fishing", fishingLevel) : "");
        }
        
        /// <summary>Suggestion for items randomly obtainable from fishing chests.</summary>
        /// <param name="level">The minimum Fishing level at which the item will start appearing.</param>
        private static string strFishingChest(int level = 0)
        {
            string levelStr = "";
            if (level != 0 && Game1.player.FishingLevel < level)
                levelStr = levelRequirementString("fishing", level);
            
            return str.Get("fishingChest") + levelStr;
        }
        
        /// <summary>Suggestion for items catchable in a Crab Pot.</summary>
        /// <param name="waterTypeKey">String key for type of water (waterTypeX).</param>
        private static string strCrabPot(string waterTypeKey)
        {
            return str.Get("crabPot", new { crabPot = getItemName(ItemID.IT_CrabPot), waterType = str.Get(waterTypeKey) });
        }
        
        /// <summary>Suggestion for an item produced by an animal. Includes building requirement for said animal.</summary>
        /// <param name="animalKey">String key for animal name (animalX).</param>
        /// <param name="mustBeHappy">Whether the animal has to be sufficiently happy to produce the item.</param>
        /// <param name="mustBeOutside">Whether the animal has to be outside to produce the item.</param>
        private static string strAnimalProduct(string animalKey, bool mustBeHappy = false, bool mustBeOutside = false)
        {
            int coopReq = -1, barnReq = -1;
            switch (animalKey)
            {
                case "animalChicken": coopReq = 0; break;
                case "animalVoidChicken": coopReq = 1; break;
                case "animalDuck": coopReq = 1; break;
                case "animalRabbit": coopReq = 2; break;
                case "animalCow": barnReq = 0; break;
                case "animalOstrich": barnReq = 0; break;
                case "animalGoat": barnReq = 1; break;
                case "animalSheep": barnReq = 2; break;
                case "animalPig": barnReq = 2; break;
            }
            
            int coopLevel = getCoopLevel();
            int barnLevel = getBarnLevel();
            
            string animalUnlockTip = "";
            if (coopLevel < coopReq)
                animalUnlockTip = parenthesize(str.Get("animalReqCoopLv" + (coopReq + 1)));
            else if (barnLevel < barnReq)
                animalUnlockTip = parenthesize(str.Get("animalReqBarnLv" + (barnReq + 1)));
            
            string details = "";
            if (animalUnlockTip == "") // Details not really necessary if animal is not even obtainable yet
                details = mustBeHappy? str.Get("inGoodMood") : mustBeOutside? str.Get("animalOutside") : "";
            
            return str.Get("animalProduct", new { animal = str.Get(animalKey) + animalUnlockTip, details = details });
        }
        
        /// <summary>Suggestion for an item produced by putting an item in a machine.
        /// Includes requirement for said machine's recipe.</summary>
        /// <param name="itemID">Item ID of the item to put in.</param>
        /// <param name="machineID">Big Craftable ID of the machine.</param>
        /// <param name="itemLiteral">Override for preformatted text.</param>
        /// <param name="itemQuantity">Required quantity of input item.</param>
        /// <param name="itemName">String referencr for mod-added items.</param>
        /// <param name="machineName">String reference for mod-added machines.</param>
        private static string strPutItemInMachine(string itemID = "", string machineID = "",
                                                  string itemLiteral = "", int itemQuantity = 1,
                                                  string itemName = "", string machineName = "")
        {
            if (itemName != "")
            {
                if (!findItemIDByName(itemName, out itemID))
                    return "";
            }
            
            if (machineName != "")
            {
                if (!findBigCraftableIDByName(machineName, out machineID))
                    return "";
            }
            else
            {
                machineName = getBigCraftableName(machineID, true);
                if (machineName == "")
                    return str.Get("unknownSource");
            }
            
            string machineRecipeName = machineName;
            switch (machineName) // Convert modded machine names that don't match the internal names of their recipes
            {
                case ItemID.ALC_BC_EssenceRestabilizer:
                case ItemID.ALC_BC_ManaExtractor:
                case ItemID.ALC_BC_MortarPestle:
                case ItemID.ALC_BC_TinctureBin:
                case ItemID.ALC_BC_TransmuterCoil:
                    machineRecipeName += "_Recipe";
                    break;
            }
            
            bool canMakeMachine = Game1.MasterPlayer.craftingRecipes.ContainsKey(machineRecipeName);
            switch (machineName) // Ensure some modded default recipes are treated as makeable
            {
                case ItemID.ALC_BC_MortarPestle:
                    canMakeMachine = true;
                    break;
            }
            
            string itemTip = getShortHint(itemID);
            if (itemTip != "")
                itemTip = parenthesize(itemTip);
            
            string machineUnlockTip = "";
            if (!canMakeMachine)
            {
                machineUnlockTip = getCraftingRecipeSources(machineRecipeName);
                if (machineUnlockTip != "")
                    machineUnlockTip = parenthesize(machineUnlockTip);
            }
            
            string itemStr = itemLiteral != ""? itemLiteral : getItemName(itemID);
            
            if (itemQuantity > 1)
                itemStr = str.Get("machineItemQuantity", new { item = itemStr, num = itemQuantity });
            
            return str.Get("putItemInMachine", new { rawItem = itemStr + itemTip,
                                                     machine = getBigCraftableName(machineID) + machineUnlockTip });
        }
        
        /// <summary>Suggestion for putting raw item in Keg for base quality, or result item in Cask for higher quality.</summary>
        /// <param name="rawItemID">Item ID of the raw material to put in the base machine.</param>
        /// <param name="machineID">Big Craftable ID of the base machine.</param>
        /// <param name="resultItemID">Item ID of the result you get from the base machine.</param>
        /// <param name="quality">The quality required for the bundle.</param>
        private static string strMachineOrCaskForQuality(string rawItemID, string machineID, string resultItemID, int quality)
        {
            if (quality == 0) // Base quality, so put raw item in "base" machine
                return strPutItemInMachine(rawItemID, machineID);
            else // Higher quality requires putting raw item in base machine, then result in Cask
            {
                string machineName = getBigCraftableName(machineID, true);
                bool canMakeMachine = Game1.MasterPlayer.craftingRecipes.ContainsKey(machineName);
                
                string machineUnlockTip = "";
                if (!canMakeMachine)
                {
                    machineUnlockTip = getCraftingRecipeSources(machineName);
                    if (machineUnlockTip != "")
                        machineUnlockTip = parenthesize(machineUnlockTip);
                }
                
                string caskName = getBigCraftableName(ItemID.BC_Cask, true);
                bool canMakeCask = Game1.MasterPlayer.craftingRecipes.ContainsKey(caskName);
                
                string caskUnlockTip = "";
                if (!canMakeCask)
                {
                    caskUnlockTip = getCraftingRecipeSources(caskName);
                    if (caskUnlockTip != "")
                        caskUnlockTip = parenthesize(caskUnlockTip);
                }
                
                return str.Get("putItemInMachineThenCask", new { rawItem = getItemName(rawItemID),
                                                                 machine = getBigCraftableName(machineID) + machineUnlockTip,
                                                                 resultItem = getItemName(resultItemID),
                                                                 cask = getBigCraftableName(ItemID.BC_Cask) + caskUnlockTip});
            }
        }
        
        /// <summary>Suggestion for an item produced by a machine on its own.
        /// Includes requirement for said machine's recipe.</summary>
        /// <param name="machineID">Big Craftable ID of the machine.</param>
        private static string strNoItemMachine(string machineID)
        {
            string machineUnlockTip = "";
            
            // Statue of Perfection isn't crafted, only obtained, so it's a special case.
            if (machineID == ItemID.BC_StatueOfPerfection
             && !Utility.doesItemExistAnywhere("(BC)" + ItemID.BC_StatueOfPerfection))
            {
                try
                {
                    if (Game1.getFarm().grandpaScore.Value < 4) // Haven't had evaluation, or didn't get four candles
                        machineUnlockTip = parenthesize(str.Get("statueOfPerfectionTip"));
                    else // Got four candles, so it's waiting to be collected at shrine
                        machineUnlockTip = parenthesize(str.Get("statueOfPerfectionAvailable"));
                }
                catch // Error in getFarm
                {
                    machineUnlockTip = parenthesize(str.Get("statueOfPerfectionTip"));
                }
            }
            else
            {
                string machineName = getBigCraftableName(machineID, true);
                bool canMakeMachine = Game1.MasterPlayer.craftingRecipes.ContainsKey(machineName);
                
                if (!canMakeMachine && machineID != ItemID.BC_StatueOfPerfection)
                {
                    machineUnlockTip = getCraftingRecipeSources(machineName);
                    if (machineUnlockTip != "")
                        machineUnlockTip = parenthesize(machineUnlockTip);
                }
            }
            
            return str.Get("noItemMachine", new { machine = getBigCraftableName(machineID) + machineUnlockTip });
        }
        
        /// <summary>Suggestion for getting item from a fish pond with a minimum population of a certain fish.</summary>
        /// <param name="fishItemID">Item ID of the fish.</param>
        /// <param name="numRequired">Minimum number of fish required in the pond for item to spawn.</param>
        /// <param name="fishItemName">String reference for mod-added fish.</param>
        private static string strFishPond(string fishItemID = "", int numRequired = 1, string fishItemName = "")
        {
            if (fishItemName != "")
            {
                if (!findItemIDByName(fishItemName, out fishItemID))
                    return "";
            }
            
            return str.Get("fishPond", new { fish = getItemName(fishItemID), num = numRequired });
        }
        
        /// <summary>Suggestion for an item dropped by a monster. Includes location of said monster.</summary>
        /// <param name="monsterName">Internal string name of the monster.</param>
        /// <param name="monsterKey">String key for general monster category or specific monster color (monsterX).</param>
        private static string strDroppedByMonster(string monsterName = "", string monsterKey = "")
        {
            string monsterStr = monsterKey != ""? str.Get(monsterKey) : getMonsterName(monsterName);
            
            // Set location and requirements based on monster name or type.
            string locationKey = "";
            int startFloor = -1, endFloor = -1;
            int mineLevelReq = -1;
            bool skullReq = false, volcanoReq = false;
            
            if (monsterKey != "")
            {
                switch(monsterKey)
                {
                    case "monsterGeneralSlime":
                    case "monsterBRPCISlime":
                        locationKey = "monsterAreaMinesAndSkull"; break;
                    case "monsterGeneralBat":
                    case "monsterGeneralAnyInMines":
                    case "monsterHauntedSkull":
                        locationKey = "monsterAreaMinesAll"; break;
                    case "monsterPurpleSlime":
                        locationKey = "monsterAreaSkull"; skullReq = true; break;
                }
            }
            else
            {
                switch (monsterName)
                {
                    case "Green Slime":
                        locationKey = "monsterAreaMinesAndSkull";
                        break;
                    case "Bug":
                    case "Fly":
                    case "Rock Crab":
                    case "Blue Squid":
                        startFloor = 1;
                        endFloor = 29;
                        locationKey = "monsterAreaMinesRange";
                        break;
                    case "Duggy":
                        mineLevelReq = 5;
                        startFloor = 6;
                        endFloor = 29;
                        locationKey = "monsterAreaMinesRange";
                        break;
                    case "Grub":
                        mineLevelReq = 10;
                        startFloor = 11;
                        endFloor = 29;
                        locationKey = "monsterAreaMinesRange";
                        break;
                    case "Bat":
                    case "Stone Golem":
                        mineLevelReq = 30;
                        startFloor = 31;
                        endFloor = 39;
                        locationKey = "monsterAreaMinesRange";
                        break;
                    case "Dust Spirit":
                    case "Frost Bat":
                    case "Frost Jelly":
                        mineLevelReq = 40;
                        startFloor = 41;
                        endFloor = 79;
                        locationKey = "monsterAreaMinesRange";
                        break;
                    case "Ghost":
                    case "Putrid Ghost":
                        mineLevelReq = 50;
                        startFloor = 51;
                        endFloor = 79;
                        locationKey = "monsterAreaMinesRange";
                        break;
                    case "Skeleton":
                        mineLevelReq = 70;
                        startFloor = 71;
                        endFloor = 79;
                        locationKey = "monsterAreaMinesRange";
                        break;
                    case "Lava Bat":
                    case "Lava Crab":
                    case "Metal Head":
                    case "Sludge": // Red
                    case "Shadow Brute":
                    case "Shadow Shaman":
                    case "Shadow Sniper":
                    case "Squid Kid":
                        mineLevelReq = 80;
                        startFloor = 81;
                        endFloor = 119;
                        locationKey = "monsterAreaMinesRange";
                        break;
                    case "Mummy":
                    case "Serpent":
                    case "Royal Serpent":
                        skullReq = true;
                        locationKey = "monsterAreaSkull";
                        break;
                    case "Iridium Crab":
                        skullReq = true;
                        startFloor = 26;
                        locationKey = "monsterAreaSkullFloorPlus";
                        break;
                    case "Iridium Bat":
                        skullReq = true;
                        startFloor = 50;
                        locationKey = "monsterAreaSkullFloorPlus";
                        break;
                    case "Pepper Rex":
                        skullReq = true;
                        locationKey = "monsterAreaSkullPrehistoric";
                        break;
                    case "Carbon Ghost":
                        skullReq = true;
                        locationKey = "monsterAreaSkullMummy";
                        break;
                    case "Tiger Slime":
                    case "Lava Lurk":
                    case "Hot Head":
                    case "Spider":
                    case "Magma Duggy":
                    case "Magma Sprite":
                    case "Magma Sparker":
                    case "Dwarvish Sentry":
                    case "False Magma Cap":
                        volcanoReq = true;
                        locationKey = "monsterAreaVolcano";
                        break;
                }
            }
            
            // Convert "Mines and Skull Cavern" to just "Mines" if you shouldn't know about the latter.
            if (locationKey.Equals("monsterAreaMinesAndSkull") && !isSkullCavernKnown())
                locationKey = "monsterAreaMinesAll";
            
            if (!Config.ShowSpoilers)
            {
                if ((skullReq && !isSkullCavernKnown()) // Skull Cavern only, but not yet unlocked
                 || (volcanoReq && !isVolcanoKnown()) // Volcano, but not yet unlocked
                 || (mineLevelReq > MineShaft.lowestLevelReached)) // Mines, but haven't gotten deep enough
                    monsterStr = str.Get("monsterUnknown"); // Conceal monster name
                
                if ((skullReq && !isSkullCavernKnown()) // Skull Cavern only, but not yet unlocked
                 || (volcanoReq && !isVolcanoKnown())) // Volcano, but not yet unlocked
                    locationKey = "monsterAreaUnknown"; // Conceal area name
            }
            
            if (locationKey != "") // Always append location, even if its name is hidden
                monsterStr += parenthesize(str.Get(locationKey, new { start = startFloor != -1? startFloor.ToString() : "",
                                                                      end = endFloor != -1? endFloor.ToString() : "" }));
            
            return str.Get("droppedByMonster", new { monster = monsterStr });
        }
        
        /// <summary>Suggestion for an item that grows on a fruit tree during a particular season.</summary>
        /// <param name="treeKey">String key for tree name (treeX).</param>
        /// <param name="seasonKey">String key for season name (spring/summer/fall/winter).</param>
        /// <param name="shopKey">String key for the shop that sells the saplings (shopX). Defaults to Pierre's.</param>
        /// <param name="startingYear">What year the seedlings become available.</param>
        private static string strFruitTreeDuringSeason(string treeKey, string seasonKey,
                                                       string shopKey = "shopPierre", int startingYear = 0)
        {
            string yearStr = getStartingYearString(startingYear);
            string seedlingStr = parenthesize(str.Get("treeDescSeedling", new { shop = str.Get(shopKey), startingYear = yearStr }));
            
            return str.Get("treeDuringSeason", new { tree = str.Get(treeKey) + seedlingStr, season = str.Get(seasonKey) });
        }
        
        /// <summary>Suggestion for an item obtainable by tapping a particular tree. Includes seed used to grow said tree.</summary>
        /// <param name="treeKey">String key for tree name (treeX).</param>
        private static string strTapTree(string treeKey)
        {
            string treeSeed = "";
            switch (treeKey)
            {
                case "treeMaple": treeSeed = getItemName(ItemID.IT_MapleSeed); break;
                case "treeOak": treeSeed = getItemName(ItemID.IT_Acorn); break;
                case "treePine": treeSeed = getItemName(ItemID.IT_PineCone); break;
            }
            
            string tapperUnlockTip = "";
            if (Game1.player.ForagingLevel < 3)
                tapperUnlockTip = levelRequirementString("foraging", 3);
            
            string tapperStr = getBigCraftableName(ItemID.BC_Tapper) + tapperUnlockTip;
            string treeStr = treeKey == "treeMystic"? str.Get(treeKey, new { craftingInfo = strCraftRecipe("Mystic Tree Seed") })
                           : treeSeed != ""? str.Get(treeKey) + parenthesize(str.Get("treeDescNonFruit", new { treeSeed = treeSeed }))
                                           : str.Get(treeKey);
            return str.Get("tapTree", new { tapper = tapperStr, tree = treeStr });
        }
        
        /// <summary>Suggestion for craftable item. Includes either how to get recipe, or materials.</summary>
        /// <param name="recipeName">Internal string name of the recipe.</param>
        private static string strCraftRecipe(string recipeName)
        {
            System.Collections.Generic.Dictionary<string, string> recipes = DataLoader.CraftingRecipes(Game1.content);
            if (!recipes.ContainsKey(recipeName))
                return str.Get("unknownSource");
            
            string[] recipeData = recipes[recipeName].Split('/');
            string ingredientDefinition = recipeData[0];
            
            string recipeDesc = "";
            
            if (ModEntry.debugTreatRecipesAsKnown || Game1.player.knowsRecipe(recipeName)) // Have recipe, so list ingredients
                recipeDesc = getRecipeIngredientsString(ingredientDefinition);
            else // Describe where to get recipe
            {
                string recipeSources = getCraftingRecipeSources(recipeName);
                if (recipeSources != "")
                    recipeDesc = parenthesize(str.Get("recipeFrom", new { sources = recipeSources }));
            }
            
            // For recipes where the recipe name is not the created item, include the name of the recipe.
            bool includeRecipeName = false;
            switch (recipeName)
            {
                case "Transmute (Fe)":
                case "Transmute (Au)":
                case "Wild Seeds (Sp)":
                case "Wild Seeds (Su)":
                case "Wild Seeds (Fa)":
                case "Wild Seeds (Wi)":
                    includeRecipeName = true;
                    break;
            }
            
            return (includeRecipeName? str.Get("craftRecipeByName", new { recipe = getCraftingRecipeName(recipeName) })
                                     : str.Get("craftRecipe"))
                 + recipeDesc;
        }
        
        /// <summary>Suggestion for cookable item. Includes either how to get recipe, or ingredients.</summary>
        /// <param name="recipeName">Internal string name of the recipe.</param>
        private static string strCookRecipe(string recipeName)
        {
            System.Collections.Generic.Dictionary<string, string> recipes = DataLoader.CookingRecipes(Game1.content);
            if (!recipes.ContainsKey(recipeName))
                return str.Get("unknownSource");
            
            string[] recipeData = recipes[recipeName].Split('/');
            string ingredientDefinition = recipeData[0];
            
            string recipeDesc = "";
            
            if (ModEntry.debugUnlockCooking && Game1.player.HouseUpgradeLevel <= 0)
                Game1.player.HouseUpgradeLevel = 1;
            
            if (Game1.player.HouseUpgradeLevel <= 0) // Don't have house upgrade to cook anything yet
                recipeDesc = parenthesize(str.Get("recipeTipHouseUpgrade"));
            else if (ModEntry.debugTreatRecipesAsKnown || Game1.player.knowsRecipe(recipeName)) // Have recipe, so list ingredients
                recipeDesc = getRecipeIngredientsString(ingredientDefinition);
            else // Describe where to get recipe
            {
                string recipeSources = getCookingRecipeSources(recipeName);
                if (recipeSources != "")
                    recipeDesc = parenthesize(str.Get("recipeFrom", new { sources = recipeSources }));
            }
            
            return str.Get("cookRecipe") + recipeDesc;
        }
        
        /// <summary>Suggestion for Apothecary's Cauldron brew from Alchemistry. Includes either how to get recipe, or ingredients.</summary>
        /// <param name="recipeName">Internal string name of the recipe.</param>
        private static string strAlchemistryCauldron(string recipeName)
        {
            System.Collections.Generic.Dictionary<string, string> recipes = DataLoader.CookingRecipes(Game1.content);
            if (!recipes.ContainsKey(recipeName))
                return str.Get("unknownSource");
            
            string[] recipeData = recipes[recipeName].Split('/');
            string ingredientDefinition = recipeData[0];
            
            string recipeDesc = "";
            
            if (!Game1.player.knowsRecipe("Morghoula.AlchemistryCP_ApothecaryCauldron_Recipe") && !ModEntry.debugTreatRecipesAsKnown) // Don't know how to make cauldron yet
                recipeDesc = parenthesize(str.Get("recipeFrom", new { sources = conditionalMailSource("Wizard", 2) }));
            else if (ModEntry.debugTreatRecipesAsKnown || Game1.player.knowsRecipe(recipeName)) // Have recipe, so list ingredients
                recipeDesc = getRecipeIngredientsString(ingredientDefinition);
            else // Describe where to get recipe
            {
                string recipeSources = getCookingRecipeSources(recipeName);
                if (recipeSources != "")
                    recipeDesc = parenthesize(str.Get("recipeFrom", new { sources = recipeSources }));
            }
            
            return str.Get("apothecaryCauldron") + recipeDesc;
        }
        
        /// <summary>Suggestion for items randomly obtainable from geodes.</summary>
        /// <param name="geodeIDs">List of item IDs for geode types.</param>
        private static string strOpenGeode(params string[] geodeIDs)
        {
            return str.Get("openGeode", new { geode = multiItem(geodeIDs) });
        }
        
        /// <summary>Suggestion for panning, described relative to spoiler policy and glittering boulder being removed.</summary>
        private static string strPanning()
        {
            return Config.ShowSpoilers || Game1.MasterPlayer.mailReceived.Contains("ccFishTank")? str.Get("panning")
                                                                                                : str.Get("unknownSource");
        }
        
        /// <summary>Suggestion to buy from a shop.</summary>
        /// <param name="shopKey">String key for shop (shopX).</param>
        /// <param name="shopLiteral">Override for preformatted text (usually used with multiKey).</param>
        private static string strBuyFrom(string shopKey = "", string shopLiteral = "")
        {
            return str.Get("buyFrom", new { shop = shopLiteral != ""? shopLiteral : str.Get(shopKey) });
        }

        /// <summary>Suggestion to buy from a shop that only randomly has the item available.</summary>
        /// <param name="shopKey">String key for shop (shopX).</param>
        /// <param name="shopLiteral">Override for preformatted text (usually used with multiKey).</param>
        private static string strBuyFromRandom(string shopKey = "", string shopLiteral = "")
        {
            return strBuyFrom(shopKey, shopLiteral) + parenthesize(str.Get("randomlyAvailable"));
        }
        
        /// <summary>Suggestion to buy from Dwarf, or an unknown shop if not yet known.</summary>
        private static string strBuyFromDwarf()
        {
            return str.Get("buyFrom", new { shop = str.Get(isDwarfKnown()? "shopDwarf" : "shopUnknown") });
        }
        
        /// <summary>Suggestion to buy from Krobus, or an unknown shop if not yet known.</summary>
        private static string strBuyFromKrobus()
        {
            return str.Get("buyFrom", new { shop = str.Get(isSewerKnown()? "shopKrobus" : "shopUnknown")
                                                 + (!Game1.player.hasRustyKey? parenthesize(str.Get("sewerRequirement")) : "") });
        }
        
        /// <summary>Suggestion to buy from Krobus on a certain day, or an unknown shop if not yet known. Auto-appends "(random)" for Saturday's cooked dishes.</summary>
        private static string strBuyFromKrobusWeekday(string dayKey)
        {
            return str.Get("buyFrom", new { shop = (isSewerKnown()? str.Get("shopKrobusWeekday", new { day = str.Get(dayKey) })
                                                                 + (dayKey == "saturday"? parenthesize(str.Get("randomlyAvailable")) : "")
                                                                  : str.Get("shopUnknown"))
                                                 + (!Game1.player.hasRustyKey? parenthesize(str.Get("sewerRequirement")) : "") });
        }
        
        /// <summary>Suggestion to buy from Oasis on a certain day, or an unknown shop if not yet known.</summary>
        /// <param name="dayKey">Key for the day of the week (monday, tuesday, wednesday, thursday, friday, saturday, sunday)</param>
        private static string strBuyFromOasisWeekday(string dayKey)
        {
            return str.Get("buyFrom", new { shop = isDesertKnown()? str.Get("shopOasisWeekday", new { day = str.Get(dayKey) })
                                                                  : str.Get("shopUnknown") });
        }
        
        /// <summary>Suggestion to chop wood with axe.</summary>
        private static string strChopWood()
        {
            // Loads "Axe" tool name from strings
            return str.Get("chopWood", new { axe = TokenParser.ParseText(DataLoader.Tools(Game1.content)["Axe"].DisplayName) });
        }
        
        /// <summary>Suggestion to chop stumps and logs with upgraded axe for hardwood.</summary>
        private static string strChopHardwood()
        {
            string copperAxe = Game1.content.LoadString("Strings\\Tools:Axe_Copper_Name");
            string steelAxe = Game1.content.LoadString("Strings\\Tools:Axe_Steel_Name");
            return str.Get("chopHardwood", new { copperAxe = copperAxe, steelAxe = steelAxe });
        }
        
        /// <summary>Suggestion to chop trees with axe.</summary>
        private static string strChopTrees()
        {
            // Loads "Axe" tool name from strings
            return str.Get("chopTrees", new { axe = TokenParser.ParseText(DataLoader.Tools(Game1.content)["Axe"].DisplayName) });
        }
        
        /// <summary>Suggestion of fruit bat cave depending on progress, choice, and spoiler policy.
        /// Returns blank string if not applicable, so non-blank results are prefixed with a newline.</summary>
        private static string possibleSourceFruitBatCave()
        {
            switch (Game1.MasterPlayer.caveChoice.Value)
            {
                case 0: // Not yet chosen, so don't spoil, or specify which type if spoilers are okay
                    if (Config.ShowSpoilers)
                        return "\n" + str.Get("caveFruitBats");
                    else
                        return "\n" + str.Get("unknownSource");
                case 1: // Chose fruit bat cave, so simply say it can appear in your cave
                    return "\n" + str.Get("caveYours");
                case 2: // Did not choose fruit bat cave, so don't include it
                    return "";
            }
            return "";
        }
        
        /// <summary>Suggestion of mushroom cave depending on progress, choice, and spoiler policy.
        /// Returns blank string if not applicable, so non-blank results are prefixed with a newline.</summary>
        private static string possibleSourceMushroomCave()
        {
            switch (Game1.MasterPlayer.caveChoice.Value)
            {
                case 0: // Not yet chosen, so don't spoil, or specify which type if spoilers are okay
                    if (Config.ShowSpoilers)
                        return "\n" + str.Get("caveMushrooms");
                    else
                        return "\n" + str.Get("unknownSource");
                case 1: // Did not choose mushroom cave, so don't include it
                    return "";
                case 2: // Chose mushroom cave, so simply say it can appear in your cave
                    return "\n" + str.Get("caveYours");
            }
            return "";
        }
        
        /// <summary>Suggestion of foraging on farm in a particular season, if you chose a certain farm type.
        /// Returns blank string if not applicable, so non-blank results are prefixed with a newline.</summary>
        /// <param name="farmType">String for farm type (standard, riverland, forest, hilltop, wilderness, fourCorners).</param>
        /// <param name="seasonKey">String key for season name (spring/summer/fall/winter).</param>
        private static string possibleSourceSpecialFarmSeasonal(string farmType, string seasonKey)
        {
            if (haveSpecialFarmType(farmType))
                return "\n" + strSeasonalLocationalForage(seasonKey, "locationFarm");
            else
                return "";
        }
        
        /***********************
         ** Name Data Getters **
         ***********************/
        
        /// <summary>Returns item name for the current language (or internal name), or category for negative category IDs.</summary>
        /// <param name="id">The item ID or negative category ID.</param>
        /// <param name="internalName">Whether to return the internal name instead of the display name.</param>
        public static string getItemName(string id, bool internalName = false, string preservesID = null)
        {
            int intID;
            if (int.TryParse(id, out intID))
            {
                if (intID < 0) // Category
                {
                    switch (intID)
                    {
                        case StardewValley.Object.GemCategory: return str.Get("itemCategoryGem");
                        case StardewValley.Object.FishCategory: return str.Get("itemCategoryFish");
                        case StardewValley.Object.EggCategory: return str.Get("itemCategoryEgg");
                        case StardewValley.Object.MilkCategory: return str.Get("itemCategoryMilk");
                        case StardewValley.Object.mineralsCategory: return str.Get("itemCategoryMineral");
                        case StardewValley.Object.junkCategory: return str.Get("itemCategoryJunk");
                        case StardewValley.Object.SeedsCategory: return str.Get("itemCategorySeed");
                        case StardewValley.Object.VegetableCategory: return str.Get("itemCategoryVegetable");
                        case StardewValley.Object.FruitsCategory: return str.Get("itemCategoryFruit");
                        case StardewValley.Object.flowersCategory: return str.Get("itemCategoryFlower");
                        case -777: return str.Get("itemCategoryWildSeed"); // Used in Tea Sapling crafting recipe
                    }
                    return "[Category " + id + "]";
                }
            }
            
            if (Game1.objectData.ContainsKey(id) && Game1.objectData[id] != null)
            {
                if (internalName)
                    return Game1.objectData[id].Name;
                else
                {
                    // Override item name for generic Dried and Smoked items, which would otherwise just return "Dried" or "Smoked."
                    if (preservesID == null)
                    {
                        switch (id)
                        {
                            case ItemID.IT_DriedFruit:
                                return Game1.content.LoadString("Strings\\Objects:DriedFruit_CollectionsTabName");
                            case ItemID.IT_DriedMushrooms:
                                return Game1.content.LoadString("Strings\\Objects:DriedMushrooms_CollectionsTabName");
                            case ItemID.IT_SmokedFish:
                                return Game1.content.LoadString("Strings\\Objects:SmokedFish_CollectionsTabName");
                        }
                    }
                    else // Use flavored name for artisan goods if preservesID is given
                    {
                        Item flavoredItem = Utility.CreateFlavoredItem(id, preservesID);
                        return TokenParser.ParseText(flavoredItem.DisplayName);
                    }
                    return TokenParser.ParseText(Game1.objectData[id].DisplayName);
                }
            }
            
            return internalName? "" : "[Item " + id + "]";
        }
        
        /// <summary>Returns "big craftable" item name for the current language (or internal name).</summary>
        /// <param name="id">The item's Big Craftable ID.</param>
        /// <param name="internalName">Whether to return the internal name instead of the display name.</param>
        private static string getBigCraftableName(string id, bool internalName = false)
        {
            if (Game1.bigCraftableData.ContainsKey(id) && Game1.bigCraftableData[id] != null)
            {
                if (internalName)
                    return Game1.bigCraftableData[id].Name;
                else
                    return TokenParser.ParseText(Game1.bigCraftableData[id].DisplayName);
            }
            
            return internalName? "" : "[BigCraftable " + id + "]";
        }
        
        /// <summary>Returns name of person for the current language.</summary>
        /// <param name="name">The internal name of the person.</param>
        public static string getPersonName(string name)
        {
            return TokenParser.ParseText(DataLoader.Characters(Game1.content)[name].DisplayName);
        }
        
        /// <summary>Returns name of monster for the current language.</summary>
        /// <param name="name">The internal name of the monster.</param>
        private static string getMonsterName(string name)
        {
            return DataLoader.Monsters(Game1.content)[name].Split('/')[14];
        }
        
        /// <summary>Returns name of crafting recipe for the current language.</summary>
        /// <param name="name">The internal name of the recipe.</param>
        private static string getCraftingRecipeName(string name)
        {
            string[] recipeData = DataLoader.CraftingRecipes(Game1.content)[name].Split('/');
            if (recipeData.Length < 3) // Not long enough to contain item ID
                return "";
            
            bool bigCraftable = false;
            if (recipeData.Length > 3) // Long enough to contain "is big craftable" bool
                bool.TryParse(recipeData[3], out bigCraftable);
            
            return TokenParser.ParseText(recipeData[5]);
        }
        
        /// <summary>Returns display name of roe for a specific fish.</summary>
        /// <param name="id">The fish's item ID.</param>
        private static string getFishRoeName(string id)
        {
            string fish = getItemName(id); // Fish name
            string fishRoe = Game1.content.LoadString("Strings\\Objects:Roe_Flavored_Name"); // "{0} Roe" string
            return string.Format(fishRoe, fish);
        }
        
        /// <summary>Looks for item by name and returns success.</summary>
        /// <param name="name">The internal name of the item.</param>
        /// <param name="itemID">Result item ID. Empty string if not found.</param>
        public static bool findItemIDByName(string name, out string itemID)
        {
            foreach (string id in Game1.objectData.Keys)
            {
                if (Game1.objectData[id] != null && Game1.objectData[id].Name != null)
                {
                    if (Game1.objectData[id].Name.Equals(name))
                    {
                        itemID = id;
                        return true;
                    }
                }
            }
            
            itemID = "";
            return false;
        }
        
        /// <summary>Looks for item by name and returns success.</summary>
        /// <param name="name">The internal name of the item.</param>
        /// <param name="bigCraftableID">Result Big Craftable ID. Empty string if not found.</param>
        public static bool findBigCraftableIDByName(string name, out string bigCraftableID)
        {
            foreach (string id in Game1.bigCraftableData.Keys)
            {
                if (Game1.bigCraftableData[id] != null)
                {
                    if (Game1.bigCraftableData[id].Name.Equals(name))
                    {
                        bigCraftableID = id;
                        return true;
                    }
                }
            }
            
            bigCraftableID = "";
            return false;
        }
        
        /**********************************
         ** Miscellaneous String Helpers **
         **********************************/
        
        /// <summary>Returns a list of the ingredients for a recipe.</summary>
        /// <param name="ingredients">The string definition of ingredient IDs and quantities from the data.</param>
        private static string getRecipeIngredientsString(string ingredients)
        {
            string list = "";
            string[] data = ingredients.Split(' ');
            
            for (int i = 0; i < data.Length; i += 2)
            {
                string itemName = getItemName(data[i]);
                int quantity = int.Parse(data[i + 1]);
                if (list != "")
                    list += str.Get("recipeIngredientSeparator");
                list += str.Get(quantity == 1? "recipeIngredientSingle" : "recipeIngredientMultiple",
                                new { ingredient = itemName, num = quantity });
            }
            
            return parenthesize(list);
        }
        
        /// <summary>Returns a list of sources for the given crafting recipe.</summary>
        /// <param name="recipeName">The internal name of the recipe.</param>
        private static string getCraftingRecipeSources(string recipeName)
        {
            return getRecipeSources(recipeName, false);
        }
        
        /// <summary>Returns a list of sources for the given cooking recipe.</summary>
        /// <param name="recipeName">The internal name of the recipe.</param>
        private static string getCookingRecipeSources(string recipeName)
        {
            return getRecipeSources(recipeName, true);
        }
        
        /// <summary>Returns a list of sources for the given recipe.</summary>
        /// <param name="recipeName">The internal name of the recipe.</param>
        /// <param name="isCooking">Whether the recipe is a cooking recipe rather than a crafting recipe.</param>
        private static string getRecipeSources(string recipeName, bool isCooking)
        {
            string recipeSources = "";
            
            // First, look for base requirement in recipe data definitions.
            string[] recipeData;
            string requirementDefinition = "";
            
            if (!isCooking)
            {
                recipeData = DataLoader.CraftingRecipes(Game1.content)[recipeName].Split('/');
                if (recipeData.Length > 4)
                    requirementDefinition = recipeData[4];
            }
            else
            {
                recipeData = DataLoader.CookingRecipes(Game1.content)[recipeName].Split('/');
                if (recipeData.Length > 3)
                    requirementDefinition = recipeData[3];
            }
            
            string[] data = requirementDefinition.Split(' ');
            string dataZero = data[0].ToLower();
            int value;
            
            switch (dataZero)
            {
                case "s": // Skill Level (s SkillName Lv#)
                case "farming": // Alternates (SkillName Lv#)
                case "mining":
                case "fishing":
                case "foraging":
                case "combat":
                    string skillName = dataZero.Equals("s")? data[1].ToLower() : dataZero;
                    if (int.TryParse(dataZero.Equals("s")? data[2] : data[1], out value))
                        if (value >= 1 && !skillName.Equals("luck")) // Ignore if inconsequential or Luck skill
                            recipeSources = str.Get("skillLvRequirement", new { skill = str.Get(skillName + "Skill"), num = value });
                    break;
                case "l": // Total Skill Level (l Lv#), combined total divided by two
                    if (int.TryParse(data[1], out value))
                        if (value >= 1 && value <= 25) // Ignore if inconsequential/unreachable (max is 25: 5 skills * 10 levels / 2)
                            recipeSources = str.Get("totalSkillLvRequirement", new { num = value * 2 });
                            // Combined total divided by two, so double it here to make it more understandable
                    break;
                case "f": // Friendship (f PersonName Heart#)
                    if (int.TryParse(data[2], out value))
                    {
                        if (data[1] != "Leo" || isIslandKnown()) // Don't mention Leo before island is known
                            recipeSources = str.Get("recipeSourceFriendship", new { person = getPersonName(data[1]), hearts = value });
                    }
                    break;
            }
            
            Dictionary<string, StardewValley.GameData.SpecialOrders.SpecialOrderData> orders;
            
            // Manual mail unlocks, often with multiple factors.
            switch (recipeName)
            {
                // Base Game Recipes By Mail
                case "Monster Musk":
                    recipeSources = str.Get("conditionalMailSpecialOrder",
                        new { orderName = TokenParser.ParseText("[LocalizedText Strings\\SpecialOrderStrings:Wizard2_Name]") }); // Prismatic Jelly
                    break;
                
                // Cornucopia Recipes By Mail
                case "Cornucopia_WaxBarrel":
                    orders = DataLoader.SpecialOrders(Game1.content);
                    if (orders.ContainsKey("Cornucopia.ArtisanMachines_WaxBarrel"))
                    {
                        recipeSources = str.Get("conditionalMailSpecialOrder",
                            new { orderName = TokenParser.ParseText(orders["Cornucopia.ArtisanMachines_WaxBarrel"].Name) }); // Gifts for Evelyn
                    }
                    break;
                
                case "Cornucopia_YogurtJar":
                    orders = DataLoader.SpecialOrders(Game1.content);
                    if (orders.ContainsKey("Cornucopia.ArtisanMachines_YogurtJar"))
                    {
                        recipeSources = str.Get("conditionalMailSpecialOrder",
                            new { orderName = TokenParser.ParseText(orders["Cornucopia.ArtisanMachines_YogurtJar"].Name) }); // Cultured Yogurt
                    }
                    break;
                
                // RSV Recipes By Mail
                case "Matcha Latte":
                    if (modRegistry.IsLoaded("Rafseazz.RSVCP"))
                        recipeSources = str.Get("conditionalMailSpecialOrder",
                            new { orderName = TokenParser.ParseText("[LocalizedText Strings\\SpecialOrderStrings:RSV.SpecialOrder.MorningDrinks_Name]") });
                    break;
                
                case "Clementine Cake":
                    if (modRegistry.IsLoaded("Rafseazz.RSVCP"))
                        recipeSources = conditionalMailSource("Shanice", 8);
                    break;
                
                case "Highland Blueberry Pie":
                    if (modRegistry.IsLoaded("Rafseazz.RSVCP"))
                        recipeSources = conditionalMailSource("Malaya", 8);
                    break;
                
                case "Fluffy Apple Crumble":
                    if (modRegistry.IsLoaded("Rafseazz.RSVCP"))
                        recipeSources = conditionalMailSource("Blair", 8);
                    break;
                
                case "Sweet Cranberry Cheesecake":
                    if (modRegistry.IsLoaded("Rafseazz.RSVCP"))
                        recipeSources = conditionalMailSource("Faye", 8);
                    break;
                
                // Alchemistry Recipes By Mail
                case "Morghoula.AlchemistryCP_EssenceRestabilizer_Recipe":
                    if (modRegistry.IsLoaded("Morghoula.AlchemistryCP"))
                        recipeSources = conditionalMailSource("Wizard", 4);
                    break;
                
                case "Morghoula.AlchemistryCP_ManaExtractor_Recipe":
                    if (modRegistry.IsLoaded("Morghoula.AlchemistryCP"))
                        recipeSources = conditionalMailSource(skill: str.Get("fishingSkill"), level: 3);
                    break;
                
                case "Morghoula.AlchemistryCP_TinctureBin_Recipe":
                    if (modRegistry.IsLoaded("Morghoula.AlchemistryCP"))
                        recipeSources = conditionalMailSource(skill: str.Get("farmingSkill"), level: 3);
                    break;
                
                case "Morghoula.AlchemistryCP_TransmuterCoil_Recipe":
                    if (modRegistry.IsLoaded("Morghoula.AlchemistryCP"))
                        recipeSources = conditionalMailSource("Wizard", 6, str.Get("miningSkill"), 8);
                    break;
                
                // PPJA Recipes By Mail
                case "Butter Churn":
                    if (modRegistry.IsLoaded("ppja.artisanvalleyforMFM")) // Artisan Valley
                        recipeSources = conditionalMailSource("Marnie", 4, "farming", 5);
                    break;
                
                case "Still":
                    if (modRegistry.IsLoaded("ppja.artisanvalleyforMFM")) // Artisan Valley
                        recipeSources = conditionalMailSource(skill: "farming", level: 10, year: 3, seasonKey: "fall");
                    break;
                
                case "Poached Pear":
                    if (modRegistry.IsLoaded("ppja.MoreRecipesforMFM")) // More Recipes
                        recipeSources = conditionalMailSource("Gus", 5, year: 2);
                    break;
                
                case "PB&J Sandwich":
                    if (modRegistry.IsLoaded("ppja.MoreRecipesforMFM")) // More Recipes
                        recipeSources = conditionalMailSource(skill: "farming", level: 4);
                    break;
                
                case "Seaweed Chips":
                    if (modRegistry.IsLoaded("ppja.EvenMoreRecipesforMFM")) // Even More Recipes
                        recipeSources = str.Get("recipeSourceFriendship", new { person = getPersonName("Willy"), hearts = 5 });
                    break;
                
                case "Chocolate Mouse Bread":
                    if (modRegistry.IsLoaded("ppja.EvenMoreRecipesforMFM")) // Even More Recipes
                        recipeSources = conditionalMailSource("Penny", 8, year: 3);
                    break;
            }
            
            // For cooking recipes, determine if obtainable from Queen of Sauce and add that as a source if so.
            if (isCooking)
            {
                for (int i = 1; i <= 32; i++)
                {
                    if (DataLoader.Tv_CookingChannel(Game1.content)[i.ToString()].Split('/')[0].Equals(recipeName))
                    {
                        string seasonKey = new string[] { "spring", "summer", "fall", "winter" }[((i - 1) / 4) % 4];
                        int day = (((i - 1) % 4) + 1) * 7;
                        int year = ((i - 1) / 16) + 1;
                        
                        int airDate = i * 7;
                        bool alreadyAired = Game1.stats.DaysPlayed > airDate;
                        if (alreadyAired) // If first airing already passed, give next scheduled airing 2n years later
                        {
                            do
                            {
                                airDate += 224;
                                year += 2;
                            } while (Game1.stats.DaysPlayed > airDate);
                        }
                        
                        string date;
                        if (Game1.stats.DaysPlayed == airDate) // Scheduled airing today
                            date = str.Get("today");
                        else // Scheduled airing at a future date
                        {
                            if (year != Game1.year) // Not this year, so year must be specified
                                date = str.Get("specificDate", new { season = str.Get(seasonKey), day, year });
                            else // Current year, so save space by not specifying
                                date = str.Get("generalDate", new { season = str.Get(seasonKey), day });
                        }
                        
                        recipeSources += (recipeSources != ""? str.Get("recipeSourceSeparator") : "")
                                       + str.Get("recipeSourceTV" + (alreadyAired? "AlreadyAired" : ""), new { date });
                        break;
                    }
                }
            }
            
            // Add other hardcoded non-mail sources.
            string separator = recipeSources != ""? str.Get("recipeSourceSeparator") : "";
            switch (recipeName)
            {
                // Base Game Crafting Recipes
                case "Wood Floor":
                case "Straw Floor":
                case "Stone Floor":
                case "Brick Floor":
                case "Stepping Stone Path":
                case "Crystal Path":
                case "Wooden Brazier":
                case "Stone Brazier":
                case "Gold Brazier":
                case "Carved Brazier":
                case "Stump Brazier":
                case "Barrel Brazier":
                case "Skull Brazier":
                case "Marble Brazier":
                case "Wood Lamp-post":
                case "Iron Lamp-post":
                    recipeSources += separator + str.Get("shopCarpenter");
                    break;
                
                case "Grass Starter":
                case "Dehydrator":
                    recipeSources += separator + str.Get("shopPierre");
                    break;
                    
                case "Fish Smoker":
                    recipeSources += separator + str.Get("shopFish");
                    break;
                
                case "Weathered Floor":
                    if (isDwarfKnown())
                        recipeSources += separator + str.Get("shopDwarf");
                    break;
                
                case "Crystal Floor":
                case "Wicked Statue":
                    if (isSewerKnown())
                        recipeSources += separator + str.Get("shopKrobus");
                    break;
                
                case "Warp Totem: Desert":
                    if (isDesertKnown())
                        recipeSources += separator + str.Get("shopDesertTrader");
                    break;
                
                case "Tub o' Flowers":
                    recipeSources += separator + str.Get("shopFlowerDance");
                    break;
                
                case "Jack-O-Lantern":
                    recipeSources += separator + str.Get("shopSpiritsEve");
                    break;
                
                case "Furnace":
                    recipeSources += separator + str.Get("recipeSourceFirstCopper",
                                                         new { copperOre = getItemName(ItemID.IT_CopperOre) });
                    break;
                
                case "Garden Pot":
                    recipeSources += separator + str.Get("recipeSourceAfterGreenhouse");
                    break;
                
                case "Cask":
                    recipeSources += separator + str.Get("recipeSourceFinalFarmhouse");
                    break;
                
                case "Ancient Seeds":
                    recipeSources += separator + str.Get("recipeSourceAncientSeed",
                                                         new { seedArtifact = getItemName(ItemID.IT_AncientSeedArtifact) });
                    break;
                
                case "Deluxe Scarecrow":
                    recipeSources += separator + str.Get("recipeSourceRarecrows");
                    break;
                
                case "Tea Sapling":
                    recipeSources += separator + str.Get("recipeSourceHeartEvent",
                                                         new { person = getPersonName("Caroline"), hearts = 2 });
                    break;
                
                case "Wild Bait":
                    recipeSources += separator + str.Get("recipeSourceHeartEvent",
                                                         new { person = getPersonName("Linus"), hearts = 4 });
                    break;
                
                case "Mini-Jukebox":
                    recipeSources += separator + str.Get("recipeSourceHeartEvent",
                                                         new { person = getPersonName("Gus"), hearts = 5 });
                    break;
                
                case "Flute Block":
                case "Drum Block":
                    recipeSources += separator + str.Get("recipeSourceHeartEvent",
                                                         new { person = getPersonName("Robin"), hearts = 6 });
                    break;
                
                case "Mystic Tree Seed":
                    recipeSources += separator + str.Get("skillMastery", new { skill = str.Get("foragingSkill") });
                    break;
                
                // Base Game Cooking Recipes
                case "Hashbrowns":
                case "Omelet":
                case "Pancakes":
                case "Bread":
                case "Tortilla":
                case "Pizza":
                case "Maki Roll":
                case "Triple Shot Espresso":
                    recipeSources += separator + str.Get("shopSaloon");
                    break;
                
                case "Cookies":
                    recipeSources += separator + str.Get("recipeSourceHeartEvent",
                                                         new { person = getPersonName("Evelyn"), hearts = 4 });
                    break;
                
                case "Banana Pudding":
                    if (isIslandKnown())
                        recipeSources += separator + str.Get("shopIslandTrader");
                    break;
                    
                case "Tropical Curry":
                    if (isIslandKnown())
                        recipeSources += separator + str.Get("shopIslandResort");
                    break;
                
                case "Ginger Ale":
                    if (isVolcanoKnown())
                        recipeSources += separator + str.Get("shopDwarfVolcano");
                    break;
                
                // SVE Cooking Recipes
                case "Big Bark Burger":
                case "Mixed Berry Pie":
                case "Glazed Butterfish":
                case "Candy":
                    recipeSources += separator + str.Get("shopSaloon");
                    break;
                
                case "Void Salmon Sushi":
                case "Void Delight":
                    if (isSewerKnown())
                        recipeSources += separator + str.Get("shopKrobus")
                                       + parenthesize(str.Get("recipeSourceFriendship",
                                                              new { person = getPersonName("Krobus"), hearts = 10 }));
                    break;
                
                case "Birch Syrup":
                    recipeSources += separator + str.Get("shopPierre");
                    break;
                
                case "Mushroom Berry Rice":
                case "Frog Legs":
                    recipeSources += separator + str.Get("shopGuild");
                    break;
                
                case "Ice Cream Sundae":
                    recipeSources += separator + str.Get("shopLuau");
                    break;
                
                case "Baked Berry Oatmeal":
                    recipeSources += separator + str.Get("shopWestForestBear");
                    break;
                
                // RSV Cooking Recipes
                case "Highland Ice Cream":
                    recipeSources += separator + str.Get("shopPikaRestaurant");
                    break;
                
                case "Pillowsoft Cheezy Sandwich":
                    recipeSources += separator + str.Get("shopHotelPastry");
                    break;
                
                case "Pink Frosted Sprinkled Doughnut":
                case "Kek's Style Shortcake":
                case "Wild Apple Juice":
                    recipeSources += separator + str.Get("shopMalayaRecipes");
                    break;
                
                // PPJA Cooking Recipes
                case "Mushroom and Pepper Crepe":
                case "Popcorn":
                case "Strawberry Lemonade":
                    if (modRegistry.IsLoaded("ppja.evenmorerecipes")) // Even More Recipes assets
                        recipeSources += separator + str.Get("shopSaloon");
                    break;
                
                case "Breakfast Tea":
                    if (modRegistry.IsLoaded("paradigmnomad.morefood")) // More Recipes (Fruits and Veggies) assets
                        recipeSources += separator + str.Get("shopSaloon");
                    break;
                
                case "Halloumi Burger":
                    if (modRegistry.IsLoaded("ppja.evenmorerecipes")) // Even More Recipes assets
                        recipeSources += separator + str.Get("shopSaloon") + parenthesize(str.Get("randomlyAvailable"));
                    break;
                
                case "Berry Fusion Tea":
                    if (modRegistry.IsLoaded("paradigmnomad.morefood")) // More Recipes (Fruits and Veggies) assets
                        recipeSources += separator + str.Get("shopSaloon") + parenthesize(str.Get("spring"));
                    break;
                
                case "Southern Sweet Tea":
                    if (modRegistry.IsLoaded("paradigmnomad.morefood")) // More Recipes (Fruits and Veggies) assets
                        recipeSources += separator + str.Get("shopSaloon") + parenthesize(str.Get("summer"));
                    break;
                
                case "Cranberry Pomegranate Tea":
                    if (modRegistry.IsLoaded("paradigmnomad.morefood")) // More Recipes (Fruits and Veggies) assets
                        recipeSources += separator + str.Get("shopSaloon") + parenthesize(str.Get("fall"));
                    break;
                
                case "Avocado Eel Roll":
                    if (modRegistry.IsLoaded("paradigmnomad.morefood")) // More Recipes (Fruits and Veggies) assets
                        recipeSources += separator + str.Get("shopSaloon") + getStartingYearString(2);
                    break;
                
                case "Rich Tiramisu":
                    if (modRegistry.IsLoaded("ppja.evenmorerecipes")) // Even More Recipes assets
                        recipeSources += separator + str.Get("shopSaloon") + getStartingYearString(2);
                    break;
                
                case "Ice Cream Brownie":
                    if (modRegistry.IsLoaded("ppja.evenmorerecipes")) // Even More Recipes assets
                        recipeSources += separator + str.Get("shopSaloon") + parenthesize(str.Get("randomlyAvailable"))
                                       + getStartingYearString(2);
                    break;
                
                case "Wasabi Peas":
                case "Grilled Zucchini":
                    if (modRegistry.IsLoaded("ppja.evenmorerecipes")) // Even More Recipes assets
                        recipeSources += separator + str.Get("shopSaloon") + getStartingYearString(3);
                    break;
                
                case "Sun Tea":
                    if (modRegistry.IsLoaded("paradigmnomad.morefood")) // More Recipes (Fruits and Veggies) assets
                        if (isDesertKnown())
                            recipeSources += separator + str.Get("shopOasis");
                    break;
                
                case "Prismatic Popsicle":
                    if (modRegistry.IsLoaded("ppja.evenmorerecipes")) // Even More Recipes assets
                    {
                        if (isDesertKnown())
                        {
                            bool shippedBerry = Game1.player.basicShipped.ContainsKey(ItemID.IT_SweetGemBerry)
                                             && Game1.player.basicShipped[ItemID.IT_SweetGemBerry] >= 1;
                            
                            recipeSources += separator + str.Get("shopOasis")
                                           + (!shippedBerry? parenthesize(str.Get("mustHaveShipped",
                                                                                  new { item = getItemName(ItemID.IT_SweetGemBerry) }))
                                                           : "");
                        }
                    }
                    break;
            }
            
            if (recipeSources.Equals("")) // No sources were found (usually due to leaving out spoilers)
                return str.Get("unknownSource");
            
            return recipeSources;
        }
        
        /// <summary>Returns a string describing conditions for recieving a certain piece of mail.</summary>
        /// <param name="person">Person who you need sufficient friendship with.</param>
        /// <param name="hearts">Hearts required with person.</param>
        /// <param name="skill">Skill that needs at a certain level.</param>
        /// <param name="level">Level required in skill.</param>
        /// <param name="year">Year of the earliest time you'll be able to receive the mail. Omitted if not specified.</param>
        /// <param name="seasonKey">Season of the earliest time you'll be able to receive the mail. Omitted if not specified.</param>
        /// <param name="day">Day of the earliest time you'll be able to receive the mail. Omitted if not specified.</param>
        private static string conditionalMailSource(string person = "", int hearts = 0,
                                                    string skill = "", int level = 0,
                                                    int year = 0, string seasonKey = "", int day = 0)
        {
            string friendReq = "", skillReq = "", time = "";
            
            int daysPlayedReq = ((year != 0? year - 1 : 0) * 112) + (day != 0? day : 1);
            switch (seasonKey)
            {
                // "" (default) and "spring" need not add any days
                case "summer": daysPlayedReq += 28; break;
                case "fall": daysPlayedReq += 56; break;
                case "winter": daysPlayedReq += 84; break;
            }
            
            if (Game1.stats.DaysPlayed < daysPlayedReq) // No need to mention time if player has reached required day
            {
                if (seasonKey != "" && day != 0 && year != 0)
                    time = str.Get("specificDate", new { season = str.Get(seasonKey), day = day, year = year });
                else if (seasonKey != "" && day != 0)
                    time = str.Get("generalDate", new { season = str.Get(seasonKey), day = day });
                else if (seasonKey != "" && year != 0)
                    time = str.Get("yearSeason", new { season = str.Get(seasonKey), year = year });
                else if (year != 0)
                    time = str.Get("year", new { year = year });
            }
            
            if (person != "")
                friendReq = str.Get("mailConditionFriendship", new { person = getPersonName(person), hearts = hearts });
            
            if (skill != "")
                skillReq = str.Get("skillLvRequirement", new { skill = str.Get(skill + "Skill"), num = level });
            
            // Return string combining the requirements depending on which are specified.
            if (time != "" && friendReq != "" && skillReq != "")
                return str.Get("conditionalMailAll", new { time, friendReq, skillReq });
            else if (time != "" && friendReq != "")
                return str.Get("conditionalMailTimeFriend", new { time, friendReq });
            else if (time != "" && skillReq != "")
                return str.Get("conditionalMailTimeSkill", new { time, skillReq });
            else if (friendReq != "" && skillReq != "")
                return str.Get("conditionalMailFriendSkill", new { friendReq, skillReq });
            else if (time != "")
                return time;
            else if (friendReq != "")
                return friendReq;
            else if (skillReq != "")
                return skillReq;
            else
                return "";
        }
        
        /// <summary>Returns startingYear hint with the given year, or a blank string if that year has already been reached.</summary>
        /// <param name="year">The starting year.</param>
        private static string getStartingYearString(int year)
        {
            return Game1.year < year? str.Get("startingYear", new { num = year }) : "";
        }
        
        /// <summary>Returns shops where you can buy standard seeds (removing JojaMart after it closes).</summary>
        private static string getSeedShopsString()
        {
            return multiKey("shopPierre", isJojaOpen()? "shopJoja" : "");
        }
        
        /// <summary>Returns time range given start and end hours.</summary>
        /// <param name="start">Start of time range (i.e. "6am", "12pm").</param>
        /// <param name="end">End of time range (i.e. "6am", "12pm").</param>
        private static string getTimeRange(string start, string end)
        {
            if (!using24HourTime())
            {
                string startTime = start.Contains("am")? str.Get("timeAM", new { hour = start.Replace("am", "") })
                                                       : str.Get("timePM", new { hour = start.Replace("pm", "") });
                string endTime = end.Contains("am")? str.Get("timeAM", new { hour = end.Replace("am", "") })
                                                   : str.Get("timePM", new { hour = end.Replace("pm", "") });
                return str.Get("timeRange", new { start = startTime, end = endTime });
            }
            else
            {
                int startHour = start.Contains("am")? int.Parse(start.Replace("am", ""))
                                                    : int.Parse(start.Replace("pm", "")) + 12;
                int endHour = end.Contains("am")? int.Parse(end.Replace("am", ""))
                                                : int.Parse(end.Replace("pm", "")) + 12;
                
                // Adjust for 12 AM/PM
                if (startHour == 12) // 12 AM
                    startHour = 24;
                else if (startHour == 24) // 12 PM
                    startHour = 12;
                
                if (endHour == 12) // 12 AM
                    endHour = 24;
                else if (endHour == 24) // 12 PM
                    endHour = 12;
                
                // When range goes past midnight (wrapping around to be less than start hour), end hour should go past 24
                if (endHour < startHour)
                    endHour += 24;
                
                string startTime = str.Get("time24Hour", new { hour = startHour });
                string endTime = str.Get("time24Hour", new { hour = endHour });
                return str.Get("timeRange", new { start = startTime, end = endTime });
            }
        }
        
        /// <summary>Returns a skill level requirement string in parentheses.</summary>
        /// <param name="skillName">The nane of the skill.</param>
        /// <param name="level">The level required.</param>
        private static string levelRequirementString(string skillName, int level)
        {
            return parenthesize(str.Get("skillLvRequirement", new { skill = str.Get(skillName + "Skill"), num = level }));
        }
        
        /// <summary>Returns a string with parentheses (and preceding space) put around it.</summary>
        /// <param name="text">The contained text.</param>
        private static string parenthesize(string text)
        {
            return str.Get("parenthesized", new { text = text });
        }
        
        /// <summary>Returns a standalone multi-line string listing hints for an sub-item in parentheses.</summary>
        /// <param name="itemID">The item ID of the sub-item.</param>
        /// <param name="quality">Required quality of the sub-item.</param>
        private static string subItemHints(string itemID, int quality = 0)
        {
            string hintText = getHintText(itemID, quality);
            string sourceList = "";
            foreach (string line in hintText.Split('\n'))
                sourceList += (sourceList != ""? "\n" : "") + str.Get("subItemSourceListEntry", new { hintLine = line });
            return str.Get("subItemHints", new { subItemName = getItemName(itemID), sourceList = sourceList });
        }
        
        /// <summary>Returns combined string for multiple seasons.</summary>
        /// <param name="seasons">List of season keys.</param>
        private static string multiSeason(params string[] seasons)
        {
            if (seasons.Length >= 4)
                return str.Get("allSeasons");
            else
                return multiKey(seasons);
        }
        
        /// <summary>Returns combined string for multiple string keys.</summary>
        /// <param name="keys">List of keys.</param>
        private static string multiKey(params string[] keys)
        {
            string[] strings = new string[keys.Length];
            for (int i = 0; i < keys.Length; i++)
                strings[i] = keys[i] != ""? str.Get(keys[i]) : "";
            return multiString(strings);
        }
        
        /// <summary>Returns combined string for multiple item names.</summary>
        /// <param name="items">List of item IDs.</param>
        private static string multiItem(params string[] items)
        {
            string[] strings = new string[items.Length];
            for (int i = 0; i < items.Length; i++)
                strings[i] = getItemName(items[i]);
            return multiString(strings);
        }
        
        /// <summary>Returns combined string for multiple strings.</summary>
        /// <param name="strings">List of strings.</param>
        private static string multiString(params string[] strings)
        {
            if (strings.Length == 1)
                return strings[0];
            else
            {
                string result = strings[0];
                for (int i = 1; i < strings.Length; i++)
                {
                    if (strings[i] != "")
                        result += (result != ""? str.Get("multipleThingSeparator") : "") + strings[i];
                }
                return result;
            }
        }
        
        /*************************
         ** Player Data Getters **
         *************************/
        
        /// <summary>Returns whether player chose a particular type of farm.</summary>
        /// <param name="farmType">String for farm type (standard, riverland, forest, hilltop, wilderness, fourCorners).</param>
        private static bool haveSpecialFarmType(string farmType)
        {
            string yourFarmType = "";
            switch (Game1.whichFarm)
            {
                case 0: yourFarmType = "standard"; break;
                case 1: yourFarmType = "riverland"; break;
                case 2: yourFarmType = "forest"; break;
                case 3: yourFarmType = "hilltop"; break;
                case 4: yourFarmType = "wilderness"; break;
                case 5: yourFarmType = "fourCorners"; break;
            }
            return yourFarmType.Equals(farmType);
        }
        
        /// <summary>Returns a number representing the highest-level coop on the farm.</summary>
        /// <returns>-1: No coop built; 0: Coop; 1: Big Coop; 2: Deluxe Coop</returns>
        private static int getCoopLevel()
        {
            Farm farm;
            try
            {
                farm = Game1.getFarm();
            }
            catch // Failed to get farm, possibly because no game is loaded
            {
                return -1;
            }
            
            return farm.isBuildingConstructed("Deluxe Coop")? 2
                 : farm.isBuildingConstructed("Big Coop")? 1
                 : farm.isBuildingConstructed("Coop")? 0
                                                     : -1;
        }
        
        /// <summary>Returns a number representing the highest-level barn on the farm.</summary>
        /// <returns>-1: No barn built; 0: Barn; 1: Big Barn; 2: Deluxe Barn</returns>
        private static int getBarnLevel()
        {
            Farm farm;
            try
            {
                farm = Game1.getFarm();
            }
            catch // Failed to get farm, possibly because no game is loaded
            {
                return -1;
            }
            
            return farm.isBuildingConstructed("Deluxe Barn")? 2
                 : farm.isBuildingConstructed("Big Barn")? 1
                 : farm.isBuildingConstructed("Barn")? 0
                                                     : -1;
        }
        
        /// <summary>Returns whether the bridge on the beach has been fixed, allowing access to the east side.</summary>
        private static bool fixedBridgeToEastBeach()
        {
            Beach beach = Game1.getLocationFromName("Beach") as Beach;
            if (beach != null)
                return beach.bridgeFixed.Value;
            return false;
        }
        
        /// <summary>Returns whether JojaMart is still open.</summary>
        private static bool isJojaOpen()
        {
            return Game1.isLocationAccessible("JojaMart");
        }
        
        /// <summary>Returns whether it's okay to mention Krobus/sewer, either due to spoiler policy or having Rusty Key.</summary>
        private static bool isSewerKnown()
        {
            return Config.ShowSpoilers || Game1.player.hasRustyKey;
        }
        
        /// <summary>Returns whether it's okay to mention dwarf, either due to spoiler policy or knowing dwarven language.</summary>
        private static bool isDwarfKnown()
        {
            return Config.ShowSpoilers || Game1.player.canUnderstandDwarves;
        }
        
        /// <summary>Returns whether it's okay to mention the desert, either due to spoiler policy or having unlocked it.</summary>
        private static bool isDesertKnown()
        {
            return Config.ShowSpoilers || Game1.MasterPlayer.mailReceived.Contains("ccVault");
        }
        
        /// <summary>Returns whether it's okay to mention the Skull Cavern, either due to spoiler policy or having unlocked it.</summary>
        private static bool isSkullCavernKnown()
        {
            return Config.ShowSpoilers || Game1.MasterPlayer.hasUnlockedSkullDoor;
        }
        
        /// <summary>Returns whether it's okay to mention the Witch's Swamp, either due to spoiler policy or having unlocked it.</summary>
        private static bool isWitchSwampKnown()
        {
            return Config.ShowSpoilers || Game1.MasterPlayer.hasOrWillReceiveMail("witchStatueGone");
        }
        
        /// <summary>Returns whether it's okay to mention Ginger Island, either due to spoiler policy or having unlocked it.</summary>
        private static bool isIslandKnown()
        {
            return Config.ShowSpoilers || Game1.MasterPlayer.hasOrWillReceiveMail("seenBoatJourney");
        }
        
        /// <summary>Returns whether it's okay to mention the volcano, either due to spoiler policy or having unlocked it.</summary>
        private static bool isVolcanoKnown()
        {
            return Config.ShowSpoilers || Game1.MasterPlayer.hasOrWillReceiveMail("islandNorthCaveOpened");
        }
        
        /// <summary>Returns whether it's okay to mention the Movie Theather, either due to spoiler policy or having unlocked it.</summary>
        private static bool isTheatherKnown()
        {
            return Config.ShowSpoilers || Game1.MasterPlayer.mailReceived.Contains("ccMovieTheater")
                                       || Game1.MasterPlayer.mailReceived.Contains("ccMovieTheaterJoja");
        }
        
        /// <summary>Returns whether the Mystery Boxes have been dropped.</summary>
        private static bool areMysteryBoxesUnlocked()
        {
            return Game1.MasterPlayer.mailReceived.Contains("sawQiPlane");
        }
        
        /// <summary>Returns whether current language should use 24-hour time.</summary>
        private static bool using24HourTime()
        {
            return Game1.content.GetCurrentLanguage() == LocalizedContentManager.LanguageCode.ja;
        }
    }
}
