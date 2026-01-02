using SkillIT_Models.Entities.Learning;
using SkillIT_Models.Models;
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
		ObservableCollection<Tuple<long, string>> GetAllCatalogCaptions();
        ResponseModel AddCatalog(Catalog catalog);
		Catalog GetCatalog(long id);
		ResponseModel UpdateCatalog(long id, Catalog catalog);
		ResponseModel DeleteCatalog(long id);
	}
}
