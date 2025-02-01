using System;
using System.Collections.Generic;

namespace Prueba_JaramilloFabiana.Models;

public partial class Respuestum
{
    public int Id { get; set; }

    public int CampoId { get; set; }

    public string Valor { get; set; } = null!;

    public int? RegistroId { get; set; }

    public virtual Campo Campo { get; set; } = null!;

    public virtual Registro? Registro { get; set; }
}
