﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using StudentExercisesMVC.Models;

namespace StudentExercisesMVC.Models
{
    public class Cohort
    {
        public int Id { get; set; }
        public string CohortName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
