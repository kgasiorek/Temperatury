using Domain.Entities.PomTemp;
using Domain.SettingsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository.SettingsRepositoriesInterfaces
{
    public interface ISensorSettingsRepository
    {
        Task<List<SensorSettings>> GetAllSensorSettings();
        Task<List<SensorSettings>> GetSensorsForReportWhichAreNeeded();
    }
}
