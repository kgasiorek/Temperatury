using Application.DataModels;
using Application.DataModels.SettingsModels;
using AutoMapper;
using Domain.Entities.PomTemp;
using Domain.SettingsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Temperatury, TemperaturyDto>();

            CreateMap<SensorSettings, SensorsWithLastSixteenDataListView>();
            CreateMap<Room, RoomDto>();
            CreateMap<TypeOfSensor, TypeOfSensorDto>();
        }
    }
}
