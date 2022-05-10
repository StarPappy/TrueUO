namespace Server.Items
{
    public class CandlewoodTorch : BaseShield
    {
        public override int LabelNumber => 1094957;  //Candlewood Torch
        public override bool IsArtifact => true;
        public bool Burning => ItemID == 0xA12;

        [Constructable]
        public CandlewoodTorch()
            : base(0xF6B)
        {
            Weight = 1.0;
            Attributes.SpellChanneling = 1;
            Attributes.CastSpeed = -1;
        }

        public CandlewoodTorch(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
            else
            {
                if (ItemID == 0xF6B)
                {
                    ItemID = 0xA12;
                }
                else if (ItemID == 0xA12)
                {
                    ItemID = 0xF6B;
                }
            }

            Mobile parent = Parent as Mobile;

            if (parent == from && Burning)
            {
                Mobiles.MeerMage.StopEffect(parent, true);
                SwarmContext.CheckRemove(parent);
            }
        }

        public override void OnAdded(object parent)
        {
            base.OnAdded(parent);

            if (parent is Mobile mobile && Burning)
            {
                Mobiles.MeerMage.StopEffect(mobile, true);
                SwarmContext.CheckRemove(mobile);
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadEncodedInt();
        }
    }
}
