using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Dtos;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleRESTAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;

        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        // GET: api/<CoursesController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
          var results = await _course.GetAll();
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(results));
        }

        // GET api/<CoursesController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CourseDto>(result));
        }

        // POST api/<CoursesController>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseForCreateDto courseForCreateDto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseForCreateDto);
                var result =  await _course.Insert(course);
                var courseReturn = _mapper.Map<CourseDto>(result);
  
                return Ok(courseReturn);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // PUT api/<CoursesController>/5
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseForCreateDto courseForCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(courseForCreateDto);
                var result = await _course.Update(id.ToString(), course);
                var coursedto = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(coursedto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<CoursesController>/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"delete data id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("bytitle")]
        public async Task<IEnumerable<Course>> GetByTitle(string title)
        {
            var results = await _course.GetByTitle(title);
            return results;
        }
    }
}
