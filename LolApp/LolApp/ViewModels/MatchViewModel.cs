using Android.App;
using LolApp.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LolApp.ViewModels
{
    public class MatchViewModel : BaseViewModel, IInitialize
    {
        public Match Match { get; set; }
        public MatchViewModel(IPageDialogService alertService) : base(alertService)
        {
        }

        public void Initialize(INavigationParameters parameters)
        {
            StreamReader strm = new StreamReader(Android.App.Application.Context.Assets.Open("MatchTest.json"));
            var response = strm.ReadToEnd();

            Match = JsonConvert.DeserializeObject<Match>(response);

            foreach (var participant in Match.Participants)
            {
                participant.SummonerName = Match.ParticipantIdentities.Find(x => x.ParticipantId == participant.ParticipantId).Player.SummonerName;
            }

            /*if (parameters.TryGetValue(Config.MatchParam, out Match match))
            {
                Match = match;

                foreach (var participant in Match.Participants)
                {
                    participant.SummonerName = Match.ParticipantIdentities.Find(x => x.ParticipantId == participant.ParticipantId).Player.SummonerName;
                }
            }*/
        }
    }
}
