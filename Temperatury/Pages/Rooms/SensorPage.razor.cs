using ApexCharts;
using Application.DataModels;
using Application.DataModels.SettingsModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace Temperatury.Pages.Rooms;

public partial class SensorPage : IDisposable
{
    [CascadingParameter] public SensorsWithLastSixteenDataListView SelectedSensor { get; set; }
    [CascadingParameter] public List<SensorsWithLastSixteenDataListView> Sensors { get; set; }
    private MudDateRangePicker _picker;
    private DateRange _dateRange = new DateRange(DateTime.Today.Date.AddDays(-1), DateTime.Today);
    private DateTime now = DateTime.Now;
    private ApexChartOptions<TemperaturyDto> options;
    private ApexChart<TemperaturyDto> _chart;
    private int TimeOffsetToLoadData = 1;
    TimeSpan? timeStart;
    TimeSpan? timeEnd;
    List<TemperaturyDto> temperaturesBySensor = new();
    private bool _loaded = false;

    protected override async Task OnInitializedAsync()
    {
        CreateChart();
        timeStart = new TimeSpan(now.Hour, now.Minute, 00);
        timeEnd = new TimeSpan(now.Hour, now.Minute, 00);
        temperaturesBySensor = await LoadDataForDashboard();
        _loaded = true;
        StateHasChanged();
    }

    private async Task<List<TemperaturyDto>> LoadDataForDashboard()
    {
        var startDate = _dateRange.Start.Value.AddHours(timeStart.Value.TotalHours);
        var endDate = _dateRange.End.Value.AddHours(timeEnd.Value.TotalHours);
        return await _temperaturyService.GetTemperaturiesForSensorByStartAndEndDateAsync(startDate, endDate, SelectedSensor.OriginalName, TimeOffsetToLoadData);
    }

    private void CreateChart()
    {
        options = new ApexChartOptions<TemperaturyDto>
        {
            Chart = new ApexCharts.Chart
            {
                Toolbar = new Toolbar
                {
                    AutoSelected = AutoSelected.Zoom,
                    Show = true
                },
                DefaultLocale = "pl",
                Locales = new List<ChartLocale>
                {
                    new ChartLocale
                    {
                        Name = "pl",
                        Options = new LocaleOptions
                        {
                            Months = new List<string>
                            {
                                "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień"
                            },
                            ShortMonths = new List<string>
                            {
                                "Sty", "Lut", "Mar", "Kwi", "Maj", "Cze", "Lip", "Sie", "Wrz", "Paź", "Lis", "Gru"
                            },
                            Days = new List<string>
                            {
                                "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela"
                            },
                            ShortDays = new List<string>
                            {
                                "Pon", "Wto", "Śro", "Czw", "Pią", "Sob", "Nie"
                            },
                            Toolbar = new LocaleToolbar
                            {
                                Download = "Ściągnij SVG",
                                Selection = "Zaznaczenie",
                                SelectionZoom = "Zbliżenie zaznaczenia",
                                ZoomIn = "Przybliż",
                                ZoomOut = "Oddal",
                                Pan = "Przesuwanie",
                                Reset = "Reset",
                            }
                        },
                    }
                }
            },
            Stroke = new Stroke
            {
                Curve = Curve.Smooth,
                Width = 2,
            },
            Tooltip = new ApexCharts.Tooltip { X = new TooltipX { Format = @"dd MMMM yyyy HH:mm", Show = true } },
            Yaxis = new List<YAxis>
            {
                new YAxis
                {
                    DecimalsInFloat = 1,
                    TickAmount = 5,
                }
            },
            Xaxis = new XAxis
            {
                Labels = new XAxisLabels
                {
                    Show = true,
                }
            },
          
            Annotations = new Annotations
            {
                Yaxis = new List<AnnotationsYAxis>()
                {
                    new AnnotationsYAxis
                    {
                        Y = SelectedSensor.MinTemp,
                        BorderWidth = 2,
                        StrokeDashArray = 5,
                        BorderColor = "blue",
                        Label = new Label { Text = "Minimum" }
                    },
                    new AnnotationsYAxis
                    {
                        Y = SelectedSensor.MaxTemp,
                        BorderWidth = 2,
                        StrokeDashArray = 5,
                        BorderColor = "red",
                        Label = new Label { Text = "Maximum" }
                    }
                }
            },
        };
    }

