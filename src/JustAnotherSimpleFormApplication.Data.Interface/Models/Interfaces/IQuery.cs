using System.Collections.Generic;

namespace JustAnotherSimpleFormApplication.Data.Interface.Models.Interfaces
{
    public interface IQuery<T>
    {
        IEnumerable<T> Apply(IEnumerable<T> models);
    }
}
