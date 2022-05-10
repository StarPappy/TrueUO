namespace Server.Engines.Quests.Doom
{
    public class GrandGrimoire : Item
    {
        [Constructable]
        public GrandGrimoire()
            : base(0xEFA)
        {
            Weight = 1.0;
            Hue = 0x835;
            Layer = Layer.OneHanded;
        }

        public GrandGrimoire(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1060801;// The Grand Grimoire

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
