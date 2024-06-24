using SimetricaConsulting.Application.Contracts;
using SimetricaConsulting.Application.Utilities;

namespace SimetricaConsulting.Application.Models.DTOs.V1.Comment
{
    public class CommentQueryParameters : QueryParametersBase
    {
        public  string? UserId { get; set; }
    }
}