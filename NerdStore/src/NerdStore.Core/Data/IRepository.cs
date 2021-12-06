using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Data
{
    /// <summary>
    /// Herda do IDisposable para realização do Dispose, onde o tipo T é do tipo
    /// IAgregateRoot. Com isso é possível atender a regra de um único repositório
    /// por agregação.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  interface IRepository<T> : IDisposable where T : IAgregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
