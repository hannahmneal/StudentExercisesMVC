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