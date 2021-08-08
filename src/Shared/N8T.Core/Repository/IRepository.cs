using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using N8T.Core.Domain;
using N8T.Core.Specification;

namespace N8T.Core.Repository
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        Task<TAggregateRoot> Find(Guid id, CancellationToken token);
        ValueTask Add(TAggregateRoot aggregateRoot, CancellationToken token);
        ValueTask Update(TAggregateRoot aggregateRoot, CancellationToken token);
        ValueTask Delete(TAggregateRoot aggregateRoot, CancellationToken token);
    }

    public interface IQueryRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> FindOneAsync(ISpecification<TEntity> spec);
        Task<List<TEntity>> FindAsync(ISpecification<TEntity> spec);
    }

    public interface IGridRepository<TEntity> where TEntity : IAggregateRoot
    {
        ValueTask<long> CountAsync(IGridSpecification<TEntity> spec);
        Task<List<TEntity>> FindAsync(IGridSpecification<TEntity> spec);
    }
}
