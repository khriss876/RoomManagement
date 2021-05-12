using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Contracts
{
    public interface IRepositoryBase <T> where T : class
    { //ID type interger for Find All may change
        ICollection<T> FindAll();
        T FindById(int id);
        bool isExists(int Id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
