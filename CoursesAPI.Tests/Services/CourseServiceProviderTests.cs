using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoursesAPI.Services.Services;
using CoursesAPI.Tests.MockObjects;
using CoursesAPI.Services.Models.Entities;
using System.Collections.Generic;
using CoursesAPI.Models;
using CoursesAPI.Models.DataTransfer;

namespace CoursesAPI.Tests.Services
{

	/// <summary>
	/// Test class for CourseServiceProvider
	/// </summary>
	[TestClass]
	public class CourseServiceProviderTests
	{
		private CoursesServiceProvider _service;
		private MockDataFactory _dataFactory;

		private MockUnitOfWork<MockDataContext> _mockUnitOfWork;

		/// <summary>
		/// Initialization before each test
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

			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<TeacherRegistration>());

			// Creating the service using the new mock UOW
			_service = new CoursesServiceProvider(_mockUnitOfWork);
		}

		/// <summary>
		/// Asserts the fetching of all course instances
		/// </summary>
		[TestMethod]
		public void GetCourseInstances()
		{
			// Arrange:
			List<CourseInstance> mockCourses = _dataFactory.GetMockCourseInstances();

			// Act:
			List<CourseInstanceDTO> courseInstances = _service.GetCourseInstances();

			// Assert:
			Assert.AreEqual(mockCourses.Count, courseInstances.Count);
		}


		/// <summary>
		/// Asserts the fetching of courses taught on semester
		/// </summary>
		[TestMethod]
		public void GetCoursesOnSemester(){

			// Arrange:
			// none

			// Act:
			List<CourseInstanceDTO> courses = _service.GetCourseInstancesOnSemester("20133");

			// Assert:
			Assert.AreEqual(courses.Count, 1);
			Assert.AreEqual("T17-FEE", courses[0].CourseID);

		}


		/// <summary>
		/// Asserts the fetching of teachers tied to a course instance
		/// </summary>
		[TestMethod]
		public void GetCourseTeachers()
		{
			// Arrange:
			// --

			// Act:
			List<Person> teachers = _service.GetCourseTeachers(1);

			// Assert
			Assert.AreEqual(2, teachers.Count);

		}

	


	}
}
