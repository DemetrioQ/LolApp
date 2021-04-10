using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LolApp.ViewModels
{
    public class SummonerDetailViewModel : BaseViewModel
    {
        public SummonerDetailViewModel(IPageDialogService pageDialogService) : base(pageDialogService)
        {
        }
    }
}
