using abccCoppel.Models;
using abccCoppel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace abccCoppel.Controllers
{
    public class ProductController : Controller
    {
        private readonly AbccCoppelContext _context;

        public ProductController(AbccCoppelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Clases"] = new SelectList(_context.Clases, "NumClase", "NombreClase");
            ViewData["Familias"] = new SelectList(_context.Familia, "NumFamilia", "NombreFamilia");
            ViewData["Departamentos"] = new SelectList(_context.Departamentos, "NumDepartamento", "NombreDepartamento");

            var productos = await _context.Productos.Include(p => p.NumDepartamentoNavigation).ToListAsync();
            var productosCla = await _context.Productos.Include(p => p.NumClaseNavigation).ToListAsync();
            var productosFam = await _context.Productos.Include(p => p.NumFamiliaNavigation).ToListAsync();
            return View(productos);
        }

        public IActionResult Create()
        {
            ViewData["Clases"] = new SelectList(_context.Clases, "NumClase", "NombreClase");
            ViewData["Familias"] = new SelectList(_context.Familia, "NumFamilia", "NombreFamilia");
            ViewData["Departamentos"] = new SelectList(_context.Departamentos, "NumDepartamento", "NombreDepartamento");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Producto()
                {
                    Articulo = model.Articulo,
                    Marca = model.Marca,
                    Modelo = model.Modelo,
                    Stock = model.Stock,
                    Cantidad = model.Cantidad,
                    FechaAlta = DateTime.Parse(model.FechaAlta.ToString("yyyy-MM-dd")),
                    Descontinuado = model.Descontinuado,
                    NumClase = model.ClaseId,
                    NumFamilia = model.FamiliaId,
                    NumDepartamento = model.DepartamentoId,
                };
                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewData["Clases"] = new SelectList(_context.Clases, "NumClase", "NombreClase", model.ClaseId);
            ViewData["Familias"] = new SelectList(_context.Familia, "NumFamilia", "NombreFamilia", model.FamiliaId);
            ViewData["Departamentos"] = new SelectList(_context.Departamentos, "NumDepartamento", "NombreDepartamento", model.DepartamentoId);
            return View(model);
        }
    }
}
