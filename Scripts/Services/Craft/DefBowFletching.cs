using Server.Items;
using System;

namespace Server.Engines.Craft
{
    public class DefBowFletching : CraftSystem
    {
        public override SkillName MainSkill => SkillName.Fletching;

        public override int GumpTitleNumber => 1044006;

        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefBowFletching();

                return m_CraftSystem;
            }
        }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.5; // 50%
        }

        private DefBowFletching()
            : base(1, 1, 1.25)// base( 1, 2, 1.7 )
        {
        }

        public override int CanCraft(Mobile from, ITool tool, Type itemType)
        {
            int num = 0;

            if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
                return 1044038; // You have worn out your tool!

            if (!tool.CheckAccessible(from, ref num))
                return num; // The tool must be on your person to use.

            return 0;
        }

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x55);
        }

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
            {
                from.SendLocalizedMessage(1044038); // You have worn out your tool
            }

            if (failed)
            {
                if (lostMaterial)
                {
                    return 1044043; // You failed to create the item, and some of your materials are lost.
                }

                return 1044157; // You failed to create the item, but no materials were lost.
            }

            if (quality == 0)
            {
                return 502785; // You were barely able to make this item.  It's quality is below average.
            }

            if (makersMark && quality == 2)
            {
                return 1044156; // You create an exceptional quality item and affix your maker's mark.
            }

            if (quality == 2)
            {
                return 1044155; // You create an exceptional quality item.
            }

            return 1044154; // You create the item.
        }

        public override CraftECA ECA => CraftECA.FiftyPercentChanceMinusTenPercent;

        public override void InitCraftList()
        {
            int index = -1;

            // Materials
            index = AddCraft(typeof(ElvenFletching), 1044457, 1113346, 90.0, 130.0, typeof(Feather), 1044562, 20, 1044563);
            AddRes(index, typeof(FaeryDust), 1113358, 1, 1044253);

            AddCraft(typeof(Kindling), 1044457, 1023553, 0.0, 00.0, typeof(Board), 1044041, 1, 1044351);

            index = AddCraft(typeof(Shaft), 1044457, 1027124, 0.0, 40.0, typeof(Board), 1044041, 1, 1044351);
            SetUseAllRes(index, true);

            // Ammunition
            index = AddCraft(typeof(Arrow), 1044565, 1023903, 0.0, 40.0, typeof(Shaft), 1044560, 1, 1044561);
            AddRes(index, typeof(Feather), 1044562, 1, 1044563);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(Bolt), 1044565, 1027163, 0.0, 40.0, typeof(Shaft), 1044560, 1, 1044561);
            AddRes(index, typeof(Feather), 1044562, 1, 1044563);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(FukiyaDarts), 1044565, 1030246, 50.0, 73.8, typeof(Board), 1044041, 1, 1044351);
            SetUseAllRes(index, true);

            // Weapons
            AddCraft(typeof(Bow), 1044566, 1025042, 30.0, 70.0, typeof(Board), 1044041, 7, 1044351);
            AddCraft(typeof(Crossbow), 1044566, 1023919, 60.0, 100.0, typeof(Board), 1044041, 7, 1044351);
            AddCraft(typeof(HeavyCrossbow), 1044566, 1025117, 80.0, 120.0, typeof(Board), 1044041, 10, 1044351);

            AddCraft(typeof(CompositeBow), 1044566, 1029922, 70.0, 110.0, typeof(Board), 1044041, 7, 1044351);
            AddCraft(typeof(RepeatingCrossbow), 1044566, 1029923, 90.0, 130.0, typeof(Board), 1044041, 10, 1044351);

            SetSubRes(typeof(Board), 1072643);

            // Add every material you want the player to be able to choose from
            // This will override the overridable material
            AddSubRes(typeof(Board), 1072643, 0.0, 1044041, 1072653);
            AddSubRes(typeof(OakBoard), 1072644, 65.0, 1044041, 1072653);
            AddSubRes(typeof(AshBoard), 1072645, 75.0, 1044041, 1072653);
            AddSubRes(typeof(YewBoard), 1072646, 85.0, 1044041, 1072653);
            AddSubRes(typeof(HeartwoodBoard), 1072647, 95.0, 1044041, 1072653);
            AddSubRes(typeof(BloodwoodBoard), 1072648, 95.0, 1044041, 1072653);
            AddSubRes(typeof(FrostwoodBoard), 1072649, 95.0, 1044041, 1072653);

            MarkOption = true;
            Repair = true;
            CanEnhance = true;
        }
    }
}
