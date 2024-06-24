using SimetricaConsulting.Application.Extensions;
using SimetricaConsulting.Application.Models.Dtos.V1.Task;
using System.Linq.Expressions;
using Task = SimetricaConsulting.Domain.Entities.V1.Task;

namespace SimetricaConsulting.Application.Models.Specification.V1
{
    public class TaskSpecification : Specification<Task>
    {
        public TaskSpecification(TaskQueryParameters queryParameters, bool applyPagination) : base(queryParameters, applyPagination)
        {
            #region Criteria

            if (queryParameters.UserId != null)
            {
                Expression<Func<Task, bool>> expression = Task => Task.UserId.Contains(queryParameters.UserId);

                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            if (queryParameters.ProjectId != null)
            {
                Expression<Func<Task, bool>> expression = Task => Task.ProjectId!.Equals(queryParameters.ProjectId);

                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }


            #endregion Criteria
        }
    }
}