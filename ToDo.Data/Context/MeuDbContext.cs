using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Hosting;
using ToDo.Business.Models;

namespace ToDo.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Dificuldade> Dificuldades { get; set; }
        public DbSet<LogPontuacao> LogsPontuacao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.Entity<LogPontuacao>(builder =>
            {
                // Time is a TimeOnly property and time on database
                builder.Property(x => x.Hr_execucao)
                    .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
            });


            modelBuilder.Entity<Tarefa>(builder =>
            {
                // Time is a TimeOnly property and time on database
                builder.Property(x => x.Hr_planejado)
                    .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
            });

            base.OnModelCreating(modelBuilder);
        }

    }

    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
                timeOnly => timeOnly.ToTimeSpan(),
                timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        {
        }
    }

    public class TimeOnlyComparer : ValueComparer<TimeOnly>
    {
        public TimeOnlyComparer() : base(
            (t1, t2) => t1.Ticks == t2.Ticks,
            t => t.GetHashCode())
        {
        }
    }
}
