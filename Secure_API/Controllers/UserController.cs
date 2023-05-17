using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Secure_API.Repositories;
using Secure_API.Models.DTO;
using Secure_API.Models.Domain;

namespace Secure_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser UserRepository;
        private readonly IMapper mapper;

        public UserController(IUser _UserRepository, IMapper mapper)
        {
                this.UserRepository = _UserRepository;
                this.mapper = mapper;
        }

        #region Add User
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            try
            {
                var employee = mapper.Map<User>(userDTO);
                var res= await UserRepository.AddUser(employee);
                if (res != null)
                {
                    return Ok("Success");

                }
                return Ok("Already Exists");
            }
            catch (Exception e)
            {
                return BadRequest("Error in Controller method AddLoginDetails" + e);
            }
        }
        #endregion

        #region Search User        

        [HttpGet]
        [Route("SearchUser")]

        //retrive data by User data by name/email/Company/Role
        public async Task<IActionResult> SearchUser(string data)
        {
            //fetch employee
            var result = await UserRepository.SearchUser(data);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("User not found");
            }
            var resultDTO = mapper.Map<List<Models.DTO.GetUserDTO>>(result);
            return Ok(resultDTO);
        }

        #endregion
    }
}