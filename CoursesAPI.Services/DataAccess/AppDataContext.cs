using System.Data.Entity;
using CoursesAPI.Services.Models.Entities;
using CoursesAPI.Services.Models;

namespace CoursesAPI.Services.DataAccess
{
	public class AppDataContext : DbContext, IDbContext
	{
		/// <summary>
		/// Standalone tables
		/// </summary>
		public DbSet<Person>				Persons						{ get; set; }
		public DbSet<Semester>				Semesters					{ get; set; }

		/// <summary>
		/// Course data
		/// </summary>
		public DbSet<CourseTemplate>		CourseTemplates				{ get; set; }
		public DbSet<CourseInstance>		CourseInstances				{ get; set; }
		public DbSet<TeacherRegistration>	TeacherRegistrations		{ get; set; }
		public DbSet<StudentRegistration>	StudentRegistrations		{ get; set; }
		public DbSet<AssessmentStatus>		AssessmentStatuses			{ get; set; }

		/// <summary>
		/// Assignment data
		/// </summary>
		public DbSet<AssignmentGroup>		AssignmentGroups			{ get; set; }
		public DbSet<Assignment>			Assignments					{ get; set; }

		public DbSet<AssignmentGroupSwap>	AssignmentGroupSwaps			{ get; set; }

		public DbSet<Grade>					Grades						{ get; set; }

		public DbSet<CourseRequirement>		CourseRequirements			{ get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// modelBuilder.Configurations.Add(new CourseInstanceMap());
		}

		public AppDataContext()
		{
			//SERIALIZE WILL FAIL WITH PROXIED ENTITIES
			Configuration.ProxyCreationEnabled = false;

			//ENABLING COULD CAUSE ENDLESS LOOPS AND PERFORMANCE PROBLEMS
			Configuration.LazyLoadingEnabled = false;
		}
	}
}