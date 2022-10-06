using Domain.DTO.Requests.Security;
using Domain.DTO.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest.Fixture
{
    public abstract class AbstractIntegrationTest : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;

        public AbstractIntegrationTest(ApiWebApplicationFactory fixture)
        {
            _factory = fixture;
            _client = _factory.CreateClient();
        }


        public async Task SignIn(string nickname, string password)
        {
            HttpResponseMessage responseLogin = await _client.PostAsJsonAsync("api/members/login", new AuthentificationRequestDTO()
            {
                Nickname = nickname,
                Password = password
            });

            var login = await responseLogin.Content.ReadFromJsonAsync<TokenResponseDTO>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", login.Token);
        }


        public void SignOut()
        {
            _client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
