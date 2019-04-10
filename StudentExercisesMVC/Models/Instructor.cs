using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC.Models
{
    public class Instructor
    {

     /*
               From Student Exercises 1

               1. First name
               2.  Last name
               3. Slack handle
               4. The instructor's cohort
               5. A method to assign an exercise to a student
             */


        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string InstructorFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string InstructorLastName { get; set; }

        [Display(Name = "Instructor Name")]
        public string InstructorFullName
        {
            get
            {
                return $"{InstructorFirstName} {InstructorLastName}";
            }
        }

        [Required]
        [Display(Name = "Slack")]
        public string InstructorSlackHandle { get; set; }
        [Required]
        [Display(Name = "Cohort")]
        public int instructor_cohort_id { get; set; }
        public Cohort Cohort { get; set; }
    }
}