namespace SimetricaConsulting.Application.Models.Dtos.V1.Comment
{
    public class CommentListDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string UserId { get; set; }
        public int TaskId { get; set; }
    }
}