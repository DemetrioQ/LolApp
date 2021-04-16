using LolApp.Models;
using LolApp.Services;
using LolApp.ViewModels;
using LolApp.Views;
using Newtonsoft.Json;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using System.IO;
using Xamarin.Forms;

namespace LolApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer plataformInitializer = null) : base(plataformInitializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            //await NavigationService.NavigateAsync($"/{Config.SummonerPage}");   
            StreamReader strm = new StreamReader(Android.App.Application.Context.Assets.Open("MatchTest.json"));
            var response = strm.ReadToEnd();

            
            Match match = JsonConvert.DeserializeObject<Match>(response);
            strm = new StreamReader(Android.App.Application.Context.Assets.Open("PlayerTest.json"));
            response = strm.ReadToEnd();
            Summoner summoner = JsonConvert.DeserializeObject<Summoner>(response);
            var parameters = new NavigationParameters();
            parameters.Add(Config.MatchParam, match);
            parameters.Add(Config.SummonerParam, summoner);

            await NavigationService.NavigateAsync($"{Config.MatchTabbedPage}", parameters);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILolIconsApiService, LolIconsApiService>();
            containerRegistry.Register<ISummonerApiService, SummonerApiService>();
            containerRegistry.Register<IRankingApiService, RankingApiService>();
            containerRegistry.Register<IStatusApiService, StatusApiService>();
            containerRegistry.Register<ISerializerService, SerializerService>();
            containerRegistry.RegisterSingleton<IChampionService, ChampionService>();

            containerRegistry.RegisterForNavigation<NavigationPage>(Config.NavigationPage);
            containerRegistry.RegisterForNavigation<MainTabbedPage>(Config.MainTabbedPage);
            containerRegistry.RegisterForNavigation<MatchTabbedPage, MatchViewModel>(Config.MatchTabbedPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisTabbedPage>(Config.MatchAnalysisTabbedPage);

            containerRegistry.RegisterForNavigation<RankingPage, RankingViewModel>(Config.RankingPage);
            containerRegistry.RegisterForNavigation<SummonerPage, SummonerViewModel>(Config.SummonerPage);
            containerRegistry.RegisterForNavigation<SummonerDetailPage, SummonerDetailViewModel>(Config.SummonerDetailPage);
            containerRegistry.RegisterForNavigation<GrandMasterPage, GrandMasterViewModel>(Config.GrandMasterPage);

            containerRegistry.RegisterForNavigation<MatchTotalPage>(Config.MatchTotalPage);
            containerRegistry.RegisterForNavigation<MatchBuildPage>(Config.MatchBuildPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisChampionKillPage>(Config.MatchAnalysisChampionKillsPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisGoldPage>(Config.MatchAnalysisGoldPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisDamageDealtPage>(Config.MatchAnalysisDamageDealtPage);
        }
    }
}
