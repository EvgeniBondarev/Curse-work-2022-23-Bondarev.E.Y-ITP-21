using App.Services;
using App.Users;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

public class Registered : User, IUser
{
    private TicketServices _ticketServices;
    private UserServices _userServices;

    public Registered(SpectacleServices spectacleService, UserServices userServices, TicketServices ticketServices) : base(spectacleService)
    {
        _ticketServices = ticketServices;
        _userServices = userServices;
    }

    public void UpdateUser(string userName, string newPassword)
    {
        _userServices.UpdateUserByName(userName, newPassword, Role.registered);
    }

    public IEnumerable<TicketModel> GetTicket()
    {
        return _ticketServices.GetTicket(this.Login);
    }
    public IEnumerable<TicketModel> GetTicket(string owner)
    {
        return _ticketServices.GetTicket(owner);
    }
    public TicketModel GetTicket(int id)
    {
        return _ticketServices.GetTicket(id);
    }
    
    public void AddTicket(string userName, DateTime spectacleDate, Categorias category)
    {
        _ticketServices.AddTicket(userName, GetThisSpectacle(spectacleDate), category);
    }

    public void DeletTicket(int id)
    {
        _ticketServices.DeletTicket(id);
    }


    private SpectacleModel GetThisSpectacle(DateTime spectacleDate)
    {
        return _spectacleService.ShowSpectacle(spectacleDate);
    }


}
