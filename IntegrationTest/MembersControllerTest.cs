using Domain.DTO.Requests.Members;
using Domain.DTO.Requests.Security;
using Domain.DTO.Responses.Members;
using Domain.DTO.Security;
using IntegrationTest.Fixture;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class MembersControllerTest : AbstractIntegrationTest
    {
        public MembersControllerTest(ApiWebApplicationFactory fixture) : base(fixture)
        {
            Cleanup();
        }

        private void Cleanup()
        {
            var connectionString = "Data Source=(localdb)\\MSSqlLocalDB;Integrated Security=True";
            var sqlScript = File.ReadAllText(@"C:\Users\cda5mour\Desktop\Projet Fil Rouge 2\Workspace\Merise\script.sql");

            using (var connection = new SqlConnection(connectionString))
            {
                var server = new Server(new ServerConnection(connection));
                server.ConnectionContext.ExecuteNonQuery(sqlScript);
            }
        }
        
        [Fact]
        public async void LoginShouldBeOk()
        {
            //Arrange
            string uri = "/api/members/login";

            AuthentificationRequestDTO content = new AuthentificationRequestDTO()
            {
                Nickname = "toto",
                Password = "totopassword"
            };

            string expected = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";

            //Act
            HttpResponseMessage response = await _client.PostAsJsonAsync(uri, content);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);

            string token = (await response.Content.ReadFromJsonAsync<TokenResponseDTO>()).Token;

            Assert.Equal(expected, token.Split(".")[0]);
        }

        [Fact]
        public async void RegisterShouldBeOk()
        {
            //Arrange
            string uri = "/api/members/register";

            CreateMemberRequestDTO createMemberRequestDTO = new CreateMemberRequestDTO()
            {
                Nickname = "tata",
                Email = "tata@toto.fr",
                Password = "tatapassword"
            };

            CreateMemberResponseDTO expected = new CreateMemberResponseDTO()
            {
                Nickname = createMemberRequestDTO.Nickname,
                Email = createMemberRequestDTO.Email,
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"
            };

            //Act
            HttpResponseMessage response = await _client.PostAsJsonAsync<CreateMemberRequestDTO>(uri, createMemberRequestDTO);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.Created);
            CreateMemberResponseDTO createMemberResponseDTO = await response.Content.ReadFromJsonAsync<CreateMemberResponseDTO>();

            Assert.True(createMemberResponseDTO.Nickname == expected.Nickname);
            Assert.True(createMemberResponseDTO.Email == expected.Email);
            Assert.True(createMemberResponseDTO.Token.Split(".")[0] == expected.Token );
        }

        [Fact]
        public async void UpdatePasswordShouldBeOk()
        {
            //Arrange
            string uri = "/api/members/2";

            UpdatePasswordRequestDTO updatePasswordRequestDTO = new UpdatePasswordRequestDTO()
            {
                Id = 2,
                Password = "titipassword"
            };

            MemberResponseDTO expected = new MemberResponseDTO()
            {
                Nickname = "titi",
                Email = "titi@toto.fr"
            };

            await SignIn("titi", "titipassword");
            
            //Act
            HttpResponseMessage response = await _client.PutAsJsonAsync<UpdatePasswordRequestDTO>(uri, updatePasswordRequestDTO);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            MemberResponseDTO memberResponseDTO = await response.Content.ReadFromJsonAsync<MemberResponseDTO>();

            Assert.True(memberResponseDTO.Nickname == expected.Nickname);
            Assert.True(memberResponseDTO.Email == expected.Email);

            //clean 
            SignOut();
        }

        [Fact]
        public async void UpdatePasswordShouldBeUnauthorizedAndBadRequest()
        {
            //Arrange
            string uri = "/api/members/5";

            UpdatePasswordRequestDTO updatePasswordRequestDTO = new UpdatePasswordRequestDTO()
            {
                Id = 2,
                Password = "titipassword"
            };

            await SignIn("titi", "titipassword");

            //Act
            HttpResponseMessage response = await _client.PutAsJsonAsync<UpdatePasswordRequestDTO>(uri, updatePasswordRequestDTO);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.Unauthorized);

            //clean 
            SignOut();
        }

        [Fact]
        public async void GetMembersShouldBeOk()
        {
            //Arrange
            string uri = "/api/members";

            await SignIn("toto", "totopassword");

            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);

            //clean
            SignOut();
        }

        [Fact]
        public async void GetMemberByIdShouldBeOk()
        {
            //Arrange
            string uri = "/api/members/2";

            await SignIn("toto", "totopassword");

            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);

            //clean
            SignOut();
        }

        [Fact]
        public async void GetMemberByIdShouldBeNotFound()
        {
            //Arrange
            string uri = "/api/members/5";

            await SignIn("toto", "totopassword");

            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);

            //clean
            SignOut();
        }
    }
}
