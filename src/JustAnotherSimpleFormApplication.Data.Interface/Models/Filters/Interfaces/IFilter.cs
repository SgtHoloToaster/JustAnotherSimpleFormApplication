using System.Collections.Generic;

namespace JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Interfaces
{
    public interface IFilter<T>
    {
        bool Apply(T model);

        IEnumerable<T> Apply(IEnumerable<T> models);
    }
}
