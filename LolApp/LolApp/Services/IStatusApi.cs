using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public interface IStatusApi
    {
        [Get("/RANKED_SOLO_5x5?api_key={key}")]
        Task<HttpResponseMessage> GetStatusAsync(string key);   
    }
}
