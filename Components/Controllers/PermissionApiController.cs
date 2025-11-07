using RestSharp;
using THMY_API.Models;

namespace API_Interface.Components.Controllers;

public class PermissionApiController : BaseApiService
{
    public PermissionApiController(ILogger<PermissionApiController> logger, IConfiguration configuration) : base(logger, configuration)
    {
    }

    public async Task<RestResponse> GetAllPermissions()
    {
        var request = new RestRequest("Permission/all", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetAllPermissions response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> GetPermission(int id)
    {
        var request = new RestRequest($"Permission/{id}", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetPermission response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> GetPermissionsBySystem(int systemId)
    {
        var request = new RestRequest($"Permission/system/{systemId}", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetPermissionsBySystem response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> CreatePermission(Permission permission)
    {
        var request = new RestRequest("Permission", Method.Post);
        request.AddJsonBody(permission);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("CreatePermission response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> UpdatePermission(int id, Permission permission)
    {
        var request = new RestRequest($"Permission/{id}", Method.Put);
        request.AddJsonBody(permission);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("UpdatePermission response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> DeletePermission(int id)
    {
        var request = new RestRequest($"Permission/{id}", Method.Delete);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("DeletePermission response: {ResponseContent}", response.Content);
        return response;
    }
}

