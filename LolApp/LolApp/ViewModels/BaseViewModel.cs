using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LolApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        protected IPageDialogService AlertService { get; }

        protected BaseViewModel(IPageDialogService pageDialogService)
        {
            AlertService = pageDialogService;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
