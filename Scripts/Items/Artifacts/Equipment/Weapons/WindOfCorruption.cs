namespace Server.Items
{
    public class WindOfCorruption : Bow
    {
        public override int LabelNumber => 1150358;  // Wind of Corruption

        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;

        [Constructable]
        public WindOfCorruption()
        {
            WeaponAttributes.HitLeechStam = 40;
            Attributes.WeaponSpeed = 30;
            Attributes.WeaponDamage = 50;
            WeaponAttributes.HitLowerDefend = 40;
            AosElementDamages.Chaos = 100;
            Slayer = SlayerName.Fey;
            Hue = 1171;
        }

        public WindOfCorruption(Serial serial)
            : base(serial)
        {
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
