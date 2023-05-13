using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

/// <summary>
/// Предоставляет методы для работы с пользователями в файле XML.
/// </summary>
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
    /// <summary>
    /// Возвращает все объекты UserModel из файла XML.
    /// </summary>
    /// <returns>Все объекты UserModel из файла XML.</returns>
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
    /// <summary>
    /// Добавляет новый объект UserModel в файл XML.
    /// </summary>
    /// <param name="user">Объект UserModel для добавления.</param>
    /// <exception cref="ArgumentException">Вызывается, когда данные не валидны или пользователь с таким логином уже существует.</exception>
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
    // <summary>
    /// Обновляет объект UserModel в файле XML.
    /// </summary>
    /// <param name="user">Объект UserModel для обновления.</param>
    /// <exception cref="ArgumentException">Вызывается, когда данные не валидны или пользователь с таким логином не существует.</exception>
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
    // <summary>
    /// Удаление объекта UserModel в файле XML.
    /// </summary>
    /// <param name="user">Объект UserModel для удаления.</param>
    /// <exception cref="ArgumentException">Вызывается, когда пользователя не существует.</exception>
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
    // <summary>
    /// Проверка уникальности пользователя.
    /// </summary>
    /// <param name="user">Объект UserModel для проверки валидации.</param>
    private static bool UserValid(UserModel user)
    {
        if (_xmlDoc.Root.Elements("user").Any(u => u.Element("login").Value == user.Login))
        {
            return false;
        }
        else return true;
    }
    /// <summary>
    /// Проверяет, что данные пользователя проходят валидацию.
    /// </summary>
    /// <param name="user">Пользователь которого нужно проверить.</param>
    /// <returns>true, если данные проходят валидацию, false в противном случае.</returns>
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