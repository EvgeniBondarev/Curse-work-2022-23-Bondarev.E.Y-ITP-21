using App.Services;
using System;

public class Guest : User
{
    public Guest(SpectacleServices spectacleService) : base(spectacleService)
    {
    }

}
