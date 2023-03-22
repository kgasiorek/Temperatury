using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModels
{
    public class ZmienneTempDto
    {
        public long ZmiennaTempId { get; set; }

        public string Nazwa { get; set; } = null!;

        public string Opis { get; set; } = null!;

        public double ZakresAlarmMin { get; set; }

        public double ZakresAlarmMax { get; set; }

        public bool UseAlarmMin { get; set; }

        public bool UseAlarmMax { get; set; }

        public ICollection<MeasurmentsTemperaturesDto> Pomiary { get; set; }
    }
}
