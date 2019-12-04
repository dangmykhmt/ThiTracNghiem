using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Model
{
    public class score
    {
        [Key]
        public int id_score { get; set; }

        public double score_number { get; set; }
        public string detail { get; set; }

        public int id_student { get; set; }
        public student student { get; set; }

        public int test_code { get; set; }
        public test test { get; set; }
    }
}
