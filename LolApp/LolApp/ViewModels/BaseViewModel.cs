using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LolApp.ViewModels
{
    public abstract class BaseViewModel : BindableBase
    {

        public abstract string Title { get; set; }

        protected INavigationService NavigationService { get; }
        protected IPageDialogService AlertService { get; }

        protected BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            AlertService = pageDialogService;
        }
    }
}
