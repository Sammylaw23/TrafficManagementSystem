using MudBlazor;

namespace TrafficManagementSystem.UI.Infrastructure.Constants
{
    public static class AppConstants
    {
        public static class Designs
        {
            public const Variant InputTextVariant = Variant.Text;
            public const Variant ButtonVariant = Variant.Filled;
        }

        public static class SignalR
        {
            public const string HubUrl = "";
        }
        public static class Storage
        {
            public const string AuthToken = "_token";
            public const string RefreshToken = "";
        }

        public static class ErrorMessages
        {
            public const string SessionTimeout = "";
        }
    }

    public static class Endpoints
    {
        public static class Users
        {
            private const string _base = "users";
            public const string Login = _base + "/login";
        }

        public static class DriverEndpoints
        {
            private const string _base = "drivers";

            public const string GetDrivers = _base;

            public const string AddDriver = _base;

            public static string DeleteDrivers(Guid id) =>
                $"{_base}/{id}";
        }
    }
}
