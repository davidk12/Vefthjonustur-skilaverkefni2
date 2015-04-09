using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.DataTransfer
{
	/// <summary>
	/// Data transfer object for teachers
	/// </summary>
	public class TeacherDTO
	{
		/// <summary>
		/// Teacher's user ID
		/// </summary>
		public int TeacherID { get; set; }

		/// <summary>
		/// Teacher's SSN
		/// </summary>
		public string TeacherSSN { get; set; }

		/// <summary>
		/// Teacher's full name
		/// </summary>
		public string Name { get; set; }


	}
}
