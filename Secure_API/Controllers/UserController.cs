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

       
    }
}