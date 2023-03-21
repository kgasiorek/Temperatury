using Application.DataModels;
using AutoMapper;
using Domain.Entities.PomTemp;
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
        }
    }
}
