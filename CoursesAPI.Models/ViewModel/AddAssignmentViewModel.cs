using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.ViewModel
{
	/// <summary>
	/// View model for adding a new assignment
	/// </summary>
	public class AddAssignmentViewModel
	{
		/// <summary>
		/// Assignment's name
		/// </summary>
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Assignment's group ID
		/// </summary>
		[Required]
		public int AssignmentGroupID { get; set; }

		
	}
}
