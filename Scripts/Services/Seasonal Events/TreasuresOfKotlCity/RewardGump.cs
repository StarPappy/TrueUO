using Server.Engines.Points;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.TreasuresOfKotlCity
{
    public class KotlCityRewardGump : BaseRewardGump
    {
        public KotlCityRewardGump(Mobile owner, PlayerMobile user)
            : base(owner, user, KotlCityRewards.Rewards, 1156988)
        {
        }

        public override int GetYOffset(int id)
        {
            return 15;
        }

        public override double GetPoints(Mobile m)
        {
            return PointsSystem.TreasuresOfKotlCity.GetPoints(m);
        }

        public override void OnConfirmed(CollectionItem citem, int index)
        {
            Item item = null;

            if (citem.Type == typeof(TreasuresOfKotlRewardDeed))
            {
                item = new TreasuresOfKotlRewardDeed(citem.Tooltip);
            }

            if (item != null)
            {
                if (User.Backpack == null || !User.Backpack.TryDropItem(User, item, false))
                {
                    User.SendLocalizedMessage(1074361); // The reward could not be given.  Make sure you have room in your pack.
                    item.Delete();
                }
                else
                {
                    User.SendLocalizedMessage(1073621); // Your reward has been placed in your backpack.
                    User.PlaySound(0x5A7);
                }
            }
            else
            {
                base.OnConfirmed(citem, index);
            }

            PointsSystem.TreasuresOfKotlCity.DeductPoints(User, citem.Points);
        }
    }
}
