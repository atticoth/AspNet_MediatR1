using MediatR;

namespace AspNet_MediatR1.Domain.Command
{
    public class ProdutoCreateCommand : IRequest<string>
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
    }
}
