using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Profiles.Models.DBModels
{
    /// <summary>
    /// тип вопроса
    /// </summary>
    public enum QuestionType
    {
        /// <summary>
        /// строковый ответ
        /// </summary>
        StringType,
        /// <summary>
        /// ответ целое число
        /// </summary>
        IntType,
        /// <summary>
        /// ответ из списка
        /// </summary>
        DropDownType,
        /// <summary>
        /// ответ дата
        /// </summary>
        DateType,
        /// <summary>
        /// ответ булев тип
        /// </summary>
        BoolType,
    }
    /// <summary>
    /// вопрос
    /// </summary>
    public class Question
    {
        public int Id { get; set; }
        /// <summary>
        /// текст вопроса
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// какой тип данных будет использоваться в данном вопросеs
        /// </summary>
        public QuestionType TypeOfQuestion { get; set; }
    }
}