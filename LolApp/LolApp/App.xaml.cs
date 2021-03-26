using LolApp.Services;
using LolApp.ViewModels;
using LolApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace LolApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer plataformInitializer = null) : base(plataformInitializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"/{Pages.MainTabbedPage}");   
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISerializerService, SerializerService>();
            containerRegistry.Register<IRankingApiService, RankingApiService>();
            containerRegistry.RegisterForNavigation<MainTabbedPage>(Pages.MainTabbedPage);
            containerRegistry.RegisterForNavigation<RankingPage, RankingViewModel>(Pages.RankingPage);

        }
    }
}
