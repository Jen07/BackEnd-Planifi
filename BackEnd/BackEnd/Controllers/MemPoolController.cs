using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Services;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemPoolController : ControllerBase
    {

        public MemPoolService _memPollService;

        public MemPoolController(MemPoolService memPollService)
        {
            _memPollService = memPollService;
        }

        [HttpGet]
        public ActionResult<List<MemPool>> Get()
        {
            return _memPollService.AllConfiguration();
        }

        [HttpPost]
        public ActionResult<MemPool> Create(MemPool memPool)
        {
            _memPollService.Create(memPool);
            return Ok(memPool);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _memPollService.Delete(id);
            return Ok();
        }

        [HttpGet("{cantidad}")]
        public ActionResult cantidadBloquesMinar(int cantidad)
        {
            Ok(cantidad);
            return Ok(_memPollService.mineList(cantidad));
        }

    }
}
