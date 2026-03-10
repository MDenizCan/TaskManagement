using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Interfaces;
using TaskManagement.ENTITIES.Common;

namespace TaskManagement.INFRASTRUCTURE.Repositories;
//GenericRepository<T>= bu class generic
//GenericRepository<TaskEntity>
//GenericRepository<User>
//GenericRepository<Project>
// hepsi ayni kodu kullanir
public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
{//where T : BaseEntity olmadan GenericRepository<string> ya da GenericRepository<int> gibi saçma şeyler yapılabilirdi. Kısıtlama sayesinde sadece 
//BaseEntity'den türeyen sınıflar kullanılabilir yani UserEntity, ProjectEntity, TaskEntity

    protected readonly AppDbContext _context;
    //EF Core'un DbContext sinifini temsil eder.
    //Veritabanı işlemlerini gerçekleştirmek için kullanılır.
    //Readonly= sadece constructor içinde atanabilir, sonrasında değiştirilemez.
    public GenericRepository(AppDbContext context)
    {//Depedency Injection= AppDbContext nesnesi dışarıdan sağlanır,
     //böylece test edilebilirlik ve esneklik artar.
        _context = context;
    }
    //Task<List<T>> GetAllAsync();
    public async Task<List<T>> GetAllAsync()
    {//_context.Set<T>()=DbContext içinde T tipine karşılık gelen DbSet’i bul.
        return await _context.Set<T>().ToListAsync();
    }
    //Task<T> GetByIdAsync(int id);
    public async Task<T> GetByIdAsync(int id)
    {//FindAsync normalde ValueTask<T> döner.
     //Ama sen interface’de Task<T> yazdığın için dönüştürüyorsun.
        return await _context.Set<T>().FindAsync(id).AsTask();
    }
    //Task<T> CreateAsync(T entity);
    public async Task<T> CreateAsync(T entity)
    {
        var entry = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }
    //void Update(T entity);
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
    //void Remove(T entity);
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    //Task SaveChangesAsync();
    public  Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
