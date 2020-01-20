using JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace JustAnotherSimpleFormApplication.Data.Models.Filters.Json
{
    public class EqualityFilter : IFilter<JObject>
    {
        public string ColumnName { get; }

        public object Value { get; }

        public EqualityFilter(string columnName, object value)
        {
            ColumnName = columnName;
            Value = value;
        }

        public bool Apply(JObject model) =>
            Equals(model[ColumnName], Value);

        public IEnumerable<JObject> Apply(IEnumerable<JObject> models) =>
            models.Where(Apply);
    }
}
