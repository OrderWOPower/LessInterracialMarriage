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
            if (firstHero.MapFaction.Culture != secondHero.MapFaction.Culture)
            {
                List<Hero> lords = firstHero.MapFaction.Lords.ToList();
                List<Hero> lords2 = secondHero.MapFaction.Lords.ToList();
                if (lords.Count(lord => lord.Culture != firstHero.MapFaction.Culture) >= lords.Count / 10 || lords2.Count(lord => lord.Culture != secondHero.MapFaction.Culture) >= lords2.Count / 10)
                {
                    return false;
                }
            }
            return base.IsCoupleSuitableForMarriage(firstHero, secondHero);
        }
    }
}
