using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustAnotherSimpleFormApplication.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectFormsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(JObject projectForm)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult List()
        {
            throw new NotImplementedException();
        }
    }
}
