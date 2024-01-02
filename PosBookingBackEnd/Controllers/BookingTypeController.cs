using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PosBookingBackEnd.Interfaces;
using PosBookingBackEnd.Model.Requests;
using PosBookingBackEnd.Services;

namespace PosBookingBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTypeController : ControllerBase
    {
        IBookingTypeService bookingTypeService;
        public BookingTypeController(IBookingTypeService bookingTypeService) 
        {
            this.bookingTypeService = bookingTypeService; 
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(bookingTypeService.GetBookingTypes());

        }

    }
}
