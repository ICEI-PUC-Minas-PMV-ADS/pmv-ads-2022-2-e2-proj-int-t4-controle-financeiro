using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ZCaixaV5.Models;
using ZCaixaV5.Data.Mapeamentos;



namespace ZCaixaV5.Api.Data
{
    public class ZCaixaContexto : DbContext
    {
        public ZCaixaContexto(DbContextOptions<ZCaixaContexto> options)
            : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Categoria> TTTTT { get; set; }

        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new LancamentoMap());
            //modelBuilder.Entity<Usuario>().ToTable("Usuario");
            //modelBuilder.Entity<Categoria>().ToTable("Categoria");
            //modelBuilder.Entity<Lancamento>().ToTable("Lancamento");
        }

        public DbSet<ZCaixaV5.Models.TTTTT> TTTTT_1 { get; set; }
    }
}
