using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Blog
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleDto>().ForMember(a => a.CreatedDateTime,
                opt => opt.MapFrom(x => 
                    string.Join(" at ", x.CreatedDate.ToShortDateString(), x.CreatedDate.ToShortTimeString())));

            CreateMap<Category, CategoryDto>();

            CreateMap<CategoryDto, Category>();
            CreateMap<ArticleForCreationDto, Article>().ReverseMap();
            CreateMap<ArticleForCreationDto, Article>();


      

            CreateMap<ArticleForUpdateDto, Article>();
            CreateMap<Article, ArticleForUpdateDto>();

            CreateMap<ArticleForUpdateDto, Article>().ReverseMap();


            CreateMap<Category, CategoryForCreationDto>();

            CreateMap<CategoryForCreationDto, Category>();

            CreateMap<CategoryForUpdateDto, Category>();

           
            CreateMap<UserForRegistrationDto, User>();


        }

    }
}
