using System.Collections.Generic;
using System.Web.Http;
using CoursesAPI.Models;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Models.Entities;
using CoursesAPI.Services.Services;
using System;
using CoursesAPI.Models.DataTransfer;
using CoursesAPI.Models.ViewModel;
using CoursesAPI.Filters;
using CoursesAPI.Services.Helpers;


namespace CoursesAPI.Controllers
{

	/// <summary>
	/// Management controller for courses and course instances
	/// </summary>
	[CoursesExceptionFilter]
	[RoutePrefix("api/v1/courses")]
	public class CoursesController : ApiController
	{
		private readonly CoursesServiceProvider _service;

		private readonly AssignmentServiceProvider _assignmentService;

		/// <summary>
		/// Default constructor
		/// </summary>
		public CoursesController()
		{
			UnitOfWork<AppDataContext> uow = new UnitOfWork<AppDataContext>();
			_service = new CoursesServiceProvider(uow);
			_assignmentService = new AssignmentServiceProvider(uow);
		}


		/// <summary>
		/// Fetches all teachers tied to a given course
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("")]
		public List<CourseInstanceDTO> GetCourseInstances()
		{
			return _service.GetCourseInstances();
		}


		/// <summary>
		/// Fetches all teachers tied to a given course
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("{courseInstanceID}/teachers")]
		public List<Person> GetCourseTeachers(int courseInstanceID)
		{
			return _service.GetCourseTeachers(courseInstanceID);
		}
		
		/// <summary>
		/// Fetches all course instances on a given semester
		/// </summary>
		/// <param name="semester"></param>
		/// <returns></returns>
        [Route("semester/{semester}")]
        public List<CourseInstanceDTO> GetCoursesOnSemester2(string semester)
        {
            return _service.GetCourseInstancesOnSemester(semester);
        }

		/// <summary>
		/// Fetches all assignment groups in a given course
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("{courseInstanceID:int}/assignments")]
		public List<AssignmentGroupDTO> GetAssignmentGroups(int courseInstanceID)
		{


			return _assignmentService.GetAssignmentGroups(courseInstanceID);

		}

		/// <summary>
		/// Fetches all assignments within a given assignment group
		/// </summary>
		/// <param name="assignmentGroupID"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("assignments/{assignmentGroupID:int}")]
		public List<AssignmentDTO> GetAssignmentsInGroup(int assignmentGroupID)
		{
			return _assignmentService.GetAssignmentsInGroup(assignmentGroupID);
		}

		/// <summary>
		/// Fetches all assignments
		/// </summary>
		/// <param name="studentSSN"></param>
		/// <param name="assignmentGroupID"></param>
		/// <returns></returns>
		[HttpGet]
		//[Route("{courseInstanceID:int}/students/{studentSSN}/assignments/{assignmentGroupID:int}")]
		//public StudentGradeDTO GetStudentGradesInGroup(string studentSSN, int courseInstanceID, int assignmentGroupID)
		[Route("assignments/{assignmentGroupID:int}/students/{studentSSN}")]
		public StudentGradeDTO GetStudentGradesInGroup(string studentSSN, int assignmentGroupID)
		{
			return _assignmentService.GetStudentGradesInGroup(studentSSN, assignmentGroupID);
		}

		/// <summary>
		/// Adds a new assignment group
		/// </summary>
		/// <param name="courseInstanceID">The ID of the course to add to</param>
		/// <param name="model">A view model containing assignment group data</param>
		/// <returns></returns>
		[HttpPost]
		[Route("{courseInstanceID:int}/assignments")]
		public AssignmentGroupDTO AddAssigmentGroup(int courseInstanceID, AddAssignmentGroupViewModel model) 
		{
			APIValidation.Validate(model);
			return _assignmentService.AddAssignmentGroup(courseInstanceID, model);
		}

		/// <summary>
		/// Adds a new assignment to an assignment group
		/// </summary>
		/// <param name="assignmentGroupID">The ID value of the assignment group to add to</param>
		/// <param name="assignmentData">The assignment data to post</param>
		/// <param name="courseInstanceID"</param>
		/// <returns></returns>
		[HttpPost]
		[Route("{courseInstanceID:int}/assignments/{assignmentGroupID:int}")]
		public AssignmentDTO AddAssignment(int courseInstanceID, int assignmentGroupID, AddAssignmentViewModel assignmentData)
		{
			return _assignmentService.AddAssignment(courseInstanceID, assignmentData);
		}

		/// <summary>
		/// Adds a new grade
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("grade")]
		public GradeDTO addGrade(AddGradeViewModel model)
		{
			return _assignmentService.AddGrade(model);
		}


		/// <summary>
		/// Returns all assignments in an assignment group
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <param name="assignmentGroupID"></param>
		/// <param name="assignmentData"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("{courseInstanceID:int}/assignments/{assignmentGroupID:int}")]
		public List<AssignmentDTO> AddAssignment(int courseInstanceID, int assignmentGroupID)
		{
			return _assignmentService.GetAssignmentsInGroup(assignmentGroupID);
		}

		/// <summary>
		/// Fetches the requirements for a course
		/// </summary>
		/// <param name="courseInstanceID">The ID value of the course instance</param>
		/// <returns></returns>
		[HttpGet]
		[Route("{courseInstanceID:int}/requirements")]
		public List<AssignmentGroupDTO> GetCourseRequirements(int courseInstanceID)
		{

			return _assignmentService.GetCourseRequirements(courseInstanceID);
		}


		/// <summary>
		/// Adds a new relation between two assignment groups which allows for the group weights to be swapped
		/// if a student receives a worse grade in the lesser weight group
		/// </summary>
		/// <param name="swapModel"></param>
		/// <returns></returns>
		[HttpPatch]
		[Route("{courseInstanceID:int}/assignments")]
		public AssignmentGroupSwapDTO AddAssignmentGroupSwap(AddAssignmentGroupSwapViewModel swapModel)
		{
			return _assignmentService.AddAssignmentGroupSwap(swapModel);
		}


		/// <summary>
		/// Fetches an overview for a student in a particular course
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <param name="studentSSN"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("{courseInstanceID:int}/students/{studentSSN}/overview")]
		public StudentGradeOverviewDTO GetSingleStudentGradeOverview(int courseInstanceID, string studentSSN)
		{
			return _assignmentService.GetSingleStudentGradeOverview(courseInstanceID, studentSSN);
		}

		
	}
}
