using System;
using System.Collections.Generic;

namespace Domain.Entities.PomTemp;

public partial class Email
{
    public long EmailId { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public bool Aktywny { get; set; }
}
