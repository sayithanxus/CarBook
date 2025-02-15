using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                AuthorImageUrl = x.Author.ImageUrl,
                AuthorDescription = x.Author.Description,
                AuthorName = x.Author.Name,
                BlogID = x.BlogID,
                Title = x.Title,
                Description = x.Description,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,

            }).ToList();
        }
    }
}