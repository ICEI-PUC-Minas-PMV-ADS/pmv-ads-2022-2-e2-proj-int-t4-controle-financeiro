﻿using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
        
    }
}
