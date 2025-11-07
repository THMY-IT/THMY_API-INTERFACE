using RestSharp;
using THMY_API.Models;

namespace API_Interface.Components.Controllers;

public class RoleApiController : BaseApiService
{
    public RoleApiController(ILogger<RoleApiController> logger, IConfiguration configuration) : base(logger, configuration)
    {
    }

    public async Task<RestResponse> GetAllRoles()
    {
        var request = new RestRequest("Role/all", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetAllRoles response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> GetRole(int id)
    {
        var request = new RestRequest($"Role/{id}", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetRole response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> CreateRole(Role role)
    {
        var request = new RestRequest("Role", Method.Post);
        request.AddJsonBody(role);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("CreateRole response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> UpdateRole(int id, Role role)
    {
        var request = new RestRequest($"Role/{id}", Method.Put);
        request.AddJsonBody(role);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("UpdateRole response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> DeleteRole(int id)
    {
        var request = new RestRequest($"Role/{id}", Method.Delete);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("DeleteRole response: {ResponseContent}", response.Content);
        return response;
    }
}

