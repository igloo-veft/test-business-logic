using CoursesAPI.Services.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoursesAPI.Tests.Utilities
{
    [TestClass]
	public class DateTimeUtilsTests
	{
		#region IsLeapYear

		/// <summary>
		/// Years not divisible by 4 are definitely not leap years:
		/// </summary>
		[TestMethod]
		public void IsLeapYear_TestForNonLeapYear()
		{
			// Act:
			var result = DateTimeUtils.IsLeapYear(2015);

			// Assert:
			Assert.IsFalse(result);
		}

		/// <summary>
		/// Years divisible by 4 are usually leap years
		/// (but see below).
		/// </summary>
		[TestMethod]
		public void IsLeapYear_TestForStandardLeapYearDivisibleBy4()
		{
			// Act:
			var result = DateTimeUtils.IsLeapYear(2012);

			// Assert:
			Assert.IsTrue(result);
		}

		/// <summary>
		/// Years divisible by 400 are always leap years:
		/// </summary>
		[TestMethod]
		public void IsLeapYear_TestForLeapYearDivisibleBy400()
		{
			// Act:
			var result = DateTimeUtils.IsLeapYear(1600);

			// Assert:
			Assert.IsTrue(result);
		}

		/// <summary>
		/// Years divisible by 100 are never leap years,
		/// unless they are divisible by 400:
		/// </summary>
		[TestMethod]
		public void IsLeapYear_TestForNonLeapYearDivisibleBy100()
		{
			// Act:
			var result = DateTimeUtils.IsLeapYear(1900);

			// Assert:
			Assert.IsFalse(result);
		}

		/// <summary>
		/// Finally, throw in yet another test, just for good measure...
		/// </summary>
		[TestMethod]
		public void IsLeapYear_TestForNonLeapYearEdgeCase1()
		{
			// Act:
			var result = DateTimeUtils.IsLeapYear(1999);

			// Assert:
			Assert.IsFalse(result);
		}

		#endregion
	}
}
