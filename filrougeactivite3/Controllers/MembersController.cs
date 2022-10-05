using BLLS;
using Domain.DTO.Requests.Members;
using Domain.DTO.Requests.Security;
using Domain.DTO.Responses.Members;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/members")]
    [Authorize]
    public class MembersController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMemberService _memberService;
        public MembersController(ISecurityService securityService, IMemberService memberService)
        {
            _securityService = securityService;
            _memberService = memberService;
        }

        /// <summary>
        /// Se connecter
        /// </summary>
        /// <param name="authentificationRequestDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthentificationRequestDTO authentificationRequestDTO)
        {
            string token = await _securityService.SigninAsync(authentificationRequestDTO.Nickname, authentificationRequestDTO.Password);

            return Ok(new { Token = token });
        }

        /// <summary>
        /// S'enregistrer
        /// </summary>
        /// <param name="createMemberRequestDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateMemberRequestDTO createMemberRequestDTO)
        {
            Member newMember = new Member
            {
                Nickname = createMemberRequestDTO.Nickname,
                Email = createMemberRequestDTO.Email,
                Password = createMemberRequestDTO.Password
            };

            Member member = await _memberService.RegisterAsync(newMember);

            string token = await _securityService.SigninAsync(createMemberRequestDTO.Nickname, createMemberRequestDTO.Password);

            var response = new CreateMemberResponseDTO()
            {
                Nickname = member.Nickname,
                Email = member.Email,
                Token = token
            };

            return Ok(response);
        }

        /// <summary>
        /// Mettre à jour son mot de passe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatePasswordRequestDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassword([FromRoute] int id, [FromBody] UpdatePasswordRequestDTO updatePasswordRequestDTO)
        {
            // Vérification
            if (id != updatePasswordRequestDTO.Id) return BadRequest();

            /// DTO -> ObjetMétier
            var modifiedMember = new Member()
            {
                Id = updatePasswordRequestDTO.Id,
                Password = updatePasswordRequestDTO.Password
            };

            //Actions
            var member = await _memberService.UpdatePasswordAsync(modifiedMember);

            //Creation Reponse
            if (member is null) return NotFound();

            var reponse = new MemberResponseDTO()
            {
                Nickname = member.Nickname,
                Email = member.Email

            };

            return Ok(reponse);
        }
    }
}
