using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Comment
{
    public class CommentUpdateDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
    }
}