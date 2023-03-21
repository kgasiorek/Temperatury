using System;
using System.Collections.Generic;

namespace Domain.Entities.PomTemp;

public partial class Komora
{
    public long KomoraId { get; set; }

    public DateTime Czas { get; set; }

    public int Nr { get; set; }

    public int Komora1 { get; set; }

    public double Temp1 { get; set; }

    public double Temp2 { get; set; }

    public int Status { get; set; }

    public int Aktywny { get; set; }

    public int Granice { get; set; }

    public int Bateria { get; set; }

    public DateTime? CzasStart { get; set; }

    public DateTime? CzasStop { get; set; }
}
