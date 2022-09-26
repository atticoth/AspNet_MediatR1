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
    public class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;

        public ProdutoUpdateCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto { Nome = request.Nome, Preco = request.Preco };

            try
            {
                await _repository.Edit(produto);
                await _mediator.Publish(new ProdutoUpdateNotification { Id = produto.Id, Nome = produto.Nome, Preco = produto.Preco});
                return await Task.FromResult("Produto alterado com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ProdutoUpdateNotification { Id = produto.Id, Nome = produto.Nome, Preco = produto.Preco });
                await _mediator.Publish(new ErroNotification{ Erro = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }
        }
    }
}
