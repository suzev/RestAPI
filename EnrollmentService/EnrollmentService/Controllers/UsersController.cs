using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnrollmentService.Data;
using EnrollmentService.Dtos;
using EnrollmentService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnrollmentService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<ActionResult> Registration(CreateUserDto user)
        {
            try
            {
                await _user.Registration(user);
                return Ok($"Regirtrasi user {user.Username} berhasil");
            }
            catch (System.Exception ex)
            {

                throw new System.Exception($"{ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return Ok(_user.GetAllUser());
        }

        [HttpPost("Role")]
        public async Task<ActionResult> AddRole(CreateRoleDto createRoleDto)
        {
            try
            {
                await _user.AddRole(createRoleDto.RoleName);
                return Ok($"Tambah role {createRoleDto.RoleName} berhasil");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Role")]
        public ActionResult<IEnumerable<CreateRoleDto>> GetAllRole()
        {
            return Ok(_user.GetRoles());
        }

        [HttpPost("UserInRole")]
        public async Task<ActionResult> AddUserToRole(string username, string role)
        {
            try
            {
                await _user.AddUserToRole(username, role);
                return Ok($"Berhasil menambakan user {username} pada role {role}");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("RolesByUser/{username}")]
        public async Task<ActionResult<List<string>>> GetRolesFromUser(string username)
        { 
            var results = await _user.GetRolesFromUser(username);
            return Ok(results);
        }

        [AllowAnonymous]
        [HttpPost("Authentication")]
        public async Task<ActionResult<User>> Authentication(CreateUserDto createUserDto) 
        {
            try
            {
                var user = await _user.Authenticate(createUserDto.Username, createUserDto.Password);
                if (user == null)
                    return BadRequest("username/password kurang tepat");
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }

}
