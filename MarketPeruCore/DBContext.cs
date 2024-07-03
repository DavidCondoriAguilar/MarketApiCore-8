using Microsoft.EntityFrameworkCore;

namespace MarketPeruCore.Models
{
    public class MarketPeruContext : DbContext
    {
        public MarketPeruContext(DbContextOptions<MarketPeruContext> options)
            : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Guia> Guias { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Categoría
            modelBuilder.Entity<Categoria>()
                .HasIndex(c => c.Nombre)
                .IsUnique();

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Nombre)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Descripcion)
                .HasMaxLength(255)
                .IsRequired();

            // Configuración de Local
            modelBuilder.Entity<Local>()
                .HasIndex(l => l.Direccion)
                .IsUnique();

            modelBuilder.Entity<Local>()
                .Property(l => l.Direccion)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Local>()
                .Property(l => l.Distrito)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Local>()
                .Property(l => l.Telefono)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Local>()
                .Property(l => l.Fax)
                .HasMaxLength(15)
                .IsRequired();

            // Configuración de Producto
            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Nombre)
                .IsUnique();

            modelBuilder.Entity<Producto>()
                .Property(p => p.Nombre)
                .HasMaxLength(40)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .Property(p => p.UnidadMedida)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .Property(p => p.PrecioProveedor)
                .HasColumnType("money");

            // Configuración de Proveedor
            modelBuilder.Entity<Proveedor>()
                .HasIndex(p => p.Nombre)
                .IsUnique();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Nombre)
                .HasMaxLength(40)
                .IsRequired();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Representante)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Direccion)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Ciudad)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Departamento)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.CodigoPostal)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Telefono)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Fax)
                .HasMaxLength(15)
                .IsRequired();

            // Configuración de relaciones
            modelBuilder.Entity<Guia>()
                .HasOne(g => g.Local)
                .WithMany(l => l.Guias)
                .HasForeignKey(g => g.IdLocal)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Proveedor)
                .WithMany(pr => pr.Productos)
                .HasForeignKey(p => p.IdProveedor)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar valores predeterminados
            modelBuilder.Entity<Producto>()
                .Property(p => p.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.Estado)
                .HasDefaultValue(true);

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Estado)
                .HasDefaultValue(true);

            // Configurar conversiones de valores (si es necesario)
            // modelBuilder.Entity<Entidad>().Property(e => e.Propiedad).HasConversion(...);
        }
    }
}
