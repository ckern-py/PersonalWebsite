using Microsoft.Extensions.Configuration;
using PersonalWebsite.Domain;
using System;
using System.Net.Http;

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
            _httpClient.DefaultRequestHeaders.Clear();

            _httpClient.DefaultRequestHeaders.Add("RequestingSystem", _configuration["REQUESTING_SYSTEM"]);
            _httpClient.DefaultRequestHeaders.Add("X-Environment-Header", _configuration["ENVIRONMENT_HEADER"]);

            _httpClient.GetAsync(_configuration["STATS_API_URI"] + pageName);
        }
    }
}
