using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Model
{
    public class student
    {
        [Key]
        public int id_student { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime birthday { get; set; }
        public string phone { get; set; }
     
        public ICollection<score> scores { get; set; }
        public ICollection<student_test_detail> student_test_detail { get; set; }
    }
}
