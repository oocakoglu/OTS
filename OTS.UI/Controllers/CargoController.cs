using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OTS.Core.Services;
using OTS.Model;
using OTS.UI.Attribute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.UI.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;
        private IWebHostEnvironment _env;
        public CargoController(IWebHostEnvironment webEnvironment, ICargoService cargoService)
        {
            this._cargoService = cargoService;
            _env = webEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            var list = await _cargoService.GetCargoList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Cargo cargo, IFormFile postedFile)
        {
            var value = HttpContext.Session.GetString("SessionContext");
            SessionContext scon = JsonConvert.DeserializeObject<SessionContext>(value);

            string fileName = "nullImage.png";
            if (postedFile != null)
            {
                string path = Path.Combine(_env.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (postedFile.Length > 0)
                {
                    string extension = Path.GetExtension(postedFile.FileName);
                    fileName = Guid.NewGuid().ToString() + extension;
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        await postedFile.CopyToAsync(stream);
                    }
                }
            }

            cargo.CargoImageUrl = "/Uploads/" + fileName;
            cargo.UserId = scon.UserId;
            await _cargoService.CreateCargo(cargo);
            return Redirect("/Cargo/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
            {
                return Redirect("/Cargo/Index");
            }

            Cargo cargo = await _cargoService.GetCargoById(Id.Value);
            if (cargo == null)
            {
                return Redirect("/Cargo/Index");
            }

            return View(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Cargo cargo, IFormFile postedFile)
        {
            var value = HttpContext.Session.GetString("SessionContext");
            SessionContext scon = JsonConvert.DeserializeObject<SessionContext>(value);

            if (postedFile != null)
            {
                string path = Path.Combine(_env.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (postedFile.Length > 0)
                {
                    string extension = Path.GetExtension(postedFile.FileName);
                    string fileName = Guid.NewGuid().ToString() + extension;
                    cargo.CargoImageUrl = "/Uploads/" + fileName;
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        await postedFile.CopyToAsync(stream);
                    }
                }
            }
            
            cargo.UserId = scon.UserId;
            await _cargoService.UpdateCargoById(cargo, cargo.CargoId);
            return Redirect("/Cargo/Index");
        }

   
        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return Redirect("/Cargo/Index");
            }
            await _cargoService.DeleteCargoById(Id.Value);
            return Redirect("/Cargo/Index");
        }

    }
}
