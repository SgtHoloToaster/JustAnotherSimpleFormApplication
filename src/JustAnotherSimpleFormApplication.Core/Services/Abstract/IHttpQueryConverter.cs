using JustAnotherSimpleFormApplication.Data.Interface.Models.Abstract;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustAnotherSimpleFormApplication.Core.Services.Abstract
{
    public interface IHttpQueryConverter<T>
    {
        IQuery<T> Convert(IEnumerable<KeyValuePair<string, StringValues>> parameters);
    }
}
