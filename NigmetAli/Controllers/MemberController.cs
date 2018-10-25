using NigmetAli.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace NigmetAli.Controllers
{
    public class MemberController : Controller
    {
        CFContext context = new CFContext();
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
            incomeMember.IsValid = false;
            Image img = Image.FromStream(Picture.InputStream);
            int width = 64;
            int height = 64;
            string name = "/Pictures/" + Guid.NewGuid() + Path.GetExtension(Picture.FileName);
            Bitmap bmp = new Bitmap(img, width, height);
            bmp.Save(Server.MapPath(name));



            if (!context.Members.Any(x => x.EMail == incomeMember.EMail))
            {
                Member m = new Member();
                m.userName = incomeMember.userName;
                m.EMail = incomeMember.EMail;
                m.Password = incomeMember.Password;
                m.Picture = name;

                context.Members.Add(m);
                context.SaveChanges();
                BuildEmailTemplate(incomeMember.Id);
                ViewBag.msg = true;
                return View();
            }
            else
            {
                ViewBag.msg = false;
                return View();
            }
        }

        public ActionResult Confirm(int registID)
        {
            ViewBag.regID = registID;
            return View();
        }
        public JsonResult RegisterConfirm(int regId)
        {
            Member Data = context.Members.Where(x => x.Id == regId).FirstOrDefault();
            Data.IsValid = true;
            context.SaveChanges();
            var msg = "Your Email Is Verified!";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public void BuildEmailTemplate(int regID)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
            var regInfo = context.Members.Where(x => x.Id == regID).FirstOrDefault();
            var url = "http://localhost:49873/" + "Member/Confirm?regId=" + regID;
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate("Your Account Is Successfully Created", body, regInfo.EMail);
        }

        public static void BuildEmailTemplate(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "mulakat.beyza.n.ali@gmail.com";
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));

            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SendEmail(mail);
        }

        private static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("mulakat.beyza.n.ali@gmail.com", "Mulakat.2018.nigmetali");
            try
            {
                client.Send(mail);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}