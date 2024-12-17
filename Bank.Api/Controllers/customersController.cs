using Bank.Core.Services;
using Bank.Service;
using Microsoft.AspNetCore.Mvc;
using project.Entitis;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IcustomerService _customerService;
        public CustomersController(IcustomerService customerService)
        {
            _customerService = customerService;
        }


        // GET: api/customers
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_customerService.GetList());
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var customer = _customerService.GetById(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound();

        }
        // POST api/<customersController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer value)
        {
            var customer = _customerService.GetById(value.id);
            if (customer != null)
            {
                return Conflict();
            }
            _customerService.Add(value);
            return Ok(); ;
        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
         public ActionResult Put(string id,  Customer value)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return Conflict();
            }
            _customerService.Put(id,value);
            return Ok();
        }
        // PUT api/customers/status/5
        [HttpPut("status/{id}")]
        public ActionResult Put(string id, bool isActive)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return Conflict();
            }
            _customerService.PutStatus(id, isActive);
            return Ok();
        }
    }
}
