using System;
using System.Collections.Generic;

namespace Domain.Entities.PomTemp;

public partial class Zmienna
{
    public long ZmiennaId { get; set; }

    public string Nazwa { get; set; } = null!;

    public string Opis { get; set; } = null!;

    public double ZakresAlarmMin { get; set; }

    public double ZakresAlarmMax { get; set; }

    public short UseAlarmMin { get; set; }

    public short UseAlarmMax { get; set; }

    public virtual ICollection<Granice> Granices { get; } = new List<Granice>();
}
