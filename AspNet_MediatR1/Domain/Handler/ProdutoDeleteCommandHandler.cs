using AspNet_MediatR1.Domain.Command;
using AspNet_MediatR1.Domain.Entity;
using AspNet_MediatR1.Notification;
using AspNet_MediatR1.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNet_MediatR1.Domain.Handler
{
    public class ProdutoDeleteCommandHandler : IRequestHandler<ProdutoDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;

        public ProdutoDeleteCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(ProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);
                await _mediator.Publish(new ProdutoDeleteNotification { Id = request.Id, IsConcluido = true });
                return await Task.FromResult("Produto excluido com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ProdutoDeleteNotification { Id = request.Id, IsConcluido = false });
                await _mediator.Publish(new ErroNotification { Erro = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }
        }
    }
}
