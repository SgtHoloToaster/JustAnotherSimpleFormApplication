using JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Abstract;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace JustAnotherSimpleFormApplication.Data.Models.Filters.Json
{
    public class EqualityFilter : IFilter<JObject>
    {
        public string ColumnName { get; }

        public string Value { get; }

        public EqualityFilter(string columnName, string value)
        {
            ColumnName = columnName;
            Value = value;
        }

        public bool Apply(JObject model) =>
            string.Equals(model.Value<string>(ColumnName), Value);

        public IEnumerable<JObject> Apply(IEnumerable<JObject> models) =>
            models.Where(Apply);
    }
}