    private async Task GetData()
    {
        _loaded = false;
        temperaturesBySensor = await LoadDataForDashboard();
        _loaded = true;
    }

    private async void OnValueChanged(SensorsWithLastSixteenDataListView selected)
    {
        SelectedSensor = selected;
        options = ApexChartOptions();
        await _chart.UpdateSeriesAsync();
        await _chart.UpdateOptionsAsync(true, true, false);
        StateHasChanged();
        // Do other stuff
    }

    private ApexChartOptions<TemperaturyDto> ApexChartOptions()
    {
        var apexOptions = new ApexChartOptions<TemperaturyDto>
        {
            Chart = new ApexCharts.Chart
            {
                Toolbar = new Toolbar
                {
                    AutoSelected = AutoSelected.Zoom,
                    Show = true
                },
                DefaultLocale = "pl",
                Locales = new List<ChartLocale>
                {
                    new ChartLocale
                    {
                        Name = "pl",
                        Options = new LocaleOptions
                        {
                            Months = new List<string>
                            {
                                "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień"
                            },
                            ShortMonths = new List<string>
                            {
                                "Sty", "Lut", "Mar", "Kwi", "Maj", "Cze", "Lip", "Sie", "Wrz", "Paź", "Lis", "Gru"
                            },
                            Days = new List<string>
                            {
                                "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela"
                            },
                            ShortDays = new List<string>
                            {
                                "Pon", "Wto", "Śro", "Czw", "Pią", "Sob", "Nie"
                            },
                            Toolbar = new LocaleToolbar
                            {
                                Download = "Ściągnij SVG",
                                Selection = "Zaznaczenie",
                                SelectionZoom = "Zbliżenie zaznaczenia",
                                ZoomIn = "Przybliż",
                                ZoomOut = "Oddal",
                                Pan = "Przesuwanie",
                                Reset = "Reset",
                            }
                        },
                    }
                }
            },
            Stroke = new Stroke
            {
                Curve = Curve.Smooth,
                Width = 2,
            },
            Tooltip = new ApexCharts.Tooltip { X = new TooltipX { Format = @"dd MMMM yyyy HH:mm (dddd)", Show = true } },
            Yaxis = new List<YAxis>
            {
                new YAxis
                {
                    DecimalsInFloat = 1,
                    TickAmount = 5,
                }
            },
            Xaxis = new XAxis
            {
                Labels = new XAxisLabels
                {
                    Show = true,
                }
            },
            Fill = new Fill
            {
                Type = new List<FillType> { FillType.Gradient },
                Gradient = new FillGradient
                {
                    Type = GradientType.Vertical,
                    ShadeIntensity = 1,
                    OpacityFrom = 1,
                    OpacityTo = 1,
                    GradientToColors = new List<string> { "#0045ff", "#00ff29", "#ff5959" },
                    Stops = new List<double> { 20, 70, 100 }
                },
            },
            Annotations = new Annotations
            {
                Yaxis = new List<AnnotationsYAxis>()
                {
                    new AnnotationsYAxis
                    {
                        Y = SelectedSensor.MinTemp,
                        BorderWidth = 2,
                        StrokeDashArray = 5,
                        BorderColor = "blue",
                        Label = new Label { Text = "Minimum" }
                    },
                    new AnnotationsYAxis
                    {
                        Y = SelectedSensor.MaxTemp,
                        BorderWidth = 2,
                        StrokeDashArray = 5,
                        BorderColor = "red",
                        Label = new Label { Text = "Maximum" }
                    }
                }
            },
        };
        return apexOptions;
    }

    public void Dispose()
    {

    }
}
