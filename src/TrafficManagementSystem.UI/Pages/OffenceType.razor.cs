using MudBlazor;
using TrafficManagementSystem.Application.DTOs.OffenceType;
using TrafficManagementSystem.UI.Components;

namespace TrafficManagementSystem.UI.Pages
{
    public partial class OffenceType
    {
        List<OffenceTypeDto> offenceTypes = new();
        string? searchString;

        protected override async Task OnInitializedAsync()
        {
            await GetOffenceTypes();
        }

        async Task GetOffenceTypes()
        {
            offenceTypes = await _offenceTypeManager.GetOffenceTypes();
        }

        async Task InvokeOffenceTypeDialog(Guid? id = null)
        {
            var parameters = new DialogParameters();
            if (id != null)
            {
                var offenceType = offenceTypes.FirstOrDefault(d => d.Id == id.Value);
                if (offenceType != null)
                {
                    parameters.Add(nameof(OffenceTypesDialog.OffenceTypeModel), new NewOffenceTypeRequest
                    {
                        Id = offenceType.Id,
                        Category = offenceType.Category,
                        Code = offenceType.Code,
                        FineAmount = offenceType.FineAmount,
                        Name = offenceType.Name,
                        Point = offenceType.Point
                    });
                }
            }

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<OffenceTypesDialog>("OffenceType Dialog", parameters, options);
            var result = await dialog.Result;
            //if (!result.Cancelled)
            //{
            //    await _hubConnection.InvokeHubMethodAsync(ApplicationConstants.SignalR.OnWalletUpdate);
            //}

        }
    }

}
