using SimetricaConsulting.Application.Extensions;
using SimetricaConsulting.Application.Models.Dtos.V1.Comment;
using SimetricaConsulting.Application.Models.DTOs.V1.Comment;
using System.Linq.Expressions;
using Comment = SimetricaConsulting.Domain.Entities.V1.Comment;

namespace SimetricaConsulting.Application.Models.Specification.V1
{
    public class CommentSpecification : Specification<Comment>
    {
        public CommentSpecification(CommentQueryParameters queryParameters, bool applyPagination) : base(queryParameters, applyPagination)
        {
            #region Criteria

            if (queryParameters.UserId != null)
            {
                Expression<Func<Comment, bool>> expression = Comment => Comment.UserId.Contains(queryParameters.UserId);

                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }



            #endregion Criteria
        }
    }
}