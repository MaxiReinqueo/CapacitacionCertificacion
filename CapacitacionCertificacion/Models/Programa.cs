using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapacitacionCertificacion.Models;

public partial class Programa
{
    public int IdPg { get; set; }

    [Display(Name = "Nombre")]
    public string NombrePg { get; set; } = null!;

    [Display(Name = "Descripción")]
    public string DescripcionPg { get; set; } = null!;

    [Display(Name = "Fecha de Inicio")]
    public DateOnly FechaInicioPg { get; set; }

    [Display(Name = "Fecha de Fin")]
    public DateOnly FechaFinPg { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
