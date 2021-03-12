using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

    public class MemberRegister
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class MemberLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}