using Domain.DTO.Requests.Topic;
using Domain.DTO.Responses.Topics;
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
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class ForumControllerTest : AbstractIntegrationTest
    {
        public ForumControllerTest(ApiWebApplicationFactory fixture) : base(fixture)
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
        public async void GetCategoriesShouldBeOk()
        {
            //Arrange
            string uri = "/api/forum/categories";

            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async void GetTopicsShouldBeOk()
        {
            //Arrange
            string uri = "/api/forum/categories/1/topics";

            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async void GetTopicByIdShouldBeOk()
        {
            //Arrange
            string uri = "/api/forum/categories/1/topics/1";

            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async void GetTopicByIdShouldBeNotFound()
        {
            //Arrange
            string uri = "/api/forum/categories/1/topics/5";

            //Act
            HttpResponseMessage response = await _client.GetAsync(uri);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async void CreateTopicShouldBeOkAndCreated()
        {
            //Arrange
            string uri = "/api/forum/categories/1/topics";

            CreateTopicRequestDTO createTopicRequestDTO = new CreateTopicRequestDTO()
            {
                Title = "Python",
                Description = "Uniquement pour les maths et la science ?",
                CategoryId = 1,
                MemberId = 1
            };

            TopicResponseDTO expected = new TopicResponseDTO()
            {
                Title = createTopicRequestDTO.Title,
                Description = createTopicRequestDTO.Description,
                CategoryName = "Développement",
                MemberId = 1
            };

            await SignIn("toto", "totopassword");

            //Act
            HttpResponseMessage response = await _client.PostAsJsonAsync<CreateTopicRequestDTO>(uri, createTopicRequestDTO);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.Created);
            TopicResponseDTO topicResponseDTO = await response.Content.ReadFromJsonAsync<TopicResponseDTO>();

            Assert.True(topicResponseDTO.Title == expected.Title);
            Assert.True(topicResponseDTO.Description == expected.Description);
            Assert.True(topicResponseDTO.CategoryName == expected.CategoryName);
            Assert.True(topicResponseDTO.MemberId == expected.MemberId);

            //clean 
            SignOut();
        }

        [Fact]
        public async void CreateTopicShouldBeABadRequest()
        {
            //Arrange
            string uri = "/api/forum/categories/1/topics";

            CreateTopicRequestDTO createTopicRequestDTO = new CreateTopicRequestDTO()
            {
                Title = "Python",
                Description = "Uniquement pour les maths et la science ?",
                CategoryId = 1,
                MemberId = 0
            };

            await SignIn("toto", "totopassword");

            //Act
            HttpResponseMessage response = await _client.PostAsJsonAsync<CreateTopicRequestDTO>(uri, createTopicRequestDTO);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);

            //clean 
            SignOut();
        }

        [Fact]
        public async void UpdateTopicShouldBeOkAndUpdated()
        {
            //Arrange
            string uri = "/api/forum/categories/1/topics/1";

            UpdateTopicRequestDTO updateTopicRequestDTO = new UpdateTopicRequestDTO()
            {
                Id = 1,
                Title = "Framework .NET C#",
                Description = "L'utilisez-vous ?",
                CategoryId = 1
            };

            TopicResponseDTO expected = new TopicResponseDTO()
            {
                Title = "Framework .NET C#",
                Description = "L'utilisez-vous ?",
                CategoryName = "Développement",
                MemberId = 1
            };

            await SignIn("toto", "totopassword");

            //Act
            HttpResponseMessage response = await _client.PutAsJsonAsync<UpdateTopicRequestDTO>(uri, updateTopicRequestDTO);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            TopicResponseDTO topicResponseDTO = await response.Content.ReadFromJsonAsync<TopicResponseDTO>();

            Assert.True(topicResponseDTO.Title == expected.Title);
            Assert.True(topicResponseDTO.Description == expected.Description);
            Assert.True(topicResponseDTO.CategoryName == expected.CategoryName);
            Assert.True(topicResponseDTO.MemberId == expected.MemberId);

            //clean 
            SignOut();
        }
    }
}
