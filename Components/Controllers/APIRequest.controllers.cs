using THMY_API.Models;
using RestSharp;
namespace API_Interface.Components.Controllers;
public class APIRequestController
{
    private readonly RestClient _client;
    private readonly ILogger<APIRequestController> _logger;
    protected readonly IConfiguration _configuration;
    public APIRequestController(ILogger<APIRequestController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        RestClientOptions options;


        options = new RestClientOptions(_configuration["AppSettings:API_BASE_URL"])
        {
            ThrowOnAnyError = false,
            Timeout = TimeSpan.FromSeconds(10) // optional
        };

        _client = new RestClient(options);

        if(_client != null)
        {
            Console.WriteLine("Client initialized successfully.");
        }

        _client.AddDefaultHeader("Application-Name", "API-Interface");
        _client.AddDefaultHeader("API-Key", "pKzYyrGbIDLTLBRtB29El3I70Tehes/0KFMtiqqzQZs=");
        _client.AddDefaultHeader("Content-Type", "application/json");
    }

    public async Task<RestResponse> GetAllUsers()
    {
        var request = new RestRequest("User/all", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("Login response: {ResponseContent}", response.Content);
        return response;
    }

}