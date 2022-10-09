using API.Controllers;
using BLLS;
using Domain.DTO.Requests.Members;
using Domain.DTO.Requests.Security;
using Domain.DTO.Responses.Members;
using Domain.DTO.Security;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public static class JSONHelper
    {
        /// <summary>
        /// Convert an abject to JSON format
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }
    }
    public class MembersControllerTest
    {
        [Fact]
        public async void LoginShouldBeOk()
        {
            //Arrange
            ISecurityService securityService = Mock.Of<ISecurityService>();
            IMemberService memberService = Mock.Of<IMemberService>();

            string username = "toto";
            string password = "totopassword";
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
            AuthentificationRequestDTO authentificationRequestDTO = new AuthentificationRequestDTO()
            {
                Nickname = username,
                Password = password
            };

            TokenResponseDTO expectedContentResult = new TokenResponseDTO()
            {
                Token = token
            };

            Mock.Get(securityService).Setup(securityService => securityService.SigninAsync(username, password)).ReturnsAsync(token);

            MembersController membersController = new MembersController(securityService, memberService);

            //Act
            IActionResult result = await membersController.Login(authentificationRequestDTO);

            //Assert
            OkObjectResult okResult = result as OkObjectResult;
            Assert.True(result is OkObjectResult);
            Assert.Equal(okResult.Value.ToJSON(), expectedContentResult.ToJSON());
        }

        [Fact]
        public async void RegisterShouldBeOkAndCreated()
        {
            //Arrange
            ISecurityService securityService = Mock.Of<ISecurityService>();
            IMemberService memberService = Mock.Of<IMemberService>();

            string username = "tata";
            string password = "tatapassword";

            CreateMemberRequestDTO createMemberRequestDTO = new CreateMemberRequestDTO()
            {
                Nickname = username,
                Email = "tata@toto.fr",
                Password = password
            };

            Member newMember = new Member
            {
                Nickname = createMemberRequestDTO.Nickname,
                Email = createMemberRequestDTO.Email,
                Password = createMemberRequestDTO.Password
            };

            Member member = new Member() { Nickname = "tata", Email = "tata@toto.fr" };
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";

            Mock.Get(memberService).Setup(memberService => memberService.RegisterAsync(newMember)).ReturnsAsync(member);
            Mock.Get(securityService).Setup(securityService => securityService.SigninAsync(username, password)).ReturnsAsync(token);

            CreateMemberResponseDTO expected = new CreateMemberResponseDTO()
            {
                Nickname = member.Nickname,
                Email = member.Email,
                Token = token
            };

            MembersController membersController = new MembersController(securityService, memberService);

            //Act
            IActionResult result = await membersController.Register(createMemberRequestDTO);

            //Assert
            CreatedAtActionResult createdResult = result as CreatedAtActionResult;
            Assert.True(result is CreatedAtActionResult);
            Assert.Equal(createdResult.Value, expected);
        }

        [Fact]
        public async void UpdatePasswordShouldBeABadRequest()
        {
            //Arrange
            ISecurityService securityService = Mock.Of<ISecurityService>();
            IMemberService memberService = Mock.Of<IMemberService>();

            UpdatePasswordRequestDTO updatePasswordRequestDTO = new UpdatePasswordRequestDTO()
            {
                Id = 2,
                Password = "titipassword"
            };

            MembersController membersController = new MembersController(securityService, memberService);

            //Act
            IActionResult result = await membersController.UpdatePassword(3, updatePasswordRequestDTO);

            //Assert
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public async void UpdatePasswordShouldBeOkAndUpdated()
        {
            //Arrange
            ISecurityService securityService = Mock.Of<ISecurityService>();
            IMemberService memberService = Mock.Of<IMemberService>();

            UpdatePasswordRequestDTO updatePasswordRequestDTO = new UpdatePasswordRequestDTO()
            {
                Id = 2,
                Password = "titipassword"
            };

            Member modifiedMember = new Member()
            {
                Id = updatePasswordRequestDTO.Id,
                Password = updatePasswordRequestDTO.Password
            };

            Member member = new Member() { Nickname = "titi", Email = "titi@toto.fr" };

            Mock.Get(memberService).Setup(memberService => memberService.UpdatePasswordAsync(modifiedMember)).ReturnsAsync(member);

            MemberResponseDTO expected = new MemberResponseDTO()
            {
                Nickname = member.Nickname,
                Email = member.Email
            };

            MembersController membersController = new MembersController(securityService, memberService);

            //Act
            IActionResult result = await membersController.UpdatePassword(2, updatePasswordRequestDTO);

            //Assert
            OkObjectResult okResult = result as OkObjectResult;
            Assert.True(result is OkObjectResult);
            Assert.Equal(expected, okResult.Value);
        }

        [Fact]
        public async void GetMembersShouldBeOk()
        {
            //Arrange
            ISecurityService securityService = Mock.Of<ISecurityService>();
            IMemberService memberService = Mock.Of<IMemberService>();

            List<Member> members = new List<Member>()
                {
                    new Member() {Id = 1, Nickname = "toto", Type = "Moderator", Email = "toto@toto.fr", Password = "3F9kY2n69M3Nj1B5NCZTSZSxLUtEzpCwnDChBjViJNQ=", CreatedAt = DateTime.Parse("08/10/2022 12:03:38")},
                    new Member() {Id = 2, Nickname = "titi", Type = "Member", Email = "titi@toto.fr", Password = "4vtbZCx1En4VqfCnDyfYitoW+dlLjaMppEpqsaHyKCo=", CreatedAt = DateTime.Parse("08/10/2022 12:03:38")}
                };

            IEnumerable<MemberResponseDTO> expectedContentResult = members.Select(member => new MemberResponseDTO()
            {
                Nickname = member.Nickname,
                Email = member.Email
            });

            Mock.Get(memberService)
                .Setup(memberService => memberService.GetMembersAsync())
                .ReturnsAsync(members);

            MembersController membersController = new MembersController(securityService, memberService);

            //Act
            IActionResult result = await membersController.GetMembers();

            //Assert
            OkObjectResult okResult = result as OkObjectResult;
            Assert.True(result is OkObjectResult);
            Assert.Equal(okResult.Value, expectedContentResult);
        }

        [Fact]
        public async void GetMemberByIdShoulBeNotFound()
        {
            //Arrange
            ISecurityService securityService = Mock.Of<ISecurityService>();
            IMemberService memberService = Mock.Of<IMemberService>();

            Mock.Get(memberService)
                .Setup(memberService => memberService.GetMemberByIdAsync(5))
                .ReturnsAsync(null as Member);

            MembersController membersController = new MembersController(securityService, memberService);

            //Act
            IActionResult actionResult = await membersController.GetMemberById(5);

            //Assert
            Assert.True(actionResult is NotFoundResult);
        }

        [Fact]
        public async void GetMemberByIdShoulBeOk()
        {
            //Arrange
            ISecurityService securityService = Mock.Of<ISecurityService>();
            IMemberService memberService = Mock.Of<IMemberService>();

            Member member = new Member() { Id = 2, Nickname = "titi", Type = "Member", Email = "titi@toto.fr", Password = "4vtbZCx1En4VqfCnDyfYitoW+dlLjaMppEpqsaHyKCo=", CreatedAt = DateTime.Parse("08/10/2022 12:03:38") };

            MemberResponseDTO expectedContentResult = new MemberResponseDTO()
            {
                Nickname = member.Nickname,
                Email = member.Email
            };

            Mock.Get(memberService)
                .Setup(memberService => memberService.GetMemberByIdAsync(2))
                .ReturnsAsync(member);


            MembersController membersController = new MembersController(securityService, memberService);

            //Act
            IActionResult result = await membersController.GetMemberById(2);

            //Assert
            OkObjectResult okResult = result as OkObjectResult;
            Assert.True(result is OkObjectResult);
            Assert.Equal(okResult.Value, expectedContentResult);
        }
    }
}
