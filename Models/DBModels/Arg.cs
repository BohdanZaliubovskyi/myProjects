using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Profiles.Models.DBModels
{
    /// <summary>
    /// аргументы для выпадающих списков
    /// </summary>
    public class Arg
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuestionId { get; set; }
    }
}