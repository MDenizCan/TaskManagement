using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.INFRASTRUCTURE.Repositories;

public class TaskRepository
{
    protected readonly AppDbContext _context;
    //EF Core'un DbContext sinifini temsil eder.
    //Veritabanı işlemlerini gerçekleştirmek için kullanılır.
    //Readonly= sadece constructor içinde atanabilir, sonrasında değiştirilemez.
    public TaskRepository(AppDbContext context)
    {//Depedency Injection= AppDbContext nesnesi dışarıdan sağlanır,
     //böylece test edilebilirlik ve esneklik artar.
        _context = context;
    }


}
