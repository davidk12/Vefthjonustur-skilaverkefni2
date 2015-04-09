using CoursesAPI.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.ViewModel
{
	/// <summary>
	/// View model for adding a new grade relation between a 
	/// student and assignment
	/// </summary>
	public class AddGradeViewModel
	{
		/// <summary>
		/// The ID for the assignment to be graded
		/// </summary>
		[Required]
		public int AssignmentID				{ get; set; }

		/// <summary>
		/// The grade for the assignment
		/// </summary>
		[Required]
		public double GradeValue			{ get; set; }

		/// <summary>
		/// The student ssn which the grade belongs to
		/// </summary>
		[Required]
		public string SSN					{ get; set; }
	}
}