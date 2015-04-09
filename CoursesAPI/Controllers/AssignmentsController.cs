using CoursesAPI.Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoursesAPI.Services.Services;

using CoursesAPI.Models.DataTransfer;
using CoursesAPI.Services.Exceptions;
using CoursesAPI.Filters;

namespace CoursesAPI.Controllers
{
	/// <summary>
	/// Controller for assignments
	/// </summary>
	[CoursesExceptionFilter]
	[RoutePrefix("api/v1/assignments")]
    public class AssignmentsController : ApiController
    {

		private readonly CoursesServiceProvider _service;

		/// <summary>
		/// Default constructor, sets the service in use
		/// </summary>
		public AssignmentsController()
		{
			_service = new CoursesServiceProvider(new UnitOfWork<AppDataContext>());
		}

		[Route("jaden")]
		[HttpGet]
		public void Jaden(){

			throw new JadenException(ErrorCodes.JADEN);

		}

    }
}
