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
        public Summoner Summoner { get; set; }
        public string SummonerName { get; set; }
       
        ISummonerApiService SummonerApiService;
        public ICommand GetSummonerCommand { get; }
        public ICommand TestCommand { get; }

        public SummonerViewModel(ISummonerApiService summonerService, IPageDialogService alertService) : base(alertService)
        {
            GetSummonerCommand = new DelegateCommand(GetSummonerAsync);
            SummonerApiService = summonerService;
        }

        private async void GetSummonerAsync()
        {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var summoner = await SummonerApiService.GetSummonerAsync(SummonerName);

                if (summoner == null)
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
