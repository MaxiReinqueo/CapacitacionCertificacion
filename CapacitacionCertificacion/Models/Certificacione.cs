using System;
using System.Collections.Generic;

namespace CapacitacionCertificacion.Models;

public partial class Certificacione
{
    public int IdCert { get; set; }

    public int IdAsign { get; set; }

    public DateOnly FechaEmision { get; set; }

    public DateOnly? FechaExpiracion { get; set; }

    public string? DescripcionCer { get; set; }

    public virtual AsignacionesCurso IdAsignNavigation { get; set; } = null!;
}
