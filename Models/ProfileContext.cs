using Profiles.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Profiles.Models
{
    public class ProfileContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Arg> Args { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
    public class ProfileDbInitializer : DropCreateDatabaseAlways<ProfileContext>
    {
        /// <summary>
        /// удобное заполнение таблицы аргументов
        /// </summary>
        /// <param name="context">база данных</param>
        /// <param name="questionText">текст вопроса, для которого будут добавляться аргументы</param>
        /// <param name="args">массив аргументов</param>
        void AddArg(ref ProfileContext context, string questionText, string[] args)
        {
            var tmpQ = context.Questions.Where(c => c.Text == questionText).SingleOrDefault();
            if (tmpQ != null)
            {
                foreach (var arg in args)
                   context.Args.Add(new Arg() { Name = arg, QuestionId = tmpQ.Id });

                context.SaveChanges();
            }
        }
        protected override void Seed(ProfileContext context)
        {
            var genderQuestionText = "Введите пол";
            var maritalQuestionText = "Введите семейное положение";
            //заполнение таблицы вопросов
            context.Questions.Add(new Question() { Text = "Введите имя", TypeOfQuestion = QuestionType.StringType });
            context.Questions.Add(new Question() { Text = "Введите возраст", TypeOfQuestion = QuestionType.IntType });
            context.Questions.Add(new Question() { Text = genderQuestionText, TypeOfQuestion = QuestionType.DropDownType });
            context.Questions.Add(new Question() { Text = "Введите дату роджения", TypeOfQuestion = QuestionType.DateType });
            context.Questions.Add(new Question() { Text = maritalQuestionText, TypeOfQuestion = QuestionType.DropDownType });
            context.Questions.Add(new Question() { Text = "Любите ли вы программировать", TypeOfQuestion = QuestionType.BoolType });
            context.SaveChanges();
            //---------------------------------------------------------------------------------------------------
            AddArg(ref context, genderQuestionText, new string[] { "Мужской", "Женский" });
            AddArg(ref context, maritalQuestionText, new string[] { "В браке", "НЕ в браке" });

            base.Seed(context);
        }
    }

}