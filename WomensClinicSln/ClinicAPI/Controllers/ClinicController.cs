using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Data;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {

        private readonly ClinicContext _context;

        public ClinicController(ClinicContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Login>> PostLoginDetails(Login tee)
        {
            _context.LoginDetails.Add(tee);
            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}