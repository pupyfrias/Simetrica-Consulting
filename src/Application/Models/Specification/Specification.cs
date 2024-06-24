﻿using SimetricaConsulting.Application.Contracts;
using SimetricaConsulting.Application.Exceptions;
using SimetricaConsulting.Domain.Contracts;
using System.Linq.Expressions;
using System.Reflection;

namespace SimetricaConsulting.Application.Models.Specification
{
    /// <summary>
    /// Provides a base class for building query specifications for TEntity, including paging, sorting, and criteria.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which the specification is defined.</typeparam>
    public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : IEntityBase
    {
        protected Specification(IQueryParametersBase queryParametersBase, bool applyPagination)
        {
            if (applyPagination)
            {
                Skip = queryParametersBase.Offset;
                Take = queryParametersBase.Limit;
            }
            Descending = queryParametersBase.Descending;
            ApplySortBy(queryParametersBase.SortBy ?? "Created");
        }

        public Expression<Func<TEntity, bool>>? Criteria { get; protected set; }
        public bool Descending { get; private set; }

        public Expression<Func<TEntity, object>> SortBy { get; set; }

        public int Skip { get; private set; }
        public int Take { get; private set; }

        /// <summary>
        /// Applies an sort by expression to the specification based on the property name.
        /// </summary>
        /// <param name="propertyName">The name of the property to sort by.</param>
        public void ApplySortBy(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "p");
            var propertyInfo = typeof(TEntity).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (propertyInfo == null)
            {
                throw new BadRequestException($"Could not find {propertyName} on {typeof(TEntity).Name}");
            }

            var property = Expression.Property(parameter, propertyInfo);
            var conversion = Expression.Convert(property, typeof(object));
            var lambda = Expression.Lambda<Func<TEntity, object>>(conversion, parameter);

            SortBy = lambda;
        }
    }
}