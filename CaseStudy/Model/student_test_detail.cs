using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Model
{
    public class student_test_detail
    {
        [Key]
        public int ID { get; set; }

        public int id_student { get; set; }
        public student student { get; set; }

        public int id_question { get; set; }
        public question question { get; set; }


        public string answer_a { get; set; }
        public string answer_b { get; set; }
        public string answer_c { get; set; }
        public string answer_d { get; set; }
        public string student_answer { get; set; }
        public int test_code { get; set; }



    }
}
