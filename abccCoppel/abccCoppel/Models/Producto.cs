using System;
using System.Collections.Generic;

namespace abccCoppel.Models;

public partial class Producto
{
    public int Sku { get; set; }

    public string Articulo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int NumDepartamento { get; set; }

    public int NumClase { get; set; }

    public int NumFamilia { get; set; }

    public DateTime FechaAlta { get; set; }

    public int Stock { get; set; }

    public int Cantidad { get; set; }

    public int Descontinuado { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual Clase NumClaseNavigation { get; set; } = null!;

    public virtual Departamento NumDepartamentoNavigation { get; set; } = null!;

    public virtual Familium NumFamiliaNavigation { get; set; } = null!;
}
