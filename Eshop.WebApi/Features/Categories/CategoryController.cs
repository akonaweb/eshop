using Eshop.Domain;
using Eshop.Persistence;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Eshop.WebApi.Features.Categories
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly EshopDbContext dbContext;

        public CategoryController(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = nameof(GetCategories))]
        [ProducesResponseType(typeof(IEnumerable<GetCategoryResponseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetCategoriesResponseDto>>> GetCategories()
        [HttpGet]
        public List<Category> GetCategories()
        {
            return dbContext.CategoriesViews.ToList();
        }

        [HttpGet("{id}", Name = nameof(GetCategory))]
        [ProducesResponseType(typeof(GetCategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateCategoryResponseDto>> GetCategoryForUpdate(int id, UpdateCategoryResponseDto request)
        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            var result = await mediator.Send(new GetCategory.Query(id));
            return Ok(result);
        }

        [HttpPost(Name = nameof(AddCategory))]
        [ProducesResponseType(typeof(AddCategoryResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddCategoryResponseDto>> AddCategory(AddCategoryRequestDto requestDto)
        {
            var result = await mediator.Send(new AddCategory.Command(requestDto));
            return CreatedAtAction(nameof(GetCategory), new { id = result.Id }, result);
        }

        [HttpPut("{id}", Name = nameof(UpdateCategory))]
        [ProducesResponseType(typeof(UpdateCategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateCategoryResponseDto>> UpdateCategory(int id, UpdateCategoryResponseDto request)
        {
            var result = await mediator.Send(new UpdateCategory.Command(id, request));
            return Ok(result);
        }

        [HttpDelete("{id}", Name = nameof(DeleteCategory))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await mediator.Send(new DeleteCategory.Command(id));
            return NoContent();
        }
    }
}
