using CoursesAPI.Models.DataTransfer;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoursesAPI.Services.Exceptions;

namespace CoursesAPI.Services.Extensions
{
	/// <summary>
	/// Extension methods for assignment related data
	/// </summary>
	public static class AssignmentExtensions
	{

		/// <summary>
		/// Returns a single assignment group corresponding to a given course instance
		/// </summary>
		/// <param name="repo"></param>
		/// <param name="groupID"></param>
		/// <returns></returns>
		public static AssignmentGroup GetAssignmentGroupByID(this IRepository<AssignmentGroup> repo, int groupID)
		{
			var foundGroup = repo.All().SingleOrDefault(group => group.ID == groupID);

			if (foundGroup == null)
			{
				throw new ArgumentException(ErrorCodes.INVALID_ASSIGNMENT_GROUP_ID);
			}

			return foundGroup;
		}


		/// <summary>
		/// Returns an assignment group data transfer object through its entity class
		/// </summary>
		/// <param name="group"></param>
		/// <returns></returns>
		public static AssignmentGroupDTO GetAssignmentGroupDTO(this AssignmentGroup group){
			return new AssignmentGroupDTO
			{
				ID = group.ID,
				Name = group.Name,
				Weight = group.Weight,
				GradedAssignments = group.GradedAssignments,
				CourseInstanceID = group.CourseInstanceID
			};
		}

		/// <summary>
		/// Returns an assignment data transfer object through its entity class
		/// </summary>
		/// <param name="assignment">The assignment to use</param>
		/// <returns></returns>
		public static AssignmentDTO GetAssignmentDTO(this Assignment assignment){

			return new AssignmentDTO
			{
				ID = assignment.ID,
				Name = assignment.Name,
				AssignmentGroupID = assignment.AssignmentGroupID,	
				CourseInstanceID = assignment.CourseInstanceID
			};
		}

		/// <summary>
		/// Returns a data transfer object for a grade
		/// </summary>
		/// <param name="grade"The grade to use></param>
		/// <returns></returns>
		public static GradeDTO GetGradeDTO(this Grade grade)
		{

			return new GradeDTO
			{
				ID = grade.ID,
				AssignmentID = grade.AssignmentID,
				GradeValue = grade.GradeValue,
				StudentSSN = grade.StudentSSN
			};
		}
		
		/// <summary>
		/// Returns a list of assignments found by group ID
		/// </summary>
		/// <param name="repo">The repository to use</param>
		/// <param name="groupID"></param>
		/// <returns></returns>
		public static List<AssignmentDTO> GetGroupAssignments(this IRepository<Assignment> repo, int groupID)
		{

			var result = (from ass in repo.All()
						  where ass.AssignmentGroupID == groupID
						  select new AssignmentDTO
						  {
							  ID = ass.ID,
							  Name = ass.Name,
							  CourseInstanceID = ass.CourseInstanceID,
							  AssignmentGroupID = ass.AssignmentGroupID
						  }).ToList();

			return result;

		}

		/// <summary>
		/// Finds an assignment by ID
		/// </summary>
		/// <param name="repo"></param>
		/// <param name="assignmentID"></param>
		/// <returns></returns>
		public static Assignment GetAssignmentByID(this IRepository<Assignment> repo, int assignmentID)
		{
			var assignment = repo.All().SingleOrDefault(ass => ass.ID == assignmentID);

			// Illegal if assignment ID isn't found
			if (assignment == null)
			{
				throw new ArgumentException(ErrorCodes.INVALID_ASSIGNMENT_ID);
			}

			return assignment;
		}


		/// <summary>
		/// Calculates the combined weight of assignment group
		/// </summary>
		/// <returns></returns>
		public static double CalculateAssignmentGroupWeight(this List<AssignmentGroupDTO> groupList)
		{
			double totalWeight = 0;
			foreach (AssignmentGroupDTO group in groupList)
			{
				totalWeight += group.Weight;
			}

			return totalWeight;
		}

		
	}
}
