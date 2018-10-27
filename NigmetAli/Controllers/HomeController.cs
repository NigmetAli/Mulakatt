using NigmetAli.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NigmetAli.Controllers
{
    public class HomeController : Controller
    {
        CFContext context = new CFContext();
        // GET: Home
        public ActionResult Index()
        {
            List<Question> question = context.Questions.ToList();

            List<Answer> answers = context.Answers.ToList();
            ViewBag.Answers = answers;

            return View(question);
        }

    }
}


