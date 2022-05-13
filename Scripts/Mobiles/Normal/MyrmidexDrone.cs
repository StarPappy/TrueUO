namespace Server.Mobiles
{
    [CorpseName("a myrmidex corpse")]
    public class MyrmidexDrone : BaseCreature
    {
        [Constructable]
        public MyrmidexDrone()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, .2, .4)
        {
            Name = "a myrmidex drone";

            Body = 1402;
            BaseSoundID = 959;
            //Hue = 2676;

            SetStr(76, 105);
            SetDex(96, 136);
            SetInt(25, 44);

            SetDamage(6, 12);

            SetHits(460, 597);
            SetMana(0);

            SetResistance(ResistanceType.Physical, 1, 5);
            SetResistance(ResistanceType.Fire, 1, 5);
            SetResistance(ResistanceType.Cold, 1, 5);
            SetResistance(ResistanceType.Poison, 1, 5);
            SetResistance(ResistanceType.Energy, 1, 5);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Poison, 50);

            SetSkill(SkillName.MagicResist, 30.1, 43.5);
            SetSkill(SkillName.Tactics, 30.1, 49.0);
            SetSkill(SkillName.Wrestling, 41.1, 49.8);

            Fame = 2500;
            Karma = -2500;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.LootGold(50, 70));
        }

        public override int Meat => 4;
        public override Poison HitPoison => Poison.Regular;
        public override Poison PoisonImmune => Poison.Regular;
        public override int TreasureMapLevel => 1;

        public MyrmidexDrone(Serial serial)
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
