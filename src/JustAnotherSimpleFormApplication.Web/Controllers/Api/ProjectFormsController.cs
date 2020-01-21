using JustAnotherSimpleFormApplication.Core.Services.Abstract;
using JustAnotherSimpleFormApplication.Data.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace JustAnotherSimpleFormApplication.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectFormsController : ControllerBase
    {
        readonly IHttpQueryConverter<JObject> _httpQueryConverter;
        readonly IProjectFormsRepository _jsonRepository;

        public ProjectFormsController(IHttpQueryConverter<JObject> httpQueryConverter, IProjectFormsRepository jsonRepository)
        {
            _httpQueryConverter = httpQueryConverter;
            _jsonRepository = jsonRepository;
        }

        [HttpPost]
        public IActionResult Add(JObject projectForm)
        {
            _jsonRepository.Add(projectForm);
            return Ok();
        }

        [HttpGet]
        public IActionResult List()
        {
            var query = _httpQueryConverter.Convert(Request.Query);
            return Ok(_jsonRepository.GetList(query));
        }
    }
}
