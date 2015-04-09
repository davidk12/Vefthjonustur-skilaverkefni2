using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Models.Entities;
using CoursesAPI.Models.DataTransfer;

namespace CoursesAPI.Services.Services
{
	/// <summary>
	/// Service layer for students data
	/// </summary>
	public class StudentsServiceProvider
	{

		/// <summary>
		/// Unit of work being used
		/// </summary>
		private readonly IUnitOfWork				 _uow;

		/// <summary>
		/// Repository of registerees
		/// </summary>
		private readonly IRepository<Person>		_persons;


		/// <summary>
		/// Default constructor, accepts unit of work
		/// </summary>
		/// <param name="uow"></param>
		public StudentsServiceProvider(IUnitOfWork uow)
		{
			_uow = uow;

			_persons = _uow.GetRepository<Person>();

		}

		/// <summary>
		/// Returns all registered students
		/// </summary>
		/// <returns></returns>
		public List<StudentDTO> GetStudents()
		{
			List<StudentDTO> result;

			var stuff = _persons.All();

			result = (from person in _persons.All()
					  select new StudentDTO
					  {
						  ID = person.ID,
						  SSN = person.SSN,
						  Name = person.Name
					  }).ToList();
			return result;
		}
	}
}
