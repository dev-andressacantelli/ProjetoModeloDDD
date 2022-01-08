using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;


namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        //Além do CRUD, faz uma pesquisa especial;
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
