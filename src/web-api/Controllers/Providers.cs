using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResilientIntegration.Api.Model;
using ResilientIntegration.Core.Commands;
using System;
using System.Threading.Tasks;

namespace ResilientIntegration.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Providers : ControllerBase
    {
        private readonly IMapper _mapper;

        public Providers(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody]UploadProvidersRequest providers)
        {
            var command = _mapper.Map<UploadProvidersCommand>(providers);
            Console.Write(command);
            return Ok("Success");
        }
    }
}
