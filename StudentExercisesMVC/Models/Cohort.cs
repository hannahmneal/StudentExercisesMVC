using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using StudentExercisesMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentExercisesMVC.Models
{
    public class Cohort
    {
        /*
                From Student Exercise Part 1:

                1. The cohort's name (Evening Cohort 6, Day Cohort 25, etc.)
                2. The collection of students in the cohort.
                3. The collection of instructors in the cohort.
             
             */

        public Cohort()
        {
            Student = new List<Student>();
            Instructor = new List<Instructor>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string CohortName { get; set; }
        public List<Student> Student { get; set; }
        public List<Instructor> Instructor { get; set; }
    }
}
