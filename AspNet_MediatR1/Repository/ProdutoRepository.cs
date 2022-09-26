using AspNet_MediatR1.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_MediatR1.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private static Dictionary<int, Produto> _produtos = new Dictionary<int, Produto>();

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await Task.Run(() => _produtos.Values.ToList());
        }

        public async Task<Produto> Get(int id)
        {
            return await Task.Run(() => _produtos.GetValueOrDefault(id));
        }

        public async Task Add(Produto produto)
        {
            await Task.Run(() => _produtos.Add(produto.Id, produto));
        }

        public async Task Edit(Produto produto)
        {
            await Task.Run(() =>
            {
                _produtos.Remove(produto.Id);
                _produtos.Add(produto.Id, produto);
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => _produtos.Remove(id));
        }
    }
}
