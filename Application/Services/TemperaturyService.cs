using Application.DataModels;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities.PomTemp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TemperaturyService : ITemperaturyService
    {
        private readonly ITemperaturyRepository _temperaturaRepository;
        private readonly IMapper _mapper;

        public TemperaturyService(ITemperaturyRepository temperaturaRepository, IMapper mapper)
        {
            _temperaturaRepository = temperaturaRepository;
            _mapper = mapper;
        }

        public async Task<List<TemperaturyDto>> GetTemperaturyAsync()
        {
            var response = await _temperaturaRepository.GetAllTemperaturyAsync();
            var mapped = _mapper.Map<List<TemperaturyDto>>(response);
            return mapped;
        }
        public async Task<List<TemperaturyDto>> GetTemperaturiesForDashboardAsync()
        {
            var response = await _temperaturaRepository.GetLastTenTemperaturiesAsync();
            var mapped = _mapper.Map<List<TemperaturyDto>>(response);
            return mapped;
        }


    }
}
