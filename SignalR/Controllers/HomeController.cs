using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Hubs;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private MessagesService objCust;
        public HomeController()
        {
            this.objCust = new MessagesService();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllData()
        {
            int Count = 10; IEnumerable<object> Result = null;
            try
            {
                object[] parameters = { Count };
                Result = objCust.GetAll(parameters);

            }
            catch { }
            return PartialView("_DataList", Result);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Messages model)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    object[] parameters = { model.Message, model.EmptyMessage, model.Date };
                    result = objCust.Insert(parameters);
                    if (result == 1)
                    {
                        //Notify
                        MessageHub.BroadcastData();
                    }
                }
            }
            catch { }
            return View("Index");
        }
        public ActionResult Delete(int MessageID)
        {
            int result = 0;
            try
            {
                object[] parameters = { MessageID };
                result = objCust.Delete(parameters);
                if (result == 1)
                {
                    //Notify
                    MessageHub.BroadcastData();
                }
            }
            catch { }
            return View("Index");
        }

        public ActionResult Update(int MessageID)
        {
            object result = null;
            try
            {
                object[] parameters = { MessageID };
                result = this.objCust.GetbyID(parameters);
            }
            catch { }
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Messages model)
        {
            int result = 0;
            try
            {
                object[] parameters = { model.MessageID, model.Message, model.EmptyMessage, model.Date };
                result = objCust.Update(parameters);

                if (result == 1)
                {
                    //Notify
                    MessageHub.BroadcastData();
                }
            }
            catch { }
            return View("Index");
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}