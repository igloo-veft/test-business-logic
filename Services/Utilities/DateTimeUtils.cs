namespace CoursesAPI.Services.Utilities
{
	public class DateTimeUtils
	{
		public static bool IsLeapYear(int year)
		{
			if(year % 4 == 0) {
				return true;
			}
			// TODO: add your logic here!!!1!!!one!!!eleven
			return false;
		}
	}
}
