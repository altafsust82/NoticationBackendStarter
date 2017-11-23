using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NotificationBackend.Core.Enums;

namespace NotificationBackend.Services.AbstractRepositories
{
    public interface IObjectWithState
    {
        ObjectState ObjectState { get; set; }
    }
}
