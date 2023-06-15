using Microsoft.EntityFrameworkCore;

namespace Ev3_DBProductosCategorias.Models
{
	public class SupermercadoContext : DbContext
	{
		public SupermercadoContext(DbContextOptions<SupermercadoContext> options) : base(options) { }
		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<Producto> Productos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Producto>()
				.HasOne(p => p.Categoria)
				.WithMany(c => c.Productos)
				.HasForeignKey(p => p.CategoriaId);
		}
	}
}
