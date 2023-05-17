using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Secure_API.Repositories;
using Secure_API.Models.DTO;
using Secure_API.Models.Domain;

namespace Secure_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitor _VisitorRepository;
        private readonly IMapper mapper;

        public VisitorController(IVisitor VisitorRepository, IMapper mapper)
        {
                this._VisitorRepository = VisitorRepository;
                this.mapper = mapper;
        }
        
        #region Search Visitor        

        [HttpGet]
        [Route("SearchVisitor")]

        //retrive data by Visitor data by name/email/Company
        public async Task<IActionResult> SearchVisitor(string data)
        {
            //fetch data
            var result = await _VisitorRepository.SearchVisitor(data);
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
            var resultDTO = mapper.Map<List<Models.DTO.VisitorDTO>>(result);
            return Ok(resultDTO);
        }

        #endregion

         #region Add Visitor
        [HttpPost]
        [Route("AddVisitor")]
        public async Task<IActionResult> AddVisitor(VisitorDTO visitorDTO)
        {
            try
            {
                var newvisitor = mapper.Map<Visitor>(visitorDTO);
                var res= await _VisitorRepository.AddVisitor(newvisitor);
                if (res != null)
                {
                    return Ok("Success");

                }
                return Ok("Already Exists");
            }
            catch (Exception e)
            {
                return BadRequest("Error in Controller method AddUser" + e);
            }
        }
        #endregion
    }
}