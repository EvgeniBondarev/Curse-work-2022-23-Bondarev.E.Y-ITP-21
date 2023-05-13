public enum Role
{
    admin,
    registered, 
    guest
}
/// <summary>
/// Класс сущности пользователя
/// </summary>
public class UserModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
