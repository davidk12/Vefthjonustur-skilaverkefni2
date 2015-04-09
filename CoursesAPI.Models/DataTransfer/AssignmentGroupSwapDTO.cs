using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.DataTransfer
{

	/// <summary>
	/// A DTO object for a relation between two assignment groups weight/grade wise
	/// </summary>
	public class AssignmentGroupSwapDTO
	{
		/// <summary>
		/// The first assignment group
		/// </summary>
		public AssignmentGroupDTO FirstAssignmentGroup			{ get; set; }

		/// <summary>
		/// The second assignment group
		/// </summary>
		public AssignmentGroupDTO SecondAssignmentGroup			{ get; set; }
	}
}
