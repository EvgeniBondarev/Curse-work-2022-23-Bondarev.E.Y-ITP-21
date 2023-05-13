using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users
{
    public interface IUser
    {
        string Login { get; set; }
        string Password { get; set; }
        Role Role { get; }
    }
}
