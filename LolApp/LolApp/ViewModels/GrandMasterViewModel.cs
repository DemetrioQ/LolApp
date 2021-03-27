using LolApp.Models;
using LolApp.Services;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Entry = LolApp.Models.Entry;

namespace LolApp.ViewModels
{
    public class GrandMasterViewModel : BaseViewModel
    {
        private Entry entries;
        private Status status;

        public Entry Entries
        {
            get { return entries; }
            set { SetProperty(ref entries, value); }
        }
        public Status Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }
        IStatusApiService StatusApiService { get; }


        public GrandMasterViewModel(IStatusApiService statusApiService, IPageDialogService alertService) : base(alertService)
        {
            StatusApiService = statusApiService;
            Status = new Status();
            GetStatus();

        }

        private async void GetStatus()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                Status = await StatusApiService.GetStatusAsync();
                Entries = Status.Entries[0];

            }
            else
            {
                // Alert
                await AlertService.DisplayAlertAsync("No connection :( ", "please try again when your are conected.", "Ok", null);
            }

        }
    }
}
