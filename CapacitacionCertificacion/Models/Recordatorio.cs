using System;
using System.Collections.Generic;

namespace CapacitacionCertificacion.Models;

public partial class Recordatorio
{
    public int IdRecord { get; set; }

    public int IdEmp { get; set; }

    public int IdTipoRecord { get; set; }

    public DateOnly FechaEjecucion { get; set; }

    public string? MensajeRecord { get; set; }

    public virtual Empleado IdEmpNavigation { get; set; } = null!;

    public virtual TipoRecordatorio IdTipoRecordNavigation { get; set; } = null!;
}
