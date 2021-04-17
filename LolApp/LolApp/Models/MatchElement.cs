using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LolApp.Models
{
    public class MatchElement : BaseModel
    {
        public string PlatformId { get; set; }
        public int GameId { get; set; }
        public int Champion { get; set; }
        public int Queue { get; set; }
        public int Season { get; set; }
        public object Timestamp { get; set; }
        public string Role { get; set; }
        public string Lane { get; set; }
    }

    public class MatchList : BaseModel
    {
        public ObservableCollection<MatchElement> Matches { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int TotalGames { get; set; }
    }
}
