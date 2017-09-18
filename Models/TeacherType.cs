namespace CoursesAPI.Models
{
	/// <summary>
	/// This enum represents the different types/roles
	/// a teacher in a course can have.
	/// </summary>
	public enum TeacherType
	{
		/// <summary>
		/// The main teacher of the course. This is basically
		/// the teacher which runs the course, decides what is
		/// covered, writes the final exam etc.
		/// </summary>
		MainTeacher      = 1,

		/// <summary>
		/// An assistant teacher (TA). Can be a graduate student
		/// etc.
		/// </summary>
		AssistantTeacher = 2,
	}
}
