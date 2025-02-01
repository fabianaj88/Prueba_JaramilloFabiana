using System;
using System.Collections.Generic;

namespace Prueba_JaramilloFabiana.Models;

public partial class Campo
{
    public int Id { get; set; }

    public int FormularioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public virtual Formulario? Formulario { get; set; }

    public virtual ICollection<Respuestum>? Respuesta { get; set; }
}
