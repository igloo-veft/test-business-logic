	using CoursesAPI.Models;

namespace CoursesAPI.Services.Models.Entities
{
	/// <summary>
	/// An instance of this class represents the fact that a given
	/// person is a teacher in a given course instance.
	/// </summary>
	public class TeacherRegistration
	{
		/// <summary>
		/// A database-generated ID of the teacher registration.
		/// </summary>
		public int    ID               { get; set; }

		/// <summary>
		/// The SSN of the person.
		/// </summary>
		public string SSN              { get; set; }
		
		/// <summary>
		/// The ID of the course instance the given teacher is teaching
		/// </summary>
		public int    CourseInstanceID { get; set; }
	
		/// <summary>
		/// The type of teacher:
		/// 1: main teacher
		/// 2: assistant teacher
		/// etc. (see the TeacherType enumeration for all the possibilities).
		/// </summary>
		public TeacherType    Type             { get; set; }
	}
}
