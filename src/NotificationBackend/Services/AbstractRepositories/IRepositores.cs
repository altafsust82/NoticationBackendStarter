using NotificationBackend.DAL.NotificationEntities;
using NotificationBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NotificationBackend.Core.Enums;

namespace NotificationBackend.Services.Abstract
{
    
    public interface IUserRepository : INotificationServiceRepository<Users>
    {
        bool Exists(int id);
    }
  
}
