namespace Core.Dtos
{
    public class CommentDto
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string CommentText { get; set; }
        public int Rating { get; set; }
    }
}
