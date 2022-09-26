using MediatR;

namespace AspNet_MediatR1.Command
{
    public class ProdutoDeleteCommand : IRequest<string>
    {
        public int Id { get; private set; } 
    }
}
