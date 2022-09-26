using MediatR;

namespace AspNet_MediatR1.Command
{
    public class ProdutoCreateCommand : IRequest<string>
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
    }
}
