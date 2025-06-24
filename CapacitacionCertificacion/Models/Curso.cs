using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapacitacionCertificacion.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public int IdPg { get; set; }

    [Display(Name = "Nombre del Curso")]

    public string NombreCurso { get; set; } = null!;

    [Display(Name = "Modalidad")]

    public string? Modalidad { get; set; }

    [Display(Name = "Duración Curso (Horas)")]

    public int? DuracionHoras { get; set; }

    public virtual ICollection<AsignacionesCurso> AsignacionesCursos { get; set; } = new List<AsignacionesCurso>();

    public virtual Programa? IdPgNavigation { get; set; } 
}
