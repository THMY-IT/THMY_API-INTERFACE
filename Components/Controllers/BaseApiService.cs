using Microsoft.Extensions.Options;
using RestSharp;

namespace API_Interface.Components.Controllers;

public abstract class BaseApiService
{

    protected readonly RestClient _client;
    protected readonly ILogger _logger;
    protected readonly IConfiguration _configuration;

    protected BaseApiService(ILogger logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;

        Console.WriteLine(_configuration["AppSettings:API_BASE_URL"]);

        var options = new RestClientOptions(_configuration["AppSettings:API_BASE_URL"])
        {
            ThrowOnAnyError = false,
            Timeout = TimeSpan.FromSeconds(10) // optional
        };

        _client = new RestClient(options);


        _client.AddDefaultHeader("Application-Name", "API-Interface");
        _client.AddDefaultHeader("API-Key", "pKzYyrGbIDLTLBRtB29El3I70Tehes/0KFMtiqqzQZs=");
        _client.AddDefaultHeader("Content-Type", "application/json");
    }
}

