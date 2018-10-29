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

        public ActionResult QuestionDetails()
        {
            string variable = Request.QueryString["id"];
            int id = Convert.ToInt32(variable);

            CFContext context = new CFContext();
            Question question;

            question = context.Questions.FirstOrDefault(x => x.Id == id);

            List<Comment> comments = context.Comments.Where(x => x.QuestionId == question.Id).ToList();
            ViewBag.Comments = comments;

            List<Answer> answers = context.Answers.Where(x => x.QuestionId == question.Id).ToList();
            ViewBag.Answers = answers;

            return View(question);
        }

        [HttpPost]
        public ActionResult AddQuestionComment(string NewComment)
        {
            string data = Request.QueryString["qId"];
            int qId = Convert.ToInt32(data);

            CFContext context = new CFContext();

            Comment comment = new Comment();
            comment.QuestionId = qId;
            comment.MemberId = 8;
            comment.Description = NewComment;
            comment.Score = 0;

            context.Comments.Add(comment);
            context.SaveChanges();

            Question question;

            question = context.Questions.FirstOrDefault(x => x.Id == qId);
            List<Comment> dataComm = context.Comments.Where(x => x.QuestionId == question.Id).ToList();

            ViewBag.Comments = dataComm;

            return View("QuestionDetails",question);
        }

        [HttpPost]
        public void AddAnswer(string NewAnswerDescription,string NewAnswerCode)
        {
            string data = Request.QueryString["qId"];
            int qId = Convert.ToInt32(data);

            CFContext context = new CFContext();

            Answer answer = new Answer();
            answer.Description = NewAnswerDescription;
            answer.CodeArea = (NewAnswerCode != "") ? NewAnswerCode : null;
            answer.MemberId = 8;
            answer.QuestionId = qId;
            answer.Score = 0;
            answer.IsTrue = false;

            context.Answers.Add(answer);
            context.SaveChanges();

            //Question question;
            //question = context.Questions.FirstOrDefault(x => x.Id == qId);

            //List<Comment> dataComm = context.Comments.Where(x => x.QuestionId == question.Id).ToList();

            //List<Answer> answers = context.Answers.Where(x => x.QuestionId == question.Id).ToList();
            //ViewBag.Answers = answers;

            //return View("QuestionDetails", question);
        }
    }
}