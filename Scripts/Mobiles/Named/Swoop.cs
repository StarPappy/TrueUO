using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Swoop corpse")]
    public class Swoop : Eagle
    {
        [Constructable]
        public Swoop()
        {
            Name = "Swoop";
            Hue = 0xE0;

            AI = AIType.AI_Melee;

            SetStr(100, 150);
            SetDex(400, 480);
            SetInt(75, 90);

            SetHits(1350, 1550);

            SetDamage(20, 30);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 75, 90);
            SetResistance(ResistanceType.Fire, 60, 70);
            SetResistance(ResistanceType.Cold, 70, 85);
            SetResistance(ResistanceType.Poison, 55, 60);
            SetResistance(ResistanceType.Energy, 50, 60);

            SetSkill(SkillName.Wrestling, 120.0, 140.0);
            SetSkill(SkillName.Tactics, 120.0, 140.0);
            SetSkill(SkillName.MagicResist, 95.0, 105.0);

            Fame = 18000;
            Karma = 0;

            Tamable = false;

            SetSpecialAbility(SpecialAbility.GraspingClaw);
        }

        public override bool CanBeParagon => false;

        public Swoop(Serial serial)
            : base(serial)
        {
        }

        public override bool CanFly => true;

        public override bool GivesMLMinorArtifact => true;

        public override int Feathers => 72;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);
            AddLoot(LootPack.HighScrolls);
            AddLoot(LootPack.MageryRegs, 4);
            AddLoot(LootPack.LootItem<ParrotItem>(10.0));
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
