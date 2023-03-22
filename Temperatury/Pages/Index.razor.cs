using System;
using Microsoft.AspNetCore.Components;
using System.Timers;
using Application.DataModels;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;

namespace Temperatury.Pages
{
    public partial class Index : IDisposable
    {
        private Timer _timer;
        private DateTime currentDateTime;
        private List<TemperaturyDto> _data;
        private bool _loaded = false;
        private bool _isDisposed = false;

        protected override async Task OnInitializedAsync()
        {
            
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadData();
                _timer = new Timer(async _ => await LoadData(), null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
                _loaded = true;
            }
        }

        private async Task LoadData()
        {
            _data = await FetchDataFromDatabase();
            currentDateTime = DateTime.Now;
            await InvokeAsync(StateHasChanged);
        }

        private async Task<List<TemperaturyDto>> FetchDataFromDatabase()
        {
            return await _temperaturyService.GetTemperaturiesForDashboardAsync();
        }

        public void Dispose()
        {
            _isDisposed = true;
        }
            
    }
}
