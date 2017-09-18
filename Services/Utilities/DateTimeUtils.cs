namespace CoursesAPI.Services.Utilities
{
	public class DateTimeUtils
	{
		public static bool IsLeapYear(int year)
		{
			if(year % 4 == 0) {
				if(year % 100 == 0) {
					if(year % 400 == 0) {
						return true;
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
