using System.Linq.Expressions;

namespace Catalog.API.Domain.Specifications
{
    public static class SortSpecification
    {
        public static IQueryable<T> AddSorting<T>( this IQueryable<T> query, SortDirection sortDirection, string propertyName)
        {
            var param = Expression.Parameter(typeof(T));
            var prop = Expression.PropertyOrField(param, propertyName);
            var sortLambda = Expression.Lambda(prop, param);

            Expression<Func<IOrderedQueryable<T>>> sortMethod = null;

            switch (sortDirection)
            {
                case SortDirection.Ascending when query.Expression.Type == typeof(IOrderedQueryable<T>):
                    sortMethod = () => ((IOrderedQueryable<T>)query).ThenBy<T, object>(k => null);
                    break;
                case SortDirection.Ascending:
                    sortMethod = () => query.OrderBy<T, object>(k => null);
                    break;
                case SortDirection.Descending when query.Expression.Type == typeof(IOrderedQueryable<T>):
                    sortMethod = () => ((IOrderedQueryable<T>)query).ThenByDescending<T, object>(k => null);
                    break;
                case SortDirection.Descending:
                    sortMethod = () => query.OrderByDescending<T, object>(k => null);
                    break;
            }

            var methodCallExpression = (sortMethod.Body as MethodCallExpression);
            if (methodCallExpression == null)
                throw new Exception("MethodCallExpression null");

            var method = methodCallExpression.Method.GetGenericMethodDefinition();
            var genericSortMethod = method.MakeGenericMethod(typeof(T), prop.Type);
           return (IOrderedQueryable<T>)genericSortMethod.Invoke(query, new object[] { query, sortLambda }) ;
       
        }
    }
}
