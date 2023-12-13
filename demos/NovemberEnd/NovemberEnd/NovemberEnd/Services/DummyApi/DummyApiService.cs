using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NovemberEnd.Shared;

namespace NovemberEnd.Services.DummyApi;

public class DummyApiService : IDummyApiService
{
    private readonly IHttpClientFactory httpClientFactory;

    public DummyApiService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }
    
    public async Task<DummyApiResult<IEnumerable<DummyApiEmployee>>> GetAllEmployeesAsync()
    {
        try
        {
            var httpClient = this.httpClientFactory.CreateClient(HttpClientsConstants.DummyApiKey);
            var httpResponseString = await httpClient.GetStringAsync("/api/v1/employees");
            return JsonConvert.DeserializeObject<DummyApiResult<IEnumerable<DummyApiEmployee>>>(httpResponseString);
        }
        catch (Exception e)
        {
            throw new DummyApiException(e.Message);
        }
    }

    public async Task<DummyApiResult<DummyApiEmployee>> GetSingleEmployeeAsync(long id)
    {
        try
        {
            var httpClient = this.httpClientFactory.CreateClient(HttpClientsConstants.DummyApiKey);
            var httpResponseString = await httpClient.GetStringAsync($"/api/v1/employee/{id}");
            return JsonConvert.DeserializeObject<DummyApiResult<DummyApiEmployee>>(httpResponseString);
        }
        catch (Exception e)
        {
            throw new DummyApiException(e.Message);
        }
    }

    public async Task<DummyApiResult<DummyApiEmployee>> CreateAsync(DummyApiCreateEmployee employee)
    {
        throw new System.NotImplementedException();
    }
}