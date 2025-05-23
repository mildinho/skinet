using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            // Apply criteria
            if (specification.Criteria != null)
            {
                inputQuery = inputQuery.Where(specification.Criteria);
            }


            // Apply ordering
            if (specification.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(specification.OrderBy);
            }
            if (specification.OrderByDescending != null)
            {
                inputQuery = inputQuery.OrderByDescending(specification.OrderByDescending);
            }

            // Apply distinct
            if (specification.IsDistinct)
            {
                inputQuery = inputQuery.Distinct();
            }


            //// Apply paging
            //if (specification.IsPagingEnabled)
            //{
            //    query = query.Skip(specification.Skip).Take(specification.Take);
            //}
            //// Apply includes
            //foreach (var include in specification.Includes)
            //{
            //    query = query.Include(include);
            //}
            return inputQuery;
        }




        public static IQueryable<TResult> GetQuery<TSpec, TResult>(IQueryable<T> inputQuery, ISpecification<T, TResult> specification)
        {
            // Apply criteria
            if (specification.Criteria != null)
            {
                inputQuery = inputQuery.Where(specification.Criteria);
            }


            // Apply ordering
            if (specification.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(specification.OrderBy);
            }
            if (specification.OrderByDescending != null)
            {
                inputQuery = inputQuery.OrderByDescending(specification.OrderByDescending);
            }


            //// Apply paging
            //if (specification.IsPagingEnabled)
            //{
            //    query = query.Skip(specification.Skip).Take(specification.Take);
            //}
            //// Apply includes
            //foreach (var include in specification.Includes)
            //{
            //    query = query.Include(include);
            //}

            var resultQuery = inputQuery as IQueryable<TResult>;

            if( specification.Select != null)
            {
                resultQuery = inputQuery.Select(specification.Select);
            }


            // Apply distinct
            if (specification.IsDistinct)
            {
                resultQuery = resultQuery?.Distinct();
            }

            return resultQuery ?? inputQuery.Cast<TResult>();
        }
    }
}
