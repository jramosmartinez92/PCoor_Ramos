using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCoor_Ramos.Domain.Entities;

namespace PCoor_Ramos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet por entidad
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Consumidor> Consumidores { get; set; }
        public DbSet<Reclamo> Reclamos { get; set; }
        public DbSet<Asesoria> Asesorias { get; set; }
        public DbSet<Aviso> Avisos { get; set; }
        public DbSet<Propuesta> Propuestas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // =====================
            // 
            // =====================

            modelBuilder.Entity<Estado>().ToTable("c_Estado");
            modelBuilder.Entity<Empleado>().ToTable("c_Empleado");
            modelBuilder.Entity<Consumidor>().ToTable("c_Consumidor");
            modelBuilder.Entity<Reclamo>().ToTable("t_Reclamo");
            modelBuilder.Entity<Asesoria>().ToTable("t_Asesoria");
            modelBuilder.Entity<Aviso>().ToTable("t_Aviso");
            modelBuilder.Entity<Propuesta>().ToTable("t_Propuesta");

            base.OnModelCreating(modelBuilder);

            // =====================
            // Logica del modelo (Jose Ramos) 
            // Aplicacione de cardinalidad 
            // Aplicacion de unicidad (Usuario, Dui)
            // =====================

            // Empleado: usuario único
            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Usuario)
                .IsUnique();

            // Consumidor: DUI único
            modelBuilder.Entity<Consumidor>()
                .HasIndex(c => c.Dui)
                .IsUnique();

            // Reclamo → Asesoria (1:1)
            modelBuilder.Entity<Reclamo>()
                .HasOne(r => r.Asesoria)
                .WithOne(a => a.Reclamo)
                .HasForeignKey<Asesoria>(a => a.ReclamoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Reclamo → Aviso (1:1)
            modelBuilder.Entity<Reclamo>()
                .HasOne(r => r.Aviso)
                .WithOne(a => a.Reclamo)
                .HasForeignKey<Aviso>(a => a.ReclamoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Reclamo → Propuesta (1:1)
            modelBuilder.Entity<Reclamo>()
                .HasOne(r => r.Propuesta)
                .WithOne(p => p.Reclamo)
                .HasForeignKey<Propuesta>(p => p.ReclamoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones N:1 Reclamo con Estado, Empleado y Consumidor
            modelBuilder.Entity<Reclamo>()
                .HasOne(r => r.Estado)
                .WithMany(e => e.Reclamos)
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reclamo>()
                .HasOne(r => r.Empleado)
                .WithMany(e => e.Reclamos)
                .HasForeignKey(r => r.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reclamo>()
                .HasOne(r => r.Consumidor)
                .WithMany(c => c.Reclamos)
                .HasForeignKey(r => r.ConsumidorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
