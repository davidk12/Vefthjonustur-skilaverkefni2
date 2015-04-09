using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesAPI.Services.Models.Entities
{
	public class AssignmentGroup
	{
		/// <summary>
		/// Database-generated ID value of the Assignment Group
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// The Assignment Group's name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The number of graded assignments
		/// </summary>	
		public int GradedAssignments { get; set; }

		/// <summary>
		/// The blabla
		/// </summary>
		public int CourseInstanceID { get; set;  }

		/// <summary>
		/// The assignment group's weight
		/// </summary>
		public double Weight { get; set; }
	} 
}
