using AutoMapper;
using SimetricaConsulting.Application.Models.Dtos.V1.Comment;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Application.Mappings.V1
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentListDto>();
            CreateMap<Comment, CommentExportDto>();
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentDetailDto>();
        }
    }
}