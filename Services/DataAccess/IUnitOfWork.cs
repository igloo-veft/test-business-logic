using System;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Services.DataAccess
{
	/// <summary>
	/// Interface for Unit Of Work pattern
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
		void Save();
	}
}
