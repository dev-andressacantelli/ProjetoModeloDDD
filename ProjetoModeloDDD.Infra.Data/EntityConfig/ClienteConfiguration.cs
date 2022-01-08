using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {//Quando estiver criando a minha entidade de Cliente quero setar alguns comportamentos exclusivos da modelagem dessa tabela:
        public ClienteConfiguration()
        {   //Dando um padrão p/ essa entidade específica:
            HasKey(c => c.ClienteId); // c = cliente

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired();
        }
    }
}


