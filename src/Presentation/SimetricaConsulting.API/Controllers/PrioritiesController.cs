using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimetricaConsulting.Application.Constants;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Application.Models.Dtos.V1.Priority;
using SimetricaConsulting.Application.Models.Wrappers;

namespace SimetricaConsulting.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PrioritiesController : ControllerBase
    {
        #region Private Variable
        private readonly IPriorityService _priorityServiceAsync;

        #endregion Private Variable

        public PrioritiesController(IPriorityService priorityServiceAsync)
        {
            _priorityServiceAsync = priorityServiceAsync;
        }

        #region Actions

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync([FromBody] PriorityCreateDto priorityCreateDto)
        {
            var priority = await _priorityServiceAsync.CreateAsync<PriorityCreateDto, PriorityDetailDto>(priorityCreateDto);
            return CreatedAtAction(nameof(GetProjectAsync), new { id = priority.Id }, priority);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            await _priorityServiceAsync.DeleteLogicalAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<PriorityListDto>>>> GetAllPrioritiesAsync()
        {
            var response = await _priorityServiceAsync.GetAllProjectedAsync<PriorityListDto>();
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PriorityDetailDto>>> GetProjectAsync(int id)
        {
            var response = await _priorityServiceAsync.GetByIdProjectedAsync<int, PriorityDetailDto>(id);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync(int id, [FromBody] PriorityUpdateDto priorityUpdateDto)
        {
            await _priorityServiceAsync.UpdateAsync(id, priorityUpdateDto);
            return NoContent();
        }

        [Authorize]
        [HttpGet("export/word")]
        public async Task<FileResult> ExportToWordAsync()
        {
            var file = await _priorityServiceAsync.ExportToWordAsync<PriorityExportDto>("Lista de Categorias");
            return File(file, FileContentType.Word, "Priorities.docx");
        }

        [Authorize]
        [HttpGet("export/pdf")]
        public async Task<FileResult> ExportToPdfAsync()
        {
            var file = await _priorityServiceAsync.ExportToPdfAsync<PriorityExportDto>("Lista de Categorias");
            return File(file, FileContentType.Pdf, "Priorities.pdf");
        }

        [Authorize]
        [HttpGet("export/excel")]
        public async Task<FileResult> ExportToExcelAsync()
        {
            var file = await _priorityServiceAsync.ExportToExcelAsync<PriorityExportDto>("Categorias");
            return File(file, FileContentType.Excel, "Priorities.xlsx");
        }

        #endregion Actions
    }
}