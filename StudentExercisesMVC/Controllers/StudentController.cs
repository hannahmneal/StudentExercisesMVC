using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExercisesMVC.Models;

namespace StudentExercisesMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IConfiguration _configuration;

        public StudentsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        // GET: Students
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT s.Id, s.StudentFirstName, s.StudentLastName, s.StudentSlackHandle, s.student_cohort_id,
                                               c.CohortName AS CohortName
                                          FROM Student s LEFT JOIN Cohort c on s.student_cohort_id = c.id";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();

                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            StudentFirstName = reader.GetString(reader.GetOrdinal("StudentFirstName")),
                            StudentLastName = reader.GetString(reader.GetOrdinal("StudentLastName")),
                            StudentSlackHandle = reader.GetString(reader.GetOrdinal("StudentSlackHandle")),
                            student_cohort_id = reader.GetInt32(reader.GetOrdinal("student_cohort_id")),
                            Cohort = new Cohort
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("student_cohort_id")),
                                CohortName = reader.GetString(reader.GetOrdinal("CohortName")),
                            }
                        };

                        students.Add(student);
                    }

                    reader.Close();
                    return View(students);
                }
            }
        }


        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT s.Id, s.StudentFirstName, s.StudentLastName, s.StudentSlackHandle, s.student_cohort_id,
                                               c.CohortName AS CohortName
                                          FROM Student s LEFT JOIN Cohort c on s.student_cohort_id = c.id
                                          WHERE s.Id = @id ";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Student student = null;

                    if(reader.Read())
                    {
                        student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            StudentFirstName = reader.GetString(reader.GetOrdinal("StudentFirstName")),
                            StudentLastName = reader.GetString(reader.GetOrdinal("StudentLastName")),
                            StudentSlackHandle = reader.GetString(reader.GetOrdinal("StudentSlackHandle")),
                            student_cohort_id = reader.GetInt32(reader.GetOrdinal("student_cohort_id")),
                            Cohort = new Cohort
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("student_cohort_id")),
                                CohortName = reader.GetString(reader.GetOrdinal("CohortName")),
                            }
                        };
                    }
                    reader.Close();
                    return View(student);
                }
            }
        }

        // GET: Students/Create
        //public ActionResult Create()
        //{
        //    StudentCreateViewModel viewModel =
        //        new StudentCreateViewModel(_configuration.GetConnectionString("DefaultConnection"));
        //    return View(viewModel);
        //}

        // POST: Students/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(StudentCreateViewModel viewModel)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = Connection)
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = @"INSERT INTO student (studentfirstname, studentlastname, studentslackhandle, student_cohort_id)
        //                                     VALUES (@studentfirstname, @studentlastname, @studentslackhandle, @student_cohort_id)";
        //                cmd.Parameters.Add(new SqlParameter("@studentfirstname", viewModel.Student.StudentFirstName));
        //                cmd.Parameters.Add(new SqlParameter("@studentlastname", viewModel.Student.StudentLastName));
        //                cmd.Parameters.Add(new SqlParameter("@studentslackhandle", viewModel.Student.StudentSlackHandle));
        //                cmd.Parameters.Add(new SqlParameter("@student_cohort_id", viewModel.Student.student_cohort_id));

        //                cmd.ExecuteNonQuery();

        //                return RedirectToAction(nameof(Index));
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        viewModel.Cohorts = GetAllCohorts();
        //        return View(viewModel);
        //    }
        //}

        // GET: Students/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    Student student = GetStudentById(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    StudentEditViewModel viewModel = new StudentEditViewModel
        //    {
        //        Cohorts = GetAllCohorts(),
        //        Student = student
        //    };

        //    return View(viewModel);
        //}

        // POST: Student/Edit/5
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit(int id, StudentEditViewModel viewModel)
        //        {
        //            try
        //            {
        //                using (SqlConnection conn = Connection)
        //                {
        //                    conn.Open();
        //                    using (SqlCommand cmd = conn.CreateCommand())
        //                    {
        //                        cmd.CommandText = @"UPDATE student 
        //                                           SET StudentFirstName = @StudentFirstName, 
        //                                               StudentLastName = @StudentLastName,
        //                                               StudentSlackHandle = @StudentSlackHandle, 
        //                                               student_cohort_id = @student_cohort_id
        //                                         WHERE id = @id;";
        //                        cmd.Parameters.Add(new SqlParameter("@StudentFirstName", viewModel.Student.StudentFirstName));
        //                        cmd.Parameters.Add(new SqlParameter("@StudentLastName", viewModel.Student.StudentLastName));
        //                        cmd.Parameters.Add(new SqlParameter("@StudentSlackHandle", viewModel.Student.StudentSlackHandle));
        //                        cmd.Parameters.Add(new SqlParameter("@student_cohort_id", viewModel.Student.student_cohort_id));
        //                        cmd.Parameters.Add(new SqlParameter("@id", id));

        //                        cmd.ExecuteNonQuery();

        //                        return RedirectToAction(nameof(Index));
        //                    }
        //                }
        //            }
        //            catch
        //            {
        //                viewModel.Cohorts = GetAllCohorts();
        //                return View(viewModel);
        //            }
        //        }

        //        // GET: Students/Delete/5
        //        public ActionResult Delete(int id)
        //        {
        //            return View();
        //        }

        //        // POST: Students/Delete/5
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Delete(int id, IFormCollection collection)
        //        {
        //            try
        //            {
        //                // TODO: Add delete logic here

        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch
        //            {
        //                return View();
        //            }
        //        }

        //        private Student GetStudentById(int id)
        //        {
        //            using (SqlConnection conn = Connection)
        //            {
        //                conn.Open();
        //                using (SqlCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = @"SELECT i.Id AS StudentId,
        //                                               i.StudentFirstName, i.StudentLastName, 
        //                                               i.StudentSlackHandle, i.student_cohort_id,
        //                                               c.CohortName AS CohortName
        //                                          FROM Student i LEFT JOIN Cohort c on i.student_cohort_id = c.id
        //                                         WHERE  i.Id = @id";
        //                    cmd.Parameters.Add(new SqlParameter("@id", id));
        //                    SqlDataReader reader = cmd.ExecuteReader();

        //                    Student student = null;

        //                    if (reader.Read())
        //                    {
        //                        student = new Student
        //                        {
        //                            Id = reader.GetInt32(reader.GetOrdinal("InstructorId")),
        //                            StudentFirstName = reader.GetString(reader.GetOrdinal("StudentFirstName")),
        //                            StudentLastName = reader.GetString(reader.GetOrdinal("StudentLastName")),
        //                            StudentSlackHandle = reader.GetString(reader.GetOrdinal("StudentSlackHandle")),
        //                            student_cohort_id = reader.GetInt32(reader.GetOrdinal("student_cohort_id")),
        //                            Cohort = new Cohort
        //                            {
        //                                Id = reader.GetInt32(reader.GetOrdinal("student_cohort_id")),
        //                                CohortName = reader.GetString(reader.GetOrdinal("CohortName")),
        //                            }
        //                        };
        //                    }

        //                    reader.Close();

        //                    return student;
        //                }
        //            }

        //        }

        //        private List<Cohort> GetAllCohorts()
        //        {
        //            using (SqlConnection conn = Connection)
        //            {
        //                conn.Open();
        //                using (SqlCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = @"SELECT id, name from Cohort;";
        //                    SqlDataReader reader = cmd.ExecuteReader();

        //                    List<Cohort> cohorts = new List<Cohort>();

        //                    while (reader.Read())
        //                    {
        //                        cohorts.Add(new Cohort
        //                        {
        //                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                            CohortName = reader.GetString(reader.GetOrdinal("name"))
        //                        });
        //                    }
        //                    reader.Close();

        //                    return cohorts;
        //                }
        //            }

        //        }

        //        private class StudentCreateViewModel
        //        {
        //            public StudentCreateViewModel(string v)
        //            {
        //            }

        //            public object Student { get; internal set; }
        //        }
    }
}