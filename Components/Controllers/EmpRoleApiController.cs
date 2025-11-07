using RestSharp;
using THMY_API.Models;

namespace API_Interface.Components.Controllers;

public class EmpRoleApiController : BaseApiService
{
    public EmpRoleApiController(ILogger<EmpRoleApiController> logger, IConfiguration configuration) : base(logger, configuration)
    {
    }

    public async Task<RestResponse> GetAllEmpRoles()
    {
        var request = new RestRequest("EmpRole/all", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetAllEmpRoles response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> GetEmpRolesByEmployee(string empId)
    {
        var request = new RestRequest($"EmpRole/employee/{empId}", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetEmpRolesByEmployee response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> GetEmpRolesByRole(int roleId)
    {
        var request = new RestRequest($"EmpRole/role/{roleId}", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetEmpRolesByRole response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> CreateEmpRole(EmpRole empRole)
    {
        var request = new RestRequest("EmpRole", Method.Post);
        request.AddJsonBody(empRole);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("CreateEmpRole response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> DeleteEmpRole(EmpRole empRole)
    {
        var request = new RestRequest("EmpRole", Method.Delete);
        request.AddJsonBody(empRole);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("DeleteEmpRole response: {ResponseContent}", response.Content);
        return response;
    }
}

