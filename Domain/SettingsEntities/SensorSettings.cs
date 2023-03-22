using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SettingsEntities;

public class SensorSettings
{
    public int Id { get; set; }
    public string? OriginalName { get; set; }
    public string? Description { get; set; }
    public double MinTemp { get; set; }
    public double MaxTemp { get; set; }
    public bool MinAlarmEnabled { get; set; }
    public bool MaxAlarmEnabled { get; set; }

    public int? RoomId { get; set; }
    public virtual Room? Room { get; set; }

    public int? TypeOfSensorId { get; set; }
    public TypeOfSensor? TypeOfSensor { get; set; }
}
