using RestSharp;
using THMY_API.Models;
namespace API_Interface.Components.Controllers;

public class APIStorageApiController : BaseApiService
{
    public APIStorageApiController(ILogger<APIStorageApiController> logger, IConfiguration configuration) : base(logger, configuration)
    {
    }

    public async Task<RestResponse> GetAllAPIStorages()
    {
        var request = new RestRequest("APIStorage/all", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetAllAPIStorages response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> GetAPIStorage(int id)
    {
        var request = new RestRequest($"APIStorage/{id}", Method.Get);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("GetAPIStorage response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> CreateAPIStorage(APIStorage apiStorage)
    {
        var request = new RestRequest("APIStorage", Method.Post);
        request.AddJsonBody(apiStorage);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("CreateAPIStorage response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> UpdateAPIStorage(int id, APIStorage apiStorage)
    {
        var request = new RestRequest($"APIStorage/{id}", Method.Put);
        request.AddJsonBody(apiStorage);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("UpdateAPIStorage response: {ResponseContent}", response.Content);
        return response;
    }

    public async Task<RestResponse> DeleteAPIStorage(int id)
    {
        var request = new RestRequest($"APIStorage/{id}", Method.Delete);
        RestResponse response = await _client.ExecuteAsync(request);
        _logger.LogInformation("DeleteAPIStorage response: {ResponseContent}", response.Content);
        return response;
    }
}

