using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

public static class UserManager
{
    private static readonly string _xmlFilePath;
    private static readonly XDocument _xmlDoc;
    private static readonly XmlSchemaSet _schemas;

    static UserManager()
    {
        _xmlFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xml";
        _xmlDoc = XDocument.Load(_xmlFilePath);
        _schemas = new XmlSchemaSet();
        _schemas.Add(null, "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xsd");
    }


    public static IEnumerable<UserModel> GetAll()
    {
        return _xmlDoc.Root.Elements("user").Select(u =>
            new UserModel
            {
                Login = u.Element("login").Value,
                Password = u.Element("password").Value,
                Role = (Role)Enum.Parse(typeof(Role), u.Element("role").Value)
            });
    }

    public static void Add(UserModel user)
    {
        if (!DataValidate(user))
        {
            throw new ArgumentException("Данные не валидны.");
        }
        if (!UserValid(user))
        {
            throw new ArgumentException("Пользователь с таким логином уже существует.");
        }

        var newUser = new XElement("user",
            new XElement("login", user.Login),
            new XElement("password", user.Password),
            new XElement("role", user.Role)
        );
        _xmlDoc.Root.Add(newUser);
        using (var ms = new MemoryStream())
        {
            _xmlDoc.Save(ms);

            using (var file = new FileStream(_xmlFilePath, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
        }
    }
    public static void Update(UserModel user)
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
            userToUpdate.Element("role").Value = user.Role.ToString();
            _xmlDoc.Save(_xmlFilePath);
        }
    }

    public static void Delete(UserModel user)
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
    public static string GetUserRole(string login)
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

    private static bool UserValid(UserModel user)
    {
        if (_xmlDoc.Root.Elements("user").Any(u => u.Element("login").Value == user.Login))
        {
            return false;
        }
        else return true;
    }

    private static bool DataValidate(UserModel user)
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