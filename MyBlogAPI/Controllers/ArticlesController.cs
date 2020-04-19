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
        public ActionResult<List<Article>> Get()
        {
            return Ok(_articleRepository.GetAll());
        }

        // GET: api/Articles/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Article> Get(int id)
        {
            Article articleFound = _articleRepository.Get(id);
            if (articleFound == null) return NotFound();
            else return Ok(articleFound);
        }

        // POST: api/Articles
        [HttpPost]
        public ActionResult<Article> Post([FromBody] Article article)
        {
            return CreatedAtAction(nameof(Post), _articleRepository.Add(article));
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
            Response.StatusCode = 204;
        }
    }
}
