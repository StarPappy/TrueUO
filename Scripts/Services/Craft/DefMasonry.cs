using Server.Items;
using Server.Mobiles;
using System;

namespace Server.Engines.Craft
{
    public class DefMasonry : CraftSystem
    {
        public override SkillName MainSkill => SkillName.Carpentry;

        public override int GumpTitleNumber => 1044500;

        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefMasonry();

                return m_CraftSystem;
            }
        }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.0; // 0% 
        }

        private DefMasonry()
            : base(1, 1, 1.25)// base( 1, 2, 1.7 ) 
        {
        }

        public override bool RetainsColorFrom(CraftItem item, Type type)
        {
            return true;
        }

        public override int CanCraft(Mobile from, ITool tool, Type itemType)
        {
            int num = 0;

            if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
                return 1044038; // You have worn out your tool!

            if (tool is Item item && !BaseTool.CheckTool(item, from))
                return 1048146; // If you have a tool equipped, you must use that tool.

            if (!(from is PlayerMobile mobile && mobile.Masonry && mobile.Skills[SkillName.Carpentry].Base >= 100.0))
                return 1044633; // You havent learned stonecraft.

            if (!tool.CheckAccessible(from, ref num))
                return num; // The tool must be on your person to use.

            return 0;
        }

        public override void PlayCraftEffect(Mobile from)
        {
        }

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
                from.SendLocalizedMessage(1044038); // You have worn out your tool 

            if (failed)
            {
                if (lostMaterial)
                {
                    return 1044043; // You failed to create the item, and some of your materials are lost.
                }

                return 1044157; // You failed to create the item, but no materials were lost. 
            }

            if (quality == 0)
                return 502785; // You were barely able to make this item.  It's quality is below average.

            if (makersMark && quality == 2)
                return 1044156; // You create an exceptional quality item and affix your maker's mark.

            if (quality == 2)
            {
                return 1044155; // You create an exceptional quality item.
            }

            return 1044154; // You create the item. 
        }

        public override void InitCraftList()
        {
            // Decorations
            AddCraft(typeof(Vase), 1044501, 1022888, 52.5, 102.5, typeof(Granite), 1044514, 1, 1044513);
            AddCraft(typeof(LargeVase), 1044501, 1022887, 52.5, 102.5, typeof(Granite), 1044514, 3, 1044513);

            int index = AddCraft(typeof(SmallUrn), 1044501, 1029244, 82.0, 132.0, typeof(Granite), 1044514, 3, 1044513);

            index = AddCraft(typeof(SmallTowerSculpture), 1044501, 1029242, 82.0, 132.0, typeof(Granite), 1044514, 3, 1044513);

            AddCraft(typeof(GargoylePainting), 1044501, 1095317, 83.0, 133.0, typeof(Granite), 1044514, 3, 1044513);
            AddCraft(typeof(GargishSculpture), 1044501, 1095319, 82.0, 132.0, typeof(Granite), 1044514, 3, 1044513);
            AddCraft(typeof(GargoyleVase), 1044501, 1095322, 80.0, 126.0, typeof(Granite), 1044514, 3, 1044513);

            index = AddCraft(typeof(AnniversaryVaseTall), 1044501, 1156147, 60.0, 110.0, typeof(Granite), 1044514, 6, 1044513);
            AddRecipe(index, (int)CraftRecipes.AnniversaryVaseTall);

            index = AddCraft(typeof(AnniversaryVaseShort), 1044501, 1156148, 60.0, 110.0, typeof(Granite), 1044514, 6, 1044513);
            AddRecipe(index, (int)CraftRecipes.AnniversaryVaseShort);

            // Furniture
            AddCraft(typeof(StoneChair), 1044502, 1024635, 55.0, 105.0, typeof(Granite), 1044514, 4, 1044513);
            AddCraft(typeof(MediumStoneTableEastDeed), 1044502, 1044508, 65.0, 115.0, typeof(Granite), 1044514, 6, 1044513);
            AddCraft(typeof(MediumStoneTableSouthDeed), 1044502, 1044509, 65.0, 115.0, typeof(Granite), 1044514, 6, 1044513);
            AddCraft(typeof(LargeStoneTableEastDeed), 1044502, 1044511, 75.0, 125.0, typeof(Granite), 1044514, 9, 1044513);
            AddCraft(typeof(LargeStoneTableSouthDeed), 1044502, 1044512, 75.0, 125.0, typeof(Granite), 1044514, 9, 1044513);
            AddCraft(typeof(RitualTableDeed), 1044502, 1097690, 94.7, 103.5, typeof(Granite), 1044514, 8, 1044513);

            // Statues
            AddCraft(typeof(StatueSouth), 1044503, 1044505, 60.0, 110.0, typeof(Granite), 1044514, 3, 1044513);
            AddCraft(typeof(StatueNorth), 1044503, 1044506, 60.0, 110.0, typeof(Granite), 1044514, 3, 1044513);
            AddCraft(typeof(StatueEast), 1044503, 1044507, 60.0, 110.0, typeof(Granite), 1044514, 3, 1044513);
            AddCraft(typeof(StatuePegasusSouth), 1044503, 1044510, 70.0, 120.0, typeof(Granite), 1044514, 4, 1044513);
            AddCraft(typeof(StatueGargoyleEast), 1044503, 1097637, 54.5, 104.5, typeof(Granite), 1044514, 20, 1044513);
            AddCraft(typeof(StatueGryphonEast), 1044503, 1097619, 54.5, 104.5, typeof(Granite), 1044514, 15, 1044513);

            // Misc Addons
            index = AddCraft(typeof(StoneAnvilSouthDeed), 1044290, 1072876, 78.0, 128.0, typeof(Granite), 1044514, 20, 1044513);
            AddRecipe(index, (int)CraftRecipes.StoneAnvilSouth);

            index = AddCraft(typeof(StoneAnvilEastDeed), 1044290, 1073392, 78.0, 128.0, typeof(Granite), 1044514, 20, 1044513);
            AddRecipe(index, (int)CraftRecipes.StoneAnvilEast);

            index = AddCraft(typeof(LargeGargoyleBedSouthDeed), 1044290, 1111761, 76.0, 126.0, typeof(Granite), 1044514, 3, 1044513);
            AddSkill(index, SkillName.Tailoring, 70.0, 75.0);
            AddRes(index, typeof(Cloth), 1044286, 100, 1044287);

            index = AddCraft(typeof(LargeGargoyleBedEastDeed), 1044290, 1111762, 76.0, 126.0, typeof(Granite), 1044514, 3, 1044513);
            AddSkill(index, SkillName.Tailoring, 70.0, 75.0);
            AddRes(index, typeof(Cloth), 1044286, 100, 1044287);

            index = AddCraft(typeof(GargishCotEastDeed), 1044290, 1111921, 76.0, 126.0, typeof(Granite), 1044514, 3, 1044513);
            AddSkill(index, SkillName.Tailoring, 70.0, 75.0);
            AddRes(index, typeof(Cloth), 1044286, 100, 1044287);

            index = AddCraft(typeof(GargishCotSouthDeed), 1044290, 1111920, 76.0, 126.0, typeof(Granite), 1044514, 3, 1044513);
            AddSkill(index, SkillName.Tailoring, 70.0, 75.0);
            AddRes(index, typeof(Cloth), 1044286, 100, 1044287);

            // Stone Walls
            index = AddCraft(typeof(CraftableHouseItem), 1155792, 1155794, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, CraftableItemType.RoughWindowless);
            SetDisplayID(index, 464);

            index = AddCraft(typeof(CraftableHouseItem), 1155792, 1155797, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, CraftableItemType.RoughWindow);
            SetDisplayID(index, 467);

            index = AddCraft(typeof(CraftableHouseItem), 1155792, 1155799, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, CraftableItemType.RoughArch);
            SetDisplayID(index, 469);

            index = AddCraft(typeof(CraftableHouseItem), 1155792, 1155804, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, CraftableItemType.RoughPillar);
            SetDisplayID(index, 474);

            index = AddCraft(typeof(CraftableHouseItem), 1155792, 1155805, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, CraftableItemType.RoughRoundedArch);
            SetDisplayID(index, 475);

            index = AddCraft(typeof(CraftableHouseItem), 1155792, 1155810, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, CraftableItemType.RoughSmallArch);
            SetDisplayID(index, 480);

            index = AddCraft(typeof(CraftableHouseItem), 1155792, 1155814, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, CraftableItemType.RoughAngledPillar);
            SetDisplayID(index, 486);

            index = AddCraft(typeof(CraftableHouseItem), 1155792, 1155816, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, CraftableItemType.ShortRough);
            SetDisplayID(index, 488);

            index = AddCraft(typeof(CraftableStoneHouseDoor), 1155792, 1156078, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, DoorType.StoneDoor_S_In);
            SetDisplayID(index, 804);
            AddCreateItem(index, CraftableStoneHouseDoor.Create);

            index = AddCraft(typeof(CraftableStoneHouseDoor), 1155792, 1156079, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, DoorType.StoneDoor_E_Out);
            SetDisplayID(index, 805);
            AddCreateItem(index, CraftableStoneHouseDoor.Create);

            index = AddCraft(typeof(CraftableStoneHouseDoor), 1155792, 1156348, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, DoorType.StoneDoor_S_Out);
            SetDisplayID(index, 804);
            AddCreateItem(index, CraftableStoneHouseDoor.Create);

            index = AddCraft(typeof(CraftableStoneHouseDoor), 1155792, 1156349, 60.0, 110.0, typeof(Granite), 1044514, 10, 1044513);
            SetData(index, DoorType.StoneDoor_E_In);
            SetDisplayID(index, 805);
            AddCreateItem(index, CraftableStoneHouseDoor.Create);

            // Stone Stairs
            index = AddCraft(typeof(CraftableHouseItem), 1155820, 1155821, 60.0, 110.0, typeof(Granite), 1044514, 5, 1044513);
            SetData(index, CraftableItemType.RoughBlock);
            SetDisplayID(index, 1928);

            index = AddCraft(typeof(CraftableHouseItem), 1155820, 1155822, 60.0, 110.0, typeof(Granite), 1044514, 5, 1044513);
            SetData(index, CraftableItemType.RoughSteps);
            SetDisplayID(index, 1929);

            index = AddCraft(typeof(CraftableHouseItem), 1155820, 1155826, 60.0, 110.0, typeof(Granite), 1044514, 5, 1044513);
            SetData(index, CraftableItemType.RoughCornerSteps);
            SetDisplayID(index, 1934);

            index = AddCraft(typeof(CraftableHouseItem), 1155820, 1155830, 60.0, 110.0, typeof(Granite), 1044514, 5, 1044513);
            SetData(index, CraftableItemType.RoughRoundedCornerSteps);
            SetDisplayID(index, 1938);

            index = AddCraft(typeof(CraftableHouseItem), 1155820, 1155834, 60.0, 110.0, typeof(Granite), 1044514, 5, 1044513);
            SetData(index, CraftableItemType.RoughInsetSteps);
            SetDisplayID(index, 1941);

            index = AddCraft(typeof(CraftableHouseItem), 1155820, 1155838, 60.0, 110.0, typeof(Granite), 1044514, 5, 1044513);
            SetData(index, CraftableItemType.RoughRoundedInsetSteps);
            SetDisplayID(index, 1945);

            // Stone Floors
            index = AddCraft(typeof(CraftableHouseItem), 1155877, 1155878, 60.0, 110.0, typeof(Granite), 1044514, 5, 1044513);
            SetData(index, CraftableItemType.LightPaver);
            SetDisplayID(index, 1305);

            index = AddCraft(typeof(CraftableHouseItem), 1155877, 1155879, 60.0, 110.0, typeof(Granite), 1044514, 5, 1044513);
            SetData(index, CraftableItemType.MediumPaver);
            SetDisplayID(index, 1309);

            index = AddCraft(typeof(CraftableHouseItem), 1155877, 1155880, 60.0, 110.0, typeof(Granite), 1044514, 5, 1044513);
            SetData(index, CraftableItemType.DarkPaver);
            SetDisplayID(index, 1313);

            MarkOption = true;
            Repair = true;
            CanEnhance = true;

            SetSubRes(typeof(Granite), 1044525);

            AddSubRes(typeof(Granite), 1044525, 00.0, 1044514, 1044526);
            AddSubRes(typeof(DullCopperGranite), 1044023, 65.0, 1044514, 1044526);
            AddSubRes(typeof(ShadowIronGranite), 1044024, 70.0, 1044514, 1044526);
            AddSubRes(typeof(CopperGranite), 1044025, 75.0, 1044514, 1044526);
            AddSubRes(typeof(BronzeGranite), 1044026, 80.0, 1044514, 1044526);
            AddSubRes(typeof(GoldGranite), 1044027, 85.0, 1044514, 1044526);
            AddSubRes(typeof(AgapiteGranite), 1044028, 90.0, 1044514, 1044526);
            AddSubRes(typeof(VeriteGranite), 1044029, 95.0, 1044514, 1044526);
            AddSubRes(typeof(ValoriteGranite), 1044030, 99.0, 1044514, 1044526);
        }
    }
}
