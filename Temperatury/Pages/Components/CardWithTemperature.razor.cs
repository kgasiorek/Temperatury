using Application.DataModels;
using Application.DataModels.SettingsModels;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;
using Azure;
using Microsoft.AspNetCore.Components.Web;
using ApexCharts;
using MudBlazor;
using static MudBlazor.CategoryTypes;
using Application.Enums;

namespace Temperatury.Pages.Components
{
    public partial class CardWithTemperature : IDisposable
    {
        [Parameter] public SensorsWithLastSixteenDataListView Sensor { get; set; }
        [Parameter] public EventCallback<string> NewDataRecieved { get; set; }
        [Parameter] public CardSize cardSize { get; set; }
        private ApexChartOptions<MeasurmentsTemperaturesDto> options;
        private ApexChart<MeasurmentsTemperaturesDto> _chart;
        bool _loaded = false;

        protected override async Task OnInitializedAsync()
        {
            options = new ApexChartOptions<MeasurmentsTemperaturesDto>
            {
                Chart = new ApexCharts.Chart
                {
                    Toolbar = new Toolbar
                    {
                        AutoSelected = AutoSelected.Pan,
                        Show = false
                    },
                },
                Stroke = new Stroke
                {
                    Curve = Curve.Smooth,
                    Width = 2,
                },
                Tooltip = new ApexCharts.Tooltip { X = new TooltipX { Format = @"HH:mm", Show = false } },
                Yaxis = new List<YAxis>
                {
                    new YAxis
                    {
                        DecimalsInFloat = 1,
                        TickAmount = 2,
                    }
                },
                Xaxis = new XAxis
                {
                    Labels = new XAxisLabels
                    {
                        Show = false,
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
            };
            _loaded = true;
            StateHasChanged();
        }

        public async Task RefreshDataInChart()
        {
            await _chart.UpdateSeriesAsync(true);
            await InvokeAsync(StateHasChanged);
        }

        private string AlarmColor()
        {
            if(Sensor.Measurments[0].Temperature > Sensor.MinTemp && Sensor.Measurments[0].Temperature < Sensor.MaxTemp)
            {
                return "background-color:green;opacity:0.6;";
            }
            if (Sensor.Measurments[0].Temperature < Sensor.MinTemp)
            {
                return "background-color:blue;opacity:0.6;";
            }
            return "background-color:red;opacity:0.6";
        }

        public void Dispose()
        {
            _chart.Dispose();
        }
    }
}


