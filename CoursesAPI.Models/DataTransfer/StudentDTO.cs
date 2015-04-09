using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.DataTransfer
{
	/// <summary>
	/// A DTO class for the Student entity class
	/// </summary>
	public class StudentDTO
	{
		/// <summary>
		/// The database-generated ID value of the student
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// The SSN of the student, without spaces/dashes etc.
		/// </summary>
		public string SSN { get; set; }

		/// <summary>
		/// The full name of the student
		/// </summary>
		public string Name { get; set; }
	}
}
