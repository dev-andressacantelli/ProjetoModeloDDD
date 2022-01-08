using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    public class ProjetoModeloContext : DbContext //Contexto de banco de dados do EntityFramework : herança DB;
    {
        public ProjetoModeloContext() //Construtor que leva o nome 
            : base("ProjetoModeloDDD")
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)//Método nativo, sobreescrevendo o método no bloco de código:
        {
            //Desabilitando convenções que não quero:
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Desabilita plural p/ executar tabelas em PTbr sem alterações de nome / inglês;
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Não quero que delete em casacata em relação 1:n;
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //Não quero que delete em casacata em relação n:n;

            /* Toda vez que eu tiver uma entidade não quero utilizar aquele padrão, 
            ou seja,  PK é ClienteID nesse projeto, mas nem sempre ele entende que ProdutoID tbm é uma PK, 
            então irei força-lo entender isso: */
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());
            //Toda vez que um campo for definido como ID, identifica-lo como PK.

            //Para não setar todas vez à mão o campo Nvarchar (que ocupa espaço), utilizar a config:
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar")); //TIPO

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100)); //TAMANHO

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }

        //Para não setar toda vez à mão o DataCadastro (update) p/ que o DateTimeNow seja dado, não ter que fzr na controller ou outro lugar:
        public override int SaveChanges()//Método nativo, sobreescrevendo o método no bloco de código:
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}


