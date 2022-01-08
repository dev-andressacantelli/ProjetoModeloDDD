using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {//Quando estiver criando a minha entidade de Produto quero setar alguns comportamentos exclusivos da modelagem dessa tabela:

        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoId); // p = produto

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Valor)
                .IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId); //Relacionamento entre tabelas, ClienteId é a FK de Produto;
        }
    }
}



