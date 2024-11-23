using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private IRepository _repository;

        public ArticlesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Article), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Article> Get(Guid id)
        {
            var article = _repository.Get(id);

            if (article == null)
            {
                return NotFound("Article not found.");
            }

            return Ok(article);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Article> Create(Article article)
        {
            if (string.IsNullOrWhiteSpace(article.Title))
            {
                return BadRequest();
            }

            var createdArticleId = _repository.Create(article);
            var createdArticle = _repository.Get(createdArticleId);

            return Created($"/api/articles/{createdArticleId}", createdArticle);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(Guid id)
        {
            var isDeleted = _repository.Delete(id);

            if (!isDeleted)
            {
                return NotFound("Article not found.");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update(Guid id, Article articleToUpdate)
        {
            if (id != articleToUpdate.Id)
            {
                return BadRequest();
            }

            var isUpdated = _repository.Update(articleToUpdate);

            if (!isUpdated)
            {
                return NotFound("Article not found.");
            }

            return NoContent();
        }
    }

    public interface IRepository
    {
        // Returns a found article or null.
        Article Get(Guid id);

        // Creates a new article and returns its identifier.
        // Throws an exception if a article is null.
        // Throws an exception if a title is null or empty.
        Guid Create(Article article);

        // Returns true if an article was deleted or false if it was not possible to find it.
        bool Delete(Guid id);

        // Returns true if an article was updated or false if it was not possible to find it.
        // Throws an exception if an articleToUpdate is null.
        // Throws an exception or if a title is null or empty.
        bool Update(Article articleToUpdate);
    }

    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}

