using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Models.DataTransfer
{
	/// <summary>
	/// Data transfer object for a grade
	/// </summary>
	public class GradeDTO
	{
		/// <summary>
		/// Database-generated ID value of the Grade instance
		/// </summary>
		public int ID { get; set;  }


		/// <summary>
		/// Database Generated ID value
		/// </summary>
		public int AssignmentID { get; set; }

		/// <summary>
		/// Name of the assignment the grade belongs to
		/// </summary>
		public string AssignmentName { get; set; }

		/// <summary>
		/// The actual grade value (0-10)
		/// </summary>
		public double GradeValue { get; set; }

		/// <summary>
		/// The database-generated ID value of the student who the grade belongs to
		/// </summary>
		public int StudentID { get; set; }

		/// <summary>
		/// SSN value of the student
		/// </summary>
		public string StudentSSN { get; set; }
	}
}
