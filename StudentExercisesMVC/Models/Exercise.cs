using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentExercisesMVC.Models;


namespace StudentExercisesMVC.Models
{
    public class Exercise
    {
        /*
                From Student Exercise 1:
                An exercise can be assigned to many students; Instructors must be able to assign students.

                    1. Name of exercise
                    2. Language of exercise (JavaScript, Python, CSharp, etc.)

            */


        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseLanguage { get; set; }
    }
}
