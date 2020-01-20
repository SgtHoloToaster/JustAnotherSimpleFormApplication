using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustAnotherSimpleFormApplication.Data.Interface.Repositories
{
    public interface IDynamicFormsRepository
    {
        void Add(JObject form);

        IEnumerable<JObject> GetList();
    }
}
