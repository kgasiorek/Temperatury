using Application.DataModels;
using Application.DataModels.SettingsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ISensorsService
    {
        Task<List<SensorsWithMeasurmentDataListView>> GetAllSensorsWithLastSixteenData();
        Task<List<SensorsWithMeasurmentDataListView>> GetSensorsDataForReport(DateTime dateOfReport);
    }
}
