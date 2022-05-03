using MudBlazor;
using TrafficManagementSystem.Application.DTOs.Driver;
using TrafficManagementSystem.UI.Components;
using TrafficManagementSystem.UI.Infrastructure.Extensions;

namespace TrafficManagementSystem.UI.Pages
{
    public partial class Drivers
    {
        List<DriverDto> drivers = new();
        string? searchString;

        protected override async Task OnInitializedAsync()
        {
            await GetDrivers();
        }

        async Task GetDrivers()
        {
            drivers= await _driverManager.GetDrivers();
        }
        async Task InvokeDriverDialog(Guid? id = null)
        {
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
            if (!result.Cancelled)
            {
                await GetDrivers();
                StateHasChanged();
            }

        }

        async Task DeleteDriver(DriverDto driver)
        {
            string deleteContent = $"Delete driver ({driver.FirstName} {driver.LastName})?";
            var parameters = new DialogParameters
            {
                { nameof(DeleteConfirmationDialog.ContentText), deleteContent }
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<DeleteConfirmationDialog>("Delete", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await _driverManager.DeleteDriver(driver.Id.Value);
                if (response.Succeeded)
                {
                    _snackbar.Add("Driver record has been deleted successfully.", Severity.Success);
                    await GetDrivers();
                    StateHasChanged();
                }
                else
                {
                    response.ShowFailureMessages(_snackbar);
                }
            }
        }
    }
}
