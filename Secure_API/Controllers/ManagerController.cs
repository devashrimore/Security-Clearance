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
    public class ManagerController : ControllerBase
    {
        private readonly IManager ManagerRepository;
        private readonly IMapper mapper;

        public ManagerController(IManager _ManagerRepository, IMapper mapper)
        {
                this.ManagerRepository = _ManagerRepository;
                this.mapper = mapper;
        }
        
        [HttpGet]
        //method for retriving request details
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
            var data= await ManagerRepository.GetAllRequests();
            return Ok(mapper.Map<List<Models.DTO.RequestDTO>>(data));
            }
            catch(Exception e)
            {
                return BadRequest("Error in Controller method GetAll" + e);
            }
        }
    }
}