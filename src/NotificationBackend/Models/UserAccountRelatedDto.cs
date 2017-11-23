using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static NotificationBackend.Core.Enums;
using NotificationBackend.Services.AbstractRepositories;

namespace NotificationBackend.Models
{
    public class UserBaseDto
    {
        public UserBaseDto()
        {
        }
        public int UserAccountId { get; set; }
        public int UserAccountTypeId { get; set; }
        public string UserName { get; set; }
 
    }
    public class UserBaseViewDto : UserBaseDto
    {
        public string UserAccountTypeDescription { get; set; }
        public string JobCategoryDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

}
