using CoursesAPI.Models.DataTransfer;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesAPI.Services.Extensions;
using CoursesAPI.Models.ViewModel;
using CoursesAPI.Services.Exceptions;
using CoursesAPI.Services.Helpers;

namespace CoursesAPI.Services.Services
{
	public class AssignmentServiceProvider
	{
		private readonly IUnitOfWork _uow;

		
		private readonly IRepository<Person>					_persons;
		private readonly IRepository<Semester>					_semesters;
		private readonly IRepository<CourseTemplate>			_courseTemplates; 
		private readonly IRepository<CourseInstance>			_courseInstances;
		private readonly IRepository<AssignmentGroup>			_assignmentGroups;
		private readonly IRepository<Assignment>				_assignments;
		private readonly IRepository<Grade>						_grades;
		private readonly IRepository<CourseRequirement>			_courseRequirements;

		private readonly IRepository<StudentRegistration>		_studentRegistrations;

		private readonly IRepository<AssignmentGroupSwap>		_assignmentGroupSwaps;

		/// <summary>
		/// Main constructor
		/// </summary>
		/// <param name="uow"></param>
		public AssignmentServiceProvider(IUnitOfWork uow)
		{
			_uow = uow;
			_persons				= _uow.GetRepository<Person>();
			_semesters				= _uow.GetRepository<Semester>();
			_courseInstances		= _uow.GetRepository<CourseInstance>();
			_courseTemplates		= _uow.GetRepository<CourseTemplate>();
			_assignmentGroups		= _uow.GetRepository<AssignmentGroup>();
			_assignments			=_uow.GetRepository<Assignment>();
			_grades					= _uow.GetRepository<Grade>();

			_studentRegistrations	= _uow.GetRepository<StudentRegistration>();

			_courseRequirements		= _uow.GetRepository<CourseRequirement>();

			_assignmentGroupSwaps	= _uow.GetRepository<AssignmentGroupSwap>();
		}

	
		/// <summary>
		/// Fetches all assignment groups belonging to a certain course
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <returns></returns>
		public List<AssignmentGroupDTO> GetAssignmentGroups(int courseInstanceID)
		{

			CourseInstance course = _courseInstances.GetCourseInstanceByID(courseInstanceID);

			var result = (from assGroup in _assignmentGroups.All()
						  where assGroup.CourseInstanceID == courseInstanceID
						  select new AssignmentGroupDTO
						  {
							  ID = assGroup.ID,
							  CourseInstanceID = assGroup.CourseInstanceID,
							  Name = assGroup.Name,
							  GradedAssignments = assGroup.GradedAssignments,
							  Weight = assGroup.Weight

						  }).ToList();

			return result;

		}


		/// <summary>
		/// Fetches a single assignment group by ID
		/// </summary>
		/// <param name="assignmentGroupID"></param>
		/// <returns></returns>
		public AssignmentGroupDTO GetAssignmentGroup(int assignmentGroupID)
		{

			AssignmentGroup result = _assignmentGroups.GetAssignmentGroupByID(assignmentGroupID);


			AssignmentGroupDTO transObject = result.GetAssignmentGroupDTO();

			transObject.Assignments = GetAssignmentsInGroup(assignmentGroupID);

			return transObject;
		}

		/// <summary>
		/// Fetches all assignments belonging to an assignment group
		/// </summary>
		/// <param name="assignmentGroupID"></param>
		/// <returns></returns>
		public List<AssignmentDTO> GetAssignmentsInGroup(int assignmentGroupID)
		{
			//Making sure the group exists
			AssignmentGroup group = _assignmentGroups.GetAssignmentGroupByID(assignmentGroupID);

			// Fetching corresponding assignments
			List<AssignmentDTO> assignments = _assignments.GetGroupAssignments(assignmentGroupID);

			return assignments;
		}



		/// <summary>
		/// Fetches all student grades within an assignment group
		/// </summary>
		/// <param name="ssn"></param>
		/// <param name="assignmentGroupID"></param>
		/// <returns></returns>
		public StudentGradeDTO GetStudentGradesInGroup(string ssn, int assignmentGroupID)
		{

			// Fetching the student
			StudentDTO student = _persons.GetStudentBySSN(ssn).GetStudentDTO();

			// Fetching the course
			//CourseInstance course = _courseInstances.GetCourseInstanceByID(courseInstanceID);

			// Fetching the assignment group
			AssignmentGroupDTO assignmentGroup = _assignmentGroups.GetAssignmentGroupByID(assignmentGroupID).GetAssignmentGroupDTO();

			// Fetching the assignments in the group
			List<AssignmentDTO> assignments = _assignments.GetGroupAssignments(assignmentGroupID);

			List<GradeDTO> gradesDTO = (from a in assignments
										join g in _grades.All().ToList()
										on a.ID equals g.AssignmentID
										where student.SSN == g.StudentSSN
										select new GradeDTO
										{
											AssignmentID = g.AssignmentID,
											GradeValue = g.GradeValue,
											StudentID = student.ID,
											AssignmentName = a.Name,
											StudentSSN = ssn


										}).ToList();

			return new StudentGradeDTO
			{
				Student = student,
				StudentGrades = gradesDTO
			};

		}


