namespace Core.Dtos
{
    public class OrderDto
    {
        public Guid UserId{ get; set; }
        public string Status{ get; set; }
        public Guid AddressId{ get; set; }
        
    }
}
