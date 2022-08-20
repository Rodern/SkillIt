using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;

namespace SkillItAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CatalogController : ControllerBase
	{
		private readonly ICatalogService _catalogService;
		public CatalogController(ICatalogService catalogService)
		{
			this._catalogService = catalogService;
		}

		[HttpGet]
		[Route("GetAllCatalogs")]
		public IActionResult GetAllCatalogs()
		{
			return Ok(_catalogService.GetAllCatalogs());
		}

		[HttpPost]
		[Route("GetCatalog")]
		public IActionResult GetCatalog(int id)
		{
			return Ok(_catalogService.GetCatalog(id));
		}

		[HttpPost]
		[Route("AddCatalog")]
		public IActionResult AddCatalog(CatalogModel catalogModel)
		{
			return Ok(_catalogService.AddCatalog(catalogModel));
		}

		[HttpPut]
		[Route("UpdateCatalog/{id:int}")]
		public IActionResult UpdateCatalog([FromRoute] int id, CatalogModel catalogModel)
		{
			return Ok(_catalogService.UpdateCatalog(id, catalogModel));
		}
	}
}
