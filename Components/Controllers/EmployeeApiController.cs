using RestSharp;
using InternalSystem_ModelContext.Models.SQLite;

namespace API_Interface.Components.Controllers;

public class EmployeeApiController : BaseApiService
{
    public EmployeeApiController(ILogger<EmployeeApiController> logger, IConfiguration configuration) : base(logger, configuration)
    {
    }

    public async Task<RestResponse> GetAllEmployees()
    {
        var request = new RestRequest("user/all", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        if (response != null)
        {
            // Safe logging with null check
            var contentPreview = response.Content?.Length > 100
                ? response.Content.Substring(0, 200)
                : response.Content ?? "No content";
            _logger.LogInformation("GetAllEmployees response: {ResponseContent}", contentPreview);
            return response;
        }

        return null;
    }
}

