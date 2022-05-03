using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using TrafficManagementSystem.Application.DTOs.User;
using TrafficManagementSystem.UI.Infrastructure.Constants;

namespace TrafficManagementSystem.UI.Infrastructure.Authentication
{
    public class AppStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackbar;
       // private readonly ApplicationStateManager _applicationStateManager;

        public AppStateProvider(
            ILocalStorageService localStorage,
            HttpClient httpClient,
            ISnackbar snackbar/*, ApplicationStateManager applicationStateManager*/)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
            _snackbar = snackbar;
            //_applicationStateManager=applicationStateManager;
        }

        //public string CurrentUsername { get; private set; }
        public static AuthenticationState Anonymous { get; set; } = new(new ClaimsPrincipal(new ClaimsPrincipal()));

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsStringAsync(AppConstants.Storage.AuthToken);
            if (string.IsNullOrEmpty(token))
            {
                return Anonymous;
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(GetClaims(token), "jwt"));
           // _applicationStateManager.CurrentUsername = claimsPrincipal.FindFirst("username")?.Value;
            return new AuthenticationState(claimsPrincipal);
        }

        public async Task NotifyAuthenticatedAsync(AuthenticationResponse response)
        {
            await _localStorage.SetItemAsync(AppConstants.Storage.AuthToken, response.JWToken);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task NotifyLogoutAsync()
        {
            await _localStorage.ClearAsync();
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }

        public async Task ValidateSession()
        {
            var currentAuthState = await GetAuthenticationStateAsync();
            if (currentAuthState == Anonymous)
            {
                _snackbar.Add(AppConstants.ErrorMessages.SessionTimeout, Severity.Error);
                await NotifyLogoutAsync();
            }
        }


        private static List<Claim> GetClaims(string jwtToken)
        {
            if (string.IsNullOrEmpty(jwtToken))
                return new List<Claim>();
            string payload = jwtToken.Split(".")[1];
            byte[] jsonBytes = ParseBase64StringWithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            List<Claim> claims = keyValuePairs?.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())).ToList();
            return claims;
        }

        private static byte[] ParseBase64StringWithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
