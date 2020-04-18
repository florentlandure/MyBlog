using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogCore.Models;
using MyBlogCore.Repositories;

namespace MyBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        // GET: api/Articles
        [HttpGet]
        public List<Article> Get()
        {
            Console.WriteLine("Get articles");
            return _articleRepository.GetAll();
        }

        // GET: api/Articles/5
        [HttpGet("{id}", Name = "Get")]
        public Article Get(int id)
        {
            return _articleRepository.Get(id);
        }

        // POST: api/Articles
        [HttpPost]
        public void Post([FromBody] Article article)
        {
            Console.WriteLine(article);
            _articleRepository.Add(article);
            Response.StatusCode = 204;
        }

        // PUT: api/Articles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _articleRepository.Remove(id);
        }
    }
}
