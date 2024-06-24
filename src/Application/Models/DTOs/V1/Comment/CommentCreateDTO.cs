using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Comment
{
    public class CommentCreateDto
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}