using App.Services;
using System;
using System.Collections.Generic;
public abstract class User : UserModel
{
    public readonly SpectacleServices  _spectacleService;


    public User(SpectacleServices spectacleService)
    {
        _spectacleService = spectacleService;
    }

    public IEnumerable<SpectacleModel> ViewSpectacle()
    {
        return _spectacleService.ShowAllSpectacles();
    }
    public IEnumerable<SpectacleModel> ViewSpectacle(string genre)
    {
        return _spectacleService.ShowSpectacle(genre);
        
    }
    public SpectacleModel ViewSpectacle(DateTime date)
    {
        return _spectacleService.ShowSpectacle(date);   
    }
}