using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.interfaces
{
    public interface INotification
    {
         Models.Notification SaveNotification(Models.Notification notification);
         List<Models.Notification> GetAllNotification();
         Boolean RemoveNotificationById(int id);
         Boolean RemoveNotificationByName(String name);
    }
}
