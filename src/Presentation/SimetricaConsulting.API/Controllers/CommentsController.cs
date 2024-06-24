using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimetricaConsulting.Application.Constants;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Application.Models.Dtos.V1.Comment;
using SimetricaConsulting.Application.Models.DTOs.V1.Comment;
using SimetricaConsulting.Application.Models.Specification.V1;
using SimetricaConsulting.Application.Models.Wrappers;

namespace SimetricaConsulting.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CommentsController : ControllerBase
    {
        #region Private Variable
        private readonly ICommentService _commentServiceAsync;

        #endregion Private Variable

        public CommentsController(ICommentService commentServiceAsync)
        {
            _commentServiceAsync = commentServiceAsync;
        }

        #region Actions

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync([FromBody] CommentCreateDto commentCreateDto)
        {
            var comment = await _commentServiceAsync.CreateAsync<CommentCreateDto, CommentDetailDto>(commentCreateDto);
            return CreatedAtAction(nameof(GetProjectAsync), new { id = comment.Id }, comment);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            await _commentServiceAsync.DeleteLogicalAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<CommentListDto>>>> GetAllCommentsAsync([FromQuery] CommentQueryParameters commentQueryParameters)
        {
            var response = await _commentServiceAsync.GetAllProjectedWithPaginationAsync<CommentListDto, CommentSpecification>(commentQueryParameters);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CommentDetailDto>>> GetProjectAsync(int id)
        {
            var response = await _commentServiceAsync.GetByIdProjectedAsync<int, CommentDetailDto>(id);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync(int id, [FromBody] CommentUpdateDto commentUpdateDto)
        {
            await _commentServiceAsync.UpdateAsync(id, commentUpdateDto);
            return NoContent();
        }

        [Authorize]
        [HttpGet("export/word")]
        public async Task<FileResult> ExportToWordAsync()
        {
            var file = await _commentServiceAsync.ExportToWordAsync<CommentExportDto>("Lista de Categorias");
            return File(file, FileContentType.Word, "Comments.docx");
        }

        [Authorize]
        [HttpGet("export/pdf")]
        public async Task<FileResult> ExportToPdfAsync()
        {
            var file = await _commentServiceAsync.ExportToPdfAsync<CommentExportDto>("Lista de Categorias");
            return File(file, FileContentType.Pdf, "Comments.pdf");
        }

        [Authorize]
        [HttpGet("export/excel")]
        public async Task<FileResult> ExportToExcelAsync()
        {
            var file = await _commentServiceAsync.ExportToExcelAsync<CommentExportDto>("Categorias");
            return File(file, FileContentType.Excel, "Comments.xlsx");
        }

        #endregion Actions
    }
}