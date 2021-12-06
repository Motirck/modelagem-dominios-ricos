namespace NerdStore.Core.DomainObjects
{
    public class DomainException : Exception
    {
        /// <summary>
        /// Construtor para apenas criar uma instância
        /// </summary>
        public DomainException()
        {

        }

        /// <summary>
        /// Recebe uma mensagem personalisada e "alimenta" a própria exception
        /// através do ":base(message)"
        /// </summary>
        /// <param name="message"></param>
        public DomainException(string message): base(message)
        {

        }

        /// <summary>
        /// Exceção que iniciou internamente.
        /// innnerException é uma exceção dentro de uma exceção.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public DomainException(string message, Exception innerException): base(message, innerException)
        {

        }
    }
}
