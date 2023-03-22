using Domain.SettingsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModels.SettingsModels
{
    public class SensorsWithLastSixteenDataListView
    {
        public int Id { get; set; }
        public string? OriginalName { get; set; }
        public string? Description { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public bool MinAlarmEnabled { get; set; }
        public bool MaxAlarmEnabled { get; set; }

        public int? RoomId { get; set; }
        public virtual RoomDto? Room { get; set; }

        public int? TypeOfSensorId { get; set; }
        public TypeOfSensorDto? TypeOfSensor { get; set; }

        public List<MeasurmentsTemperaturesDto> Measurments { get; set; } = new();
    }
}
