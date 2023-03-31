using System;
using System.Collections.Generic;

namespace abccCoppel.Models;

public partial class Departamento
{
    public int NumDepartamento { get; set; }

    public string NombreDepartamento { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
