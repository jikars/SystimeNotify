using BussinesLogic.interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/notification")]
    public class NotificationController : ApiController
    {
        public INotification _notification { get; set; }

        public NotificationController(INotification notification)
        {
            _notification = notification;
        }

        [HttpPost]
        public Response SaveNotification(Notification notification)
        {
            if(_notification.SaveNotification(notification) != null)
            {
                return new Response() { CodHttp = HttpStatusCode.Created.GetHashCode(), ObjectResponse = notification };
            }
            else
            {
                return new Response() { CodHttp = HttpStatusCode.BadRequest.GetHashCode(), ObjectResponse = null };
            }
        }

        [HttpDelete]
        public Response DeleteNotificaion(string  name)
        {
            if (_notification.RemoveNotificationByName(name))
            {
                return new Response() { CodHttp = HttpStatusCode.OK.GetHashCode(), ObjectResponse = true };
            }
            else
            {
                return new Response() { CodHttp = HttpStatusCode.BadRequest.GetHashCode(), ObjectResponse = false };
            }
        }

        [HttpGet]
        public Response GetAllNotification()
        {
            return new Response() { CodHttp = HttpStatusCode.OK.GetHashCode(), ObjectResponse = _notification.GetAllNotification() };
        }
    }
}
