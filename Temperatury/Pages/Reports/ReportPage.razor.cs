using ApexCharts;
using Application.DataModels.SettingsModels;
using Microsoft.JSInterop;

namespace Temperatury.Pages.Reports;

public partial class ReportPage
{
    DateTime selectedDate = DateTime.Today;
    DateTime? selectedTime;
    List<SensorsWithMeasurmentDataListView> Sensors = new();
    bool firstLoad = true;
    bool _loaded = false;

    protected override async Task OnInitializedAsync()
    {
        Sensors = await _sensorsService.GetSensorsDataForReport(selectedDate);
        _loaded = true;
    }
    private async Task PrintPage()
    {
        await JsRuntime.InvokeVoidAsync("printDiv");
    }

    private async void DateChanged(DateTime? newDate)
    {
        _loaded = false;
        selectedDate = (DateTime)newDate;
        Sensors = await _sensorsService.GetSensorsDataForReport(selectedDate);
        _loaded = true;
        selectedTime = null;
        StateHasChanged();
    }

    private async void ChangeSelectedTime(DateTime SelectedTime)
    {
        selectedTime = SelectedTime;
        StateHasChanged();
    }
}
