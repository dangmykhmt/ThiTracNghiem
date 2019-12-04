using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Model
{
    public class test
    {
        [Key]
        public int test_code { get; set; }
        [Display(Name = "Mã Đề")]
        public string test_name { get; set; }
      

        public int id_subject { get; set; }
        [Display(Name = "Môn Học")]
        public subject subject { get; set; }
        [Display(Name = "Tổng câu hỏi")]
        public int total_questions { get; set; }


        public ICollection<quests_of_test> quests_of_test { get; set; }
        public ICollection<score> scores { get; set; }


    }
}
