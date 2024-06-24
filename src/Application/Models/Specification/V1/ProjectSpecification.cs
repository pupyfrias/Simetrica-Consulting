using SimetricaConsulting.Application.Extensions;
using SimetricaConsulting.Application.Models.DTOs.V1.Project;
using SimetricaConsulting.Domain.Entities.V1;
using System.Linq.Expressions;

namespace SimetricaConsulting.Application.Models.Specification.V1
{
    public class ProjectSpecification : Specification<Project>
    {
        public ProjectSpecification(ProjectQueryParameters queryParameters, bool applyPagination) : base(queryParameters, applyPagination)
        {
            #region Criteria

            if (queryParameters.UserId != null)
            {
                Expression<Func<Project, bool>> expression = Project => Project.UserId.Contains(queryParameters.UserId);

                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }


            if (queryParameters.Name != null)
            {
                Expression<Func<Project, bool>> expression = Project => Project.Name.Contains(queryParameters.Name);

                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }



            if (queryParameters.Description != null)
            {
                Expression<Func<Project, bool>> expression = Project => Project.Description.Contains(queryParameters.Description);

                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }



            #endregion Criteria
        }
    }
}