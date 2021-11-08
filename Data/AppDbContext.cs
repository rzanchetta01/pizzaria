using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pizzaria.Model;

namespace Pizzaria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Bebida> Bebidas { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Avaliacao> AvaliacaosDb { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            PizzasCreating(model);
            BebidasCreating(model);
            AvaliacoesCreating(model);
        }

        public void PizzasCreating(ModelBuilder model)
        {
            model.Entity<Pizza>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnName("id");

                entity.Property(x => x.Nome)
                .HasMaxLength(150)
                .IsUnicode(false)
                .IsRequired(true)
                .HasColumnName("nome_pizza");

                entity.Property(x => x.Descricao)
                .HasMaxLength(300)
                .IsUnicode(false)
                .IsRequired(true)
                .HasColumnName("descricao_pizza");

                entity.Property(x => x.Tamanho)
                .IsRequired(true)
                .HasColumnName("tamanho_pizza");

                entity.Property(x => x.Preco)
                .IsRequired(true)
                .HasColumnName("preco_pizza");

            });
        }

        public void BebidasCreating(ModelBuilder model)
        {
            model.Entity<Bebida>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnName("id");

                entity.Property(x => x.Nome)
                .HasMaxLength(150)
                .IsUnicode(false)
                .IsRequired(true)
                .HasColumnName("nome_bebida");

                entity.Property(x => x.Descricao)
                .HasMaxLength(300)
                .IsUnicode(false)
                .IsRequired(true)
                .HasColumnName("descricao_bebida");

                entity.Property(x => x.Tamanho)
                .IsRequired(true)
                .HasColumnName("tamanho_bebida");

                entity.Property(x => x.Preco)
                .IsRequired(true)
                .HasColumnName("preco_bebida");
            });
        }

        public void AvaliacoesCreating(ModelBuilder model)
        {
            model.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(r => r.idPizzaRelation)
                .WithMany(e => e.Avaliacoes)
                .HasForeignKey(r => r.IdPizza)
                .HasConstraintName("fk_avaliacao_pizza")
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnName("id");

                entity.Property(x => x.Rating)
                .IsRequired(true)
                .HasColumnName("rating");

                entity.Property(x => x.Comentario)
                .HasMaxLength(400)
                .IsUnicode(false)
                .IsRequired(true)
                .HasColumnName("comentarios");
            });     
        } 
    }
}
