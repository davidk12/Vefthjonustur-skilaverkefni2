using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Models.Entities;

using CoursesAPI.Services.Exceptions;

namespace CoursesAPI.Services.Extensions
{
	/// <summary>
	/// Extension methods for course related data
	/// </summary>
	public static class CourseExtensions
	{
		/// <summary>
		/// Returns a single course corresponding to a given course instance ID value
		/// </summary>
		/// <param name="repo"></param>
		/// <param name="courseID"></param>
		/// <returns></returns>
		public static CourseInstance GetCourseInstanceByID(this IRepository<CourseInstance> repo, int courseID)
		{
			var course = repo.All().SingleOrDefault(c => c.ID == courseID);
			if (course == null)
			{
				throw new ArgumentException(ErrorCodes.INVALID_COURSE_ID);
			}

			return course;
		}


		/// <summary>
		/// Fetches a student registered in a course
		/// </summary>
		/// <param name="repo"></param>
		/// <param name="courseInstanceID"></param>
		/// <param name="studentSSN"></param>
		/// <returns></returns>
		public static StudentRegistration GetCourseStudentByKeys(this IRepository<StudentRegistration> repo, int courseInstanceID, string studentSSN)
		{
			var courseStudent = repo.All().SingleOrDefault(cs => cs.StudentSSN == studentSSN && cs.CourseInstanceID == courseInstanceID);

			if (courseStudent == null)
			{
				throw new ArgumentException(ErrorCodes.STUDENT_NOT_REGISTERED_IN_COURSE);
			}
			return courseStudent;
		}

		
	}
}
