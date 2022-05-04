using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseHandler
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public string FullName { get; set; }
        public string Id { get; set; }
        public string Username { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? ProfilePicture { get; set; }
    }
}
