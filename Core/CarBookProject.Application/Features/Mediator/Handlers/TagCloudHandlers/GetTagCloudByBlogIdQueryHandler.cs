using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using CarBookProject.Application.Interfaces.TagCloudInterfaces;
using CarBookProject.Application.TagClouds.Mediator.Queries.TagCloudQueries;
using MediatR;

public class GetTagCloudByBlogIdQueryHandler
    : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
{
    private readonly ITagCloudRepository _repository;

    public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
    {
        _repository = repository;
    }

    public Task<List<GetTagCloudByBlogIdQueryResult>> Handle(
        GetTagCloudByBlogIdQuery request,
        CancellationToken cancellationToken)
    {
        // Senkron repo çağrısı
        var values = _repository.GetTagCloudByBlogId(request.Id);

        var result = values.Select(x => new GetTagCloudByBlogIdQueryResult
        {
            TagCloudId = x.TagCloudId,
            BlogId = x.BlogId,
            Title = x.Title
        }).ToList();

        return Task.FromResult(result);
    }
}
