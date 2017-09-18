namespace CoursesAPI.Models
{
	/// <summary>
	/// This class represents the data needed when registering
	/// a teacher in a course.
	/// </summary>
	public class AddTeacherViewModel
	{
		/// <summary>
		/// The SSN of the person which will be registered
		/// as a teacher in a course.
		/// </summary>
		public string SSN { get; set; }

		/// <summary>
		/// The type of the teacher.
		/// </summary>
		public TeacherType Type { get; set; }
	}
}
