using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PersonalWebsite.Domain;
using PersonalWebsite.Models;
using System;
using System.Net.Http;
using System.Text;

namespace PersonalWebsite.Data
{
    public class StatsAPI : IStatsAPI
    {
        private readonly IConfiguration _configuration;
        private HttpClient _httpClient;

        public StatsAPI(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public void RecordPageVisit(string pageName)
        {
            StatsAPIBody reqBody = new StatsAPIBody()
            {
                PageName = pageName,
                VisitDT = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                RequestingSystem = _configuration["REQUESTING_SYSTEM"]
            };

            _httpClient.DefaultRequestHeaders.Clear();

            _httpClient.DefaultRequestHeaders.Add("X-Environment-Header", _configuration["ENVIRONMENT_HEADER"]);

            HttpContent body = new StringContent(JsonConvert.SerializeObject(reqBody), Encoding.Default, "application/json");

            _httpClient.PostAsync(_configuration["STATS_API_URI"], body);
        }
    }
}
