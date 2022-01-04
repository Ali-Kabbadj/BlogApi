using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace Blog
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/xml"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(CategoryForCreationDto).IsAssignableFrom(type) || typeof(IEnumerable<CategoryForCreationDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<CategoryForCreationDto>)
            {
                foreach (var category in (IEnumerable<CategoryForCreationDto>)context.Object)
                {
                    FormatCsv(buffer, category);
                }
            }
            else if (context.Object is CategoryForCreationDto)
            {
                FormatCsv(buffer, (CategoryForCreationDto)context.Object);
            }

            else if (context.Object is ArticleDto)
            {
                FormatCsv(buffer, (ArticleDto)context.Object);
            }

            else if (context.Object is IEnumerable<ArticleDto>)
            {
                foreach (var article in (IEnumerable<ArticleDto>)context.Object)
                {
                    FormatCsv(buffer, article);
                }
            }
            else if (context.Object is CategoryForCreationDto)
            {
                FormatCsv(buffer, (CategoryForCreationDto)context.Object);
            }
            else if (context.Object is IEnumerable<CategoryForCreationDto>)
            {
                foreach (var categoryC in (IEnumerable<CategoryForCreationDto>)context.Object)
                {
                    FormatCsv(buffer, categoryC);
                }
            }



            await response.WriteAsJsonAsync( context.Object,default);
        }

        private void FormatCsv(StringBuilder buffer, ArticleDto article)
        {
            buffer.AppendLine($"{article.Id},\"{article.Title},\"{article.Summary},\",{article.CreatedDateTime},\"");
        }

        private static void FormatCsv(StringBuilder buffer, CategoryForCreationDto category)
        {
            buffer.AppendLine($"{category.Name},\"{category.Articles}\"");
        }

        private static void FormatCsv(StringBuilder buffer, string errorCode,string errorMessage)
        {
            buffer.AppendLine($"{errorCode},\"{errorMessage}\"");
        }
    }
}
