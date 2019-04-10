using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExercisesMVC.Models;

namespace StudentExercisesMVC.Controllers
{
    public class CohortsController : Controller
    {
        private readonly IConfiguration _configuration;

        public CohortsController(IConfiguration configuration)
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

        public string InstructorFirstName { get; private set; }
        public string InstructorLastName { get; private set; }

        //====================================================================================

        // GET: Cohorts
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //cmd.CommandText = @"SELECT c.Id, c.Name, s.StudentFirstName s.StudentLastName, s.StudentSlackHandle, i.InstructorFirstName, i.InstructorLastName, i.InstructorSlackHandle
                    //                    FROM Cohort c
                    //                    LEFT JOIN Student s ON c.Id = s.student_cohort_id
                    //                    LEFT JOIN Instructor i ON c.Id = i.instructor_cohort_id";

                    //NOTE: For Cohort detail, I want the names of instructors and students in the cohort but I'm having trouble setting it up properly or in a way that VS recognizes. Consider using a CohortViewModel for these details instead. In the meantime, only the cohort information (name and id) are used.

                    cmd.CommandText = @"SELECT * FROM Cohort c";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cohort> cohorts = new List<Cohort>();

                    while (reader.Read())
                    {
                        Cohort cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                        };

                        cohorts.Add(cohort);
                    }

                    reader.Close();
                    return View(cohorts);
                }
            }
        }

        //====================================================================================


        // GET: Cohorts/Details/5
        public ActionResult Details(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //cmd.CommandText = @"SELECT c.Id, c.Name, s.StudentFirstName s.StudentLastName, s.StudentSlackHandle, i.InstructorFirstName, i.InstructorLastName, i.InstructorSlackHandle
                    //                    FROM Cohort c
                    //                    LEFT JOIN Student s ON c.Id = s.student_cohort_id
                    //                    LEFT JOIN Instructor i ON c.Id = i.instructor_cohort_id";

                    //NOTE: For Cohort detail, I want the names of instructors and students in the cohort but I'm having trouble setting it up properly or in a way that VS recognizes. Consider using a CohortViewModel for these details instead. In the meantime, only the cohort information (name and id) are used.

                    cmd.CommandText = @"SELECT * FROM Cohort c";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Cohort cohort = null;

                    if (reader.Read())

                    {
                        cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName")),
                        };
                    }

                    reader.Close();
                    return View(cohort);
                }
            }
        }

        //====================================================================================


        // GET: Cohorts/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //====================================================================================


        // POST: Cohorts/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //====================================================================================


        // GET: Cohorts/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //====================================================================================


        // POST: Cohorts/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //====================================================================================


        // GET: Cohorts/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //====================================================================================


        // POST: Cohorts/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}