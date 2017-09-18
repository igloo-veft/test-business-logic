using System;

namespace CoursesAPI.Services.Exceptions
{
	public class AppValidationException : Exception
	{
		public AppValidationException(string msg)
			: base(msg)
		{
			
		}
	}
}
