using JustAnotherSimpleFormApplication.Data.Interface.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JustAnotherSimpleFormApplication.Data.Interface.Repositories
{
    public interface IJsonRepository
    {
        void Add(JObject form);

        IEnumerable<JObject> GetList(Query<JObject> query);
    }
}
