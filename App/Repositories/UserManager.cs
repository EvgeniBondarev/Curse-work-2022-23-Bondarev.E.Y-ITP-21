using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

public class UserManager :  IXmlDocumentManager<UserModel>
{
    private readonly string _xmlFilePath;
    private readonly XDocument _xmlDoc;
    private readonly XmlSchemaSet _schemas;

    public UserManager(string xmlFilePath, string xsdFilePath)
    {
        _xmlFilePath = xmlFilePath;
        _xmlDoc = XDocument.Load(_xmlFilePath);
        _schemas = new XmlSchemaSet();
        _schemas.Add(null, xsdFilePath);
    }

    public  IEnumerable<UserModel> GetAll()
    {
        return _xmlDoc.Root.Elements("user").Select(u =>
            new UserModel
            {
                Login = u.Element("login").Value,
                Password = u.Element("password").Value,
                Role = u.Element("role").Value
            });
    }

    public void Add(UserModel user)
    {
        if (!DataValidate(user))
        {
            throw new ArgumentException("Двнные не валидны.");
        }
        if (!UserValid(user))
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

    public  void Update(UserModel user)
    {
        if (!DataValidate(user))
        {
            throw new ArgumentException("Двнные не валидны.");
        }
        if (UserValid(user))
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

    public  void Delete(UserModel user)
    {
        if (UserValid(user))
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

    private bool UserValid(UserModel user)
    {
        if (_xmlDoc.Root.Elements("user").Any(u => u.Element("login").Value == user.Login))
        {
            return false;
        }
        else return true;
    }

    private bool DataValidate(UserModel user)
    {
        bool isValid = true;

        var tmpSpectacle = new XElement("users",
            new XElement("user",
            new XElement("login", user.Login),
            new XElement("password", user.Password),
            new XElement("role", user.Role)
            ));

     
        var xdoc = new XDocument(tmpSpectacle);
        xdoc.Validate(_schemas, (o, e) =>
        {
            isValid = false;
        });
        return isValid;
    }
}
