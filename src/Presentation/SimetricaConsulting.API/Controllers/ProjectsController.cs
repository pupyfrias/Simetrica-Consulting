using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SimetricaConsulting.Application.Constants;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Application.Models.Dtos.V1.Project;
using SimetricaConsulting.Application.Models.DTOs.V1.Comment;
using SimetricaConsulting.Application.Models.DTOs.V1.Project;
using SimetricaConsulting.Application.Models.Specification.V1;
using SimetricaConsulting.Application.Models.Wrappers;

namespace SimetricaConsulting.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProjectsController : ControllerBase
    {
        #region Private Variable
        private readonly IProjectService _projectServiceAsync;

        #endregion Private Variable

        public ProjectsController(IProjectService projectServiceAsync)
        {
            _projectServiceAsync = projectServiceAsync;
        }

        #region Actions

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync([FromBody] ProjectCreateDto projectCreateDto)
        {
            var project = await _projectServiceAsync.CreateAsync<ProjectCreateDto, ProjectDetailDto>(projectCreateDto);
            return CreatedAtAction(nameof(GetProjectAsync), new { id = project.Id }, project);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            await _projectServiceAsync.DeleteLogicalAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ProjectListDto>>>> GetAllProjectsAsync([FromQuery] ProjectQueryParameters projectQueryParameters)
        {
            var response = await _projectServiceAsync.GetAllProjectedWithPaginationAsync<ProjectListDto, ProjectSpecification>(projectQueryParameters);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProjectDetailDto>>> GetProjectAsync(int id)
        {
            var response = await _projectServiceAsync.GetByIdProjectedAsync<int, ProjectDetailDto>(id);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync(int id, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            await _projectServiceAsync.UpdateAsync(id, projectUpdateDto);
            return NoContent();
        }

        [Authorize]
        [HttpGet("export/word")]
        public async Task<FileResult> ExportToWordAsync()
        {
            var file = await _projectServiceAsync.ExportToWordAsync<ProjectExportDto>("Lista de Categorias");
            return File(file, FileContentType.Word, "Projects.docx");
        }

        [Authorize]
        [HttpGet("export/pdf")]
        public async Task<FileResult> ExportToPdfAsync()
        {
            var file = await _projectServiceAsync.ExportToPdfAsync<ProjectExportDto>("Lista de Categorias");
            return File(file, FileContentType.Pdf, "Projects.pdf");
        }

        [Authorize]
        [HttpGet("export/excel")]
        public async Task<FileResult> ExportToExcelAsync()
        {
            var file = await _projectServiceAsync.ExportToExcelAsync<ProjectExportDto>("Categorias");
            return File(file, FileContentType.Excel, "Projects.xlsx");
        }

        #endregion Actions
    }
}