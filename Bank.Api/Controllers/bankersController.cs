using Bank.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using project.Entitis;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bankersController : ControllerBase
    {
        private readonly IbankerService _bankerService;
        public bankersController(IbankerService bankerService)
        {
            _bankerService = bankerService;
        }

        // GET: api/<bankersController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_bankerService.GetList());
        }
        // GET api/<bankersController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var banker = _bankerService.GetById(id);
            if (banker != null)
            {
                return Ok(banker);
            }
             return NotFound();
            
        }

        // POST api/<bankersController>
        [HttpPost]
        public ActionResult Post([FromBody] Banker value)
        {
            var banker=_bankerService.GetById(value.id);
            if(banker != null)
            {
                return Conflict();
            }
            _bankerService.Add(value);
            return Ok(); ;
        }

        //put api/<bankerscontroller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id,  Banker value)
        {
            var banker = _bankerService.GetById(id);
            if (banker == null)
            {
                return Conflict();
            }
            _bankerService.Put(id,value);
            return Ok();
        }
        // PUT api/<bankersController>/status/5
        [HttpPut("status/{id}")]
        public ActionResult Put(string id, bool isActive)
        {
            var banker = _bankerService.GetById(id);
            if (banker == null)
            {
                return Conflict();
            }
            _bankerService.PutStatus(id, isActive);
            return Ok();
        }
    }
}