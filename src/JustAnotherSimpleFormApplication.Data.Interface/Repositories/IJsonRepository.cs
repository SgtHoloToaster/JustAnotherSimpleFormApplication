using JustAnotherSimpleFormApplication.Data.Interface.Models.Abstract;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JustAnotherSimpleFormApplication.Data.Interface.Repositories
{
    public interface IJsonRepository
    {
        void Add(JObject form);

        IEnumerable<JObject> GetList(IQuery<JObject> query);
    }
}
