using JustAnotherSimpleFormApplication.Core.Services.Abstract;
using JustAnotherSimpleFormApplication.Data.Interface.Models;
using JustAnotherSimpleFormApplication.Data.Interface.Models.Abstract;
using JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Abstract;
using System.Collections.Generic;

namespace JustAnotherSimpleFormApplication.Core.Services
{
    public class QueryBuilder<T> : IQueryBuilder<T>
    {
        readonly List<IFilter<T>> _filters = new List<IFilter<T>>();

        public IQueryBuilder<T> AddFilter(IFilter<T> filter)
        {
            _filters.Add(filter);
            return this;
        }

        public IQuery<T> Build() => 
            new Query<T>(_filters);
    }
}
