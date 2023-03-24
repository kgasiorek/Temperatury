﻿using System;
using Microsoft.AspNetCore.Components;
using System.Timers;
using Application.DataModels;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;
using Application.DataModels.SettingsModels;
using MudBlazor;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Temperatury.Pages.Components;
using Application.Enums;

namespace Temperatury.Pages
{
    public partial class Index : IDisposable
    {
        private Timer _timer;
        private DateTime currentDateTime;
        private bool _loaded = false;
        private bool _refreshed = false;
        private bool _dataNotActual = false;
        private List<SensorsWithLastSixteenDataListView> _sensors;
        private List<CardWithTemperature> CardWithTemperatureInstances = new();
        private CardSize cardSize = CardSize.Medium;
        private int _cardSizeForLg = 2;
        private int _cardSizeForMd = 3;
        private int CardValue = 50;
        string[] labels = new string[] { "Małe", "Średnie", "Duże" };


        protected override async Task OnInitializedAsync()
        {
            await CreateCards();
        }

        private async Task CreateCards()
        {
            await LoadData();
            var timeOffsetToRun = _sensors[0].Measurments[0].Time.AddSeconds(65) - DateTime.Now;
            if (timeOffsetToRun < TimeSpan.Zero) 
            {
                timeOffsetToRun = TimeSpan.FromSeconds(60);
                _dataNotActual = true;
            }
            else
            {
                _dataNotActual = false;
            }


            _timer = new Timer(async _ => await LoadData(), null, timeOffsetToRun, TimeSpan.FromSeconds(60));
            _loaded = true;
            await Task.Delay(1000);
            _refreshed = true;
            StateHasChanged();
        }

        private async Task LoadData()
        {
            _sensors = await LoadDataForDashboard();
            currentDateTime = DateTime.Now;
            await RefreshChildData();
            await InvokeAsync(StateHasChanged);
        }

        private async void CardSizeChanged(int newValue)
        {
            _refreshed = false;
            await Task.Delay(500);
            CardWithTemperatureInstances.Clear();
            _timer.Dispose();
            switch (newValue)
            {
                case 1:
                    _cardSizeForLg = 2;
                    _cardSizeForMd = 2;
                    cardSize = CardSize.Small;
                    break;
                case 2:
                    _cardSizeForLg = 2;
                    _cardSizeForMd = 4;
                    cardSize = CardSize.Medium;
                    break;
                case 3:
                    _cardSizeForLg = 4;
                    _cardSizeForMd = 6;
                    cardSize = CardSize.Big;
                    break;
                default: break;
            }
            await CreateCards();
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
            try
            {
                foreach (var childInstance in CardWithTemperatureInstances)
                {
                    await childInstance.RefreshDataInChart();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private string GetFadeInOutClass()
        {
            return _refreshed ? "fade-in-out loaded" : "fade-in-out not-loaded";
        }

        private async Task<List<SensorsWithLastSixteenDataListView>> LoadDataForDashboard()
        {
            return await _sensorsService.GetAllSensorsWithLastSixteenData();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
