using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.ENTITIES.Common;

namespace Task.BLL.Interfaces;

//where T: BaseEntity demek,
//T'nin BaseEntity'den türemiş bir sınıf olması gerektiği anlamına gelir.Bu, IGenericRepository'nin sadece BaseEntity'den türemiş sınıflar için
//kullanılabileceği anlamına gelir. Böylece, IGenericRepository'yi kullanarak sadece BaseEntity'den türemiş sınıflar üzerinde işlemler yapabilirsiniz.
public interface IGenericRepository<T> where T : BaseEntity
{
    
}
