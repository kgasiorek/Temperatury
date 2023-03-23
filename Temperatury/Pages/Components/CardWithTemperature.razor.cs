using Application.DataModels;
using Application.DataModels.SettingsModels;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;
using ChartJs.Blazor.Common;
using Azure;
using ChartJs.Blazor.Common.Time;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.PieChart;
using Microsoft.AspNetCore.Components.Web;

namespace Temperatury.Pages.Components
{
    public partial class CardWithTemperature
    {
        [Parameter] public SensorsWithLastSixteenDataListView Sensor { get; set; }
        [Parameter] public EventCallback<string> NewDataRecieved { get; set; }
        LineConfig _lineConfig { get; set; }
        LineDataset<Point> _lineDataset { get; set; }
        bool _loaded = false;


        private async Task ProductSelected(MouseEventArgs e, string name)
        {
            await NewDataRecieved.InvokeAsync(name);
        }
        protected override async Task OnInitializedAsync()
        {
            await ConfigureNewDataset();
            CreateConfigForChart();
            _loaded = true;
            StateHasChanged();
        }

        public async Task ConfigureNewDataset()
        {
            _lineDataset = new LineDataset<Point>
            {
                Label = "Temperatura",
                BorderColor = ColorUtil.ColorString(52, 131, 235, 1),
                BorderWidth = 1,
                Fill = false,
                PointRadius = 1,
                PointBorderWidth = 0
            };
            await RefreshDataInChart();
        }

        public async Task RefreshDataInChart()
        {
            _lineDataset.Clear();
            var temperatureData = Sensor.Measurments.OrderBy(x => x.Time).Select((x, index) => new { Time = index, Temperature = x.Temperature }).ToList();
            _lineDataset.AddRange(temperatureData.Select(x => new Point((double)x.Time, x.Temperature)));
            await InvokeAsync(StateHasChanged);
        }

        private void CreateConfigForChart()
        {
            _lineConfig = new LineConfig
            {
                Options = new LineOptions
                {
                    Legend = new Legend
                    {
                        Display = false,
                    },
                    Scales = new Scales
                    {
                        XAxes = new List<CartesianAxis>
                        {
                            new LinearCartesianAxis
                            {
                                GridLines = new GridLines
                                {
                                    Display = false
                                },
                                Ticks = new LinearCartesianTicks
                                {
                                    Display = false
                                }
                            }
                        },
                        YAxes = new List<CartesianAxis>
                        {
                            new LinearCartesianAxis
                            {
                                GridLines = new GridLines
                                {
                                    Display = true
                                },
                                Ticks = new LinearCartesianTicks
                                {
                                    AutoSkip = true,
                                    StepSize = 10
                                }
                            },
                        }
                    }
                }
            };

            _lineConfig.Data.Datasets.Add(_lineDataset);
            StateHasChanged();
        }
    }

}
