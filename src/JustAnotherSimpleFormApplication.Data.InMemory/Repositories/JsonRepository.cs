using JustAnotherSimpleFormApplication.Data.Interface.Models;
using JustAnotherSimpleFormApplication.Data.Interface.Repositories;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace JustAnotherSimpleFormApplication.Data.InMemory.Repositories
{
    class JsonRepository : IJsonRepository
    {
        readonly static ConcurrentBag<JObject> _data = new ConcurrentBag<JObject>();

        public void Add(JObject form) =>
            _data.Add(form);

        public IEnumerable<JObject> GetList(Query<JObject> query) =>
            query.Apply(_data);
    }
}
