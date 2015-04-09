using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Services.Models.Entities
{
	/// <summary>
	/// Entity class for assignment group swap
	/// A relation which allows the weight in assignment groups to be swapped
	/// around if a student's grade in the higher weight is less than in the smaller
	/// </summary>
	public class AssignmentGroupSwap
	{

		/// <summary>
		/// The database generated ID value of the relation
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// The ID value of the assignment first assignment group
		/// </summary>
		public int BaseAssignmentGroupID { get; set; }

		/// <summary>
		/// The ID value of the second assignment group
		/// </summary>
		public int TargetAssignmentGroupID { get; set; }
	}
}
