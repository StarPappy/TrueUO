namespace Server.Items
{
    public class HolidayBell : Item
    {
        private static readonly string[] m_StaffNames =
        {
            "Adrick",
            "Alai",
            "Bulldoz",
            "Evocare",
            "FierY-iCe",
            "Greyburn",
            "Hanse",
            "Ignatz",
            "Jalek",
            "LadyMOI",
            "Lord Krum",
            "Malantus",
            "Nimrond",
            "Oaks",
            "Prophet",
            "Runesabre",
            "Sage",
            "Stellerex",
            "T-Bone",
            "Tajima",
            "Tyrant",
            "Vex"
        };

        private static readonly int[] m_Hues =
        {
            0xA, 0x24, 0x42, 0x56, 0x1A, 0x4C, 0x3C, 0x60, 0x2E, 0x55, 0x23, 0x38, 0x482, 0x6, 0x10
        };

        private string m_Maker;
        private int m_SoundID;

        [Constructable]
        public HolidayBell()
            : this(m_StaffNames[Utility.Random(m_StaffNames.Length)])
        {
        }

        [Constructable]
        public HolidayBell(string maker)
            : base(0x1C12)
        {
            m_Maker = maker;

            Hue = m_Hues[Utility.Random(m_Hues.Length)];
            SoundID = 0x0F5 + Utility.Random(14);
        }

        public HolidayBell(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SoundID
        {
            get => m_SoundID;
            set
            {
                m_SoundID = value;
                InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string Giver { get => m_Maker; set => m_Maker = value; }

        public override string DefaultName => string.Format("A Holiday Bell From {0}", Giver);

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.InRange(GetWorldLocation(), 2))
            {
                from.SendLocalizedMessage(500446); // That is too far away.
            }
            else
            {
                from.PlaySound(m_SoundID);
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version

            writer.Write(m_Maker);
            writer.WriteEncodedInt(m_SoundID);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();

            m_Maker = reader.ReadString();
            m_SoundID = reader.ReadEncodedInt();

            Utility.Intern(ref m_Maker);
        }
    }
}
