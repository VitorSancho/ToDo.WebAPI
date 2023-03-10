// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDo.Data.Context;

#nullable disable

namespace ToDo.WebAPI.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20221228013044_Initialmigration")]
    partial class Initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToDo.Business.Models.Dificuldade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Pontos")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Dificuldades", (string)null);
                });

            modelBuilder.Entity("ToDo.Business.Models.LogPontuacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Hr_execucao")
                        .HasColumnType("time");

                    b.Property<Guid>("TarefaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId")
                        .IsUnique();

                    b.ToTable("LogsPontucao", (string)null);
                });

            modelBuilder.Entity("ToDo.Business.Models.Tarefa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DificuldadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Hr_planejado")
                        .HasColumnType("time");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("foiExecutada")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DificuldadeId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tarefas", (string)null);
                });

            modelBuilder.Entity("ToDo.Business.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Hr_cadastroTarefas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("ToDo.Business.Models.LogPontuacao", b =>
                {
                    b.HasOne("ToDo.Business.Models.Tarefa", "Tarefa")
                        .WithOne("LogPontuacao")
                        .HasForeignKey("ToDo.Business.Models.LogPontuacao", "TarefaId")
                        .IsRequired();

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("ToDo.Business.Models.Tarefa", b =>
                {
                    b.HasOne("ToDo.Business.Models.Dificuldade", "Dificuldade")
                        .WithMany("Tarefa")
                        .HasForeignKey("DificuldadeId")
                        .IsRequired();

                    b.HasOne("ToDo.Business.Models.Usuario", "Usuario")
                        .WithMany("Tarefas")
                        .HasForeignKey("UsuarioId")
                        .IsRequired();

                    b.Navigation("Dificuldade");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ToDo.Business.Models.Dificuldade", b =>
                {
                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("ToDo.Business.Models.Tarefa", b =>
                {
                    b.Navigation("LogPontuacao")
                        .IsRequired();
                });

            modelBuilder.Entity("ToDo.Business.Models.Usuario", b =>
                {
                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
