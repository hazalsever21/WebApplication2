using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DB;

namespace WebApplication2.Controllers
{
    public class BaseController : Controller
    {
        protected ETicaretDBEntities context { get; private set; }
        public BaseController()
        {
            context = new ETicaretDBEntities();
            ViewBag.MenuCategories = context.Categories.Where(x => x.Parent_Id == null).ToList();

        }
        protected DB.Members CurrentUser()
        {
            if (Session["LogonUser"] == null) return null;
            return (DB.Members)Session["LogonUser"];
        }
        protected int CurrentUserId()
        {
            if (Session["LogonUser"] == null) return 0;
            return ((DB.Members)Session["LogonUser"]).Id;
        }
    }
}