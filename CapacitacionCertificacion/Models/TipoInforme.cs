using System;
using System.Collections.Generic;

namespace CapacitacionCertificacion.Models;

public partial class TipoInforme
{
    public int IdTipoInforme { get; set; }

    public string? NombreTipo { get; set; }

    public virtual ICollection<InformesCumplimiento> InformesCumplimientos { get; set; } = new List<InformesCumplimiento>();
}
