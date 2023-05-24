namespace Server.Items
{
    [Flipable(0x13cb, 0x13d2)]
    public class LeatherLegs : BaseArmor
    {
        [Constructable]
        public LeatherLegs()
            : base(0x13CB)
        {
            Weight = 4.0;

            Attributes.BonusHits = 5;
        }

        public LeatherLegs(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => Quality == ItemQuality.Exceptional ? 3 : 2;

        public override int InitMinHits => 30;
        public override int InitMaxHits => 40;
        public override int StrReq => 20;

        public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;
        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

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
