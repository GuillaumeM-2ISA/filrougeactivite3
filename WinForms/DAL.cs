using Domain.DTO.Requests.Security;
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

                return lstDTO.ConvertAll(topic => new Topic { Title = topic.Title, Description = topic.Description, CategoryId = topic.CategoryId, MemberId = topic.MemberId });
            }
            else
                return null;
        }
    }
}
