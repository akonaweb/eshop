using Eshop.Domain;
using Eshop.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eshop.WebApi.Features.Categories
{
    public class GetCategories
    {
        public record Query() : IRequest<IEnumerable<GetCategoriesResponseDto>>;

        public class Handler : IRequestHandler<Query, IEnumerable<GetCategoriesResponseDto>>
        {
            private readonly EshopDbContext dbContext;

            public Handler(EshopDbContext dbContext)
            {
                this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            }

            public async Task<IEnumerable<GetCategoriesResponseDto>> Handle(Query command, CancellationToken cancellationToken)
            {
                var categories = await dbContext.CategoriesViews
                    .ToListAsync(cancellationToken);

                return (IEnumerable<GetCategoriesResponseDto>)categories.Select(GetCategoriesResponseDto.Map).ToList();
            }
        }
    }

    public class GetCategoriesResponseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        internal static object Map(Category category, int arg2)
        {
            throw new NotImplementedException();
        }
    }
}