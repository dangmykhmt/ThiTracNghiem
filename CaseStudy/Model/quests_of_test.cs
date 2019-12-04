using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Model
{
    public class quests_of_test
    {
        [Key]
        public int ID { get; set; }

        public int test_code { get; set; }
        public test test { get; set; }

        public int id_question { get; set; }
        public question question { get; set; }



    }
}
