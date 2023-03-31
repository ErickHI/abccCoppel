using System;
using System.Collections.Generic;

namespace abccCoppel.Models;

public partial class Familium
{
    public int NumFamilia { get; set; }

    public string NombreFamilia { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
