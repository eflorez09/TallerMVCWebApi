using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TallerMVCWebApi.Models;

namespace TallerMVCWebApi.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                return Ok(contact);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult List()
        {
            List<ContactViewModel> concats = new List<ContactViewModel>();

            concats.Add(new ContactViewModel
            {
                Name = "Elver Florez",
                Email = "elver@mail.com",
                Phone = "3185419456",
                Message = "Hola"
            });

            return Ok(concats);
        }
    }
}