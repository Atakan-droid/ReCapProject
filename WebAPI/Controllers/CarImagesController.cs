using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;
        public CarImagesController(ICarImageService carImageService,IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
            
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var path = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);

            var carimage = new CarImage { CarId = carImage.CarId, ImagePath = path, Date = DateTime.Now };


            var result = _carImageService.Add2(carimage, fileExtension);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }

    }
}
