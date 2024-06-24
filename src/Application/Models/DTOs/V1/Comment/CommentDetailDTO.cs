namespace SimetricaConsulting.Application.Models.Dtos.V1.Comment
{
    public class CommentDetailDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string User { get; set; }
        public string Task { get; set; }
    }
}