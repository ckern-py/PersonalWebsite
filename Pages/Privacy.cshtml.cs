using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PersonalWebsite.Data;
using PersonalWebsite.Domain;

namespace PersonalWebsite.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        private readonly IConfiguration _config;

        public PrivacyModel(ILogger<PrivacyModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {
            IStatsAPI statsAPI = new StatsAPI(_config);
            statsAPI.RecordPageVisit("Privacy");
        }
    }
}