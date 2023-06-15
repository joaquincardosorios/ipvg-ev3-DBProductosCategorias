using Ev3_DBProductosCategorias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ev3_DBProductosCategorias.Controllers
{
	public class ProductoController : Controller
	{
        public SupermercadoContext context;
        public ProductoController(SupermercadoContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
		{
            List<Producto> productos = context.Productos.Include(i => i.Categoria).ToList();

            return View(productos);
		}

        public IActionResult Create()
        {
            List<Categoria> categorias = context.Categorias.ToList();
            ViewBag.Categorias = categorias;
            Producto producto = new Producto();
            return View(producto);
        }

        public IActionResult Save(Producto producto)
        {
            if (ModelState.IsValid)
            {
                context.Productos.Add(producto);
                context.SaveChanges();
            }
            else
            {
                if(producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Debe seleccionar una categoría");
                }
                List<Categoria> categorias = context.Categorias.ToList();
                ViewBag.Categorias = categorias;
                return View("Create", producto);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
