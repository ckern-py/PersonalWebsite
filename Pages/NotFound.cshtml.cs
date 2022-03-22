using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PersonalWebsite.Data;
using PersonalWebsite.Domain;

namespace PersonalWebsite.Pages
{
    public class NotFoundModel : PageModel
    {
        private readonly ILogger<NotFoundModel> _logger;

        private readonly IConfiguration _config;

        public NotFoundModel(ILogger<NotFoundModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {
            IStatsAPI statsAPI = new StatsAPI(_config);
            statsAPI.RecordPageVisit("NotFound");
        }
    }
}