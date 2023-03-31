using System;
using System.Collections.Generic;

namespace abccCoppel.Models;

public partial class Clase
{
    public int NumClase { get; set; }

    public string NombreClase { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
