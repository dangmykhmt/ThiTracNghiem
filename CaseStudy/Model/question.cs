using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Model
{
    public class question
    {
        [Key]
        public int id_question { get; set; }
        
        public int id_subject { get; set; }
        [Display(Name = "Môn học")]
        public subject subject { get; set; }
        [Display(Name ="Câu Hỏi")]
        public string content { get; set; }
        [Display(Name = "Đáp án A")]
        public string answer_a { get; set; }
        [Display(Name = "Đáp án B")]
        public string answer_b { get; set; }
        [Display(Name = "Đáp án C")]
        public string answer_c { get; set; }
        [Display(Name = "Đáp án D")]
        public string answer_d { get; set; }
        [Display(Name = "Đáp án đúng")]
        public string correct_answer { get; set; }


        public ICollection<quests_of_test> quests_of_test { get; set; }
        public ICollection<student_test_detail> student_test_detail { get; set; }
    }
}
