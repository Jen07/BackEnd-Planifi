using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {

        public ConfigurationService _configurationService;


        public ConfigurationController(ConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
        [HttpGet]
        public ActionResult<List<Configuration>> Get()
        {
            return _configurationService.AllConfiguration();
        }

        [HttpPost]
        public ActionResult<Configuration> Create(Configuration Configuration)
        {
            _configurationService.Create(Configuration);
            return Ok(Configuration);
        }

        [HttpPut]
        public ActionResult Update(Configuration configuration)
        {
            _configurationService.Update(configuration.Id, configuration);
            return Ok(configuration);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _configurationService.Delete(id);
            return Ok();
        }
    }
}
