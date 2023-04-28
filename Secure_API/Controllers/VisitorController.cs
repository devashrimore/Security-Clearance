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
        
        [HttpPost]
        [Route("SendRequest")]
        public async Task<IActionResult> AddRequest(RequestDTO SendRequest)
        {
            try
            {
                // //DTO to Model
                var request = mapper.Map<Request>(SendRequest);

                //Pass Detail to Repository
                var response = await _VisitorRepository.AddRequest(request);

                //Convert back to DTO
                var SendRequestDTO = mapper.Map<RequestDTO>(response);

                

                return Ok(SendRequestDTO);
            }
            catch(Exception e)
            {
                return BadRequest("Error in Controller method AddRequest" + e);
            }
            }
    }
}