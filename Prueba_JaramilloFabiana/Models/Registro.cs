using System;
using System.Collections.Generic;

namespace Prueba_JaramilloFabiana.Models;

public partial class Registro
{
    public int Id { get; set; }

    public int? FormularioId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Respuestum> Respuesta { get; set; } = new List<Respuestum>();
}
