using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.ViewModel
{
	/// <summary>
	/// A view model of an AssignmentGroupSwap relation that's sent in as input
	/// </summary>
	public class AddAssignmentGroupSwapViewModel
	{	
		/// <summary>
		/// First assignment group
		/// </summary>
		[Required]
		public int BaseAssignmentGroupID { get; set; }

		/// <summary>
		/// Second assignment
		/// </summary>
		[Required]
		public int SwapAssignmentGroupID { get; set; }
	}
}
