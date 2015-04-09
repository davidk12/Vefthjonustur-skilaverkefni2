using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CoursesAPI.Models.DataTransfer
{
	/// <summary>
	/// Data transfer object that contains grades tied to a student 
	/// as well as student information
	/// </summary>
	public class StudentGradeDTO
	{
		/// <summary>
		/// Data transfer object containing the student details
		/// </summary>
		public StudentDTO Student { get; set; }

		/// <summary>
		/// List of student grade DTOs containing grades 
		/// tied to a student
		/// </summary>
		public List<GradeDTO> StudentGrades { get; set; }

	}

}
