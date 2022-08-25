using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface ICatalogService
	{
		ObservableCollection<Catalog> GetAllCatalogs();
		ResponseModel AddCatalog(CatalogModel catalogModel);
		Catalog GetCatalog(int id);
		ResponseModel UpdateCatalog(int id, CatalogModel catalogModel);
		ResponseModel DeleteCatalog(int id);
	}
}
