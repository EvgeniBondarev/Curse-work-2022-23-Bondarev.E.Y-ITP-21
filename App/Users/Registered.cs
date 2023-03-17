using App.Services;
using System;

public class Registered : User
{
    public Registered(SpectacleServices spectacleService) : base(spectacleService)
    {
    }

    public override void LogIn()
    {
        throw new NotImplementedException();
    }

    public override void LogOut()
    {
        throw new NotImplementedException();
    }

    public override void Register()
    {
        throw new NotImplementedException();
    }
}
