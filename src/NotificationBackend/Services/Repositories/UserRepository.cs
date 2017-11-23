using NotificationBackend.Core;
using NotificationBackend.DAL;
using NotificationBackend.DAL.NotificationEntities;
using NotificationBackend.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using NoficationBackend.Services;

namespace NotificationBackend.Services.Repositories
{
    public class UserRepsository : NotificationServiceRepository<Users>, IUserRepository
    {
        public UserRepsository(NotifContext dbContext) : base(dbContext)
        {
        }
        public bool Exists(int id)
        {
            return _dbContext.Users.Any(u => u.UserAccountId == id);
        }
    }
}
