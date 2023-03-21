using System;
using System.Collections.Generic;

namespace Domain.Entities.PomTemp;

public partial class Operator
{
    public long OperatorId { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Haslo { get; set; } = null!;

    public string Uprawnienia { get; set; } = null!;
}
