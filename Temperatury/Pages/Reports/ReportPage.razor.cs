using ApexCharts;
using Application.DataModels.SettingsModels;
using Microsoft.JSInterop;

namespace Temperatury.Pages.Reports;

public partial class ReportPage
{
    DateTime? selectedDate = DateTime.Today;
    DateTime? selectedTime;
    List<SensorsWithMeasurmentDataListView> Sensors = new();
    bool _loaded = false;
    bool _reloading = false;

    protected override async Task OnInitializedAsync()
    {
        Sensors = await _sensorsService.GetSensorsDataForReport((DateTime)selectedDate);
        _loaded = true;
    }
    private async Task PrintPage()
    {
        await JsRuntime.InvokeVoidAsync("printDiv");
    }

    private async void DateChanged()
    {
        _reloading = true;
        Sensors = await _sensorsService.GetSensorsDataForReport((DateTime)selectedDate);
        selectedTime = null;
        _reloading = false;
        StateHasChanged();
    }

    private async void ChangeSelectedTime(DateTime SelectedTime)
    {
        selectedTime = SelectedTime;
        StateHasChanged();
    }
}
