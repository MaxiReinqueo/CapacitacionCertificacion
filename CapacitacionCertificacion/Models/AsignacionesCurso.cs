using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapacitacionCertificacion.Models;

public partial class AsignacionesCurso
{
    public int IdAsign { get; set; }

    public int IdEmp { get; set; }

    public int IdCurso { get; set; }

    [Display(Name = "Fecha de la Asignación")]

    public DateOnly FechaAsign { get; set; }

    [Display(Name = "Estado")]

    public string Estado { get; set; } = null!;

    [Display(Name = "Finalización de la Asignación")]

    public DateOnly? FechaFinalizacion { get; set; }

    public virtual ICollection<Certificacione> Certificaciones { get; set; } = new List<Certificacione>();

    public virtual ICollection<EvaluacionesSatisfaccion> EvaluacionesSatisfaccions { get; set; } = new List<EvaluacionesSatisfaccion>();

    public virtual Curso? IdCursoNavigation { get; set; } 

    public virtual Empleado? IdEmpNavigation { get; set; }
}
