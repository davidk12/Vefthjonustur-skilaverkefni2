using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Services.Exceptions
{
	/// <summary>
	///  An exception for when trees are blue
	/// </summary>
	public class JadenException : Exception
	{
		public JadenException(string msg)
			: base(msg){}
	}
}
