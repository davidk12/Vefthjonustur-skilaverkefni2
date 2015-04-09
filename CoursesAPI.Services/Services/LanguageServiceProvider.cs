using CoursesAPI.Models;
using CoursesAPI.Services.Exceptions;
using CoursesAPI.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Services.Services
{
	/// <summary>
	///  Dummy language provider
	/// </summary>
	public class LanguageServiceProvider
	{
		public LanguageServiceProvider(){

		}

		public LanguageViewModel GetLanguageByName(string name)
		{

			//Throw exception on porpuse
			throw new CoursesAPIObjectNotFoundException(ErrorCodes.LanguageDoesNotExist);
		}

		public LanguageViewModel GetLanguageById(int id)
		{
			return new LanguageViewModel
			{
				Description = "Description",
				Timestamp = DateTime.UtcNow,
				Name = "Name"
			};
		}


		//Dummy function representing the method for creating a instance of Language
		public LanguageViewModel CreateLanguage(LanguageViewModel model)
		{
			//Validate here!
			APIValidation.Validate(model);

			//TODO create the corrsponding instance in DB

			return model;
		}
	}
}
