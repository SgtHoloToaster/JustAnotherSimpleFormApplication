using JustAnotherSimpleFormApplication.Data.Interface.Models.Abstract;
using JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Abstract;

namespace JustAnotherSimpleFormApplication.Core.Services.Abstract
{
    public interface IQueryBuilder<T>
    {
        IQueryBuilder<T> AddFilter(IFilter<T> filter);

        IQuery<T> Build();
    }
}
