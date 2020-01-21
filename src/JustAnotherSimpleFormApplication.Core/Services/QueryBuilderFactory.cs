using JustAnotherSimpleFormApplication.Core.Services.Abstract;

namespace JustAnotherSimpleFormApplication.Core.Services
{
    public class QueryBuilderFactory : IQueryBuilderFactory
    {
        public IQueryBuilder<T> Create<T>() =>
            new QueryBuilder<T>();
    }
}
