using Domain.Entities.PomTemp;
using Infrastructure.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Temperatury.Pages
{
    public partial class Index
    {
        protected override async Task OnInitializedAsync()
        {
            var temperatury = await _temperaturyService.GetTemperaturiesForDashboardAsync();
        }
    }
}
