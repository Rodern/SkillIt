using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using SkillIT_Models.Data;
using SkillIT_Models.Entities.Learning;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class CatalogService : ICatalogService
	{
		private readonly ApplicationDbContext DatabaseContext;
		public CatalogService(ApplicationDbContext skill_It_DbContext)
		{
			this.DatabaseContext = skill_It_DbContext;
		}
		public ResponseModel AddCatalog(Catalog catalog)
		{
			try
			{
				if (catalog == null) return new(false, "CatalogNull");
				//catalog.Image = Encoding.UTF8.GetBytes(imageString);// Convert.(imageString);
				DatabaseContext.Catalogs.Add(catalog);
				DatabaseContext.SaveChanges();
				return new ResponseModel(true, "Success");
			}
			catch (Exception ex)
			{

				return new(false, ex.Message);
			}
		}

		public ResponseModel DeleteCatalog(long id)
		{
			try
			{
				Catalog catalog = DatabaseContext.Catalogs.Find(id);
				if(catalog != null)
				{
					DatabaseContext.Entry(catalog).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
					DatabaseContext.Catalogs.Remove(catalog);
					DatabaseContext.SaveChanges();
					return new ResponseModel(true, "Success");
				}
				return new ResponseModel(false, "DeleteFailed");
			}
			catch (Exception ex)
			{
				return new(false, $"Error: {ex.Message}");
			}
		}

		public ObservableCollection<Catalog> GetAllCatalogs()
		{
			return new ObservableCollection<Catalog>(DatabaseContext.Catalogs.ToList());
		}

		public ObservableCollection<Tuple<long, string>> GetAllCatalogCaptions()
		{
			return new ObservableCollection<Tuple<long, string>>(DatabaseContext.Catalogs.Select(c => new Tuple<long, string>(c.Id, c.Descriptions)));
		}

		public Catalog GetCatalog(long id)
		{
			return DatabaseContext.Catalogs.Find(id);
		}

		public ResponseModel UpdateCatalog(long id, Catalog catalog)
		{
			try
			{
				var this_catalog = DatabaseContext.Catalogs.Where(cat => cat.Id == id).ToList().FirstOrDefault();
				if (this_catalog != null && catalog != null)
				{
					if (this_catalog.Id == id)
					{
						DatabaseContext.Entry(this_catalog).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
						DatabaseContext.Catalogs.Update(catalog);
						DatabaseContext.SaveChanges();
						return new ResponseModel(true, "Success");
					}
					return new ResponseModel(false, "Failed");
				}
				return new ResponseModel(false, "Failed");
			}
			catch (Exception ex)
			{
				return new ResponseModel(false, ex.Message);
			}
		}
	}
}
