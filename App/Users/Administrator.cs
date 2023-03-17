using App.Services;
using System;
using System.Collections.Generic;

public class Administrator : User
{
    private UserServices _userServices;
    public Administrator(SpectacleServices spectacleService, UserServices userServices) : base(spectacleService) {
        _userServices = userServices;
    }

    public void AddSpectacle(string title, string author, string genre, DateTime date, Dictionary<string, int> categories)
    {
        _spectacleService.AddNewSpectacle(title, author, genre, date, categories);
    }

    public void UpdateSpectacle(string newTitle, string newAuthor, string newGenre, DateTime date, Dictionary<string, int> newCategories)
    {
        _spectacleService.UpdateSpectacle(newTitle, newAuthor, newGenre, date, newCategories);
    }

    public void DeleteSpectacle(DateTime date)
    {
        _spectacleService.DeleteSpectacle(date);
    }

    public void CreateUser(string login, string password, string role)
    {
       _userServices.AddUser(login, password, role); 
    }

    public IEnumerable<UserModel> GetUser()
    {
        return _userServices.GetUser();
    }

    public UserModel GetUser(string login)
    {
        return _userServices.GetUser(login);
    }

    public void UpdateUser(string login, string password, string role)
    {
        _userServices.UpdateUserByName(login, password, role);
    }

    public void DeleteUser(string login)
    {
        _userServices.DeleteUser(login);
    }

    
}