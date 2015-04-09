using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.ViewModel
{
	/// <summary>
	/// View model class for adding new Assignment groups
	/// </summary>
	public class AddAssignmentGroupViewModel
	{
		/// <summary>
		/// Name of the assignment group
		/// </summary>
		[Required]
		public string Name					{ get; set; }

		/// <summary>
		/// The number of graded assignments
		/// </summary>
		[Required]
		public int GradedAssignments		{ get; set; }

		/// <summary>
		/// The weight of the group
		[Required]
		public double Weight				{ get; set; }

	}
}
