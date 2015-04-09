namespace CoursesAPI.Models
{
	/// <summary>
	/// Data transfer object containing a course instance
	/// </summary>
	public class CourseInstanceDTO
	{
		/// <summary>
		/// Database generated ID value of the course instance
		/// </summary>
		public int CourseInstanceID { get; set; }

		/// <summary>
		/// Database generated ID value of the course template
		/// </summary>
		public string CourseID { get; set; }

		/// <summary>
		/// The name of the course 
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The ID value of the semester
		/// </summary>
		public string SemesterID { get; set; }

		/// <summary>
		/// The minimum grade to pass course
		/// </summary>
		public double MinGrade { get; set; }
	}
}
