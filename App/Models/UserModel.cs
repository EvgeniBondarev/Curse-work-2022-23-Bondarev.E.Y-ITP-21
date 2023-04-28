public enum Role
{
    admin,
    registered, 
    guest
}
public class UserModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
