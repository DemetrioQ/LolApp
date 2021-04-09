using LolApp.Models;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
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
            if (parameters.TryGetValue(Config.MatchParam, out Match match))
            {
                Match = match;
            }
        }
    }
}
