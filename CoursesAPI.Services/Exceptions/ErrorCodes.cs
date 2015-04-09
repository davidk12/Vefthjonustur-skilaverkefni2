using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Services.Exceptions
{
    public class ErrorCodes
    {
        public const string IdDoesNotExistException						= "IdDoesNotExistException";
        public const string LanguageDoesNotExist						= "LanguageDoesNotExist";


		/// <summary>
		/// For when a student doesn't exist in the database
		/// </summary>
		public static string STUDENT_DOESNT_EXIST						= "StudentDoesntExist";

		/// <summary>
		/// In the event a course ID is invalid
		/// </summary>
		public static string INVALID_COURSE_ID							= "CourseIDInvalid";

		/// <summary>
		/// In the event an assignment group ID is invalid
		/// </summary>
		public static string INVALID_ASSIGNMENT_GROUP_ID				= "GroupIDInvalid";

		/// <summary>
		/// In the event an assignment ID is invalid
		/// </summary>
		public static string INVALID_ASSIGNMENT_ID						= "InvalidAssignmentID";

		/// <summary>
		/// In the event a provided assignment group's weight is illegal (< 0, > 100)
		/// </summary>
		public static string ILLEGAL_ASSIGNMENT_GROUP_WEIGHT			= "IllegalGroupWeight";

		/// <summary>
		/// When identical group IDs are sent in
		/// </summary>
		public static string IDENTICAL_GROUP_IDS						= "GroupIDsIdentical";

		/// <summary>
		/// When an assignment group swap relation already exists
		/// </summary>
		public static string GROUP_SWAP_ALREADY_EXISTS					= "GroupSwapAlreadyExists";

		/// <summary>
		/// When a student/assignment grade already exists
		/// </summary>
		public static string ASSIGNMENT_GRADE_ALREADY_EXISTS			= "AssignmentGradeAlreadyExists";

		/// <summary>
		/// For when blue trees
		/// </summary>
		public static string JADEN										= "HowCanMirrorsBeRealIfOurEyesArentReal";

		/// <summary>
		/// When a student isn't registered in a given course
		/// </summary>
		public static string STUDENT_NOT_REGISTERED_IN_COURSE			= "StudentNotRegisteredInCourse";
    }
}
