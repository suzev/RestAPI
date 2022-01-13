using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Dtos;
using SampleRESTAPI.Models;
using SampleRESTAPI.SyncDataServices.Http;
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
        private IEnrollmentDataClient _dataClient;

        public EnrollmentsController(IEnrollment enrollment, IMapper mapper, IEnrollmentDataClient dataClient)
        {
            _enrollment = enrollment;
            _mapper = mapper;
            _dataClient = dataClient;
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
        public async Task<ActionResult<EnrollmentDto>> Get(int id)
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

        //Menunggu Payment Service
        // POST api/<EnrollmentsController>
          [HttpPost]
           public async Task<ActionResult> CreateEnrollment([FromBody] CreateEnrollmentDto createEnrollmentDto)
           {
               try
               {
                   await _dataClient.CreateEnrollmentFromPaymentService(createEnrollmentDto);

                   return Ok("Success");
               }
               catch (Exception ex)
               {
                   return BadRequest(ex.Message);
               }

           }
        
    }
}
