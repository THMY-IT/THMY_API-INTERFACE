using RestSharp;
using THMY_API.Models;

namespace API_Interface.Components.Controllers;

public class RolePermissionApiController : BaseApiService
{
    public RolePermissionApiController(ILogger<RolePermissionApiController> logger, IConfiguration configuration) : base(logger, configuration)
    {
    }

    public async Task<RestResponse> GetAllRolePermissions()
    {
        var request = new RestRequest("RolePermission/all", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetAllRolePermissions response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> GetRolePermissionsByRole(int roleId)
    {
        var request = new RestRequest($"RolePermission/role/{roleId}", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetRolePermissionsByRole response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> GetRolePermissionsByPermission(int permissionId)
    {
        var request = new RestRequest($"RolePermission/permission/{permissionId}", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetRolePermissionsByPermission response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> CreateRolePermission(RolePermission rolePermission)
    {
        var request = new RestRequest("RolePermission", Method.Post);
        request.AddJsonBody(rolePermission);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("CreateRolePermission response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> DeleteRolePermission(RolePermission rolePermission)
    {
        var request = new RestRequest("RolePermission", Method.Delete);
        request.AddJsonBody(rolePermission);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("DeleteRolePermission response: {ResponseContent}", response.Content);
        return response;
    }
}

