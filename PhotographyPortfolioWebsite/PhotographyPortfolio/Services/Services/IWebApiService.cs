using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IWebApiService
    {
        Task<TResponse> GetAsync<TResponse>(string endpoint, string token = "", bool applyToken = false);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, string endpoint, string token = "", bool applyToken = false);

        //TResponse PutAsync<TRequest, TResponse>(TRequest request, string endpoint, string token = "", bool applyToken = false);

        Task<TResponse> DeleteAsync<TResponse>(string endpoint, string token = "", bool applyToken = false);
        
    }
}