		/// <summary>
		/// Adds an assignment group to a course instance
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <param name="groupData"></param>
		/// <returns></returns>
		public AssignmentGroupDTO AddAssignmentGroup(int courseInstanceID, AddAssignmentGroupViewModel groupData)
		{

			groupData.ValidateAssignmentGroupVM();
			
			// Fetching the course (throws an error if not found)
			CourseInstance course = _courseInstances.GetCourseInstanceByID(courseInstanceID);

			// Fetching the assignments in the group
			List<AssignmentGroupDTO> courseAssignmentGroups = GetAssignmentGroups(courseInstanceID);


			// Adding the new group's weight to the list 
			double totalWeight = courseAssignmentGroups.CalculateAssignmentGroupWeight() + groupData.Weight;

			// Illegal if new group weight goes above the maximum
			if (totalWeight > 100)
			{
				throw new CoursesAPIException(ErrorCodes.ILLEGAL_ASSIGNMENT_GROUP_WEIGHT);

			}

			// New group to add
			AssignmentGroup newGroup = new AssignmentGroup
			{
				CourseInstanceID = courseInstanceID,
				Name = groupData.Name,
				GradedAssignments = groupData.GradedAssignments,
				Weight = groupData.Weight
			};


			_assignmentGroups.Add(newGroup);

			_uow.Save();

			AssignmentGroupDTO groupDTO = newGroup.GetAssignmentGroupDTO();

			return groupDTO;
		}


		/// <summary>
		/// Adds an assignment to an assignment group
		/// </summary>
		/// <param name="assignmentGroupID"></param>
		/// <param name="assignmentData"></param>
		/// <returns></returns>
		public AssignmentDTO AddAssignment(int courseInstanceID, AddAssignmentViewModel assignmentData)
		{


			// Validating the data
			assignmentData.ValidateAssignmentVM();

			// Fetching the group (throws an error if not found)
			AssignmentGroup group = _assignmentGroups.GetAssignmentGroupByID(assignmentData.AssignmentGroupID);

			// Creating new assignment entity
			Assignment newAssignment = new Assignment
			{
				AssignmentGroupID = group.ID,
				CourseInstanceID = courseInstanceID,
				Name = assignmentData.Name
			};

			// Adding the new entity to the repo
			_assignments.Add(newAssignment);

			// Saving changes
			_uow.Save();

			return new AssignmentDTO
			{
				AssignmentGroupID = group.ID,
				ID = newAssignment.ID,
				Name = newAssignment.Name,
				CourseInstanceID = courseInstanceID,
				Weight = (double)group.Weight / group.GradedAssignments
			};
		}

		/// <summary>
		/// Ties two assignment groups together 
		/// In the event a student receives a worse grade in the group
		/// with the higher weight, the weights are switched around
		/// </summary>
		/// <param name="swapModel"></param>
		/// <returns></returns>
		public AssignmentGroupSwapDTO AddAssignmentGroupSwap(AddAssignmentGroupSwapViewModel swapModel)
		{
			// Validating the view model
			AssignmentValidation.ValidateAssignmentSwapVM(swapModel);
			
			var allAssGroups = _assignmentGroupSwaps.All();
			var result = allAssGroups.FirstOrDefault(  a => (a.BaseAssignmentGroupID == swapModel.BaseAssignmentGroupID
				&& a.TargetAssignmentGroupID == swapModel.SwapAssignmentGroupID)
				|| (a.BaseAssignmentGroupID == swapModel.SwapAssignmentGroupID
				&& a.TargetAssignmentGroupID == swapModel.BaseAssignmentGroupID));
				
	

			// If the relation already exists, throw error
			if(result != null){
				throw new ArgumentException(ErrorCodes.GROUP_SWAP_ALREADY_EXISTS);
			}

			// New swap entry
			AssignmentGroupSwap newSwap = new AssignmentGroupSwap
			{
				BaseAssignmentGroupID = swapModel.BaseAssignmentGroupID,
				TargetAssignmentGroupID = swapModel.SwapAssignmentGroupID
			};

			_assignmentGroupSwaps.Add(newSwap);

			_uow.Save();

			// Returning new assignment group DTO
			return new AssignmentGroupSwapDTO
			{
				FirstAssignmentGroup = GetAssignmentGroup(swapModel.BaseAssignmentGroupID),
				SecondAssignmentGroup = GetAssignmentGroup(swapModel.SwapAssignmentGroupID)
			};
		}


