using LolApp.Models;
using LolApp.Services;
using Prism.Commands;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LolApp.ViewModels
{
    class SummonerViewModel : BaseViewModel
    {
        private Summoner summoner;
        private string summonerName;

        public ICommand GetSummonerCommand { get; }

        public string SummonerName
        {
            get { return summonerName; }
            set { SetProperty(ref summonerName, value); }
        }

        ISummonerApiService summonerApiService;

        public Summoner Summoner
        {
            get { return summoner; }
            set { SetProperty(ref summoner, value); }
        }

        public SummonerViewModel(ISummonerApiService summonerService, IPageDialogService alertService) : base(alertService)
        {
            //summonerApiService = new SummonerApiService();
            GetSummonerCommand = new DelegateCommand(GetSummonerAsync);
            summonerApiService = summonerService;
        }

        private async void GetSummonerAsync()
        {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var summoner = await summonerApiService.GetSummonerAsync(SummonerName);

                if(summoner == null)
                {
                    await AlertService.DisplayAlertAsync("Summoner not found", "No such summoner was found, please try another one.", "Ok");
                }

                Summoner = summoner;
            }
            else
            {
                await AlertService.DisplayAlertAsync("No internet connection", "No internet connection detected", "ok");
            }
            

        }
    }
}
