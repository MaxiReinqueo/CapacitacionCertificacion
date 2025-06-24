using System;
using System.Collections.Generic;

namespace CapacitacionCertificacion.Models;

public partial class TipoRecordatorio
{
    public int IdTipoRecord { get; set; }

    public string? DescripcionTipo { get; set; }

    public virtual ICollection<Recordatorio> Recordatorios { get; set; } = new List<Recordatorio>();
}
