using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesAPI.Services.Models.Entities
{
	/// <summary>
	/// Entity class for Course Requirements
	/// Links together assignment groups and course instances
	/// </summary>
	//[Table("CourseRequirements")]
	public class CourseRequirement
	{

		/// <summary>
		/// Database generated ID value
		/// </summary>
		public int ID { get; set; }


		/// <summary>
		/// Minimum grade to pass
		/// </summary>
		public int CourseInstanceID				{ get; set; }

		/// <summary>
		/// ID value of the assessment type
		/// </summary>
		public int AssignmentGroupID			{ get; set; }
	}
}
