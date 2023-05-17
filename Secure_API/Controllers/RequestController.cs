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
    public class RequestController : ControllerBase
    {
        private readonly IRequest RequestRepository;
        private readonly IMapper mapper;

        public RequestController(IRequest _RequestRepository, IMapper mapper)
        {
                this.RequestRepository = _RequestRepository;
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
            var data= await RequestRepository.GetAllRequests();
            return Ok(mapper.Map<List<Models.DTO.GetRequestDTO>>(data));
            }
            catch(Exception e)
            {
                return BadRequest("Error in Controller method GetAll" + e);
            }
        }

        #endregion

        #region Add Request
        [HttpPost]
        [Route("SendRequest")]
        public async Task<IActionResult> AddRequest(RequestDTO SendRequest)
        {
            try
            {
                // //DTO to Model
                var request = mapper.Map<Request>(SendRequest);

                //Pass Detail to Repository
                var response = await RequestRepository.AddRequest(request);

                //Convert back to DTO
                var SendRequestDTO = mapper.Map<RequestDTO>(response);

                

                return Ok(SendRequestDTO);
            }
            catch(Exception e)
            {
                return BadRequest("Error in Controller method AddRequest" + e);
            }
            }
            #endregion

        #region Get Approved
        [HttpGet]
        [Route("Approved")]
        public async Task<IActionResult> GetApprovedRequests()
        {
            var result = await RequestRepository.GetApprovedRequests();
            return Ok(mapper.Map<List<Models.DTO.GetRequestDTO>>(result));
           
        }

        #endregion

        #region Get Rejected
        [HttpGet]
        [Route("Rejected")]
        public async Task<IActionResult> GetRejectedRequests()
        {
            var result = await RequestRepository.GetRejectedRequests();
            return Ok(mapper.Map<List<Models.DTO.GetRequestDTO>>(result));
           
        }

        #endregion

        
        #region Edit RequestStatus
        [HttpPut]
        [Route("EditRequest")]
        public async Task<IActionResult> EditRequest(int requestId, EditRequestDTO editDTO)
        {
            var request = mapper.Map<Request>(editDTO);
            var response = await RequestRepository.EditRequest(requestId, request);
            if (response == null)
            {
                return BadRequest();
            }
            //Convert back to DTO
           var getRequestDTO = mapper.Map<GetRequestDTO>(response);
            return Ok(getRequestDTO);
        }

        #endregion
    }
}