using Application.DataModels;
using Domain.Entities.PomTemp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITemperaturyService
    {
        Task<List<TemperaturyDto>> GetTemperaturyAsync();
        Task<List<TemperaturyDto>> GetTemperaturiesForDashboardAsync();
        Task<List<TemperaturyDto>> GetTemperaturiesForSensorByStartAndEndDateAsync(DateTime startDate, DateTime endDate, string sensorText);
    }
}
