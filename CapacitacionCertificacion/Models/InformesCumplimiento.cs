using System;
using System.Collections.Generic;

namespace CapacitacionCertificacion.Models;

public partial class InformesCumplimiento
{
    public int IdInfor { get; set; }

    public int IdTipoInforme { get; set; }

    public int IdEmp { get; set; }

    public string? DescripcionInfor { get; set; }

    public DateOnly FechaEmision { get; set; }

    public virtual Empleado IdEmpNavigation { get; set; } = null!;

    public virtual TipoInforme IdTipoInformeNavigation { get; set; } = null!;
}
