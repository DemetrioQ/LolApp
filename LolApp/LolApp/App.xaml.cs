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
            //await NavigationService.NavigateAsync($"/{NavigationConstant.SummonerPage}");   
            StreamReader strm = new StreamReader(Android.App.Application.Context.Assets.Open("MatchTest.json"));
            var response = strm.ReadToEnd();

            
            Match match = JsonConvert.DeserializeObject<Match>(response);
            strm = new StreamReader(Android.App.Application.Context.Assets.Open("PlayerTest.json"));
            response = strm.ReadToEnd();
            Summoner summoner = JsonConvert.DeserializeObject<Summoner>(response);
            var parameters = new NavigationParameters();
            parameters.Add(NavigationConstant.MatchParam, match);
            parameters.Add(NavigationConstant.SummonerParam, summoner);

            //MatchTabbedPage

            await NavigationService.NavigateAsync($"{NavigationConstant.NavigationPage}/{NavigationConstant.MatchTabbedPage}", parameters);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILolIconsApiService, LolIconsApiService>();
            containerRegistry.Register<ISummonerLeagueApiService, SummonerLeagueApiService>();
            containerRegistry.Register<ISummonerApiService, SummonerApiService>();
            containerRegistry.Register<IRankingApiService, RankingApiService>();
            containerRegistry.Register<ISerializerService, SerializerService>();
            containerRegistry.RegisterSingleton<IChampionService, ChampionService>();
            containerRegistry.RegisterSingleton<IRuneService, RuneService>();

            containerRegistry.RegisterForNavigation<NavigationPage>(NavigationConstant.NavigationPage);
            containerRegistry.RegisterForNavigation<MainTabbedPage>(NavigationConstant.MainTabbedPage);
            containerRegistry.RegisterForNavigation<MatchTabbedPage, MatchViewModel>(NavigationConstant.MatchTabbedPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisTabbedPage>(NavigationConstant.MatchAnalysisTabbedPage);

            containerRegistry.RegisterForNavigation<RankingPage, RankingViewModel>(NavigationConstant.RankingPage);
            containerRegistry.RegisterForNavigation<SummonerPage, SummonerViewModel>(NavigationConstant.SummonerPage);
            containerRegistry.RegisterForNavigation<SummonerDetailPage, SummonerDetailViewModel>(NavigationConstant.SummonerDetailPage);

            containerRegistry.RegisterForNavigation<MatchTotalPage>(NavigationConstant.MatchTotalPage);
            containerRegistry.RegisterForNavigation<MatchBuildPage>(NavigationConstant.MatchBuildPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisChampionKillPage>(NavigationConstant.MatchAnalysisChampionKillsPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisGoldPage>(NavigationConstant.MatchAnalysisGoldPage);
            containerRegistry.RegisterForNavigation<MatchAnalysisDamageDealtPage>(NavigationConstant.MatchAnalysisDamageDealtPage);
        }
    }
}
