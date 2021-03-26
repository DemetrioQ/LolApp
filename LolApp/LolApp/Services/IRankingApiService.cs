using LolApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public interface IRankingApiService
    {
        Task<ObservableCollection<Ranking>> GetRankingAync(string queue, string tier, string division);
    }
}