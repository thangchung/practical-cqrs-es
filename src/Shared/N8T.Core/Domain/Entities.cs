using System;
using System.Collections.Concurrent;

namespace N8T.Core.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }

    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
        IDomainEvent[] DequeueUncommittedEvents();
    }

    public interface IProjection
    {
        void When(object @event);
    }

    public interface ITxRequest { }

    public abstract class AggregateRoot : IAggregateRoot
    {
        private ConcurrentQueue<IDomainEvent> UncommittedDomainEvents { get; set; }

        public void Enqueue(IDomainEvent eventItem)
        {
            UncommittedDomainEvents ??= new ConcurrentQueue<IDomainEvent>();
            UncommittedDomainEvents.Enqueue(eventItem);
        }

        public IDomainEvent[] DequeueUncommittedEvents()
        {
            var dequeuedEvents = UncommittedDomainEvents.ToArray();

            UncommittedDomainEvents.Clear();

            return dequeuedEvents;
        }

        public Guid Id { get; protected set; }= default!;
        public int Version { get; protected set; }
    }
}
