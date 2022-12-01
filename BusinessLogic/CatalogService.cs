using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;
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
		private readonly skill_it_dbContext DatabaseContext;
		public CatalogService(skill_it_dbContext skill_It_DbContext)
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

		public ResponseModel DeleteCatalog(int id)
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

		public Catalog GetCatalog(int id) => DatabaseContext.Catalogs.Where(cat => cat.CatalogId == id).FirstOrDefault();

		public ResponseModel UpdateCatalog(int id, Catalog catalog)
		{
			try
			{
				var this_catalog = DatabaseContext.Catalogs.Where(cat => cat.CatalogId == id).ToList().FirstOrDefault();
				if (this_catalog != null && catalog != null)
				{
					if (this_catalog.CatalogId == id)
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
