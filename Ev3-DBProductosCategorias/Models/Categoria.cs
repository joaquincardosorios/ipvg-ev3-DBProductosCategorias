using System.ComponentModel.DataAnnotations;

namespace Ev3_DBProductosCategorias.Models
{
	public class Categoria
	{
		public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la categoria es obligatoria")]
        [MinLength(2, ErrorMessage = "El minimo son 2 caracteres")]
        [MaxLength(50, ErrorMessage = "El maximo son 50 caracteres")]
		public string Nombre { get; set; }

		public ICollection<Producto>? Productos { get; set; }

	}
}
