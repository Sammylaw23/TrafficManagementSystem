using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.Driver;
using TrafficManagementSystem.Application.Wrappers;
using TrafficManagementSystem.UI.Infrastructure.Constants;

namespace TrafficManagementSystem.UI.Infrastructure.Managers
{
    public interface IDriverManager
    {
        Task<Response<DriverDto>> AddDriver(NewDriverRequest request);
        Task<Response<IEnumerable<DriverDto>>> GetDrivers();
        Task<Response<DriverDto>> GetDriver(Guid id);
        Task DeleteDriver(Guid id);
    }
    public class DriverManager : IDriverManager
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DriverManager> _logger;
        private readonly ISnackbar _snackbar;
        //private readonly IStringLocalizer<DriverManager> _localizer;

        public DriverManager(HttpClient httpClient, ILogger<DriverManager> logger, ISnackbar snackbar /*,IStringLocalizer<DriverManager> localizer*/)
        {
            _httpClient = httpClient;
            _logger = logger;
            _snackbar = snackbar;
            //_localizer = localizer;
        }

        public async Task<Response<DriverDto>> AddDriver(NewDriverRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(Endpoints.DriverEndpoints.AddDriver, request);
            return await response.Content.ReadFromJsonAsync<Response<DriverDto>>();
        }

        public Task DeleteDriver(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<DriverDto>> GetDriver(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<DriverDto>>> GetDrivers()
        {
            throw new NotImplementedException();
        }


      
      
       
        //public async Task<IResponse> Delete(Guid id)
        //{
        //    var response = await _httpClient.DeleteAsync(CurrencyEndpoints.DeleteCurrency(id));
        //    if (response.IsSuccessStatusCode)
        //        return await Response.SuccessAsync();
        //    var content = await response.Content.ReadFromJsonAsync<Response<string>>();
        //    return await Response.FailAsync(content.Messages);
        //}

        //public async Task<List<CurrencyDto>> GetCurrencies()
        //{
        //    try
        //    {
        //        return (await _httpClient.GetFromJsonAsync<Response<List<CurrencyDto>>>(CurrencyEndpoints.GetCurrencies)).Data;
        //    }
        //    catch (Exception ex)
        //    {
        //        _snackbar.Add(_localizer["Failed to fetch currencies."], Severity.Error);
        //        _logger.LogError(ex.Format());
        //        return new List<CurrencyDto>();
        //    }
        //}
    }
}
