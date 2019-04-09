using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudentExercisesMVC.Models;

namespace StudentExercisesMVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]

        //[Required]
        public string StudentFirstName { get; set; }

        //[Required]
        public string StudentLastName { get; set; }

        //[Required]
        public string StudentSlackHandle { get; set; }

        //[Required]
        public int student_cohort_id { get; set; }




        public Cohort Cohort { get; set; }

        public List<Exercise> Exercise { get; set; } = new List<Exercise>();
    }
}