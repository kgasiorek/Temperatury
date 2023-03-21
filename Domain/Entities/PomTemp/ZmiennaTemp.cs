using System;
using System.Collections.Generic;

namespace Domain.Entities.PomTemp;

public partial class ZmiennaTemp
{
    public long ZmiennaTempId { get; set; }

    public string Nazwa { get; set; } = null!;

    public string Opis { get; set; } = null!;

    public double ZakresAlarmMin { get; set; }

    public double ZakresAlarmMax { get; set; }

    public bool UseAlarmMin { get; set; }

    public bool UseAlarmMax { get; set; }
}
