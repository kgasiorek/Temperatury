using Microsoft.JSInterop;

namespace Temperatury.Pages.Reports;

public partial class ReportPage
{
    private async Task PrintPage()
    {
        await JsRuntime.InvokeVoidAsync("printDiv");
    }
}
