using JustAnotherSimpleFormApplication.Core.Services;
using JustAnotherSimpleFormApplication.Core.Services.Abstract;
using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace JustAnotherSimpleFormApplication.Core.Tests.Services
{
    public class QueryBuilderFactoryTests
    {
        [Fact]
        public void CanCreateQueryBuilder() =>
            TestCreateBuilder<object>(result => Assert.NotNull(result));

        [Fact]
        public void CreatedQueryBuilderHasCorrectType() =>
            TestCreateBuilder<JObject>(result => Assert.True(result is QueryBuilder<JObject>));

        private void TestCreateBuilder<T>(Action<IQueryBuilder<T>> assert)
        {
            // arrange
            var target = new QueryBuilderFactory();

            // act
            var result = target.Create<T>();

            // assert
            assert(result);
        }
    }
}
