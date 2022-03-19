using Contracts;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;

namespace Blog.Utility;

public class ArticleLinks : IArticleLinks
{
	private readonly LinkGenerator _linkGenerator;
	private readonly IDataShaper<ArticleDto> _dataShaper;

	public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } =
		new Dictionary<string, MediaTypeHeaderValue>();

	public ArticleLinks(LinkGenerator linkGenerator, IDataShaper<ArticleDto> dataShaper)
	{
		_linkGenerator = linkGenerator;
		_dataShaper = dataShaper;
	}

	public LinkResponse TryGenerateLinks(IEnumerable<ArticleDto> articlesDto, string fields, Guid categoryId, HttpContext httpContext)
	{
		var shapedArticles = ShapeData(articlesDto, fields);

		if (ShouldGenerateLinks(httpContext))
			return ReturnLinkdedArticles(articlesDto, fields, categoryId, httpContext, shapedArticles);

		return ReturnShapedArticles(shapedArticles);
	}

	public LinkResponse TryGenerateLinksWithoutCategoryId(IEnumerable<ArticleDto> articlesDto, string fields, HttpContext httpContext)
	{
		var shapedArticles = ShapeData(articlesDto, fields);

		if (ShouldGenerateLinks(httpContext))
			return ReturnLinkdedArticlesWithoutCategoryId(articlesDto, fields, httpContext, shapedArticles);

		return ReturnShapedArticles(shapedArticles);
	}

	private List<Entity> ShapeData(IEnumerable<ArticleDto> articlesDto, string fields) =>
		_dataShaper.ShapeData(articlesDto, fields)
			.Select(e => e.Entity)
			.ToList();

	private bool ShouldGenerateLinks(HttpContext httpContext)
	{
		var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];

		return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
	}


	private LinkResponse ReturnShapedArticles(List<Entity> shapedArticles) =>
		new LinkResponse { ShapedEntities = shapedArticles };


	private LinkResponse ReturnLinkdedArticles(IEnumerable<ArticleDto> articlesDto,
		string fields, Guid categoryId, HttpContext httpContext, List<Entity> shapedArticles)
	{
		var articleDtoList = articlesDto.ToList();

		for (var index = 0; index < articleDtoList.Count(); index++)
		{
			var articleLinks = CreateLinksForArticle(httpContext, categoryId, articleDtoList[index].Id, fields);
			shapedArticles[index].Add("Links", articleLinks);
		}

		var articleCollection = new LinkCollectionWrapper<Entity>(shapedArticles);
		var linkedArticles = CreateLinksForArticles(httpContext, articleCollection);

		return new LinkResponse { HasLinks = true, LinkedEntities = linkedArticles };
	}


	private LinkResponse ReturnLinkdedArticlesWithoutCategoryId(IEnumerable<ArticleDto> articlesDto,
		string fields, HttpContext httpContext, List<Entity> shapedArticles)
	{
		var articleDtoList = articlesDto.ToList();

		for (var index = 0; index < articleDtoList.Count(); index++)
		{
			var articleLinks = CreateLinksForArticleWithoutCategoryId(httpContext, articleDtoList[index].Id, fields);
			shapedArticles[index].Add("Links", articleLinks);
		}

		var articleCollection = new LinkCollectionWrapper<Entity>(shapedArticles);
		var linkedArticles = CreateLinksForArticles(httpContext, articleCollection);

		return new LinkResponse { HasLinks = true, LinkedEntities = linkedArticles };
	}

	private List<Link> CreateLinksForArticle(HttpContext httpContext, Guid categoryId, Guid id, string? fields = "")
	{
		var links = new List<Link>
			{
				new Link(_linkGenerator.GetUriByAction(httpContext, "GetArticleInCategory", values: new { id, categoryId, fields }),"self","GET"),
				new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteArticleInCategory", values: new { categoryId, id }),"delete_article","DELETE"),
				new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateArticleInCategory", values: new { categoryId, id }),"update_article","PUT"),
				new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateArticleInCategory", values: new { categoryId, id }),"partially_update_article","PATCH")
			};
		return links;
	}

	private List<Link> CreateLinksForArticleWithoutCategoryId(HttpContext httpContext, Guid id, string? fields = "")
	{
		var links = new List<Link>
			{
				new Link(_linkGenerator.GetUriByAction(httpContext, "GetArticle", values: new { id, fields }),"self","GET")
			};
		return links;
	}

	private LinkCollectionWrapper<Entity> CreateLinksForArticles(HttpContext httpContext,LinkCollectionWrapper<Entity> articlesWrapper)
	{
		articlesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetArticlesInCategory", values: new { }),"self","GET"));

		return articlesWrapper;
	}
}
