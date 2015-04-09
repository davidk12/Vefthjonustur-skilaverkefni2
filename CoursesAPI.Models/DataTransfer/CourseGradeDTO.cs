using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.DataTransfer
{
	public class CourseGradeDTO
	{

		public int CourseInstanceID { get; set; }

		/// <summary>
		/// Data transfer object containing the Student the Grades belong to
		/// </summary>
		public StudentDTO Student { get; set; }

		/// <summary>
		/// A list of grades earned by the student
		/// </summary>
		public List<StudentGradeDTO> Grades { get; set; }
	}
}
