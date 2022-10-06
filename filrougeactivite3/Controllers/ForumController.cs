using BLLS;
using Domain.DTO.Requests.Responses;
using Domain.DTO.Requests.Topic;
using Domain.DTO.Responses.Categories;
using Domain.DTO.Responses.Responses;
using Domain.DTO.Responses.Topics;
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
    [Route("api/forum")]
    [Authorize]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;
        private readonly IMemberService _memberService;
        public ForumController(IForumService forumService, IMemberService memberService)
        {
            _forumService = forumService;
            _memberService = memberService;
        }

        /// <summary>
        /// Obtenir toutes les catégories
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _forumService.GetCategoriesAsync();

            //Construction de la réponse
            var categoriesResponse = categories.Select(category => new CategoryResponseDTO
            {
                Name = category.Name
            });

            return Ok(categoriesResponse);
        }

        /// <summary>
        /// Obtenir tous les sujets d'une catégorie
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("categories/{categoryId}/topics")]
        public async Task<IActionResult> GetTopics([FromRoute] int categoryId)
        {
            var topics = await _forumService.GetTopicsByCategoryIdAsync(categoryId);
            var category = await _forumService.GetCategoryByIdAsync(categoryId);

            //Construction de la réponse
            var topicsResponse = topics.Select(topic => new TopicResponseDTO
            {
                Title = topic.Title,
                Description = topic.Description,
                CategoryName = category.Name,
                MemberId = topic.MemberId
            });

            return Ok(topicsResponse);
        }

        /// <summary>
        /// Obtenir un sujet spécifique
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("categories/{categoryId}/topics/{id}")]
        public async Task<IActionResult> GetTopicById([FromRoute] int categoryId, [FromRoute] int id)
        {
            var topic = await _forumService.GetTopicByIdAsync(id);
            var category = await _forumService.GetCategoryByIdAsync(categoryId);
            
            if (topic is null) return NotFound();

            // Réponse
            TopicResponseDTO topicResponse = new TopicResponseDTO()
            {
                Title = topic.Title,
                Description = topic.Description,
                CategoryName = category.Name,
                MemberId = topic.MemberId
            };

            return Ok(topicResponse);
        }

        /// <summary>
        /// Ajouter un sujet
        /// </summary>
        /// <param name="createTopicRequestDTO"></param>
        /// <returns></returns>
        [HttpPost("categories/{categoryId}/topics")]
        public async Task<IActionResult> CreateTopic([FromBody] CreateTopicRequestDTO createTopicRequestDTO)
        {
            //Validation des données envoyer par le client
            var author = await _memberService.GetMemberByIdAsync(createTopicRequestDTO.MemberId);
            if (createTopicRequestDTO.MemberId == 0 || createTopicRequestDTO.Title == null || author is null)
            {
                return BadRequest("L'auteur est requis et le titre ne doit pas être vide");
            }

            //DTO -> Objet Métier
            Topic newTopic = new Topic()
            {
                Title = createTopicRequestDTO.Title,
                Description = createTopicRequestDTO.Description,
                CategoryId = createTopicRequestDTO.CategoryId,
                MemberId = createTopicRequestDTO.MemberId
            };

            var topic = await _forumService.AddTopicAsync(newTopic);

            if (topic != null)
            {
                var category = await _forumService.GetCategoryByIdAsync(topic.CategoryId);

                return CreatedAtAction(nameof(GetTopicById), new { categoryId = topic.CategoryId, id = topic.Id }, new TopicResponseDTO()
                {
                    Title = topic.Title,
                    Description = topic.Description,
                    CategoryName = category.Name,
                    MemberId = topic.MemberId
                });
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Mettre à jour un sujet
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="id"></param>
        /// <param name="updateTopicRequestDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "MODERATOR")]
        [HttpPut("categories/{categoryId}/topics/{id}")]
        public async Task<IActionResult> UpdateTopic([FromRoute] int categoryId, [FromRoute] int id, [FromBody] UpdateTopicRequestDTO updateTopicRequestDTO)
        {
            //Vérification
            if (id != updateTopicRequestDTO.Id) return BadRequest();


            /// DTO -> ObjetMétier
            var topicModified = new Topic()
            {
                Id = updateTopicRequestDTO.Id,
                Title = updateTopicRequestDTO.Title,
                Description = updateTopicRequestDTO.Description,
                CategoryId = updateTopicRequestDTO.CategoryId
            };

            //Actions 
            var topic = await _forumService.ModifyTopicAsync(topicModified);

            //Creation Reponse
            //if (topic is null) return NotFound();

            var category = await _forumService.GetCategoryByIdAsync(topic.CategoryId);

            var reponse = new TopicResponseDTO()
            {
                Title = topic.Title,
                Description = topic.Description,
                CategoryName = category.Name,
                MemberId = topic.MemberId
            };

            return Ok(reponse);
        }

        /// <summary>
        /// Supprimer un sujet
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "MODERATOR")]
        [HttpDelete("categories/{categoryId}/topics/{id}")]
        public async Task<IActionResult> DeleteTopicById([FromRoute] int categoryId, [FromRoute] int id)
        {
            var isDeleted = await _forumService.DeleteTopicAsync(id);
            return (isDeleted) ? NoContent() : NotFound();
        }

        /// <summary>
        /// Obtenir toutes les réponses d'un sujet
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("categories/{categoryId}/topics/{topicId}/responses")]
        public async Task<IActionResult> GetResponses([FromRoute] int categoryId, [FromRoute] int topicId)
        {
            var responses = await _forumService.GetResponsesByTopicIdAsync(topicId);
            var topic = await _forumService.GetTopicByIdAsync(topicId);

            //Construction de la réponse
            var responsesResponse = responses.Select(response => new ResponseResponseDTO
            {
                Content = response.Content,
                TopicTitle = topic.Title,
                MemberId = response.MemberId
            });

            return Ok(responsesResponse);
        }

        /// <summary>
        /// Obtenir une réponse spécifique
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("categories/{categoryId}/topics/{topicId}/responses/{id}")]
        public async Task<IActionResult> GetResponseById([FromRoute] int categoryId, [FromRoute] int topicId, [FromRoute] int id)
        {
            var response = await _forumService.GetResponseByIdAsync(id);
            var topic = await _forumService.GetTopicByIdAsync(topicId);

            if (response is null) return NotFound();

            // Réponse
            ResponseResponseDTO ResponseResponse = new ResponseResponseDTO()
            {
                Content = response.Content,
                TopicTitle = topic.Title,
                MemberId = response.MemberId
            };

            return Ok(ResponseResponse);
        }

        /// <summary>
        /// Ajouter une réponse à un sujet
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="topicId"></param>
        /// <param name="createResponseRequestDTO"></param>
        /// <returns></returns>
        [HttpPost("categories/{categoryId}/topics/{topicId}/responses")]
        public async Task<IActionResult> CreateResponse([FromRoute] int categoryId, [FromRoute] int topicId, [FromBody] CreateResponseRequestDTO createResponseRequestDTO)
        {
            //Validation des données envoyer par le client
            var author = await _memberService.GetMemberByIdAsync(createResponseRequestDTO.MemberId);
            if (createResponseRequestDTO.MemberId == 0 || author is null)
            {
                return BadRequest("L'auteur est requis");
            }

            //DTO -> Objet Métier
            Response newResponse = new Response()
            {
                Content = createResponseRequestDTO.Content,
                TopicId = createResponseRequestDTO.TopicId,
                MemberId = createResponseRequestDTO.MemberId
            };

            var response = await _forumService.AddResponseAsync(newResponse);

            if (response != null)
            {
                var topic = await _forumService.GetTopicByIdAsync(response.TopicId);

                return CreatedAtAction(nameof(GetTopicById), new { categoryId = topic.CategoryId, id = topic.Id }, new ResponseResponseDTO()
                {
                    Content = response.Content,
                    TopicTitle = topic.Title,
                    MemberId = response.MemberId
                });
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Supprimer une réponse d'un sujet
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="topicId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "MODERATOR")]
        [HttpDelete("categories/{categoryId}/topics/{topicId}/responses/{id}")]
        public async Task<IActionResult> DeleteResponseById([FromRoute] int categoryId, [FromRoute] int topicId, [FromRoute] int id)
        {
            var isDeleted = await _forumService.DeleteResponseAsync(id);
            return (isDeleted) ? NoContent() : NotFound();
        }
    }
}
