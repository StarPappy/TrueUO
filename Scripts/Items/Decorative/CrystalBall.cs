using Server.Network;

namespace Server.Items
{
    public class MagicCrystalBall : Item
    {
        [Constructable]
        public MagicCrystalBall() : base(0xE2E)
        {
            Name = "a crystal ball";
            Weight = 10;
            Stackable = false;
            Light = LightType.Circle150;
        }

        public MagicCrystalBall(Serial serial) : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            PublicOverheadMessage(MessageType.Regular, 0x3B2, 1007000 + Utility.Random(28));
        }

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
