using App.Services;
using App.Users;
using System;
using System.Collections.Generic;
public abstract class User : UserModel, IUser
{
    public readonly SpectacleServices  _spectacleService;

    Role IUser.Role => Role.admin;

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