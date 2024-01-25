using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Application.Helpers
{
    public static class PredicateHelper
    {
        public static bool IsValidColumn(string columnName)
        {
            var movieType = typeof(Claim);
            var properties = movieType.GetProperties().Select(p => p.Name);
            return properties.Contains(columnName);
        }

        public static Expression<Func<Claim, bool>> BuildPredicate(string filterColumn, string filterValue)
        {
            var parameter = Expression.Parameter(typeof(Claim), "movie");
            var property = Expression.Property(parameter, filterColumn);
            var constant = Expression.Constant(filterValue);
            var equality = Expression.Equal(property, constant);

            return Expression.Lambda<Func<Claim, bool>>(equality, parameter);
        }

        public static Expression<Func<IQueryable<Claim>, IOrderedQueryable<Claim>>> BuildSortingExpression(string orderBy)
        {
            var movieType = typeof(Claim);
            var parameter = Expression.Parameter(typeof(IQueryable<Claim>), "movies");

            // Get the property to sort by based on the 'orderBy' string
            var property = Expression.Property(parameter, orderBy);

            // Create a lambda expression for sorting
            var lambda = Expression.Lambda<Func<IQueryable<Claim>, IOrderedQueryable<Claim>>>(
                Expression.Call(
                    typeof(Queryable),
                    "OrderBy",
                    new[] { typeof(Claim), property.Type },
                    parameter,
                    Expression.Quote(Expression.Lambda(property, parameter))
                ),
                parameter
            );

            return lambda;
        }
    }
}
