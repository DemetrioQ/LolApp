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
            await NavigationService.NavigateAsync($"/{Config.MatchTabbedPage}");   
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILolIconsApiService, LolIconsApiService>();
            containerRegistry.Register<ISummonerApiService, SummonerApiService>();
            containerRegistry.Register<IRankingApiService, RankingApiService>();
            containerRegistry.Register<IStatusApiService, StatusApiService>();
            containerRegistry.Register<ISerializerService, SerializerService>();

            containerRegistry.RegisterForNavigation<MainTabbedPage>(Config.MainTabbedPage);
            containerRegistry.RegisterForNavigation<MatchTabbedPage, MatchViewModel>(Config.MatchTabbedPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisTabbedPage, MatchViewModel>(Config.MatchAnalysisTabbedPage);

            containerRegistry.RegisterForNavigation<RankingPage, RankingViewModel>(Config.RankingPage);
            containerRegistry.RegisterForNavigation<SummonerPage, SummonerViewModel>(Config.SummonerPage);
            containerRegistry.RegisterForNavigation<GrandMasterPage, GrandMasterViewModel>(Config.GrandMasterPage);

            containerRegistry.RegisterForNavigation<MatchTotalPage, MatchViewModel>(Config.MatchTotalPage);
            containerRegistry.RegisterForNavigation<MatchBuildPage, MatchViewModel>(Config.MatchBuildPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisChampionKillPage, MatchViewModel>(Config.MatchAnalysisChampionKillsPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisGoldPage, MatchViewModel>(Config.MatchAnalysisGoldPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisDamageDealtPage, MatchViewModel>(Config.MatchAnalysisDamageDealtPage);
        }
    }
}
