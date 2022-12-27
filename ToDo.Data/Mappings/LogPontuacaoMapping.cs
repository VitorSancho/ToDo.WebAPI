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
    public class LogPontuacaoMapping : IEntityTypeConfiguration<LogPontuacao>
    {
        public void Configure(EntityTypeBuilder<LogPontuacao> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Hr_execucao)
                        .IsRequired()
                        .HasColumnType("time");



            builder.ToTable("LogsPontucao");
        }
    }
}
