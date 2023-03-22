using Application.DataModels;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities.PomTemp;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TemperaturyRepository : BaseRepository<Temperatury>, ITemperaturyRepository
    {
        public TemperaturyRepository(PomTempContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Temperatury>> GetAllTemperaturyAsync()
        {
            var response = await _dbContext.Temperatury.Where(x => x.TemperaturyId < 1000).ToListAsync();
            return response;
        }
        public async Task<List<Temperatury>> GetLastTenTemperaturiesAsync()
        {
            var last10Temperatury = await _dbContext.Temperatury
                                .OrderByDescending(t => t.Czas)
                                .Take(10)
                                .ToListAsync();
            return last10Temperatury;
        }

    }

}
