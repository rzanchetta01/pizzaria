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
        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            PizzasCreating(model);
            BebidasCreating(model);
            AvaliacoesCreating(model);
            ClienteCreating(model);
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

                entity.Property(x => x.QntFatias)
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

                entity.Property(x => x.IdPizza)
                .HasColumnName("id_pizza");

                entity.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnName("id");

                entity.Property(x => x.Rating)
                .IsRequired(true)
                .HasColumnName("rating");

                entity.Property(x => x.Comentario)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("comentarios");
            });     
        }

        public void ClienteCreating(ModelBuilder model)
        {
            model.Entity<Cliente>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

                entity.Property(p => p.PrimeiroNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired(true)
                .HasColumnName("primeiro_nome");

                entity.Property(p => p.SegundoNome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .IsRequired(true)
                .HasColumnName("segundo_nome");

                entity.Property(p => p.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .IsRequired(true)
                .HasColumnName("email");

                entity.Property(p => p.Senha)
                .HasMaxLength(25)
                .IsUnicode(true)
                .IsRequired(true)
                .HasColumnName("senha");

            });
        }
    }
}
