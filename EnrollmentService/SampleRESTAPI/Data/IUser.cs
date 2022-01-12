﻿using Microsoft.AspNetCore.Identity;
using SampleRESTAPI.Dtos;
using SampleRESTAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleRESTAPI.Data
{
    public interface IUser
    {
        IEnumerable<UserDto> GetAllUser(); 
        Task Registration(CreateUserDto user);

        Task AddRole(string rolename);

        IEnumerable<CreateRoleDto> GetRoles();

        Task AddUserToRole (string username , string role);

        Task <List<string>> GetRolesFromUser(string username);

        Task<User> Authenticate (string username, string password);

    }
}
