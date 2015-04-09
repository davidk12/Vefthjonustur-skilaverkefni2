using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Exceptions;

using CoursesAPI.Services.Models.Entities;
using CoursesAPI.Models.DataTransfer;

namespace CoursesAPI.Services.Extensions
{


	/// <summary>
	/// Extension methods for student related data
	/// </summary>
	public static class StudentExtensions
	{
		/// <summary>
		/// Returns Student data in the form of a Student Data Object
		/// </summary>
		/// <param name="student"></param>
		/// <returns></returns>
		public static StudentDTO GetStudentDTO(this Person student)
		{
			StudentDTO studentData = new StudentDTO
			{
				ID = student.ID,
				Name = student.Name,
				SSN = student.SSN
			};

			return studentData;
		}


		/// <summary>
		/// Queries a repository of Persons for a Person with a certain SSN key
		/// </summary>
		/// <param name="repo"></param>
		/// <param name="studentSSN"></param>
		/// <returns></returns>
		public static Person GetStudentBySSN(this IRepository<Person> repo, string studentSSN)
		{
			// Querying the provided repo
			var student = repo.All().SingleOrDefault(s => s.SSN == studentSSN);

			// If nothing is found, student doesn't exist
			if (student == null)
			{
				// Throwing a new argument exception
				throw new ArgumentException(ErrorCodes.STUDENT_DOESNT_EXIST);
			}

			return student;
		}
	}
}
