﻿namespace Core.Dtos
{
    public class UserDto
    {
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public Guid? RoleId { get; set; }

    }
}
