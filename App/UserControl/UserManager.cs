using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class UserManager : XmlDocumentManager<User>, IXmlDocumentManager<User>
{
    private string _XmlFilePath;
    public UserManager(string xmlFilePath) : base(xmlFilePath)
    {
        this._XmlFilePath = xmlFilePath;
    }

    public override IEnumerable<User> GetAll()
    {
        return XmlDoc.Root.Elements("user").Select(u =>
            new User
            {
                Login = u.Element("login").Value,
                Password = u.Element("password").Value,
                Role = u.Element("role").Value
            });
    }

    public override void Add(User user)
    {
        XmlDoc.Root.Add(new XElement("user",
            new XElement("login", user.Login),
            new XElement("password", user.Password),
            new XElement("role", user.Role)
        ));
        XmlDoc.Save(_XmlFilePath);
    }

    public override void Update(User user)
    {
        XElement userToUpdate = XmlDoc.Root.Elements("user")
            .SingleOrDefault(u => u.Element("login").Value == user.Login);

        if (userToUpdate != null)
        {
            userToUpdate.Element("password").Value = user.Password;
            userToUpdate.Element("role").Value = user.Role;
            XmlDoc.Save(_XmlFilePath);
        }
    }

    public override void Delete(User user)
    {
        XElement userToDelete = XmlDoc.Root.Elements("user")
            .SingleOrDefault(u => u.Element("login").Value == user.Login);

        if (userToDelete != null)
        {
            userToDelete.Remove();
            XmlDoc.Save(_XmlFilePath);
        }
    }
    public string GetUserRole(string login)
    {
        var user = XmlDoc.Descendants("user")
                         .FirstOrDefault(u => u.Element("login").Value == login);
        if (user != null)
        {
            return user.Element("role").Value;
        }
        else
        {
            return null;
        }
    }

}
