using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lol.API.Models.DbMysqlModels;

public partial class Login
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; }

    public int Password { get; set; }

    public static class Authenticator
    {
        public static bool loggedin = false;
    }
}
