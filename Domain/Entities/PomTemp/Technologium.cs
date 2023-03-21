using System;
using System.Collections.Generic;

namespace Domain.Entities.PomTemp;

public partial class Technologium
{
    public long? TechnologiaId { get; set; }

    public DateTime? Czas { get; set; }

    public double? Pom1 { get; set; }

    public int Pom1Status { get; set; }

    public double Pom1Max { get; set; }

    public double Pom1Min { get; set; }

    public double? Pom2 { get; set; }

    public double? Pom2Max { get; set; }

    public int? Pom2Status { get; set; }

    public double? Pom2Min { get; set; }

    public double? Pom3 { get; set; }

    public double? Pom3Max { get; set; }

    public int? Pom3Status { get; set; }

    public double? Pom3Min { get; set; }

    public double? Pom4 { get; set; }

    public double? Pom4Max { get; set; }

    public int? Pom4Status { get; set; }

    public double? Pom4Min { get; set; }
}
