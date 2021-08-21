using BilgeKitap.Entity;
using System.Collections.Generic;

namespace BilgeKitap.Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        void Add(Author author);
        void Delete(Author author);
        void Update(Author author);
        Author GetByID(int authorId);
    }
}
