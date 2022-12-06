using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System.IO;
using Ubiety.Dns.Core;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace SkillItAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private byte[] Bytes { get; set; }
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

        [AllowAnonymous]
        [HttpGet]
        [Route("captions")]
        public IActionResult GetAllCatalogCaptions()
        {
            return Ok(_catalogService.GetAllCatalogCaptions());
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
        public IActionResult AddCatalog(string catalogJson, IFormFile image)
        {
            if (catalogJson.Length <= 0 || image == null) return BadRequest();
            Catalog catalog = JsonConvert.DeserializeObject<Catalog>(catalogJson);
            catalog.Image = ImageUpload.GetBytes(image);
            return Ok(_catalogService.AddCatalog(catalog));
        }

		[AllowAnonymous]
        [HttpPost]
        [Route("upload")]
        public IActionResult Upload(IFormFile image)
		{
            try
            {
                if (image.Length <= 0)
                {
                    return Ok(new ResponseModel()
                    {
                        Success = false,
                        Message = $"Failed: No image sent."
					});
				}
                long length = image.Length;
                if (length < 0)
					return BadRequest();

                using var fileStream = image.OpenReadStream();
                byte[] bytes = new byte[length];
                fileStream.Read(bytes, 0, (int)image.Length);
                this.Bytes = bytes;
				//return Ok(new ResponseModel(true, Convert.ToBase64String(bytes)));
				return Ok(new ResponseModel(true, "Done"));

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel()
                {
                    Success = false,
                    Message = $"Failed: {ex.Message}"
                });
            }
        }

        [HttpPut]
		[Route("UpdateCatalog")]
		public IActionResult UpdateCatalog(string catalogJson, IFormFile image)
		{
            if(catalogJson.Length <= 0 || image == null) return BadRequest();
            Catalog catalog = JsonConvert.DeserializeObject<Catalog>(catalogJson);
            catalog.Image = ImageUpload.GetBytes(image);
			return Ok(_catalogService.UpdateCatalog(catalog.CatalogId, catalog));
		}
	}
	public class Object
	{
		public Catalog catalog { get; set; }
		public string imageString{ get; set; }
	}
}
