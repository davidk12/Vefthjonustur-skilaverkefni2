using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesAPI.Services.Models.Entities
{
	/// <summary>
	/// Entity class for course Assignments
	/// </summary>
	//[Table("Assignments")]
	public class Assignment
	{
		/// <summary>
		/// Database generated ID value for the assignment
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Name of the Assignment
		/// </summary>
		public string Name { get; set; }


		/// <summary>
		/// The database-generated ID value of the Course Instance the Assignment is tied to
		/// </summary>
		public int CourseInstanceID { get; set; }

		/// <summary>
		/// The database-generated ID value of the Assignment Group the Assignment is tied to
		/// </summary>
		public int AssignmentGroupID { get; set; }

	}
}
