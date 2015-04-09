using CoursesAPI.Models.DataTransfer;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoursesAPI.Controllers
{
	/// <summary>
	/// Student management/data controller
	/// </summary>
	[RoutePrefix("api/v1/students")]
    public class StudentsController : ApiController
    {

		/// <summary>
		/// Student service in use
		/// </summary>
		private readonly StudentsServiceProvider _studentService;

		/// <summary>
		/// Default constructor
		/// </summary>
		public StudentsController()
		{
			_studentService = new StudentsServiceProvider(new UnitOfWork<AppDataContext>());
		}


		/// <summary>
		/// Fetches all students
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("")]
		public List<StudentDTO> GetStudents()
		{
			return _studentService.GetStudents();
		}




    }
}
