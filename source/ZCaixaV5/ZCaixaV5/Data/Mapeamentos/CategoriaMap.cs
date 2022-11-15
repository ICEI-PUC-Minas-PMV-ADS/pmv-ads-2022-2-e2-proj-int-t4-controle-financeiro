using ZCaixaV5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZCaixaV5.Data.Mapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            builder.HasKey(t => t.Id);
                

            builder.Property(t => t.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Tipo)
                .IsRequired();
            builder.Property(t => t.Username)
                .IsRequired();
            
            builder.ToTable(nameof(Categoria));

        }
    }
}
