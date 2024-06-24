using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimetricaConsulting.Application.Constants;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Application.Models.Dtos.V1.Dashboard;
using SimetricaConsulting.Application.Models.DTOs.V1.Dashboard;
using SimetricaConsulting.Application.Models.Specification.V1;
using SimetricaConsulting.Application.Models.Wrappers;

namespace SimetricaConsulting.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DashboardsController : ControllerBase
    {
        #region Private Variable
        private readonly IDashboardService _dashboardServiceAsync;

        #endregion Private Variable

        public DashboardsController(IDashboardService dashboardServiceAsync)
        {
            _dashboardServiceAsync = dashboardServiceAsync;
        }

        #region Actions

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync([FromBody] DashboardCreateDto dashboardCreateDto)
        {
            var dashboard = await _dashboardServiceAsync.CreateAsync<DashboardCreateDto, DashboardDetailDto>(dashboardCreateDto);
            return CreatedAtAction(nameof(GetProjectAsync), new { id = dashboard.Id }, dashboard);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            await _dashboardServiceAsync.DeleteLogicalAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<DashboardListDto>>>> GetAllDashboardsAsync([FromQuery] DashboardQueryParameters dashboardQueryParameters)
        {
            var response = await _dashboardServiceAsync.GetAllProjectedWithPaginationAsync<DashboardListDto, DashboardSpecification>(dashboardQueryParameters);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<DashboardDetailDto>>> GetProjectAsync(int id)
        {
            var response = await _dashboardServiceAsync.GetByIdProjectedAsync<int, DashboardDetailDto>(id);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync(int id, [FromBody] DashboardUpdateDto dashboardUpdateDto)
        {
            await _dashboardServiceAsync.UpdateAsync(id, dashboardUpdateDto);
            return NoContent();
        }

        [Authorize]
        [HttpGet("export/word")]
        public async Task<FileResult> ExportToWordAsync()
        {
            var file = await _dashboardServiceAsync.ExportToWordAsync<DashboardExportDto>("Lista de Categorias");
            return File(file, FileContentType.Word, "Dashboards.docx");
        }

        [Authorize]
        [HttpGet("export/pdf")]
        public async Task<FileResult> ExportToPdfAsync()
        {
            var file = await _dashboardServiceAsync.ExportToPdfAsync<DashboardExportDto>("Lista de Categorias");
            return File(file, FileContentType.Pdf, "Dashboards.pdf");
        }

        [Authorize]
        [HttpGet("export/excel")]
        public async Task<FileResult> ExportToExcelAsync()
        {
            var file = await _dashboardServiceAsync.ExportToExcelAsync<DashboardExportDto>("Categorias");
            return File(file, FileContentType.Excel, "Dashboards.xlsx");
        }

        #endregion Actions
    }
}