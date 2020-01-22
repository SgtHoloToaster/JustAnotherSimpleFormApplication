using JustAnotherSimpleFormApplication.Core.Services.Abstract;
using JustAnotherSimpleFormApplication.Data.Interface.Models.Abstract;
using JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Abstract;
using JustAnotherSimpleFormApplication.Data.Models.Filters.Json;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JustAnotherSimpleFormApplication.Core.Services
{
    public class HttpQueryJsonConverter : IHttpQueryConverter<JObject>
    {
        readonly IQueryBuilderFactory _queryBuilderFactory;

        public HttpQueryJsonConverter(IQueryBuilderFactory queryBuilderFactory)
        {
            _queryBuilderFactory = queryBuilderFactory;
        }

        public IQuery<JObject> Convert(IEnumerable<KeyValuePair<string, StringValues>> parameters)
        {
            var builder = _queryBuilderFactory.Create<JObject>();
            foreach (var parameter in parameters)
                builder.AddFilter(GetFilter(parameter));

            return builder.Build();
        }

        private IFilter<JObject> GetFilter(KeyValuePair<string, StringValues> keyValuePair) =>
            new ContainsFilter(keyValuePair.Key, keyValuePair.Value.ToString());
    }
}