		/// <summary>
		/// Returns a list of assignment groups required to pass a course
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <returns></returns>
		public List<AssignmentGroupDTO> GetCourseRequirements(int courseInstanceID)
		{

			// Selecting all course requirements tied to the supplied course
			List<AssignmentGroupDTO> result = (from req in _courseRequirements.All()
											   join gr in _assignmentGroups.All() on req.AssignmentGroupID equals gr.ID
											   where req.CourseInstanceID == courseInstanceID
											   select new AssignmentGroupDTO
											   {
												   CourseInstanceID = courseInstanceID,
												   GradedAssignments = gr.GradedAssignments,
												   ID = gr.ID,
												   Name = gr.Name,
												   Weight = gr.Weight

											   }).ToList();

			// Getting the assignments for each group
			foreach (AssignmentGroupDTO group in result)
			{
				group.Assignments = GetAssignmentsInGroup(group.ID);
			}

			return result;
		}


		/// <summary>
		/// Returns grade overview for every student signed up in course
		/// </summary>
		/// <param name="courseInstanceID"></param>
		/// <returns></returns>
		public StudentGradeOverviewDTO GetSingleStudentGradeOverview(int courseInstanceID, string studentSSN)
		{

			// Fetching the course
			CourseInstance course = _courseInstances.GetCourseInstanceByID(courseInstanceID);

			// Fetching the student
			Person student = _persons.GetStudentBySSN(studentSSN);

			// Fetching the student course registration
			StudentRegistration registration = _studentRegistrations.GetCourseStudentByKeys(courseInstanceID, studentSSN);

			// Preparing the overview
			StudentGradeOverviewDTO overview = new StudentGradeOverviewDTO();

			// Fetching the assignment groups in the course
			List<AssignmentGroupDTO> courseAssignmentGroups = GetAssignmentGroups(courseInstanceID);

			// Setting the student in the overview
			overview.Student = student.GetStudentDTO();
			overview.Grades = new List<GradeDTO>();

			// For every group, we check if the student has a part in it
			foreach(AssignmentGroupDTO group in courseAssignmentGroups){

				StudentGradeDTO grades = GetStudentGradesInGroup(studentSSN, group.ID);

				// Adding the grades
				overview.Grades.AddRange(grades.StudentGrades);

				// Adding the weight to the final grade if applicable
				if (group.Weight > 0)
				{
					
					overview.EarnedGrade += Math.Round(CalculateEarnedGroupPercentage(group, grades.StudentGrades), 2);

					if (grades.StudentGrades.Count > 0)
					{
						overview.WeightGraded += group.Weight;
					}
					else
					{
						overview.WeightUngraded += group.Weight;
					}


					
				}

			
			}
			overview.WeightGraded *= 0.1;
			overview.WeightUngraded *= 0.1;

			return overview;
		}

		/// <summary>
		/// Calculates the grade earned in a given group relative to 100%
		/// </summary>
		public double CalculateEarnedGroupPercentage(AssignmentGroupDTO group, List<GradeDTO> earnedGrades){

			// Sorting the grades
			List<GradeDTO> sortedGrades = earnedGrades.OrderByDescending(o => o.GradeValue).ToList();

			
			double gradeValues = 0;

			// Checking the number of graded assignments
			int graded = (sortedGrades.Count > group.GradedAssignments) ? group.GradedAssignments : sortedGrades.Count;

			// Going through each group
			for(int index = 0; index < graded; index++){

				gradeValues += (group.Weight * 0.01 / graded) * sortedGrades[index].GradeValue;

			}

			return gradeValues;
		}

		/// <summary>
		/// Posts a new grade
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public GradeDTO AddGrade(AddGradeViewModel model)
		{
			// get the student from the ssn, throw exception if they don't exist
			Person student = _persons.GetStudentBySSN(model.SSN);

			// get the assignment from the assignmentID, throw exception if it doesn't exist
			Assignment assignment = _assignments.GetAssignmentByID(model.AssignmentID);

			// Checking if the grade already exists
			var studentGrade = _grades.All().SingleOrDefault(grade => grade.AssignmentID == model.AssignmentID && grade.StudentSSN == model.SSN);
			if (studentGrade != null)
			{
				throw new ArgumentException(ErrorCodes.ASSIGNMENT_GRADE_ALREADY_EXISTS);
			}

			Grade grad = new Grade
			{
				AssignmentID = model.AssignmentID,
				StudentSSN = model.SSN,
				GradeValue = model.GradeValue
			};

			_grades.Add(grad);

			_uow.Save();

			GradeDTO gradeTransfer = grad.GetGradeDTO();
			gradeTransfer.AssignmentName = assignment.Name;
			gradeTransfer.StudentID = student.ID;

			return gradeTransfer;
		}

		
	}
}
