using Microsoft.AspNetCore.Mvc;
using Ev3_DBProductosCategorias.Models;
using Microsoft.EntityFrameworkCore;

namespace Ev3_DBProductosCategorias.Controllers
{
	public class CategoriaController : Controller
	{
		public SupermercadoContext context;
		public CategoriaController(SupermercadoContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			List<Categoria> categorias = context.Categorias.Include(i => i.Productos).ToList();


			return View(categorias);
		}
		public IActionResult Create()
		{
			Categoria categoria = new Categoria();
			return View(categoria);
		}

        public IActionResult Save(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
            else
            {
                return View("Create", categoria);
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
