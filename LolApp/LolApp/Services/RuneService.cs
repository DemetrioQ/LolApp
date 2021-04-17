using LolApp.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace LolApp.Services
{
    public class RuneService : IRuneService
    {
        private static RuneService runeService = new RuneService();

        public List<RuneRoot> GetRunes()
        {
            var url = Config.RuneApiUrl;
            WebClient client = new WebClient();

            var download = client.DownloadString(url);
            List<RuneRoot> runes = JsonSerializer.Deserialize<List<RuneRoot>>(download);
            return runes;
        }
        public void GetSlots(Participant participant)
        {

            List<RuneRoot> runeRoots = runeService.GetRunes();
            
            participant.MainRuneRoot = (from runeroot in runeRoots
                                     where runeroot.Id == participant.Stats.PerkPrimaryStyle
                                     select runeroot).First();


            participant.SecondaryRuneRoot = (from runeroot in runeRoots
                                             where runeroot.Id == participant.Stats.PerkSubStyle
                                         select runeroot).First();

           participant.MainRunes = new ObservableCollection<Rune>(from slots in participant.MainRuneRoot.Slots
                                                   from rune in slots.Runes
                                                   where rune.Id == participant.Stats.Perk0 || rune.Id == participant.Stats.Perk1 || rune.Id == participant.Stats.Perk2 || rune.Id == participant.Stats.Perk3
                                                   select rune);

            participant.SecondaryRunes = new ObservableCollection<Rune>(from slots in participant.SecondaryRuneRoot.Slots
                                                              from rune in slots.Runes
                                                              where rune.Id == participant.Stats.Perk4|| rune.Id == participant.Stats.Perk5
                                                              select rune);
        }



    }
}
