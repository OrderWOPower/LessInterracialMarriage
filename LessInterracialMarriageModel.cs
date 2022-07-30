using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace LessInterracialMarriage
{
    public class LessInterracialMarriageModel : DefaultMarriageModel
    {
        // If 10% or more of the lords in either hero's faction is of a foreign culture, stop the couple from marrying.
        public override bool IsCoupleSuitableForMarriage(Hero firstHero, Hero secondHero)
        {
            if (firstHero.MapFaction != null && secondHero.MapFaction != null)
            {
                CultureObject culture = firstHero.MapFaction.Culture;
                CultureObject culture2 = secondHero.MapFaction.Culture;
                if (culture != culture2)
                {
                    List<Hero> lords = firstHero.MapFaction.Lords.ToList();
                    List<Hero> lords2 = secondHero.MapFaction.Lords.ToList();
                    if (lords.Count(lord => lord.Culture != culture) >= lords.Count / 10 || lords2.Count(lord => lord.Culture != culture2) >= lords2.Count / 10)
                    {
                        return false;
                    }
                }
            }
            return base.IsCoupleSuitableForMarriage(firstHero, secondHero);
        }
    }
}
