using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
      //  [Authorize(Roles ="Product.List")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success) { return Ok(result); }
            
                return BadRequest(result.Message);

        }

        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _carService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getalldetailsbybrand")]
        public IActionResult GetAllDetailsByBrand(int brandId)
        {
            var result = _carService.GetAllDetailsByBrand(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getalldetailsbycolor")]
        public IActionResult GetAllDetailsByColor(int colorId)
        {
            var result = _carService.GetAllDetailsByColor(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getdetailbyid")]
        public IActionResult GetDetailById(int carId)
        {
            var result = _carService.GetDetail(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int Id)
        {
            var result = _carService.GetAllByBrandId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int Id)
        {
            var result = _carService.GetAllByColorId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }

}
