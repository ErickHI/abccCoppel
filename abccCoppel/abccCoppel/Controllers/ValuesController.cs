using abccCoppel.Models;
using abccCoppel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace abccCoppel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly AbccCoppelContext _context;

        public ValuesController(AbccCoppelContext context)
        {
            _context = context;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExample(int id, [FromBody] ProductViewModel productViewModel)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            producto.Articulo = productViewModel.Articulo;
            producto.Marca = productViewModel.Marca;
            producto.Modelo = productViewModel.Modelo;
            producto.FechaAlta = DateTime.Parse(productViewModel.FechaAlta.ToString("yyyy-MM-dd"));
            producto.Stock = productViewModel.Stock;
            producto.Cantidad = productViewModel.Cantidad;
            producto.Descontinuado = productViewModel.Descontinuado;
            producto.NumDepartamento = productViewModel.DepartamentoId;
            producto.NumClase = productViewModel.ClaseId;
            producto.NumFamilia = productViewModel.FamiliaId;

            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();

            return Ok("El producto se actualizo correctamente");
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExample(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok("El producto se eliminó correctamente.");
        }
    }
}
