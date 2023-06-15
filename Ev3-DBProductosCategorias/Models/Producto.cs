using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ev3_DBProductosCategorias.Models
{
	public class Producto
	{
		public int Id { get; set; }
		[MaxLength(100, ErrorMessage ="El valor maximo de caracteres de 100")]
		[MinLength(2, ErrorMessage = "El valor minimo de caracteres de 2")]
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public string Nombre { get; set; }
		[Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Precio no puede ser menor que cero")]
        public decimal Precio { get; set;}
        [Required(ErrorMessage = "Debe seleccionar una categoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría")]
        public int CategoriaId { get; set; }
		public Categoria? Categoria { get; set; }

	}
}
