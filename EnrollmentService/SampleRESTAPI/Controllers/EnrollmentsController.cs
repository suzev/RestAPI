using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleRESTAPI.Controllers
{

    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IEnrollment _enrollment;
        private IMapper _mapper;

        public EnrollmentsController(IEnrollment enrollment, IMapper mapper)
        {
            _enrollment = enrollment;
            _mapper = mapper;
        }

        // GET: api/<EnrollmentsController>
        [HttpGet]
        public async Task<IEnumerable<Enrollment>> Get()
        {
            var results = await _enrollment.GetAll();
            return results;
        } 

        // GET api/<EnrollmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> Get(int id)
        {
            try
            {
                var results = await _enrollment.GetById(id.ToString());
                if (results == null)
                    return NotFound();
                return Ok((results));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EnrollmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EnrollmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
