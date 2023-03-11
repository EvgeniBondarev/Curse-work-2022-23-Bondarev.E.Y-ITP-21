using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class UserManager :  IXmlDocumentManager<User>
{
    private readonly string _xmlFilePath;
    private readonly XDocument _xmlDoc;
    public UserManager(string xmlFilePath)
    {
        _xmlFilePath = xmlFilePath;
        _xmlDoc = XDocument.Load(_xmlFilePath);
    }

    public  IEnumerable<User> GetAll()
    {
        return _xmlDoc.Root.Elements("user").Select(u =>
            new User
            {
                Login = u.Element("login").Value,
                Password = u.Element("password").Value,
                Role = u.Element("role").Value
            });
    }

    public void Add(User user)
    {
        if (UserValid(user))
        {
            throw new ArgumentException("Пользователь с таким логином уже существует.");
        }

        _xmlDoc.Root.Add(new XElement("user",
            new XElement("login", user.Login),
            new XElement("password", user.Password),
            new XElement("role", user.Role)
        ));
        _xmlDoc.Save(_xmlFilePath);
    }

    public  void Update(User user)
    {
        if (!UserValid(user))
        {
            throw new ArgumentException("Пользователя с таким логином не существует.");
        }

        XElement userToUpdate = _xmlDoc.Root.Elements("user")
            .SingleOrDefault(u => u.Element("login").Value == user.Login);

        if (userToUpdate != null)
        {
            userToUpdate.Element("password").Value = user.Password;
            userToUpdate.Element("role").Value = user.Role;
            _xmlDoc.Save(_xmlFilePath);
        }
    }

    public  void Delete(User user)
    {
        if (!UserValid(user))
        {
            throw new ArgumentException("Пользователя с таким логином не существует.");
        }

        XElement userToDelete = _xmlDoc.Root.Elements("user")
            .SingleOrDefault(u => u.Element("login").Value == user.Login);

        if (userToDelete != null)
        {
            userToDelete.Remove();
            _xmlDoc.Save(_xmlFilePath);
        }
    }
    public string GetUserRole(string login)
    {

        var user = _xmlDoc.Descendants("user")
                         .FirstOrDefault(u => u.Element("login").Value == login);
        if (user != null)
        {
            return user.Element("role").Value;
        }
        else
        {
            throw new ArgumentException("Пользователя с таким логином не существует.");
        }
    }

    private bool UserValid(User user)
    {
        if (_xmlDoc.Root.Elements("user").Any(u => u.Element("login").Value == user.Login))
        {
            return true;
        }
        else return false;
    }

}
