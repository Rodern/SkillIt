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

		[AllowAnonymous]
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

		[HttpDelete]
		[Route("DeleteCatalog/id")]
		public IActionResult DeleteCatalog([FromRoute] int id)
		{
			return Ok(_catalogService.DeleteCatalog(id));
		}

		[HttpPost]
		[Route("AddCatalog")]
		public IActionResult AddCatalog(CatalogModel catalogModel)
		{
			return Ok(_catalogService.AddCatalog(catalogModel));
		}

		[HttpPut]
		[Route("UpdateCatalog/{id}")]
		public IActionResult UpdateCatalog([FromRoute] int id, CatalogModel catalogModel)
		{
			return Ok(_catalogService.UpdateCatalog(id, catalogModel));
		}
	}
}
