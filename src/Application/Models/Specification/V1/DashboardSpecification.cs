using SimetricaConsulting.Application.Extensions;
using SimetricaConsulting.Application.Models.DTOs.V1.Dashboard;
using SimetricaConsulting.Domain.Entities.V1;
using System.Linq.Expressions;

namespace SimetricaConsulting.Application.Models.Specification.V1
{
    public class DashboardSpecification : Specification<Dashboard>
    {
        public DashboardSpecification(DashboardQueryParameters queryParameters, bool applyPagination) : base(queryParameters, applyPagination)
        {
            #region Criteria

            if (queryParameters.UserId != null)
            {
                Expression<Func<Dashboard, bool>> expression = Dashboard => Dashboard.UserId.Contains(queryParameters.UserId);

                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }



            #endregion Criteria
        }
    }
}