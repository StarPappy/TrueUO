using Server.Engines.Quests;
using Server.Items;
using System;

namespace Server.Mobiles
{
    public class QueenZhah : MondainQuester
    {
        public override Type[] Quests => new[] { typeof(JourneyToTheAthenaeumIsleQuest) };

        [Constructable]
        public QueenZhah() : base("Zhah", "the Gargoyle Queen")
        {
        }

        public override void InitBody()
        {
            Female = true;
            Race = Race.Human;
            Body = 667;

            InitStats(100, 100, 25);
            SpeechHue = Utility.RandomDyedHue();
            Hue = Race.RandomSkinHue();

            HairItemID = 0x42AB; // Get tiare looking kind
            HairHue = Race.RandomHairHue();
        }

        public override void Advertise()
        {
            Say(1150932);
        }

        public QueenZhah(Serial serial)
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
