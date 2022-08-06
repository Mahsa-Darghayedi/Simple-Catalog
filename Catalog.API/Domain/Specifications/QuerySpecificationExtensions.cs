using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Domain.Specifications
{
    public static class QuerySpecificationExtensions
    {
        public static IQueryable<TEntity> Specify<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> spec) where TEntity : class
        {
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending != null)
                query = query.OrderByDescending(spec.OrderByDescending);

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
