namespace Entity.Concrete
{
    public class Address : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User{ get; set; }
        public string Title { get; set; }
        public string City{ get; set; }
        public string Destrict{ get; set; }
        public string Street{ get; set; }
        public int PostalCode { get; set; }
    }
}
