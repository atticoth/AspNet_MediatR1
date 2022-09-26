using MediatR;

namespace AspNet_MediatR1.Domain.Command
{
    public class ProdutoDeleteCommand : IRequest<string>
    {
        public int Id { get; set; } 
    }
}
