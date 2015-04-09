using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesAPI.Services.Models.Entities
{
	/// <summary>
	/// An entity class for storing a grade for a particular Assignment
	/// </summary>
	public class Grade
	{
		/// <summary>
		/// Database-generated ID value of the Grade instance
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// The SSN value of the student who the grade belongs to
		/// </summary>
		public string StudentSSN { get; set; }

		/// <summary>
		/// The ID value of the Assignment the Grade is bound to
		/// </summary>
		public int AssignmentID { get; set; }

		/// <summary>
		/// The actual Grade 
		/// </summary>
		public double GradeValue { get; set; }
	}
}
