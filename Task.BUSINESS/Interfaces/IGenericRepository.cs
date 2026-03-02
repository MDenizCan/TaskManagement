using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ENTITIES.Common;

namespace TaskManagement.BLL.Interfaces;

//where T: BaseEntity demek,
//T'nin BaseEntity'den türemiş bir sınıf olması gerektiği anlamına gelir.Bu, IGenericRepository'nin sadece BaseEntity'den türemiş sınıflar için
//kullanılabileceği anlamına gelir. Böylece, IGenericRepository'yi kullanarak sadece BaseEntity'den türemiş sınıflar üzerinde işlemler yapabilirsiniz.
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(int id, T entity);
    void Update(T entity);
    void Remove(T entity);
    Task SaveChangesAsync();
}
