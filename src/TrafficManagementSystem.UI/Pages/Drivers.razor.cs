using MudBlazor;
using TrafficManagementSystem.Application.DTOs.Driver;
using TrafficManagementSystem.UI.Components;

namespace TrafficManagementSystem.UI.Pages
{
    public partial class Drivers
    {
        List<DriverDto> drivers = new();
        string? searchString;

        async Task InvokeDriverDialog(Guid? id = null)
        {
            await Task.Delay(0);

            var parameters = new DialogParameters();
            if (id != null)
            {
                var driver = drivers.FirstOrDefault(d => d.Id==id.Value);
                if (driver!=null)
                {
                    parameters.Add(nameof(DriverDialog.DriverModel), new NewDriverRequest
                    {
                        Id=driver.Id,
                        DateOfBirth=driver.DateOfBirth,
                        Email=driver.Email,
                        FirstName=driver.FirstName,
                        LastName=driver.LastName,
                        Gender = driver.Gender,
                        LicenseNo=driver.LicenseNo,
                        Address=driver.Address,
                        PhoneNumber=driver.PhoneNumber
                    });
                }
            }

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<DriverDialog>("Driver Dialog", parameters, options);
            var result = await dialog.Result;
            //if (!result.Cancelled)
            //{
            //    await _hubConnection.InvokeHubMethodAsync(ApplicationConstants.SignalR.OnWalletUpdate);
            //}

        }
    }
}
