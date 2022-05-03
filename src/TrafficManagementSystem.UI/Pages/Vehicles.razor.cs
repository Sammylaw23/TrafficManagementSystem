using MudBlazor;
using TrafficManagementSystem.Application.DTOs.Vehicle;
using TrafficManagementSystem.UI.Components;

namespace TrafficManagementSystem.UI.Pages
{
    public partial class Vehicles
    {
        List<VehicleDto> vehicles = new();
        string? searchString;

        async Task InvokeVehicleDialog(Guid? id = null)
        {
            await Task.Delay(0);

            var parameters = new DialogParameters();
            if (id != null)
            {
                var driver = vehicles.FirstOrDefault(d => d.Id == id.Value);
                if (driver != null)
                {
                    parameters.Add(nameof(VehicleDialog.VehicleModel), new NewVehicleRequest
                    {
                        Id = driver.Id,
                        Name = driver.Name,
                        Owner = driver.Owner,
                        PlateNumber = driver.PlateNumber,
                        RegistrationDate = driver.RegistrationDate,
                        Brand = driver.Brand,
                        ChassisNo = driver.ChassisNo,
                        Colour = driver.Colour,
                        EngineNumber = driver.EngineNumber,
                        Model = driver.Model,
                        Type = driver.Type
                    });
                }
            }

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<VehicleDialog>("Vehicle Dialog", parameters, options);
            var result = await dialog.Result;
            //if (!result.Cancelled)
            //{
            //    await _hubConnection.InvokeHubMethodAsync(ApplicationConstants.SignalR.OnWalletUpdate);
            //}

        }
    }

}
