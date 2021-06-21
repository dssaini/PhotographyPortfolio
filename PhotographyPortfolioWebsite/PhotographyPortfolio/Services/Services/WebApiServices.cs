using Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class WebApiServices:IWebApiService
    {
        public async Task<TResponse> GetAsync<TResponse>(string endpoint, string token = "", bool applyToken = false)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiConstants.BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (applyToken)
                    {
                        // ADD TOKEN HERE
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiConstants.Bearer, token);
                    }
                    client.Timeout = new TimeSpan(0, 5, 0);
                    HttpResponseMessage Res = await client.GetAsync(endpoint);
                    var stringResponse = Res.Content.ReadAsStringAsync().Result;

                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var response = JsonConvert.DeserializeObject<TResponse>(stringResponse, settings);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, string endpoint, string token = "", bool applyToken = false)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiConstants.BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (applyToken)
                    {
                        // ADD TOKEN HERE
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiConstants.Bearer, token);
                    }
                    string jsonRequest = JsonConvert.SerializeObject(request);
                    StringContent jsonContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    HttpResponseMessage Res = await client.PostAsync(endpoint, jsonContent);
                    var stringResponse = Res.Content.ReadAsStringAsync().Result;

                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var response = JsonConvert.DeserializeObject<TResponse>(stringResponse, settings);
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<TResponse> DeleteAsync<TResponse>(string endpoint, string token = "", bool applyToken = false)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiConstants.BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (applyToken)
                    {
                        // ADD TOKEN HERE
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiConstants.Bearer, token);
                    }

                    HttpResponseMessage Res = await client.DeleteAsync(endpoint);
                    var stringResponse = Res.Content.ReadAsStringAsync().Result;

                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var response = JsonConvert.DeserializeObject<TResponse>(stringResponse, settings);
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
