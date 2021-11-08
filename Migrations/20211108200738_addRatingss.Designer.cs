﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzaria.Data;

#nullable disable

namespace Pizzaria.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211108200738_addRatingss")]
    partial class addRatingss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pizzaria.Model.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(400)
                        .IsUnicode(false)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("comentarios");

                    b.Property<int>("IdPizza")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.HasKey("Id");

                    b.HasIndex("IdPizza");

                    b.ToTable("AvaliacaosDb");
                });

            modelBuilder.Entity("Pizzaria.Model.Bebida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("descricao_bebida");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome_bebida");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("preco_bebida");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int")
                        .HasColumnName("tamanho_bebida");

                    b.HasKey("Id");

                    b.ToTable("Bebidas");
                });

            modelBuilder.Entity("Pizzaria.Model.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("descricao_pizza");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome_pizza");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("preco_pizza");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int")
                        .HasColumnName("tamanho_pizza");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("Pizzaria.Model.Avaliacao", b =>
                {
                    b.HasOne("Pizzaria.Model.Pizza", "idPizzaRelation")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("IdPizza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_avaliacao_pizza");

                    b.Navigation("idPizzaRelation");
                });

            modelBuilder.Entity("Pizzaria.Model.Pizza", b =>
                {
                    b.Navigation("Avaliacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
