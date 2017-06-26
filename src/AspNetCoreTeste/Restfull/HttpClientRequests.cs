using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTeste.Restfull
{
    public class HttpClientRequests
    {
        private CookieContainer _cookieContainer;
        public HttpClient client = new HttpClient();

        public HttpClientRequests(string url)
        {
            client.BaseAddress = new Uri(url);
            this._cookieContainer = new CookieContainer();
        }
        public async Task<string> SendRequestPost(string action,string json)
        {
            try
            {
                var response = await client.PostAsync(action, new StringContent(json, Encoding.UTF8, "application/json"));
                var contents = await response.Content.ReadAsStringAsync();
                return contents;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> SendRequestGet(string action)
        {
            try
            {
                var response = await client.GetAsync(action);
                var contents = await response.Content.ReadAsStringAsync();
                return contents;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
