using JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Interfaces;
using JustAnotherSimpleFormApplication.Data.Interface.Models.Interfaces;
using System.Collections.Generic;

namespace JustAnotherSimpleFormApplication.Data.Interface.Models
{
    public class Query<T> : IQuery<T>
    {
        public IEnumerable<IFilter<T>> Filters { get; }

        public Query(IEnumerable<IFilter<T>> filters)
        {
            Filters = filters;
        }

        public IEnumerable<T> Apply(IEnumerable<T> models) =>
            ApplyFilters(models);

        private IEnumerable<T> ApplyFilters(IEnumerable<T> models)
        {
            var result = models;
            foreach (var filter in Filters)
                result = filter.Apply(result);

            return result;
        }
    }
}
