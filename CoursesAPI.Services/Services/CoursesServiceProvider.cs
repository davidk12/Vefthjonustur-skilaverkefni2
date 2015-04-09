using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using CoursesAPI.Models;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Models.Entities;
using CoursesAPI.Services.Helpers;
using CoursesAPI.Services.Exceptions;
using CoursesAPI.Models.DataTransfer;
using System.Diagnostics;

using CoursesAPI.Services.Extensions;
using CoursesAPI.Models.ViewModel;

namespace CoursesAPI.Services.Services
{
	/// <summary>
	/// Service that handles basic course data
	/// </summary>
	public class CoursesServiceProvider
	{
		private readonly IUnitOfWork _uow;

		/// <summary>
		/// General repos
		/// </summary>
		private readonly IRepository<Person>					_persons;
		private readonly IRepository<Semester>					_semesters;

		/// <summary>
		/// Course repos
		/// </summary>
		private readonly IRepository<CourseTemplate>			_courseTemplates; 
		private readonly IRepository<CourseInstance>			_courseInstances;
		private readonly IRepository<TeacherRegistration>		_teacherRegistrations;

		/// <summary>
		/// Assignment repos
		/// </summary>
		private readonly IRepository<AssignmentGroup>			_assignmentGroups;
		private readonly IRepository<Assignment>				_assignments;
		private readonly IRepository<Grade>						_grades;

		private readonly IRepository<CourseRequirement>			_courseRequirements;

		/// <summary>
		/// Main constructor
		/// </summary>
		/// <param name="uow"></param>
		public CoursesServiceProvider(IUnitOfWork uow)
		{
			_uow = uow;

			// basic (physics)
			_persons = _uow.GetRepository<Person>();
			_semesters = _uow.GetRepository<Semester>();

			// course
			_courseInstances		= _uow.GetRepository<CourseInstance>();
			_courseTemplates		= _uow.GetRepository<CourseTemplate>();
			_teacherRegistrations	= _uow.GetRepository<TeacherRegistration>();

			// Assignments
			_assignmentGroups = _uow.GetRepository<AssignmentGroup>();
			_assignments = _uow.GetRepository<Assignment>();
			_grades = _uow.GetRepository<Grade>();

			_courseRequirements = _uow.GetRepository<CourseRequirement>();
		}

       

		/// <summary>
		/// Fetches all teachers
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <returns></returns>
		public List<Person> GetCourseTeachers(int courseInstanceID)
		{
			// TODO:
            var result = from tr in _teacherRegistrations.All()
                         join p in _persons.All() on tr.SSN equals p.SSN
                         where tr.CourseInstanceID == courseInstanceID
                         select p;

            var result2 = result.ToList();
            return result2;
		}

		/// <summary>
		/// Returns all course instances
		/// </summary>
		/// <returns></returns>
		public List<CourseInstanceDTO> GetCourseInstances()
		{
			var stuff = _persons.All();

			List<CourseInstanceDTO> courseInstances;

			courseInstances = (from instance in _courseInstances.All()
							   join template in _courseTemplates.All() on instance.CourseID equals template.CourseID
							   select new CourseInstanceDTO
							   {
								   CourseInstanceID = instance.ID,
								   CourseID = instance.CourseID,
								   Name = template.Name
							   }).ToList();

			return courseInstances;
		}

		/// <summary>
		/// Fetches all course instances on a given semester
		/// </summary>
		/// <param name="semester"></param>
		/// <returns></returns>
		public List<CourseInstanceDTO> GetCourseInstancesOnSemester(string semester)
		{
			// TODO:
            if (String.IsNullOrEmpty(semester))
            {
                semester = _semesters.All().OrderByDescending(x => x.DateBegins).Select(s => s.ID).FirstOrDefault();
            }

            var result = from ci in _courseInstances.All()
                         join c in _courseTemplates.All() on ci.CourseID equals c.CourseID
                         where ci.SemesterID == semester
                         select new CourseInstanceDTO
                         {
                             CourseInstanceID = ci.ID,
                             CourseID = ci.CourseID,
                             Name = c.Name
                         };

            return result.OrderBy(c => c.Name).ToList();
		}




	}
}
