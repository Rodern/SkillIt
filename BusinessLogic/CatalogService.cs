﻿using BusinessLogic.Interfaces;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class CatalogService : ICatalogService
	{
		private readonly skillit_dbContext DatabaseContext;
		public CatalogService(skillit_dbContext skill_It_DbContext)
		{
			this.DatabaseContext = skill_It_DbContext;
		}
		public ResponseModel AddCatalog(CatalogModel catalogModel)
		{
			try
			{
				Catalog catalog = new()
				{
					Caption = catalogModel.Caption,
					Description = catalogModel.Description,
					ImgBase64 = catalogModel.ImgBase64,
					CatalogLink = catalogModel.CatalogLink
				};
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
					DatabaseContext.Entry<Catalog>(catalog).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
					DatabaseContext.Catalogs.Remove(catalog);
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

		public ResponseModel UpdateCatalog(int id, CatalogModel catalogModel)
		{
			try
			{
				var this_catalog = DatabaseContext.Catalogs.Where(cat => cat.CatalogId == id).ToList().FirstOrDefault();
				if (this_catalog != null && catalogModel != null)
				{
					if (this_catalog.CatalogId == id)
					{
						this_catalog.Caption = catalogModel.Caption;
						this_catalog.Description = catalogModel.Description;
						this_catalog.ImgBase64 = catalogModel.ImgBase64;
						this_catalog.CatalogLink = catalogModel.CatalogLink;
						DatabaseContext.Entry<Catalog>(this_catalog).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
						DatabaseContext.Catalogs.Update(this_catalog);
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
