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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tag()
        {
            using (CFContext context = new CFContext())
            {
                List<Answer> answers = context.Answers.ToList();
                ViewBag.Answers = answers;

                string TagName = Request.QueryString["TName"].ToString();
                List<Question> isContain = context.Questions.Where(x => x.Tags.Contains(TagName)).ToList();
                return View(isContain);
            }
        }

        public ActionResult TagList()
        {
            using (CFContext context = new CFContext())
            {
                List<Tag> tags = context.Tags.ToList();
                return View(tags);
            }
        }

        [HttpPost]
        public ActionResult SearchTag(string FilterByTag)
        {
            using (CFContext context = new CFContext())
            {
                List<Tag> tags = context.Tags.Where(x => x.QTags.Contains(FilterByTag)).ToList();
                return View("TagList", tags);
            }
        }
    }
}