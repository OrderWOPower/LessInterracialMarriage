using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace LessInterracialMarriage
{
    public class LessInterracialMarriageSubModule : MBSubModuleBase
    {
        // This mod stops nobles of different cultures from marrying if their factions have too many foreign nobles.
        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            if (game.GameType is Campaign)
            {
                CampaignGameStarter campaignStarter = (CampaignGameStarter)gameStarter;
                campaignStarter.AddModel(new LessInterracialMarriageModel());
            }
        }
    }
}
