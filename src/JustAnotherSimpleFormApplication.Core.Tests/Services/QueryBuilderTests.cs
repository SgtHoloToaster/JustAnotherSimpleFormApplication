using JustAnotherSimpleFormApplication.Core.Services;
using JustAnotherSimpleFormApplication.Data.Interface.Models;
using JustAnotherSimpleFormApplication.Data.Interface.Models.Abstract;
using JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Abstract;
using JustAnotherSimpleFormApplication.Data.Models.Filters.Json;
using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace JustAnotherSimpleFormApplication.Core.Tests.Services
{
    public class QueryBuilderTests
    {
        [Fact]
        public void CanBuild() =>
            TestBuild<JObject>(result => Assert.NotNull(result));

        [Fact]
        public void BuiltQueryHasCorrectType() =>
            TestBuild<JObject>(result => Assert.True(result is Query<JObject>));

        private void TestBuild<T>(Action<IQuery<T>> assert)
        {
            // arrange
            var target = new QueryBuilder<T>();

            // act
            var result = target.Build();

            // assert
            assert(result);
        }

        [Fact]
        public void CanAddFilter() =>
            TestAddFilter((result, expectedFilter) => { /*no exceptions*/ });

        [Fact]
        public void AddedFilterIsPresentInBuiltQuery() =>
            TestAddFilter((result, expectedFilter) =>
                Assert.Contains(expectedFilter, (result as Query<JObject>).Filters));

        private void TestAddFilter(Action<IQuery<JObject>, IFilter<JObject>> assert)
        {
            // arrange
            var target = new QueryBuilder<JObject>();
            var filter = new ContainsFilter("someColumn", "someText");

            // act
            target.AddFilter(filter);
            var result = target.Build();

            // assert
            assert(result, filter);
        }
    }
}
