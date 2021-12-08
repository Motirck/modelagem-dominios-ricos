using MediatR;

namespace NerdStore.Core.Messages
{
    /// <summary>
    /// INotification é uma interface de marcação, utilizada apenas com o intuito de
    /// "marcar" a classe evento como uma classe responsável por uma Notificação
    /// </summary>
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
