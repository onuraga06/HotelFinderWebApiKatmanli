using HotelFinderBusiness.Abstract;
using HotelFinderEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService hotelService;
        public HotelsController(IHotelService _hotelService)
        {
            hotelService = _hotelService;
        }
        [HttpGet] 
        public IActionResult GetList()
        {
            var values = hotelService.GetList();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var values = hotelService.GetByID(id);
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Sayfa Bulanamadı");

            }
        }
        [HttpPost]
        public IActionResult Create(Hotel entites)
        {
            if (ModelState.IsValid)
            {
                var value = hotelService.Add(entites);
                return Ok(value);
            }
            return BadRequest(ModelState);//404 + Error Mesaj
        }
        [HttpPut]
        public IActionResult Update(Hotel entites)
        {
            if (hotelService.GetByID(entites.Id) != null)
            {
                var values = hotelService.Update(entites);
                return Ok(values);
            }
            else
            {
                return NotFound("Güncelleme Gerçekleşmedi");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          
            if (hotelService.GetByID(id) != null)
            {
                var hotel = hotelService.GetByID(id);
                hotelService.Delete(id);
                return Ok(hotel);

            }
            else
            {
                return NotFound("Silme Gerceklesmedi");
            }

        }
       
    }
}
