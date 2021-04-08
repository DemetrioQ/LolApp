﻿using LolApp.Models;
using LolApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace LolApp.ViewModels
{
    public class RankingViewModel : BaseViewModel
    {
        public ObservableCollection<Ranking> Ranking { get; set; }

        public string Queue { get; set; }

        public string Tier { get; set; }

        public string Division { get; set; }

        public bool IsBusy { get; set; }

        IRankingApiService _rankingApiService { get; }
        public ICommand GetCommand { get; }
        public bool IsNotBusy => !IsBusy;

        public RankingViewModel(IRankingApiService rankingApiService, IPageDialogService alertService) : base(alertService)
        {
            _rankingApiService = rankingApiService;
            GetCommand = new DelegateCommand(LoadRanking);
        }

        public async void LoadRanking()
        {
            if (string.IsNullOrEmpty(Queue) || string.IsNullOrEmpty(Tier) || string.IsNullOrEmpty(Division))
            {
                await AlertService.DisplayAlertAsync("Error", "You must select a queue, a tier and a division", "Ok", null);
            }
            else
            {
                IsBusy = true;
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {

                    Ranking = await _rankingApiService.GetRankingAync(Queue, Tier, Division);
                }
                else
                {
                    await AlertService.DisplayAlertAsync("No internet connection", "No internet connection detected", "ok", null);
                }

                IsBusy = false;
            }

        }

    }
}
