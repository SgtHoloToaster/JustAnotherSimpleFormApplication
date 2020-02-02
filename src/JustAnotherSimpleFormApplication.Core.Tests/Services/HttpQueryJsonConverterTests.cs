using AutoMoqCore;
using JustAnotherSimpleFormApplication.Core.Services;
using JustAnotherSimpleFormApplication.Core.Services.Abstract;
using JustAnotherSimpleFormApplication.Data.Interface.Models;
using JustAnotherSimpleFormApplication.Data.Interface.Models.Filters.Abstract;
using JustAnotherSimpleFormApplication.Data.Models.Filters.Json;
using Microsoft.Extensions.Primitives;
using Moq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit;

namespace JustAnotherSimpleFormApplication.Core.Tests.Services
{
    public class HttpQueryJsonConverterTests
    {
        [Fact]
        public void CanDetermineContainsFilter()
        {
            // arrange
            var mocker = new AutoMoqer();
            mocker.GetMock<IQueryBuilderFactory>()
                .Setup(m => m.Create<JObject>())
                .Returns(() => mocker.GetMock<IQueryBuilder<JObject>>().Object);
            const string columnName = "someColumnName";
            const string filterValue = "someFilterValue";
            var expectedFilter = new ContainsFilter(columnName, filterValue);
            var addedFilters = new List<IFilter<JObject>>();
            mocker.GetMock<IQueryBuilder<JObject>>()
                .Setup(m => m.AddFilter(It.IsAny<IFilter<JObject>>()))
                .Callback<IFilter<JObject>>(filter => addedFilters.Add(filter));
            mocker.GetMock<IQueryBuilder<JObject>>()
                .Setup(m => m.Build())
                .Returns(() => new Query<JObject>(addedFilters));
            var input = new List<KeyValuePair<string, StringValues>> 
            { 
                new KeyValuePair<string, StringValues>(columnName, new StringValues(filterValue)) 
            };
            var target = mocker.Create<HttpQueryJsonConverter>();

            // act
            var result = target.Convert(input) as Query<JObject>;

            // assert
            mocker.Verify<IQueryBuilder<JObject>>(m => m.AddFilter(expectedFilter), Times.Once());
            mocker.Verify<IQueryBuilder<JObject>>(m => m.Build(), Times.Once());
            Assert.NotEmpty(result.Filters);
            Assert.Equal(addedFilters, result.Filters);
        }
    }
}
