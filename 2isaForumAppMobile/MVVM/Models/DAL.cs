using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2isaForumAppMobile
{
    public class DAL
    {
        private static volatile DAL _instance;
        private static readonly object _syncRoot = new Object();
        private readonly HttpClient _httpClient = new HttpClient();

        private DAL() { } // Singleton = constructeur privé

        public static DAL Instance // Propriété static pour créer l'instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot) // Verrou pour les accès multi threads
                    {
                        if (_instance == null)
                        {
                            _instance = new DAL();
                        }
                    }
                }

                return _instance;
            }
        }

        /*
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int MemberId { get; set; }
        */
        public async Task<List<BOTopic>> GetTopicsByCategoryId(int categoryId)
        {
            Uri uri = new Uri($"http://user39.2isa.org/api/forum/categories/{categoryId}/topics");
            using (HttpResponseMessage response = await _httpClient.GetAsync(uri))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var dtoTopics = JsonSerializer.Deserialize<List<DTOTopic>>(res);
                    return dtoTopics.Select(t => new BOTopic() { Id = t.Id, Title = t.Title, Description = t.Description, CategoryId = t.CategoryId, MemberId = t.MemberId }).ToList();
                }
            }

            return null;
        }

        public async Task<List<BOResponse>> GetResponsesByTopicId(int categoryId, int topicId)
        {
            Uri uri = new Uri($"http://user39.2isa.org/api/forum/categories/{categoryId}/topics/{topicId}/responses");
            using (HttpResponseMessage response = await _httpClient.GetAsync(uri))
            {
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var dtoResponses = JsonSerializer.Deserialize<List<DTOResponse>>(res);
                    return dtoResponses.Select(r => new BOResponse() { Id = r.Id, Content = r.Content, TopicId = r.TopicId, MemberName = r.MemberName }).ToList();
                }
            }

            return null;
        }
    }
}
