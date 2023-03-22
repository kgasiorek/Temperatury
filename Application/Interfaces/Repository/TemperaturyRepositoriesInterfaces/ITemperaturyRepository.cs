using Application.DataModels;
using Domain.Entities.PomTemp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository.TemperaturyRepositoriesInterfaces
{
    public interface ITemperaturyRepository
    {
        Task<List<Temperatury>> GetAllTemperaturyAsync();
        Task<List<Temperatury>> GetLastSixteenTemperaturiesAsync();
    }
}
