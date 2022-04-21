using Ceci.Domain.DTO.Commons;
using Ceci.Domain.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service
{
    public interface INotificationService
    {
        Task<ResultResponse> SendAsync(NotificationSendDTO obj);
    }
}
