using FibonacciNumbers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FibonacciNumbers.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FibonacciEvenNumbersController : ControllerBase
    {
        IFibonacciService _fibonacciService;

        public FibonacciEvenNumbersController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        // GET: api/<FibonacciEvenNumbersController>
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return _fibonacciService.GetEvenNumbers();
        }

        // GET api/<FibonacciEvenNumbersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FibonacciEvenNumbersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FibonacciEvenNumbersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FibonacciEvenNumbersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
