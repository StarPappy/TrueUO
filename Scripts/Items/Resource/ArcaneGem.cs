using Server.Targeting;
using System.Collections.Generic;

namespace Server.Items
{
    public class ArcaneGem : Item, ICommodity
    {
        public const int DefaultArcaneHue = 2117;
        public override int LabelNumber => 1114115;  // Arcane Gem

        [Constructable]
        public ArcaneGem()
            : this(1)
        {
        }

        [Constructable]
        public ArcaneGem(int amount)
            : base(0x1EA7)
        {
            Stackable = true;
            Amount = amount;
            Weight = 1.0;
        }

        public ArcaneGem(Serial serial)
            : base(serial)
        {
        }

        TextDefinition ICommodity.Description => LabelNumber;
        bool ICommodity.IsDeedable => true;

        public static bool ConsumeCharges(Mobile from, int amount)
        {
            List<Item> items = from.Items;
            int avail = 0;

            for (int i = 0; i < items.Count; ++i)
            {
                Item obj = items[i];

                if (obj is IArcaneEquip eq)
                {
                    if (eq.IsArcane)
                        avail += eq.CurArcaneCharges;
                }
            }

            if (avail < amount)
                return false;

            for (int i = 0; i < items.Count; ++i)
            {
                Item obj = items[i];

                if (obj is IArcaneEquip eq)
                {
                    if (eq.IsArcane)
                    {
                        if (eq.CurArcaneCharges > amount)
                        {
                            eq.CurArcaneCharges -= amount;
                            break;
                        }

                        amount -= eq.CurArcaneCharges;
                        eq.CurArcaneCharges = 0;
                    }
                }
            }

            return true;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042010); // You must have the object in your backpack to use it.
            }
            else
            {
                from.BeginTarget(2, false, TargetFlags.None, OnTarget);
            }
        }

        public int GetChargesFor(Mobile m)
        {
            int v = (int)(m.Skills[SkillName.Tailoring].Value / 5);

            if (v < 16)
                return 16;
            if (v > 24)
                return 24;

            return v;
        }

        public void OnTarget(Mobile from, object obj)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042010); // You must have the object in your backpack to use it.
                return;
            }

            if (obj is IArcaneEquip eq && eq is Item item)
            {
                CraftResource resource = CraftResource.None;

                if (item is BaseClothing clothing)
                    resource = clothing.Resource;
                else if (item is BaseArmor armor)
                    resource = armor.Resource;
                else if (item is BaseWeapon weapon) // Sanity, weapons cannot recieve gems...
                    resource = weapon.Resource;

                if (!item.IsChildOf(from.Backpack))
                {
                    from.SendMessage("You may only target items in your backpack.");
                    return;
                }

                int charges = GetChargesFor(from);

                if (eq.IsArcane)
                {
                    if (eq.CurArcaneCharges > 0)
                    {
                        from.SendMessage("This item still has charges left.");
                    }
                    else
                    {
                        item.Hue = eq.TempHue;

                        if (charges >= eq.MaxArcaneCharges)
                        {
                            eq.CurArcaneCharges = eq.MaxArcaneCharges;
                            from.SendMessage("Your skill in tailoring allows you to fully recharge the item.");
                        }
                        else
                        {
                            eq.CurArcaneCharges += charges;
                            from.SendMessage("You are only able to restore some of the charges.");

                        }

                        Consume();
                    }
                }
                else if (from.Skills[SkillName.Tailoring].Value >= 60.0)
                {
                    bool isExceptional = false;

                    if (item is BaseClothing bc)
                        isExceptional = bc.Quality == ItemQuality.Exceptional;
                    else if (item is BaseArmor ba)
                        isExceptional = ba.Quality == ItemQuality.Exceptional;
                    else if (item is BaseWeapon bw)
                        isExceptional = bw.Quality == ItemQuality.Exceptional;

                    if (isExceptional)
                    {
                        if (item is BaseClothing cloth)
                        {
                            cloth.Quality = ItemQuality.Normal;
                            cloth.Crafter = from;
                        }
                        else if (item is BaseArmor armor)
                        {
                            if (armor.IsImbued || armor.IsArtifact || RunicReforging.GetArtifactRarity(armor) > 0)
                            {
                                from.SendLocalizedMessage(1049690); // Arcane gems cannot be used on that type of leather.
                                return;
                            }

                            armor.Quality = ItemQuality.Normal;
                            armor.Crafter = from;
                            armor.PhysicalBonus = 0;
                            armor.FireBonus = 0;
                            armor.ColdBonus = 0;
                            armor.PoisonBonus = 0;
                            armor.EnergyBonus = 0;
                        }
                        else
                        {
                            BaseWeapon weapon = item as BaseWeapon; // Sanity, weapons cannot recieve gems...

                            weapon.Quality = ItemQuality.Normal;
                            weapon.Crafter = from;
                        }

                        eq.CurArcaneCharges = eq.MaxArcaneCharges = charges;

                        item.Hue = DefaultArcaneHue;

                        if (item.LootType == LootType.Blessed)
                            item.LootType = LootType.Regular;

                        Consume();
                    }
                    else
                    {
                        from.SendMessage("You can only use this on exceptionally crafted robes, thigh boots, cloaks, or leather gloves.");
                    }
                }
                else
                {
                    from.SendMessage("You do not have enough skill in tailoring to use this.");
                }
            }
            else
            {
                from.SendMessage("You can only use this on exceptionally crafted robes, thigh boots, cloaks, or leather gloves.");
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
