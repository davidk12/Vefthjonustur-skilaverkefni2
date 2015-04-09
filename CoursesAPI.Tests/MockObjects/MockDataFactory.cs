using CoursesAPI.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Tests.MockObjects
{
	/// <summary>
	/// A factory class responsible for spewing out mock data
	/// </summary>
	public class MockDataFactory
	{

		// A meta repo, keyvalue pair to store repos for all data
		private readonly Dictionary<Type, object> _repos;

		/// <summary>
		/// Default constructor, initializes meta repo dictionary
		/// </summary>
		public MockDataFactory()
		{
			// Intializing the meta repo
			_repos = new Dictionary<Type, object>();


			// Adding semesters to the repo
			_repos.Add(typeof(Semester), GetMockSemesters());

			// Adding persons to the list
			_repos.Add(typeof(Person), GetMockPersons());

			// Adding assessment statuses to the list
			_repos.Add(typeof(AssessmentStatus), GetMockAssessmentStatuses());

			// Adding course templates to repo
			_repos.Add(typeof(CourseTemplate), GetMockCourseTemplates());

			// Adding course instances to repo
			_repos.Add(typeof(CourseInstance), GetMockCourseInstances());

			// Adding assignment groups to repo
			_repos.Add(typeof(AssignmentGroup), GetMockAssignmentGroupList());

			// Adding assignment group swaps to repo
			_repos.Add(typeof(AssignmentGroupSwap), GetMockAssignmentGroupSwaps());

			// Adding assignments to repo
			_repos.Add(typeof(Assignment), GetMockAssignmentList());

			// Adding grades to the repo
			_repos.Add(typeof(Grade), GetMockGradeList());

			// Adding teacher registrations to the repo
			_repos.Add(typeof(TeacherRegistration), GetMockTeacherRegistrations());

			// Adding student registrations to the repo
			_repos.Add(typeof(StudentRegistration), GetMockStudentRegistrations());

			// Adding course requirements to the repo
			_repos.Add(typeof(CourseRequirement), GetMockCourseRequirements());
		}


		/// <summary>
		/// Returns the corresponding list of type supplied as a List from the repositorie
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public List<TemplateType> GetMockRepo<TemplateType>() where TemplateType : class
		{
			return _repos[typeof(TemplateType)] as List<TemplateType>;
		}

		/// <summary>
		/// Returns a list of mock course requirements
		/// </summary>
		/// <returns></returns>
		public List<CourseRequirement> GetMockCourseRequirements()
		{
			List<CourseRequirement> requirementList = new List<CourseRequirement>();
			requirementList.Add(new CourseRequirement
			{
				ID = 1,
				CourseInstanceID  = 1,
				AssignmentGroupID = 1
			});

			return requirementList;
		}



		/// <summary>
		/// Returns a list of mock student registrations
		/// </summary>
		/// <returns></returns>
		public List<StudentRegistration> GetMockStudentRegistrations()
		{
			List<StudentRegistration> registrationList = new List<StudentRegistration>();

			registrationList.Add(new StudentRegistration
			{
				ID = 1,
				StudentSSN = "2233882299",
				CourseInstanceID = 1,
				FinalGrade = 8,
				AssessmentStatusID = 1
			});

			return registrationList;
		}

		/// <summary>
		/// Returns a list of mock assignment group swaps
		/// </summary>
		/// <returns></returns>
		public List<AssignmentGroupSwap> GetMockAssignmentGroupSwaps()
		{
			List<AssignmentGroupSwap> swapList = new List<AssignmentGroupSwap>();

			swapList.Add(new AssignmentGroupSwap
			{
				ID = 1,
				BaseAssignmentGroupID = 1,
				TargetAssignmentGroupID = 2
			});

			return swapList;
		}

		/// <summary>
		/// Returns a list of mock teacher registrations
		/// </summary>
		/// <returns></returns>
		public List<TeacherRegistration> GetMockTeacherRegistrations()
		{
			List<TeacherRegistration> teacherRegistrationList = new List<TeacherRegistration>();

			teacherRegistrationList.Add(new TeacherRegistration
			{
				ID = 1,
				SSN = "1199118989",
				Type = 1,
				CourseInstanceID = 1
			});

			teacherRegistrationList.Add(new TeacherRegistration
			{
				ID = 2,
				SSN = "457293339",
				Type = 2,
				CourseInstanceID = 1
			});

			return teacherRegistrationList;
		}

		/// <summary>
		/// Returns a list of mock grades
		/// </summary>
		/// <returns></returns>
		public List<Grade> GetMockGradeList()
		{
			List<Grade> gradeList = new List<Grade>();

			gradeList.Add(new Grade
			{
				ID = 1,
				GradeValue = 7,
				AssignmentID = 1,
				StudentSSN = "2233882299"
			});

			gradeList.Add(new Grade
			{
				ID = 2,
				GradeValue = 8,
				AssignmentID = 3,
				StudentSSN = "2233882299"
			});

			gradeList.Add(new Grade
			{
				ID = 3,
				GradeValue = 6,
				AssignmentID = 2,
				StudentSSN = "2233882299"
			});

			return gradeList;
		}

		/// <summary>
		/// Returns a list of mock assignment groups
		/// </summary>
		/// <returns></returns>
		public List<AssignmentGroup> GetMockAssignmentGroupList()
		{
			List<AssignmentGroup> assignmentGroupList = new List<AssignmentGroup>();

			assignmentGroupList.Add(new AssignmentGroup
			{
				ID = 1,
				Name = "Generic Group 1",
				CourseInstanceID = 1,
				GradedAssignments = 5,
				Weight = 20				
			});

			assignmentGroupList.Add(new AssignmentGroup
			{
				ID = 2,
				Name = "Generic Group 2",
				CourseInstanceID = 2,
				GradedAssignments = 4,
				Weight = 20
			});

			assignmentGroupList.Add(new AssignmentGroup
			{
				ID = 3,
				Name = "Generic Group 3",
				CourseInstanceID = 1,
				GradedAssignments = 5,
				Weight = 25
			});


			return assignmentGroupList;
		}

		/// <summary>
		/// Returns a list of mock assignments
		/// </summary>
		/// <returns></returns>
		public List<Assignment> GetMockAssignmentList()
		{
			List<Assignment> assignmentList = new List<Assignment>();

			assignmentList.Add(new Assignment
			{
				ID = 1,
				AssignmentGroupID = 1,				
				CourseInstanceID = 1,
				Name = "Generic Assignment 1"
			});

			assignmentList.Add(new Assignment
			{
				ID = 2,
				AssignmentGroupID = 1,				
				CourseInstanceID = 1,
				Name = "Generic Assignment 2"
			});

			assignmentList.Add(new Assignment
			{
				ID = 3,
				AssignmentGroupID = 2,				
				CourseInstanceID = 2,
				Name = "Generic Assignment 3"
			});

			assignmentList.Add(new Assignment
			{
				ID = 4,
				AssignmentGroupID = 2,
				CourseInstanceID = 2,
				Name = "Generic Assignment 4"
			});


			return assignmentList;
		}

		/// <summary>
		/// Returns a list of mock course templates
		/// </summary>
		/// <returns></returns>
		public List<CourseTemplate> GetMockCourseTemplates()
		{
			List<CourseTemplate> courseList = new List<CourseTemplate>();

			courseList.Add(new CourseTemplate
			{
				CourseID = "T17-FEE",
				Description = "Fee-fi-fo-fum",
				Name = "Intricacies of Beanstalks"
			});

			courseList.Add(new CourseTemplate
			{
				CourseID = "T17-FI",
				Description = "I smell the blood of an Englishman",
				Name = "Giant Footwear 101"
			});

			courseList.Add(new CourseTemplate
			{
				CourseID = "T17-FO",
				Description = "Be he live, or be he dead",
				Name = "Social Policies of Giants"
			});

			courseList.Add(new CourseTemplate
			{
				CourseID = "T17-FUM",
				Description = "I'll grind his bones to make my bread",
				Name = "Grand Theft Gold"
			});

			return courseList;
		}

		/// <summary>
		/// Returns a mock list of course instances
		/// </summary>
		/// <returns></returns>
		public List<CourseInstance> GetMockCourseInstances()
		{

			List<CourseInstance> courseInstanceList = new List<CourseInstance>();

			courseInstanceList.Add(new CourseInstance{
				ID = 1,
				CourseID = "T17-FEE",
				MinGrade = 5,
				SemesterID = "20133"
			});

			courseInstanceList.Add(new CourseInstance
			{
				ID = 2,
				CourseID = "T17-FI",
				MinGrade = 5,
				SemesterID = "20132"
			});

			courseInstanceList.Add(new CourseInstance
			{
				ID = 3,
				CourseID = "T17-FO",
				MinGrade = 5,
				SemesterID = "20131"
			});

			return courseInstanceList;
		}

		/// <summary>
		/// Returns a mock list of assessment statuses
		/// </summary>
		/// <returns></returns>
		public List<AssessmentStatus> GetMockAssessmentStatuses()
		{
			List<AssessmentStatus> statusList = new List<AssessmentStatus>();

			statusList.Add(new AssessmentStatus
			{
				ID = 1,
				Status = "Graded"
			});

			statusList.Add(new AssessmentStatus
			{
				ID = 2,
				Status = "Evaluated"
			});

			statusList.Add(new AssessmentStatus
			{
				ID = 3,
				Status = "Ongoing"
			});

			statusList.Add(new AssessmentStatus
			{
				ID = 4,
				Status = "Failed"
			});


			return statusList;
		}
	

		/// <summary>
		/// Returns a mock list of semesters
		/// </summary>
		/// <returns></returns>
		public List<Semester> GetMockSemesters()
		{
			List<Semester> semesterList = new List<Semester>();

			semesterList.Add(new Semester
			{
				ID = "20133",
				Name = "Fall 2013",
				DateBegins = new DateTime(2013, 8, 16),
				DateEnds = new DateTime(2013, 12, 31)
			});

			semesterList.Add(new Semester
			{
				ID = "20132",
				Name = "Summer 2013",
				DateBegins = new DateTime(2013, 6, 1),
				DateEnds = new DateTime(2013, 8, 15)
			});

			semesterList.Add(new Semester
			{
				ID = "20131",
				Name = "Spring 2013",
				DateBegins = new DateTime(2013, 1, 1),
				DateEnds = new DateTime(2013, 5, 31)
			});

			return semesterList;
		}


		/// <summary>
		/// Returns a mock list of people
		/// </summary>
		/// <returns></returns>
		public List<Person> GetMockPersons()
		{
			List<Person> peopleList = new List<Person>();
			peopleList.Add(new Person
			{
				ID = 1,
				SSN = "1199118989",
				Name = "Gordon Freeman",
				Email = "Black Mesa"
			});

			peopleList.Add(new Person
			{
				ID = 2,
				SSN = "2233882299",
				Name = "Barney Calhoun",
				Email = "City 17"
			});

			peopleList.Add(new Person
			{
				ID = 3,
				SSN = "457293339",
				Name = "Wallace Breen",
				Email = "The Citadel"
			});


			return peopleList;
		}


	}
}
