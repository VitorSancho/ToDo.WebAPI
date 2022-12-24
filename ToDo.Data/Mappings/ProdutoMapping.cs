using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.ViewModels;

namespace ToDo.Data.Mappings
{
    public class ProdutoMapping: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                        .IsRequired()
                        .HasColumnType("varchar(200)");

            builder.Property(p => p.Email)
                        .IsRequired()
                        .HasColumnType("varchar(200)");


            builder.Property(p => p.Celular)
                        .IsRequired()
                        .HasColumnType("varchar(200)");


            builder.Property(p => p.Hr_cadastroTarefas)
                        .IsRequired()
                        .HasColumnType("time");


            builder.Property(p => p.CEP)
                        .IsRequired()
                        .HasColumnType("varchar(200)");

            builder.ToTable("Produtos");
        }
    }
}
