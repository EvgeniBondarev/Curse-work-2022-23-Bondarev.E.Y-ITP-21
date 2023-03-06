using System.Collections.Generic;
using System.Xml.Linq;

public abstract class XmlDocumentManager<T> : IXmlDocumentManager<T>
{
    protected XDocument XmlDoc;

    protected XmlDocumentManager(string xmlFilePath)
    {
        XmlDoc = XDocument.Load(xmlFilePath);
    }

    public abstract IEnumerable<T> GetAll();

    public abstract void Add(T item);

    public abstract void Update(T item);

    public abstract void Delete(T item);
}