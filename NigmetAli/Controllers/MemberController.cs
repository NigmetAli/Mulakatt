using NigmetAli.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NigmetAli.Controllers
{
    public class MemberController : Controller
    {

        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Title = "Sign Up";
            return View();
            //return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SignUp(Member incomeMember, HttpPostedFileBase Picture)
        {
            Image img = Image.FromStream(Picture.InputStream);
            int width = 64;
            int height = 64;
            string name = "/Pictures/" + Guid.NewGuid() + Path.GetExtension(Picture.FileName);
            Bitmap bmp = new Bitmap(img, width, height);
            bmp.Save(Server.MapPath(name));
            using (CFContext context = new CFContext())
            {
                Member m = new Member();
                m.userName = incomeMember.userName;
                m.EMail = incomeMember.EMail;
                m.Password = incomeMember.Password;
                m.Picture = name;

                context.Members.Add(m);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}