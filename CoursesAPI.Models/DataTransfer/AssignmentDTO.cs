using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.DataTransfer
{
	public class AssignmentDTO
	{
		/// <summary>
		/// Database generated ID value for the assignment
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Name of the Assignment
		/// Example: "Dickbutt"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The assignment's weight
		/// </summary>
		public double Weight { get; set; }

		/// <summary>
		/// The database-generated ID value of the Course Instance the Assignment is tied to
		/// Example: 3
		/// </summary>
		public int CourseInstanceID { get; set; }

		/// <summary>
		/// The database-generated ID value of the Assignment Group the Assignment is tied to
		/// </summary>
		public int AssignmentGroupID { get; set; }

	}
}
