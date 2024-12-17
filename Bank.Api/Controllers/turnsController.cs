using Bank.Core.Services;
using Bank.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using project.Entitis;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class turnsController : ControllerBase
    {
        private readonly IturnService _turnService;
        public turnsController(IturnService turnService)
        {
            _turnService = turnService;
        }

        // GET: api/<turnsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_turnService.GetList());
        }

        // GET api/<turnsController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var turn = _turnService.GetById(id);
            if (turn != null)
            {
                return Ok(turn);
            }
            return NotFound();
        }

        // POST api/<turnsController>
        [HttpPost]
        public ActionResult Post([FromBody] Turn value)
        {
           var turn = _turnService.GetById(value.id);
           if (turn != null)
           {
              return Conflict();
           }
           _turnService.Add(value);
           return Ok(); ;
        }

        // PUT api/<turnsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, Turn value)
        {
            var turn = _turnService.GetById(id);
            if (turn == null)
            {
                return Conflict();
            }
            _turnService.Put(id,value);
            return Ok();
        }

        // DELETE api/<turnsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var turn= _turnService.GetById(id);
            if (turn == null)
                return Conflict();
            _turnService.Delete(id);
            return Ok();
        }
    }
}