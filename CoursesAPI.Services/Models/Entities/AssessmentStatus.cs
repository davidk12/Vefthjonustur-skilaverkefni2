using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Services.Models.Entities
{
	/// <summary>
	/// Entity class used to refer to a student's assessment status
	/// </summary>
	public class AssessmentStatus
	{

		/// <summary>
		/// The database-generated ID value of the assessment status
		/// </summary>
		public int ID { get; set;  }

		/// <summary>
		/// The 
		/// </summary>
		public string Status { get; set; }
	}
}
