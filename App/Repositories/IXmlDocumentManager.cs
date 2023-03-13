using System.Collections.Generic;
using System.Xml.Schema;

public interface IXmlDocumentManager<T>
{
    IEnumerable<T> GetAll();
    void Add(T item);
    void Update(T item);
    void Delete(T item);
    bool DataValidate(T items);
}