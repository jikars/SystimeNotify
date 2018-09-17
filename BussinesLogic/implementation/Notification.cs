using BussinesLogic.constants;
using BussinesLogic.interfaces;
using DataAccess.interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.implementation
{
    public class Notification : INotification
    {
        private ILiteDb _liteDb { get; set; } = DepenFactory.ResolveInstance<ILiteDb>();

        public List<Models.Notification> GetAllNotification()
        {
            return _liteDb.GetAll<Models.Notification>();

        }

        public bool RemoveNotificationById(int id)
        {
            return _liteDb.DeleteById<Models.Notification>(id);
        }

        public bool RemoveNotificationByName(string name)
        {
            return _liteDb.DeleteByEntity(_liteDb.GetAll<Models.Notification>().First(t => t.Name == name));
        }

        public   Models.Notification SaveNotification(Models.Notification notification)
        {
            if(notification.Destination.TrueForAll(t=> Enum.TryParse(t.Message.TypeNotification, out EventSupport eventSupport)))
            {
                return _liteDb.Insert(notification);
            }
            else
            {
                return null;
            }
        }
    }
}
