using Profiles.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profiles.Models
{
    public class AnswerViewModel
    {
        public List<Answer> Answers { get; set; }
        public int CurPos { get; set; }
        public string Answer { get; set; }
    }
}