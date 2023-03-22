using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModels
{
    public class MeasurmentsTemperaturesDto
    {
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public string? PomName { get; set; }
    }
}
