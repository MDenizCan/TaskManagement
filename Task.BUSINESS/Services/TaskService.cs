using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Interfaces;

namespace Task.BLL.Services;

public class TaskService : ITaskService
{
    //getAllTasks
    //repodan taskları çek

    //getTaskByProjectId
    //project var mi 
    //repodan o projectin tasklarını çek

    //getTaskById
    //o task var mi
    //repodan o taski çek

    //getUsersByTaskId
    //o task var mi
    //repodan o taska atanmış userları çek

    //CreateTaskbyProjectId
    //project kontrolu 
    //repoya yonlendirme

    //assignTaskToUser
    //o task var mi 
    //o user var mi
    //user var mi 
    //user o projectte var mi
    //eğer user o projectte yoksa useri project ekle ve taski usera ata
    //repoya yonlendirme

    //updateTask
    //o task var mi
    //repoya yonlendirme

    //changeTaskStatus
    //o task var mi
    //mevcut status ayni mi
    //repoya yonlendirme

    //deleteTask
    //o task var mi
    //repoya yonlendirme
}
