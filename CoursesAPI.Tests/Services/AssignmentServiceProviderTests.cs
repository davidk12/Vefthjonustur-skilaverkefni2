using CoursesAPI.Models.DataTransfer;
using CoursesAPI.Models.ViewModel;
using CoursesAPI.Services.Models.Entities;
using CoursesAPI.Services.Services;
using CoursesAPI.Tests.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Tests.Services
{

	

	/// <summary>
	/// Test class for AssignmentServiceProvider
	/// </summary>
	[TestClass]
	public class AssignmentServiceProviderTests
	{
		// TODO: code which will be executed before each test!


		private AssignmentServiceProvider _service;
		private MockDataFactory _dataFactory;

		private MockUnitOfWork<MockDataContext> _mockUnitOfWork;

		/// <summary>
		/// Initialization of repos
		/// </summary>
		[TestInitialize]
		public void Setup()
		{
			// TODO: code which will be executed before each test!

			_mockUnitOfWork = new MockUnitOfWork<MockDataContext>();
			_dataFactory = new MockDataFactory();

			// Setting up mock repos to be used
			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<Person>());
			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<CourseTemplate>());
			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<CourseInstance>());
			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<AssignmentGroup>());
			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<Assignment>());
			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<Grade>());

			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<StudentRegistration>());
			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<CourseRequirement>());

			// Creating the service using the new mock UOW
			_service = new AssignmentServiceProvider(_mockUnitOfWork);
		}
	

		/// <summary>
		/// Asserts the fetching of all assignment group instances in a course
		/// </summary>
		[TestMethod]
		public void GetAssignmentGroups()
		{
			// Arrange:
			List<AssignmentGroup> allGroups = _dataFactory.GetMockAssignmentGroupList();

			
			// Act:
			List<AssignmentGroupDTO> groupInstances = _service.GetAssignmentGroups(1);

			// Assert:
			Assert.AreEqual(3, allGroups.Count);
			Assert.AreEqual(2, groupInstances.Count);
			Assert.AreEqual("Generic Group 1", groupInstances[0].Name);
			

		}

		/// <summary>
		/// Fetching of assignments within an assignment group
		/// </summary>
		[TestMethod]
		public void GetAssignmentsInGroup()
		{
			// Arrange:
			List<AssignmentGroup> allGroups = _dataFactory.GetMockAssignmentGroupList();
			List<Assignment> allAssignments = _dataFactory.GetMockAssignmentList();

			// Act:
			List<AssignmentDTO> assignments = _service.GetAssignmentsInGroup(1);

			// Assert:
			Assert.AreEqual(allAssignments.Count, 4);
			Assert.AreEqual(assignments.Count, 2);
		}

		/// <summary>
		/// Fetching of a single assignment
		/// </summary>
		[TestMethod]
		public void GetAssignmentGroup()
		{

			// Arrange:
			int courseInstanceID = 1;

			// Act:
			AssignmentGroupDTO group = _service.GetAssignmentGroup(courseInstanceID);

			// Assert:
			Assert.AreEqual("Generic Group 1", group.Name);
		}

		/// <summary>
		/// Fetching of all student grades in an assignment group
		/// </summary>
		[TestMethod]
		public void GetStudentGradesInGroup()
		{
			// Arrange:
			string studentSSN = "2233882299";
			int courseInstanceID = 1;

			// Act:
			StudentGradeDTO gradeObject = _service.GetStudentGradesInGroup(studentSSN, courseInstanceID);

			// Assert:
			Assert.IsNotNull(gradeObject);
			Assert.AreEqual("Barney Calhoun", gradeObject.Student.Name);
			Assert.AreEqual(2, gradeObject.StudentGrades.Count);
		}

		/// <summary>
		/// Adding a new assignment group
		/// </summary>
		[TestMethod]
		public void AddAssignmentGroup()
		{

			// Arrange:
			AddAssignmentGroupViewModel groupModel = new AddAssignmentGroupViewModel
			{
				GradedAssignments = 5,
				Name = "Another generic group",
				Weight = 10
			};

			int courseInstanceID = 1;

			// Act:
			AssignmentGroupDTO newGroup = _service.AddAssignmentGroup(courseInstanceID, groupModel);

			// Assert:
			Assert.AreEqual(groupModel.Name, newGroup.Name);
			Assert.AreEqual(groupModel.GradedAssignments, newGroup.GradedAssignments);
			Assert.AreEqual(groupModel.Weight, newGroup.Weight);


		}

		/// <summary>
		/// Adding a new assignment
		/// </summary>
		[TestMethod]
		public void AddAssignment()
		{

			// Arrange:
			AddAssignmentViewModel assignmentModel = new AddAssignmentViewModel
			{
				AssignmentGroupID = 1,
				Name = "Another Assignment"
			};

			// Act:
			AssignmentDTO newAssignment = _service.AddAssignment(1, assignmentModel);

			// Assert:
			Assert.AreEqual(assignmentModel.Name, newAssignment.Name);
			Assert.AreEqual(assignmentModel.AssignmentGroupID, newAssignment.AssignmentGroupID);
			
		}


		/// <summary>
		/// Adding a new assignment
		/// </summary>
		[TestMethod]
		public void AddAssignmentSwap()
		{
			// Arrange:
			AddAssignmentGroupSwapViewModel swapModel = new AddAssignmentGroupSwapViewModel
			{
				BaseAssignmentGroupID = 1,
				SwapAssignmentGroupID = 3
			};

			// Act:
			AssignmentGroupSwapDTO swapDTO = _service.AddAssignmentGroupSwap(swapModel);

			// Assert:
			Assert.AreEqual("Generic Group 1", swapDTO.FirstAssignmentGroup.Name);
			Assert.AreEqual("Generic Group 3", swapDTO.SecondAssignmentGroup.Name);

		}

		/// <summary>
		/// Fetching course requirements for a course
		/// </summary>
		[TestMethod]
		public void GetCourseRequirements()
		{
			// Arrange:
			int courseInstanceID = 1;

			// Act:
			List<AssignmentGroupDTO> requiredGroups = _service.GetCourseRequirements(courseInstanceID);

			// Assert:
			Assert.AreEqual(1, requiredGroups.Count);
			Assert.AreEqual("Generic Group 1", requiredGroups[0].Name);
		}

		/// <summary>
		/// Adding a new student grade
		/// </summary>
		[TestMethod]
		public void AddGrade()
		{
			// Arrange:
			AddGradeViewModel gradeModel = new AddGradeViewModel
			{
				GradeValue = 8,
				SSN = "2233882299",
				AssignmentID = 4
			};

			// Act:
			GradeDTO addedGrade = _service.AddGrade(gradeModel);

			// Assert:
			Assert.AreEqual(gradeModel.SSN, addedGrade.StudentSSN);
			Assert.AreEqual(gradeModel.GradeValue, addedGrade.GradeValue);
			Assert.AreEqual(gradeModel.AssignmentID, addedGrade.AssignmentID);

		}

		/// <summary>
		/// Fetching overview for a single student
		/// </summary>
		[TestMethod]
		public void GetSingleStudentGradeOverview()
		{
			// Arrange:
			string studentSSN = "2233882299";
			int courseInstanceID = 1;

			// Act:
			StudentGradeOverviewDTO overview = _service.GetSingleStudentGradeOverview(courseInstanceID, studentSSN);

			// Assert:
			Assert.IsNotNull(overview);
			Assert.AreEqual("2233882299", overview.Student.SSN);
			Assert.AreEqual(2, overview.Grades.Count);
		}


		/// <summary>
		/// Calculates earned grade within a group
		/// </summary>
		[TestMethod]
		public void CalculateEarnedGroupPercentage()
		{

			// Arrange:
			AssignmentGroupDTO group = new AssignmentGroupDTO
			{
				Name = "Hat Hut",
				CourseInstanceID = 1,
				Weight = 30,
				GradedAssignments = 2
			};

			List<GradeDTO> gradeList = new List<GradeDTO>();
			gradeList.Add(new GradeDTO
			{
				GradeValue = 10
			});
			gradeList.Add(new GradeDTO
			{
				GradeValue = 0
			});

			// Act:
			double groupGrade = _service.CalculateEarnedGroupPercentage(group, gradeList);


			// Assert:
			Assert.AreEqual(30 / 2.0 * 0.1, groupGrade);
		}



	}
}
