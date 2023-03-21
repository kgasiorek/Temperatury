using System;
using System.Collections.Generic;

namespace Domain.Entities.PomTemp;

public partial class Granice
{
    public long GraniceId { get; set; }

    public long? ZmiennaFk { get; set; }

    public DateTime CzasStart { get; set; }

    public DateTime CzasStop { get; set; }

    public double GranicaMin { get; set; }

    public double GranicaMax { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual Zmienna? ZmiennaFkNavigation { get; set; }
}
