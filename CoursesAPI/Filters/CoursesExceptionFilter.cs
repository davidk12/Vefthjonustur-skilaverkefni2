using CoursesAPI.Services.Exceptions;
using Mindscape.Raygun4Net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace CoursesAPI.Filters
{
    /// <summary>
    /// An attempt to write a generic exception filter, which would ensure..
    /// </summary>
    public class CoursesExceptionFilter : ExceptionFilterAttribute
    {
		/// <summary>
		/// An exception 
		/// </summary>
		/// <param name="actionExecutedContext"></param>
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

			HttpStatusCode code;

			HttpError error = new HttpError();
		
			// Various exception cases
			if (actionExecutedContext.Exception is ArgumentException)
			{

				var ex = actionExecutedContext.Exception as ArgumentException;
				code = HttpStatusCode.BadRequest;
			}
			else if (actionExecutedContext.Exception is SqlException)
			{
				var ex = actionExecutedContext.Exception as SqlException;
				code = HttpStatusCode.BadRequest;
			}
			else
			{
				var ex = actionExecutedContext.Exception as Exception;
				code = HttpStatusCode.InternalServerError;
			}
		

			// Setting the error response
			error.Add("Error", actionExecutedContext.Exception.Message);
			actionExecutedContext.Response = actionExecutedContext.ActionContext.Request.CreateErrorResponse(code, error);

           
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