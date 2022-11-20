using ZCaixaV5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZCaixaV5.Data.Mapeamentos
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Data)
               .IsRequired();
            builder.Property(t => t.Descricao);
            builder.Property(t => t.Tipo)
                .IsRequired();
            builder.Property(t => t.Valor)
                .IsRequired();
            builder.Property(t => t.Conciliado)
                .IsRequired();
            builder.Property(t => t.Username)
                .IsRequired(); 
            builder.Property(t => t.CatId)
                .IsRequired();

            builder.ToTable(nameof(Lancamento));

        }
    }
}
