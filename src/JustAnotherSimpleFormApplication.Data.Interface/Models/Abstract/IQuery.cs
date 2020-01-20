using System.Collections.Generic;

namespace JustAnotherSimpleFormApplication.Data.Interface.Models.Abstract
{
    public interface IQuery<T>
    {
        IEnumerable<T> Apply(IEnumerable<T> models);
    }
}
