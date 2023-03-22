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

        public async Task<List<SensorsWithLastSixteenDataListView>> GetAllSensorsWithLastSixteenData()
        {
            var sensors = await _sensorSettingsRepository.GetAllSensorSettings();
            var lastSixteenData = await _temperaturaRepository.GetLastSixteenTemperaturiesAsync();

            var mappedSensors = _mapper.Map<List<SensorsWithLastSixteenDataListView>>(sensors);
            var mappedTemperatures = _mapper.Map<List<TemperaturyDto>>(lastSixteenData);


            foreach (var sensor in mappedSensors.Take(3).ToList())
            {
                sensor.Measurments.AddRange(CreateMeasurmentList(mappedTemperatures, sensor.Id));
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
                    case 1:
                        pomName = "Pom1";
                        pomValue = x.Pom1;
                        time = x.Czas;
                        break;
                    case 2:
                        pomName = "Pom2";
                        pomValue = x.Pom2;
                        time = x.Czas;
                        break;
                    case 3:
                        pomName = "Pom3";
                        pomValue = x.Pom3;
                        time = x.Czas;
                        break;
                    default:
                        pomName = "Unknown";
                        pomValue = 0;
                        break;
                }

                return new MeasurmentsTemperaturesDto
                {
                    Time = x.Czas,
                    PomName = pomName,
                    Temperature = pomValue
                };
            }).ToList();

            return result;
        }

    }
}
