using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.User;
using TrafficManagementSystem.Application.Wrappers;
using TrafficManagementSystem.UI.Infrastructure.Authentication;
using TrafficManagementSystem.UI.Infrastructure.Constants;

namespace TrafficManagementSystem.UI.Infrastructure.Managers
{
    public interface IAuthenticationManager
    {
        Task<IResponse> Login(AuthenticationRequest request);
        Task Logout();
        Task<ClaimsPrincipal> CurrentUser();
    }

    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;

        public AuthenticationManager(
            HttpClient httpClient,
            ILocalStorageService storage,
            AuthenticationStateProvider authenticationStateProvider,
            NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _localStorage = storage;
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager=navigationManager;
        }

        public async Task<ClaimsPrincipal> CurrentUser()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return state.User;
        }

        public async Task<IResponse> Login(AuthenticationRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(Endpoints.Users.Login, request);
            if (response.IsSuccessStatusCode)
            {
                var authenticationResponse = await response.Content.ReadFromJsonAsync<Response<AuthenticationResponse>>();
                await ((AppStateProvider)_authenticationStateProvider).NotifyAuthenticatedAsync(authenticationResponse.Data);

                return await Response.SuccessAsync();
            }
            else
            {
                var authenticationResponse = await response.Content.ReadFromJsonAsync<Response<string>>();
                return await Response.FailAsync(authenticationResponse.Messages);
            }
        }

        public async Task Logout()
        {
            await ((AppStateProvider)_authenticationStateProvider).NotifyLogoutAsync();
            _navigationManager.NavigateTo("/");
        }

       


    }
}
