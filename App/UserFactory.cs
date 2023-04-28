using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class UserFactory
    {
        private UserServices _userServices;
        private SpectacleServices _spectacleServices { get; set; }
        private TicketServices _ticketServices;

        public UserFactory(UserServices userServices, SpectacleServices spectacleServices, TicketServices ticketServices)
        {
            _userServices = userServices;
            _spectacleServices = spectacleServices;
            _ticketServices = ticketServices;
        }

        public User CreateUser(UserModel checkUser)
        {
            User user= null;
            if (checkUser.Role == Role.admin) 
            {
                user = new Administrator(_spectacleServices, _userServices, _ticketServices) { Login = checkUser.Login };
            }
            else if (checkUser.Role == Role.registered)
            {
                user = new Registered(_spectacleServices, _userServices, _ticketServices) { Login = checkUser.Login };
            }
            else user = new Guest(_spectacleServices);

            return user;
        }
    }
}
