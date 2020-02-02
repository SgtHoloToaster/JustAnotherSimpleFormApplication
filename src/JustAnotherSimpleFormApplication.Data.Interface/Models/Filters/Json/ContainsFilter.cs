using JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Abstract;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace JustAnotherSimpleFormApplication.Data.Models.Filters.Json
{
    public class ContainsFilter : IFilter<JObject>
    {
        public string ColumnName { get; }

        public string Value { get; }

        public ContainsFilter(string columnName, string value)
        {
            ColumnName = columnName;
            Value = value;
        }

        public bool Apply(JObject model)
        {
            if (string.IsNullOrWhiteSpace(Value))
                return true;

            var modelValue = model.Value<string>(ColumnName);
            return !string.IsNullOrWhiteSpace(modelValue) && modelValue.Contains(Value);
        }

        public IEnumerable<JObject> Apply(IEnumerable<JObject> models) =>
            models.Where(Apply);

        public override bool Equals(object obj) =>
            Equals(obj as ContainsFilter);

        public bool Equals(ContainsFilter filter)
        {
            if (filter == null)
                return false;

            if (ReferenceEquals(this, filter))
                return true;

            return Equals(ColumnName, filter.ColumnName)
                && Equals(Value, filter.Value);
        }

        public override int GetHashCode()
        {
            var hash = 17;
            unchecked
            {
                hash *= 23 + (ColumnName?.GetHashCode() ?? 0);
                hash *= 23 + (ColumnName?.GetHashCode() ?? 0);
            }

            return hash;
        }
    }
}
