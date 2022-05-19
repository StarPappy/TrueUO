using Server.Items;
using System;

namespace Server.Mobiles
{
    [CorpseName("a rotworm corpse")]
    public class Rotworm : BaseCreature
    {
        [Constructable]
        public Rotworm()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.25, 0.5)
        {
            Name = "a rotworm";
            Body = 732;

            SetStr(200, 300);
            SetDex(80);
            SetInt(15, 20);

            SetHits(200, 250);
            SetStam(50);

            SetDamage(1, 5);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 35, 45);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 65, 75);
            SetResistance(ResistanceType.Energy, 25, 35);

            SetSkill(SkillName.MagicResist, 25.0);
            SetSkill(SkillName.Tactics, 25.0);
            SetSkill(SkillName.Wrestling, 50.0);

            Fame = 500;
            Karma = -500;

            SetSpecialAbility(SpecialAbility.BloodDisease);
        }

        public Rotworm(Serial serial)
            : base(serial)
        {
        }

        public override int GetAngerSound() { return 0x62D; }
        public override int GetIdleSound() { return 0x62D; }
        public override int GetAttackSound() { return 0x62A; }
        public override int GetHurtSound() { return 0x62C; }
        public override int GetDeathSound() { return 0x62B; }

        public override int Meat => 2;
        public override MeatType MeatType => MeatType.Rotworm;
        public override FoodType FavoriteFood => FoodType.Fish;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
            AddLoot(LootPack.BodyPartsAndBones);
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (m.FindItemOnLayer(Layer.TwoHanded) is CandlewoodTorch torch && torch.Burning)
            {
                ForceFleeUntil = DateTime.UtcNow + TimeSpan.FromSeconds(5.0);
            }
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
