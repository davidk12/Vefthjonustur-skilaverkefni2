using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Services.Models.Entities
{
	/// <summary>
	/// An entity class for representing a relation between a course instance and a student
	/// </summary>
	public class StudentRegistration
	{

		/// <summary>
		/// Database generated ID value of the student registrations
		/// </summary>
		public int ID						{ get; set; }

		/// <summary>
		/// Student's SSN value
		/// </summary>
		public string StudentSSN			{ get; set; }

		/// <summary>
		/// Database generated ID value of the course instance
		/// </summary>
		public int CourseInstanceID			{ get; set; }

		/// <summary>
		/// The final grade attached to the course
		/// </summary>
		public double FinalGrade			{ get; set; }
		
		/// <summary>
		/// Database generated ID value of an assessment status attached to the registration
		/// </summary>
		public int AssessmentStatusID		{ get; set; }
	}
}
