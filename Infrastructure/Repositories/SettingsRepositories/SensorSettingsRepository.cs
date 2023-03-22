using Application.Interfaces.Repository.SettingsRepositoriesInterfaces;
using Application.Interfaces.Repository.TemperaturyRepositoriesInterfaces;
using Domain.Entities.PomTemp;
using Domain.SettingsEntities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.SettingsRepositories
{
    public class SensorSettingsRepository : BaseRepository<SettingsContext>, ISensorSettingsRepository
    {
        SettingsContext _db;
        public SensorSettingsRepository(SettingsContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<SensorSettings>> GetAllSensorSettings()
        {
            var response = await _db.SensorSettings.ToListAsync();
            return response;
        }
    }
}
