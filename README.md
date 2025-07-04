# CommunityCenterHelper
A mod for **Stardew Valley** that adds suggestions when hovering over required items for bundles, or items in the Collections tab.

## Description

Need help finding items for the Community Center bundles, but don't want to look it up online every time? This mod adds suggestions of where to find items when you hover over/highlight them in the bundle menu!

Suggestions are generally tailored to your progress in the game. For example, if an item requires an unlearned cooking recipe, it will tell you how to get the recipe; otherwise, it will tell you the ingredients. It tries to make it clear when there are requirements (such as skill levels) that must be met in before the item can be obtained.

Most item sources are included, but not every possible one - I prioritized the easiest and most reliable ways to get each item. This notably excludes things like the Traveling Cart, which can randomly provide many of the items required for bundles, but cannot be relied upon. I also don't account for bundle rewards, since they're one-time and are often changed by mods.

Additionally, as of version 1.6.0, you can choose to show hints for items in the Collections tab as well, which can help with filling in your Collection or finding more of a particular item. Note that only items from the base game Collections tab are guaranteed to be supported, as supporting every mod item that could be there is infeasible.

## Supported Languages

**English, Japanese, Simplified Chinese (provided by sansenenlemon), Traditional Chinese (provided by Yilite), French (provided by Azurys & Caranud), German (provided by NotErikWasTaken & randomC0der), Italian (provided by AliAgo08 & flowerssummerr), Portuguese (provided by Cosmiky), Russian (provided by angel4killer & AppleNorris), Spanish (provided by vlcoo), Thai (provided by ellipszist), Turkish (provided by sevilayerkan), Ukrainian (provided by ChulkyBow)**

(Even in unsupported languages, item and character names refer directly to the data, so those will use the proper names for that language.)

## Installation
1. Install the latest version of SMAPI.
2. Unzip the mod folder into Stardew Valley/Mods.
3. Run the game using SMAPI.

## User Configuration

**NOTE:** The Collections tab setting is disabled by default, so be sure to enable it if you want it! Either edit the config.json file directly, or if you have [Generic Mod Config Menu](https://www.nexusmods.com/stardewvalley/mods/5098) installed, open Mod Config from the title screen or options menu.

### ShowSpoilers (true or false)
By its nature, this mod spoils certain things about the game. However, by default ("ShowSpoilers": false), it tries to conceal things that could be seen as "surprises" for new players, like areas and characters you haven't yet encountered. If you want all the information regardless of your progress in the game, you can set this to true.

**Things that are still spoiled with ShowSpoilers disabled:** Names of items and machines, requirements for getting recipes, the existence of some constructions.

**Things that ShowSpoilers will hide as appropriate:** Names of areas you haven't yet reached, unknown shops, unencountered monsters.

### ShowCollectionsTabHints (0, 1, or 2)
You can enable this to show the same style of hint tooltips in the Collections tab as well.

**0 (off, default):** Never show location hints in the Collections tab.

**1 (for unknowns):** Shows hints for where to get items not yet obtained in Collections.

**2 (all items):** Not only shows hints for unobtained items, but allows you to review location hints on obtained items as well - just click or press the Action or Tool button to toggle what's displayed.

## Bundle Mod Support
In addition to the bundles (both normal and remixed) in the base game, the following bundle-altering mods are supported.

- Custom Community Center Bundles (by Alja)
- Challenging Community Center Bundles (by Alja)
- Minerva's Harder Community Center Bundles
- Legacy Community Center Bundles (by Lunatyx)
- Alchemistry Bundles (Easy and Harder) (by Morghoula)
- Community Center Bundle Overhaul (by 7Yrs, SMAPI version by Chaos234)
- EasierBundles (by Quirinea)
- Alternative Bundles (by Quirinea)
- Vegan Community Center Bundles (by Yuki Del Valle)
- difficulty option for bundles (by Axisdubois)
- Very Hard version of Community Center Bundles for 1 year challenge (by kners)
- Adventurer's Bundle to Gemologist's Bundle (by LenneDalben)
- The Impossible Bundle (by Mossy)

Note that even if a bundle mod is not listed here, it's still likely to have partial, or possibly even full support for non-modded items - suggestions are defined on a per-item basis, and many base-game items are covered. Any items not covered will just not show any suggestions.

## Possible Mod Conflicts
I tried to have this mod directly reference the data when possible, so some things changed by mods (like recipe unlock requirements that aren't mail-based) may be automatically supported. But for the most part, suggestions are hardcoded according to the base game, and could be inaccurate or incomplete when using mods that make major changes. (In just a few cases, there are suggestions that are only listed when specific mods are installed, but I'm absolutely not committing to covering everything like that.)

Besides that, however, the mod does very little to the code and is unlikely to break the game in combination with anything.

## Download

[Nexus Mods](https://www.nexusmods.com/stardewvalley/mods/6893/)
