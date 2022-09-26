using MediatR;

namespace AspNet_MediatR1.Notification
{
    public class ErroNotification : INotification
    {
        public string Erro { get; set; }
        public string PilhaErro { get; set; }
    }
}
