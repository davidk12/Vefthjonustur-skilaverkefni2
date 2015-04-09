using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace CoursesAPI.Filters
{
	public class StudentsExceptionFilter : ExceptionFilterAttribute
	{
		/// <summary>
		/// An exception 
		/// </summary>
		/// <param name="actionExecutedContext"></param>
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{


		}

		/// <summary>
		/// Fetches a HttpError from a model state
		/// </summary>
		/// <param name="modelState"></param>
		/// <param name="includeErrorDetail"></param>
		/// <returns></returns>
		private HttpError GetErrors(ModelStateDictionary modelState, bool includeErrorDetail)
		{
			var modelStateError = new HttpError();
			foreach (KeyValuePair<string, ModelState> keyModelStatePair in modelState)
			{
				string key = keyModelStatePair.Key;
				ModelErrorCollection errors = keyModelStatePair.Value.Errors;
				if (errors != null && errors.Count > 0)
				{
					IEnumerable<string> errorMessages = errors.Select(error =>
					{
						if (includeErrorDetail && error.Exception != null)
						{
							return error.Exception.Message;
						}
						return String.IsNullOrEmpty(error.ErrorMessage) ? "ErrorOccurred" : error.ErrorMessage;
					}).ToArray();
					modelStateError.Add(key, errorMessages);
				}
			}

			return modelStateError;
		}
	}
}