using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FibonacciNumbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        FibonacciNumbers.Services.IFibonacciService _fibonacciService;
        public FibonacciController(Services.IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        // GET: api/<FibonacciController>
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return _fibonacciService.FibonacciSequence;
        }

        // GET api/<FibonacciController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FibonacciController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FibonacciController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FibonacciController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
