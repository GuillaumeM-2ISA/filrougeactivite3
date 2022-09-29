using BLLS;
using Domain.DTO.Requests.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MembersController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        public MembersController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthentificationRequestDTO authentificationRequestDTO)
        {
            string token = await _securityService.SigninAsync(authentificationRequestDTO.Nickname, authentificationRequestDTO.Password);

            return Ok(new { Token = token });
        }
    }
}
