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
	/// Test class for StudentsServiceProvider
	/// </summary>
	[TestClass]
	public class StudentsServiceProviderTests
	{
		private StudentsServiceProvider _service;
		private MockDataFactory _dataFactory;

		private MockUnitOfWork<MockDataContext> _mockUnitOfWork;

		/// <summary>
		/// Initialization
		/// </summary>
		[TestInitialize]
		public void Setup()
		{
			// TODO: code which will be executed before each test!

			_mockUnitOfWork = new MockUnitOfWork<MockDataContext>();
			_dataFactory = new MockDataFactory();

			// Setting up mock repos to be used
			_mockUnitOfWork.SetRepositoryData(_dataFactory.GetMockRepo<Person>());

			// Creating the service using the new mock UOW
			_service = new StudentsServiceProvider(_mockUnitOfWork);
		}

		/// <summary>
		/// Testing the fetching of all students
		/// </summary>
		[TestMethod]
		public void GetStudents()
		{
			// Arrange:
			List<Person> mockPeople = _dataFactory.GetMockPersons();

			// Act:
			List<StudentDTO> students = _service.GetStudents();

			// Assert:
			Assert.AreEqual(mockPeople.Count, students.Count);
		}


		


	}
}
