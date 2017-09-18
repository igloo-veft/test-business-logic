using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesAPI.Services.Models.Entities
{
	class StudentCourseRegistration
	{
		public int ID { get; set; }
		public string SSN { get; set; }
		public int CourseInstanceID { get; set; }
		public bool Active { get; set; }
	}
}
