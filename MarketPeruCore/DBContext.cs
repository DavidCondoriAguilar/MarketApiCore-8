using MarketPeruCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ServicioRestCore
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Guia> Guias { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<Orden> Ordenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir la relación uno a muchos entre Categoria y Producto
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria);

            // Definir la relación uno a muchos entre Proveedor y Producto
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Proveedor)
                .WithMany(pr => pr.Productos)
                .HasForeignKey(p => p.IdProveedor);

            // Definir la relación uno a muchos entre Local y Guia
            modelBuilder.Entity<Guia>()
                .HasOne(g => g.Local)
                .WithMany(l => l.Guias)
                .HasForeignKey(g => g.IdLocal);

            // Asegurar unicidad de nombres
            modelBuilder.Entity<Categoria>()
                .HasIndex(c => c.Nombre)
                .IsUnique();
            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Nombre)
                .IsUnique();
            modelBuilder.Entity<Proveedor>()
                .HasIndex(pr => pr.Nombre)
                .IsUnique();
        }
    }
}
