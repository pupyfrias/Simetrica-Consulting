using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimetricaConsulting.Application.Constants;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Application.Models.Dtos.V1.Task;
using SimetricaConsulting.Application.Models.Specification.V1;
using SimetricaConsulting.Application.Models.Wrappers;

namespace SimetricaConsulting.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TasksController : ControllerBase
    {
        #region Private Variable
        private readonly ITaskService _taskServiceAsync;

        #endregion Private Variable

        public TasksController(ITaskService taskServiceAsync)
        {
            _taskServiceAsync = taskServiceAsync;
        }

        #region Actions

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync([FromBody] TaskCreateDto taskCreateDto)
        {
            var task = await _taskServiceAsync.CreateAsync<TaskCreateDto, TaskDetailDto>(taskCreateDto);
            return CreatedAtAction(nameof(GetProjectAsync), new { id = task.Id }, task);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            await _taskServiceAsync.DeleteLogicalAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<TaskListDto>>>> GetAllTasksAsync([FromQuery] TaskQueryParameters taskQueryParameters)
        {
            var response = await _taskServiceAsync.GetAllProjectedWithPaginationAsync<TaskListDto, TaskSpecification>(taskQueryParameters);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<TaskDetailDto>>> GetProjectAsync(int id)
        {
            var response = await _taskServiceAsync.GetByIdProjectedAsync<int, TaskDetailDto>(id);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync(int id, [FromBody] TaskUpdateDto taskUpdateDto)
        {
            await _taskServiceAsync.UpdateAsync(id, taskUpdateDto);
            return NoContent();
        }

        [Authorize]
        [HttpGet("export/word")]
        public async Task<FileResult> ExportToWordAsync()
        {
            var file = await _taskServiceAsync.ExportToWordAsync<TaskExportDto>("Lista de Categorias");
            return File(file, FileContentType.Word, "Tasks.docx");
        }

        [Authorize]
        [HttpGet("export/pdf")]
        public async Task<FileResult> ExportToPdfAsync()
        {
            var file = await _taskServiceAsync.ExportToPdfAsync<TaskExportDto>("Lista de Categorias");
            return File(file, FileContentType.Pdf, "Tasks.pdf");
        }

        [Authorize]
        [HttpGet("export/excel")]
        public async Task<FileResult> ExportToExcelAsync()
        {
            var file = await _taskServiceAsync.ExportToExcelAsync<TaskExportDto>("Categorias");
            return File(file, FileContentType.Excel, "Tasks.xlsx");
        }

        #endregion Actions
    }
}