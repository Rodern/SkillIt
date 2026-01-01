using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace BusinessLogic
{
    public class EntityService : IEntityService
	{
		private readonly skill_it_dbContext DbContext;
		public EntityService(skill_it_dbContext storeContext)
		{
			DbContext = storeContext;
		}

		#region Entity
		public ResponseModel AddEntity<T>(T entity) where T : class
		{
			string name = typeof(T).Name;
			if (entity == null) return new(false, $"{name}Null");
			try
			{
				DbContext.Add<T>(entity);
				DbContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, $"Failed: {ex}");
			}
		}
		public ResponseModel UpdateEntity<T>(T entity) where T : class
		{
			string name = typeof(T).Name;
			if (entity == null) return new(false, $"{name}NotFound");
			try
			{
				DbContext.Entry<T>(entity).State = EntityState.Detached;
				//StoreContext.Entry<T>(entity).State = EntityState.Modified;
				DbContext.Update<T>(entity);
				DbContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, $"Failed: {ex}");
			}
		}
		public ResponseModel DeleteEntity<T>(int id) where T : class
		{
			T obj = DbContext.Find<T>(id);
			string name = typeof(T).Name;
			if (obj == null) return new(false, $"{name}NotFound");
			try
			{
				DbContext.Entry<T>(obj).State = EntityState.Deleted;
				//DbContext.Remove<T>(obj);
				DbContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, $"Failed: {ex}");
			}
		}
		public ResponseModel DeleteEntity<T>(long id) where T : class
		{
			T obj = DbContext.Find<T>(id);
			string name = typeof(T).Name;
			if (obj == null) return new(false, $"{name}NotFound");
			try
			{
				DbContext.Entry<T>(obj).State = EntityState.Deleted;
				//DbContext.Remove<T>(obj);
				DbContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, $"Failed: {ex}");
			}
		}
		#endregion
	}
}
