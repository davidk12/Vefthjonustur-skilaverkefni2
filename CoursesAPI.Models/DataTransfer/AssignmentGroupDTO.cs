using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.DataTransfer
{
	/// <summary>
	/// Data transfer object for assignment groups
	/// </summary>
	public class AssignmentGroupDTO
	{
		/// <summary>
		/// Database-generated ID value of the Assignment Group
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Assignment Group's name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The assignment group's weight of the total grade
		/// </summary>
		public double Weight { get; set; }

		/// <summary>
		/// The number of assignments 
		/// </summary>
		public int GradedAssignments { get; set; }

		/// <summary>
		/// The database-generated ID value of the Course Instance the Assignment Group belongs to
		/// </summary>
		public int CourseInstanceID { get; set; }


		/// <summary>
		/// Assignments in the assignment group
		/// </summary>
		public List<AssignmentDTO> Assignments { get; set; }
	}
}
