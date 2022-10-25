using Domain.DTO.Requests.Members;
using Domain.DTO.Requests.Responses;
using Domain.DTO.Requests.Security;
using Domain.DTO.Requests.Topic;
using Domain.DTO.Responses.Members;
using Domain.DTO.Responses.Responses;
using Domain.DTO.Responses.Topics;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinForms
{
    public class DAL
    {
        static DAL _dal = null;

        HttpClient _client = new HttpClient();
        string _token;
        int idMember = -1;
        List<string> roles = new();

        private DAL() { }

        public static DAL getDAL()
        {
            if (_dal == null)
                _dal = new DAL();

            return _dal;
        }

        public int IdMember { get => idMember; }
        public List<string> Roles { get => roles; }

        public async Task<string> LoginAsync(string nickname, string password)
        {
            AuthentificationRequestDTO authentificationRequestDTO = new() { Nickname = nickname, Password = password };
            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(authentificationRequestDTO), Encoding.UTF8, "application/json");

            var res = await _client.PostAsync($"{Settings1.Default.ConnectionString}/members/login", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                _token = content;
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var handler = new JwtSecurityTokenHandler();
                var tokenDecoded = handler.ReadJwtToken(_token);

                foreach (var item in tokenDecoded.Claims)
                {
                    switch (item.Type)
                    {
                        case ClaimTypes.Role:
                            roles.Add(item.Value);
                            break;

                        case ClaimTypes.NameIdentifier:
                            idMember = int.Parse(item.Value);
                            break;
                    }
                }

                return _token;
            }
            
            return null;
        }

        public async Task<string> UpdatePasswordAsync(int idMember, string newPassword)
        {
            UpdatePasswordRequestDTO updatePasswordRequestDTO = new() { Id = idMember, Password = newPassword };
            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(updatePasswordRequestDTO), Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"{Settings1.Default.ConnectionString}/members/{idMember}", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                return "Le mot de passe à été correctement modifié";
            }
            else
                return null;
        }

        public async Task<List<Topic>> GetAllTopicsByCategoryIdAsync(int id)
        {
            var res = await _client.GetAsync($"{Settings1.Default.ConnectionString}/forum/categories/{id}/topics");

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var lstDTO = JsonSerializer.Deserialize<List<TopicResponseDTO>>(content);

                return lstDTO.ConvertAll(topic => new Topic { Id = topic.Id, Title = topic.Title, Description = topic.Description, CategoryId = topic.CategoryId, MemberId = topic.MemberId });
            }
            else
                return null;
        }

        public async Task<bool> DeleteTopicAsync(int categoryId, int id)
        {
            var res = await _client.DeleteAsync($"{Settings1.Default.ConnectionString}/forum/categories/{categoryId}/topics/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<Topic> AddTopicAsync(string titre, string description, int categoryId, int memberId)
        {
            CreateTopicRequestDTO createTopicRequestDTO = new() { Title = titre, Description = description, CategoryId = categoryId, MemberId = memberId};

            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(createTopicRequestDTO), Encoding.UTF8, "application/json");

            var res = await _client.PostAsync($"{Settings1.Default.ConnectionString}/forum/categories/{categoryId}/topics/", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();

                var DTOTopic = JsonSerializer.Deserialize<TopicResponseDTO>(content);

                return new Topic() { Id = DTOTopic.Id, Title = DTOTopic.Title, Description = DTOTopic.Description, CategoryId = DTOTopic.CategoryId, MemberId = DTOTopic.MemberId };
            }
            else
                return null;
        }

        public async Task<Topic> UpdateTopicAsync(int id, string titre, string description, int categoryId)
        {
            UpdateTopicRequestDTO updateTopicRequestDTO = new() { Id = id, Title = titre, Description = description, CategoryId = categoryId };

            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(updateTopicRequestDTO), Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"{Settings1.Default.ConnectionString}/forum/categories/{categoryId}/topics/{id}", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();

                var DTOTopic = JsonSerializer.Deserialize<TopicResponseDTO>(content);

                return new Topic() { Id = DTOTopic.Id, Title = DTOTopic.Title, Description = DTOTopic.Description, CategoryId = DTOTopic.CategoryId, MemberId = DTOTopic.MemberId };
            }
            else
                return null;
        }

        public async Task<List<Response>> GetAllResponsesByTopicIdAsync(int categoryId, int id)
        {
            var res = await _client.GetAsync($"{Settings1.Default.ConnectionString}/forum/categories/{categoryId}/topics/{id}/responses");

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var lstDTO = JsonSerializer.Deserialize<List<ResponseResponseDTO>>(content);

                return lstDTO.ConvertAll(response => new Response { Id = response.Id, Content = response.Content, TopicId = response.TopicId, MemberName = response.MemberName });
            }
            else
                return null;
        }

        public async Task<bool> DeleteResponseAsync(int categoryId, int topicId, int id)
        {
            var res = await _client.DeleteAsync($"{Settings1.Default.ConnectionString}/forum/categories/{categoryId}/topics/{topicId}/responses/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<Response> AddResponseAsync(int categoryId, string contenu, int topicId, int memberId)
        {
            CreateResponseRequestDTO createResponseRequestDTO = new() { Content = contenu, TopicId = topicId, MemberId = memberId };

            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(createResponseRequestDTO), Encoding.UTF8, "application/json");

            var res = await _client.PostAsync($"{Settings1.Default.ConnectionString}/forum/categories/{categoryId}/topics/{topicId}/responses", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();

                var DTOResponse = JsonSerializer.Deserialize<ResponseResponseDTO>(content);

                return new Response() { Id = DTOResponse.Id, Content = DTOResponse.Content, TopicId = DTOResponse.TopicId, MemberName = DTOResponse.MemberName };
            }
            else
                return null;
        }
    }
}
