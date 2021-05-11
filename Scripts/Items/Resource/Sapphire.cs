namespace Server.Items
{
    public class Sapphire : Item, IGem, ICommodity
    {
        [Constructable]
        public Sapphire()
            : this(1)
        {
        }

        [Constructable]
        public Sapphire(int amount)
            : base(0xF11)
        {
            Stackable = true;
            Amount = amount;
        }

        public Sapphire(Serial serial)
            : base(serial)
        {
        }

        TextDefinition ICommodity.Description => LabelNumber;
        bool ICommodity.IsDeedable => true;

        public override double DefaultWeight => 0.1;

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
