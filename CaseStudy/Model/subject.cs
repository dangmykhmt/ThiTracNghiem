using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Model
{
    public class subject
    {
        [Key]
        public int id_subject { get; set; }
        [Display(Name = "Tên môn học")]
        public string subject_name { get; set; }

        public ICollection<question> questions { get; set; }
        public ICollection<test> tests { get; set; }
    }
}
