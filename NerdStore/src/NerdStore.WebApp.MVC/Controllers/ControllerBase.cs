using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        /// <summary>
        /// O DomainNotificationHandler implementa o INotificationHandler que faz com que seja obrigatório
        /// a implementação do método Handle, então a injeção de depenência teve que ser da classe DomainNotificationHandler
        /// pois se fosse injetada a INotificationHandler o único método que poderia ser acessado seria o Handle,
        /// não sendo possível acessar os outros (ObterNotificacoes, TemNotificacao, etc)
        /// </summary>
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected ControllerBase(INotificationHandler<DomainNotification> notifications, 
                                 IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }
        
        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }
    }
}