using ZCaixaV5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZCaixaV5.Data.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.HasKey(t => t.Username);

            builder.Property(t => t.Nome)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.UltimoNome)
                .HasMaxLength(150)
                .IsRequired(false);
            builder.Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(t => t.Email)
                .IsRequired();
            builder.Property(t => t.Telefone)
                .HasMaxLength(11);
            builder.Property(t => t.DataNascimento);


            builder.ToTable(nameof(Usuario));

        }
    }
}
