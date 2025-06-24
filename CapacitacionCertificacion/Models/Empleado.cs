using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapacitacionCertificacion.Models;

public partial class Empleado
{
    public int IdEmp { get; set; }

    [Display(Name = "Nombre")]
    public string NombreEmp { get; set; } = null!;

    [Display(Name = "Correo")]
    public string CorreoEmp { get; set; } = null!;

    [Display(Name = "Departamento")]
    public string? Departamento { get; set; }

    [Display(Name = "Fecha de Contratación")]
    public DateOnly FechaContratacion { get; set; }

    public virtual ICollection<AsignacionesCurso> AsignacionesCursos { get; set; } = new List<AsignacionesCurso>();

    public virtual ICollection<InformesCumplimiento> InformesCumplimientos { get; set; } = new List<InformesCumplimiento>();

    public virtual ICollection<Recordatorio> Recordatorios { get; set; } = new List<Recordatorio>();
}
