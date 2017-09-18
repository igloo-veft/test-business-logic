namespace CoursesAPI.Models
{
	/// <summary>
	/// This is a lightweight class for a person, does not
	/// contain any details about the person.
	/// </summary>
	public class PersonDTO
	{
		/// <summary>
		/// The SSN of the person. Example:
		/// "1234567890"
		/// </summary>
		public string SSN { get; set; }

		/// <summary>
		/// The full name of the person.
		/// Example: "Herp McDerpsson"
		/// </summary>
		public string Name { get; set; }
	}
}
