using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Interfaces
{
	public interface ICatalogService
	{
		ObservableCollection<Catalog> GetAllCatalogs();
		ResponseModel AddCatalog(Catalog catalog);
		Catalog GetCatalog(int id);
		ResponseModel UpdateCatalog(int id, Catalog catalog);
		ResponseModel DeleteCatalog(int id);
	}
}
