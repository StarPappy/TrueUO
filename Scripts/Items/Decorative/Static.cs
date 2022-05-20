namespace Server.Items
{
    public class Static : Item
    {
        public Static()
            : base(0x80)
        {
            Movable = false;
        }

        [Constructable]
        public Static(int itemID)
            : base(itemID)
        {
            Movable = false;
        }

        [Constructable]
        public Static(int itemID, int count)
            : this(Utility.Random(itemID, count))
        {
        }

        public Static(Serial serial)
            : base(serial)
        {
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

    public class LocalizedStatic : Static
    {
        private int m_LabelNumber;

        [Constructable]
        public LocalizedStatic(int itemID)
            : this(itemID, itemID < 0x4000 ? 1020000 + itemID : 1078872 + itemID)
        {
        }

        [Constructable]
        public LocalizedStatic(int itemID, int labelNumber)
            : base(itemID)
        {
            m_LabelNumber = labelNumber;
        }

        public LocalizedStatic(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Number
        {
            get => m_LabelNumber;
            set
            {
                m_LabelNumber = value;
                InvalidateProperties();
            }
        }

        public override int LabelNumber => m_LabelNumber;

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((byte)0); // version

            writer.WriteEncodedInt(m_LabelNumber);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadByte();

            m_LabelNumber = reader.ReadEncodedInt();
        }
    }
}
