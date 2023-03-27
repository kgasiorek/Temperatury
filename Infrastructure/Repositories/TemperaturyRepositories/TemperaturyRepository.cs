using Application.DataModels;
using Application.Interfaces.Repository.TemperaturyRepositoriesInterfaces;
using AutoMapper;
using Domain.Entities.PomTemp;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.TemperaturyRepositories
{
    public class TemperaturyRepository : BaseRepository<Temperatury>, ITemperaturyRepository
    {
        PomTempContext _db { get; set; }

        public TemperaturyRepository(PomTempContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<Temperatury>> GetAllTemperaturyAsync()
        {
            var response = await _db.Temperatury.Where(x => x.TemperaturyId < 1000).ToListAsync();
            return response;
        }
        public async Task<List<Temperatury>> GetLastSixteenTemperaturiesAsync()
        {
            var last10Temperatury = await _db.Temperatury
                                .OrderByDescending(t => t.Czas)
                                .Take(60)
                                .ToListAsync();
            return last10Temperatury;
        }

        public async Task<List<Temperatury>> GetTemperaturiesForSensorByStartAndEndDate(DateTime startDate, DateTime endDate, string sensorText)
        {
            var temperatures = await _db.Temperatury
                .OrderByDescending(t => t.Czas)
                .Where(x => x.Czas >= startDate && x.Czas <= endDate)
                .ToListAsync();
            return temperatures;
        }
    }

}
