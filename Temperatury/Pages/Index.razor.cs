using System;
using Microsoft.AspNetCore.Components;
using System.Timers;
using Application.DataModels;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;
using Application.DataModels.SettingsModels;
using MudBlazor;
using System.Collections.Generic;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Util;
using ChartJs.Blazor.LineChart;
using System.Data;
using ChartJs.Blazor.Common.Enums;
using System.Drawing;
using Temperatury.Pages.Components;

namespace Temperatury.Pages
{
    public partial class Index : IDisposable
    {
        private Timer _timer;
        private DateTime currentDateTime;
        private bool _loaded = false;
        private bool _isDisposed = false;
        private List<SensorsWithLastSixteenDataListView> _sensors;
        private List<CardWithTemperature> CardWithTemperatureInstances = new();


        protected override async Task OnInitializedAsync()
        {
            await LoadData();
            var timeSpan = _sensors[0].Measurments[0].Time.AddSeconds(65) - DateTime.Now;
            _timer = new Timer(async _ => await LoadData(), null, timeSpan, TimeSpan.FromSeconds(60));
            _loaded = true;
            StateHasChanged();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
               
            }
        }

        private async Task LoadData()
        {
            _sensors = await LoadDataForDashboard();
            currentDateTime = DateTime.Now;
            await RefreshChildData();
            await InvokeAsync(StateHasChanged);
        }

        private CardWithTemperature AddChildComponentInstance
        {
            set
            {
                if (value != null)
                {
                    CardWithTemperatureInstances.Add(value);
                }
            }
        }

        private async Task RefreshChildData()
        {
            foreach (var childInstance in CardWithTemperatureInstances)
            {
                await childInstance.RefreshDataInChart();
            }
        }

        private async Task<List<SensorsWithLastSixteenDataListView>> LoadDataForDashboard()
        {
            return await _sensorsService.GetAllSensorsWithLastSixteenData();
        }

        public void Dispose()
        {
            _isDisposed = true;
            _timer.Dispose();
        }

    }
}
