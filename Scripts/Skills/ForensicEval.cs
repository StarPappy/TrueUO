using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using System;
using System.Text;

namespace Server.SkillHandlers
{
    public interface IForensicTarget
    {
        void OnForensicEval(Mobile m);
    }

    public class ForensicEvaluation
    {
        public static void Initialize()
        {
            SkillInfo.Table[(int)SkillName.Forensics].Callback = OnUse;
        }

        public static TimeSpan OnUse(Mobile m)
        {
            m.Target = new ForensicTarget();
            m.RevealingAction();

            m.SendLocalizedMessage(501000); // Show me the crime.

            return TimeSpan.FromSeconds(1.0);
        }

        public class ForensicTarget : Target
        {
            public ForensicTarget()
                : base(10, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object target)
            {
                double skill = from.Skills[SkillName.Forensics].Value;
                double minSkill = 30.0;

                if (target is Corpse c)
                {
                    if (skill < minSkill)
                    {
                        from.SendLocalizedMessage(501003); //You notice nothing unusual.
                        return;
                    }

                    if (from.CheckTargetSkill(SkillName.Forensics, c, minSkill, 55.0))
                    {
                        if (c.m_Forensicist != null)
                            from.SendLocalizedMessage(1042750, c.m_Forensicist); // The forensicist  ~1_NAME~ has already discovered that:
                        else
                            c.m_Forensicist = from.Name;

                        if (((Body)c.Amount).IsHuman)
                            from.SendLocalizedMessage(1042751, c.Killer == null ? "no one" : c.Killer.Name);//This person was killed by ~1_KILLER_NAME~

                        if (c.Looters.Count > 0)
                        {
                            StringBuilder sb = new StringBuilder();

                            for (int i = 0; i < c.Looters.Count; i++)
                            {
                                if (i > 0)
                                    sb.Append(", ");

                                sb.Append(c.Looters[i].Name);
                            }

                            from.SendLocalizedMessage(1042752, sb.ToString());//This body has been distrubed by ~1_PLAYER_NAMES~
                        }
                        else
                        {
                            from.SendLocalizedMessage(501002);//The corpse has not be desecrated.
                        }
                    }
                    else
                    {
                        from.SendLocalizedMessage(501001);//You cannot determain anything useful.
                    }
                }
                else if (target is Mobile)
                {
                    if (skill < 36.0)
                    {
                        from.SendLocalizedMessage(501003);//You notice nothing unusual.
                    }
                    else if (from.CheckTargetSkill(SkillName.Forensics, target, 36.0, 100.0))
                    {
                        if (target is PlayerMobile mobile && mobile.NpcGuild == NpcGuild.ThievesGuild)
                        {
                            from.SendLocalizedMessage(501004);//That individual is a thief!
                        }
                        else
                        {
                            from.SendLocalizedMessage(501003);//You notice nothing unusual.
                        }
                    }
                    else
                    {
                        from.SendLocalizedMessage(501001);//You cannot determain anything useful.
                    }
                }
                else if (target is ILockpickable p)
                {
                    if (skill < 41.0)
                    {
                        from.SendLocalizedMessage(501003); //You notice nothing unusual.
                    }
                    else if (from.CheckTargetSkill(SkillName.Forensics, p, 41.0, 100.0))
                    {
                        if (p.Picker != null)
                        {
                            from.SendLocalizedMessage(1042749, p.Picker.Name);//This lock was opened by ~1_PICKER_NAME~
                        }
                        else
                        {
                            from.SendLocalizedMessage(501003);//You notice nothing unusual.
                        }
                    }
                    else
                    {
                        from.SendLocalizedMessage(501001);//You cannot determain anything useful.
                    }
                }
                else if (target is Item item)
                {
                    if (item is IForensicTarget forensicTarget)
                    {
                        forensicTarget.OnForensicEval(from);
                    }
                    else if (skill < 41.0)
                    {
                        from.SendLocalizedMessage(501001);//You cannot determine anything useful.
                    }
                }
            }
        }
    }
}
