namespace Entity.Concrete
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname{ get; set; }
        public string Email{ get; set; }
        public byte[] PasswordHash{ get; set; }
        public byte[] PasswordSalt{ get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
