using LolApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LolApp.Services
{
    public interface IRuneService
    {
        List<RuneRoot> GetRunes();
        void GetSlots(Participant participant);
    }
}
