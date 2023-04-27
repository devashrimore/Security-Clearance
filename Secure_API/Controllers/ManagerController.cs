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
        
        #region GetAllRequest Method
        [HttpGet]
        [Route("GetAllRequests")]
        //method for retriving request details
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
            var data= await ManagerRepository.GetAllRequests();
            return Ok(mapper.Map<List<Models.DTO.GetRequestDTO>>(data));
            }
            catch(Exception e)
            {
                return BadRequest("Error in Controller method GetAll" + e);
            }
        }

        #endregion

        #region Search Request        

        [HttpGet]
        [Route("SearchRequest")]

        //retrive data by Visitor data by name/email/Company
        public async Task<IActionResult> SearchVisitor([FromRoute] string data)
        {
            //fetch employee
            var result = await ManagerRepository.SearchVisitor(data);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Visitor not found");
            }
            var resultDTO = mapper.Map<List<Models.DTO.RequestDTO>>(result);
            return Ok(resultDTO);
        }

        #endregion
    }
}