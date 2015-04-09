using CoursesAPI.Models.ViewModel;
using CoursesAPI.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Services.Helpers
{
	public static class AssignmentValidation
	{

		/// <summary>
		/// Validates an assignment swap view model
		/// </summary>
		/// <param name="swapModel">The swap model to validate</param>
		public static void ValidateAssignmentSwapVM(AddAssignmentGroupSwapViewModel swapModel)
		{
			// Validating base validity
			APIValidation.Validate(swapModel);

			// Assignment group IDs cannot be the same
			if (swapModel.SwapAssignmentGroupID == swapModel.BaseAssignmentGroupID)
			{
				throw new CoursesAPIException(ErrorCodes.IDENTICAL_GROUP_IDS);
			}


		}

		/// <summary>
		/// Validates an assignment group
		/// </summary>
		/// <param name="groupModel"></param>
		public static void ValidateAssignmentGroupVM(this AddAssignmentGroupViewModel groupModel)
		{
			// Validing the model
			APIValidation.Validate(groupModel);
		}

		/// <summary>
		/// Validates an assignment 
		/// </summary>
		/// <param name="groupModel"></param>
		public static void ValidateAssignmentVM(this AddAssignmentViewModel groupModel)
		{
			// Validing the model
			APIValidation.Validate(groupModel);
		}




	}
}
