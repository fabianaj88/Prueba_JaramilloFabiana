using System;
using System.Collections.Generic;

namespace Prueba_JaramilloFabiana.Models;

public partial class Formulario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Campo> Campos { get; set; } = new List<Campo>();
}
