using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Dtos;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRESTAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudent _student;
        private IMapper _mapper;

        public StudentsController(IStudent student, IMapper mapper)
        {
            _student = student ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }
       
        [Authorize(Roles ="student")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> Get()
        {
            var students = await _student.GetAll();
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> Get(int id)
        {
            var result = await _student.GetById(id.ToString());
            if (result == null) 
                return NotFound();
            return Ok(_mapper.Map<StudentDto>(result));
        }

        [Authorize(Roles ="admin")]
        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post([FromBody]StudentForCreateDto studentforCreateDto)
        {
            try
            {
                var student = _mapper.Map<Models.Student>(studentforCreateDto);
                var result = await _student.Insert(student);
                var studentReturn = _mapper.Map<Dtos.StudentDto>(result);
                return Ok(studentReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> Put(int id, [FromBody] StudentForCreateDto studentForCreateDto)
        {
            try
            {
                var student = _mapper.Map<Models.Student>(studentForCreateDto);
                var result = await _student.Update(id.ToString(), student);
                var studentdto = _mapper.Map<Dtos.StudentDto>(result);
                return Ok(studentdto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _student.Delete(id.ToString());
                return Ok($"Data student {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
