using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace SkillIT_UI.Controllers
{
	[Route("fileBrowser")]
	[ApiController]
	public partial class FileBrowserController : Controller
	{

		private readonly string RootPath = string.Empty;
		private readonly string ThumbnailsPath = string.Empty;
		private readonly string ThumbnailExtension = string.Empty;

		public FileBrowserController(IWebHostEnvironment environment)
		{
			RootPath = environment.WebRootPath + "/site_data";
			ThumbnailsPath = RootPath + "/thumbnails";
			ThumbnailExtension = "_thumbnail";
		}

		[HttpGet]
		[Route("createDirectory")]
		public IActionResult CreateDirectory(string name, string size = "", string type = "d", string path = "")
		{
			if (type != "d") return BadRequest("Not a directory!");
			try
			{
				string combinedPath = RootPath + $"/{path}{name}";
				if (!Directory.Exists(combinedPath))
				{
					var dirInfo = Directory.CreateDirectory(combinedPath);

					FileObjectInfo objectInfo = new()
					{
						Name = name,
						Path = path,
						Size = 0,
						Type = type,
					};

					return Ok(objectInfo);
				}
				return Ok("Directory exists!");
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}

		[HttpPost]
		[Route("read")]
		public IActionResult ReadDirectory()
		{
			//if (string.IsNullOrEmpty(path)) return BadRequest("Path not provided!");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
			string path = ""; path = HttpContext.Request.Form.FirstOrDefault().Value.FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
			if (path.Length == 0) path = "";
#pragma warning restore CS8602 // Dereference of a possibly null reference.

			else path = "/" + path[..^1];
			//path = path.Replace("path=", "");

			List<FileObjectInfo> fileObjectInfos = new();

			List<string> folders = new();
			folders.AddRange(Directory.GetDirectories(RootPath + path));

			foreach (var folder in folders.OrderBy(x => x))
			{
				if (!folder.Contains("thumbnails"))
				{
					fileObjectInfos.Add(new()
					{
						Name = folder[(folder.LastIndexOf("\\") + 1)..],
						Type = "d",
						Path = folder,
						Size = 0
					});
				}
			}

			List<string> tFiles = new();
			tFiles.AddRange(Directory.GetFiles(RootPath + path));

			var files = new List<string>();
			files.AddRange(tFiles.Where(x => MyRegex().IsMatch(x) == true));

			foreach (var file in files.OrderBy(x => x))
			{
				fileObjectInfos.Add(new()
				{
					Name = file[(file.LastIndexOf("\\") + 1)..],
					Type = "f",
					Path = file,
					Size = 0
				});
			}

			return Ok(fileObjectInfos);
		}

		[HttpGet]
		[Route("reads")]
		public IActionResult ReadsDirectory(string path)
		{
			if (string.IsNullOrEmpty(path)) return BadRequest("Path not provided!");

			List<FileObjectInfo> fileObjectInfos = new();

			List<string> folders = new(); folders.AddRange(Directory.GetDirectories("\\site_data\\"));

			foreach (var folder in folders.OrderBy(x => x))
			{
				fileObjectInfos.Add(new()
				{
					Name = folder[(folder.LastIndexOf("\\") + 1)..],
					Type = "d",
					Path = folder,
					Size = 0
				});
			}

			List<string> tFiles = new(); tFiles.AddRange(Directory.GetFiles("\\site_data\\"));
			var files = new List<string>();
			files.AddRange(tFiles.Where(x => MyRegex().IsMatch(x) == true));

			foreach (var file in files.OrderBy(x => x))
			{
				fileObjectInfos.Add(new()
				{
					Name = file[(file.LastIndexOf("\\") + 1)..],
					Type = "d",
					Path = file,
					Size = 0
				});
			}

			return Ok(fileObjectInfos);
		}

		string getExtension(string fileName)
		{
			return fileName[fileName.LastIndexOf(".")..];
		}

		[HttpPost]
		[Route("uploadFile")]
		public IActionResult UploadFile()
		{
			string path = "";

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
			path = HttpContext.Request.Form["path"].FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
			if (path.Length == 0) path = string.Empty;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
			else path = "/" + path[..^1];

			IFormFile file = HttpContext.Request.Form.Files[0];

			string fileName = $"{file.FileName}";
			string fullPath = $"{RootPath}{path}/{fileName}";
			string ImageThumbnailPath = ThumbnailsPath + $"/{fileName.Replace(getExtension(fileName), "")}{ThumbnailExtension}{getExtension(fileName)}";

			using (FileStream fileStream = System.IO.File.Create(fullPath))
			{
				file.CopyTo(fileStream);
				fileStream.Flush();
			}
			using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(fullPath))
			{
				image.Mutate(x => x.Resize(image.Width / 12, image.Height / 12));
				//image.Mutate(x => x.Rotate(90));
				image.SaveAsPng(ImageThumbnailPath);
			}

			FileObjectInfo fileObjectInfo = new()
			{
				Name = fileName,
				Type = "f",
				Path = HttpContext.Request.Form["path"].FirstOrDefault(),
				Size = file.Length,
			};

			return Ok(fileObjectInfo);
		}

		[HttpGet]
		[Route("destroy")]
		public IActionResult Destroy(string name, string size = "", string type = "d", string path = "")
		{
			try
			{
				string combinedPath = RootPath + $"/{path}{name}";
				if (type == "d" && Directory.Exists(combinedPath))
				{
					Directory.Delete(combinedPath);
				}
				if (type == "f" && System.IO.File.Exists(combinedPath))
				{
					string thumbnailPath = ThumbnailsPath + $"/{name.Replace(getExtension(name), "")}{ThumbnailExtension}{getExtension(name)}";
					System.IO.File.Delete(combinedPath);
					System.IO.File.Delete(thumbnailPath);
				}
				return Ok();
			}
			catch (Exception)
			{
				return Ok();
			}
		}

		[HttpGet]
		[Route("getThumbnailUrl")]
		public IActionResult GetThumbnail(string path)
		{
			string combinedPath = ThumbnailsPath + "/" + path.Replace(getExtension(path), "") + ThumbnailExtension + getExtension(path);
			if (path.Contains(".svg"))
			{
				return Ok(System.IO.File.OpenRead(RootPath + "/" + path));
			}
			if (System.IO.File.Exists(combinedPath))
			{
				return Ok(System.IO.File.OpenRead(combinedPath));
			}
			return Ok(System.IO.File.OpenRead(RootPath + "/" + path));
		}

		[GeneratedRegex("\\.jpg$|\\.jpeg$|\\.png$|\\.gif$|\\.svg$|\\.tiff$|\\.bmp$")]
		private static partial Regex MyRegex();
	}
}
