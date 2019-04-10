using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudentExercisesMVC.Models;

namespace StudentExercisesMVC.Models
{
    public class Student
    {
        /*
                From Student Exercise Part 1:

                A student can only be in one cohort at a time. A student can be working on many exercises at a time.

                    1. First name
                    2. Last name
                    3. Slack handle
                    4. The student's cohort
                    5. The collection of exercises that the student is currently working on
            */


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


//namespace StudentExercises.Models.ViewModels
//{
//    public class StudentInstructorViewModel
//    {

//        public IEnumerable<Student> Students { get; set; }
//        public IEnumerable<Instructor> Instructors { get; set; }

//        private string _connectionString;

//        private SqlConnection Connection
//        {
//            get
//            {
//                return new SqlConnection(_connectionString);
//            }
//        }

//        public StudentInstructorViewModel(string connectionString)
//        {
//            _connectionString = connectionString;
//            GetAllStudents();
//            GetAllInstructors();
//        }

//        private void GetAllStudents()
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                        SELECT
//                            Id,
//                            FirstName,
//                            LastName,
//                            SlackHandle
//                        FROM Student";
//                    SqlDataReader reader = cmd.ExecuteReader();

//                    Students = new List<Student>();
//                    if (reader.Read())
//                    {
//                        Students.Add(new Student
//                        {
//                            Id = reader.GetString(reader.GetOrdinal("Id")),
//                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
//                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
//                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
//                        });
//                    }

//                    reader.Close();
//                }
//            }
//        }

//        private void GetAllInstructors()
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                            SELECT
//                            Id,
//                            FirstName,
//                            LastName,
//                            SlackHandle
//                        FROM Instructor";
//                    SqlDataReader reader = cmd.ExecuteReader();

//                    Instructors = new List<Instructor>();
//                    if (reader.Read())
//                    {
//                        Instructors.Add(new Instructor
//                        {
//                            Id = reader.GetString(reader.GetOrdinal("Id")),
//                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
//                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
//                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
//                        });
//                    }

//                    reader.Close();
//                }
//            }
//        }

//        public class Student
//        {
//        }
//    }
//}