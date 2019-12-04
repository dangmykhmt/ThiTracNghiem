using CaseStudy.Comoon;
using CaseStudy.Model;
using CaseStudy.Models;
using CaseStudy.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CaseStudy.Controllers
{
    public class StudentController : Controller
    {
        
        private readonly trac_nghiem_onlineEntities db;

        public StudentController(trac_nghiem_onlineEntities trac_Nghiem_)
        {
            this.db = trac_Nghiem_;
        }
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult CreateStudentQuestion(int code1)
        {
            List<quests_of_test> qs = (from x in db.quests_of_test

                                       where x.test_code == code1
                                       select x).OrderBy(x => Guid.NewGuid()).ToList();

            var rd = new Random();
            var list = db.students.ToList();

            foreach (var item in qs)
            {
                var StudentTest = new student_test_detail();
                StudentTest.id_question = item.id_question;
                StudentTest.test_code = code1;
                StudentTest.id_student = 1;
                question q = db.questions.SingleOrDefault(x => x.id_question == item.id_question);
                string[] answer = { q.answer_a, q.answer_b, q.answer_c, q.answer_d };
                answer = ShuffleArray.Randomize(answer);
                StudentTest.answer_a = answer[0];
                StudentTest.answer_b = answer[1];
                StudentTest.answer_c = answer[2];
                StudentTest.answer_d = answer[3];
                db.student_test_detail.Add(StudentTest);
                db.SaveChanges();
            }
            return RedirectToAction("DoingTest", new { test_code = code1 });

        }
       
        public IActionResult CreateQuestionOfTest(int code) 
        {
          var abc =   db.student_test_detail.ToList();
            foreach (var item in abc)
            {
                db.Remove(item);
                db.SaveChanges();
            }


            var abcd = db.quests_of_test.ToList();
            foreach (var item in abcd)
            {
                db.Remove(item);
                db.SaveChanges();
            }

            var abcde = db.scores.ToList();
            foreach (var item in abcde)
            {
                db.Remove(item);
                db.SaveChanges();
            }

            var rd = new Random();
           
            List<question> list = (from x in db.questions
                                   where x.subject.id_subject == x.id_subject
                                   select x
                                   ).OrderBy(x => Guid.NewGuid()).ToList();
            var count = (from x in db.tests
                         where x.test_code == code
                         select x).ToList();// lay so luong de == ten de 

            var sl = count.First().total_questions;
            var b = 1;
            for (int i = 0; i < sl; i++)
            {
                var chDe = new quests_of_test();
                var a = rd.Next(1, list.Count);
                list.RemoveAt(a);
                chDe.test_code = code;
                chDe.id_question = b;
                
                db.quests_of_test.Add(chDe);
                db.SaveChanges();
                b++;
            }
            


            return RedirectToAction("CreateStudentQuestion", new { code1 = code });

        }

        [AllowAnonymous]
        public IActionResult DoingTest(int test_code)
        {
            List<StudentQuestViewModel> list = new List<StudentQuestViewModel>();
            try
            {
                list = (from x in db.student_test_detail
                        join t in db.tests on x.test_code equals t.test_code
                        join q in db.questions on x.id_question equals q.id_question                       
                        where x.test_code == test_code && x.id_student == 1
                        select new StudentQuestViewModel { test = t, student_test = x, question = q }).OrderBy(x => x.student_test.ID).ToList();
            }
            catch (Exception) { }

            return View(list);
        }
       
        public IActionResult SubmitTest(int id)
        {
            List<StudentQuestViewModel> list = new List<StudentQuestViewModel>();
            try
            {
                list = (from x in db.student_test_detail
                        join t in db.tests on x.test_code equals t.test_code
                        join q in db.questions on x.id_question equals q.id_question
                        join s in db.students on x.id_student equals s.id_student
                        where x.test_code == id
                        && x.id_student == 1
                        select new StudentQuestViewModel { test = t, student_test = x, question = q }).OrderBy(x => x.student_test.ID).ToList();
            }
            catch (Exception) { }

            int total_quest = list.First().test.total_questions;
            int test_code = list.First().test.test_code;
            double coefficient = 10.0 / (double)total_quest;
            int count_correct = 0;
            foreach (var item in list)
            {
                if (item.student_test.student_answer != null && item.student_test.student_answer.Trim().Equals(item.question.correct_answer.Trim()))
                    count_correct++;
            }
            double score = coefficient * count_correct;
            string detail = count_correct + "/" + total_quest;

            var sc = new score();
            sc.id_student = list.First().student_test.id_student;
            sc.test_code = id;
            sc.score_number = score;
            sc.detail = detail;
            db.scores.Add(sc);
            db.SaveChanges();
            return RedirectToAction("PreviewTest", new { id = test_code });
        }
        //[AllowAnonymous]
        public IActionResult PreviewTest(int id)
        {
            List<int> score = new List<int>();
            try
            {
                score = (from x in db.scores
                         where x.id_student == 1
                         select x.test_code).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (score.IndexOf(id) == -1)
                return View("Error");
            score scores = new score();
            try
            {
                scores = db.scores.FirstOrDefault(x => x.test_code == id && x.id_student==1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            ViewBag.score = scores;
            List<StudentQuestViewModel> list = new List<StudentQuestViewModel>();
            try
            {
                list = (from x in db.student_test_detail
                        join t in db.tests on x.test_code equals t.test_code
                        join q in db.questions on x.id_question equals q.id_question
                        join s in db.students on x.id_student equals s.id_student
                        where x.test_code == id
                        && x.id_student == 1
                        select new StudentQuestViewModel { test = t, student_test = x, question = q }).OrderBy(x => x.student_test.ID).ToList();
            }
            catch (Exception) { }
            return View(list);
        }
        public void UpdateStudentTest(IFormCollection form)
        {
            int id_quest = Convert.ToInt32(form["id"]);
            string answer = form["answer"];
            int test_code = Convert.ToInt32(form["code"]);
            answer = answer.Trim();
            var update = (from x in db.student_test_detail                        
                          where x.id_question == id_quest && x.id_student == 1 &&x.test_code == test_code
                          select x).Single();
            update.student_answer = answer;
            db.SaveChanges();
        }
        
    }
}
