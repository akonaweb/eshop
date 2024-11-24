using MediatR;

namespace UpdateCategory
{
    internal class Command : IRequest<object>
    {
        public Command(int id, UpdateCategoryResponseDto request)
        {
        }
    }
}