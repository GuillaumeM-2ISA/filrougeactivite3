using Domain.DTO.Requests.Security;
using Domain.DTO.Requests.Topic;
using Domain.DTO.Responses.Topics;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinForms
{
    public class DAL
    {
        HttpClient _client = new HttpClient();
        string _token;

        public async Task<string> Login(string nickname, string password)
        {
            AuthentificationRequestDTO authentificationRequestDTO = new() { Nickname = nickname, Password = password };
            var jsonBodyParameter = new StringContent(JsonSerializer.Serialize(authentificationRequestDTO), Encoding.UTF8, "application/json");

            var res = await _client.PostAsync($"{Settings1.Default.ConnectionString}/members/login", jsonBodyParameter);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                _token = content;
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                
                return _token;
            }
            
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
    }
}
