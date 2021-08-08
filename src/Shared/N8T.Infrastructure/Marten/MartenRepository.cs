using System;
using System.Threading;
using System.Threading.Tasks;
using Marten;
using N8T.Core.Domain;
using N8T.Core.Repository;
using N8T.Infrastructure.Bus;

namespace N8T.Infrastructure.Marten
{
    public class MartenRepository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private readonly IDocumentSession _documentSession;
        private readonly IEventBus _eventBus;

        public MartenRepository(IDocumentSession documentSession, IEventBus eventBus)
        {
            _documentSession = documentSession ?? throw new ArgumentNullException(nameof(documentSession));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public Task<TAggregateRoot> Find(Guid id, CancellationToken token)
        {
            return _documentSession.Events.AggregateStreamAsync<TAggregateRoot>(id, token:token);
        }

        public ValueTask Add(TAggregateRoot aggregateRoot, CancellationToken token)
        {
            return Store(aggregateRoot, token);
        }

        public ValueTask Update(TAggregateRoot aggregateRoot, CancellationToken token)
        {
            return Store(aggregateRoot, token);
        }

        public ValueTask Delete(TAggregateRoot aggregateRoot, CancellationToken token)
        {
            return Store(aggregateRoot, token);
        }

        private async ValueTask Store(TAggregateRoot aggregate, CancellationToken cancellationToken)
        {
            var events = aggregate.DequeueUncommittedEvents();
            _documentSession.Events.Append(
                aggregate.Id,
                events
            );
            await _documentSession.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in events)
            {
                if (domainEvent is IExternalEvent)
                {
                    await _eventBus.PublishAsync(domainEvent, token: cancellationToken);
                }
            }
        }
    }
}
