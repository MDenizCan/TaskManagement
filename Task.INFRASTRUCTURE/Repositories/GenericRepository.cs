using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;

namespace TaskManagement.INFRASTRUCTURE.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : TaskManagement.ENTITIES.Common.BaseEntity
{
    public Task<T> UpdateAsync(int id, T entity)
    {
        throw new NotImplementedException();
    }
}
