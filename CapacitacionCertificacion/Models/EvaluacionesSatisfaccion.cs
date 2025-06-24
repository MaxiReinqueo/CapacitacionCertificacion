using System;
using System.Collections.Generic;

namespace CapacitacionCertificacion.Models;

public partial class EvaluacionesSatisfaccion
{
    public int IdEva { get; set; }

    public int IdAsign { get; set; }

    public int? Puntaje { get; set; }

    public string? Comentario { get; set; }

    public DateOnly FechaEva { get; set; }

    public virtual AsignacionesCurso IdAsignNavigation { get; set; } = null!;
}
