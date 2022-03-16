using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.DomainEvents;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        /// <summary>
        /// O evento genérico "T" precisa ser filho de "Event". Ex.: DomainEvent que é filho de Event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="evento"></param>
        /// <returns></returns>
        Task PublicarEvento<T>(T evento) where T : Event;

        /// <summary>
        /// O evento genérico "T" precisa ser filho de "Command"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comando"></param>
        /// <returns></returns>
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        
        /// <summary>
        /// O evento genérico "T" precisa ser filho de "DomainNotification"
        /// </summary>
        /// <param name="notificacao"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;

        /// <summary>
        /// O evento genérico "T" precisa ser filho de "DomainEvent"
        /// </summary>
        /// <param name="notificacao"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;

    }
}
