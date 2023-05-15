using Server.Items;
using System;

namespace Server.Engines.Quests
{
    public class Aurvidlem : MondainQuester
    {
        [Constructable]
        public Aurvidlem()
            : base("Aurvidlem", "the Artificer")
        {
            SetSkill(SkillName.ItemID, 60.0, 83.0);
            SetSkill(SkillName.Imbuing, 60.0, 83.0);
        }

        public Aurvidlem(Serial serial)
            : base(serial)
        {
        }

        public override Type[] Quests => new[] { typeof(KnowledgeoftheSoulforge) };

        public override void InitBody()
        {
            InitStats(100, 100, 25);

            CantWalk = true;
            Race = Race.Human;

            Hue = 0x86DE;
            HairItemID = 0x4259;
            HairHue = 0x0;
        }

        public override void Advertise()
        {
            Say(1112525);  // Come to be Artificer. I have a task for you. 
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
