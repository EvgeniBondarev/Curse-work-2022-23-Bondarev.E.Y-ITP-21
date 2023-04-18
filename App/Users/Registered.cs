using App.Services;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

public class Registered : User
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
        _userServices.UpdateUserByName(userName, newPassword, "registered");
    }

    public IEnumerable<TicketModel> GetTicket()
    {
        return _ticketServices.GetTicket(this.Login);
    }

    public TicketModel GetTicket(DateTime date)
    {
        return _ticketServices.GetTicket(date);
    }

    public void AddTicket(string userName, DateTime spectacleDate, Categorias category)
    {
        _ticketServices.AddTicket(GetThisUser(userName), GetThisSpectacle(spectacleDate), category);
    }

    public void DeletTicket(string userName, DateTime spectacleDate, Categorias category)
    {
        _ticketServices.DeletTicket(GetThisUser(userName), GetThisSpectacle(spectacleDate), category);
    }

    private UserModel GetThisUser(string userName)
    {
        return _userServices.GetUser(userName);
    }
    private SpectacleModel GetThisSpectacle(DateTime spectacleDate)
    {
        return _spectacleService.ShowSpectacle(spectacleDate);
    }


}
