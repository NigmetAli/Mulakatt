using NigmetAli.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NigmetAli.Controllers
{
    public class QuAnCoTaController : Controller
    {
        // GET: QuAnCoTa
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Tag(string TagName)
        {
            CFContext context = new CFContext();

            List<Answer> answers = context.Answers.ToList();
            ViewBag.Answers = answers;

            List<Question> isContain = context.Questions.Where(x => x.Tags.Contains(TagName)).ToList();

            return View(isContain);


        }
    }
}