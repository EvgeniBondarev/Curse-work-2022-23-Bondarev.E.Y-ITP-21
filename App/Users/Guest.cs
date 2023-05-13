using App.Services;
using App.Users;
using System;

public class Guest : User, IUser
{
    public Guest(SpectacleServices spectacleService) : base(spectacleService)
    {
    }

}
