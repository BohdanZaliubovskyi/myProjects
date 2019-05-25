using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Profiles.Models.DBModels
{
    /// <summary>
    /// таблица ответов
    /// </summary>
    public class Answer
    {
        public int Id { get; set; }
        /// <summary>
        /// ид пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// ид вопроса
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// собственно сам ответ
        /// </summary>
        public string AnswerValue { get; set; }
    }
}