using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Gov.News.Search.Reset.Service
{
    public class NewsSearchResetHostedService : IHostedService
    {
        private Timer _timer;
        private static readonly HttpClient _client = new HttpClient();
        private readonly ILogger<NewsSearchResetHostedService> _logger;
        private readonly IConfiguration _config;

        public NewsSearchResetHostedService(
            ILogger<NewsSearchResetHostedService> logger,
            IConfiguration config
            )
        {
            _logger = logger;
            _config = config;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(ResetSearchService, null, 0, 1000 * 60 * 60); // every hour
            return Task.CompletedTask;
        }

        async void ResetSearchService(object state)
        {
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _config.GetValue<string>("Token"));

                var response = await _client.GetStringAsync(_config.GetValue<string>("SearchServiceUrl"));
                _logger.LogInformation($"Search service reset at {DateTime.Now.ToLongTimeString()}: {response}");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
