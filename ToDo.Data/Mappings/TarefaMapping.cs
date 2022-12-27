using DevIO.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.Models;

namespace ToDo.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                        .IsRequired()
                        .HasColumnType("varchar(200)");

            builder.Property(p => p.Hr_planejado)
                        .IsRequired()
                        .HasColumnType("time");

            builder.Property(p => p.foiExecutada)
                        .IsRequired()
                        .HasColumnType("bit");

            // 1 : 1 => Fornecedor : Endereco
            builder.HasOne(f => f.LogPontuacao)
                .WithOne(e => e.Tarefa);

            builder.ToTable("Tarefas");
        }
    }
}
