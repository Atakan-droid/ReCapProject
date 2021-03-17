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
        public IActionResult Add([FromForm(Name =("Image"))] IFormFile file,[FromForm] CarImage carImage)
        {
            var result = _carImageService.Add2(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("testupload")]
        public string Post([FromForm(Name =("Image"))] IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream=System.IO.File.Create(path+file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Updated";
                    }
                }
                else
                {
                    return "Not Uploaded";
                }
            }catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("getbycarid")]
        public IActionResult GetAll(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
         
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id,[FromForm(Name =("Image"))] IFormFile file)
        {

            var carImage = _carImageService.GetById(Id).Data;

            var result = _carImageService.Delete2(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageService.GetById(Id).Data;
            var result = _carImageService.Update2(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
