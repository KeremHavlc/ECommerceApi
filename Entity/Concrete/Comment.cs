namespace Entity.Concrete
{
    public class Comment : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string CommentText { get; set; }
        public int Rating { get; set; }
    }
}
