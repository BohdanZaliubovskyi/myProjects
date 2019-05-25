using Profiles.Models;
using Profiles.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profiles.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        List<Question> _questions = null;
        int _currentQuestionPosition = 0;
        List<Answer> _answers = null;

        [HttpGet]
        public ActionResult Begin()
        {
            using (var db = new ProfileContext())
            {
                _questions = db.Questions.ToList();
            }
            if (_questions != null)
            {
                _currentQuestionPosition = 0;
                ViewBag.Message = _questions[_currentQuestionPosition].Text;
                _answers = new List<Answer>(_questions.Count);
                foreach (var q in _questions)
                    _answers.Add(new Answer() { QuestionId = q.Id, AnswerValue = "" });

                AnswerViewModel model = new AnswerViewModel() { Answers = _answers, Answer = "", CurPos = _currentQuestionPosition };
                return View("StringView", model);
            }
            else
            {
                ViewBag.Message = "Не найдено вопросов в базе данных.";
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult StringView(AnswerViewModel model)
        {
            List<Answer> answers = model.Answers.ToList();
            answers[model.CurPos].AnswerValue = model.Answer; // тут уперся в то, что при нажатии на кнопку далее, куда-то теряется массив ответов
            model.CurPos++;

            var viewName = "Error";

            switch (_questions[model.CurPos].TypeOfQuestion)
            {
                case QuestionType.IntType:
                    ViewBag.Message = _questions[model.CurPos].Text;
                    viewName = "IntView";
                    model.Answers = answers;
                    break;
            }

            ViewBag.Message = "Не найдено представления, соответствующего вопросу.";
            model = null;
            return View(viewName,model);
        }

    }
}