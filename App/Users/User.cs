using App.Services;
using System;
using System.Collections.Generic;
public abstract class User : UserModel
{
    private readonly SpectacleServices _spectacleService;
    public abstract void Register();
    public abstract void LogIn();
    public abstract void LogOut();

    public User(SpectacleServices spectacleService)
    {
        _spectacleService = spectacleService;
    }

    public IEnumerable<SpectacleModel> ViewSpectacle()
    {
        return _spectacleService.ShowAllSpectacles();
    }
    public SpectacleModel ViewSpectacle(string title)
    {
        return _spectacleService.ShowSpectacle(title);
        
    }
    public SpectacleModel ViewSpectacle(DateTime date)
    {
        return _spectacleService.ShowSpectacle(date);   
    }
}