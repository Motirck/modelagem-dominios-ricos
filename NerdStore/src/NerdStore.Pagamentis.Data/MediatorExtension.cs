using NerdStore.Core.DomainObjects;
using NerdStore.Core.Communication.Mediator;

namespace NerdStore.Pagamentos.Data;

public static class MediatorExtension
{
    /// <summary>
    /// Extension Method para publicar uma lista de eventos
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="ctx"></param>
    public static async Task PublicarEventos(this IMediatorHandler mediator, PagamentoContext ctx)
    {
        /// Irá pegar todas as entidades dentro do ChangeTracker do context onde forem do tipo Entity
        /// onde elas possuem alguma notificação
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

        /// Selecionando todos os enventos de domínio 
        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.Notificacoes)
            .ToList();

        /// Transformando em uma lista e limpando os eventos em seguida
        domainEntities.ToList()
            .ForEach(entity => entity.Entity.LimparEventos());

        /// Os eventos ao serem selecionados na lista, serão publicados um a um
        var tasks = domainEvents
            .Select(async (domainEvent) =>
            {
                await mediator.PublicarEvento(domainEvent);
            });

        /// Somente irá retornar quando todos os eventos forem lançados
        await Task.WhenAll(tasks);
    }
}
