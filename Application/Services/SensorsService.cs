using Application.DataModels;
using Application.DataModels.SettingsModels;
using Application.Interfaces.Repository.SettingsRepositoriesInterfaces;
using Application.Interfaces.Repository.TemperaturyRepositoriesInterfaces;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities.PomTemp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class SensorsService : ISensorsService
    {

        private readonly ITemperaturyRepository _temperaturaRepository;
        private readonly ISensorSettingsRepository _sensorSettingsRepository;
        private readonly IMapper _mapper;

        public SensorsService(ITemperaturyRepository temperaturaRepository, ISensorSettingsRepository sensorSettingsRepository, IMapper mapper)
        {
            _temperaturaRepository = temperaturaRepository;
            _sensorSettingsRepository = sensorSettingsRepository;
            _mapper = mapper;
        }



        public async Task<List<SensorsWithMeasurmentDataListView>> GetAllSensorsWithLastSixteenData()
        {
            var sensors = await _sensorSettingsRepository.GetAllSensorSettings();
            var lastSixteenData = await _temperaturaRepository.GetLastSixteenTemperaturiesAsync();

            var mappedSensors = _mapper.Map<List<SensorsWithMeasurmentDataListView>>(sensors);
            var mappedTemperatures = _mapper.Map<List<TemperaturyDto>>(lastSixteenData);


            foreach (var sensor in mappedSensors)
            {
                sensor.Measurments.AddRange(CreateMeasurmentList(mappedTemperatures, int.Parse(Regex.Replace(sensor.OriginalName, @"\D", ""))));
            }

            return mappedSensors;
        }

        public async Task<List<SensorsWithMeasurmentDataListView>> GetSensorsDataForReport(DateTime dateOfReport)
        {
            var sensors = await _sensorSettingsRepository.GetSensorsForReportWhichAreNeeded();
            var lastSixteenData = await _temperaturaRepository.GetTemperaturesForOneDayReport(dateOfReport);

            var mappedSensors = _mapper.Map<List<SensorsWithMeasurmentDataListView>>(sensors);
            var mappedTemperatures = _mapper.Map<List<TemperaturyDto>>(lastSixteenData);

            foreach (var sensor in mappedSensors)
            {
                sensor.Measurments.AddRange(CreateMeasurmentList(mappedTemperatures, int.Parse(Regex.Replace(sensor.OriginalName, @"\D", ""))));
            }
            return mappedSensors;
        }

        public List<MeasurmentsTemperaturesDto> CreateMeasurmentList(List<TemperaturyDto> temperatury, int sensorId)
        {
            List<MeasurmentsTemperaturesDto> result = temperatury.Select(x =>
            {
                string pomName;
                double pomValue;
                DateTime time;

                switch (sensorId)
                {
                    case 1: pomValue = x.Pom1; break;
                    case 2: pomValue = x.Pom2; break;
                    case 3: pomValue = x.Pom3; break;
                    case 4: pomValue = x.Pom4; break;
                    case 5: pomValue = x.Pom5; break;
                    case 6: pomValue = x.Pom6; break;
                    case 7: pomValue = x.Pom7; break;
                    case 8: pomValue = x.Pom8; break;
                    case 9: pomValue = x.Pom9; break;
                    case 10: pomValue = x.Pom10; break;
                    case 11: pomValue = x.Pom11; break;
                    case 12: pomValue = x.Pom12; break;
                    case 13: pomValue = x.Pom13; break;
                    case 14: pomValue = x.Pom14; break;
                    case 15: pomValue = x.Pom15; break;
                    case 16: pomValue = x.Pom16; break;
                    case 17: pomValue = x.Pom17; break;
                    case 18: pomValue = x.Pom18; break;
                    case 19: pomValue = x.Pom19; break;
                    case 20: pomValue = x.Pom20; break;
                    case 21: pomValue = x.Pom21; break;
                    case 22: pomValue = x.Pom22; break;
                    case 23: pomValue = x.Pom23; break;
                    case 24: pomValue = x.Pom24; break;
                    case 25: pomValue = x.Pom25; break;
                    case 26: pomValue = x.Pom26; break;
                    case 27: pomValue = x.Pom27; break;
                    case 28: pomValue = x.Pom28; break;
                    case 29: pomValue = x.Pom29; break;
                    case 30: pomValue = x.Pom30; break;
                    case 31: pomValue = x.Pom31; break;
                    case 32: pomValue = x.Pom32; break;
                    case 33: pomValue = x.Pom33; break;
                    case 34: pomValue = x.Pom34; break;
                    case 35: pomValue = x.Pom35; break;
                    default:
                        pomName = "Unknown";
                        pomValue = 0;
                        break;
                }

                return new MeasurmentsTemperaturesDto
                {
                    Time = x.Czas,
                    PomName = $"Pom{sensorId}",
                    Temperature = pomValue
                };
            }).ToList();

            return result;
        }


    }
}
