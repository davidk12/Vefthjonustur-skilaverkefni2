using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.DataTransfer
{
	/// <summary>
	/// A transfer object containing grade overview for a particular student
	/// </summary>
	public class StudentGradeOverviewDTO
	{
		/// <summary>
		/// Data transfer object containing the details of the student who the overview is tied
		/// </summary>
		public StudentDTO Student				{ get; set; }

		/// <summary>
		/// A list of transfer objects containing grades earned by the student
		/// </summary>
		public List<GradeDTO> Grades			{ get; set; }

		/// <summary>
		/// A calculated final grade
		/// </summary>
		public double EarnedGrade				{ get; set; }

		/// <summary>
		/// The actual graded weight
		/// </summary>
		public double WeightGraded				{ get; set; }

		/// <summary>
		/// The assignment grade the course is composed of
		/// participated in
		/// </summary>
		public double WeightUngraded			{ get; set; }
	}
}
