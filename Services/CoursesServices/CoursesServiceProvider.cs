using System.Collections.Generic;
using System.Linq;
using CoursesAPI.Models;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Exceptions;
using CoursesAPI.Services.Models.Entities;
using static CoursesAPI.Models.TeacherType;

namespace CoursesAPI.Services.CoursesServices
{
	public class CoursesServiceProvider
	{
		private readonly IUnitOfWork _uow;

		private readonly IRepository<CourseInstance> _courseInstances;
		private readonly IRepository<TeacherRegistration> _teacherRegistrations;
		private readonly IRepository<CourseTemplate> _courseTemplates; 
		private readonly IRepository<Person> _persons;

		public CoursesServiceProvider(IUnitOfWork uow)
		{
			_uow = uow;

			_courseInstances      = _uow.GetRepository<CourseInstance>();
			_courseTemplates      = _uow.GetRepository<CourseTemplate>();
			_teacherRegistrations = _uow.GetRepository<TeacherRegistration>();
			_persons              = _uow.GetRepository<Person>();
		}

		/// <summary>
		/// You should implement this function, such that all tests will pass.
		/// </summary>
		/// <param name="courseInstanceID">The ID of the course instance which the teacher will be registered to.</param>
		/// <param name="model">The data which indicates which person should be added as a teacher, and in what role.</param>
		/// <returns>Should return basic information about the person.</returns>
		public PersonDTO AddTeacherToCourse(int courseInstanceID, AddTeacherViewModel model)
		{

			var teacher = _persons.All().SingleOrDefault(t => model.SSN == t.SSN);

			var course = _courseInstances.All().SingleOrDefault(t => courseInstanceID == t.ID);

			if(course == null)
			{
				throw new AppObjectNotFoundException();
			}
			else if(teacher == null)
			{
				throw new AppObjectNotFoundException();
			}
			
			var mainTeacherAmount = _teacherRegistrations.All().Where(t => courseInstanceID == t.CourseInstanceID 
																		&& t.Type == MainTeacher).Count();

			if(mainTeacherAmount >= 1 && model.Type == MainTeacher)
			{
				throw new AppValidationException("A main teacher has been assigned for this course already");
			}

			var teacherRegistered = _teacherRegistrations.All().SingleOrDefault(t => courseInstanceID == t.CourseInstanceID 
																			&& t.SSN == model.SSN);

			if(teacherRegistered != null)
			{
				throw new AppValidationException("This person is already registered as teacher in this course");
			}

			_teacherRegistrations.Add(
				new TeacherRegistration
				{
					SSN = model.SSN,
					CourseInstanceID = courseInstanceID,
					Type = model.Type
				}
			);
			_uow.Save();

			return ( new PersonDTO { SSN = teacher.SSN, Name = teacher.Name });
		}

		/// <summary>
		/// You should write tests for this function. You will also need to
		/// modify it, such that it will correctly return the name of the main
		/// teacher of each course.
		/// </summary>
		/// <param name="semester"></param>
		/// <returns></returns>
		public List<CourseInstanceDTO> GetCourseInstancesBySemester(string semester = null)
		{
			if (string.IsNullOrEmpty(semester))
			{
				semester = "20153";
			}
			
			var teachernames = (from t in _teacherRegistrations.All()
				join p in _persons.All() on t.SSN equals p.SSN
				where t.Type == MainTeacher
				select new 
				{
					CourseInstanceID = t.CourseInstanceID,
					Name = p.Name
				}).ToList();

			var courses = (from c in _courseInstances.All()
				join ct in _courseTemplates.All() on c.CourseID equals ct.CourseID
				join t in teachernames on c.ID equals t.CourseInstanceID // needs an outer join
				//into temp from name in temp.DefaultIfEmpty()
				where c.SemesterID == semester
				select new CourseInstanceDTO
				{
					Name               = ct.Name,
					TemplateID         = ct.CourseID,
					CourseInstanceID   = c.ID,
					MainTeacher        = t.Name //"" // Hint: it should not always return an empty string!
				}).ToList();

			return courses;
		}
	}
}
