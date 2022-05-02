using MudBlazor;
using TrafficManagementSystem.Application.DTOs.Offence;
using TrafficManagementSystem.UI.Components;

namespace TrafficManagementSystem.UI.Pages
{
    public partial class Offence
    {
        List<OffenceDto> offences = new();
        string? searchString;

        async Task InvokeOffenceDialog(Guid? id = null)
        {
            await Task.Delay(0);

            var parameters = new DialogParameters();
            if (id != null)
            {
                var offence = offences.FirstOrDefault(d => d.Id == id.Value);
                if (offence != null)
                {
                    parameters.Add(nameof(OffenceDialog.OffenceModel), new NewOffenceRequest
                    {
                        Id = offence.Id,
                        OffenceTypeCode = offence.OffenceTypeCode,
                        OffenderName = offence.OffenderName,
                        PlateNumber = offence.PlateNumber,
                        CreatedBy = offence.CreatedBy,
                        LicenseNo = offence.LicenseNo,
                        ReportDate = offence.ReportDate
                    });
                }
            }

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<OffenceDialog>("Offence Dialog", parameters, options);
            var result = await dialog.Result;


        }
    }
}
