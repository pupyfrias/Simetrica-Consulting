using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimetricaConsulting.Application.Constants;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Application.Models.Dtos.V1.Status;
using SimetricaConsulting.Application.Models.Wrappers;

namespace SimetricaConsulting.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StatusesController : ControllerBase
    {
        #region Private Variable
        private readonly IStatusService _statusServiceAsync;

        #endregion Private Variable

        public StatusesController(IStatusService statusServiceAsync)
        {
            _statusServiceAsync = statusServiceAsync;
        }

        #region Actions

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync([FromBody] StatusCreateDto statusCreateDto)
        {
            var status = await _statusServiceAsync.CreateAsync<StatusCreateDto, StatusDetailDto>(statusCreateDto);
            return CreatedAtAction(nameof(GetProjectAsync), new { id = status.Id }, status);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            await _statusServiceAsync.DeleteLogicalAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<StatusListDto>>>> GetAllStatusesAsync()
        {
            var response = await _statusServiceAsync.GetAllProjectedAsync<StatusListDto>();
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<StatusDetailDto>>> GetProjectAsync(int id)
        {
            var response = await _statusServiceAsync.GetByIdProjectedAsync<int, StatusDetailDto>(id);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync(int id, [FromBody] StatusUpdateDto statusUpdateDto)
        {
            await _statusServiceAsync.UpdateAsync(id, statusUpdateDto);
            return NoContent();
        }

        [Authorize]
        [HttpGet("export/word")]
        public async Task<FileResult> ExportToWordAsync()
        {
            var file = await _statusServiceAsync.ExportToWordAsync<StatusExportDto>("Lista de Categorias");
            return File(file, FileContentType.Word, "Statuses.docx");
        }

        [Authorize]
        [HttpGet("export/pdf")]
        public async Task<FileResult> ExportToPdfAsync()
        {
            var file = await _statusServiceAsync.ExportToPdfAsync<StatusExportDto>("Lista de Categorias");
            return File(file, FileContentType.Pdf, "Statuses.pdf");
        }

        [Authorize]
        [HttpGet("export/excel")]
        public async Task<FileResult> ExportToExcelAsync()
        {
            var file = await _statusServiceAsync.ExportToExcelAsync<StatusExportDto>("Categorias");
            return File(file, FileContentType.Excel, "Statuses.xlsx");
        }

        #endregion Actions
    }
}