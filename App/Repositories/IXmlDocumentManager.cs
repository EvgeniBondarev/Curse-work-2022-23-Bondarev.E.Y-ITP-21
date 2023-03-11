using System.Collections.Generic;

public interface IXmlDocumentManager<T>
{
    IEnumerable<T> GetAll();
    void Add(T item);
    void Update(T item);
    void Delete(T item);
}